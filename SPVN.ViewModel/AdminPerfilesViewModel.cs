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
using SPVN.ViewModel.Command.AdminPerfiles;
using SPVN.ViewModel.Helpers.AdminPerfiles;

namespace SPVN.ViewModel
{
    public class AdminPerfilesViewModel:MyViewModelBase
    {

        #region Atributos

        private ObservableCollection<T_Perfil> listPermiso = new ObservableCollection<T_Perfil>();
        private T_Perfil selectedPermiso = null;
        private int selectedIndex = -1;
        private T_Perfil temporalPerfil = null;
        
        #endregion

        #region Referencia a Servicios

        private SPVNServicesClient _service;

        #endregion

        #region Propiedades
        public ObservableCollection<T_Perfil> ListPerfil
        {
            get { return listPermiso; }
            set
            {

                if (value != null)
                {
                    listPermiso = value;
                    RaisePropertyChanged("ListPerfil");
                }
            }
        }
        public T_Perfil SelectedPerfil
        {
            get { return selectedPermiso; }
            set
            {
                selectedPermiso = value;
                RaisePropertyChanged("SelectedPermiso");
            }
        }
        public int SelectedIndex
        {
            get { return selectedIndex; }
            set
            {
                selectedIndex = value;
                RaisePropertyChanged("SelectedIndex");
                SelectedPerfil = ListPerfil[value];
            }
        }
        #endregion

        #region Comandos

        public InsertPerfilCommand Insertar
        {
            get
            {
                return new InsertPerfilCommand(this);
            }
        }
        public UpdatePerfilCommand Actualizar
        {
            get
            {
                return new UpdatePerfilCommand(this);
            }
        }
        public DeletePerfilCommand Eliminar
        {
            get
            {
                return new DeletePerfilCommand(this);
            }
        }
        public SelectAllPerfilCommand Refrescar
        {
            get
            {
                return new SelectAllPerfilCommand(this);
            }
        }
        public ViewDetailsPerfilCommand VerDetalle
        {
            get
            {
                return new ViewDetailsPerfilCommand(this);
            }
        }

        #endregion

        #region Constructor

        public AdminPerfilesViewModel()
        {
            Init();
        }

        #endregion

        #region Métodos

        public void Init()
        {
            ListPerfil.Clear();
            _service = new SPVNServicesClient();
            this.IsBusy = true;
            this.StateAction = "Recopilando Información";
            _service.SeleccionarTodosPerfilAsync();
            _service.SeleccionarTodosPerfilCompleted += new System.EventHandler<SeleccionarTodosPerfilCompletedEventArgs>(permisoService_SeleccionarTodosPerfilCompleted);
        }

        public void NuevoPerfil()
        {
            _regPerfil = new ChildRegistrarPerfil();
            _regPerfil.InitializeComponent();
            _regPerfil.OKButton.Click += new RoutedEventHandler(OKRegisterButton_Click);
        }

        public void ActualizarPerfil()
        {
            //_actPermiso = new ChildActualizarPermiso();
            //_actPermiso.Show();
            //_actPermiso.OKButton.Click+=new RoutedEventHandler(OKActualButton_Click);
        }

        public void EliminarPerfil()
        {
        }

        public void VerDetallePerfil()
        {
        }

        #endregion

        #region Handlers

        void OKRegisterButton_Click(object sender, RoutedEventArgs e)
        {
            this.IsBusy = true;
            this.StateAction = "Registrando Permiso";
            _service = new SPVNServicesClient();
            temporalPerfil = new T_Perfil()
            {
                Nombre_Perfil = _regPerfil.txtNombrePerfil.Text,
                Descripcion_Perfil = _regPerfil.txtDescripcionPerfil.Text
            };

            //_service.RegistrarPerfilAsync(temporalPerfil);
            //_service.RegistrarPerfilAsync(temporalPerfil);
            _service.RegistrarPerfilCompleted += new EventHandler<RegistrarPerfilCompletedEventArgs>(permisoService_RegistrarPerfilCompleted);
        }

        void OKActualButton_Click(object sender, RoutedEventArgs e)
        {
            this.IsBusy = true;
            this.StateAction = "Actualizando el Permiso";
            _service = new SPVNServicesClient();
            //_service.ActualizarPerfilAsync(temporalPerfil);
        }

        void permisoService_RegistrarPerfilCompleted(object sender, RegistrarPerfilCompletedEventArgs e)
        {
            this.IsBusy = false;
            this.StateAction = e.Result;
            this.Init();
        }

        void permisoService_SeleccionarTodosPerfilCompleted(object sender, SeleccionarTodosPerfilCompletedEventArgs e)
        {
            this.IsBusy = false;
            this.ListPerfil = e.Result;
            this.StateAction = string.Empty;
        }

        #endregion

        #region Pantallas
        ChildRegistrarPerfil _regPerfil;
        #endregion
    }
}
