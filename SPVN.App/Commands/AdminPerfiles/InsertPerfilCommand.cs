using System;
using System.Windows.Input;
using SPVN.App.ViewModel;

namespace SPVN.App.Commands.AdminPerfiles
{
    public class InsertPerfilCommand:ICommand
    {
        private AdminPerfilesViewModel viewModel;

        public InsertPerfilCommand(AdminPerfilesViewModel _admin)
        {
            viewModel = _admin;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            viewModel.NuevoPerfil();
        }
    }
}
