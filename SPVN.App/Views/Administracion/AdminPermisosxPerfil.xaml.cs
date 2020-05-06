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
using SPVN.ViewModel.SPVNServices;
using System.Collections.ObjectModel;
using SPVN.ViewModel;

namespace SPVN.App.Views.Administracion
{
    public partial class AdminPermisosxPerfil : UserControl
    {
        //List<T_Permiso> datasource = new List<T_Permiso>();
        AdminPermisosxPerfilViewModel vm;
        public AdminPermisosxPerfil()
        {
            InitializeComponent();
            vm = this.Resources["vm"] as AdminPermisosxPerfilViewModel;
        }

        private void PerfilxPermisoTarget_Drop(object sender, Microsoft.Windows.DragEventArgs e)
        {
            
            object data = e.Data.GetData(e.Data.GetFormats()[0]);
            ItemDragEventArgs dragEventArgs = data as ItemDragEventArgs;
            SelectionCollection selectionCollection = dragEventArgs.Data as SelectionCollection;
            if (selectionCollection != null)
            {
                IEnumerable<T_Permiso> permisos = selectionCollection.Select(selection => selection.Item).OfType<T_Permiso>();
                if (permisos.Any())
                {
                    foreach (T_Permiso per in permisos)
                    {
                        vm.ListPermiso.Add(per);
                    }
                }
            }
        }
    }
}
