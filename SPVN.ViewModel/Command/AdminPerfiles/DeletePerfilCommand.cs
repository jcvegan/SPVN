using System.Windows.Input;

namespace SPVN.ViewModel.Command.AdminPerfiles
{
    public class DeletePerfilCommand:ICommand
    {
        private AdminPerfilesViewModel viewModel;

        public DeletePerfilCommand(AdminPerfilesViewModel _admin)
        {
            viewModel = _admin;
        }

        public bool CanExecute(object parameter)
        {
            if (viewModel.SelectedIndex > -1 || viewModel.SelectedPerfil != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public event System.EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            viewModel.EliminarPerfil();
        }
    }
}
