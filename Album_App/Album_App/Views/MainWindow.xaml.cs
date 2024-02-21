using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Album_App.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           InitIcon();
        }

        private void InitIcon()
        {
            try
            {
                // Load the icon from the embedded resource
                Uri iconUri = new Uri("./Resources/AppIcon/cupid.ico", UriKind.Relative);
                Icon = new BitmapImage(iconUri);
            }
            catch (Exception ex)
            {
                // Handle the error, e.g., log it or display a message to the user
                Console.WriteLine("Error loading icon: " + ex.Message);
            }
        }
    }
}
