using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoPOO
{
    public abstract class Pessoa
    {
        protected string nome;
        protected Endereco endereco;
        public Pessoa(string nome, Endereco endereco) {
            this.nome = nome;
            this.endereco = endereco;    
        }

        public override string ToString()
        {
            string res = "Nome: " + nome + "\nEndereco: " + endereco.ToString();
            return res;
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public Endereco Endereco { 
            get { return endereco; } 
            set {  endereco = value; }
        }   
    }
}
