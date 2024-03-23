# Stickers - Imersão Alura

Projeto desenvolvido em C# a partir da Imersão Java Alura.

## Descrição

### 1º Dia

- Fazer chamada da API, método GET.
- Armazenar a resposta em uma variável do tipo string
- Criar uma classe com método que, usando expressões regulares, transforma e organiza as informações da resposta em um dicionário, com o nome do atributo e o valor do atributo.
- Exibir somente as informações selecionadas: titulo, link imagem e nota dos filmes.
- API alternativa ao do IMDB, usando o top 10 melhores filmes.

#### 🚀 Desafios do 1º dia

- [x] Usar sua criatividade para deixar a saída dos dados mais bonitinha: usar emojis com código UTF-8, mostrar a nota do filme como estrelinhas, decorar o terminal com cores, negrito e itálico usando códigos ANSI, e mais!
- [x] Mudar o JsonParser para usar uma biblioteca de parsing de JSON -> Biblioteca usada `System.Text.Json.JsonSerializer`
- [x] **Desafio supremo:** criar alguma maneira para você dar uma avaliação ao filme, puxando de algum arquivo de configuração ou pedindo a avaliação para o usuário digitar no terminal.

- [ ] ~~Consumir o endpoint de filmes mais populares da API do IMDB. Procure também, na documentação da API do IMDB, o endpoint que retorna as melhores séries e o que retorna as séries mais populares.~~
- [ ] ~~Colocar a chave da API do IMDB em algum lugar fora do código como um arquivo de configuração (p. ex, um arquivo .properties) ou uma variável de ambiente.~~  
       _OBS.: Usei a API mockada que não precisa da chave de segurança._

### 2º Dia

- Criar classe com método para ler, editar e salvar imagem.
- Primeiro usou imagem salva no computador.
- Segundo usou endereço de imagem da internet
- Adicionar parametros ao método, para que o endereço da imagem e o nome final da figurinha pronta, sejam adicionados na chamada do método.

> Para fazer a figurinha usei o namespace `System.Drawing` que só é possível ser usado no Windows. Para usá-lo precisou instalar o pacote `System.Drawing.Common`.

#### 🚀 Desafios do 2º dia

- [x] Centralizar o texto na figurinha.
- [x] Colocar outra fonte como a Comic Sans ou a Impact, a fonte usada em memes.
- [x] Colocar contorno (outline) no texto da imagem.
- [x] Criar diretório de saída das imagens, se ainda não existir.
- [x] Tratar as imagens retornadas pela API do IMDB para pegar uma imagem maior ao invés dos thumbnails. Opções: pegar a URL da imagem e remover o trecho mostrado durante a aula ou consumir o endpoint de posters da API do IMDB (mais trabalhoso), tratando o JSON retornado.
- [x] Fazer com que o texto da figurinha seja personalizado de acordo com as classificações do IMDB.
- [ ] ~~Desafio supremo: usar alguma biblioteca de manipulação de imagens como OpenCV pra extrair imagem principal e contorná-la.~~

### 3º Dia

- Usar API da NASA.
- Refatorar código seguindo o Paradigma da Orientação à Objetos.
- [APIs Públicas](https://github.com/public-apis/public-apis).

#### 🚀 Desafios do 3º dia

- [x] Transformar a classe que representa os conteúdos em um Record.
- [x] Criar as suas próprias exceções e usá-las na classe que implementa o cliente HTTP.
- [x] ~~Usar recursos do Java 8 e posterior, como Streams~~ Em C# usar LINQ e Lambdas para mapear uma lista em uma outra.
- [x] ~~Criar uma Enum que une, como configurações, a URL da API e o extrator utilizado.~~ Em C# não é possível fazer o mesmo que é feito em Java com enum. Por isso, fiz uma classe com os campos `private readonly`, criei os objetos como `static readonly`, para deixar o mais parecido possível com um enum em Java.
- [x] **Desafio supremo:** consumir outras APIs que contém imagens, como a da Marvel, que é bem diferente.
  - Outra API utilizada foi a _Pexels_ que precisa adicionar uma chave de acesso - [Photos provided by Pexels](https://www.pexels.com).
    > A chave foi salva separadamente em um arquivo Secrets (gerenciador de secredos), para isso, precisou instalar o pacote `Microsoft.Extensions.Configuration.UserSecrets`

#### Além dos desafios:

- Separei parte do método `CreateSticker` em outros métodos, pois achei que estava muita coisa em um método só.
  - O método `GetImage` que pega a imagem da internet.
  - A parte do código que salva o sticker no método `SaveSticker`.
- Alterei a forma que a deserialização das API (`Parse`) estava sendo feita, deixei de usar o arquivo criado durante a imersão, que usa expressões regulares, e passei a usar as funcionalidades presentes no namespace `System.Text.Json`.

### 4º Dia

- Construir API REST que armazena as logos das linguagens de programação, que pode ser usada na aplicação de gerar stickers.
- Conectar a API ao banco de dados NoSQL MongoDB.

#### 🚀 Desafios do 4º dia

- [x] Finalizar o CRUD (Create, Read, Update e Delete) para que se possa atualizar e excluir uma linguagem cadastrada;
- [x] Devolver a listagem ordenada pelo ranking;
- [x] Criar na sua API um modelo de entidade com nomes diferentes de title e image ou, manter com o nome title e image e traduzir para que seja retornado como título e imagem através do uso de DTO (Data Transfer Object);
- [x] Retornar o status 201 quando um recurso (linguagem, no nosso caso) for cadastrado através do POST;
- [x] Criar seu próprio extrator de figurinhas personalizado;
- [x] **Desafio supremo**: Aplicar modificações parciais no recurso através do método PATCH, por exemplo, modificando o número de votos ou de pessoas que utilizam cada linguagem de programação.
  - No método PATCH adiciona mais um voto na contagem da linguagem escolhida e atualiza o rank das linguagens.
