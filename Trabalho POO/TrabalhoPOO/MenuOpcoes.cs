using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoPOO
{
    public class MenuOpcoes
    {
        private CadEmprestimos todosEmprestimos;
        private Acervo acervo;
        private CadUsuarios cadUsuarios;
        private EntradaDados entradaDados;
        private PersistenciaDados persistenciaDados;

        public MenuOpcoes()
        {
            todosEmprestimos = new CadEmprestimos();
            acervo = new Acervo();
            cadUsuarios = new CadUsuarios();
            entradaDados = new EntradaDados();
            persistenciaDados = new PersistenciaDados();

            this.Menu();
        }
        private void OpcoesMenu()
        {
            Console.WriteLine("1 - Cadastrar Usuario");
            Console.WriteLine("2 - Cadastrar Item");
            Console.WriteLine("3 - Emprestar");
            Console.WriteLine("4 - Devolução");
            Console.WriteLine("5 - Listar Todos Usuários");
            Console.WriteLine("6 - Listar Todos Livros");
            Console.WriteLine("7 - Listar Todos Periódicos");
            Console.WriteLine("8 - Listar Todos DVDs");
            Console.WriteLine("9 - Listar Todos Emprestimos");
            Console.WriteLine("10 - Excluir Usuário");
            Console.WriteLine("11 - Excluir Item");
            Console.WriteLine("0 - Sair");
        }

        private void Menu()
        {  
            Usuario usuario;
            Endereco enderecoUsuario;
            ItemBiblioteca item;
            CadUsuarios listaUsuarios = new CadUsuarios();
            Emprestimo emprestimo = new Emprestimo();
            Endereco endereco = new Endereco();

            int opc = 0;
            int codigo = 0;

            string autor, editora, titulo, situacao, periodicidade, assunto;
            int paginas, identificacao, num, ano, duracao, id;

            persistenciaDados.LeituraDados("usuarios.txt", cadUsuarios, endereco);
            persistenciaDados.LeituraDadosItens("acervo.txt", acervo);

            OpcoesMenu();
            opc = entradaDados.LeInteiro("Informe a sua opção: ", 0, 9);
            while (opc != 0)
            {
                switch (opc)
                {
                    case 0: break;
                    case 1:
                        Console.Clear();
                        Console.WriteLine("######## Cadastro de Usuário ########");
                        string rua = entradaDados.LeString("Rua: ");
                        int numero = entradaDados.LeInteiro("Número: ");
                        string complemento = entradaDados.LeString("Complemento: ");
                        string bairro = entradaDados.LeString("Bairro: ");
                        string cidade = entradaDados.LeString("Cidade: ");
                        string uf = entradaDados.LeString("UF: ");
                        string cep = entradaDados.LeString("CEP: ");
                        enderecoUsuario = new Endereco(rua, numero, complemento, bairro, cidade, uf, cep);    

                        string nome = entradaDados.LeString("Nome: ");
                        string matricula = entradaDados.LeString("Nº de Matricula: ");
                        string curso = entradaDados.LeString("Curso: ");

                        usuario = new Usuario(nome, enderecoUsuario, matricula, curso);
                        cadUsuarios.Insere(usuario);
                        listaUsuarios.Insere(usuario);

                        persistenciaDados.EscritaDados(cadUsuarios, "usuarios.txt");
                        Console.Clear();
                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("######## Cadastro de Item ########");
                        Console.WriteLine("1 - Cadastrar Livro");
                        Console.WriteLine("2 - Cadastrar Periodico");
                        Console.WriteLine("3 - Cadastrar DVD");
                        Console.WriteLine("0 - Voltar");
 
                        opc = entradaDados.LeInteiro("\nInforme a sua opção: ", 1, 3);

                        switch (opc)
                        {                 
                            case 1:
                                Console.Clear();
                                Console.WriteLine("######## Cadastro de Livro ########");
                                autor = entradaDados.LeString("Autor: ");
                                editora = entradaDados.LeString("Editora: ");
                                paginas = entradaDados.LeInteiro("Páginas: ");
                                identificacao = entradaDados.LeInteiro("Identificação: ");
                                titulo = entradaDados.LeString("Titulo: ");
                                situacao = entradaDados.LeString("Situacao: ");

                                Livro livro = new Livro(autor, editora, paginas, identificacao, titulo, situacao);
                                acervo.Insere(livro);
                                persistenciaDados.EscritaDadosItens(acervo, "acervo.txt");
                                break;

                            case 2:
                                Console.Clear();
                                Console.WriteLine("######## Cadastro de Periodico ########");
                                periodicidade = entradaDados.LeString("Periodicidade: ");
                                num = entradaDados.LeInteiro("Número: ");
                                ano = entradaDados.LeInteiro("Ano: ");
                                identificacao = entradaDados.LeInteiro("Identificação: ");
                                titulo = entradaDados.LeString("Titulo: ");
                                situacao = entradaDados.LeString("Situacao: ");

                                Periodico periodico = new Periodico(periodicidade, num, ano, identificacao, titulo, situacao);
                                acervo.Insere(periodico);
                                persistenciaDados.EscritaDadosItens(acervo, "acervo.txt");
                                break;


                            case 3:
                                Console.Clear();
                                Console.WriteLine("######## Cadastro de DVD ########");
                                assunto = entradaDados.LeString("Assunto: ");
                                duracao = entradaDados.LeInteiro("Duração: ");
                                identificacao = entradaDados.LeInteiro("Identificação: ");
                                titulo = entradaDados.LeString("Titulo: ");
                                situacao = entradaDados.LeString("Situacao: ");

                                Dvd dvd = new Dvd(assunto, duracao, identificacao, titulo, situacao);
                                acervo.Insere(dvd);
                                persistenciaDados.EscritaDadosItens(acervo, "acervo.txt");
                                break;

                        }
                        Console.Clear();
                        break;

                    case 3:
                        Console.Clear();
                        Console.WriteLine("######## Emprestimo ########");
     
                        string matri = entradaDados.LeString("Digite o seu número de matricula: ");
                        id = entradaDados.LeInteiro("Digite o codigo do item que deseja retirar: ");

                        //Pesquisa pelo matricula do usuario
                        int resultadoPesquisaMatri = cadUsuarios.PesquisaMatricula(matri);
                        if(resultadoPesquisaMatri >= 0)
                        {
                            Console.Clear();
                            //Pega o usuario pelo index
                            Usuario user = cadUsuarios.GetUsuario(resultadoPesquisaMatri);

                            //Pesquisa pelo identificacao do item e pesquisa
                            int resultadoPesquisaId = acervo.PesquisaId(id);
                            ItemBiblioteca itemDesejado = acervo.GetItemAcervo(resultadoPesquisaId);

                            if (itemDesejado.Situacao == "disponivel")
                            {
                                emprestimo = new Emprestimo();   

                                if(itemDesejado is Livro)
                                {
                                    emprestimo.Emprestar(user, itemDesejado, 7);
                                    Console.WriteLine($"Item {itemDesejado.Titulo} emprestado, devolução em 7 dias\nCodigo: {emprestimo.Identificacao}");
                                }

                                if (itemDesejado is Periodico)
                                {
                                    emprestimo.Emprestar(user, itemDesejado, 4);
                                    Console.WriteLine($"Item {itemDesejado.Titulo} emprestado, devolução em 4 dias\nCodigo: {emprestimo.Identificacao}");
                                }

                                if (itemDesejado is Dvd)
                                {
                                    emprestimo.Emprestar(user, itemDesejado, 2);
                                    Console.WriteLine($"Item {itemDesejado.Titulo} emprestado, devolução em 2 dias\nCodigo: {emprestimo.Identificacao}");
                                }

                                todosEmprestimos.Insere(emprestimo);
                            }
                            else
                            {
                                Console.WriteLine($"Item não disponivel - Situação: {itemDesejado.Situacao}");
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine($"Matricula NÃO encontrada");
                        }
                        persistenciaDados.EscritaDadosItens(acervo, "acervo.txt");
                        Console.Write("\n\nPressione ENTER para continuar... ");
                        Console.ReadLine();
                        Console.Clear();

                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("######## Devolução ########");
   
                        id = entradaDados.LeInteiro("Digite a identificação do emprestimo que deseja devolver: ");
                        int indexEmprestimo = todosEmprestimos.PesquisaId(id);

                        if(indexEmprestimo >= 0)
                        {
                            emprestimo.Retorna();
                            todosEmprestimos.RemoveEmprestimo(id);
                        }
                        else
                        {
                            Console.Clear();
                            Console.Write("Emprestimo não encontrado\n\nst");
                            Console.Write("Pressione ENTER para continuar... ");
                            Console.ReadLine();
                            Console.Clear();
                        }

                        persistenciaDados.EscritaDadosItens(acervo, "acervo.txt");
                        break;

                    case 5:
                        Console.Clear();
                        Console.WriteLine("######## TODOS USUÁRIOS ########\n");
                        for (int i = 0; i <= cadUsuarios.Tamanho(); i++)
                        {
                            Console.WriteLine($"{cadUsuarios.GetUsuario(i)}");
                        }
                        Console.Write("Pressione ENTER para continuar... ");
                        Console.ReadLine();                
                        Console.Clear();
                        break;

                    case 6:
                        Console.Clear();
                        Console.WriteLine("######## TODOS LIVROS ########\n");
                        for (int i = 0; i <= acervo.Tamanho(); i++)
                        {
                            if(acervo.GetItemAcervo(i) is Livro)
                            {
                                Console.WriteLine($"{acervo.GetItemAcervo(i)}\n");
                            }
                        }
                        Console.Write("\nPressione ENTER para continuar... ");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case 7:
                        Console.Clear();
                        Console.WriteLine("######## TODOS PERIODICOS ########\n");
                        for (int i = 0; i <= acervo.Tamanho(); i++)
                        {
                            if (acervo.GetItemAcervo(i) is Periodico)
                            {
                                Console.WriteLine($"{acervo.GetItemAcervo(i)}\n");
                            }
                        }
                        Console.Write("\nPressione ENTER para continuar... ");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case 8:
                        Console.Clear();
                        Console.WriteLine("######## TODOS DVDs ########\n");
                        for (int i = 0; i <= acervo.Tamanho(); i++)
                        {
                            if (acervo.GetItemAcervo(i) is Dvd)
                            {
                                Console.WriteLine($"{acervo.GetItemAcervo(i)}\n");
                            }
                        }
                        Console.Write("\nPressione ENTER para continuar... ");
                        Console.ReadLine();
                        Console.Clear();
                        break;


                    case 9:
                        Console.Clear();
                        Console.WriteLine("########## TODOS EMPRESTIMOS ATE AGORA ##########\n");
                        for (int i = 0; i <= todosEmprestimos.Tamanho(); i++)
                        {
                            Console.WriteLine($"{todosEmprestimos.GetEmprestimo(i)}\n");

                        }
                        //todosEmprestimos.Atrasos();
                        Console.Write("Pressione ENTER para continuar... ");
                        Console.ReadLine();
                        Console.Clear();
                        break;


                    case 10:
                        listaUsuarios.RemoveUsuario("55988312");
                        break;

                    case 11:
                        acervo.RemoveItemAcervo(2);
                        break;

                    default:
                        Console.WriteLine("Opção Inválida");
                        break;
                }

                OpcoesMenu();
                opc = entradaDados.LeInteiro("Informe a sua opção: ", 0, 9);
            }
        }
    }
}
