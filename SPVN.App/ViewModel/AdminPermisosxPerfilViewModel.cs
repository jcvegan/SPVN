using System;
using GalaSoft.MvvmLight;
using SPVN.App.PermisoServiceReference;
using System.Collections.ObjectModel;

namespace SPVN.App.ViewModel
{
    public class AdminPermisosxPerfilViewModel:ViewModelBase
    {

        #region Atributos

        private bool isBusy;
        private string stateAction;
        private ObservableCollection<T_Permiso> listPermiso=new ObservableCollection<T_Permiso>();
        private ObservableCollection<T_Perfil> listPerfil=new ObservableCollection<T_Perfil>();

        #endregion

        #region Propiedades

        public bool IsBusy
        {
            get { return isBusy; }
            set 
            {
                isBusy = value;
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

        public ObservableCollection<T_Perfil> ListPerfil
        {
            get { return listPerfil; }
            set { listPerfil = value;
            this.RaisePropertyChanged("ListPerfil");
            }
        }

        public ObservableCollection<T_Permiso> ListPermiso
        {
            get { return listPermiso;}
            set { 
                listPermiso = value;
                this.RaisePropertyChanged("ListPermiso");
            }
        }

        #endregion

        #region Referencia a Servicios

        private PermisoServiceClient permisoService;

        #endregion

        #region Métodos

        public void Init()
        {
            permisoService = new PermisoServiceClient();
            ListPermiso.Clear();
            IsBusy = true;
            StateAction = "Recopilando Información";
            permisoService.SeleccionarTodosPermisoAsync();
            permisoService.SeleccionarTodosPermisoCompleted += new EventHandler<SeleccionarTodosPermisoCompletedEventArgs>(permisoService_SeleccionarTodosPermisoCompleted);
        }

        #endregion

        #region Constructor

        public AdminPermisosxPerfilViewModel()
        {
            this.Init();
        }

        #endregion

        #region Handlers

        void permisoService_SeleccionarTodosPermisoCompleted(object sender, SeleccionarTodosPermisoCompletedEventArgs e)
        {
            ListPermiso = e.Result;
            IsBusy = false;
        }

        #endregion
    }
}
