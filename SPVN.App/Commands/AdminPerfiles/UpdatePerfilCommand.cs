using System;
using System.Windows.Input;
using SPVN.App.ViewModel;

namespace SPVN.App.Commands.AdminPerfiles
{
    public class UpdatePerfilCommand : ICommand
    {
        public AdminPerfilesViewModel viewModel;

        public UpdatePerfilCommand(AdminPerfilesViewModel _admin)
        {
            viewModel = _admin;
        }
        public bool CanExecute(object parameter)
        {
            if (viewModel.SelectedIndex > -1 || viewModel.SelectedPermiso != null)
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
            viewModel.ActualizarPerfil();
        }
    }
}