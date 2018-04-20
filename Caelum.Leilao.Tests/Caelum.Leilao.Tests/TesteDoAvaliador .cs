﻿using System;
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

        public void DeveEntenderLeilaoComApenasUmLance()
        {
            Usuario joao = new Usuario("Joao");
            Leilao leilao = new Leilao("iPhone X");

            leilao.Propoe(new Lance(joao, 5000.0));

            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            Assert.AreEqual(5000.0, leiloeiro.MaiorLance, 0.00001);
            Assert.AreEqual(5000.0, leiloeiro.MenorLance, 0.00001);
        }

        [Test]
        public void DeveEncontrarOsTresMaioresLances()
        {
            Usuario joao = new Usuario("João");
            Usuario maria = new Usuario("Maria");

            Leilao leilao = new Leilao("Samsung Galax S9");

            leilao.Propoe(new Lance(joao, 4000.0));
            leilao.Propoe(new Lance(maria, 4500.0));
            leilao.Propoe(new Lance(joao, 5000.0));
            leilao.Propoe(new Lance(maria, 6000.0));

            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            IList<Lance> maiores = leiloeiro.TresMaiores;

            Assert.AreEqual(3, maiores.Count);
            Assert.AreEqual(6000, maiores[0].Valor, 0.00001);
            Assert.AreEqual(5000, maiores[1].Valor, 0.00001);
            Assert.AreEqual(4500, maiores[2].Valor, 0.00001);
        }

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
