using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P6_Receitas
{
    interface IIngrediente
    {
        #region Properties
        int IngredienteID { get; }
        
        int ReceitaID { get; }
        
        string IngredienteNome { get; }
        
        double Quantidade { get; }
        
        EnumUnidadeMedida Unidade { get; }
        #endregion

        #region Methods
        void AdicionarIngredienteNaLista(List<Ingrediente> listaIngredientes);
        #endregion
    }
}
