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
using SPVN.App.PermisoServiceReference;
using System.Collections.ObjectModel;

namespace SPVN.App.ViewModel
{
    public class AdminProductosViewModel:ViewModelBase
    {
        #region Atributos

        private bool isBusy=false;
        private bool hasCameraActive=false;
        private VideoBrush videoSource=new VideoBrush();
        CaptureSource capSource = new CaptureSource();
        private T_Producto selectedProduct=null;
        private ObservableCollection<T_Producto> listProductos = new ObservableCollection<T_Producto>();
        private int selectedIndex=-1;
        private string stateAction = string.Empty;

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
        public bool HasCameraActive
        {
            get
            {
                return hasCameraActive;
            }
            set
            {
                hasCameraActive = value;
                this.RaisePropertyChanged("HasCameraActive");
                if (value == true)
                {
                    this.ActivarWebCam();
                }
                else
                {
                    this.DesactivarWebCam();
                }
            }
        }
        public ObservableCollection<T_Producto> ListProductos
        {
            get 
            {
                return listProductos;
            }
            set
            {
                listProductos = value;
                this.RaisePropertyChanged("ListProductos");
            }
        }
        public int SelectedIndex
        {
            get
            {
                return selectedIndex;
            }
            set
            {
                selectedIndex = value;
                this.RaisePropertyChanged("SelectedIndex");
            }
        }
        public T_Producto SelectedProducto
        {
            get
            {
                return selectedProduct;
            }
            set
            {
                selectedProduct = value;
                this.RaisePropertyChanged("SelectedProducto");
            }
        }

        #endregion

        #region Constructor

        public AdminProductosViewModel()
        {
        }

        #endregion

        public void ActivarWebCam()
        {
            VideoCaptureDevice videoCap = CaptureDeviceConfiguration.GetDefaultVideoCaptureDevice();
            
            capSource.VideoCaptureDevice = videoCap;
            if (CaptureDeviceConfiguration.AllowedDeviceAccess || CaptureDeviceConfiguration.RequestDeviceAccess())
            {
                capSource.Start();
                videoSource.SetSource(capSource);
            }
        }
        public void DesactivarWebCam()
        {
            capSource.Stop();
        }
    }
}
