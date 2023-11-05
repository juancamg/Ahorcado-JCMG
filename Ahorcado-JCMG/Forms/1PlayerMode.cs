using Ahorcado_JCMG.Properties;
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
        Button[] letrasBotones = new Button[12];
        int intentosFallidos = 0;
        int puntosTotales = 0;
        int puntosRonda = 0;
        string categoriaSeleccionada;
        public _1PlayerMode(String categoriaSeleccionada)
        {
            this.categoriaSeleccionada = categoriaSeleccionada;
            InitializeComponent();
            label_categoria.Text = "Categoría: " + categoriaSeleccionada;

            IniciarPartida();
        }

        private void IniciarPartida()
        {
            intentosFallidos = 0;
            puntosTotales = puntosTotales + puntosRonda;
            puntosRonda = 0;
            label_puntosTot.Text = "Puntuación: " + puntosTotales;
            label_puntosRond.Text = "Puntos ronda: 0";
            label_errores.Text = "Errores: 0";

            palabraSecreta = GenerarPalabra(categoriaSeleccionada);
            InicializarBotones();
            InicializarTeclado();
            ActualizarImagenAhorcado(0);
        }

        private static string GenerarPalabra(string categoriaSeleccionada)
        {
            // Ruta del archivo XML
            string rutaArchivoXml = @"..\..\..\Resources\Dictionary.xml";

            // Crea un objeto XmlDocument y carga el archivo XML
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(rutaArchivoXml);

            // Obtén la lista de palabras que pertenecen a la categoría seleccionada
            XmlNodeList words = xmlDoc.SelectNodes("/wordlist/word[@category='" + categoriaSeleccionada + "']");

            // Obtén una palabra aleatoria de la lista
            Random random = new Random();
            string palabraSecreta = words[random.Next(words.Count)].InnerText.ToUpper();

            return palabraSecreta;
        }

        private void InicializarBotones()
        {
            // Rellena el array letrasBotones con los botones correspondientes
            for (int i = 0; i < 12; i++)
            {
                letrasBotones[i] = panel1.Controls["letra" + (i + 1)] as Button;
                letrasBotones[i].Text = "";
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
        private void InicializarTeclado()
        {
            // Crear un array de letras del teclado
            char[] letrasTeclado = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

            foreach (char letra in letrasTeclado)
            {
                Button boton = Controls[letra + "_Key"] as Button;
                if (boton != null)
                {
                    boton.BackgroundImage = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject($"{letra}_Key_Light");
                    boton.Enabled = true;
                }
            }
        }

        public void InicializarAvatar(int selectedAvatar)
        {
            switch (selectedAvatar)
            {
                case 1: avatar_pictureBox.Image = Properties.Resources.Avatar1; break;
                case 2: avatar_pictureBox.Image = Properties.Resources.Avatar2; break;
                case 3: avatar_pictureBox.Image = Properties.Resources.Avatar3; break;
                case 4: avatar_pictureBox.Image = Properties.Resources.Avatar4; break;
                case 5: avatar_pictureBox.Image = Properties.Resources.Avatar5; break;
                case 6: avatar_pictureBox.Image = Properties.Resources.Avatar6; break;
                case 7: avatar_pictureBox.Image = Properties.Resources.Avatar7; break;
                default: avatar_pictureBox.Image = null; break;
            }
            avatar_pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void ActualizarImagenAhorcado(int intentos)
        {
            // Actualiza la imagen del ahorcado
            switch (intentos)
            {
                case 0: pictureBox_ahorcado.Image = null; break;
                case 1: pictureBox_ahorcado.Image = Properties.Resources.GummyBear1; break;
                case 2: pictureBox_ahorcado.Image = Properties.Resources.GummyBear2; break;
                case 3: pictureBox_ahorcado.Image = Properties.Resources.GummyBear3; break;
                case 4: pictureBox_ahorcado.Image = Properties.Resources.GummyBear4; break;
                case 5: pictureBox_ahorcado.Image = Properties.Resources.GummyBear5; break;
            }
            pictureBox_ahorcado.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private bool ComprobarLetra(char letra)
        {
            bool acierto = false;

            for (int i = 0; i < palabraSecreta.Length; i++)
            {
                if (palabraSecreta[i] == letra)
                {
                    acierto = true;
                    letrasBotones[i].Text = letra.ToString();
                    puntosRonda = puntosRonda + 2;
                    label_puntosRond.Text = "Puntos ronda: " + puntosRonda;
                }
            }

            if (!acierto)
            {
                // La letra no se encuentra en la palabra
                intentosFallidos++;
                puntosRonda = puntosRonda - 1;
                ActualizarImagenAhorcado(intentosFallidos);
                label_puntosRond.Text = "Puntos ronda: " + puntosRonda;
                label_errores.Text = "Errores: " + intentosFallidos.ToString();
                return false;
            }
            return true;
        }

        private bool ComprobarVictoria()
        {
            foreach (Button boton in letrasBotones)
            {
                if (boton.Text == "_")
                {
                    return false; // Todavía hay al menos una letra sin adivinar
                }
            }
            string message = "¡Has ganado! Obtienes 10 puntos extra.\n¿Deseas jugar otra partida?";
            puntosRonda = puntosRonda + 10;
            DialogResult result = MessageBox.Show(message, "Partida finalizada", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                IniciarPartida();
            }
            return true;
        }

        private bool ComprobarDerrota()
        {
            if (intentosFallidos >= 6)
            {
                string message = "¡Has perdido! La palabra era: " + palabraSecreta + ". Has perdido 5 puntos.\n¿Deseas jugar otra partida?";
                puntosRonda = puntosRonda - 5;
                DialogResult result = MessageBox.Show(message, "Partida finalizada", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    IniciarPartida();
                }
                return true;
            }
            return false;
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

            ComprobarDerrota();
            ComprobarVictoria();
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

        private void button_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_howtoplay_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Pulsa con el mouse cada letra para intentar adivinar la palabra.\nTienes 6 intentos.", "¿Cómo jugar?", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

}
