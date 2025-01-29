using JornadaMilhasV1.Modelos;

namespace JornadaMilhas.Test;
    public class OfertaViagemDesconto
    {
        [Fact]
        public void RetornaPrecoAtualizadoQuandoAplicadoDesconto()
        {
            //arrange
            Rota rota = new Rota("Origem Teste","Destino Teste");
            Periodo periodo = new Periodo(new DateTime(2024,2,1), new DateTime(2024, 2, 10));
            double precoOriginal = 100.0;
            double desconto = 20.0;
            double precoComDesconto = precoOriginal - desconto;
            OfertaViagem oferta = new OfertaViagem(rota, periodo, precoOriginal);

            //action
            oferta.Desconto = desconto; 
            //assert
            Assert.Equal(precoComDesconto, oferta.Preco);
        }

        [Fact]
        public void RetornaDescontoMaximoQuandoValorDescontoMaiorQuePreco()
        {
            //arrange
            Rota rota = new Rota("Origem Teste","Destino Teste");
            Periodo periodo = new Periodo(new DateTime(2024,2,1), new DateTime(2024, 2, 10));
            double precoOriginal = 100.0;
            double desconto = 120.0;
            double precoComDesconto = 30.0 ;
            OfertaViagem oferta = new OfertaViagem(rota, periodo, precoOriginal);

            //action
            oferta.Desconto = desconto; 
            //assert
            Assert.Equal(precoComDesconto, oferta.Preco, 0.001);
        }
    }