# Imersão Alura

Projeto desenvolvido a partir da imersão java Alura, mas feito em C#.

## Descrição

### 1º Dia

- Fazer chamada da API, método GET.
- Armazenar a resposta em uma variável do tipo string
- Criar uma classe com método que, usando expressões regulares, transforma e organiza as informações da resposta em um dicionário, com o nome do atributo e o valor do atributo.
- Exibir somente as informações selecionadas: titulo, link imagem e nota dos filmes.
- API alternativa ao do IMDB, usando o top 10 melhores filmes.

#### Desafios do Primeiro dia
- Usar sua criatividade para deixar a saída dos dados mais bonitinha: usar emojis com código UTF-8, mostrar a nota do filme como estrelinhas, decorar o terminal com cores, negrito e itálico usando códigos ANSI, e mais!
- Mudar o JsonParser para usar uma biblioteca de parsing de JSON -> Biblioteca usada `System.Text.Json.JsonSerializer`
- Desafio supremo: criar alguma maneira para você dar uma avaliação ao filme, puxando de algum arquivo de configuração OU pedindo a avaliação para o usuário digitar no terminal.

### 2º Dia

- Criar classe com método para ler, editar e salvar imagem.
- Primeiro usou imagem salva no computador.
- Segundo usou endereço de imagem da internet
- Adicionar parametros ao método, para que o endereço da imagem e o nome final da figurinha pronta, sejam adicionados na chamada do método.