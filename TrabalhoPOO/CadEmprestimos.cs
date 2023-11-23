using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoPOO
{
    public class CadEmprestimos
    {
        private Emprestimo[] todosEmprestimos;
        private const int TAM = 40;
        private int posicao = 0;

        public CadEmprestimos()
        {
            todosEmprestimos = new Emprestimo[TAM];
        }

        public bool Insere(Emprestimo emprestimo)
        {
            bool ret = false;
            if (posicao < TAM)
            {
                todosEmprestimos[posicao] = emprestimo;
                posicao++;
                ret = true;
            }
            return ret;
        }

        public Emprestimo GetEmprestimo(int pos)
        {
            Emprestimo emprestimo = null;
            if (pos >= 0 && pos < posicao)
            {
                emprestimo = todosEmprestimos[pos];
            }
            return emprestimo;
        }

        public int Tamanho()
        {
            return posicao;
        }

        public bool RemoveEmprestimo(int identificacao)
        {
            bool achou = false;
            int aux = 0;
            while ((achou == false) && (aux < posicao))
            {
                if (todosEmprestimos[aux].Identificacao == identificacao)
                {
                    achou = true;
                }
                else
                {
                    aux++;
                }
            }
            if (achou == true)
            {
                for (int i = aux; i < posicao - 1; i++)
                {
                    todosEmprestimos[i] = todosEmprestimos[i + 1];
                }
                posicao--;
            }
            return achou;
        }


        public void Atrasos()
        {
            Emprestimo emprestado = null;
            for(int i = 0; i < posicao; i++)
            {
                emprestado = GetEmprestimo(i);
                if (emprestado.Item.Situacao == "emprestado" && emprestado.Data_Devolucao < DateTime.Now)
                {
                    emprestado.Item.Situacao = "atrasado";
                    Console.WriteLine($"\nSituação do item {emprestado.Item.Titulo} alterada para atrasado");
                } 
            }
        }

        public int PesquisaId(int identificacao)
        {
            for (var cont = 0; cont < posicao; cont++)
            {
                if (todosEmprestimos[cont].Identificacao == identificacao)
                {
                    Console.WriteLine($"Emprestimo encontrado");
                    return cont;
                }
            }
            return -1;
        }

    }
}
