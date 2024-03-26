# Stickers - Imersão Alura

Projetos desenvolvido em C# e .NET 6 a partir da _Imersão Java Alura_, neste evento foram desenvolvidos 2 projetos:

- Projeto **Stickers**: que pega uma imagem, adiciona um texto e salva como uma nova imagem para ser usada como sticker nas redes sociais.

## Descrição

### 1º Dia

- Fazer chamada da API, método GET.
  - Usar API mockada do top 250 filmes do IMDB.
- Armazenar a resposta em uma variável do tipo string
- Criar uma classe com um método que usa expressões regulares para transformar e organizar as informações da resposta em um dicionário, com o nome e o valor do atributo.
- Exibir somente as informações selecionadas: título, link da imagem e nota dos filmes.

#### 🚀 Desafios do 1º dia

- [ ] Consumir o endpoint de filmes mais populares da API do IMDB. Procure também, na documentação da API do IMDB, o endpoint que retorna as melhores séries e o que retorna as séries mais populares.
- [ ] Colocar a chave da API do IMDB em algum lugar fora do código como um arquivo de configuração (p. ex, um arquivo .properties) ou uma variável de ambiente.  
       _OBS.: Aqui está sendo usado a API mockada, por isso não houve necessidade de usar a chave de segurança._
- [x] Usar sua criatividade para deixar a saída dos dados mais bonitinha: usar emojis com código UTF-8, mostrar a nota do filme como estrelinhas, decorar o terminal com cores, negrito e itálico usando códigos ANSI, e mais!
- [x] Mudar o JsonParser para usar uma biblioteca de parsing de JSON
  - Classe usada `JsonSerializer` do namespace `System.Text.Json`.
- [x] **Desafio supremo:** criar alguma maneira para você dar uma avaliação ao filme, puxando de algum arquivo de configuração ou pedindo a avaliação para o usuário digitar no terminal.

  > Para resolver os desafios criei as classes `MoviesList` e `Movie` para auxiliar na manipulação dos dados da API.

### 2º Dia

- Criar classe com método para ler, editar e salvar imagem.
  - Biblioteca usada: `System.Drawing.Common` **específica para Windows**
  - Testar usando imagem salva no computador.
  - Testar usando endereço de imagem da internet.
- Adicionar parâmetros ao método: para o endereço da imagem e para o nome final da figurinha pronta.

#### 🚀 Desafios do 2º dia

- [x] Centralizar o texto na figurinha.
- [x] Colocar outra fonte como a `Comic Sans` ou a `Impact`, a fonte usada em memes.
- [x] Colocar contorno (outline) no texto da imagem.
  > Fiz esse desafio fazendo a sobreposição de textos, modificando a posição e a cor.
- [x] Criar diretório de saída das imagens, se ainda não existir.
- [x] Tratar as imagens retornadas pela API do IMDB para pegar uma imagem maior ao invés dos thumbnails. Opções: pegar a URL da imagem e remover o trecho mostrado durante a aula ou consumir o endpoint de posters da API do IMDB (mais trabalhoso), tratando o JSON retornado.
- [x] Fazer com que o texto da figurinha seja personalizado de acordo com as classificações do IMDB.
  > Para esse desafio, adicionei mais um parâmetro no método de criar o sticker: string que vai ser adicionada a imagem.
- [ ] **Desafio supremo:** usar alguma biblioteca de manipulação de imagens como OpenCV pra extrair imagem principal e contorná-la.

### 3º Dia
