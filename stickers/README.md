# Imersão Alura

Projetos desenvolvido em C# a partir da _Imersão Java Alura_, neste evento foram desenvolvidos 2 projetos:

- Projeto **Stickers**: que pega uma imagem, adiciona um texto e salva como uma nova imagem para ser usada como sticker nas redes sociais.

## Descrição

### 1º Dia

- Fazer chamada da API, método GET.
  - Usar API mockada do top 250 filmes do IMDB.
- Armazenar a resposta em uma variável do tipo string
- Criar uma classe com um método que usa expressões regulares para transformar e organizar as informações da resposta em um dicionário, com o nome e o valor do atributo.
- Exibir somente as informações selecionadas: título, link da imagem e nota dos filmes.

#### Desafios do Primeiro dia

- Usar sua criatividade para deixar a saída dos dados mais bonitinha: usar emojis com código UTF-8, mostrar a nota do filme como estrelinhas, decorar o terminal com cores, negrito e itálico usando códigos ANSI, e mais!
- Mudar o JsonParser para usar uma biblioteca de parsing de JSON
  - Biblioteca usada: `System.Text.Json.JsonSerializer`.
- Desafio supremo: criar alguma maneira para você dar uma avaliação ao filme, puxando de algum arquivo de configuração OU pedindo a avaliação para o usuário digitar no terminal.
  - Para resolver os desafios criei as classes `MoviesList` e `Movie` para auxiliar na manipulação dos dados da API.
