﻿#pragma checksum "F:\Desarrollo\SPVN\SPVN.ViewModel\Helpers\AdminPerfiles\ChildRegistrarPerfil.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "2F70F2B15FB6C4E9691AFA5F987C8BDB"
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


namespace SPVN.ViewModel.Helpers.AdminPerfiles {
    
    
    public partial class ChildRegistrarPerfil : System.Windows.Controls.ChildWindow {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Button CancelButton;
        
        internal System.Windows.Controls.Button OKButton;
        
        internal System.Windows.Controls.TextBox txtNombrePerfil;
        
        internal System.Windows.Controls.TextBox txtDescripcionPerfil;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/SPVN.ViewModel;component/Helpers/AdminPerfiles/ChildRegistrarPerfil.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.CancelButton = ((System.Windows.Controls.Button)(this.FindName("CancelButton")));
            this.OKButton = ((System.Windows.Controls.Button)(this.FindName("OKButton")));
            this.txtNombrePerfil = ((System.Windows.Controls.TextBox)(this.FindName("txtNombrePerfil")));
            this.txtDescripcionPerfil = ((System.Windows.Controls.TextBox)(this.FindName("txtDescripcionPerfil")));
        }
    }
}
