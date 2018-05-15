using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caelum.Leilao;
using NUnit.Framework;

namespace Caelum.Leilao.Tests
{
    //[TestFixture]
    public class AnoBisssestoTest
    {
        //[Test]
        public void VerificarAnoBissexto()
        {
            AnoBissexto novoAno = new AnoBissexto();
            novoAno.EhAnoBissexto(2018);

            Assert.AreEqual(2018, novoAno.Ano);

        }
        
    }
}
