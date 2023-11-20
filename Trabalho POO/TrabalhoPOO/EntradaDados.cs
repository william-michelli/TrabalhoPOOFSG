using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoPOO
{
    public class EntradaDados
    {
        public EntradaDados()
        {
        }
        public int LeInteiro(string mensagem) //Entrada de dados com consistência - executa até ser digitado um inteiro. Mensagem de entrada inválida
        {
            string aux;
            int n = 0;
            bool ok;
            do
            {
                ok = true;
                Console.Write(mensagem);
                aux = Console.ReadLine();
                if (!int.TryParse(aux, out n)) // false (true)
                {
                    ok = false;
                }
                if (ok == false)
                {
                    Console.WriteLine("Entrada inválida! Digite Novamente!");
                }
            } while (ok == false);
            return n;
        }
        public int LeInteiro(string mensagem, int min, int max) //Entrada de dados com consistência - executa até ser digitado um inteiro. Mensagem de entrada inválida
        {
            string aux;
            int n = 0;
            bool ok;
            do
            {
                ok = true;
                Console.Write(mensagem);
                aux = Console.ReadLine();
                if (!int.TryParse(aux, out n)) // false (true)
                {
                    ok = false;
                }
                if ((n < min) || (n > max))
                {
                    ok = false;
                }
                if (ok == false)
                {
                    Console.WriteLine("Entrada inválida! Digite Novamente!");
                }
            } while (ok == false);
            return n;
        }
        public double LeDouble(string mensagem) //Entrada de dados com consistência - executa até ser digitado um inteiro. Mensagem de entrada inválida
        {
            string aux;
            double n = 0;
            bool ok;
            do
            {
                ok = true;
                Console.Write(mensagem);
                aux = Console.ReadLine();
                if (!double.TryParse(aux, out n)) // false (true)
                {
                    ok = false;
                }
                if (ok == false)
                {
                    Console.WriteLine("Entrada inválida! Digite Novamente!");
                }
            } while (ok == false);
            return n;
        }
        public char LeChar(string mensagem) //Entrada de dados com consistência - executa até ser digitado um inteiro. Mensagem de entrada inválida
        {
            string aux;
            char c = ' ';
            bool ok;
            do
            {
                ok = true;
                Console.Write(mensagem);
                aux = Console.ReadLine();
                if (!char.TryParse(aux, out c)) // false (true)
                {
                    ok = false;
                }
                if (ok == false)
                {
                    Console.WriteLine("Entrada inválida! Digite Novamente!");
                }
            } while (ok == false);
            return c;
        }
        public string LeString(string mensagem) //Entrada de dados com consistência - executa até ser digitado um inteiro. Mensagem de entrada inválida
        {
            string aux;
            Console.Write(mensagem);
            aux = Console.ReadLine();
            return aux;
        }
    }   
}
