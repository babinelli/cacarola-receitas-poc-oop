using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P6_Receitas
{
    #region Enumerators
    public enum EnumCategoria : ushort
    {
        Aperitivo = 1,
        Entrada = 2,
        PratoPrincipal = 3,
        Acompanhamento = 4,
        Sobremesa = 5,
        Bebida = 6
    }

    public enum EnumDificuldade : ushort
    {
        Facil = 1,
        Moderada = 2,
        Dificil = 3
    }

    public enum EnumUnidadeMedida : ushort
    {
        Grama = 1,
        Quilograma = 2,
        Mililitro = 3,
        Litro = 4,
        Chávena = 5,
        ColherCha = 6,
        ColherSopa = 7,
        ColherCafe = 8,
        Unidade = 9
    }
    #endregion
}
