# FIAP Postech Marketplace

 FIAP Postech Marketplace é um projeto baseados nas diretrizes do desafio proposto na matéria de **Desenvolvimento de API's com .NET**, com finalidade de reforço de conceitos aprendidos nas aulas.

## Proposta do desafio

Para este desafio, vamos nos aprofundar nos conhecimentos adquiridos em aula para construir uma API res-
ponsável pelo cadastro e leitura de produtos de um marketplace. Como aprendemos a construir APIs robus-
tas, vamos considerar o cenário a seguir.

Somos uma empresa especializada na construção de APIs de alta performance e fomos contratados por
esse marketplace. Nosso objetivo inicial é criar uma API de CRUD básica para suprir uma necessidade do
time de produtos desse marketplace.

Dado o cenário descrito, devemos garantir que nossa API tenha:

1. Uma autorização do tipo Bearer Token (JWT).
2. Um endpoint para inseir um novo produto.
3. Um endpoint para retornar todos os produtos cadastrados.
4. Um endpoint para deletar um determinado produto.
5. Um Swagger bem documentado.
6. Uma arquitetura bem definida com services, repository e interfaces.

### Orientações (para implementação do projeto)

1. Crie um projeto no template padrão de APIs.
2. Crie as pastas necessárias para organizar seu projeto.
3. Foque em resolver o problema proposto e depois pense em maneiras de evoluir sua aplicação.

Lembre-se de evoluir ainda mais sua aplicação utilizando os conceitos aprendidos em aula, como middlewa-
res, injeção de dependência, banco de dados e cache.

Caso vocẽ tenha alguma dúvida durante o desenvolvimento, não deixe de procurar seu(sua) docente no
nosso canal do Dicord e participar dos Grupos de Trabalho para arquirir um maior aprendizado com a pes-
soa mentora reponsável.


## Declação do autor

Algumas implementações do projejto não foram vistas em aula e partem da experiência do autor:

- Utilização de DTO's;
- Uso do pacote Nuget Mapster para mapeamnto entre DTO e entidades;
- Formato de trabalho com JWT, transformado como um service;
- Aprofundamento no uso do Swagger para documentar cada endpoint;

OBS: apesar de já possuir conhecimento em arqutietura limpa, preferi adotar o modelo monolito, não fazendo a segregação dos recursos (Services, Repositories, Entities,m etc) por projeto, deixando tudo em um mesmo projeto na solution, deixando assim uma margem para refatoração futura.
Outro ponto por esse projeto ser de estudo e ser pequeno, caberia nele perfeitamente o uso
de minimal api para tornar o código um pouco mais enxuto.
