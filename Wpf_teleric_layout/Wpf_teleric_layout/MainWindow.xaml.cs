using Microsoft.Win32;
using System;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Windows;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.RichTextBoxUI;
using Telerik.Windows.Controls.RichTextBoxUI.Dialogs;
using Telerik.Windows.Documents.Flow.FormatProviders.Html;
using Telerik.Windows.Documents.Flow.FormatProviders.Rtf;
using Telerik.Windows.Documents.Flow.FormatProviders.Txt;
using Telerik.Windows.Documents.FormatProviders;
using Telerik.Windows.Documents.FormatProviders.OpenXml.Docx;
using Telerik.Windows.Documents.FormatProviders.Pdf;
using Telerik.Windows.Documents.FormatProviders.Xaml;
using Telerik.Windows.Documents.Model;
using Telerik.Windows.Documents.Proofing;
using Telerik.Windows.Documents.RichTextBoxCommands;
using Telerik.Windows.Documents.UI.Extensibility;

using Wpf_teleric_layout.Helpers;

namespace Wpf_teleric_layout
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : RadRibbonWindow
    {
        private const string SampleDocumentFile = "SampleWordDocument.docx";

        static MainWindow()
        {
            StyleManager.ApplicationTheme = new Office2013Theme();
            RadRibbonWindow.IsWindowsThemeEnabled = false;
        }

        public MainWindow()
        {
            RadCompositionInitializer.Catalog = new TypeCatalog(
           // format providers
           typeof(XamlFormatProvider),
           typeof(RtfFormatProvider),
           typeof(DocxFormatProvider),
           typeof(HtmlFormatProvider),
           typeof(TxtFormatProvider),

           // mini toolbars
           typeof(SelectionMiniToolBar),
           typeof(ImageMiniToolBar),

           // context menu
           typeof(Telerik.Windows.Controls.RichTextBoxUI.ContextMenu),

           // the default English spell checking dictionary
           typeof(RadEn_USDictionary),

           // dialogs
           typeof(AddNewBibliographicSourceDialog),
           typeof(ChangeEditingPermissionsDialog),
           typeof(EditCustomDictionaryDialog),
           typeof(FindReplaceDialog),
           typeof(FloatingBlockPropertiesDialog),
           typeof(FontPropertiesDialog),
           typeof(ImageEditorDialog),
           typeof(InsertCaptionDialog),
           typeof(InsertCrossReferenceWindow),
           typeof(InsertDateTimeDialog),
           typeof(InsertTableDialog),
           typeof(InsertTableOfContentsDialog),
           typeof(ManageBibliographicSourcesDialog),
           typeof(ManageBookmarksDialog),
           typeof(ManageStylesDialog),
           typeof(NotesDialog),
           typeof(ProtectDocumentDialog),
           typeof(RadInsertHyperlinkDialog),
           typeof(RadInsertSymbolDialog),
           typeof(RadParagraphPropertiesDialog),
           typeof(SetNumberingValueDialog),
           typeof(SpellCheckingDialog),
           typeof(StyleFormattingPropertiesDialog),
           typeof(TableBordersDialog),
           typeof(TablePropertiesDialog),
           typeof(TabStopsPropertiesDialog),
           typeof(UnprotectDocumentDialog),
           typeof(WatermarkSettingsDialog)
           );

            InitializeComponent();
            IconSources.ChangeIconsSet(IconsSet.Modern);

            this.Loaded += this.MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.LoadSampleDocument();
            this.radRichTextBox.CommandExecuting += this.RadRichTextBoxCommandExecuting;
        }

        private void RadRichTextBoxCommandExecuting(object sender, CommandExecutingEventArgs e)
        {
            if (e.Command == this.radRichTextBox.Commands.OpenDocumentCommand)
            {
                e.Cancel = true;
                this.OpenFile(e.CommandParameter);
            }
            else if (e.Command == this.radRichTextBox.Commands.SaveCommand)
            {
                e.Cancel = true;
                this.SaveFile(e.CommandParameter);
            }
        }

        private void OpenFile(object parameter)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            string stringParameter = parameter as string;
            if (stringParameter != null && stringParameter.Contains("|"))
            {
                ofd.Filter = stringParameter;
            }
            else
            {
                string filter = string.Join("|", DocumentFormatProvidersManager.FormatProviders.Where(fp => fp.CanImport)
                                                                                               .OrderBy(fp => fp.Name)
                                                                                               .Select(fp => FileHelper.GetFilter(fp))
                                                                                               .ToArray()) + "|All Files|*.*";
                ofd.Filter = filter;
            }

            if (ofd.ShowDialog() == true)
            {
                string extension;
                extension = Path.GetExtension(ofd.SafeFileName).ToLower();

                IDocumentFormatProvider provider =
                    DocumentFormatProvidersManager.GetProviderByExtension(extension);

                if (provider == null)
                {
                    MessageBox.Show(LocalizationManager.GetString("Documents_OpenDocumentCommand_UnsupportedFileFormat"));
                    return;
                }

                try
                {
                    Stream stream;
                    stream = ofd.OpenFile();
                    using (stream)
                    {
                        RadDocument document = provider.Import(stream);
                        this.radRichTextBox.Document = document;
                        this.SetDocumentName(ofd.SafeFileName);
                    }
                }
                catch (IOException)
                {
                    MessageBox.Show(LocalizationManager.GetString("Documents_OpenDocumentCommand_TheFileIsLocked"));
                }
                catch (Exception)
                {
                    MessageBox.Show(LocalizationManager.GetString("Documents_OpenDocumentCommand_TheFileCannotBeOpened"));
                }
            }
        }

        private void SaveFile(object parameter)
        {
            string extension = null;
            Stream outputStream = null;
            SaveFileDialog saveDialog = new SaveFileDialog();
            string exportFormat = parameter as string;

            if (exportFormat != null && exportFormat.Contains("|"))
            {
                saveDialog.Filter = exportFormat;
            }
            else
            {
                var formatProviders = DocumentFormatProvidersManager.FormatProviders;

                if (!string.IsNullOrEmpty(exportFormat))
                {
                    string[] extensions = exportFormat.Split(',', ';').Select(e => e.Trim('.').ToLower()).ToArray();
                    formatProviders = formatProviders.Where(fp => fp.SupportedExtensions.Any(ext => extensions.Contains(ext.Trim('.').ToLower())));
                }

                string filter = string.Join("|", formatProviders.Where(fp => fp.CanExport)
                                                                .OrderBy(fp => fp.Name)
                                                                .Select(fp => FileHelper.GetFilter(fp))
                                                                .ToArray());
                saveDialog.Filter = filter;
            }

            bool? dialogResult = saveDialog.ShowDialog();
            if (dialogResult == true)
            {
                extension = System.IO.Path.GetExtension(saveDialog.SafeFileName);
                outputStream = saveDialog.OpenFile();

                IDocumentFormatProvider provider = DocumentFormatProvidersManager.GetProviderByExtension(extension);

                if (provider == null)
                {
                    MessageBox.Show(LocalizationManager.GetString("Documents_SaveCommand_UnsupportedFileFormat"));
                    return;
                }

                if (provider is IConfigurablePdfFormatProvider)
                {
                    IConfigurablePdfFormatProvider pdfFormatProvider = (IConfigurablePdfFormatProvider)provider;
                    pdfFormatProvider.ExportSettings.CommentsExportMode =
                        this.radRichTextBox.ShowComments ? PdfCommentsExportMode.NativePdfAnnotations : PdfCommentsExportMode.None;
                }

                try
                {
                    using (outputStream)
                    {
                        provider.Export(this.radRichTextBox.Document, outputStream);
                        this.SetDocumentName(saveDialog.SafeFileName);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show(LocalizationManager.GetString("Documents_SaveCommand_UnableToSaveFile"));
                }
            }
        }

        private void LoadSampleDocument()
        {
            using (Stream stream = FileHelper.GetSampleResourceStream(MainWindow.SampleDocumentFile))
            {
                stream.Seek(0, SeekOrigin.Begin);
                byte[] bytes = new byte[stream.Length];
                stream.Read(bytes, 0, bytes.Length);

                this.radRichTextBox.Document = new DocxFormatProvider().Import(bytes);
                this.SetDocumentName(MainWindow.SampleDocumentFile);
            }
        }

        private void SetDocumentName(string name)
        {
            this.ribbon.ApplicationName = name;
        }
    }
}
