using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppWinFormPrácticoEa1
{
    public partial class FrmTipoDocumento : Form
    {
        public FrmTipoDocumento()
        {
            InitializeComponent();
        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            var frm = new FrmTipoDocumentoEdit();
            frm.ShowDialog();
            cargarDatos();
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            cargarDatos();
        }
        private void cargarDatos()
        {
            //Creamos la instancia del adaptador
            var adaptador = new sdAppTableAdapters.TipoDocumentoTableAdapter();
            //Obtenemos el objeto DataTable
            var tabla = adaptador.GetData();
            //Asignamos el origen de datos al control (DataGridView)
            dgvDatos.DataSource = tabla;
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            int id = getId();
            if (id > 0)
            {
                var frm = new FrmTipoDocumentoEdit(id);
                frm.ShowDialog();
                cargarDatos();
            }
            else
            {
                MessageBox.Show("Seleccione un ID válido", "Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private int getId()

        {
            try
            {
                //¿Qué queeremos procesar?
                DataGridViewRow filaActual = dgvDatos.CurrentRow;
                if (filaActual == null)
                {
                    return 0;
                }
                return int.Parse(dgvDatos.Rows[filaActual.Index].Cells[0].Value.ToString());
            }
            catch (Exception)
            {
                //¿Qué hacer en caso de error?
                return 0;
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            int id = getId();
            if (id > 0)
            {
                DialogResult respuesta = MessageBox.Show("¿Realmente desea eliminar el registro?",
                    "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta == DialogResult.Yes)
                {
                    //Eliminar el registro
                    var adaptador = new sdAppTableAdapters.TipoDocumentoTableAdapter();
                    adaptador.Remove(id);
                    MessageBox.Show("Registro Eliminado", "Sistema",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    cargarDatos();
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un ID válido", "Sistemas",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
