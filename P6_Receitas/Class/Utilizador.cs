using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace P6_Receitas
{
    class Utilizador : IUtilizador
    {
        #region Properties
        public int UtilizadorID { get; set; }
        
        public string Username { get; set; }
        
        public string Password { get; set; }
        
        public string Pin { get; set; }
        #endregion

        #region Constructors
        public Utilizador()
        {
            Username = string.Empty;
            Password = string.Empty;
            Pin = string.Empty;
        }

        public Utilizador(int utilizadorId, string username, string password, string pin)
        {
            UtilizadorID = utilizadorId;
            Username = username;
            Password = password;
            Pin = pin;
        }
        #endregion

        #region Methods
        internal static Utilizador FazerLoginUsernamePassword(List<Utilizador> listaUtilizadores)
        {
            Utilizador utilizador = null;

            Utils.Utils.ExibirCabeçalho("CAÇAROLA RECEITAS");
            Console.WriteLine("\n*** LOG IN ***\n");
            string username = Utils.Utils.PedirInputString("Username: ");
            string password = Utils.Utils.PedirInputString("Password: ");

            var user = Utilizador.ValidarUtilizador(username, password, listaUtilizadores);
            if (user.Any()) // Se as credenciais forem válidas
            {
                utilizador = user.First();
                Utils.Utils.ExibirCabeçalho("CAÇAROLA RECEITAS");
                Utils.Utils.ExibirMensagem($"Olá, {utilizador.Username}");
            }
            else // Se as credenciais forem inválidas
            {
                Utils.Utils.ExibirMensagem("Credenciais inválidas.");
            }

            return utilizador;
        }
        
        internal static Utilizador FazerLoginPin(List<Utilizador> listaUtilizadores)
        {
            Utilizador utilizador = null;

            Utils.Utils.ExibirCabeçalho("CAÇAROLA RECEITAS");
            Console.WriteLine("\n*** LOG IN ***\n");
            string pin = Utils.Utils.PedirInputString("PIN: ", true);

            var user = Utilizador.ValidarUtilizador(pin, listaUtilizadores);
            if (user.Any()) // Se as credenciais forem válidas
            {
                utilizador = user.First();
                Utils.Utils.ExibirCabeçalho("CAÇAROLA RECEITAS");
                Utils.Utils.ExibirMensagem($"Olá, {utilizador.Username}");
            }
            else // Se as credenciais forem inválidas
            {
                Utils.Utils.ExibirMensagem("Credencial inválida.");
            }

            return utilizador;
        }
        
        private static IEnumerable<Utilizador> ValidarUtilizador(string username, string password, List<Utilizador> listaUtilizadores)
        {
            var user = listaUtilizadores.Where(u => u.Username == username && u.Password == password);

            return user;
        }
        
        private static IEnumerable<Utilizador> ValidarUtilizador(string pin, List<Utilizador> listaUtilizadores)
        {
            var user = listaUtilizadores.Where(u => u.Pin == pin);

            return user;
        }
        
        internal static void InserirUtilizador(List<Utilizador> listaUtilizadores)
        {
            // Pedir inputs
            Utilizador utilizador = Utilizador.PedirDadosNovoUtilizador(listaUtilizadores);

            if (utilizador != null)
            {
                // Adicionar novo utilizador à lista, caso seja diferente de null
                utilizador.AdicionarUtilizadorNaLista(listaUtilizadores);
            }
        }

        private static Utilizador PedirDadosNovoUtilizador(List<Utilizador> listaUtilizadores)
        {
            #region Cabeçalho
            Utils.Utils.ExibirCabeçalho("CAÇAROLA RECEITAS");
            Console.WriteLine("\n*** INSERIR NOVO UTILIZADOR ***\n");
            #endregion

            #region Pedir dados do novo utilizador
            string username = Utils.Utils.PedirInputString("Username: ");

            string password = Utils.Utils.PedirInputString("Password: ");

            string pin = Utils.Utils.PedirInputString("PIN: ", true);
            #endregion

            #region UtilizadorID
            int utilizadorId = LerUltimoUtilizadorID(listaUtilizadores) + 1;
            #endregion

            #region Validar par username e password e cria novo utilizador caso seja válido
            // Verifica se já existe o par username e password na lista
            var users = listaUtilizadores.Where(u => u.Username == username && u.Password == password).Select(u => u.UtilizadorID);
            // Verifica se o PIN já existe na lista
            var usersPin = listaUtilizadores.Where(u => u.Pin == pin).Select(u => u.UtilizadorID);

            if (users.Any() || usersPin.Any()) // Se já existir, dá mensagem de erro
            {
                Utils.Utils.ExibirMensagem("Utilizador já existe.");
                return null;
            }
            else // Se não existir, cria novo usuário
            {
                Utilizador utilizador = new Utilizador(utilizadorId, username, password, pin);
                return utilizador;
            }
            #endregion
        }
        
        public void AdicionarUtilizadorNaLista(List<Utilizador> listaUtilizadores)
        {
            listaUtilizadores.Add(this);
            Utils.Utils.ExibirMensagem("Utilizador adicionado com sucesso!");
        }
        
        internal static int LerUltimoUtilizadorID(List<Utilizador> listaUtilizadores)
        {
            Utilizador ultimoUtilizador = listaUtilizadores.Last();
            return ultimoUtilizador.UtilizadorID;
        }
        #endregion
    }
}
