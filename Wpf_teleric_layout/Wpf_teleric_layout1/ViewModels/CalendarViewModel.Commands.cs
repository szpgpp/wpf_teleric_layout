using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Threading;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Docking;
using Telerik.Windows.Controls.RichTextBoxUI;
using Telerik.Windows.Controls.ScheduleView;

namespace Wpf_teleric_layout1
{
    public partial class CalendarViewModel
    {
        public DelegateCommand PreviewShowCompassCommand { get; private set; }
        public DelegateCommand OpenDialogCommand { get; private set; }
        public DelegateCommand SetCategoryCommand { get; private set; }
        public DelegateCommand SetTimeMarkerCommand { get; private set; }
        public DelegateCommand SetTodayCommand { get; private set; }
        public DelegateCommand SetWorkWeekCommand { get; private set; }
        public DelegateCommand SetWeekViewCommand { get; private set; }
        public DelegateCommand DiscardCommand { get; set; }
        public DelegateCommand MenuOpenStateChangedCommand { get; private set; }
        public DelegateCommand SelectCalendarCommand { get; private set; }

        public CalendarViewModel()
        {
            this.InitializeProperties();
            this.InitializeCommands();
        }

        private void InitializeCommands()
        {
            this.PreviewShowCompassCommand = new DelegateCommand(this.OnPreviewShowCompassCommandExecuted);
            this.SelectCalendarCommand = new DelegateCommand(this.OnSelectedCalendarCommandExecuted);
            this.OpenDialogCommand = new DelegateCommand(this.OnOpenDialogCommandExecuted);
            this.SetCategoryCommand = new DelegateCommand(this.OnSetCategoryCommandExecuted, o => this.SelectedAppointment != null);
            this.SetTimeMarkerCommand = new DelegateCommand(this.OnSetTimeMarkerCommandExecuted, o => this.SelectedAppointment != null);
            this.SetTodayCommand = new DelegateCommand(this.OnSetTodayCommandExecuted);
            this.SetWorkWeekCommand = new DelegateCommand(this.OnSetWorkWeekCommandExecuted, o => this.ActiveViewDefinitionIndex != 2);
            this.SetWeekViewCommand = new DelegateCommand(this.OnSetWeekViewCommandExecuted, o => this.ActiveViewDefinitionIndex != 1);
            this.DiscardCommand = new DelegateCommand(this.OnDiscardCommandExecute);
            this.MenuOpenStateChangedCommand = new DelegateCommand(this.OnMenuOpenStateChangedCommandExecuted);
        }

        private void InitializeProperties()
        {
            this._selectedResourceNames = new List<string>();
            this.ActiveViewDefinitionIndex = 2;
            this.Appointments = SampleContentService.GetCalendarAppointments();
            this.UpdateGroupFilter();
        }


        private void OnSelectedCalendarCommandExecuted(object parameter)
        {
            var args = parameter as SelectionChangedEventArgs;
            var radListBoxControl = args.OriginalSource as RadListBox;
            if (radListBoxControl != null)
            {
                var selectedItems = radListBoxControl.SelectedItems.Cast<CheckBoxItem>().ToList();
                this._selectedResourceNames.Clear();
                foreach (var item in selectedItems)
                {
                    this._selectedResourceNames.Add(item.Text);
                }
            }

            this.UpdateGroupFilter();
        }

        private void OnPreviewShowCompassCommandExecuted(object param)
        {
            var args = (PreviewShowCompassEventArgs)param;
            if (args.TargetGroup != null)
            {
                args.Compass.IsCenterIndicatorVisible = false;
                args.Compass.IsLeftIndicatorVisible = false;
                args.Compass.IsTopIndicatorVisible = false;
                args.Compass.IsRightIndicatorVisible = false;
                args.Compass.IsBottomIndicatorVisible = false;
            }
            else
            {
                args.Compass.IsCenterIndicatorVisible = CanDock(args.DraggedElement, DockPosition.Center);
                args.Compass.IsLeftIndicatorVisible = CanDock(args.DraggedElement, DockPosition.Left);
                args.Compass.IsTopIndicatorVisible = CanDock(args.DraggedElement, DockPosition.Top);
                args.Compass.IsRightIndicatorVisible = CanDock(args.DraggedElement, DockPosition.Right);
                args.Compass.IsBottomIndicatorVisible = CanDock(args.DraggedElement, DockPosition.Bottom);
            }

            args.Canceled = !(CompassNeedsToShow(args.Compass));
        }

        private void OnOpenDialogCommandExecuted(object obj)
        {
            RadWindow.Alert(
                new DialogParameters
                {
                    Content = string.Format("{0}'s command executed.", obj.ToString()),
                    Header = "Telerik"
                });
        }

        private void OnSelectedOutlookSectionCommandExecuted(object obj)
        {
            var args = obj as SelectionChangedEventArgs;
            var radListBoxControl = args.OriginalSource as RadListBox;
            if (radListBoxControl != null)
            {
                var selectedItems = radListBoxControl.SelectedItems.Cast<CheckBoxItem>().ToList();
                this._selectedResourceNames.Clear();
                foreach (var item in selectedItems)
                {
                    this._selectedResourceNames.Add(item.Text);
                }
            }

            this.UpdateGroupFilter();
        }


        public void OnSetCategoryCommandExecuted(object parameter)
        {
            Appointment appointment = this.SelectedAppointment as Appointment;
            Category newCategory = parameter as Category;
            IExceptionOccurrence exceptionToEdit = null;
            if (!(this.SelectedAppointment is Appointment))
            {
                appointment = (this.SelectedAppointment as Occurrence).Master as Appointment;
                if (appointment.RecurrenceRule != null)
                {
                    exceptionToEdit = appointment.RecurrenceRule.Exceptions.SingleOrDefault(e => (e.Appointment as IOccurrence) == ((Telerik.Windows.Controls.ScheduleView.Occurrence)(this.SelectedAppointment)).Appointment);
                    if (exceptionToEdit != null)
                    {
                        appointment.RecurrenceRule.Exceptions.Remove(exceptionToEdit);
                        (exceptionToEdit.Appointment as Appointment).Category = newCategory;
                        appointment.RecurrenceRule.Exceptions.Add(exceptionToEdit);
                    }
                }
            }

            Appointment appointmentToEdit = (from app in this.Appointments where app.Equals(appointment) select app).FirstOrDefault();
            if (exceptionToEdit == null)
            {
                appointmentToEdit.Category = newCategory;
            }

            var index = this.Appointments.IndexOf(appointmentToEdit);
            this.Appointments.Remove(appointmentToEdit);
            this.Appointments.Insert(index, appointmentToEdit);
        }

        public void OnSetTimeMarkerCommandExecuted(object parameter)
        {
            Appointment appointment = this.SelectedAppointment as Appointment;
            TimeMarker newTimeMarker = parameter as TimeMarker;
            IExceptionOccurrence exceptionToEdit = null;
            if (!(this.SelectedAppointment is Appointment))
            {
                appointment = (this.SelectedAppointment as Occurrence).Master as Appointment;
                if (appointment.RecurrenceRule != null)
                {
                    exceptionToEdit = appointment.RecurrenceRule.Exceptions.SingleOrDefault(e => (e.Appointment as IOccurrence) == ((Telerik.Windows.Controls.ScheduleView.Occurrence)(this.SelectedAppointment)).Appointment);
                    if (exceptionToEdit != null)
                    {
                        appointment.RecurrenceRule.Exceptions.Remove(exceptionToEdit);
                        (exceptionToEdit.Appointment as Appointment).TimeMarker = newTimeMarker;
                        appointment.RecurrenceRule.Exceptions.Add(exceptionToEdit);
                    }
                }
            }

            Appointment appointmentToEdit = (from app in this.Appointments where app.Equals(appointment) select app).FirstOrDefault();
            if (exceptionToEdit == null)
            {
                appointmentToEdit.TimeMarker = newTimeMarker;
            }

            var index = this.Appointments.IndexOf(appointmentToEdit);
            this.Appointments.Remove(appointmentToEdit);
            this.Appointments.Insert(index, appointmentToEdit);
        }

        public void OnSetTodayCommandExecuted(object parameter)
        {
            this.SelectedOutlookSection.SelectedItem = DateTime.Today;
        }

        public void OnSetWorkWeekCommandExecuted(object parameter)
        {
            this.ActiveViewDefinitionIndex = 2;
        }

        public void OnSetWeekViewCommandExecuted(object parameter)
        {
            this.ActiveViewDefinitionIndex = 1;
        }

        private void OnMenuOpenStateChangedCommandExecuted(object param)
        {
            var ribbon = param as RadRichTextBoxRibbonUI;
            if (ribbon.IsApplicationMenuOpen)
            {
                Dispatcher.CurrentDispatcher.BeginInvoke(new Action(() =>
                {
                    this.DiscardCommand.Execute(null);
                }));
            }
        }

        private void OnDiscardCommandExecute(object obj)
        {
            // Execute any actions that should be triggered when the RadRichTextBoxRibbonUI's ApplicationMenuOpen is opened.
        }

    }
}
