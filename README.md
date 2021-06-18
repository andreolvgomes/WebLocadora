# WebLocadora

Sistema para locadoras(WebApi + SPA ou MVC) com as operações de inserção de filmes(com validação), listagem (com filtros), edição e deleção.
Será observado o nível de completude e qualidade dos artefatos, requisitos para o desenvolvimento:
 
- .NET Core (WebApi/Mvc)
- Dapper / Entity Framework Core
- DDD
- Solid
- Design Patterns

## Resultado

• **WebApi:** Criado um projeto **Locadora.Api** para centralizar as entradas de todas as requisições solicitadas pelo FrontEnd

• **MVC:** Criado um projeto **Locadora.WebMVC** para entradas de dados, modificações e consultas

• **Operações:** É possível executar as seguintes operações: Criação de Novos Filmes, Listagem, Filtro por nome, Edição e Exclusão

• **Validações:**
   1. Ao incluir um novo filme a API verifica se já existe algum filme na base de dados com o nome mesmo, caso exista, é abortado a operação e retorna mensagem para o FrontEnd
   2. Ao editar um filme a API faz a mesma validação o idem 1
   3. Ao excluir um filme, antes que seja feito de fato a exclusão do registro, o FrontEnd irá aguardar confirmação do usuário

• **Listagem com Filtros**: A página principal do FrontEnd já abre listando todos os registros. Acima da listagem há um campo para que seja possível efetuar filtros por Nome

## Tecnologias e Design Patterns

- :heavy_check_mark: .NET Core (WebApi/Mvc)
- :heavy_check_mark: Entity Framework Core
- Utilizado o Entity Framework para criação do banco de dados a partir da classe Filme.cs e migrations. Executar as opções de (insert, delete, update e select)
- :heavy_check_mark: Dapper
- Utilizando Dapper para  preencher a lista de filmes quando estiver utilizando o recurso de filtragem
- :heavy_check_mark: DDD
- Seguido pelo menos alguns princípios do DDD na parte arquitetônica. O BackEnd foi dividio em 4 projetos: **Locabora.Application** camada expressiva da aplicação utilizando Commands, como (CriarFilme, RemoverFilme ...). **Locadora.Api**, **Locadora.Data** camada de acesso aos dados e **Locadora.Domain**
- :heavy_check_mark: Solid
- Tudo foi criado seguindo pelo menos o mínimo de alguns dos princípios: **SRP** classes pequenas expressivas e coesas. **ISP** as classes com maiores responsabilidades são representadas por interfaces e **DIP**
- :heavy_check_mark: Design Patterns
- **Repository Pattern** na camada de acesso aos dados, **CQRS** na camada de aplicação e **Dependency Injection** ...
