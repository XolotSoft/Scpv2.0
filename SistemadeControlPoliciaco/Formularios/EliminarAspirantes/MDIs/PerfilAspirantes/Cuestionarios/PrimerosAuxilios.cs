using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SistemadeControlPoliciaco
{
    public partial class PrimerosAuxilios : Form
    {
        public PrimerosAuxilios()
        {
            InitializeComponent();
        }
        private static PrimerosAuxilios frmInst = null;

        public static PrimerosAuxilios Instancia()
        {
            if (((frmInst == null) || (frmInst.IsDisposed == true)))
            {
                frmInst = new PrimerosAuxilios();
            }
            frmInst.BringToFront();
            return frmInst;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar.cbx(this);
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            if (Vacio.cbx(this))
            {
                MessageBox.Show("Ahora solo selecciona un archivo PDF para validar el curso", "Aviso",
                           MessageBoxButtons.OK, MessageBoxIcon.Information);
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "PDF File|*.pdf";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    Pdf.cargar(0, File.OpenRead(ofd.FileName));
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("No puedes dejar preguntas sin responder");
            }
        }
    }
}
