using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoPOO
{
    public class PersistenciaDados
    {
        public PersistenciaDados() { }
        public void EscritaDados(CadUsuarios cadastro, string arquivo)
        {
            Usuario usuario = null;
            string linha;
            try
            {
                using (StreamWriter sw = new StreamWriter(arquivo))
                    for (int i = 0; i < cadastro.Tamanho(); i++) // Laço para percorrer todos os dados cadastrados
                    {
                        usuario = cadastro.GetUsuario(i); //Obtém cada um dos itens cadastrados
                        linha = usuario.Nome + ";" + usuario.Endereco.Rua + ";" + usuario.Endereco.Numero + ";" + usuario.Endereco.Complemento + ";" + 
                            usuario.Endereco.Bairro + ";" + usuario.Endereco.Cidade + ";" + usuario.Endereco.Uf + ";" + usuario.Endereco.Cep + ";" + usuario.Matricula + ";" + usuario.Curso;
                        sw.WriteLine(linha); //grava a string linha no arquivo
                    }
            }
            catch (Exception ex)
            {

            }
        }

        public bool ExisteArquivo(string arquivo) //retorna true ou false se o arq. existe ou não
        {
            return File.Exists(arquivo); //Testa a existência do arquivo
        }
        public void LeituraDados(string arquivo, CadUsuarios cadastro, Endereco endereco)
        {
            string linha = "";
            string auxPreco = "";
            string nome = "";
            string matricula = "";
            string curso = "";
            string rua = "";
            int numero = 0;
            string complemento = "";
            string bairro = "";
            string cidade = "";
            string uf = "";
            string cep = "";

            Usuario usuario = null;
            if (ExisteArquivo(arquivo))
            {
                try
                {
                    StreamReader sr = new StreamReader(arquivo); //Cria o objeto StreamReader para ler uma linha do arquivo

                    char[] delimitador = { ';' }; //Define o delimitador dos dados

                    while ((linha = sr.ReadLine()) != null) //Lê uma linha do arquivo e atribui à string linha
                    {
                        string[] linhaSplit = linha.Split(delimitador);
                        nome = linhaSplit[0]; 
                        rua = linhaSplit[1]; 
                        numero = int.Parse(linhaSplit[2]); 
                        complemento = linhaSplit[3]; 
                        bairro = linhaSplit[4]; 
                        cidade = linhaSplit[5]; 
                        uf = linhaSplit[6]; 
                        cep = linhaSplit[7]; 
                        matricula = linhaSplit[8]; 
                        curso = linhaSplit[9];

                        endereco = new Endereco(rua, numero, complemento, bairro, cidade, uf, cep);
                        usuario = new Usuario(nome, endereco, matricula, curso);

                        cadastro.Insere(usuario);

                    }
                    sr.Close();
                }
                catch (Exception ex)
                {
    
                }      
            }
        }

        //DADOS ITENS///////////////////////////////////////////////
        public void EscritaDadosItens(Acervo acervo, string arquivo)
        {
            ItemBiblioteca item = null;
            Livro livro = null;
            Periodico periodico = null;
            Dvd dvd = null; 

            string linha;
            try
            {
                using (StreamWriter sw = new StreamWriter(arquivo))
                    for (int i = 0; i < acervo.Tamanho(); i++) // Laço para percorrer todos os dados cadastrados
                    {
                        item = acervo.GetItemAcervo(i); //Obtém cada um dos itens cadastrados

                        if (item is Livro)
                        {  
                            livro = (Livro)item;
                            linha = "livro" + ";" + livro.Autor + ";" + livro.Editora + ";" + livro.Paginas + ";" + livro.Identificacao + ";" + livro.Titulo + ";" + livro.Situacao;
                            sw.WriteLine(linha); 
                        }

                        if (item is Periodico)
                        {
                            periodico = (Periodico)item;
                            linha = "periodico" + ";" + periodico.Periodicidade + ";" + periodico.Numero + ";" + periodico.Ano + ";" + periodico.Identificacao + ";" + periodico.Titulo + ";" + periodico.Situacao;
                            sw.WriteLine(linha);
                        }

                        if (item is Dvd)
                        {
                            dvd = (Dvd)item;
                            linha = "dvd" + ";" + dvd.Assunto + ";" + dvd.Duracao + ";" + dvd.Identificacao + ";" + dvd.Titulo + ";" + dvd.Situacao;
                            sw.WriteLine(linha);
                        }
                    }
            }
            catch (Exception ex)
            {

            }
        }

        public bool ExisteArquivoItens(string arquivo)
        {
            return File.Exists(arquivo); 
        }
        public void LeituraDadosItens(string arquivo, Acervo acervo)
        {
            string linha = "";
            string auxPreco = "";

            string tipo = "";
            string autor = "";
            string editora = "";
            string titulo = "";
            string situacao = "";
            string periodicidade = "";
            string assunto = "";
            int numero = 0;
            int ano = 0;
            int paginas = 0;
            int identificacao = 0;
            int duracao = 0;

            Livro livro = null;
            Periodico periodico = null;
            Dvd dvd = null;


            Usuario usuario = null;
            if (ExisteArquivoItens(arquivo))
            {
                try
                {
                    StreamReader sr = new StreamReader(arquivo); //Cria o objeto StreamReader para ler uma linha do arquivo

                    char[] delimitador = { ';' }; //Define o delimitador dos dados

                    while ((linha = sr.ReadLine()) != null) //Lê uma linha do arquivo e atribui à string linha
                    {
                        string[] linhaSplit = linha.Split(delimitador);
                        tipo = linhaSplit[0];

                        if (tipo == "livro")
                        {
                            autor = linhaSplit[1];
                            editora = linhaSplit[2];
                            paginas = int.Parse(linhaSplit[3]);
                            identificacao = int.Parse(linhaSplit[4]);
                            titulo = linhaSplit[5];
                            situacao = linhaSplit[6];

                            livro = new Livro(autor, editora, paginas, identificacao, titulo, situacao);
                            acervo.Insere(livro);
                        }

                        if (tipo == "periodico")
                        {
                            periodicidade = linhaSplit[1];
                            numero = int.Parse(linhaSplit[2]);
                            ano = int.Parse(linhaSplit[3]);
                            identificacao = int.Parse(linhaSplit[4]);
                            titulo = linhaSplit[5];
                            situacao = linhaSplit[6];

                            periodico = new Periodico(periodicidade, numero, ano, identificacao, titulo, situacao);
                            acervo.Insere(periodico);
                        }

                        if (tipo == "dvd")
                        {
                            assunto = linhaSplit[1];
                            duracao = int.Parse(linhaSplit[2]);
                            identificacao = int.Parse(linhaSplit[3]);
                            titulo = linhaSplit[4];
                            situacao = linhaSplit[5];

                            dvd = new Dvd(assunto, duracao, identificacao, titulo, situacao);
                            acervo.Insere(dvd);
                        }
                    }
                    sr.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro!\n" + ex.Message);
                }
            }
        }
    }
}
