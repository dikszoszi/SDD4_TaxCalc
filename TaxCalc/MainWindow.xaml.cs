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

[assembly: CLSCompliant(false)]
namespace TaxCalc
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

        private void CalculateTaxClick(object sender, RoutedEventArgs e)
        {
            string s = string.Empty;
            try
            {
                double income = double.Parse(txtIncome.Text, System.Globalization.NumberFormatInfo.CurrentInfo);
                double tax = double.Parse(txtTaxPercent.Text, System.Globalization.NumberFormatInfo.CurrentInfo);
                double prepaid = double.Parse(txtPrepaid.Text, System.Globalization.NumberFormatInfo.CurrentInfo);
                double result = income * (tax / 100) - prepaid;
                if (result > 0) s = "Remaining tax to be paid: " + result;
                else if (result < 0) s = "Overpaid. Your rebate is: " + (-result);
                else s = $"Your tax is paid. Thank you!\n {result}";
                MessageBox.Show(s, "Result", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                s = "Error occured. Try again!";
            }
            catch (OverflowException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                s = "Error occured. Try again!";
            }
            finally
            {
                tbkResult.Text = s;
            }
        }
    }
}
