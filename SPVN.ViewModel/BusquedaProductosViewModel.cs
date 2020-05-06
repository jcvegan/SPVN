using System;
using System.Net;
using System.Windows;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using SPVN.ViewModel.SPVNServices;
using System.Collections.Generic;

namespace SPVN.ViewModel
{
    public class BusquedaProductosViewModel:MyViewModelBase
    {
        #region Atributos

        private ObservableCollection<T_Producto> listProducto = new ObservableCollection<T_Producto>();
        private ObservableCollection<T_Caracteristica> listCaracteristica = new ObservableCollection<T_Caracteristica>();

        #endregion

        #region Propiedades

        public ObservableCollection<T_Producto> ListProducto
        {
            get
            {
                return listProducto;
            }
            set
            {
                listProducto = value;
                this.RaisePropertyChanged("ListProducto");
            }
        }

        public ObservableCollection<T_Caracteristica> ListCaracteristica
        {
            get
            {
                return listCaracteristica;
            }
            set
            {
                listCaracteristica = value;
                this.RaisePropertyChanged("ListCaracteristica");
            }
        }

        #endregion

        #region Referencia a Servicio

        private SPVNServicesClient service;

        #endregion

        #region Constructor

        public BusquedaProductosViewModel()
        {
        }

        #endregion

        #region Métodos

        private void ConsultarTodosProductos()
        {
            service = new SPVNServicesClient();
            
            service.SeleccionarTodosProductosAsync();
            IsBusy = true;
            StateAction = "Recopilando información";
            service.SeleccionarTodosProductosCompleted += new EventHandler<SeleccionarTodosProductosCompletedEventArgs>(service_SeleccionarTodosProductosCompleted);
        }

        private void AgregarFiltro(T_Caracteristica car)
        {
            //ListProducto=from p in ListProducto where p.=car.ID_Caracteristica
        }
        

        #endregion

        #region Handlers

        void service_SeleccionarTodosProductosCompleted(object sender, SeleccionarTodosProductosCompletedEventArgs e)
        {
            ListProducto = e.Result;
            IsBusy = false;
        }

        #endregion

    }
}
