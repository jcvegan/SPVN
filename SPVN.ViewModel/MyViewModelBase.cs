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
using GalaSoft.MvvmLight;

namespace SPVN.ViewModel
{
    public class MyViewModelBase:ViewModelBase
    {
        private bool _isBusy = false;
        private string stateAction = string.Empty;

        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }
            set
            {
                _isBusy = value;
                this.RaisePropertyChanged("IsBusy");
            }
        }

        public string StateAction
        {
            get
            {
                return stateAction;
            }
            set
            {
                stateAction = value;
                this.RaisePropertyChanged("StateAction");
            }
        }
    }
}
