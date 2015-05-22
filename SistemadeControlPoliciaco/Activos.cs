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
    public partial class Activos : Form
    {
        public Activos()
        {
            InitializeComponent();
        }
        private static Activos frmInst = null;

        public static Activos Instancia()
        {
            if (((frmInst == null) || (frmInst.IsDisposed == true)))
            {
                frmInst = new Activos();
            }
            frmInst.BringToFront();
            return frmInst;
        }
    }
}
