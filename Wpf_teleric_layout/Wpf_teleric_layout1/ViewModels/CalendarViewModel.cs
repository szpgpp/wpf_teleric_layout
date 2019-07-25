using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Docking;
using Telerik.Windows.Controls.ScheduleView;

namespace Wpf_teleric_layout1
{
    public partial class CalendarViewModel : ViewModelBase
    {
        private ObservableCollection<OutlookSection> _outlookSections;
        private OutlookSection _selectedOutlookSection;
        private IOccurrence _selectedAppointment;
        private ObservableCollection<Appointment> _appointments;
        private int _activeViewDefinitionIndex;
        private Func<object, bool> _groupFilter;
        private GroupDescriptionCollection _groupDescriptions;
        private List<string> _selectedResourceNames;

        /// <summary>
        /// Gets the GroupDescriptions
        /// </summary>
        public GroupDescriptionCollection GroupDescriptions
        {
            get
            {
                if (this._groupDescriptions == null)
                {
                    ResourceGroupDescription resourceGroupDescription = new ResourceGroupDescription();
                    resourceGroupDescription.ResourceType = "CalendarType";
                    this._groupDescriptions = new GroupDescriptionCollection() { resourceGroupDescription, new DateGroupDescription() };
                }

                return this._groupDescriptions;
            }
        }

        /// <summary>
        /// Gets or sets GroupFilter and notifies for changes
        /// </summary>
        public Func<object, bool> GroupFilter
        {
            get
            {
                return this._groupFilter;
            }

            set
            {

                this._groupFilter = value;
                this.OnPropertyChanged(() => this.GroupFilter);
            }
        }

        /// <summary>
        /// Gets or sets Appointments and notifies for changes
        /// </summary>
        public ObservableCollection<Appointment> Appointments
        {
            get
            {
                return this._appointments;
            }

            set
            {
                if (this._appointments != value)
                {
                    this._appointments = value;
                    this.OnPropertyChanged(() => this.Appointments);
                }
            }
        }

        /// <summary>
        /// Gets or sets SelectedAppointment and notifies for changes
        /// </summary>
        public IOccurrence SelectedAppointment
        {
            get
            {
                return this._selectedAppointment;
            }

            set
            {
                if (this._selectedAppointment != value)
                {
                    this._selectedAppointment = value;
                    this.SetCategoryCommand.InvalidateCanExecute();
                    this.SetTimeMarkerCommand.InvalidateCanExecute();
                    this.OnPropertyChanged(() => this.SelectedAppointment);
                }
            }
        }

        /// <summary>
        /// Gets or sets ActiveViewDefinitionIndex and notifies for changes
        /// </summary>
        public int ActiveViewDefinitionIndex
        {
            get
            {
                return this._activeViewDefinitionIndex;
            }

            set
            {
                if (this._activeViewDefinitionIndex != value)
                {
                    this._activeViewDefinitionIndex = value;
                    this.InvalidateGotoViewDefinitionCommands();
                    this.OnPropertyChanged(() => this.ActiveViewDefinitionIndex);
                }
            }
        }

        /// <summary>
        /// Gets or sets SelectedOutlookSection and notifies for changes
        /// </summary>
        public OutlookSection SelectedOutlookSection
        {
            get
            {
                if (this._selectedOutlookSection == null)
                {
                    this._selectedOutlookSection = this.OutlookSections.FirstOrDefault();
                    this._selectedOutlookSection.Command = new DelegateCommand(this.OnSelectedOutlookSectionCommandExecuted);
                }
                return this._selectedOutlookSection;
            }

            set
            {
                if (this._selectedOutlookSection != value)
                {
                    this._selectedOutlookSection = value;


                    this.OnPropertyChanged(() => this.SelectedOutlookSection);
                }
            }
        }

        /// <summary>
        /// Gets or sets OutlookSections and notifies for changes
        /// </summary>
        public ObservableCollection<OutlookSection> OutlookSections
        {
            get
            {
                if (this._outlookSections == null)
                {
                    this._outlookSections = SampleContentService.GetOutlookSections();
                }

                return this._outlookSections;
            }
        }

        private void InvalidateGotoViewDefinitionCommands()
        {
            if (this.SetWeekViewCommand != null && this.SetWorkWeekCommand != null)
            {
                this.SetWeekViewCommand.InvalidateCanExecute();
                this.SetWorkWeekCommand.InvalidateCanExecute();
            }
        }

        private void UpdateGroupFilter()
        {
            this.GroupFilter = new Func<object, bool>(this.GroupFilterFunc);
        }

        private bool GroupFilterFunc(object groupName)
        {
            IResource resource = groupName as IResource;

            return resource == null ? true : this._selectedResourceNames.Contains(resource.ResourceName, StringComparer.OrdinalIgnoreCase);
        }

        private Enums.PaneType GetPaneType(RadPane pane)
        {
            return ConditionalDockingHelper.GetPaneType(pane);
        }

        /// <summary>
        /// Determines if the Docking's Top, Bottom, Left and Right compasses should be shown for the Dragged Pane
        /// </summary>
        private bool CanDock(RadPane paneToDock, DockPosition position)
        {
            var paneToDockType = GetPaneType(paneToDock);
            switch (paneToDockType)
            {
                case Enums.PaneType.Normal:
                    return true;
                case Enums.PaneType.Restricted:
                    return position != DockPosition.Center && position != DockPosition.Top && position != DockPosition.Bottom;
                default:
                    return false;
            }
        }

        private bool CanDock(object dragged, DockPosition position)
        {
            var splitContainer = dragged as RadSplitContainer;

            return !splitContainer.EnumeratePanes().Any(p => !CanDock(p, position));
        }

        private bool IsExistingGroup(string groupName)
        {
            foreach (var group in this.GroupDescriptions)
            {
                if (group is ResourceGroupDescription)
                {
                    if ((group as ResourceGroupDescription).ResourceType == groupName)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static bool CompassNeedsToShow(Compass compass)
        {
            return compass.IsLeftIndicatorVisible
                || compass.IsTopIndicatorVisible
                || compass.IsRightIndicatorVisible
                || compass.IsBottomIndicatorVisible
                || compass.IsCenterIndicatorVisible;
        }
    }
}
