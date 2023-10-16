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

namespace Ahorcado_JCMG.Forms
{
    public partial class _1PlayerMode : Form
    {
        public _1PlayerMode()
        {
            InitializeComponent();

            // Ruta del archivo XML
            string rutaArchivoXml = @"..\..\Resources\Dictionary.xml";

            // Crea un objeto XmlDocument y carga el archivo XML
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(rutaArchivoXml);

            // Obtén la lista de nodos "word" que pertenecen a la categoría seleccionada
            string categoriaSeleccionada = "Ciudades";
            XmlNodeList words = xmlDoc.SelectNodes("/wordlist/word[@category='" + categoriaSeleccionada + "']");

            // Obtén una palabra aleatoria de la lista
            Random random = new Random();
            string selectedWord = words[random.Next(words.Count)].InnerText;

            // La variable "selectedWord" ahora contiene la palabra aleatoria de la categoría seleccionada
            label1.Text = selectedWord;
        }


    }
}
