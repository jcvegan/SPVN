﻿using System;
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

namespace SPVN.App.Commands
{
    public class DeletePermisoCommand:ICommand
    {
        AdminPermisosViewModel viewModel;

        public DeletePermisoCommand(AdminPermisosViewModel _adminPermisos)
        {
            viewModel = _adminPermisos;
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
            viewModel.EliminarPermiso();
        }

        #endregion
    }
}
