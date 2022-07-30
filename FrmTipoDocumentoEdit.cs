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
    public partial class FrmTipoDocumentoEdit : Form
    {
        private int? Id;
        public FrmTipoDocumentoEdit(int? id = null)
        {
            InitializeComponent();
            this.Id = id;
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            int estado = chkestado.Checked ? 1 : 0;
            string nombre = txtnombre.Text;
            var adaptador = new sdAppTableAdapters.TipoDocumentoTableAdapter();
            if (this.Id == null)
            {
                adaptador.Add(nombre, (byte)estado);
            }
            else
            {
                adaptador.Edit(nombre, (byte)estado, (int)this.Id);
            }
            this.Close();
        }

        private void FrmTipoDocumentoEdit_Load(object sender, EventArgs e)
        {
            if (this.Id != null)
            {
                this.Text = "Editar";
                var adaptador = new sdAppTableAdapters.TipoDocumentoTableAdapter();
                var tabla = adaptador.GetDataById((int)this.Id);
                var fila = (sdApp.TipoDocumentoRow)tabla.Rows[0];
                txtnombre.Text = fila.Nombre;
                chkestado.Checked = fila.Estado == 1 ? true : false;

            }
            else
            {
                this.Text = "Nuevo";

            }
        }
    }
}
