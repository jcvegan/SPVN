using System;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Collections.Generic;

namespace SPVN.App.Web.Services
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class SPVNServices
    {
        #region Permisos
        [OperationContract]
        public List<T_Permiso> SeleccionarTodosPermiso()
        {
            SAPVENEntities _entities = new SAPVENEntities();
            return _entities.T_Permiso.ToList();
        }

        [OperationContract]
        public string RegistrarPermiso(T_Permiso _permiso)
        {
            try
            {
                SAPVENEntities _entities = new SAPVENEntities();
                _entities.AddToT_Permiso(_permiso);
                _entities.SaveChanges();
                return "Registro Exitoso";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [OperationContract]
        public string ActualizarPermiso(T_Permiso _permiso)
        {
            try
            {
                SAPVENEntities _entities = new SAPVENEntities();
                T_Permiso per = _entities.T_Permiso.Single(t => t.ID_Permiso == _permiso.ID_Permiso);
                per.Nombre_Permiso = _permiso.Nombre_Permiso;
                per.NombrePaquete_Permiso = _permiso.NombrePaquete_Permiso;
                per.Descripcion_Permiso = _permiso.Descripcion_Permiso;
                _entities.SaveChanges();
                return "Permiso Modificado";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        #endregion

        #region Perfil
        [OperationContract]
        public List<T_Perfil> SeleccionarTodosPerfil()
        {
            SAPVENEntities _entities = new SAPVENEntities();
            return _entities.T_Perfil.ToList();
        }
        [OperationContract]
        public string RegistrarPerfil(T_Perfil _perfil)
        {
            try
            {
                SAPVENEntities _entities = new SAPVENEntities();
                _entities.AddToT_Perfil(_perfil);
                _entities.SaveChanges();
                return "Registro Exitoso";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        [OperationContract]
        public string ActualizarPerfil(T_Perfil _perfil)
        {
            try
            {
                SAPVENEntities _entities = new SAPVENEntities();
                T_Perfil per = _entities.T_Perfil.Single(t => t.ID_Perfil == _perfil.ID_Perfil);
                per.Nombre_Perfil = _perfil.Nombre_Perfil;
                per.Descripcion_Perfil = _perfil.Descripcion_Perfil;
                _entities.SaveChanges();
                return "Permiso Modificado";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        [OperationContract]
        public string EliminarPerfil(T_Perfil _perfil)
        {
            SAPVENEntities _entities = new SAPVENEntities();
            T_Perfil p = _entities.T_Perfil.Single(c => c.ID_Perfil == _perfil.ID_Perfil);
            _entities.DeleteObject(p);
            _entities.SaveChanges();
            return "Perfil Eliminado";
        }
        #endregion

        #region PerfilxPermisos

        #endregion

        #region Productos

        [OperationContract]
        public List<T_Producto> SeleccionarTodosProductos()
        {
            SAPVENEntities _entities = new SAPVENEntities();
            return _entities.T_Producto.ToList();
        }
        [OperationContract]
        public string RegistrarProducto(T_Producto producto)
        {
            SAPVENEntities _entities = new SAPVENEntities();
            _entities.AddToT_Producto(producto);
            _entities.SaveChanges();
            return "Producto Registrado";
        }
        [OperationContract]
        public string ActualizarProducto(T_Producto producto)
        {
            try
            {
                SAPVENEntities _entities = new SAPVENEntities();
                T_Producto p = _entities.T_Producto.Single(c => c.ID_Producto == producto.ID_Categoria);
                p.Descripcion_Producto = producto.Descripcion_Producto;
                p.Foto_Producto = producto.Foto_Producto;
                p.ID_Categoria = producto.ID_Categoria;
                _entities.SaveChanges();
                return "Producto Modificado";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        [OperationContract]
        public string EliminarProducto(T_Producto producto)
        {
            try
            {
                SAPVENEntities _entities = new SAPVENEntities();
                T_Producto p = _entities.T_Producto.Single(c => c.ID_Producto == producto.ID_Producto);
                _entities.DeleteObject(p);
                _entities.SaveChanges();
                return "Producto Eliminado";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        #endregion

        #region Categorias
        [OperationContract]
        public List<T_Categoria> SeleccionarTodasCategorias()
        {
            SAPVENEntities _entities = new SAPVENEntities();
            return _entities.T_Categoria.ToList();
        }
        #endregion
    }
}
