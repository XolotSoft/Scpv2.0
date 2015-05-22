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
    public partial class Asignar : Form
    {
        public Asignar()
        {
            InitializeComponent();
        }

        private static Asignar frmInst = null;

        public static Asignar Instancia()
        {
            if (((frmInst == null) || (frmInst.IsDisposed == true)))
            {
                frmInst = new Asignar();
            }
            frmInst.BringToFront();
            return frmInst;
        }

        private void Asignar_Load(object sender, EventArgs e)
        {
            dgvAsignaciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAsignaciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAsignaciones.RowHeadersVisible = false;
            ManejoBD db = new ManejoBD();
            ManejoBD bd = new ManejoBD();
            bd.buscarg("*", "departamentos");
            string sql3 = "SELECT d.nombre as Departamento, a.cantidad as 'Cantidad Asignada' from asignaciones a INNER JOIN departamentos d ON d.id = a.departamento_id";
            db.buscar(sql3);
            dgvAsignaciones.DataSource = db.ds.Tables[0];
            cmbArea.DataSource = bd.ds.Tables[0].DefaultView;
            cmbArea.DisplayMember = "nombre";
            cmbArea.ValueMember = "id";
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            ManejoBD bd = new ManejoBD();
            ManejoBD recurso = new ManejoBD();
            ManejoBD ins = new ManejoBD();

            string sql4 = "INSERT INTO asignaciones(departamento_id,cantidad)VALUES('" + Convert.ToString(cmbArea.SelectedValue) +
                    "','" + txbMonto.Text + "')";
            
            if (Vacio.txb(this))
            {
                recurso.buscar("SELECT * FROM recursos WHERE departamento_id = " + Convert.ToString(cmbArea.SelectedValue));
                if (recurso.ds.Tables[0].Rows.Count > 0)
                {
                    string sql2 = "UPDATE recursos SET total = total + '" + txbMonto.Text + "',restante = restante + '" + txbMonto.Text + "' WHERE departamento_id = '" + Convert.ToString(cmbArea.SelectedValue) + "'";
                    if (bd.insertarq(sql2))
                    {
                        if (ins.insertarq(sql4))
                        {
                            MessageBox.Show("Se asignaron correctamente los recursos", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ManejoBD db = new ManejoBD();
                            ManejoBD d = new ManejoBD();
                            d.buscarg("*", "departamentos");
                            string sql3 = "SELECT d.nombre as Departamento, a.cantidad as 'Cantidad Asignada' from asignaciones a INNER JOIN departamentos d ON d.id = a.departamento_id";
                            db.buscar(sql3);
                            dgvAsignaciones.DataSource = db.ds.Tables[0];
                            cmbArea.DataSource = d.ds.Tables[0].DefaultView;
                            cmbArea.DisplayMember = "nombre";
                            cmbArea.ValueMember = "id";
                        }
                        else
                        {
                            MessageBox.Show("No se registro");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se registro");
                    }
                }
                else
                {
                    string sql = "INSERT INTO recursos(departamento_id,total,restante)VALUES('" + Convert.ToString(cmbArea.SelectedValue) +
                    "','" + txbMonto.Text + "','" + txbMonto.Text + "')";
                    if (bd.insertarq(sql))
                    {
                        if (ins.insertarq(sql4))
                        {
                            MessageBox.Show("Se asignaron correctamente los recursos", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ManejoBD db = new ManejoBD();
                            ManejoBD d = new ManejoBD();
                            d.buscarg("*", "departamentos");
                            string sql3 = "SELECT d.nombre as Departamento, a.cantidad as 'Cantidad Asignada' from asignaciones a INNER JOIN departamentos d ON d.id = a.departamento_id";
                            db.buscar(sql3);
                            dgvAsignaciones.DataSource = db.ds.Tables[0];
                            cmbArea.DataSource = d.ds.Tables[0].DefaultView;
                            cmbArea.DisplayMember = "nombre";
                            cmbArea.ValueMember = "id";
                        }
                        else
                        {
                            MessageBox.Show("No se registro");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se registro");
                    }
                }
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Actividades ac = null;
            ac = Actividades.Instancia();
            ac.MdiParent = AdminMDI.ActiveForm;
            ac.Show();
            this.Close();
        }

        private void txbMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.numypun(e);
        }
    }
}
