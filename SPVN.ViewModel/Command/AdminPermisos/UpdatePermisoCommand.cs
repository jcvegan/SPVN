using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using SPVN.ViewModel.SPVNServices;

namespace SPVN.ViewModel.Command.AdminProductos
{
    public class UpdatePermisoCommand : ICommand
    {

        AdminPermisosViewModel viewModel;

        public UpdatePermisoCommand(AdminPermisosViewModel _adminPermisos)
        {
            viewModel = _adminPermisos;
        }

        #region ICommand Members

        public bool CanExecute(object parameter)
        {
            if ((parameter as T_Permiso) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {

            viewModel.ActualizarPermiso(parameter as T_Permiso);
        }

        #endregion
    }
}
