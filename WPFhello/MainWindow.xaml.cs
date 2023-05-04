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

namespace WPFhello
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ListBoxItem mike = new ListBoxItem();
            mike.Content = "Mike";
            peopleListBox.Items.Add(mike);

            ListBoxItem lisa = new ListBoxItem();
            lisa.Content = "Lisa";
            peopleListBox.Items.Add(lisa);

            ListBoxItem john = new ListBoxItem();
            john.Content = "John";
            peopleListBox.Items.Add(john);

            ListBoxItem james = new ListBoxItem();
            james.Content = "James";
            peopleListBox.Items.Add(james);

            ListBoxItem mary = new ListBoxItem();
            mary.Content = "Mary";
            peopleListBox.Items.Add(mary);

            ListBoxItem david = new ListBoxItem();
            david.Content = "David";
            peopleListBox.Items.Add(david);

            peopleListBox.SelectedItem = david;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void Button_Greeting(object sender, RoutedEventArgs e)
        {
            string greeting = (peopleListBox.SelectedItem as ListBoxItem).Content.ToString();
            //MessageBox.Show("Hello " + greeting);

            MyMessage anotherMessage = new MyMessage();
            anotherMessage.Show();
        }
    }
}
