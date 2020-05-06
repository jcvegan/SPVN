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
using System.Collections.ObjectModel;
using SPVN.ViewModel.Command.AdminProductos;
using SPVN.ViewModel.Helpers.AdminPermisos;

namespace SPVN.ViewModel
{
    public class AdminPermisosViewModel:MyViewModelBase
    {
        #region Atributos

        private ObservableCollection<T_Permiso> listPermiso = new ObservableCollection<T_Permiso>();
        private T_Permiso selectedPermiso = null;
        private int selectedIndex = -1;
        private T_Permiso temporalPermiso = null;


        #endregion

        #region Referencia a Servicios
        private SPVNServicesClient _service;
        #endregion

        #region Propiedades
        public ObservableCollection<T_Permiso> ListPermiso
        {
            get { return listPermiso; }
            set
            {

                if (value != null)
                {
                    listPermiso = value;
                    RaisePropertyChanged("ListPermiso");
                }
            }
        }
        public T_Permiso SelectedPermiso
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
                SelectedPermiso = ListPermiso[value];
            }
        }

        #endregion

        #region Comandos

        public InsertPermisoCommand Insertar
        {
            get
            {
                return new InsertPermisoCommand(this);
            }
        }
        public UpdatePermisoCommand Actualizar
        {
            get
            {
                return new UpdatePermisoCommand(this);
            }
        }
        public DeletePermisoCommand Eliminar
        {
            get
            {
                return new DeletePermisoCommand(this);
            }
        }
        public SelectAllPermisoCommand Refrescar
        {
            get
            {
                return new SelectAllPermisoCommand(this);
            }
        }
        public ViewDetailsPermisoCommand VerDetalle
        {
            get
            {
                return new ViewDetailsPermisoCommand(this);
            }
        }

        #endregion

        #region Constructor

        public AdminPermisosViewModel()
        {
            Init();

        }



        #endregion

        #region Métodos

        public void Init()
        {
            ListPermiso.Clear();
            _service = new SPVNServicesClient();
            this.IsBusy = true;
            this.StateAction = "Recopilando Información";
            _service.SeleccionarTodosPermisoAsync();
            _service.SeleccionarTodosPermisoCompleted += new System.EventHandler<SeleccionarTodosPermisoCompletedEventArgs>(permisoService_SeleccionarTodosPermisoCompleted);
        }

        public void NuevoPermiso()
        {
            _regPermiso = new ChildRegistrarPermiso();
            _regPermiso.Show();
            _regPermiso.OKButton.Click += new RoutedEventHandler(OKRegisterButton_Click);
        }

        public void ActualizarPermiso(T_Permiso _permiso)
        {
            _actPermiso = new ChildActualizarPermiso();
            _actPermiso.DataContext = _permiso;
            _actPermiso.Show();
            _actPermiso.OKButton.Click += new RoutedEventHandler(OKActualButton_Click);
        }

        public void EliminarPermiso()
        {
        }

        public void VerDetallePermiso()
        {
        }

        #endregion

        #region Handlers

        void OKRegisterButton_Click(object sender, RoutedEventArgs e)
        {
            this.IsBusy = true;
            this.StateAction = "Registrando Permiso";
            _service = new SPVNServicesClient();
            //temporalPermiso = new T_Permiso()
            //{
            //    Nombre_Permiso = _regPermiso.txtNombrePermiso.Text,
            //    Descripcion_Permiso = _regPermiso.txtDescripcionPermiso.Text,
            //    NombrePaquete_Permiso = _regPermiso.txtNombrePermiso.Text
            //};
            _service.RegistrarPermisoAsync(temporalPermiso);
            _service.RegistrarPermisoCompleted += new System.EventHandler<RegistrarPermisoCompletedEventArgs>(permisoService_RegistrarPermisoCompleted);
        }

        void OKActualButton_Click(object sender, RoutedEventArgs e)
        {
            this.IsBusy = true;
            this.StateAction = "Actualizando el Permiso";
            _service = new SPVNServicesClient();
            temporalPermiso = new T_Permiso()
            {
                ID_Permiso = int.Parse(_actPermiso.txtIDPermiso.Text),
                Nombre_Permiso = _actPermiso.txtNombrePermiso.Text,
                Descripcion_Permiso = _actPermiso.txtDescripcionPermiso.Text,
                NombrePaquete_Permiso = _actPermiso.txtNombrePermiso.Text
            };

            _service.RegistrarPermisoCompleted += new System.EventHandler<RegistrarPermisoCompletedEventArgs>(permisoService_RegistrarPermisoCompleted);

        }

        void permisoService_RegistrarPermisoCompleted(object sender, RegistrarPermisoCompletedEventArgs e)
        {
            this.StateAction = e.Result;
            IsBusy = false;
            this.Init();
        }

        void permisoService_SeleccionarTodosPermisoCompleted(object sender, SeleccionarTodosPermisoCompletedEventArgs e)
        {
            this.IsBusy = false;
            this.ListPermiso = e.Result;
            this.StateAction = string.Empty;
        }

        #endregion

        #region Pantallas

        ChildRegistrarPermiso _regPermiso;
        ChildActualizarPermiso _actPermiso;
        #endregion
    }
}
