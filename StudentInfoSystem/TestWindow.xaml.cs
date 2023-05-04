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
using System.Windows.Shapes;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for TestWindow.xaml
    /// </summary>
    public partial class TestWindow : Window
    {
        public bool isAccepted;
        public TestWindow()
        {
            InitializeComponent();
           
        }

        private void Button_Yes(object sender, RoutedEventArgs e)
        {
            this.isAccepted = true;
            if (isAccepted)
            {
                MainWindow main = new MainWindow();
                main.Show();
                this.Hide();
            }
        }
        private void Button_No(object sender, RoutedEventArgs e)
        {

            this.isAccepted = false;
            MainWindow main = new MainWindow();
            main.Show();
            this.Hide();

        }


        }
}
