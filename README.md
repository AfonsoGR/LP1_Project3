# LP1_Projeto 3 - Bootleg Roguelike

## Autoria

### Grupo 05

[Afonso Rosa](https://github.com/AfonsoGR) &nbsp;&nbsp;&nbsp;&nbsp;- a21802169  

[André Vitorino](https://github.com/Freeze88-2) - a21902663

[João Fonseca](https://github.com/JoaoFonseca197) &nbsp; - 21905441  

O repositório utilizado pode ser encontrado
[aqui](https://github.com/AfonsoGR/LP1_Project3).

### Distribuição do Projeto

#### Afonso Rosa

O aluno, Afonso Rosa, foi o responsável pelas classes `Highscore`, `MainMenu`,
`Program`, `ScoresManager` e `InfoRules`, tendo sido o responsável pela lógica,
estruturação e funcionamento das mesmas, teve apoio do colega, João Fonseca,
que ajudou no funcionamento da classe `ScoresManager`.

Tratou ainda da documentação das classes `Highscore`, `MainMenu`, `Program`,
`ScoresManager` e `InfoRules`. E realizou grande parte do relatório como também
ajudou com o UML de classes.

#### André Vitorino

O aluno, André Vitorino, foi o responsável pelas classes `GameLoopController`,
`SceneManager`, `RoomGenerator`, `SavesManager` e `Renderer`, tendo sido o
responsável pela lógica, estruturação e funcionamento das mesmas, sendo que a
class `SavesManager` é uma cópia adaptada da classe `ScoresManager`.

Tratou ainda da documentação das classes `GameLoopController`, `SceneManager`,
`RoomGenerator`, `SaveManager` e `Renderer`. E ajudou com parte do relatório.

#### João Fonseca

O aluno, João Fonseca, foi o responsável pelas classes `BigHeal`, `Boss`,
`Enemies`, `MedHeal`, `MiniHeal`, `Minion`,`Piece`, `Player`, `Position` e
`Powerup`,tendo sido o responsável pela lógica, estruturação e funcionamento
das mesmas, teve apoio do colega, André Vitorino, que ajudou no funcionamento
das classes `Enemies` e `Player`.

Tratou ainda da documentação das classes `BigHeal`, `Boss`, `Enemies`, `Piece`,
`MedHeal`, `MiniHeal`, `Minion`, `Player`, `Position` e `Powerup`. E a maioria
do UML de classes.

## Arquitetura da solução

### Descrição da solução

O projeto tem como ponto principal a classe `GameLoopController`, sendo a
classe que contem o jogo em si, criando e guardando os elementos necessários
para que o jogo funcione. A classe `GameLoopController` é que gere o _loop_
principal do jogo enquanto o jogador estiver vivo e não se encontrar com o seu
movimento bloqueado. Usando o `Renderer` para atualizar o _board_, onde mostra
o movimento atualizado do jogador e dos inimigos como também a interface do
utilizador. Verifica também se o jogador apanhou algum _powerup_ ou se se
encontra na sáida do nível. Também se responsabiliza pela passagem de nível,
utilizando a class `SavesManager` para guardar o jogo quando isto aconteçe.

`GameLoopController` gere o movimento do jogador e dos inimigos e todas as
verificações essenciais para o _loop_ principal do jogo. Utiliza também a
classe `SceneManager` para gerir a criação dos elementos da sala a qual utiliza
a class `RoomGenerator` para criar a sala.

Ao iniciar-se o programa este chama a class `MainMenu` que irá passar o
controlo para a class `GameLoopController` quando o jogo começar. A partir da
classe `MainMenu` esta acede também à classe `InfoRules`, que usa para dispor
informação em texto no ecrã e à classe `ScoresManager` que acede a ficheiros no
computador e os altera, gravando e editando ficheiros com as pontuações e nomes
dos utilizadores.

### Diagrama UML

![diagramaUML](diagramaUML.png)

### Referências

Foi consultada a
[API&nbsp;do&nbsp;C#](
    ps://docs.microsoft.com/en-us/dotnet/api/system?view=netcore-3.1) online.

Foram reaproveitados elementos do
[projeto](https://github.com/AfonsoGR/LP1_Project2) realizado previamente para
esta cadeira pelos alunos Afonso Rosa e André Vitorino.

Foram aproveitados elementos deste
[post](https://stackoverflow.com/questions/4351258) do
[Stack Overflow](https://stackoverflow.com/).

Houve troca de ideias com colegas em como lidar com os problemas impostos pelas
_highscores_, estes colegas foram o
[Tomás Franco, a21803301](https://github.com/ThomasFranque) e
[Rodrigo Pinheiro, a21802488](https://github.com/RodrigoPrinheiro),
embora as ideias do [Tomás Franco](https://github.com/RodrigoPrinheiro) é que
foram as que acabaram a ser utilizadas.

Foi também aproveitado este
[código](https://gist.github.com/fakenmc/f70b38814ac6552e790dc0a86c3c67d0)
disponibilizado no
[enunciado do projeto](https://github.com/VideojogosLusofona/lp1_2019_p3).
