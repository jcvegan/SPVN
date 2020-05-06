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
using SPVN.App.ViewModel;

namespace SPVN.App.Commands.AdminPerfiles
{
    public class SelectAllPerfilCommand:ICommand
    {
        private AdminPerfilesViewModel viewModel;

        public SelectAllPerfilCommand(AdminPerfilesViewModel _admin)
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
            viewModel.Init();
        }
    }
}
