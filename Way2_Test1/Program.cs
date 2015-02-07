using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Way2_Test1
{
    class Program
    {
        static void Main(string[] args)
        {
            Word w = new Word();
            while (true)
            {
                Console.WriteLine("Entre com a palavra: ");
                string palavra = Console.ReadLine();

                try
                {
                    int qtyGatoMorto;
                    int posicao = w.retornaPosicao(palavra.ToUpper(), out qtyGatoMorto);

                    Console.WriteLine("Palavra: " + palavra);
                    Console.WriteLine("Posicao: " + posicao);
                    Console.WriteLine("Quantidade de gato morto: " + qtyGatoMorto);
                }
                catch
                {
                    Console.WriteLine("400 Bad Request");
                }

                Console.ReadLine();
                Console.Clear();
            }

        }
    }

    class Word
    {
        public static string wsUri = "http://teste.way2.com.br/dic/api/words/";

        public int retornaPosicao(string palavra, out int qtyGatoMorto)
        {
            qtyGatoMorto = 0;
            int posicao = 0;


            while (true)
            {
                string url = string.Concat(Word.wsUri, posicao);
                var response = new WebClient().DownloadString(new Uri(url));
                if (response.Equals(palavra)) 
                    return posicao;
                if (String.IsNullOrWhiteSpace(response))
                    throw new Exception(posicao.ToString() + " < Erro");

                posicao++;
                qtyGatoMorto++;
            }
           
        }
    }

}
