using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoPOO
{
    public class Usuario : Pessoa
    {
        private string matricula;
        private string curso;
        

        public Usuario(string nome, Endereco endereco, string matricula, string curso):base(nome, endereco) { 
            this.nome = nome;
            this.endereco = endereco;   
            this.matricula = matricula;
            this.curso = curso;
        }

        public override string ToString()
        {
            string res = "Nome: " + nome + "\nEndereco: " + endereco.ToString() + "Matricula: " + matricula + "- Curso: " + curso + "\n";
            return res;
        }

        public string Matricula { 
            get { return matricula; }
            set { matricula = value; }
        }

        public string Curso{
            get { return curso; } 
            set {  curso = value; }
        }
    }
}
