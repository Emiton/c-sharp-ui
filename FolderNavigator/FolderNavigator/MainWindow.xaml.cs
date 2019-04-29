using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Path = System.IO.Path;

namespace FolderNavigator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Constructor 
        /// <summary>
        ///     Default constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        #endregion

        #region On Loaded

        /// <summary>
        ///     When the application first loads
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {

            foreach (var drive in Directory.GetLogicalDrives())
            {
                var item = new TreeViewItem()
                {
                    Header = drive,
                    Tag = drive
                };

                // Listen for item exapnsion
                item.Expanded += Folder_Expanded;

                item.Items.Add(null);

                FolderView.Items.Add(item);
            }
        }


        #endregion

        #region Folder Expanded
        /// <summary>
        ///     When a folder is expanded, find all subfolders and files
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Folder_Expanded(object sender, RoutedEventArgs e)
        {
            #region Initial Checks
            var item = (TreeViewItem)sender;

            // If item only contains dummy
            if (item.Items.Count != 1 || item.Items[0] != null)
                return;

            item.Items.Clear();

            var fullPath = (string)item.Tag;
            #endregion

            #region Get Folders

            var directories = new List<string>();

            try
            {
                var dirs = Directory.GetDirectories(fullPath);

                if (dirs.Length > 0)
                    directories.AddRange(dirs);
            }
            catch (Exception exception)
            {
                throw exception;
            }

            directories.ForEach(directoryPath =>
            {
                // Create directory item
                var subItem = new TreeViewItem()
                {
                    // Set folder name and full path
                    Header = GetFileFolderName(directoryPath),
                    Tag = directoryPath
                };

                // Add dummy item in order expand 'leaf' folders
                subItem.Items.Add(null);

                subItem.Expanded += Folder_Expanded;

                // Add item to the parent
                item.Items.Add(subItem);
            });
            #endregion

            #region Get Files
            var files = new List<string>();

            try
            {
                var fs = Directory.GetFiles(fullPath);

                if (fs.Length > 0)
                    files.AddRange(fs);
            }
            catch (Exception exception)
            {
                throw exception;
            }

            files.ForEach(filePath =>
            {
                // Create file item
                var subItem = new TreeViewItem()
                {
                    // Set file name and full path
                    Header = GetFileFolderName(filePath),
                    Tag = filePath
                };

                // Add item to the parent
                item.Items.Add(subItem);
            });
            #endregion
        }

        #endregion


    }
}
