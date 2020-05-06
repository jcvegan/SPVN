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

namespace SPVN.ViewModel.Command.AdminProductos
{
    public class InsertPermisoCommand : ICommand
    {
        AdminPermisosViewModel viewModel;

        public InsertPermisoCommand(AdminPermisosViewModel _adminPermisos)
        {
            viewModel = _adminPermisos;
        }

        #region ICommand Members

        public bool CanExecute(object parameter)
        {
            if (parameter is AdminPermisosViewModel)
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
            viewModel.NuevoPermiso();
        }

        #endregion
    }
}
