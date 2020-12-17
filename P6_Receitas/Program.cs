using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace P6_Receitas
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instanciar listas de utilizadores, receitas e ingredientes
            List<Utilizador> listaUtilizadores = new List<Utilizador>();
            List<Receita> listaReceitas = new List<Receita>();
            List<Ingrediente> listaIngredientes = new List<Ingrediente>();

            // Instanciar dicionário de receitas
            Dictionary<int, string> dicionarioReceitas = new Dictionary<int, string>();

            // Instanciar utilizador admin
            UtilizadorAdmin utilizadorAdmin = new UtilizadorAdmin();
            
            // Adicionar admin à lista de utilizadores
            listaUtilizadores.Add(utilizadorAdmin);

            // Exibir menu para login
            // Retorna o utilizador que fez login
            Utilizador utilizadorLogado = MenuUtilitaria.ExibirMenuLogin(listaUtilizadores);

            // Exibir menu principal
            MenuUtilitaria.ExibirMenuPrincipal(utilizadorLogado, listaReceitas, listaUtilizadores, listaIngredientes, dicionarioReceitas);
        }
    }
}
