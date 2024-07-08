using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using negocio;

namespace presentacion
{
    public partial class frmAltaArticulo : Form
    {
        private Articulo articulo = null;
        public frmAltaArticulo()
        {
            InitializeComponent();
        }
        public frmAltaArticulo(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
            Text = "Modificar Articulo";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private bool validarFiltroAlta()
        {
            if(txtCodigo.Text == "")
            {
                MessageBox.Show("Por favor ingrese un Código.");
                return true;
            }
            if(txtNombre.Text == "")
            {
                MessageBox.Show("Por favor ingrese un Nombre.");
                return true;
            }
            if (txtPrecio.Text == "")
            {
                MessageBox.Show("Por favor ingrese un Precio.");
                return true;
            }
            if (!(soloNumeros(txtPrecio.Text)))
            {
                MessageBox.Show("Solo números en el Precio");
                return true;
            }
            return false;
        }
        private bool soloNumeros(string cadena)
        {
            foreach (char caracter in cadena)
            {
                if (!(char.IsNumber(caracter)))
                {
                    return false;
                }
            }
            return true;
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();

            try
            {
                if(articulo == null)
                    articulo = new Articulo();

                articulo.Codigo = txtCodigo.Text;
                articulo.Nombre = txtNombre.Text;
                articulo.Descripcion = txtDescripcion.Text;
                articulo.UrlImagen = txtUrlImagen.Text;
                articulo.Marca = (Marca)cboMarca.SelectedItem;
                articulo.Categoria = (Categoria)cboCategoria.SelectedItem;
                decimal valor;
                if (decimal.TryParse(txtPrecio.Text, out valor))
                    articulo.Precio = valor;

                if (validarFiltroAlta())
                    return;

                if (articulo.Id != 0)
                {
                    negocio.modificar(articulo);
                    MessageBox.Show("Modificado exitosamente.");
                }
                else
                {
                    //taca
                    negocio.agregar(articulo);
                    MessageBox.Show("Agregado exitosamente.");
                }
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void frmAltaArticulo_Load(object sender, EventArgs e)
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            try
            {
                cboMarca.DataSource = marcaNegocio.listar();
                cboMarca.ValueMember = "Id";
                cboMarca.DisplayMember = "Descripcion";
                cboCategoria.DataSource = categoriaNegocio.listar();
                cboCategoria.ValueMember = "Id";
                cboCategoria.DisplayMember = "Descripcion";

                if(articulo != null)
                {
                    txtCodigo.Text = articulo.Codigo;
                    txtNombre.Text = articulo.Nombre;
                    txtDescripcion.Text = articulo.Descripcion;
                    txtUrlImagen.Text = articulo.UrlImagen;
                    cargarImagen(txtUrlImagen.Text);
                    cboMarca.SelectedValue = articulo.Marca.Id;
                    cboCategoria.SelectedValue = articulo.Categoria.Id;
                    txtPrecio.Text = articulo.Precio.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtUrlImagen_Leave(object sender, EventArgs e)
        {
            cargarImagen(txtUrlImagen.Text);
        }
        private void cargarImagen(string imagen)
        {
            try
            {
                pbxUrlImagen.Load(imagen);
            }
            catch (Exception)
            {
                pbxUrlImagen.Load("https://developers.elementor.com/docs/assets/img/elementor-placeholder-image.png");
            }
        }
    }
}
