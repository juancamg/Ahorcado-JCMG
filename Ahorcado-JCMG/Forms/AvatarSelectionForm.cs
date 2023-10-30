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
    public partial class AvatarSelectionForm : Form
    {
        public event EventHandler AceptarAvatares;

        public AvatarSelectionForm()
        {
            InitializeComponent();
        }

        public int avatar = 0;

        private void cerrarForm()
        {
            AceptarAvatares?.Invoke(this, EventArgs.Empty);
            this.Close();
        }

        private void avatar1_button_Click(object sender, EventArgs e)
        {
            avatar = 1;
            cerrarForm();
        }

        private void avatar2_button_Click(object sender, EventArgs e)
        {
            avatar = 2;
            cerrarForm();
        }

        private void avatar3_button_Click(object sender, EventArgs e)
        {
            avatar = 3;
            cerrarForm();
        }

        private void avatar6_button_Click(object sender, EventArgs e)
        {
            avatar = 6;
            cerrarForm();
        }

        private void avatar4_button_Click(object sender, EventArgs e)
        {
            avatar = 4;
            cerrarForm();
        }

        private void avatar5_button_Click(object sender, EventArgs e)
        {
            avatar = 5;
            cerrarForm();
        }

        private void avatar7_button_Click(object sender, EventArgs e)
        {
            avatar = 7;
            cerrarForm();
        }
    }

}
