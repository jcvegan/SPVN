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
using SPVN.ViewModel.Command.RegisterUsuario;

namespace SPVN.ViewModel
{
    public class RegistrationViewModel:MyViewModelBase
    {
        #region Atributos

        private T_Usuario _usuario = new T_Usuario();

        #endregion

        #region Propiedades

        public T_Usuario Usuario
        {
            get { return _usuario; }
            set
            {
                _usuario = value;
                this.RaisePropertyChanged("Usuario");
            }
        }

        #endregion

        #region Constructor

        public RegistrationViewModel()
        {
        }

        #endregion

        #region Commands

        public RegisterUsuario RegisterCommand
        {
            get { return new RegisterUsuario(this); }
        }

        #endregion

        #region Métodos

        public void RegistrarUsuario(T_Usuario _usuario)
        {
            IsBusy = true;
        }

        #endregion
    }
}
