using System;
using System.Collections.Generic;
using Utils;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P6_Receitas
{
    internal class ReceitaTestada : Receita
    {
        #region Properties
        public DateTime DataTeste { get; set; }
        #endregion

        #region Constructor
        public ReceitaTestada()
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
        internal static new ReceitaTestada PedirDadosReceita(Utilizador utilizadorLogado, List<Receita> listaReceitas, List<Utilizador> listaUtilizadores, List<Ingrediente> listaIngredientes)
        {
            #region Cabeçalho
            Utils.Utils.ExibirCabeçalho("CAÇAROLA RECEITAS");
            Console.WriteLine("\n*** INSERIR NOVA RECEITA ***\n");
            #endregion

            #region Instancia
            ReceitaTestada receitaTestada = new ReceitaTestada();
            #endregion

            #region Receita ID
            int receitaId = LerUltimoReceitaId(listaReceitas) + 1;

            receitaTestada.ReceitaID = receitaId;
            #endregion

            #region Nome
            string nome = Utils.Utils.PedirInputString("Nome da receita: ");

            receitaTestada.ReceitaNome = nome; // Atribui valor ao atributo pela propriedade
            #endregion

            #region Categoria
            Console.WriteLine("\nCategorias:\n1 - Aperitivo\n2 - Entrada\n3 - Prato Principal\n4 - Acompanhamento\n5 - Sobremesa\n6 - Bebida");
            int categoria = Utils.Utils.PedirInputInt("\nCategoria da receita: ", 1, 6);

            receitaTestada.Categoria = (EnumCategoria)categoria;
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

            receitaTestada.ModoPreparo = modoPreparo;
            #endregion

            #region Dificuldade
            Console.WriteLine("\nNível de dificuldade:\n\n1 - Fácil\n2 - Moderada\n3 - Difícil\n");
            int dificuldade = Utils.Utils.PedirInputInt("\nDificuldade da receita: ", 1, 3);

            receitaTestada.Dificuldade = (EnumDificuldade)dificuldade;
            #endregion

            #region Tempo de preparo
            int tempoPreparo = Utils.Utils.PedirInputInt("\nTempo de preparo em minutos: ", 1);

            receitaTestada.TempoPreparo = tempoPreparo.ToString();
            #endregion

            #region Testada
            receitaTestada.Testada = true;
            #endregion

            #region DataTeste
            DateTime dataTeste = Utils.Utils.PedirInputDateTime("\nEm que data a receita foi testada? (Formato: yyyy-MM-dd ou dd-MM-yyyy)");

            receitaTestada.DataTeste = dataTeste;
            #endregion

            #region Utilizador ID
            int utilizadorId = Utilizador.LerUltimoUtilizadorID(listaUtilizadores);

            receitaTestada.UtilizadorID = utilizadorId;
            #endregion

            return receitaTestada;
        }
        #endregion
    }
}
