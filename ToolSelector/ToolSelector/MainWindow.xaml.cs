using System;
using System.Collections.Generic;
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

namespace ToolSelector
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     Display popup message when a button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ApplyButton_OnClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"The description is: {this.DescriptionText.Text}");
        }

        /// <summary>
        ///     Reset all form values to default
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResetButton_OnClickButton_OnClick(object sender, RoutedEventArgs e)
        {
            this.WeldCheckbox.IsChecked 
                = this.AssemblyCheckbox.IsChecked 
                = this.PlasmaCheckbox.IsChecked 
                = this.LaserCheckbox.IsChecked 
                = this.PurchaseCheckbox.IsChecked 
                = this.LatheCheckbox.IsChecked 
                = this.DrillCheckbox.IsChecked 
                = this.FoldCheckbox.IsChecked 
                = this.RollCheckbox.IsChecked 
                = this.SawCheckbox.IsChecked 
                = false;

            this.NoteText.Text = "";
        }

        /// <summary>
        ///     Called when a checkbox is checked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Checkbox_OnChecked(object sender, RoutedEventArgs e)
        {
            this.LengthText.Text += (string)((CheckBox) sender).Content;
        }

        /// <summary>
        ///     Called when dropdown selection is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FinishDropdown_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (this.NoteText == null)
            {
                return;
            }
            var combo = (ComboBox) sender;
            var value = (ComboBoxItem) combo.SelectedValue;
            this.NoteText.Text = (string) value.Content;
        }

        /// <summary>
        ///     Set default values once the window is loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FinishDropdown_SelectionChanged(this.FinishDropdown, null);
        }

        /// <summary>
        ///     Call when the Supplier Name text is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SupplierNameText_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            this.MassText.Text = this.SupplierNameText.Text;
        }
    }
}
