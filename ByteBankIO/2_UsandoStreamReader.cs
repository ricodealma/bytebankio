using ByteBankIO;
using System.Text;

partial class Program
{
    static void UsandoStreamReader(string[] args)
    {
        var enderecoDoArquivo = "contas.txt";
        using (var fluxoDoArquivo = new FileStream(enderecoDoArquivo, FileMode.Open))
        {
            var leitor = new StreamReader(fluxoDoArquivo);

            //var linha = leitor.ReadLine();
            //var texto = leitor.ReadToEnd();
            //var numero = leitor.Read();

            while (!leitor.EndOfStream)
            {
                var linha = leitor.ReadLine();
                var contaCorrente = ConverterStringParaContaCorrente(linha);

                var msg = $"{contaCorrente.Titular.Nome} : Conta número {contaCorrente.Numero}, ag {contaCorrente.Agencia}, saldo {contaCorrente.Saldo}";
                Console.WriteLine(msg);
            }
        }
        Console.ReadLine();
    }

    static ContaCorrente ConverterStringParaContaCorrente(string linha)
    {
        var campos = linha.Split(',');

        var agencia = campos[0];
        var numero = campos[1];
        var saldo = campos[2].Replace('.', ',');
        var nomeTitular = campos[3];

        var agenciaInt = int.Parse(agencia);
        var numeroInt = int.Parse(numero);
        var saldoDouble = double.Parse(saldo);

        var titular = new Cliente();
        titular.Nome = nomeTitular;



        var resultado = new ContaCorrente(agenciaInt, numeroInt);
        resultado.Depositar(saldoDouble);
        resultado.Titular = titular;

        return resultado;
    }
}

