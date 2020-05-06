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
    public class InsertProductoCommand:ICommand
    {
        private AdminProductosViewModel viewModel;

        public InsertProductoCommand(ViewModel.AdminProductosViewModel _admin)
        {
            // TODO: Complete member initialization
            this.viewModel = _admin;
        }


        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            viewModel.RegistrarProducto();
        }
    }
}
