using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace P6_Receitas
{
    class UtilizadorAdmin : Utilizador
    {
        #region Constructor
        public UtilizadorAdmin()
        {
            UtilizadorID = 1;
            Username = "Admin";
            Password = "1234";
            Pin = "0000";
        }
        #endregion
    }
}
