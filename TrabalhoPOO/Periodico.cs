using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoPOO
{
    public class Periodico : ItemBiblioteca, IEmprestavel
    {
        private string periodicidade;
        private int numero;
        private int ano;

        public Periodico(string periodicidade, int numero, int ano, int identificacao, string titulo, string situacao):base(identificacao, titulo, situacao)    
        {
            this.periodicidade = periodicidade;
            this.numero = numero;
            this.ano = ano;
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
            string res = "Identificação: " + Identificacao + "\nTitulo: " + Titulo + "\nSituação: " + Situacao + "\nPeriodicidade: " + periodicidade + "\nNumero: " + numero + "\nAno: " + ano;
            return res;
        }

        public string Periodicidade
        {
            get { return periodicidade; }
            set { this.periodicidade = value; }
        }

        public int Numero
        {
            get { return numero; }
            set { this.numero = value; }
        }
        public int Ano
        {
            get { return ano; }
            set { this.ano = value; }
        }
    }
}
