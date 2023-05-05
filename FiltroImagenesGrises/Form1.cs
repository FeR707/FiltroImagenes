using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FiltroImagenesGrises
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void abrirImagenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog()
            {
                Filter = "Archivos de Imagen (*.jpg)|*.jpg|All files (*.*)|*.*"
            };

            if (open.ShowDialog() == DialogResult.OK)
            {
                pbOriginal.Image = Image.FromFile(open.FileName);
            }
        }

        private void grisesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap imagen = new Bitmap(pbOriginal.Image);
            Bitmap imagenGrises = new Bitmap(imagen.Width, imagen.Height);

            for(int x = 0; x < imagen.Width; x++)
            {
                for (int Y = 0; Y < imagen.Height; Y++)
                {
                    Color pixel = imagen.GetPixel(x, Y);
                    Byte pixelGris= (byte)(pixel.R * 0.3 + pixel.G * 0.59 + pixel.B * 0.11);

                    imagenGrises.SetPixel(x,Y,Color.FromArgb(pixelGris, pixelGris, pixelGris));
                }
            }
            pbGris.Image = imagenGrises;
        }

        private void binarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap imagen = new Bitmap(pbOriginal.Image);
            Bitmap imagenBinario = new Bitmap(imagen.Width, imagen.Height);

            for (int x = 0; x < imagen.Width; x++)
            {
                for (int Y = 0; Y < imagen.Height; Y++)
                {
                    Color pixel = imagen.GetPixel(x, Y);
                 
                    if (pixel.R >= 128)
                    {
                        imagenBinario.SetPixel(x, Y, Color.FromArgb(255, 255, 255));
                    }
                    else
                    {
                        imagenBinario.SetPixel(x, Y, Color.FromArgb(0, 0, 0));
                    }
                }
            }
            pbBinario.Image = imagenBinario;
        }
    }
}
