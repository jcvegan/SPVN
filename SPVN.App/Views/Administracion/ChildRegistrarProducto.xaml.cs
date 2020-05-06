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

namespace SPVN.App.Views.Administracion
{
    public partial class ChildRegistrarProducto : ChildWindow
    {
        public ChildRegistrarProducto()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(ChildRegistrarProducto_Loaded);
        }

        void ChildRegistrarProducto_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}

