using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemadeControlPoliciaco
{
    public partial class AspiranteCursos : Form
    {
        public AspiranteCursos()
        {
            InitializeComponent();
            dgvAspi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAspi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAspi.RowHeadersVisible = false;
        }

        private static AspiranteCursos frmInst = null;

        public static AspiranteCursos Instancia()
        {
            if (((frmInst == null) || (frmInst.IsDisposed == true)))
            {
                frmInst = new AspiranteCursos();
            }
            frmInst.BringToFront();
            return frmInst;
        }

        private void AspiranteCursos_Load(object sender, EventArgs e)
        {
            ManejoBD bd = new ManejoBD();
            bd.buscar("SELECT a.id as ID,p.apellido_paterno as Paterno,p.apellido_materno as Materno,p.nombre as Nombre,p.rfc as RFC FROM aspirantes a INNER JOIN personal p ON a.id = p.aspirante_id WHERE a.etapa = 5");
            dgvAspi.DataSource = bd.ds.Tables[0];
            dgvAspi.Columns[0].Width = 55;
            dgvAspi.Columns[4].Width = 150;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvAspi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            string id = Convert.ToString(dgvAspi.Rows[e.RowIndex].Cells[0].Value);
            Variables.AspiranteID(id);
            Formacion ac = null;
            ac = Formacion.Instancia();
            ac.MdiParent = AdminMDI.ActiveForm;
            ac.Show();

        }
    }
}
