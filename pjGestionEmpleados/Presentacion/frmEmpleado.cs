using pjGestionEmpleados.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pjGestionEmpleados.Presentacion
{
    public partial class frmEmpleado : Form
    {
        public frmEmpleado()
        {
            InitializeComponent();
        }

        #region "Metodos"

        private void CargarEmpleados (string cBusqueda)
        {
            D_Empleados Datos = new D_Empleados();
            dgvLista.DataSource = Datos.Listar_Empleados(cBusqueda);
        }
        #endregion

        private void ListaEmpleados()
        {
            dgvLista.Columns[0].Width = 45;
            dgvLista.Columns[1].Width = 160;
            dgvLista.Columns[2].Width = 150;
            dgvLista.Columns[5].Width = 250;
            dgvLista.Columns[7].Width = 160;

        }
        private void CargarDepartamentos() { 
        
             D_Departamentos Datos = new D_Departamentos();
            cmbDepartamento.DataSource = Datos.ListarDepartamentos();
            cmbDepartamento.ValueMember = "id_departamentos";
            cmbDepartamento.DisplayMember = "nombre_departamento";
            cmbDepartamento.SelectedIndex = -1;
        }
        private void CargarCargos()
        {

            D_Cargos Datos = new D_Cargos();
            cmbCargo.DataSource = Datos.ListarCargos();
            cmbCargo.ValueMember = "id_cargo";
            cmbCargo.DisplayMember = "nombre_cargo";
            cmbCargo.SelectedIndex = -1;
        }

        private void frmEmpleado_Load(object sender, EventArgs e)
        {
            CargarEmpleados("%");
            CargarDepartamentos();
            CargarCargos();
        }


        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarEmpleados(txtBuscar.Text);
        }
    }
}
