using JornadaMilhasV1.Modelos;

namespace JornadaMilhas.Test
{
    public class OfertaViagemConstrutor
    {
        [Theory]
        [InlineData("", null, "2025-01-01", "2025-01-05", 0, false)]
        [InlineData("Origem Teste","Destino Teste","2025-01-01", "2025-01-05",100, true)]
        public void RetornaEhValidoDeAcordoComDadosDeEntrada(string origem, string destino, string dataIda, string dataVolta, double preco, bool validacao)
        {
            //cenário - arrange
            Rota rota = new Rota(origem, destino);
            Periodo periodo = new Periodo(DateTime.Parse(dataIda), DateTime.Parse(dataVolta));

            //ação - action
            OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

            //validação - assert
            Assert.Equal(validacao, oferta.EhValido);
        }

         [Fact]
        public void RetornaMensagemErroDeRotaOuPeriodoInvalidosQuandoRotaNula()
        {
            Rota rota = null;
            Periodo periodo = new Periodo(new DateTime(2024,2,1), new DateTime(2024, 2, 10));
            double preco = 100.0;

            OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

            Assert.Contains("A oferta de viagem não possui rota ou período válidos.", oferta.Erros.Sumario);
            Assert.False(oferta.EhValido);
        }

        [Fact]
        public void RetornaMensagemDeErroQuandoPrecoMenorQueZero()
        {
            //arrange
            Rota rota = new Rota("Origem Teste","Destino Teste");
            Periodo periodo = new Periodo(new DateTime(2024,2,1), new DateTime(2024, 2, 10));
            double preco = -100.0;

            //action
            OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

            //assert
            Assert.Contains("O preço da oferta de viagem deve ser maior que zero.",oferta.Erros.Sumario);
        }
}
}