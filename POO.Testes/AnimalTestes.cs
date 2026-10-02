using System.Reflection.Metadata.Ecma335;

namespace POO.Testes;

[TestClass]
[DoNotParallelize]
public sealed class AnimalTestes
{
    private StringWriter _consoleOuput;
    private TextWriter _originalOutput;

    [TestInitialize]
    public void Setup()
    {
        _consoleOuput = new StringWriter();
        _originalOutput = Console.Out;
        Console.SetOut(_consoleOuput);
    }

    [TestCleanup]
    public void Cleanup()
    {
        Console.SetOut(_originalOutput);
        _consoleOuput.Dispose();
    }

    [TestMethod]
    public void DeveRetornarObjetoCachorro_QuandoNomeEIdadeEstaoCorretos()
    {
        string nomeEsperada = "Pipoca";
        int idadeEsperada = 9;

        var animal = new Cachorro(nomeEsperada, idadeEsperada);

        Assert.AreEqual(nomeEsperada, animal.Nome);
        Assert.AreEqual(idadeEsperada, animal.Idade);
    }

    [TestMethod]
    public void QuandoInvocadoComer_DeveEscreverMensagemPadraoNoConsole()

    {
        string nome = "Pipoca";
        var animal = new Cachorro(nome, 9);
        string mensagemEsperada = ($"{nome} está comendo!{Environment.NewLine}");

        animal.Comer();

        Assert.AreEqual(mensagemEsperada, _consoleOuput.ToString());
    }

    [TestMethod]
    public void QuandoInvocadoFazerBarulho_DaInstanciaCachorro_DeveFazerauAu()
    {
        string nome = "Pipoca";
        var animal = new Cachorro(nome, 9);
        string mensagemEsperada = ($"{nome} fez AuAu{Environment.NewLine}");

        animal.FazerBarulho();

        Assert.AreEqual(mensagemEsperada, _consoleOuput.ToString());
    }

    [TestMethod]
    public void QuandoInvocadoFazerBarulho_DaInstanciaGato_DeveFazerMiau()
    {
        string nome = "Pirulito";
        var animal = new Gato(nome, 2);
        string mensagemEsperada = ($"{nome} fez Miau{Environment.NewLine}");

        animal.FazerBarulho();

        Assert.AreEqual(mensagemEsperada, _consoleOuput.ToString());
    }

    [TestMethod]
    public void QuandoInvocadoFazerBarulho_DaInstanciaManuzica_DeveFazerMaaanuuuuu()
    {
        string nome = "Manu";
        var animal = new Manuzica(nome, 16);
        string mensagemEsperada = ($"{nome} fez Maaanuuuuu{Environment.NewLine}");

        animal.FazerBarulho();

        Assert.AreEqual(mensagemEsperada, _consoleOuput.ToString());
    }

    [TestMethod]
    public void QuandoInstanciarComNoemVazio_Sempre_DeveLancarArgumentException()
    {
        string nomeAnimal = " ";

        var exception = Assert.ThrowsExactly<ArgumentException>(() => new Cachorro(nomeAnimal, 12));
        Assert.Contains("O nome não pode estar vazio ou nulo!", exception.Message);
    }

    [TestMethod]
    public void QuandoInstanciarComNoemNulo_Sempre_DeveLancarArgumentException()
    {
        string nomeAnimal = null;

        var exception = Assert.ThrowsExactly<ArgumentException>(() => new Cachorro(nomeAnimal, 12));
        Assert.Contains("O nome não pode estar vazio ou nulo!", exception.Message);
    }

    [TestMethod]
    public void QuandoInstanciarComIdadeNegativa_Sempre_DeveLancarArgumentoutOfRangeExceptionException()
    {
        int idade = -1;

        var exception = Assert.ThrowsExactly<ArgumentException>(() => new Cachorro("Pipoca", idade));
        Assert.Contains("A idade não pode ser negativa!", exception.Message);
    }
}