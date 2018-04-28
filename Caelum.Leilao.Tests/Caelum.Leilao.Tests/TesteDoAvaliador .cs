using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caelum.Leilao;
using NUnit.Framework;

namespace Caelum.Leilao.Tests
{
    [TestFixture]
    class TesteDoAvaliador
    {
        [Test]
        public  void DeveEntenderLancesEmOrdemCrescente()
        {
            // cenario 1: 3 lances em ordem crescente
            Usuario joao = new Usuario("Joao");
            Usuario jose = new Usuario("José");
            Usuario maria = new Usuario("Maria");

            Leilao leilao = new Leilao("Playstation 4 Novo");


            leilao.Propoe(new Lance(maria, 250.0));
            leilao.Propoe(new Lance(joao, 300.0));
            leilao.Propoe(new Lance(jose, 400.0));
            

            // executando a acao
            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            // comparando a saida com o esperado
            Assert.AreEqual(400, leiloeiro.MaiorLance);
            Assert.AreEqual(250, leiloeiro.MenorLance);
        }

        [Test]

        // cenario 2: 3 lances em ordem crescente
        public void DeveEntenderLeilaoComApenasUmLance()
        {
            Usuario joao = new Usuario("Joao");
            Leilao leilao = new Leilao("iPhone X");

            leilao.Propoe(new Lance(joao, 5000.0));

            // executando a acao
            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            // comparando a saida com o esperado
            Assert.AreEqual(5000.0, leiloeiro.MaiorLance, 0.00001);
            Assert.AreEqual(5000.0, leiloeiro.MenorLance, 0.00001);
        }

        [Test]

        // cenario 3: 3 lances em ordem crescente
        public void DeveEncontrarOsTresMaioresLances()
        {
            Usuario joao = new Usuario("João");
            Usuario maria = new Usuario("Maria");

            Leilao leilao = new Leilao("Samsung Galax S9");

            leilao.Propoe(new Lance(joao, 4000.0));
            leilao.Propoe(new Lance(maria, 4500.0));
            leilao.Propoe(new Lance(joao, 5000.0));
            leilao.Propoe(new Lance(maria, 6000.0));

            // executando a acao
            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            IList<Lance> maiores = leiloeiro.TresMaiores;

            // comparando a saida com o esperado
            Assert.AreEqual(3, maiores.Count);
            Assert.AreEqual(6000, maiores[0].Valor, 0.00001);
            Assert.AreEqual(5000, maiores[1].Valor, 0.00001);
            Assert.AreEqual(4500, maiores[2].Valor, 0.00001);
        }

        //[Test]
        //// cenario 4: 3 lances em ordem crescente
        //public void DeveEntenderLeilaoComLancesEmOrdemRandomica()
        //{
        //    Usuario joao = new Usuario("Joao");
        //    Usuario maria = new Usuario("Joao");

        //    Leilao leilao = new Leilao("SmartTV Samsung");

        //    leilao.Propoe(new Lance(joao, 2500.0));
        //    leilao.Propoe(new Lance(maria, 3000.0));
        //    leilao.Propoe(new Lance(joao, 3500.0));
        //    leilao.Propoe(new Lance(maria, 4000.0));
            
        //    Avaliador leiloeiro = new Avaliador();
        //    leiloeiro.Avalia(leilao);

        //    Assert.AreEqual(4000, leiloeiro.MaiorLance, 0.00001);
        //    Assert.AreEqual(2500, leiloeiro.MenorLance, 0.00001);
        //}

        [Test]
        // cenario 5: 3 lances em ordem crescente
        public void DeveEntenderLeilaoComLancesEmOrdemDecrescente()
        {
            Usuario erick = new Usuario("Erick");
            Usuario marciele = new Usuario("Marciele");
            Leilao leilao = new Leilao ("Plastation 4");

            leilao.Propoe(new Lance(erick, 400.0));
            leilao.Propoe(new Lance(marciele, 300.0));
            leilao.Propoe(new Lance(erick, 200.0));
            leilao.Propoe(new Lance(marciele, 100.0));

            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            Assert.AreEqual(400, leiloeiro.MaiorLance, 0.00001);
            Assert.AreEqual(100, leiloeiro.MenorLance, 0.00001);
        }

        [Test]
        //Cenario 6
        public void DeveDevolverTodosLancesCasoNaoHajaNoMinimo3()
        {
            Usuario joao = new Usuario("Joao");
            Usuario maria = new Usuario("maria");
            Leilao leilao = new Leilao("PS4");

            leilao.Propoe(new Lance(joao, 100.0));
            leilao.Propoe(new Lance(maria, 200.0));

            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            Assert.AreEqual(100, leiloeiro.MenorLance, 0.00001);
            Assert.AreEqual(200, leiloeiro.MaiorLance, 0.00001);
        }



        //[Test]
        ////Cenario 7
        //public void DeveDevolverListaVaziaCasoNaoHajaLances()
        //{
        //    Leilao leilao = new Leilao("PS4");

        //    Avaliador leiloeiro = new Avaliador();
        //    leiloeiro.Avalia(leilao);

        //    var maiores = leiloeiro.TresMaiores;

        //    Assert.AreEqual(0, maiores.Count);

        //}


        //[Test]
        //public void DeveCalcularAMedia()
        //{
        //    // cenario 2: 3 lances em ordem crescente
        //    Usuario joao = new Usuario("Joao");
        //    Usuario jose = new Usuario("José");
        //    Usuario maria = new Usuario("Maria");

        //    Leilao leilao = new Leilao("Playstation  Novo");

        //    leilao.Propoe(new Lance(maria, 300.0));
        //    leilao.Propoe(new Lance(joao, 400.0));
        //    leilao.Propoe(new Lance(jose, 500.0));

        //    // executando a acao
        //    Avaliador leiloeiro = new Avaliador();
        //    leiloeiro.Avalia(leilao);

        //    // comparando a saida com o esperado
        //    Assert.AreEqual(400, leiloeiro.Media, 0.0001);
        //}

        //[Test]
        //public void ValorDaDiferenca()
        //{
        //    // cenario 3: 3 lances em ordem crescente
        //    Usuario joao = new Usuario("Joao");
        //    Usuario jose = new Usuario("José");
        //    Usuario maria = new Usuario("Maria");

        //    Leilao leilao = new Leilao("Playstation 4 Novo");

        //    leilao.Propoe(new Lance(maria, 300.0));
        //    leilao.Propoe(new Lance(joao, 400.0));
        //    leilao.Propoe(new Lance(jose, 500.0));

        //    // executando a acao
        //    Avaliador leiloeiro = new Avaliador();
        //    leiloeiro.Avalia(leilao);

        //    // comparando a saida com o esperado
        //    double valorDiferenca = 500.0 - 300.00;

        //    Assert.AreEqual(valorDiferenca, leiloeiro.Diferenca, 0.0001);
        //}

    }
   
    
}
