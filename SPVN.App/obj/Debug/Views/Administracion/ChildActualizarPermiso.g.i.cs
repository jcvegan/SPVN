﻿#pragma checksum "C:\Taller Proyectos 2010-I\Desarrollo\SPVN\SPVN.App\Views\Administracion\ChildActualizarPermiso.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "7AC588E180E8E10FA291E9F55893F21D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace SPVN.App.Views.Administracion {
    
    
    public partial class ChildActualizarPermiso : System.Windows.Controls.ChildWindow {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.TextBox txtIDPermiso;
        
        internal System.Windows.Controls.TextBox txtNombrePermiso;
        
        internal System.Windows.Controls.TextBox txtDescripcionPermiso;
        
        internal System.Windows.Controls.TextBox txtNombrePaquete;
        
        internal System.Windows.Controls.Button CancelButton;
        
        internal System.Windows.Controls.Button OKButton;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/SPVN.App;component/Views/Administracion/ChildActualizarPermiso.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.txtIDPermiso = ((System.Windows.Controls.TextBox)(this.FindName("txtIDPermiso")));
            this.txtNombrePermiso = ((System.Windows.Controls.TextBox)(this.FindName("txtNombrePermiso")));
            this.txtDescripcionPermiso = ((System.Windows.Controls.TextBox)(this.FindName("txtDescripcionPermiso")));
            this.txtNombrePaquete = ((System.Windows.Controls.TextBox)(this.FindName("txtNombrePaquete")));
            this.CancelButton = ((System.Windows.Controls.Button)(this.FindName("CancelButton")));
            this.OKButton = ((System.Windows.Controls.Button)(this.FindName("OKButton")));
        }
    }
}

