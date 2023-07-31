using ByteBankIO;
using System.Text;

partial class Program
{
    static void CriarArquivo()
    {
        var caminhoNovoArquivo = "contasExportadas.csv";

        using (var fluxoDoArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
        {
            var contaComoString = "456,7895,4785.40,Gustavo Santos";
            var encoding = Encoding.UTF8;

            var bytes = encoding.GetBytes(contaComoString);

            fluxoDoArquivo.Write(bytes, 0, bytes.Length);
        }
    }

    static void CriarArquivoComWriter()
    {
        var caminhoNovoArquivo = "contasExportadas.csv";

        using (var fluxoDoArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
        {
            using (var escritor = new StreamWriter(fluxoDoArquivo))
            {
                escritor.Write("456,7895,44785.40,Rafael Santos");
            }
        }
    }

    static void TestaEscrita()
    {
        var caminhoNovoArquivo = "teste.txt";

        using (var fluxoDoArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
        {
            {
                using (var escritor = new StreamWriter(fluxoDoArquivo))
                {
                    for (int i = 0; i < 1000; i++)
                    {
                        escritor.WriteLine($"Linha {i}");
                        escritor.Flush();
                        Console.WriteLine($"linha {i} foi escrita no arquivo. Tecle enter...");
                        Console.ReadLine();
                    }

                }
            }
        }
    }
}

