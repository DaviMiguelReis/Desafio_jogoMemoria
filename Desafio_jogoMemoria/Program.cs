using System;
using System.Threading;

class Program
{
    static void Main()
    {
        string[,] gabarito = new string[6, 3];
        string[,] visual = new string[6, 3];

        PreencherAleatorio(gabarito);
        PreencherAsterisco(visual);

        // MOSTRAR GABARITO
        Console.WriteLine("=== MEMORIZE AS POSIÇÕES ===\n");

        for (int l = 0; l < gabarito.GetLength(0); l++)
        {
            for (int c = 0; c < gabarito.GetLength(1); c++)
            {
                Console.Write(gabarito[l, c] + "\t");
            }
            Console.WriteLine();
        }
        Thread.Sleep(5000);
        Console.Clear();

        int pares = 0;
        int tentativas = 0;

        while (pares < 9)
        {

            ExibirTabuleiro(visual, pares, tentativas);

            // PRIMEIRA CARTA
            Console.WriteLine("\nEscolha a 1° carta:");

            Console.Write("Linha: ");
            int l1 = int.Parse(Console.ReadLine()!);

            Console.Write("Coluna: ");
            int c1 = int.Parse(Console.ReadLine()!);

            if (l1 < 0 || l1 >= gabarito.GetLength(0) || c1 < 0 || c1 >= gabarito.GetLength(1))
            {
                Console.WriteLine("Posição inválida. Digite uma linha entre 0 e 5 e uma coluna entre 0 e 2.");
                Thread.Sleep(2000);
                Console.Clear();
                continue;
            }
            if (visual[l1, c1] != "*")
            {
                Console.WriteLine("Essa carta já foi encontrada. Escolha outra posição.");
                Thread.Sleep(2000);
                continue;
            }

            visual[l1, c1] = gabarito[l1, c1];

            ExibirTabuleiro(visual, pares, tentativas);



            // SEGUNDA CARTA
            Console.WriteLine("\nEscolha a 2° carta:");

            Console.Write("Linha: ");
            int l2 = int.Parse(Console.ReadLine()!);

            Console.Write("Coluna: ");
            int c2 = int.Parse(Console.ReadLine()!);

            //  - POSIÇÃO INVÁLIDA
            if (l2 < 0 || l2 >= gabarito.GetLength(0) ||
                c2 < 0 || c2 >= gabarito.GetLength(1))
            {
                Console.WriteLine("Posição inválida. Digite uma linha entre 0 e 5 e uma coluna entre 0 e 2.");
                Thread.Sleep(2000);
                continue;
            }

            // - MESMA CARTA
            if (l1 == l2 && c1 == c2)
            {
                Console.WriteLine("Você não pode escolher a mesma carta duas vezes.");
                Thread.Sleep(2000);

                visual[l1, c1] = "*";

                continue;
            }

            //  - CARTA JÁ ENCONTRADA
            if (visual[l2, c2] != "*")
            {
                Console.WriteLine("Essa carta já foi encontrada. Escolha outra posição.");
                Thread.Sleep(2000);
                continue;
            }

            //  - REVELAR CARTA

            visual[l2, c2] = gabarito[l2, c2];

            ExibirTabuleiro(visual, pares, tentativas);

            tentativas++;

            // COMPARAÇÃO
            if (gabarito[l1, c1] == gabarito[l2, c2] &&
                (l1 != l2 || c1 != c2))
            {
                Console.WriteLine("\nBOA! Par encontrado!");
                pares++;
            }

            else
            {
                Console.WriteLine("\nERROU! Não é um par.");

                Thread.Sleep(2000);

                visual[l1, c1] = "*";
                visual[l2, c2] = "*";
            }


            Console.WriteLine("\nPressione qualquer tecla...");
            Console.ReadKey();
        }

        Console.Clear();

        Console.Clear();
        Console.WriteLine($"PARABÉNS! Você completou o jogo em {tentativas} tentativas.\n");
        Console.WriteLine("=== RELATÓRIO FINAL ===");
        Console.WriteLine($"Pares encontrados: {pares}/9");
        Console.WriteLine($"Tentativas: {tentativas} ");

        string desempenho;
        if (tentativas <= 12)
        {
            desempenho = "Excelente!";
        }
        else if (tentativas <= 18)
        {
            desempenho = "Muito bom!";
        }
        else if (tentativas <= 25)
        {
            desempenho = "Bom.";
        }
        else
        {
            desempenho = "Pode melhorar...";
        }
        Console.Write($"Desempenho: {desempenho}\n\n");

    }

    //MÉTODOS ABAIXO
    static void Preencher(string[,] gabarito)
    {
        int indice = 65;

        for (int l = 0; l < gabarito.GetLength(0); l++)
        {
            for (int c = 0; c < gabarito.GetLength(1); c++)
            {
                gabarito[l, c] = ((char)indice).ToString();

                indice++;

                if (indice > 73)
                {
                    indice = 65;
                }
            }
        }
    }
    static void ExibirTabuleiro(string[,] matriz, int pares, int tent)
    {
        Console.Clear();

        Console.WriteLine("=== JOGO DA MEMÓRIA 6x3 ===");
        Console.WriteLine("Pares: " + pares + "/9 | Tentativas: " + tent);
        Console.WriteLine();

        Console.Write("\t");

        for (int c = 0; c < matriz.GetLength(1); c++)
        {
            Console.Write(c + "\t");
        }

        Console.WriteLine();

        for (int c = 0; c < matriz.GetLength(1); c++)
        {
            Console.Write("---------");
        }

        Console.WriteLine();

        for (int l = 0; l < matriz.GetLength(0); l++)
        {
            Console.Write(l + "|\t");

            for (int c = 0; c < matriz.GetLength(1); c++)
            {
                Console.Write(matriz[l, c] + "\t");
            }

            Console.WriteLine();
        }
    }
    static void PreencherAleatorio(string[,] gabarito)
    {
        string[] letras =
        {
       "A", "A", "B", "B", "C", "C",
       "D", "D", "E", "E", "F", "F",
       "G", "G", "H", "H", "I", "I"
    };

        Random rnd = new Random();

        // embaralhar 
        for (int i = 0; i < letras.Length; i++)
        {
            int sorteio = rnd.Next(letras.Length);
            string aleat = letras[i];
            letras[i] = letras[sorteio];
            letras[sorteio] = aleat;
        }

        // preencher matriz 6x3
        int indice = 0;

        for (int l = 0; l < gabarito.GetLength(0); l++)
        {
            for (int c = 0; c < gabarito.GetLength(1); c++)
            {
                gabarito[l, c] = letras[indice];
                indice++;
            }
        }
    }

    static void PreencherAsterisco(string[,] visual)
    {
        for (int l = 0; l < visual.GetLength(0); l++)
        {
            for (int c = 0; c < visual.GetLength(1); c++)
            {
                visual[l, c] = "*";
            }
        }
    }

}
