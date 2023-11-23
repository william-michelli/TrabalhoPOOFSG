using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoPOO
{
    public class Livro: ItemBiblioteca, IEmprestavel
    {
        private string autor;
        private string editora;
        private int paginas;

        public Livro(string autor, string editora, int paginas, int identificacao, string titulo, string situacao):base(identificacao, titulo, situacao)    
        {
            this.autor = autor;
            this.editora = editora;
            this.paginas = paginas;
            this.Identificacao = identificacao;
            this.Titulo = titulo;
            this.Situacao = situacao;
        }

        public bool disponivel()
        {
            return Situacao == "disponivel";
        }
        public bool emprestado()
        {
            return Situacao == "emprestado";
        }
        public bool bloqueado()
        {
            return Situacao == "bloqueado";
        }
        public bool atrasado()
        {
            return Situacao == "bloqueado"; 
        }
        public override string ToString()
        {
            string res = "Identificação: " + Identificacao + "\nTitulo: " + Titulo + "\nSituação: " + Situacao + "\nAutor: " + autor + "\nEditora: " + editora + "\nNº Páginas: " + paginas;
            return res;
        }

        public string Autor
        {
            get { return autor; }
            set { this.autor = value; }
        }

        public string Editora
        {
            get { return editora; }
            set { this.editora = value; }
        }
        public int Paginas
        {
            get { return paginas; }
            set { this.paginas = value; }
        }
       
    }
}
