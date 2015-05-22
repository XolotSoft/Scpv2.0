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
    public partial class Formacion : Form
    {
        public Formacion()
        {
            InitializeComponent();
        }
        private static Formacion frmInst = null;
        public static Formacion Instancia()
        {
            if (((frmInst == null) || (frmInst.IsDisposed == true)))
            {
                frmInst = new Formacion();
            }
            frmInst.BringToFront();
            return frmInst;
        }
        
        private void Formacion_Load(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBestudios.SelectedIndex == 0)
            {
                btnLim.Enabled = false;
            }
            else
            {
                MessageBox.Show("Selecciona un archivo PDF para validar tu nivel de estudios", "Aviso",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "PDF File|*.pdf";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    Pdf.cargar(0, File.OpenRead(ofd.FileName));
                    pictureBox1.Visible = true;
                    label2.Visible = true;

                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnEdi_Click(object sender, EventArgs e)
        {
            Pdf.guardar();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "PDF File|*.pdf";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Pdf.cargar(0, File.OpenRead(ofd.FileName));
                

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "PDF File|*.pdf";
            if (ofd.ShowDialog() == DialogResult.OK)
            {

                Pdf.cargar(1, File.OpenRead(ofd.FileName));
                

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "PDF File|*.pdf";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Pdf.cargar(2, File.OpenRead(ofd.FileName));
                

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "PDF File|*.pdf";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Pdf.cargar(3, File.OpenRead(ofd.FileName));
                

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "PDF File|*.pdf";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Pdf.cargar(4, File.OpenRead(ofd.FileName));
               

            }
        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void btnCer_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void btnLim_Click(object sender, EventArgs e)
        {

        }
        private void RBpauxilios_CheckedChanged(object sender, EventArgs e)
        {
            if (RBpauxilios.Checked)
            {

                DialogResult aux =  MessageBox.Show("A continuacion Responderas una serie de preguntas, con el fin de validar el curso seleccionado", "Atencion",MessageBoxButtons.OKCancel,MessageBoxIcon.Information);
                pictureBox2.Visible = true;
                if (aux == DialogResult.Cancel)
                {
                    this.Show();
                    RBpauxilios.Checked = false;
                }
                else
                {
                    PrimerosAuxilios pax = null;
                    pax = PrimerosAuxilios.Instancia();
                    pax.MdiParent = AdminMDI.ActiveForm;
                    pax.MdiParent = UserMDI.ActiveForm;
                    pax.Show();
                }
               
            }
            else
            {
                RBpauxilios.Checked = false;
            }      
            }
        
        

        private void RBafuego_CheckedChanged(object sender, EventArgs e)
        {
            if (RBafuego.Checked)
            {

                DialogResult dia =  MessageBox.Show("A continuacion Responderas una serie de preguntas, con el fin de validar el curso seleccionado", "Atencion",MessageBoxButtons.OKCancel,MessageBoxIcon.Information);
                pictureBox4.Visible = true;
                if (dia == DialogResult.Cancel)
                {
                    this.Show();
                    RBafuego.Checked = false;
                }
                else
                {
                    ArmasFuego ar = null;
                    ar = ArmasFuego.Instancia();
                    ar.MdiParent = AdminMDI.ActiveForm;
                    ar.MdiParent = UserMDI.ActiveForm;
                    ar.Show();
                }
               
            }
            else
            {
                RBafuego.Checked = false;
            }
        }

        private void RBpcivil_CheckedChanged(object sender, EventArgs e)
        {
            if (RBpcivil.Checked)
            {

                DialogResult pci = MessageBox.Show("A continuacion Responderas una serie de preguntas, con el fin de validar el curso seleccionado", "Atencion", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                pictureBox3.Visible = true;
                if (pci == DialogResult.Cancel)
                {
                    RBpcivil.Checked = false;
                }
                else
                {
                    ProteccionCivil pc = null;
                    pc = ProteccionCivil.Instancia();
                    pc.MdiParent = AdminMDI.ActiveForm;
                    pc.MdiParent = UserMDI.ActiveForm;
                    pc.Show();
                }

            }
            else
            {
                RBpcivil.Checked = false;
            }
        }

        private void RBcsocial_CheckedChanged(object sender, EventArgs e)
        {
            if (RBcsocial.Checked)
            {

                DialogResult cs = MessageBox.Show("A continuacion Responderas una serie de preguntas, con el fin de validar el curso seleccionado", "Atencion", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                pictureBox5.Visible = true;
                if (cs == DialogResult.Cancel)
                {
                    this.Show();
                    RBcsocial.Checked = false;
                }
                else
                {
                    ComunicacionSocial cso = null;
                    cso = ComunicacionSocial.Instancia();
                    cso.MdiParent = AdminMDI.ActiveForm;
                    cso.MdiParent = UserMDI.ActiveForm;
                    cso.Show();
                }

            }
            else
            {
                RBafuego.Checked = false;
            }
        }
    }
}
