using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoPOO
{
    public class Dvd : ItemBiblioteca, IEmprestavel
    {
        private string assunto;
        private int duracao;

        public Dvd(string assunto, int duracao, int identificacao, string titulo, string situacao):base(identificacao, titulo, situacao)    
        {
            this.assunto = assunto;
            this.duracao = duracao;
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
            string res = "Identificação: " + Identificacao + "\nTitulo: " + Titulo + "\nSituação: " + Situacao + "\nAssunto: " + assunto + "\nDuração: " + duracao;
            return res;
        }
        public string Assunto
        {
            get { return assunto; }
            set { this.assunto = value; }
        }

        public int Duracao
        {
            get { return duracao; }
            set { this.duracao = value; }
        }   
    }
}
