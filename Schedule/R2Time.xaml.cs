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

namespace Schedule
{
    public partial class R2Time
    {
        public R2Time()
        {
            InitializeComponent();
        }

        private void backToHomepage(object sender, RoutedEventArgs e)
        {
            MainWindow homepage = new MainWindow();
            homepage.WindowState = WindowState.Maximized; // Make full screen
            homepage.Show();

            this.Close(); // Close the current window
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string userInput = SearchBox.Text; // Get text from TextBox

            // Create a new Page to display the text
            Page searchResultPage = new Page();
            TextBlock resultText = new TextBlock
            {
                Text = "Search result: " + userInput,
                FontSize = 16,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };

            // Set Content of the Page
            searchResultPage.Content = resultText;

            // Navigate Frame to the new Page
            myFrame.Navigate(searchResultPage);
        }


    }
}
