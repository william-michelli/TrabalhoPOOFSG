using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoPOO
{
    public class Endereco
    {
        private string rua;
        private int numero;
        private string complemento;
        private string bairro;
        private string cidade;
        private string uf;
        private string cep;

        public Endereco()
        {
        
        }

        public Endereco(string rua, int numero, string complemento, string bairro, string cidade, string uf, string cep) 
        { 
            this.rua = rua;
            this.numero = numero;
            this.complemento = complemento;   
            this.bairro = bairro;
            this.cidade = cidade;      
            this.uf = uf; 
            this.cep = cep;         
        }

        public override string ToString()
        {
            string res = "Rua: " + rua + " Numero: " + numero + " Complemento: " + complemento + "\nBairro: " + bairro + " Cidade: " + cidade + " UF: " + uf + " CEP: " + cep + "\n"; 
            return res;
        }

        public string Rua
        {
            get { return rua; }
            set { this.rua = value; }
        }
        public int Numero
        {
            get { return numero; }
            set { this.numero = value; }
        }
        public string Complemento
        {
            get { return complemento; }
            set { this.complemento = value; }
        }
        public string Bairro
        {
            get { return bairro; }
            set { this.bairro = value; }
        }
        public string Cidade
        {
            get { return cidade; }
            set { this.cidade = value; }
        }
        public string Uf
        {
            get { return uf; }
            set { this.uf = value; }
        }
        public string Cep
        {
            get { return cep; }
            set { this.cep = value; }
        }
    }
}
