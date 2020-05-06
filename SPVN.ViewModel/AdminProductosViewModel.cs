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
using System.Windows.Media.Imaging;
using System.IO;
using SPVN.ViewModel.SPVNServices;
using System.Collections.ObjectModel;
using SPVN.ViewModel.Command.AdminProductos;
using SPVN.ViewModel.Helpers.AdminProductos;
using FluxJpeg.Core;
using FluxJpeg.Core.Encoder;

namespace SPVN.ViewModel
{
    public class AdminProductosViewModel : MyViewModelBase
    {
        #region Atributos

        private ObservableCollection<T_Categoria> listCategoria = new ObservableCollection<T_Categoria>();
        private ObservableCollection<T_Producto> listProductos = new ObservableCollection<T_Producto>();
        private T_Producto temporalProducto = null;
        private int selectedIndex = -1;

        #endregion

        #region Propiedades

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

        #endregion

        #region Commands

        public DeleteProductoCommand Eliminar
        {
            get { return new DeleteProductoCommand(this); }
        }
        public UpdateProductoCommand Actualizar
        {
            get
            {
                return new UpdateProductoCommand(this);
            }
        }
        public InsertProductoCommand Agregar
        {
            get
            {
                return new InsertProductoCommand(this);
            }
        }
        #endregion

        #region Referencia a Servicios
        private SPVNServicesClient _service;
        #endregion

        #region Constructor

        public AdminProductosViewModel()
        {
            this.SeleccionarTodosProductos();
        }

        #endregion

        #region Pantallas
        ChildRegistrarProducto regProducto;
        #endregion

        #region Métodos


        public void RegistrarProducto()
        {
            regProducto = new ChildRegistrarProducto();
            regProducto.Show();
            regProducto.cmbCategorias.ItemsSource = listCategoria;
            regProducto.btnSeleccionar.Click += new RoutedEventHandler(btnSeleccionar_Click);
            regProducto.OKButton.Click += new RoutedEventHandler(OKButton_Click);
        }

        public void ActualizarProducto(T_Producto _producto)
        {
        }

        public void EliminarProducto(T_Producto _producto)
        {
        }

        public void SeleccionarTodosProductos()
        {
            _service = new SPVNServicesClient();
            this.IsBusy = true;
            StateAction = "Recopilando Información";
            _service.SeleccionarTodosProductosAsync();
            _service.SeleccionarTodosProductosCompleted += new EventHandler<SeleccionarTodosProductosCompletedEventArgs>(permisoService_SeleccionarTodosProductosCompleted);
        }



        public void VerDetalleProducto(T_Producto _producto)
        {
        }

        private string ConvertToString(WriteableBitmap bitmap)
        {
            int width = bitmap.PixelWidth;
            int height = bitmap.PixelHeight;
            int bands = 3;
            byte[][,] raster = new byte[bands][,];

            for (int i = 0; i < bands; i++)
            {
                raster[i] = new byte[width, height];
            }

            for (int row = 0; row < height; row++)
            {
                for (int column = 0; column < width; column++)
                {
                    int pixel = bitmap.Pixels[width * row + column];
                    raster[0][column, row] = (byte)(pixel >> 16);
                    raster[1][column, row] = (byte)(pixel >> 8);
                    raster[2][column, row] = (byte)pixel;
                }
            }

            ColorModel model = new ColorModel { colorspace = ColorSpace.RGB };
            FluxJpeg.Core.Image img = new FluxJpeg.Core.Image(model, raster);
            MemoryStream stream = new MemoryStream();
            JpegEncoder encoder = new JpegEncoder(img, 100, stream);
            encoder.Encode();

            stream.Seek(0, SeekOrigin.Begin);
            byte[] binaryData = new Byte[stream.Length];
            long bytesRead = stream.Read(binaryData, 0, (int)stream.Length);

            string base64String =
                    System.Convert.ToBase64String(binaryData,
                                                  0,
                                                  binaryData.Length);

            return base64String;
        }



        #endregion

        #region Handlers

        void btnSeleccionar_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog _dialog = new OpenFileDialog();
            _dialog.Filter = "JPEG Files (*.jpg)|*.jpg";
            if (_dialog.ShowDialog() == true)
            {
                BitmapImage bmp = new BitmapImage();
                FileInfo info = _dialog.File;
                bmp.SetSource(info.OpenRead());
                //regProducto.imgProducto.Source = bmp;
            }
        }

        void permisoService_SeleccionarTodosProductosCompleted(object sender, SeleccionarTodosProductosCompletedEventArgs e)
        {
            listProductos.Clear();
            this.ListProductos = e.Result;
            _service = new SPVNServicesClient();
            _service.SeleccionarTodasCategoriasAsync();
            _service.SeleccionarTodasCategoriasCompleted += new EventHandler<SeleccionarTodasCategoriasCompletedEventArgs>(permisoService_SeleccionarTodasCategoriasCompleted);
        }

        void permisoService_SeleccionarTodasCategoriasCompleted(object sender, SeleccionarTodasCategoriasCompletedEventArgs e)
        {
            listCategoria.Clear();
            listCategoria = e.Result;
            IsBusy = false;
        }

        void OKButton_Click(object sender, RoutedEventArgs e)
        {
            //WriteableBitmap wb = new WriteableBitmap(regProducto.imgProducto, null);
            temporalProducto = new T_Producto()
            {
                Descripcion_Producto=regProducto.txtDescripcionProducto.Text,
                //Foto_Producto=this.ConvertToString(wb)
            };
        }

        #endregion
    }
}
