using System;
using System.Collections.Generic;
using System.Linq;
using Utils;
using System.Text;
using System.Threading.Tasks;

namespace P6_Receitas
{
    class Ingrediente : IIngrediente
    {
        #region Properties
        public int IngredienteID { get; set; }

        public int ReceitaID { get; set; }

        public string IngredienteNome { get; set; }

        public double Quantidade { get; set; }

        public EnumUnidadeMedida Unidade { get; set; }
        #endregion

        #region Constructor
        public Ingrediente()
        {
            ReceitaID = 0;
            IngredienteNome = string.Empty;
            Quantidade = 0;
            Unidade = 0;
        }
        #endregion

        #region Methods
        internal static Ingrediente PedirDadosIngrediente(List<Ingrediente> listaIngredientes, int receitaId)
        {
            #region Instância Ingrediente
            Ingrediente ingrediente = new Ingrediente();
            #endregion

            #region Nome do ingrediente
            string nomeIngrediente = Utils.Utils.PedirInputString("\nNome do ingrediente: ");

            ingrediente.IngredienteNome = nomeIngrediente;
            #endregion

            #region Quantidade do ingrediente
            double quantidade = Utils.Utils.PedirInputDouble("\nQuantidade: ");

            ingrediente.Quantidade = quantidade;
            #endregion

            #region Unidade de medida do ingrediente
            Console.WriteLine("\nUnidades de medida:\n1 - Grama\n2 - Quilograma\n3 - Mililitro\n4 - Litro\n5 - Chávena\n6 - Colher de chá\n7 - Colher de sopa\n8 - Colher de café\n9 - Unidade\n");
            int unidMedida = Utils.Utils.PedirInputInt("\nUnidade de medida do ingrediente: ", 1, 9);

            ingrediente.Unidade = (EnumUnidadeMedida)unidMedida;
            #endregion

            #region IngredienteID
            int ingredienteId = LerUltimoIngredienteId(listaIngredientes) + 1;
            #endregion

            #region ReceitaID
            ingrediente.ReceitaID = receitaId;
            #endregion

            return ingrediente;

        }

        public void AdicionarIngredienteNaLista(List<Ingrediente> listaIngredientes)
        {
            listaIngredientes.Add(this);
        }

        internal static void ExibirQtdaMediaIngredientes(List<Ingrediente> listaIngredientes, List<Receita> listaReceitas)
        {
            int numReceitas = listaReceitas.Count();
            int numIngredientes = listaIngredientes.Count();

            Utils.Utils.ExibirCabeçalho("CAÇAROLA RECEITAS");

            if (numReceitas != 0)
            {
                decimal media = (numIngredientes / numReceitas);

                int mediaIngredientes = (int)Math.Round(media);

                Console.WriteLine($"Em média, as receitas possuem {mediaIngredientes} ingredientes.");

            }
            else
            {
                Console.WriteLine("Não existem receitas registadas.");
            }

            Console.ReadKey();
        }

        internal static int LerUltimoIngredienteId(List<Ingrediente> listaIngredientes)
        {
            if (listaIngredientes.Count() > 0)
            {
                Ingrediente ultimoIngrediente = listaIngredientes.Last();
                return ultimoIngrediente.IngredienteID;
            }
            else
            {
                return 0;
            }

        }
        #endregion
    }
}
