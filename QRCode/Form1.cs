using System;
using System.Drawing;
using System.Windows.Forms;
using QRCoder;

namespace QRCoder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGerarQRCode_Click(object sender, EventArgs e)
        {
            if(textTexto.Text == string.Empty)
            {
                MessageBox.Show("Campo em branco!");
                textTexto.Focus();
                return;
            }

            try
            {
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(textTexto.Text, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                Bitmap qrCodeImage = qrCode.GetGraphic(20);
                picQRCode.Image = qrCodeImage;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro : " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (picQRCode.Image == null)
            {
                MessageBox.Show("Não tem QRCode para salvar.");
                picQRCode.Focus();
                return;
            }

            string Caminho = Application.StartupPath + "\\QRCode.jpg";
            picQRCode.Image.Save(Caminho);
            MessageBox.Show("Salvo Com sucesso!");
        }

        private void btnLimpa_Click(object sender, EventArgs e)
        {
            picQRCode.Image = null;
        }
    }
}
