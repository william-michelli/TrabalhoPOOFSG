using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoPOO
{
    public class Emprestimo
    {
        private int identificacao; // identificação do empréstimo (código do empréstimo)
        private Usuario usuario; // Usuário da biblioteca que realizou o empréstimo
        private ItemBiblioteca item; //Item da biblioteca que foi emprestado
        private DateTime data_emprestimo;
        private DateTime data_devolucao;

        public Emprestimo(){ }

        public void Emprestar(Usuario usuario, ItemBiblioteca item, int prazo)
        {
            Random rnd = new Random();
            int random = rnd.Next(111, 999);


            this.identificacao = random;
            this.usuario = usuario;
            this.item = item;
            this.data_emprestimo = DateTime.Now;
            this.data_devolucao = DateTime.Now.AddDays(prazo);

            item.Situacao = "emprestado";
        }
        public void Retorna()
        {
            item.Situacao = "disponivel";
            Console.WriteLine($"\n\nDevolução do item realizada.");

            Console.Write("\n\nPressione ENTER para continuar... ");
            Console.ReadLine();
            Console.Clear();  
        }

        public int Identificacao
        {
            get { return identificacao; }
            set { identificacao = value; }
        }

        public ItemBiblioteca Item
        {
            get { return item; }
            set { item = value; }
        }

        public DateTime Data_Devolucao
        {
            get { return data_devolucao; }
            set { data_devolucao = value; }
        }


        public override string ToString()
        {
            string res = "Identificação Emprestimo: " + identificacao + "\nUsuario: " + usuario.Nome + "\nItem: " + item.Titulo + "\nData Emprestimo: " + data_emprestimo + "\nData Devolucao: " + data_devolucao;
            return res;
        }
    }

  

}
