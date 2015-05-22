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
    public partial class UserMDI : Form
    {
        public UserMDI()
        {
            InitializeComponent();
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login lg = new Login();
            lg.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Registro reg = null;
            reg = Registro.Instancia();
            reg.MdiParent = this;
            reg.Show();
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditarAspirante reg = null;
            reg = EditarAspirante.Instancia();
            reg.MdiParent = this;
            reg.Show();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EliminarAspirantes del = null;
            del = EliminarAspirantes.Instancia();
            del.MdiParent = this;
            del.Show();
        }

        private void calculadoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Calculadora del = null;
            del = Calculadora.Instancia();
            del.MdiParent = this;
            del.Show();
        }

        private void notasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void UserMDI_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tssTiempo.Text = DateTime.Now.ToString("f");
        }

        private void UserMDI_Load(object sender, EventArgs e)
        {

        }

        private void continuarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ContinuarRegistro cr = null;
            cr = ContinuarRegistro.Instancia();
            cr.MdiParent = this;
            cr.Show();
        }

        private void cursosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AspiranteCursos asc = null;
            asc = AspiranteCursos.Instancia();
            asc.MdiParent = this;
            asc.Show();
        }

        private void activosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Activos ac = null;
            ac = Activos.Instancia();
            ac.MdiParent = this;
            ac.Show();
        }

        private void asignarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Asignar re = null;
            re = Asignar.Instancia();
            re.MdiParent = this;
            re.Show();
        }

        private void actividadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
             Actividades re = null;
            re = Actividades.Instancia();
            re.MdiParent = this;
            re.Show();
        }
    }
}
