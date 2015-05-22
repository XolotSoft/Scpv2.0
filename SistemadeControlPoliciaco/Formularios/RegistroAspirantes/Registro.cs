﻿using System;
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
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
            DoubleBuffered = true;
            dtpFecNac.Format = DateTimePickerFormat.Custom;
            dtpFecNac.CustomFormat = "yyyy-MM-dd";
        }

        string apellidoPat, apellidoMat, nombre ,fechaNac, entidadFed, sexo, curp, rfc, estadoCivil;
        private static Registro registro = null;
        ManejoBD estados = new ManejoBD();
        ManejoBD aspirante = new ManejoBD();
        ManejoBD bd = new ManejoBD();
        Texto texto = new Texto();
        Claves claves = new Claves();

        public static Registro Instancia()
        {
            if (((registro == null) || (registro.IsDisposed == true)))
            {
                registro = new Registro();
            }
            registro.BringToFront();
            return registro;
        }

        private void Registro_Load(object sender, EventArgs e)
        {
            estados.buscarg("*", "estados");
            cbxEntFed.DataSource = estados.ds.Tables[0].DefaultView;
            cbxEntFed.DisplayMember = "nombre";
            cbxEntFed.ValueMember = "clave";
            Limpiar.txb(this);
            Limpiar.cbx(this);
            dtpFecNac.ResetText();
            cbxSex.SelectedIndex = 0;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Limpiar.txb(this);
            Limpiar.cbx(this);
            dtpFecNac.ResetText();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Limpiar.txb(this);
            Limpiar.cbx(this);
            dtpFecNac.ResetText();
        }

        private void btnCon_Click(object sender, EventArgs e)
        {
            if (Vacio.txb(this))
            {
                if (Vacio.cbx(this))
                {
                    apellidoPat = txbApePat.Text;
                    apellidoMat = txbApeMat.Text;
                    nombre = txbNom.Text;
                    fechaNac = dtpFecNac.Text;
                    entidadFed = cbxEntFed.Text;
                    sexo = cbxSex.Text;
                    curp = txbCurAut.Text + txbCurHom.Text;
                    rfc = txbRfcAut.Text + txbRfcHom.Text;
                    estadoCivil = cbxEdoCiv.Text;
                    
                    aspirante.buscar("SELECT a.id,p.rfc,a.etapa FROM personal p INNER JOIN aspirantes a ON a.id = p.aspirante_id WHERE p.rfc = '" + rfc + "'");

                    if (aspirante.ds.Tables[0].Rows.Count > 0)
                    {
                        MessageBox.Show("Ya se encuentra un aspirante registrado con el RFC "+ rfc +"", "Correcto",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        string pid = Convert.ToString(aspirante.ds.Tables[0].Rows[0]["id"]);
                        string etapa = Convert.ToString(aspirante.ds.Tables[0].Rows[0]["etapa"]);
                        if (etapa != "5")
                        {
                            DialogResult dialogo = MessageBox.Show("El aspirante ya cuenta con un registro previo desea concluirlo", "Atención",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (dialogo == DialogResult.Yes)
                            {
                                Variables.AspiranteID(pid);
                                Limpiar.txb(this);
                                dtpFecNac.ResetText();
                                Limpiar.cbx(this);

                                switch (etapa)
                                {
                                    case "1":
                                        this.Hide();
                                        Domicilio domicilio = null;
                                        domicilio = Domicilio.Instancia();
                                        domicilio.MdiParent = AdminMDI.ActiveForm;
                                        domicilio.MdiParent = UserMDI.ActiveForm;
                                        domicilio.Show();
                                        break;
                                    case "2":
                                        this.Hide();
                                        Contacto contacto = null;
                                        contacto = Contacto.Instancia();
                                        contacto.MdiParent = AdminMDI.ActiveForm;
                                        contacto.MdiParent = UserMDI.ActiveForm;
                                        contacto.Show();
                                        break;
                                    case "3":
                                        this.Close();
                                        Foto foto = null;
                                        foto = Foto.Instancia();
                                        foto.MdiParent = AdminMDI.ActiveForm;
                                        foto.MdiParent = UserMDI.ActiveForm;
                                        foto.Show();
                                        break;
                                    case "4":
                                        this.Hide();
                                        Escaneo escaneo = null;
                                        escaneo = Escaneo.Instancia();
                                        escaneo.MdiParent = AdminMDI.ActiveForm;
                                        escaneo.MdiParent = UserMDI.ActiveForm;
                                        escaneo.Show();
                                        break;
                                    default:
                                        break;
                                }
                                        }
                                        if (dialogo == DialogResult.No)
                                        {
                                this.Hide();
                            }
                        }
                        else
                        {
                            DialogResult dialogo = MessageBox.Show("El aspirante ya ha concluido con su proceso de registro", "Atención",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        if (bd.insertar("aspirantes", "etapa", "1"))  
                        {
                            if (bd.insertar("personal", "apellido_paterno,apellido_materno,nombre,fecha_nacimiento,sexo,entidad_federativa,curp,rfc,estado_civil,aspirante_id", "'"
                            + apellidoPat + "','" + apellidoMat + "','" + nombre + "','" + fechaNac + "','" + sexo + "','" + entidadFed + "','" + curp + "','" + rfc + "','" + estadoCivil +
                            "', (SELECT IDENT_CURRENT('aspirantes'))"))
                            {
                                bd.buscar("SELECT IDENT_CURRENT('aspirantes')");
                                Variables.AspiranteID(Convert.ToString(bd.ds.Tables[0].Rows[0][0]));
                                MessageBox.Show("El aspirante se ha registrado", "Correcto",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                                Limpiar.txb(this);
                                dtpFecNac.ResetText();
                                Limpiar.cbx(this);
                                this.Hide();
                                Domicilio dom = null;
                                dom = Domicilio.Instancia();
                                dom.MdiParent = AdminMDI.ActiveForm;
                                dom.MdiParent = UserMDI.ActiveForm;
                                dom.Show();
                            }
                            else
                            {
                                MessageBox.Show("No se registro el Aspirante", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("No se registro el Aspirante", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                   
                }
                else
                {
                    MessageBox.Show("Debes de Seleccionar una opcion", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Debes de llenar todos los campos", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        #region Genera RFC CURP
        private void calcular()
        {
            string paterno = txbApePat.Text.Trim();
            string materno = txbApeMat.Text.Trim();
            string nombre = txbNom.Text.Trim();
            txbCurAut.Text = claves.Curp(paterno, materno, nombre, dtpFecNac, cbxEntFed, cbxSex);
            txbRfcAut.Text = claves.Rfc(paterno, materno, nombre, dtpFecNac);
        }

        private void txbApePat_Leave(object sender, EventArgs e)
        {
            calcular();
            txbApePat.Text = texto.Capital(txbApePat.Text.Trim());
        }

        private void txbApeMat_Leave(object sender, EventArgs e)
        {
            calcular();
            txbApeMat.Text = texto.Capital(txbApeMat.Text.Trim());
        }

        private void txbNom_Leave(object sender, EventArgs e)
        {
            if (txbNom.Text.Trim().Length > 0)
            {
                calcular();
                txbNom.Text = texto.Capital(txbNom.Text.Trim());
            }
        }

        private void dtpFecNac_Leave(object sender, EventArgs e)
        {
            calcular();
        }
         
        private void cbxSex_Leave(object sender, EventArgs e)
        {
            if (cbxSex.SelectedIndex != -1)
            {
                calcular();
            }
        }

        private void cbxEntFed_Leave(object sender, EventArgs e)
        {
            calcular();
        }

        private void txbCurHom_Leave(object sender, EventArgs e)
        {
            if (txbCurHom.Text.Trim().Length > 1) txbCurHom.Text = txbCurHom.Text.ToUpper().Trim();
            else txbCurHom.Focus();
        }

        private void txbRfcHom_Leave(object sender, EventArgs e)
        {
            txbRfcHom.Text = txbRfcHom.Text.ToUpper().Trim();
        }
        #endregion

        #region Validaciones
        private void txbApePat_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.letrasyesp(e);
        }

        private void txbApeMat_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.letrasyesp(e);
        }

        private void txbNom_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.letrasyesp(e);
        }

        private void txbCurHom_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.letynum(e);
        }

        private void txbRfcHom_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.letynum(e);
        }
        #endregion    

    }
}
