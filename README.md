# Avaliação 04 Curso JNMoura

### Objetivo: Montar um CRUD de veículos utilizando API em C#, base de dados no SGBD SQL Server e um aplicativo cliente para validar as requisições em sua API,como, por exemplo, o Postman.

1) No SGBD criar um banco de dados chamado Loja.
2) Neste banco de dados, criar uma tabela Veiculos com as seguintes colunas: Id (int)
(chave primária e auto numeração), Marca (varchar(50)), Nome (varchar(100)),
AnoModelo (Int), DataFabricacao (Date), Valor (decimal(8,2)), Opcionais (varchar(500))
não obrigatório.
#### Entregável 1: Gerar script com as instruções acima chamado: script-Loja.sql.

3) Criar um projeto .Net Framework Web API.
  a. Criar o controlador de Veiculos com características e/ou comportamentos
    (Construtor, Get, Get(id), Get(nome) Post, Put e Delete).
  b. Validar o estado do modelo nos métodos Post e Put.
  c. Parâmetro string de conexão deve estar no Web.config.
4) Na pasta (namespace) Models.
  a. Criar a classe Veiculo com características e/ou comportamentos.
  b. Validar o modelo com DataAnottations, utilizando a notação [Required] em todos
  os dados, exceto Id e Opcionais. Os dados do tipo texto têm que ser validados
  mediante ao número máximo de caracteres permitidos.

5) Criar uma pasta (namespace) Repositories.
  a. Criar a classe Veiculo com características e/ou comportamentos (Construtor,
  Select, Insert, Update e Delete).

6) Criar uma pasta Utils para o Logger bem como os arquivos que são necessários para seu
funcionamento, seguindo o modelo que fizemos em sala de aula.
