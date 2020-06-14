using System;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Collections;

namespace ChatServidor
{
    // Trata os argumentos para o evento StatusChanged
    public class StatusChangedEventArgs : EventArgs
    {
        // Estamos interessados na mensagem descrevendo o evento
        private string EventMsg;

        // Propriedade para retornar e definir um mensagem do evento
        public string EventMessage
        {
            get { return EventMsg;}
            set { EventMsg = value;}
        }

        // Construtor para definir a mensagem do evento
        public StatusChangedEventArgs(string strEventMsg)
        {
            EventMsg = strEventMsg;
        }
    }

    // Este delegate é necessário para especificar os parametros que estamos pasando com o nosso evento
    public delegate void StatusChangedEventHandler(object sender, StatusChangedEventArgs e);

    class ChatServidor
    {
        // Esta hash table armazena os usuários e as conexões (acessado/consultado por usuário)
        public static Hashtable htUsuarios = new Hashtable(30); // 30 usuarios é o limite definido
        // Esta hash table armazena os usuários e as conexões (acessada/consultada por conexão)
        public static Hashtable htConexoes = new Hashtable(30); // 30 usuários é o limite definido
        // armazena o endereço IP passado
        private IPAddress enderecoIP;
        private int Nporta;
        private TcpClient tcpCliente;
        // O evento e o seu argumento irá notificar o formulário quando um usuário se conecta, desconecta, envia uma mensagem,etc
        public static event StatusChangedEventHandler StatusChanged;
        private static StatusChangedEventArgs e;

        // O construtor define o endereço IP para aquele retornado pela instanciação do objeto
        public ChatServidor(IPAddress endereco, int porta)
        {
            enderecoIP = endereco;
            Nporta = porta;
        }
        public void porta(int port)
        {

        }
        // A thread que ira tratar o escutador de conexões
        private Thread thrListener;

        // O objeto TCP object que escuta as conexões
        private TcpListener tlsCliente;

        // Ira dizer ao laço while para manter a monitoração das conexões
        bool ServRodando = false;

        // Inclui o usuário nas tabelas hash
        public static void IncluiUsuario(TcpClient tcpUsuario, string strUsername)
        {
            // Primeiro inclui o nome e conexão associada para ambas as hash tables
            ChatServidor.htUsuarios.Add(strUsername, tcpUsuario);
            ChatServidor.htConexoes.Add(tcpUsuario, strUsername);

            // Informa a nova conexão para todos os usuário e para o formulário do servidor
            EnviaMensagemAdmin(htConexoes[tcpUsuario] + " entrou..");
        }

        // Remove o usuário das tabelas (hash tables)
        public static void RemoveUsuario(TcpClient tcpUsuario)
        {
            // Se o usuário existir
            if (htConexoes[tcpUsuario] != null)
            {
                // Primeiro mostra a informação e informa os outros usuários sobre a conexão
                EnviaMensagemAdmin(htConexoes[tcpUsuario] + " saiu...");

                // Removeo usuário da hash table
                ChatServidor.htUsuarios.Remove(ChatServidor.htConexoes[tcpUsuario]);
                ChatServidor.htConexoes.Remove(tcpUsuario);
            }
        }

        // Este evento é chamado quando queremos disparar o evento StatusChanged
        public static void OnStatusChanged(StatusChangedEventArgs e)
        {
            StatusChangedEventHandler statusHandler = StatusChanged;
            if (statusHandler != null)
            {
                // invoca o  delegate
                statusHandler(null, e);
            }
        }

        // Envia mensagens administratias
        public static void EnviaMensagemAdmin(string Mensagem)
        {
            StreamWriter swSenderSender;

            // Exibe primeiro na aplicação
            e = new StatusChangedEventArgs("Administrador: " + Mensagem);
            OnStatusChanged(e);

            // Cria um array de clientes TCPs do tamanho do numero de clientes existentes
            TcpClient[] tcpClientes = new TcpClient[ChatServidor.htUsuarios.Count];
            // Copia os objetos TcpClient no array
            ChatServidor.htUsuarios.Values.CopyTo(tcpClientes, 0);
            // Percorre a lista de clientes TCP
            for (int i = 0; i < tcpClientes.Length; i++)
            {
                // Tenta enviar uma mensagem para cada cliente
                try
                {
                    // Se a mensagem estiver em branco ou a conexão for nula sai...
                    if (Mensagem.Trim() == "" || tcpClientes[i] == null)
                    {
                        continue;
                    }
                    // Envia a mensagem para o usuário atual no laço
                    swSenderSender = new StreamWriter(tcpClientes[i].GetStream());
                    swSenderSender.WriteLine("Administrador: " + Mensagem);
                    swSenderSender.Flush();
                    swSenderSender = null;
                }
                catch // Se houver um problema , o usuário não existe , então remove-o
                {
                    RemoveUsuario(tcpClientes[i]);
                }
            }
        }

        // Envia mensagens de um usuário para todos os outros
        public static void EnviaMensagem(string Origem, string Mensagem)
        {
            StreamWriter swSenderSender;

            // Primeiro exibe a mensagem na aplicação
            e = new StatusChangedEventArgs(Origem + " disse : " + Mensagem);
            OnStatusChanged(e);

            // Cria um array de clientes TCPs do tamanho do numero de clientes existentes
            TcpClient[] tcpClientes = new TcpClient[ChatServidor.htUsuarios.Count];
            // Copia os objetos TcpClient no array
            ChatServidor.htUsuarios.Values.CopyTo(tcpClientes, 0);
            // Percorre a lista de clientes TCP
            for (int i = 0; i < tcpClientes.Length; i++)
            {
                // Tenta enviar uma mensagem para cada cliente
                try
                {
                    // Se a mensagem estiver em branco ou a conexão for nula sai...
                    if (Mensagem.Trim() == "" || tcpClientes[i] == null)
                    {
                        continue;
                    }
                    // Envia a mensagem para o usuário atual no laço
                    swSenderSender = new StreamWriter(tcpClientes[i].GetStream());
                    swSenderSender.WriteLine(Origem + " disse: " + Mensagem);
                    swSenderSender.Flush();
                    swSenderSender = null;
                }
                catch // Se houver um problema , o usuário não existe , então remove-o
                {
                    RemoveUsuario(tcpClientes[i]);
                }
            }
        }

        public void IniciaAtendimento()
        {
            try
            {

                // Pega o IP do primeiro dispostivo da rede
                IPAddress ipaLocal = enderecoIP;
                int portaLocal = Nporta;
                // Cria um objeto TCP listener usando o IP do servidor e porta definidas
                tlsCliente = new TcpListener(ipaLocal, Nporta);

                // Inicia o TCP listener e escuta as conexões
                tlsCliente.Start();

                // O laço While verifica se o servidor esta rodando antes de checar as conexões
                ServRodando = true;

                // Inicia uma nova tread que hospeda o listener
                thrListener = new Thread(MantemAtendimento);
                thrListener.Start();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void MantemAtendimento()
        {
            // Enquanto o servidor estiver rodando
            while (ServRodando == true)
            {
                // Aceita uma conexão pendente
                tcpCliente = tlsCliente.AcceptTcpClient();
                // Cria uma nova instância da conexão
                Conexao newConnection = new Conexao(tcpCliente);
            }
        }
    }

    // Esta classe trata as conexões, serão tantas quanto as instâncias do usuários conectados
    class Conexao
    {
        TcpClient tcpCliente;
        // A thread que ira enviar a informação para o cliente
        private Thread thrSender;
        private StreamReader srReceptor;
        private StreamWriter swEnviador;
        private string usuarioAtual;
        private string strResposta;

        // O construtor da classe que que toma a conexão TCP
        public Conexao(TcpClient tcpCon)
        {
            tcpCliente = tcpCon;
            // A thread que aceita o cliente e espera a mensagem
            thrSender = new Thread(AceitaCliente);
            // A thread chama o método AceitaCliente()
            thrSender.Start();
        }

        private void FechaConexao()
        {
            // Fecha os objetos abertos
            tcpCliente.Close();
            srReceptor.Close();
            swEnviador.Close();
        }

        // Ocorre quando um novo cliente é aceito
        private void AceitaCliente()
        {
            srReceptor = new System.IO.StreamReader(tcpCliente.GetStream());
            swEnviador = new System.IO.StreamWriter(tcpCliente.GetStream());

            // Lê a informação da conta do cliente
            usuarioAtual = srReceptor.ReadLine();

            // temos uma resposta do cliente
            if (usuarioAtual != "")
            {
                // Armazena o nome do usuário na hash table
                if (ChatServidor.htUsuarios.Contains(usuarioAtual) == true)
                {
                    // 0 => significa não conectado
                    swEnviador.WriteLine("0|Este nome de usuário já existe.");
                    swEnviador.Flush();
                    FechaConexao();
                    return;
                }
                else if (usuarioAtual == "Administrator")
                {
                    // 0 => não conectado
                    swEnviador.WriteLine("0|Este nome de usuário é reservado.");
                    swEnviador.Flush();
                    FechaConexao();
                    return;
                }
                else
                {
                    // 1 => conectou com sucesso
                    swEnviador.WriteLine("1");
                    swEnviador.Flush();

                    // Inclui o usuário na hash table e inicia a escuta de suas mensagens
                    ChatServidor.IncluiUsuario(tcpCliente, usuarioAtual);
                }
            }
            else
            {
                FechaConexao();
                return;
            }
            //
            try
            {
                // Continua aguardando por uma mensagem do usuário
                while ((strResposta = srReceptor.ReadLine()) != "")
                {
                    // Se for inválido remove-o
                    if (strResposta == null)
                    {
                        ChatServidor.RemoveUsuario(tcpCliente);
                    }
                    else
                    {
                        // envia a mensagem para todos os outros usuários
                        ChatServidor.EnviaMensagem(usuarioAtual, strResposta);
                    }
                }
            }
            catch
            {
                // Se houve um problema com este usuário desconecta-o
                ChatServidor.RemoveUsuario(tcpCliente);
            }
        }
    }
}
