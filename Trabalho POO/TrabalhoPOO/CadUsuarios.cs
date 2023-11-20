using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoPOO
{
    public class CadUsuarios
    {
        private Usuario[] usuarios;
        private const int TAM = 10;
        private int posicao = 0;

        public CadUsuarios()
        {
            usuarios = new Usuario[TAM];
        }

        public bool Insere(Usuario usuario)
        {
            bool ret = false;
            if (posicao < TAM)
            {
                usuarios[posicao] = usuario;
                posicao++;
                ret = true;
            }
            return ret;
        }

        public Usuario GetUsuario(int pos)
        {
            Usuario usuario = null;
            if (pos >= 0 && pos < posicao)
            {
                usuario = usuarios[pos];
            }
            return usuario;
        }

        public int Tamanho()
        {
            return posicao;
        }

        public bool RemoveUsuario(string matricula)
        {
            bool achou = false;
            int aux = 0;
            while ((achou == false) && (aux < posicao))
            {
                if (usuarios[aux].Matricula == matricula)
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
                    usuarios[i] = usuarios[i + 1];
                }
                posicao--;
            }
            return achou;
        }

        public int PesquisaMatricula(string matricula)
        {        
            for (var cont = 0; cont < posicao; cont++)
            {
                if (usuarios[cont].Matricula == matricula)
                {
                    Console.WriteLine($"Usuário encontrado");
                    return cont;
                }
            } 
            return -1;
        }
    }
}

