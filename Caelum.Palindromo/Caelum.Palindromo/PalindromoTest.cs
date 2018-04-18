using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Caelum.Palindromo
{
    [TestFixture]
    public class PalindromoTest
    {
        [Test]
        //Step 1
        public void DeveIdentificarPalindromoEFiltrarCaracteresInvalidos()
        {
            Palindromo p = new Palindromo();

            bool resultado = p.EhPalindromo(
                "Socorram-me subi no onibus em Marrocos");
            Assert.IsTrue(resultado);
        }

        [Test]
        //Step 2
        public void DeveIdentificarPalindromo()
        {
            Palindromo p = new Palindromo();

            bool resultado = p.EhPalindromo(
                "Anotaram a data da maratona");
            Assert.IsTrue(resultado);
        }

        [Test]
        //Step 3
        public void DeveIdentificarSeNaoEhPalindromo()
        {
            Palindromo p = new Palindromo();

            bool resultado = p.EhPalindromo(
                "E preciso amar as pessoas como se nao houvesse amanha");
            Assert.IsFalse(resultado);
        }

    }
}
