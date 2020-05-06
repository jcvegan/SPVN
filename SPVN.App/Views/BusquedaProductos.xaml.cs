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
using SPVN.ViewModel.Helpers;
//using SPVN.App.ServiceReference1;

namespace SPVN.App.Views
{
    public partial class BusquedaProductos : Page
    {
        //SPVNServicesClient _service;
        public BusquedaProductos()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(BusquedaProductos_Loaded);
        }

        void BusquedaProductos_Loaded(object sender, RoutedEventArgs e)
        {
            //_service = new SPVNServicesClient();
            //_service.SeleccionarTodasCategoriasAsync();
            //_service.SeleccionarTodasCategoriasCompleted += new EventHandler<SeleccionarTodasCategoriasCompletedEventArgs>(_service_SeleccionarTodasCategoriasCompleted);
        }

        //void _service_SeleccionarTodasCategoriasCompleted(object sender, SeleccionarTodasCategoriasCompletedEventArgs e)
        //{
        //    comboBox1.ItemsSource = e.Result;
        //}

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

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            
        }

    }
}
