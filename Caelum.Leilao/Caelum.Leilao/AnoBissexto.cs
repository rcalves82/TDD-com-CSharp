using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Leilao
{
    public class AnoBissexto
    {
        public int Ano { get; private set; }
        public bool EhAnoBissexto(int ano)
        {
            bool anoAtual = false;
            anoAtual = (((ano % 4) == 0) && ((ano % 100) != 0) || ((ano % 400) == 0));
            if (ano.Equals(true))
                return true;
            else
                return false;
        }

        public void NovoAno()
        {
            this.Ano = Ano;
        }
    }
}
