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

        public int SelectedAvatar { get; private set; }

        public AvatarSelectionForm()
        {
            InitializeComponent();
        }

        private void cerrarForm()
        {
            AceptarAvatares?.Invoke(this, EventArgs.Empty);
        }

        private void avatar1_button_Click(object sender, EventArgs e)
        {
            SelectedAvatar = 1;
            cerrarForm();
        }

        private void avatar2_button_Click(object sender, EventArgs e)
        {
            SelectedAvatar = 2;
            cerrarForm();
        }

        private void avatar3_button_Click(object sender, EventArgs e)
        {
            SelectedAvatar = 3;
            cerrarForm();
        }

        private void avatar6_button_Click(object sender, EventArgs e)
        {
            SelectedAvatar = 6;
            cerrarForm();
        }

        private void avatar4_button_Click(object sender, EventArgs e)
        {
            SelectedAvatar = 4;
            cerrarForm();
        }

        private void avatar5_button_Click(object sender, EventArgs e)
        {
            SelectedAvatar = 5;
            cerrarForm();
        }

        private void avatar7_button_Click(object sender, EventArgs e)
        {
            SelectedAvatar = 7;
            cerrarForm();
        }
    }

}