using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P6_Receitas
{
    interface IUtilizador
    {
        #region Properties
        int UtilizadorID { get; }
        
        string Username { get; }
        
        string Password { get; }
        
        string Pin { get; }
        #endregion

        #region Methods
        void AdicionarUtilizadorNaLista(List<Utilizador> listaUtilizadores);
        #endregion
    }
}
