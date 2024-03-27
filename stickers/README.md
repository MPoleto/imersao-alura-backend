# Stickers - Imersão Alura

Projetos desenvolvido em C# e .NET 6 a partir da _Imersão Java Alura_, neste evento foram desenvolvidos 2 projetos:

- Projeto **Stickers** que pega uma imagem, adiciona um texto e salva como uma nova imagem para ser usada como sticker nas redes sociais.

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
  - _OBS.: Aqui está sendo usado a API mockada, por isso não houve necessidade de usar a chave de segurança._
- [x] Usar sua criatividade para deixar a saída dos dados mais bonitinha: usar emojis com código UTF-8, mostrar a nota do filme como estrelinhas, decorar o terminal com cores, negrito e itálico usando códigos ANSI, e mais!
- [x] Mudar o JsonParser para usar uma biblioteca de parsing de JSON
  - Classe usada `JsonSerializer` do namespace `System.Text.Json`.
- [x] **Desafio supremo:** criar alguma maneira para você dar uma avaliação ao filme, puxando de algum arquivo de configuração ou pedindo a avaliação para o usuário digitar no terminal.

> Para resolver os desafios criei as classes `MoviesList` e `Movie` para auxiliar na manipulação dos dados da API.

### 2º Dia

- Criar classe com método para ler, editar e salvar imagem.
  - Testar usando imagem salva no computador.
  - Testar usando endereço de imagem da internet.
- Adicionar parâmetros ao método: para o endereço da imagem e para o nome final da figurinha pronta.

> Para fazer a figurinha usei o namespace `System.Drawing` que é específica para Windows.
> É necessário instalar o pacote `System.Drawing.Common`.

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

- Usar API da NASA.
  - [APIs Públicas](https://github.com/public-apis/public-apis).
- Refatorar código seguindo o Paradigma da Orientação à Objetos.

#### 🚀 Desafios do 3º dia

- [x] Transformar a classe que representa os conteúdos em um Record.
- [x] Criar as suas próprias exceções e usá-las na classe que implementa o cliente HTTP.
- [x] ~~Usar recursos do Java 8 e posterior, como Streams.~~
  > Em C# usei LINQ e Lambdas para mapear uma lista em uma outra.
- [x] ~~Criar uma Enum que une, como configurações, a URL da API e o extrator utilizado.~~
  > Em C# não é possível usar enum como é usado em Java. Por isso, fiz uma classe com os campos `private readonly`, criei os objetos como `static readonly`, para deixar o mais parecido possível com um enum em Java.
- [x] **Desafio supremo:** consumir outras APIs que contém imagens, como a da Marvel, que é bem diferente.

  > A API utilizada foi a _Pexels_ que precisa adicionar uma chave de acesso - [Photos provided by Pexels](https://www.pexels.com).  
  > Utilizei o endpoint de curadoria, que são fotos selecionadas pela equipe da Pexels e são atualizadas de hora em hora.    
  > A chave foi salva separadamente em um arquivo Secrets (gerenciador de secredos), para isso, instalei o pacote `Microsoft.Extensions.Configuration.UserSecrets`

#### Além dos desafios:
- Separei parte do método `CreateSticker` em outros métodos, pois o método estava muito longo:  
  - O método `GetImage` que pega a imagem da internet.  
  - A parte do código que salva o sticker no método `SaveSticker`.  
- Alterei a forma que a deserialização das API (`Parse`) estava sendo feita, deixei de usar o arquivo criado durante a imersão, que usa expressões regulares, e passei a usar as funcionalidades disponíveis no namespace `System.Text.Json`.
