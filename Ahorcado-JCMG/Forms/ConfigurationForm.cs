using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ahorcado_JCMG.Forms
{

    public partial class ConfigurationForm : Form
    {
        public event EventHandler AceptarConfiguracion;

        public ConfigurationForm()
        {
            InitializeComponent();
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            AceptarConfiguracion?.Invoke(this, EventArgs.Empty);
            this.Close();
        }
    }
}

