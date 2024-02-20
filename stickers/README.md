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

- [ ] ~~Consumir o endpoint de filmes mais populares da API do IMDB. Procure também, na documentação da API do IMDB, o endpoint que retorna as melhores séries e o que retorna as séries mais populares.
- [ ] Colocar a chave da API do IMDB em algum lugar fora do código como um arquivo de configuração (p. ex, um arquivo .properties) ou uma variável de ambiente.~~
*OBS.: Aqui está sendo usado a API mockada, sem necessidade de usar uma chave de segurança.*

### 2º Dia

- Criar classe com método para ler, editar e salvar imagem.
- Primeiro usou imagem salva no computador.
- Segundo usou endereço de imagem da internet
- Adicionar parametros ao método, para que o endereço da imagem e o nome final da figurinha pronta, sejam adicionados na chamada do método.

#### 🚀 Desafios do 2º dia
- [x] Centralizar o texto na figurinha.
- [x] Colocar outra fonte como a Comic Sans ou a Impact, a fonte usada em memes.
- [x] Colocar contorno (outline) no texto da imagem.
- [x] Criar diretório de saída das imagens, se ainda não existir.
- [x] Tratar as imagens retornadas pela API do IMDB para pegar uma imagem maior ao invés dos thumbnails. Opções: pegar a URL da imagem e remover o trecho mostrado durante a aula ou consumir o endpoint de posters da API do IMDB (mais trabalhoso), tratando o JSON retornado.
- [x] Fazer com que o texto da figurinha seja personalizado de acordo com as classificações do IMDB.  
 <br/>  
- [ ] ~~Desafio supremo: usar alguma biblioteca de manipulação de imagens como OpenCV pra extrair imagem principal e contorná-la.~~  

### 3º Dia

- Usar API da NASA.
- Refatorar código seguindo o Paradigma da Orientação à Objetos.
- [APIs Públicas](https://github.com/public-apis/public-apis).

#### 🚀 Desafios do 3º dia
- [ ] Transformar a classe que representa os conteúdos em um Record, disponível a partir do Java 16
- [ ] Criar as suas próprias exceções e usá-las na classe que implementa o cliente HTTP
- [ ] Usar recursos do Java 8 e posterior, como Streams e Lambdas, para mapear uma lista em uma outra
- [ ] Criar uma Enum que une, como configurações, a URL da API e o extrator utilizado
- [ ] Desafio supremo: consumir outras APIs que contém imagens, como a da Marvel, que é bem diferente.