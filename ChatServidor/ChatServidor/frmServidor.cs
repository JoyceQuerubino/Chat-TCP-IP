using System.Windows.Forms;
using System.Net;
using System;

namespace ChatServidor
{
    public partial class Form1 : Form
    {
        private delegate void AtualizaStatusCallback(string strMensagem);

        public Form1()
        {
            InitializeComponent();
        }

        private void btnAtender_Click(object sender, System.EventArgs e)
        {
            if (txtIP.Text==string.Empty)
            {
                MessageBox.Show("Informe o endereço IP.");
                txtIP.Focus();
                return;
            }

            try
            {

                // Analisa o endereço IP do servidor informado no textbox
                IPAddress enderecoIP = IPAddress.Parse(txtIP.Text);
                int numeroporta = int.Parse(txtporta.Text);

                // Cria uma nova instância do objeto ChatServidor
                ChatServidor mainServidor = new ChatServidor(enderecoIP, numeroporta);

                // Vincula o tratamento de evento StatusChanged a mainServer_StatusChanged
                ChatServidor.StatusChanged += new StatusChangedEventHandler(mainServidor_StatusChanged);

                // Inicia o atendimento das conexões
                mainServidor.IniciaAtendimento();

                // Mostra que nos iniciamos o atendimento para conexões
                txtLog.AppendText("Monitorando as conexões...\r\n");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro de conexão : " + ex.Message);
            }
        }

        public void mainServidor_StatusChanged(object sender, StatusChangedEventArgs e)
        {
            // Chama o método que atualiza o formulário
            this.Invoke(new AtualizaStatusCallback(this.AtualizaStatus), new object[] { e.EventMessage });
        }

        private void AtualizaStatus(string strMensagem)
        {
            // Atualiza o logo com mensagens
            txtLog.AppendText(strMensagem + "\r\n");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void txtIP_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtporta_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
