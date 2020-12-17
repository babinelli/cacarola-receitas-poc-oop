using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace P6_Receitas
{
    internal class Receita : IReceita
    {
        #region Attributes
        private string receitaNome;
        #endregion

        #region Properties
        public int ReceitaID { get; set; }

        public string ReceitaNome
        {
            get { return receitaNome; }
            set { receitaNome = value; }
        }
        
        public EnumCategoria Categoria { get; set; }
        
        public string ModoPreparo { get; set; }
        
        public EnumDificuldade Dificuldade { get; set; }
        
        public string TempoPreparo { get; set; }
        
        public bool Testada { get; set; }
        
        public int UtilizadorID { get; set; }
        #endregion

        #region Constructor
        public Receita()
        {
            ReceitaNome = string.Empty;
            Categoria = 0;
            ModoPreparo = string.Empty;
            Dificuldade = 0;
            TempoPreparo = string.Empty;
            Testada = false;
            UtilizadorID = 0;
        }
        #endregion

        #region Methods
        internal static void InserirReceita(Utilizador utilizadorLogado, List<Receita> listaReceitas, List<Utilizador> listaUtilizadores, List<Ingrediente> listaIngredientes, Dictionary<int, string> dicionarioReceitas)
        {
            bool testada = PerguntarSeReceitaTestada(utilizadorLogado, listaReceitas, listaUtilizadores);
            Receita receita;
            if (testada)
            {
                // Pedir inputs
                receita = ReceitaTestada.PedirDadosReceita(utilizadorLogado, listaReceitas, listaUtilizadores, listaIngredientes);
            }
            else
            {
                // Pedir inputs
                receita = PedirDadosReceita(listaReceitas, listaUtilizadores, listaIngredientes);
            }

            // Adicionar nova receita à lista
            receita.AdicionarReceitaNaLista(listaReceitas);
            // Adicionar nova receita ao dicionário
            receita.AdicionarReceitaNoDicionario(dicionarioReceitas);
        }

        private static bool PerguntarSeReceitaTestada(Utilizador utilizadorLogado, List<Receita> listaReceitas, List<Utilizador> listaUtilizadores)
        {
            #region Receita Testada
            Utils.Utils.ExibirCabeçalho("CAÇAROLA RECEITAS");
            string testada = Utils.Utils.PedirInputInt("\nA receita já foi testada?\n1 - SIM\n2 - NÃO", 1, 2).ToString();
            #endregion

            return (testada == "1");
        }

        private static Receita PedirDadosReceita(List<Receita> listaReceitas, List<Utilizador> listaUtilizadores, List<Ingrediente> listaIngredientes)
        {
            #region Cabeçalho
            Utils.Utils.ExibirCabeçalho("CAÇAROLA RECEITAS");
            Console.WriteLine("\n*** INSERIR NOVA RECEITA ***\n");
            #endregion

            #region Instancia
            Receita receita = new Receita();
            #endregion

            #region Receita ID
            int receitaId = LerUltimoReceitaId(listaReceitas) + 1;

            receita.ReceitaID = receitaId;
            #endregion

            #region Nome
            string nome = Utils.Utils.PedirInputString("Nome da receita: ");

            receita.ReceitaNome = nome; // Atribui valor ao atributo pela propriedade
            #endregion

            #region Categoria
            Console.WriteLine("\nCategorias:\n1 - Aperitivo\n2 - Entrada\n3 - Prato Principal\n4 - Acompanhamento\n5 - Sobremesa\n6 - Bebida");
            int categoria = Utils.Utils.PedirInputInt("\nCategoria da receita: ", 1, 6);

            receita.Categoria = (EnumCategoria)categoria;
            #endregion

            #region Ingredientes

            int addIngrediente;
            do
            {
                #region Inserir ingredientes
                Ingrediente ingrediente = Ingrediente.PedirDadosIngrediente(listaIngredientes, receitaId);
                #endregion

                #region Perguntar se deseja inserir mais ingredientes
                addIngrediente = Utils.Utils.PedirInputInt("\nDeseja inserir mais um ingrediente?\n1 - SIM\n2 - NÃO", 1, 2);
                #endregion

                #region Adicionar ingrediente à lista
                // Adiciona cada novo ingrediente à lista
                ingrediente.AdicionarIngredienteNaLista(listaIngredientes);
                #endregion

            } while (addIngrediente == 1);

            #endregion

            #region Modo de preparo
            string modoPreparo = Utils.Utils.PedirInputString("\nModo de preparo: ");

            receita.ModoPreparo = modoPreparo;
            #endregion

            #region Dificuldade
            Console.WriteLine("\nNível de dificuldade:\n\n1 - Fácil\n2 - Moderada\n3 - Difícil\n");
            int dificuldade = Utils.Utils.PedirInputInt("\nDificuldade da receita: ", 1, 3);

            receita.Dificuldade = (EnumDificuldade)dificuldade;
            #endregion

            #region Tempo de preparo
            int tempoPreparo = Utils.Utils.PedirInputInt("\nTempo de preparo em minutos: ", 1);

            receita.TempoPreparo = tempoPreparo.ToString();
            #endregion

            #region Testada
            receita.Testada = false;
            #endregion

            #region Utilizador ID
            int utilizadorId = Utilizador.LerUltimoUtilizadorID(listaUtilizadores);

            receita.UtilizadorID = utilizadorId;
            #endregion

            return receita;
        }
        
        public void AdicionarReceitaNaLista(List<Receita> listaReceitas)
        {
            listaReceitas.Add(this);
            Utils.Utils.ExibirMensagem("\nReceita adicionada com sucesso!");
        }
        
        public void AdicionarReceitaNoDicionario(Dictionary<int, string> dicionarioReceitas)
        {
            dicionarioReceitas.Add(this.ReceitaID, this.ReceitaNome);
        }
        
        internal static void ExibirListaReceitas(List<Receita> listaReceitas, List<Ingrediente> listaIngredientes)
        {
            #region Cabeçalho
            Utils.Utils.ExibirCabeçalho("CAÇAROLA RECEITAS");
            Console.WriteLine("\n*** LISTA DE RECEITAS ***\n");
            #endregion

            #region Exibir na consola
            foreach (var receita in listaReceitas)
            {
                if (receita.Testada)
                {
                    Console.WriteLine($"{receita.ReceitaID} - {receita.ReceitaNome.ToUpper()}\n\nCategoria: {receita.Categoria}\n\nDificuldade: {receita.Dificuldade} \n\nIngredientes:");

                    foreach (var ingrediente in listaIngredientes.Where(i => i.ReceitaID == receita.ReceitaID))
                    {
                        Console.WriteLine($"{ingrediente.Quantidade} {ingrediente.Unidade} - {ingrediente.IngredienteNome}");
                    }

                    Console.WriteLine($"\nModo de preparo:\n{receita.ModoPreparo}\n\nTempo de preparo: {receita.TempoPreparo} minutos\n\nTestada em: {Utils.Utils.PegarData(((ReceitaTestada)receita).DataTeste)}");
                }
                else
                {
                    Console.WriteLine($"{receita.ReceitaID} - {receita.ReceitaNome.ToUpper()}\n\nCategoria: {receita.Categoria}\n\nDificuldade: {receita.Dificuldade} \n\nIngredientes:");

                    foreach (var ingrediente in listaIngredientes.Where(i => i.ReceitaID == receita.ReceitaID))
                    {
                        Console.WriteLine($"{ingrediente.Quantidade} {ingrediente.Unidade} - {ingrediente.IngredienteNome}");
                    }

                    Console.WriteLine($"\nModo de preparo:\n{receita.ModoPreparo}\n\nTempo de preparo: {receita.TempoPreparo} minutos\n\nTestada: Receita não testada.");

                }
                Console.WriteLine("------------------------------------------------------------------------------\n");

            }
            Console.ReadKey();
            #endregion

        }
        
        internal static void ExibirDicionarioReceitas(Dictionary<int, string> dicionarioReceitas)
        {
            #region Cabeçalho
            Utils.Utils.ExibirCabeçalho("CAÇAROLA RECEITAS");
            Console.WriteLine("\n*** DICIONÁRIO DE RECEITAS ***\n");
            #endregion

            foreach (var item in dicionarioReceitas)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
            Console.ReadKey();
        }
        
        internal static int LerUltimoReceitaId(List<Receita> listaReceitas)
        {
            if (listaReceitas.Count() > 0)
            {
                Receita ultimaReceita = listaReceitas.Last();
                return ultimaReceita.ReceitaID;
            }
            else
            {
                return 0;
            }

        }
        
        internal static void ExibirContagemReceitas(List<Receita> listaReceitas)
        {
            int numReceitas = listaReceitas.Count();
            int numReceitasTestadas = listaReceitas.Where(r => r.Testada == true).Count();
            int numReceitasPorTestar = listaReceitas.Where(r => r.Testada == false).Count();

            Utils.Utils.ExibirCabeçalho("CAÇAROLA RECEITAS");
            Console.WriteLine("\n*** CONTAGEM DE RECEITAS ***\n");
            Console.WriteLine($"Existem {numReceitas} receitas registadas em Caçarola Receitas.\nDestas, {numReceitasTestadas} foram testadas e {numReceitasPorTestar} ainda estão por testar.");
            Console.ReadKey();
        }
        
        internal static void ExibirReceitasCom5IngredientesOuMais(List<Ingrediente> listaIngredientes, List<Receita> listaReceitas)
        {
            // Para cada receita (r), conta o número de ingredientes (i) com o mesmo ReceitaID de r
            var receitasFiltradas = listaReceitas.Where(r => listaIngredientes.Where(i => i.ReceitaID == r.ReceitaID).Count() >= 5).
                OrderByDescending(r => listaIngredientes.Where(i => i.ReceitaID == r.ReceitaID).Count());

            Utils.Utils.ExibirCabeçalho("CAÇAROLA RECEITAS");

            if (receitasFiltradas.Count() == 0)
            {
                Utils.Utils.ExibirMensagem("Não existem receitas com 5 ingredientes ou mais.");
            }
            else
            {
                foreach (var receita in receitasFiltradas)
                {

                    Console.WriteLine($"{receita.ReceitaID} - {receita.ReceitaNome}\nCategoria:{receita.Categoria}\nDificuldade:{receita.Dificuldade}");
                    Console.WriteLine("----------------------------------------------------------------------");

                }
                Console.ReadKey();
            }

        }
        #endregion
    }
}
