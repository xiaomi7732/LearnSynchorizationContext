using System;
using System.Windows;
using ClassLib;

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Uri targetUri = new Uri("https://www.google.com");

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Correct usage:
                using (MyCurl myCurl = new MyCurl())
                {
                    string result = await myCurl.CurlAsync(targetUri).ConfigureAwait(true);
                    textBlockResult.Text = result;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            // Not that correct usage:
            using (MyCurl myCurl = new MyCurl())
            {
                string result = myCurl.CurlAsync(targetUri).Result;
                textBlockResult.Text = result;
            }
        }

        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            textBlockResult.Text = null;
        }
    }
}
