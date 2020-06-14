using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;


namespace ChatApp
{
    public partial class Form1 : Form
    {
        //Declarando as variaveis que irão Tratar o usuário
        private string NomeUsuario = "Desconhecido";
        private StreamWriter stwEnviador;
        private StreamReader strReceptor;
        private TcpClient tcpServidor;

        // Atualizar o formulário com mensagens da outra thread
        private delegate void AtualizaLogCallBack(string strMensagem);

        // Definir o formulário para o estado "disconnected" de outra thread
        private delegate void FechaConexaoCallBack(string strMotivo);
        private Thread mensagemThread;
        private IPAddress enderecoIP;
        private bool Conectado;

        private static string nomeAbreviadoArquivo = "";

        public Form1()
        {
            //Para fechar a conexão após fechar a aplicação
            // Na saida da aplicação: desconect
            Application.ApplicationExit += new EventHandler(OnApplicationExit);
            InitializeComponent();
        }

        // função para executar a saida da conexão após fechada a aplicação
        public void OnApplicationExit(object sender, EventArgs e)
        {
            if (Conectado == true)
            {
                //Fechando streams e objetos
                Conectado = false;
                stwEnviador.Close();
                strReceptor.Close();
                tcpServidor.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        //Ação do botão conectar 
        private void btnConectar_Click(object sender, EventArgs e)
        {
                // caso não esteja conectando ele aguarda a conexão
                if (Conectado == false)
                {
                    // Inicializa a conexão
                    InicializaConexao();
                }
                else // Após conectado, desconecta
                {
                    FechaConexao("Desconectado a pedido do usuário.");
                }
        }

        private void InicializaConexao()
        {

            // Transforma o endereço IP informado em um objeto IPAdress
            enderecoIP = IPAddress.Parse(txtIP.Text);
            int porta = int.Parse(txtPorta.Text);
            // Inicia uma nova conexão TCP com o servidor
            tcpServidor = new TcpClient();
            tcpServidor.Connect(enderecoIP, porta);

            // verifica se Cliente/Servidor estão conectados
            Conectado = true;

            // Prepara o formulário
            NomeUsuario = txtNome.Text;

            // Desabilita e habilita os campos do formulario
            txtIP.Enabled = false;
            txtNome.Enabled = false;
            txtPorta.Enabled = false;
            txtMensagem.Enabled = true;
            btnEnviar.Enabled = true;
            btnConectar.Text = "Desconectado";

            // Envia o nome do usuário ao servidor para que as mensagens sejam identificadas. 
            stwEnviador = new StreamWriter(tcpServidor.GetStream());
            stwEnviador.WriteLine(txtNome.Text);
            stwEnviador.Flush();

            //Inicia a thread para receber mensagens e uma nova comunicação
            mensagemThread = new Thread(new ThreadStart(RecebeMensagens));
            mensagemThread.Start();
        }

        private void RecebeMensagens()
        {
            // recebe a resposta do servidor
            strReceptor = new StreamReader(tcpServidor.GetStream());
            string ConResposta = strReceptor.ReadLine();
            // Se o primeiro caracatere é 1 a conexão foi efetuada com sucesso
            if (ConResposta[0] == '1')
            {
                // Atualiza o formulário para informar que esta conectado
                this.Invoke(new AtualizaLogCallBack(this.AtualizaLog), new object[] { "Conectado com sucesso!" });
            }
            else // Caso contrário, a conexão falhou
            {
                string Motivo = "Não Conectado: ";
                // Mostra o motivo da falha, que aparece a partir do 3º caractere
                Motivo += ConResposta.Substring(2, ConResposta.Length - 2);
                // Atualiza o formulário como o motivo da falha na conexão
                this.Invoke(new FechaConexaoCallBack(this.FechaConexao), new object[] { Motivo });
                // Sai do método
                return;
            }

            // estrutura de repetção para ler as linhas que chegam do servidor. 
            while (Conectado)
            {
                // exibe mensagems recebidas na interface do usuário (txtChat)
                this.Invoke(new AtualizaLogCallBack(this.AtualizaLog), new object[] { strReceptor.ReadLine() });
            }
        }
        private void AtualizaLog(string strMensagem)
        {
            // Anexa texto ao final de cada linha
            txtChat.AppendText(strMensagem + "\r\n");
        }

        //Botão enviar
        private void btnEnviar_Click(object sender, EventArgs e)
        {
            EnviaMensagem();
        }

       
        // Envia a mensagem para o servidor
        private void EnviaMensagem()
        {
            if (txtMensagem.Lines.Length >= 1)
            {   //Passa a mesg para a caixa de texto da interface, assim o usuário vê a troca de msg
                stwEnviador.WriteLine(txtMensagem.Text);
                stwEnviador.Flush();
                txtMensagem.Lines = null;
            }
            txtMensagem.Text = "";
        }

        // Fecha a conexão com o servidor
        private void FechaConexao(string Motivo)
        {
            // Mostra o motivo porque a conexão encerrou
            txtChat.AppendText(Motivo + "\r\n");
            // Habilita e desabilita os controles apropriados no formulario
            txtIP.Enabled = true;
            txtNome.Enabled = true;
            txtMensagem.Enabled = false;
            btnEnviar.Enabled = false;
            btnConectar.Text = "Conectado";

            // Fecha os objetos, enecerrando a conexão
            Conectado = false;
            stwEnviador.Close();
            strReceptor.Close();
            tcpServidor.Close();
        }


    }
}
