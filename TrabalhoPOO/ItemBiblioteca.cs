using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoPOO
{
    public abstract class ItemBiblioteca
    {
        private int identificacao;
        private string titulo;
        private string situacao;

        public ItemBiblioteca(int identificacao, string titulo, string situacao)
        {
            this.identificacao = identificacao;
            this.titulo = titulo;
            this.situacao = situacao;
        }

        public int Identificacao
        {
            get { return identificacao; }
            set { this.identificacao = value; }
        }

        public string Titulo
        {
            get { return titulo; }
            set { this.titulo = value; }
        }

        public string Situacao
        {
            get { return situacao; }
            set { this.situacao = value; }
        }

        public override string ToString()
        {
            string res = "Identificação: " + identificacao + "\nTitulo: " + titulo + "\nSituação: " + situacao;
            return res;
        }
    }
}
