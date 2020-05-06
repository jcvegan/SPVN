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
using System.Collections.ObjectModel;
using SPVN.ViewModel.SPVNServices;

namespace SPVN.ViewModel
{
    public class AdminPermisosxPerfilViewModel : MyViewModelBase
    {

        #region Atributos

        private ObservableCollection<T_Permiso> listPermiso = new ObservableCollection<T_Permiso>();
        private ObservableCollection<T_Perfil> listPerfil = new ObservableCollection<T_Perfil>();
        private ObservableCollection<T_Permiso> listPermisosxPerfil = new ObservableCollection<T_Permiso>();

        #endregion

        #region Propiedades


        public ObservableCollection<T_Perfil> ListPerfil
        {
            get { return listPerfil; }
            set
            {
                listPerfil = value;
                this.RaisePropertyChanged("ListPerfil");
            }
        }

        public ObservableCollection<T_Permiso> ListPermiso
        {
            get { return listPermiso; }
            set
            {
                listPermiso = value;
                this.RaisePropertyChanged("ListPermiso");
            }
        }

        public ObservableCollection<T_Permiso> ListPermisosxPerfil
        {
            get { return listPermisosxPerfil; }
            set
            {
                listPermisosxPerfil = value;
                this.RaisePropertyChanged("listPermisosxPerfil");
            }
        }

        #endregion

        #region Referencia a Servicios

        private SPVNServicesClient _service;

        #endregion

        #region Métodos

        public void Init()
        {
            _service = new SPVNServicesClient();
            ListPermiso.Clear();
            IsBusy = true;
            StateAction = "Recopilando Información";
            _service.SeleccionarTodosPerfilAsync();
            _service.SeleccionarTodosPerfilCompleted += new EventHandler<SeleccionarTodosPerfilCompletedEventArgs>(permisoService_SeleccionarTodosPerfilCompleted);

        }



        #endregion

        #region Constructor

        public AdminPermisosxPerfilViewModel()
        {
            this.Init();
        }

        #endregion

        #region Handlers

        void permisoService_SeleccionarTodosPerfilCompleted(object sender, SeleccionarTodosPerfilCompletedEventArgs e)
        {
            _service.SeleccionarTodosPermisoAsync();
            _service.SeleccionarTodosPermisoCompleted += new EventHandler<SeleccionarTodosPermisoCompletedEventArgs>(permisoService_SeleccionarTodosPermisoCompleted);
            ListPerfil = e.Result;
        }

        void permisoService_SeleccionarTodosPermisoCompleted(object sender, SeleccionarTodosPermisoCompletedEventArgs e)
        {
            ListPermiso = e.Result;
            IsBusy = false;
        }

        #endregion
    }
}
