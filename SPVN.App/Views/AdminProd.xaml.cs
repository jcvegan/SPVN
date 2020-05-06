using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Navigation;
using System.Windows.Media.Imaging;
using System.IO;

namespace SPVN.App.Views
{
    public partial class AdminProd : Page
    {
        public AdminProd()
        {
            InitializeComponent();
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog _dialog = new OpenFileDialog();
            _dialog.Filter = "JPEG Files (*.jpg)|*.jpg";
            if (_dialog.ShowDialog() == true)
            {
                BitmapImage bmp = new BitmapImage();
                FileInfo info = _dialog.File;
                bmp.SetSource(info.OpenRead());
                image1.Source = bmp;
            }
        }

    }
}
