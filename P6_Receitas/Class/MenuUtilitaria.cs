using System;
using System.Collections.Generic;
using System.Linq;
using Utils;
using System.Text;
using System.Threading.Tasks;

namespace P6_Receitas
{
    class MenuUtilitaria
    {
        #region Methods
        internal static Utilizador ExibirMenuLogin(List<Utilizador> listaUtilizadores)
        {
            string login;
            Utilizador utilizador = null;
            do
            {
                Utils.Utils.ExibirCabeçalho("CAÇAROLA RECEITAS");
                Console.WriteLine("1 - Entrar com Username e Password\n2 - Entrar com PIN\n0 - SAIR DA APLICAÇÃO");
                login = Utils.Utils.PedirInputInt("\nEscolha uma forma de LogIn: ", 0, 2).ToString();

                switch (login)
                {
                    case "1":
                        utilizador = Utilizador.FazerLoginUsernamePassword(listaUtilizadores);
                        break;
                    case "2":
                        utilizador = Utilizador.FazerLoginPin(listaUtilizadores);
                        break;
                }
            } while (login != "0" && utilizador == null);

            return utilizador;
        }

        internal static void ExibirMenuPrincipal(Utilizador utilizadorLogado, List<Receita> listaReceitas, List<Utilizador> listaUtilizadores, List<Ingrediente> listaIngredientes, Dictionary<int, string> dicionarioReceitas)
        {
            if (utilizadorLogado == null)
            {
                return;
            }

            string opcao;
            do
            {
                Utils.Utils.ExibirCabeçalho("CAÇAROLA RECEITAS");
                Console.WriteLine("\n*** MENU PRINCIPAL ***\n");

                if (utilizadorLogado.Username == "Admin")
                {
                    Console.WriteLine("1 - Inserir Receita\n2 - Ver Receitas\n3 - Consultar Receitas\n4 - Criar novo utilizador\n0 - SAIR DA APLICAÇÃO");
                    opcao = Utils.Utils.PedirInputInt("\nEscolha a opção desejada: ", 0, 4).ToString();
                }
                else // Não tem a opção de criar novo utilizador
                {
                    Console.WriteLine("1 - Inserir Receita\n2 - Ver Receitas\n3 - Consultar Receitas\n0 - SAIR DA APLICAÇÃO");
                    opcao = Utils.Utils.PedirInputInt("\nEscolha a opção desejada: ", 0, 3).ToString();
                }

                switch (opcao)
                {

                    case "1": // Inserir receita
                        Receita.InserirReceita(utilizadorLogado, listaReceitas, listaUtilizadores, listaIngredientes, dicionarioReceitas);

                        break;
                    case "2": // Ver receitas
                        MenuVerReceitas(listaReceitas, dicionarioReceitas, listaIngredientes);

                        break;
                    case "3": // Consultar receitas
                        MenuConsultarReceitas(listaReceitas, listaIngredientes);

                        break;
                    case "4": // Criar utilizador
                        Utilizador.InserirUtilizador(listaUtilizadores);
                        break;
                    case "0": // Opção sair
                        break;
                }
            } while (opcao != "0");
        }
        #endregion

        #region Métodos privados
        private static void MenuVerReceitas(List<Receita> listaReceitas, Dictionary<int, string> dicionarioReceitas, List<Ingrediente> listaIngredientes)
        {
            string opcao;
            do
            {
                Utils.Utils.ExibirCabeçalho("CAÇAROLA RECEITAS");
                Console.WriteLine("\n*** VER RECEITAS ***\n");
                Console.Write("1 - Lista de receitas (receitas completas)\n2 - Dicionário de receitas (ID e nome das receitas)\n0 - VOLTAR AO MENU ANTERIOR\n");
                opcao = Utils.Utils.PedirInputString("\nComo deseja ver as receitas?");

                switch (opcao)
                {
                    case "1":
                        Receita.ExibirListaReceitas(listaReceitas, listaIngredientes);
                        break;
                    case "2":
                        Receita.ExibirDicionarioReceitas(dicionarioReceitas);
                        break;
                    case "0":
                        return;
                    default:
                        Utils.Utils.ExibirMensagem("Opção inválida.");
                        break;
                }

            } while (opcao != "0");
        }

        private static void MenuConsultarReceitas(List<Receita> listaReceitas, List<Ingrediente> listaIngredientes)
        {
            string opcao;
            do
            {
                Utils.Utils.ExibirCabeçalho("CAÇAROLA RECEITAS");
                Console.WriteLine("\n*** CONSULTAR RECEITAS ***\n");
                Console.WriteLine("1 - Quantidade média de ingredientes por receita\n2 - Quantidade de receitas\n3 - Receitas com mais de 5 ingredientes\n0 - VOLTAR AO MENU ANTERIOR");
                opcao = Utils.Utils.PedirInputString("\nEscolha a opção desejada.");

                switch (opcao)
                {
                    case "1":
                        Ingrediente.ExibirQtdaMediaIngredientes(listaIngredientes, listaReceitas);
                        break;
                    case "2":
                        Receita.ExibirContagemReceitas(listaReceitas);
                        break;
                    case "3":
                        Receita.ExibirReceitasCom5IngredientesOuMais(listaIngredientes, listaReceitas);
                        break;
                    case "0":
                        return;
                    default:
                        Utils.Utils.ExibirMensagem("Opção inválida.");
                        break;
                }
            } while (opcao != "0");

        }
        #endregion
    }
}
