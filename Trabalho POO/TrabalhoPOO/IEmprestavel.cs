using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoPOO
{
    public interface IEmprestavel
    {
        bool disponivel();
        bool emprestado();
        bool bloqueado();
        bool atrasado();
        string ToString();
    }
}
