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

namespace SPVN.ViewModel.Command.RegisterUsuario
{
    public class RegisterUsuario:ICommand
    {
        private RegistrationViewModel viewModel;

        public RegisterUsuario(RegistrationViewModel vm)
        {
            viewModel = vm;
        }

        public bool CanExecute(object parameter)
        {
            if ((parameter as T_Usuario) != null)
            {
                if ((parameter as T_Usuario).Correo_Usuario != null)
                {
                    if ((parameter as T_Usuario).Contraseña_Usuario != null && (parameter as T_Usuario).Contraseña_Usuario.Length > 16)
                    {
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            return false;

        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            viewModel.RegistrarUsuario(parameter as T_Usuario);
        }
    }
}
