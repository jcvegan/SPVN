using GalaSoft.MvvmLight;
using SPVN.App.PermisoServiceReference;
using System.Collections.ObjectModel;
using SPVN.App.Commands;
using System.Windows;
using SPVN.App.Views.Administracion;

namespace SPVN.App.ViewModel
{

    public class AdminPermisosViewModel : ViewModelBase
    {
        #region Atributos

        private ObservableCollection<T_Permiso> listPermiso = new ObservableCollection<T_Permiso>();
        private T_Permiso selectedPermiso=null;
        private int selectedIndex = -1;
        private bool isBusy=false;
        private string stateAction = string.Empty;
        private T_Permiso temporalPermiso=null;

        #endregion

        #region Referencia a Servicios
        private PermisoServiceClient permisoService;
        #endregion

        #region Propiedades
        public ObservableCollection<T_Permiso> ListPermiso
        {
            get { return listPermiso; }
            set{
                
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
            set {
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
        public bool IsBusy
        {
            get { return isBusy; }
            set {
                isBusy = value;
                RaisePropertyChanged("IsBusy");
            }
        }
        public string StateAction
        {
            get { return stateAction; }
            set {
                stateAction = value;
                RaisePropertyChanged("StateAction");
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
            permisoService = new PermisoServiceClient();
            this.IsBusy = true;
            this.StateAction = "Recopilando Información";
            permisoService.SeleccionarTodosPermisoAsync();
            permisoService.SeleccionarTodosPermisoCompleted += new System.EventHandler<SeleccionarTodosPermisoCompletedEventArgs>(permisoService_SeleccionarTodosPermisoCompleted);
        }

        public void NuevoPermiso()
        {
            _regPermiso = new ChildRegistrarPermiso();
            _regPermiso.Show();
            _regPermiso.OKButton.Click += new RoutedEventHandler(OKRegisterButton_Click);
        }

        public void ActualizarPermiso()
        {
            _actPermiso = new ChildActualizarPermiso();
            _actPermiso.Show();
            _actPermiso.OKButton.Click+=new RoutedEventHandler(OKActualButton_Click);
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
            permisoService = new PermisoServiceClient();
            temporalPermiso = new T_Permiso()
            {
                Nombre_Permiso = _regPermiso.txtNombrePermiso.Text,
                Descripcion_Permiso = _regPermiso.txtDescripcionPermiso.Text,
                NombrePaquete_Permiso = _regPermiso.txtNombrePermiso.Text
            };
            permisoService.RegistrarPermisoAsync(temporalPermiso);
            permisoService.RegistrarPermisoCompleted += new System.EventHandler<RegistrarPermisoCompletedEventArgs>(permisoService_RegistrarPermisoCompleted);
        }

        void OKActualButton_Click(object sender, RoutedEventArgs e)
        {
            this.IsBusy = true;
            this.StateAction = "Actualizando el Permiso";
            permisoService = new PermisoServiceClient();
            temporalPermiso = new T_Permiso()
            {
                ID_Permiso=int.Parse(_actPermiso.txtIDPermiso.Text),
                Nombre_Permiso = _actPermiso.txtNombrePermiso.Text,
                Descripcion_Permiso = _actPermiso.txtDescripcionPermiso.Text,
                NombrePaquete_Permiso = _actPermiso.txtNombrePermiso.Text
            };
            
            permisoService.RegistrarPermisoCompleted += new System.EventHandler<RegistrarPermisoCompletedEventArgs>(permisoService_RegistrarPermisoCompleted);

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