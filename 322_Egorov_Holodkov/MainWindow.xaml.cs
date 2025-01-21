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

namespace _322_Egorov_Holodkov {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e) {
            try {
                double x = double.Parse(InputX.Text);
                double y = double.Parse(InputM.Text);

                double f = 0;
                if (RadioSh.IsChecked == true) {
                    f = Math.Sinh(x);
                }
                else if (RadioX2.IsChecked == true) {
                    f = Math.Pow(x, 2);
                }
                else if (RadioExp.IsChecked == true) {
                    f = Math.Exp(x);
                }

                double b;
                if (x / y > 0) {
                    b = Math.Log(f) + Math.Pow(f * f + y, 3);
                }
                else if (x / y < 0) {
                    b = Math.Log(Math.Abs(f / y)) + Math.Pow(f + y, 3);
                }
                else if (x == 0) {
                    b = Math.Pow(f * f + y, 3);
                }
                else {
                    b = 0;
                }

                OutputResult.Text = b.ToString("F2");
            }
            catch (Exception ex) {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e) {
            InputX.Clear();
            InputM.Clear();
            OutputResult.Clear();
            RadioSh.IsChecked = false;
            RadioX2.IsChecked = false;
            RadioExp.IsChecked = false;
        }
    }
}