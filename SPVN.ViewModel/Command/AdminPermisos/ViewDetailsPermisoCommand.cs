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
    public class ViewDetailsPermisoCommand:ICommand
    {
        AdminPermisosViewModel viewModel;

        public ViewDetailsPermisoCommand(AdminPermisosViewModel _admin)
        {
            viewModel = _admin;
        }

        #region ICommand Members

        public bool CanExecute(object parameter)
        {
            if (viewModel.SelectedIndex > -1)
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
            viewModel.VerDetallePermiso();
        }

        #endregion
    }
}
