using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Caelum.Leilao;

namespace Caelum.Leilao.Tests
{
    [TestFixture]
    public class LeilaoTest
    {
        [Test]
        public void DeveReceberUmLance()
        {
            Leilao leilao = new Leilao("Macbook Pro 15");
            Assert.AreEqual(0, leilao.Lances.Count);

            var usuario = new Usuario("Steve Jobs");
            leilao.Propoe(new Lance(usuario, 2000));

            Assert.AreEqual(1, leilao.Lances.Count);
            Assert.AreEqual(2000, leilao.Lances[0].Valor, 0.00001);

        }

        [Test]
        public void DeveReceberVariosLances()
        {
            Leilao leilao = new Leilao("Macbook Pro 15");
            var steve = new Usuario("Steve Jobs");
            var wozniak = new Usuario("Steve Wozniak");

            leilao.Propoe(new Lance(steve, 2000));
            leilao.Propoe(new Lance(wozniak, 3000));

            Assert.AreEqual(2, leilao.Lances.Count);
            Assert.AreEqual(2000, leilao.Lances[0].Valor, 0.00001);
            Assert.AreEqual(3000, leilao.Lances[1].Valor, 0.00001);
                        
        }

        [Test]
        public void NaoDeveAceitarDoisLancesSeguidosDoMesmoUsuario()
        {
            Leilao leilao = new Leilao("Ford Fox 2018");
            var gustavo = new Usuario("Gustavo");

            leilao.Propoe(new Lance(gustavo, 50000.0));
            leilao.Propoe(new Lance(gustavo, 60000.0));

            Assert.AreEqual(1, leilao.Lances.Count);
            Assert.AreEqual(50000, leilao.Lances[0].Valor, 0.00001);
        }

        [Test]
        public void NaoDeveAceitarMaisDoQue5LancesDeUmMesmoUsuario()
        {
            Leilao leilao = new Leilao("Playstation 4");
            var erick = new Usuario("Erick");
            var emilly = new Usuario("Emilly");

            leilao.Propoe(new Lance(erick, 500.0));
            leilao.Propoe(new Lance(emilly, 1000.0));

            leilao.Propoe(new Lance(erick, 2000.0));
            leilao.Propoe(new Lance(emilly, 2500.0));

            leilao.Propoe(new Lance(erick, 3000.0));
            leilao.Propoe(new Lance(emilly, 3500.0));

            leilao.Propoe(new Lance(erick, 4000.0));
            leilao.Propoe(new Lance(emilly, 4500.0));

            leilao.Propoe(new Lance(erick, 5000.0));
            leilao.Propoe(new Lance(emilly, 5500.0));

            //Ignorar esse lance
            leilao.Propoe(new Lance(erick, 6000.0));

            Assert.AreEqual(10, leilao.Lances.Count);
            int ultimo = leilao.Lances.Count - 1;
            Lance ultimoLance = leilao.Lances[ultimo];
            Assert.AreEqual(5500, ultimoLance.Valor, 0.00001);


        }

    }
}
