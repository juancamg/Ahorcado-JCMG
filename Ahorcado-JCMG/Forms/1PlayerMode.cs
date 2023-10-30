using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Net.Mime.MediaTypeNames;

namespace Ahorcado_JCMG.Forms
{
    public partial class _1PlayerMode : Form
    {
        string palabraSecreta = "";
        char[] palabraOculta;
        int intentosFallidos = 0;
        Button[] letrasBotones = new Button[12];
        public _1PlayerMode()
        {
            InitializeComponent();
            palabraSecreta = GenerarPalabra();
            InicializarBotones();
        }

        private void InicializarAvatar()
        {
            AvatarSelectionForm Avatar = new AvatarSelectionForm();
            int avatarNumber = Avatar.avatar;
            string avatarName = $"Avatar__{avatarNumber}_";
            
            // ya está el nombre del avatar listo, solo falta ponerlo en el pictureBox
        }

        private static String GenerarPalabra()
        {
            ConfigurationForm configForm = new ConfigurationForm();

            // Ruta del archivo XML
            string rutaArchivoXml = @"..\..\..\Resources\Dictionary.xml";

            // Crea un objeto XmlDocument y carga el archivo XML
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(rutaArchivoXml);

            // Obtén la lista de palabras que pertenecen a la categoría seleccionada en ConfigurationForm
            string categoriaSeleccionada = configForm.comboBoxCategoria.Text;
            XmlNodeList words = xmlDoc.SelectNodes("/wordlist/word[@category='" + categoriaSeleccionada + "']");

            // Obtén una palabra aleatoria de la lista
            Random random = new Random();
            //String palabraSecreta = words[random.Next(words.Count)].InnerText.ToUpper();
            String palabraSecreta = "BALONCESTO";

            return palabraSecreta;
        }
        private void InicializarBotones()
        {
            // Rellena el array letrasBotones con los botones correspondientes
            for (int i = 0; i < 12; i++)
            {
                letrasBotones[i] = panel1.Controls["letra" + (i + 1)] as Button;
            }

            // Inicializa los botones con guiones bajos según la longitud de palabraSecreta
            for (int i = 0; i < palabraSecreta.Length; i++)
            {
                if (i < letrasBotones.Length)
                {
                    letrasBotones[i].Text = "_";
                    letrasBotones[i].Visible = true;
                }
            }
        }


        private void ActualizarImagenAhorcado(int intentos)
        {
            // Actualiza la imagen del ahorcado
            //PictureBox pictureBox = (PictureBox)this.Controls["image" + (intentosFallidos).ToString()];
            //pictureBox.Visible = true;

            //picAhorcado.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject("GummyBear" + intentosFallidos);
            if (intentos >= 1 && intentos <= 6) // Asegura que el contador esté dentro del rango válido
            {
                pictureBox.Image = Properties.Resources.ResourceManager.GetObject($"GummyBear{intentos}") as System.Drawing.Image;
            }
        }

        private void ActualizarPalabraOculta()
        {
            for (int i = 0; i < palabraSecreta.Length; i++)
            {
                char letra = palabraSecreta[i];
                Button letraButton = this.Controls["letra" + (i + 1)] as Button;

                if (palabraOculta[i] == letra)
                {
                    letraButton.Text = letra.ToString();
                }
            }
        }

        private bool ComprobarLetra(char letra)
        {
            bool acierto = false;

            for (int i = 0; i < palabraSecreta.Length; i++)
            {
                if (palabraSecreta[i] == letra)
                {
                    acierto = true;

                    // Actualiza la letra en el botón correspondiente
                    letrasBotones[i].Text = letra.ToString();
                }
            }

            if (!acierto)
            {
                // La letra no se encuentra en la palabra
                intentosFallidos++;
                ActualizarImagenAhorcado(intentosFallidos);

                if (intentosFallidos == 6)
                {
                    // Has perdido
                    MessageBox.Show("¡Has perdido! La palabra era: " + palabraSecreta);
                }
                return false;
            }

            return true;
        }

        private void Letra_Click(object sender, EventArgs e, char letra)
        {
            if (ComprobarLetra(letra))
            {
                ((Button)sender).BackgroundImage = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject($"{letra}_Key_Green");
            }
            else
            {
                ((Button)sender).BackgroundImage = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject($"{letra}_Key_Red");
            }
             ((Button)sender).Enabled = false;
        }

        private void A_Key_Click(object sender, EventArgs e)
        {
            Letra_Click(sender, e, 'A');
        }

        private void B_Key_Click(object sender, EventArgs e)
        {
            Letra_Click(sender, e, 'B');
        }

        private void C_Key_Click_1(object sender, EventArgs e)
        {
            Letra_Click(sender, e, 'C');
        }

        private void D_Key_Click(object sender, EventArgs e)
        {
            Letra_Click(sender, e, 'D');
        }

        private void E_Key_Click(object sender, EventArgs e)
        {
            Letra_Click(sender, e, 'E');
        }

        private void F_Key_Click(object sender, EventArgs e)
        {
            Letra_Click(sender, e, 'F');
        }

        private void G_Key_Click(object sender, EventArgs e)
        {
            Letra_Click(sender, e, 'G');
        }

        private void H_Key_Click(object sender, EventArgs e)
        {
            Letra_Click(sender, e, 'H');
        }

        private void I_Key_Click(object sender, EventArgs e)
        {
            Letra_Click(sender, e, 'I');
        }

        private void J_Key_Click(object sender, EventArgs e)
        {
            Letra_Click(sender, e, 'J');
        }

        private void K_Key_Click(object sender, EventArgs e)
        {
            Letra_Click(sender, e, 'K');
        }

        private void L_Key_Click(object sender, EventArgs e)
        {
            Letra_Click(sender, e, 'L');
        }

        private void M_Key_Click(object sender, EventArgs e)
        {
            Letra_Click(sender, e, 'M');
        }

        private void N_Key_Click(object sender, EventArgs e)
        {
            Letra_Click(sender, e, 'N');
        }

        private void O_Key_Click(object sender, EventArgs e)
        {
            Letra_Click(sender, e, 'O');
        }

        private void P_Key_Click(object sender, EventArgs e)
        {
            Letra_Click(sender, e, 'P');
        }

        private void Q_Key_Click(object sender, EventArgs e)
        {
            Letra_Click(sender, e, 'Q');
        }

        private void R__Key_Click(object sender, EventArgs e)
        {
            Letra_Click(sender, e, 'R');
        }

        private void S_Key_Click(object sender, EventArgs e)
        {
            Letra_Click(sender, e, 'S');
        }

        private void T_Key_Click(object sender, EventArgs e)
        {
            Letra_Click(sender, e, 'T');
        }

        private void U_Key_Click(object sender, EventArgs e)
        {
            Letra_Click(sender, e, 'U');
        }

        private void V_Key_Click(object sender, EventArgs e)
        {
            Letra_Click(sender, e, 'V');
        }

        private void W_Key_Click(object sender, EventArgs e)
        {
            Letra_Click(sender, e, 'W');
        }

        private void X_Key_Click(object sender, EventArgs e)
        {
            Letra_Click(sender, e, 'X');
        }

        private void Y_Key_Click(object sender, EventArgs e)
        {
            Letra_Click(sender, e, 'Y');
        }

        private void Z_Key_Click(object sender, EventArgs e)
        {
            Letra_Click(sender, e, 'Z');
        }
    }

}
