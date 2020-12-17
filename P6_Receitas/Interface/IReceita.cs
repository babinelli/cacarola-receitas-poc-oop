using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P6_Receitas
{
    interface IReceita
    {
        #region Properties
        int ReceitaID { get; }
        
        string ReceitaNome { get; }
        
        EnumCategoria Categoria { get; }
        
        string ModoPreparo { get; }
        
        EnumDificuldade Dificuldade { get; }
        
        string TempoPreparo { get; }
        
        bool Testada { get; }
        
        int UtilizadorID { get; }
        #endregion

        #region Methods
        void AdicionarReceitaNaLista(List<Receita> listaReceitas);
        
        void AdicionarReceitaNoDicionario(Dictionary<int, string> dicionarioReceitas);
        #endregion
    }
}
