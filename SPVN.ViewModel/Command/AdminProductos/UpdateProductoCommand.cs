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
using SPVN.ViewModel;
using SPVN.ViewModel.SPVNServices;


namespace SPVN.ViewModel.Command.AdminProductos
{
    public class UpdateProductoCommand:ICommand
    {
        AdminProductosViewModel viewModel;
        public UpdateProductoCommand(AdminProductosViewModel _admin)
        {
            viewModel = _admin;
        }

        public bool CanExecute(object parameter)
        {
            if (parameter is T_Producto)
            {
                if ((parameter as T_Producto) != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            viewModel.ActualizarProducto(parameter as T_Producto);
        }
    }
}
