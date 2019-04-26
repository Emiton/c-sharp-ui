using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace FolderNavigator
{   
    /// <summary>
    ///     Convert a full path to a specific image type of drive, folder, or file
    /// </summary>
    //[ValueConversion(typeof(string), typeof(BitmapImage))]
    public class HeaderToImageConverter : IValueConverter
    {
        public static HeaderToImageConverter Instance = new HeaderToImageConverter(); 

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var path = (string) value;

            if (path == null)
                return null;

            // Get name and check path to determine icon type
            var name = MainWindow.GetFileFolderName(path);
            var image = "Images/file.png";

            if (string.IsNullOrEmpty(name))
            {
                image = "Images/drive.png";
            } else if (new FileInfo(path).Attributes.HasFlag(FileAttributes.Directory))
            {
                image = "Images/folder-closed.png";
            } 

            // To access resources in WPF as URIs, use 'pack://application:,,,/'
            return new BitmapImage(new Uri($"pack://application:,,,/{image}"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
