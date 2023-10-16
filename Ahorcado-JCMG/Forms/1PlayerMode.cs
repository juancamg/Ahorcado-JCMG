using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        public _1PlayerMode()
        {
            InitializeComponent();

            // Ruta del archivo XML
            string rutaArchivoXml = @"..\..\..\Resources\Dictionary.xml";

            // Crea un objeto XmlDocument y carga el archivo XML
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(rutaArchivoXml);

            // Obtén la lista de palabras que pertenecen a la categoría seleccionada en ConfigurationForm
            string categoriaSeleccionada = ConfigurationForm.comboBoxCategoria.Text;
            XmlNodeList words = xmlDoc.SelectNodes("/wordlist/word[@category='" + categoriaSeleccionada + "']");

            // Obtén una palabra aleatoria de la lista
            Random random = new Random();
            // palabraSecreta = words[random.Next(words.Count)].InnerText;
            palabraSecreta = "Baloncesto";

            // Inicializa palabraOculta con guiones bajos
            palabraOculta = new char[palabraSecreta.Length * 2];
            for (int i = 0; i < palabraOculta.Length; i += 2)
            {
                palabraOculta[i] = '_';
                palabraOculta[i + 1] = ' ';
            }

            // Muestra la palabra oculta en la interfaz gráfica
            palabraOcultaLabel.Text = new string(palabraOculta);
        }

        private void ActualizarImagenAhorcado()
        {
            // Actualiza la imagen del ahorcado
            PictureBox pictureBox = (PictureBox)this.Controls["image" + (intentosFallidos).ToString()];
            pictureBox.Visible = true;
        }

        private void ActualizarPalabraOculta()
        {
            // Actualiza la etiqueta que muestra la palabra oculta
            palabraOcultaLabel.Text = new string(palabraOculta); // Convierte el char[] a una cadena
        }

        private bool ComprobarLetra(char letra)
        {
            StringBuilder mostrarPalabra = new StringBuilder();
            bool encontrada = false;

            for (int i = 0; i < palabraSecreta.Length; i++)
            {
                if (palabraSecreta[i] == letra)
                {
                    mostrarPalabra.Append(letra);
                    encontrada = true;
                }
                else if (palabraOculta[i * 2] != '_')
                {
                    mostrarPalabra.Append(palabraOculta[i * 2]);
                }
                else
                {
                    mostrarPalabra.Append("_");
                }

                if (i < palabraSecreta.Length - 1)
                {
                    mostrarPalabra.Append(" ");
                }
            }

            palabraOcultaLabel.Text = mostrarPalabra.ToString();

            if (!encontrada)
            {
                intentosFallidos++;
                if (intentosFallidos == 6)
                {
                    // Has perdido
                    MessageBox.Show("¡Has perdido! La palabra era: " + palabraSecreta);
                } else
                {
                    ActualizarImagenAhorcado();
                }
            }
            return encontrada;
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
