# Desafio_jogoMemoria
1. Como foi criada a estrutura inicial do programa?
   
O programa foi desenvolvido na linguagem C# utilizando as bibliotecas básicas do sistema. Inicialmente, foi criada a estrutura principal contendo:
a biblioteca System;
a biblioteca System.Threading;
a classe Program;
o método principal Main().
Dentro do método Main, foram declaradas as matrizes do jogo e iniciada toda a lógica responsável pela execução do jogo da memória.

2. Como foi criada a matriz gabarito?
   
Foi criada uma matriz bidimensional chamada gabarito, do tipo string[,], com:
6 linhas;
3 colunas.
Essa matriz é responsável por armazenar as letras das cartas do jogo. Cada letra aparece duas vezes para formar os pares.
As letras utilizadas foram:
A, B, C, D, E, F, G, H e I.
A distribuição das letras foi realizada no método:
static void Preencher(string[,] gabarito)
Nesse método, as letras são inseridas automaticamente na matriz utilizando códigos ASCII.

3. Como foi criada e inicializada a matriz visual?
   
Foi criada uma segunda matriz chamada visual, também do tipo string[,], com dimensão 6x3.
Essa matriz representa o tabuleiro exibido ao jogador durante a partida.
Inicialmente, todas as posições recebem o caractere "*", indicando que as cartas estão escondidas.
A inicialização foi feita no método:
static void PreencherAsterisco(string[,] visual)

4. Como funciona a etapa de memorização inicial?
   
Antes do início da partida, o programa exibe a matriz gabarito completa para que o jogador memorize as posições das cartas.
Primeiramente, é exibida a mensagem:
=== MEMORIZE AS POSIÇÕES ===
Em seguida, todas as letras armazenadas na matriz gabarito são mostradas na tela.

5. Qual a função do Thread.Sleep e do Console.Clear?
    
O comando Thread.Sleep() foi utilizado para manter o gabarito visível por alguns segundos antes do início do jogo.
Para isso, foi adicionada a biblioteca:
using System.Threading;
Depois da exibição do gabarito, o programa aguarda alguns segundos:
Thread.Sleep(5000);
Após a espera, a tela é limpa utilizando:
Console.Clear();
Assim, o jogador não consegue mais visualizar as posições das cartas.

6. Como funcionam os contadores pares e tentativas?
    
Foram criadas duas variáveis inteiras para controlar o progresso da partida:
int pares = 0;
int tentativas = 0;
A variável pares armazena a quantidade de pares encontrados pelo jogador.
A variável tentativas registra quantas rodadas foram realizadas durante o jogo.

7. Como o laço while controla a continuidade do jogo?
    
O jogo permanece em execução através de um laço while.
A condição utilizada foi:
while (pares < 9)
Isso significa que o jogo continuará funcionando enquanto todos os 9 pares ainda não forem encontrados.
Dentro desse laço estão as principais ações da partida:
exibição do tabuleiro;
escolha das cartas;
validações;
comparação dos pares.

8. Como o jogador escolhe a primeira e a segunda carta?
    
O programa solicita ao jogador:
a linha;
a coluna.
Primeiramente, o jogador escolhe a primeira carta:
Escolha a 1° carta:
Linha:
Coluna:
Os valores são armazenados nas variáveis:
int l1;
int c1;
Depois, o jogador escolhe a segunda carta:
Escolha a 2° carta:
Linha:
Coluna:
Os valores são armazenados em:
int l2;
int c2;

9. Como as cartas são reveladas no tabuleiro?
    
Após o jogador escolher uma posição, a carta correspondente é revelada no tabuleiro visual.
Isso é feito copiando o conteúdo da matriz gabarito para a matriz visual.
Primeira carta:
visual[l1, c1] = gabarito[l1, c1];
Segunda carta:
visual[l2, c2] = gabarito[l2, c2];
Após cada revelação, o método ExibirTabuleiro() é chamado novamente para atualizar a tela.

10. Como o programa compara se as cartas formam um par?
    
Foi utilizada uma estrutura condicional if para verificar se as cartas escolhidas possuem o mesmo valor e não pertencem à mesma posição.
A condição utilizada foi:

if (gabarito[l1, c1] == gabarito[l2, c2] &&
   (l1 != l2 || c1 != c2))
   
Quando a condição é verdadeira, o programa exibe:
BOA! Par encontrado!
E incrementa a variável de pares:
pares++;

11. O que acontece quando o jogador acerta?
    
Quando o jogador encontra um par correto:
as cartas permanecem visíveis;
a variável pares é incrementada;
o jogo continua normalmente.
As posições encontradas não voltam a ser escondidas.

12. O que acontece quando o jogador erra?
    
Se as cartas escolhidas forem diferentes, o programa exibe a mensagem:
ERROU! Não é um par.
Em seguida, o programa aguarda alguns segundos:
Thread.Sleep(2000);
Depois disso, as cartas são escondidas novamente:
visual[l1, c1] = "*";
visual[l2, c2] = "*";

13. Qual é a função do método ExibirTabuleiro?
    
O método ExibirTabuleiro() foi criado para evitar repetição de código.
Sua função é mostrar o estado atual do jogo na tela.
A assinatura do método é:
static void ExibirTabuleiro(string[,] matriz, int pares, int tent)
Esse método exibe:
o título do jogo;
a quantidade de pares encontrados;
o número de tentativas;
todas as posições da matriz visual.


14. Como o jogo identifica que todos os pares foram encontrados?
    
O jogo utiliza a variável pares para verificar o progresso da partida.
Quando o valor chega a 9:
while (pares < 9)
A condição do while se torna falsa e o laço é encerrado automaticamente.

15. Como a mensagem final é exibida?
    
Após o término do jogo, a tela é limpa utilizando:
Console.Clear();
Depois disso, o programa exibe uma mensagem final informando o desempenho do jogador:
Console.WriteLine($"PARABÉNS! Você completou o jogo em {tentativas} tentativas.");
Também é exibido um relatório contendo:
quantidade de pares encontrados;
número de tentativas;
classificação de desempenho.

16. Validação de linha e coluna?
    
Foi implementada uma validação para impedir que o jogador escolha posições inexistentes da matriz.
As regras definidas foram:
linhas entre 0 e 5;
colunas entre 0 e 2.
A validação utilizada foi:
if (l1 < 0 || l1 >= gabarito.GetLength(0) ||
   c1 < 0 || c1 >= gabarito.GetLength(1))
Caso o jogador informe valores inválidos, o programa exibe uma mensagem de erro e reinicia a jogada.

17. Impedimento de escolher a mesma carta duas vezes?
    
Foi adicionada uma verificação para impedir que o jogador escolha a mesma posição nas duas tentativas.
A condição utilizada foi:
if (l1 == l2 && c1 == c2)
Se isso acontecer, o programa informa:
“Você não pode escolher a mesma carta duas vezes.”
Depois disso, a primeira carta é escondida novamente.

18. Impedimento de escolher carta já encontrada?
    
O programa também impede que o jogador escolha cartas que já foram descobertas anteriormente.
A verificação utilizada foi:
if (visual[l2, c2] != "*")
Quando isso ocorre, o sistema exibe:
Essa carta já foi encontrada. Escolha outra posição.
Essa validação evita jogadas inválidas durante a partida.

19. Embaralhamento das cartas?
    
Foi criada uma melhoria para embaralhar as cartas antes do início do jogo.
Para isso, foi utilizado um vetor contendo todas as letras duplicadas:
"A", "A", "B", "B", ...
Depois, foi aplicado o algoritmo de embaralhamento utilizando a classe Random.
O método responsável por essa melhoria foi:
static void PreencherAleatorio(string[,] gabarito)
Após o embaralhamento, os valores são distribuídos aleatoriamente na matriz gabarito, tornando cada partida diferente da anterior.
