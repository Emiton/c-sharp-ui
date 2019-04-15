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

        private void ApplyButton_OnClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"The description is: {this.DescriptionText.Text}");
        }

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
        }

        private void Checkbox_OnChecked(object sender, RoutedEventArgs e)
        {
            this.LengthText.Text += (string)((CheckBox) sender).Content;
        }
    }
}
