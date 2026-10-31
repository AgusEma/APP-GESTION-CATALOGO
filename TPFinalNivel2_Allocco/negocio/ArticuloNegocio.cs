using dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class ArticuloNegocio
    {
        private const string consultaBase = "Select Codigo, Nombre, A.Descripcion, C.Descripcion as Categoria, M.Descripcion as Marca, ImagenUrl, Precio, A.IdCategoria, A.IdMarca, A.Id From ARTICULOS A, CATEGORIAS C, MARCAS M Where C.Id = A.IdCategoria And M.Id = A.IdMarca";

        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta(consultaBase);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                    lista.Add(leerArticulo(datos.Lector));

                return lista;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void agregar(Articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Insert into ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio) values (@codigo, @nombre, @descripcion, @idMarca, @idCategoria, @urlImagen, @precio)");
                datos.setearParametros("@codigo", nuevo.Codigo);
                datos.setearParametros("@nombre", nuevo.Nombre);
                datos.setearParametros("@descripcion", nuevo.Descripcion);
                datos.setearParametros("@idMarca", nuevo.Marca.Id);
                datos.setearParametros("@idCategoria", nuevo.Categoria.Id);
                datos.setearParametros("@urlImagen", nuevo.UrlImagen);
                datos.setearParametros("@precio", nuevo.Precio);
                datos.ejecutarAccion();
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void modificar(Articulo arti)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update ARTICULOS set Codigo=@codigo, Nombre=@nombre, Descripcion=@desc, ImagenUrl=@img, IdMarca=@idMarca, IdCategoria=@idCategoria, Precio=@precio where Id=@id");
                datos.setearParametros("@codigo", arti.Codigo);
                datos.setearParametros("@nombre", arti.Nombre);
                datos.setearParametros("@desc", arti.Descripcion);
                datos.setearParametros("@img", arti.UrlImagen);
                datos.setearParametros("@idMarca", arti.Marca.Id);
                datos.setearParametros("@idCategoria", arti.Categoria.Id);
                datos.setearParametros("@precio", arti.Precio);
                datos.setearParametros("@id", arti.Id);
                datos.ejecutarAccion();
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void eliminarFisico(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("delete from ARTICULOS where Id = @id");
                datos.setearParametros("@id", id);
                datos.ejecutarAccion();
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public List<Articulo> filtrar(string campo, string criterio, string filtro)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = consultaBase + " And ";

                if (campo == "Precio")
                {
                    switch (criterio)
                    {
                        case "Mayor a":
                            consulta += "Precio > @filtro";
                            break;
                        case "Menor a":
                            consulta += "Precio < @filtro";
                            break;
                        default:
                            consulta += "Precio = @filtro";
                            break;
                    }
                    datos.setearParametros("@filtro", decimal.Parse(filtro));
                }
                else
                {
                    // El nombre de la columna sale de una lista fija, nunca del texto que escribe el usuario
                    string columna;
                    switch (campo)
                    {
                        case "Código":
                            columna = "Codigo";
                            break;
                        case "Nombre":
                            columna = "Nombre";
                            break;
                        case "Marca":
                            columna = "M.Descripcion";
                            break;
                        default:
                            columna = "C.Descripcion";
                            break;
                    }
                    consulta += columna + " like @filtro";

                    // El valor del filtro va como parámetro, así no se puede inyectar SQL
                    string valor;
                    switch (criterio)
                    {
                        case "Comienza con":
                            valor = filtro + "%";
                            break;
                        case "Termina con":
                            valor = "%" + filtro;
                            break;
                        default:
                            valor = "%" + filtro + "%";
                            break;
                    }
                    datos.setearParametros("@filtro", valor);
                }

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                    lista.Add(leerArticulo(datos.Lector));

                return lista;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        // Arma un Articulo a partir de la fila actual del lector (lo usan listar y filtrar)
        private Articulo leerArticulo(SqlDataReader lector)
        {
            Articulo aux = new Articulo();
            aux.Id = (int)lector["Id"];
            if (!(lector["Codigo"] is DBNull))
                aux.Codigo = (string)lector["Codigo"];
            if (!(lector["Nombre"] is DBNull))
                aux.Nombre = (string)lector["Nombre"];
            if (!(lector["Descripcion"] is DBNull))
                aux.Descripcion = (string)lector["Descripcion"];
            if (!(lector["ImagenUrl"] is DBNull))
                aux.UrlImagen = (string)lector["ImagenUrl"];

            aux.Categoria = new Categoria();
            if (!(lector["IdCategoria"] is DBNull))
                aux.Categoria.Id = (int)lector["IdCategoria"];
            if (!(lector["Categoria"] is DBNull))
                aux.Categoria.Descripcion = (string)lector["Categoria"];

            aux.Marca = new Marca();
            if (!(lector["IdMarca"] is DBNull))
                aux.Marca.Id = (int)lector["IdMarca"];
            if (!(lector["Marca"] is DBNull))
                aux.Marca.Descripcion = (string)lector["Marca"];

            if (!(lector["Precio"] is DBNull))
                aux.Precio = (decimal)lector["Precio"];

            return aux;
        }
    }
}
