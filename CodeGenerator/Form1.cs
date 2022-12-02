using System;
using System.Drawing;
using System.Windows.Forms;

namespace CodeGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Boolean generated = false;
        Zen.Barcode.Code128BarcodeDraw barcode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
        Zen.Barcode.CodeQrBarcodeDraw qr = Zen.Barcode.BarcodeDrawFactory.CodeQr;

        private void btn_barcode_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Image = barcode.Draw(textBox1.Text, 50);
                generated = true;
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("First write code");
                generated = false;
            }
        }

        private void btn_qrcode_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Image = qr.Draw(textBox2.Text, 50);
                generated = true;
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("First write code");
                generated = false; 
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
                if (generated)
                {
                    var sfd = new SaveFileDialog();
                    sfd.Filter = "Image(*.jpg)|*.jpg|(*.*|*.*";

                    if (sfd.ShowDialog() == DialogResult.OK)
                        pictureBox1.Image.Save(sfd.FileName);
                }
                else
                    MessageBox.Show("First generate code");
        }

        private void btn_reset_Click(object sender, EventArgs e) => ResetFields();

        private void ResetFields()
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            pictureBox1.Image = null;
            generated = false;
        }
    }
}