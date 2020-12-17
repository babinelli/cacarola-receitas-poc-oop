using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public class Utils
    {
        #region Methods
        public static void ExibirCabeçalho(string cabecalho)
        {
            Console.Clear();
            Console.WriteLine($"\n******* {cabecalho} *******\n");
        }

        public static void ExibirMensagem(string mensagem)
        {
            Console.WriteLine(mensagem);
            Console.ReadKey();
        }

        public static int PedirInputInt(string pergunta, int inf = int.MinValue, int sup = int.MaxValue)
        {
            int inputInt;

            Console.WriteLine(pergunta);

            while (!(int.TryParse(Console.ReadLine(), out inputInt)) || inputInt < inf || inputInt > sup)
            {
                ExibirMensagem("Valor inválido.");
                Console.WriteLine(pergunta);
            }

            return inputInt;
        }

        public static double PedirInputDouble(string pergunta)
        {
            Console.WriteLine(pergunta);
            string input = Console.ReadLine();

            double inputDouble;

            while (!(double.TryParse(input, out inputDouble)))
            {
                ExibirMensagem("Valor inválido.");
                Console.WriteLine(pergunta);
            }

            return inputDouble;
        }

        public static string PedirInputString(string pergunta, bool ValidarNumerico = false)
        {
            string input;
            do
            {
                Console.WriteLine(pergunta);
                input = Console.ReadLine();

                if (input == "" || (ValidarNumerico && !Numerico(input)))
                {
                    ExibirMensagem("Valor inválido.");
                }

            } while (input == "" || (ValidarNumerico && !Numerico(input)));

            return input;
        }

        public static bool Numerico(string str)
        {
            return int.TryParse(str, out int num);
        }
        
        public static DateTime PedirInputDateTime(string pergunta)
        {
            Console.WriteLine(pergunta);

            DateTime dateTime;

            while (!(DateTime.TryParse(Console.ReadLine(), out dateTime)) || dateTime > DateTime.Now)
            {
                ExibirMensagem("Data inválida.");
                Console.WriteLine(pergunta);
            }

            return dateTime;
        }

        public static string PegarData(DateTime dateTime)
        {
            string dia = dateTime.Day.ToString();
            string mes = dateTime.Month.ToString();
            string ano = dateTime.Year.ToString();

            return $"{dia}/{mes}/{ano}";
        }
        #endregion
    }
}
