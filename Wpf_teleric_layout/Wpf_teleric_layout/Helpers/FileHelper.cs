using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using Telerik.Windows.Documents.FormatProviders;

namespace Wpf_teleric_layout.Helpers
{
    public static class FileHelper
    {
        private const string SampleDataFolder = "SampleData/";

        public static string GetFilter(IDocumentFormatProvider formatProvider)
        {
            return
                formatProvider.FilesDescription +
                " (" +
                string.Join(", ", formatProvider.SupportedExtensions.Select(ext => "*" + ext).ToArray()) +
                ")|" +
                string.Join(";", formatProvider.SupportedExtensions.Select(ext => "*" + ext).ToArray());
        }

        public static IDocumentFormatProvider GetFormatProvider(string extension)
        {
            IDocumentFormatProvider formatProvider = DocumentFormatProvidersManager.GetProviderByExtension(extension);
            return formatProvider;
        }

        public static Stream GetSampleResourceStream(string resource)
        {
            var streamInfo = Application.GetResourceStream(GetResourceUri(SampleDataFolder + resource));
            if (streamInfo != null)
            {
                return streamInfo.Stream;
            }

            return null;
        }

        private static Uri GetResourceUri(string resource)
        {
            AssemblyName assemblyName = new AssemblyName(typeof(FileHelper).Assembly.FullName);
            string resourcePath = "/" + assemblyName.Name + ";component/" + resource;
            Uri resourceUri = new Uri(resourcePath, UriKind.Relative);

            return resourceUri;
        }
    }
}
