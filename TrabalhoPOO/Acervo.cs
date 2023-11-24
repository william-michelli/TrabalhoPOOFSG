using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoPOO
{
    public class Acervo
    {
        private ItemBiblioteca[] acervo;
        private const int TAM = 10;
        private int posicao = 0;

        public Acervo()
        {
            acervo = new ItemBiblioteca[TAM];
        }

        public bool Insere(ItemBiblioteca itemAtual)
        {
            bool ret = false;
            if (posicao < TAM)
            {
                acervo[posicao] = itemAtual;
                posicao++;
                ret = true;
            }
            return ret;
        }

        public ItemBiblioteca GetItemAcervo(int pos)
        {
            ItemBiblioteca itemAtual = null;
            if (pos >= 0 && pos < posicao)
            {
                itemAtual = acervo[pos];
            }
            return itemAtual;
        }

        public int Tamanho()
        {
            return posicao;
        }

        public bool RemoveItemAcervo(int identificacao)
        {
            bool achou = false;
            int aux = 0;
            while ((achou == false) && (aux < posicao))
            {
                if (acervo[aux].Identificacao == identificacao)
                {
                    Console.Clear();
                    Console.WriteLine($"{acervo[aux].Titulo} foi removido com exito\n");
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
                    acervo[i] = acervo[i + 1];
                }
                posicao--;
            }
            return achou;
        }

        public int PesquisaId(int identificacao)
        {
            for (var cont = 0; cont < posicao; cont++)
            {
                if (acervo[cont].Identificacao == identificacao)
                {
                    Console.WriteLine($"Item encontrado");
                    return cont;
                }
            }
            return -1;
        }
    }
}
