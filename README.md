## Projeto modelo - Movimentos Manuais

### Projeto implementado nas sequintes tecnologias:

- Arquitetura Hexagonal
- Plataforma .NET 5
- Banco de dados SQLite
- ORM - Entity Framework Core
- SPA em Angular 2+
- Testes unitários

### A estrutura do projeto pode ser detalhada com as informações a seguir:
 - O projeto está arquitetado em camadas, sendo dividas em 4: 
    --> 1-Core: Onde se encontram as camadas de application e domain, ou seja, a parte de regras de negócio se encontram aqui.
    --> 2-Driven: São os adapters com o mundo externo da aplicação. Nesta camada encontra-se o repositório de dados
    --> 3-Drivers: São os adapters de entrada da aplicação, ou qualquer estimulo que faça o sistema processar. Aqui encontram-se os projetos angular e a WebAPI
    --> 4-Tests: Aqui está o projeto utilizado para realizar os testes unitários e comportamentais. 

### As funcionalidades incluídas no projeto, permite ao usuário incluir, visualizar e excluir uma determinada Movimentação, assim como especificado em documentação.

### Para que o projeto rode, é necessário executar o comando "npm-install" dentro do projeto Angular (ClientApp) para baixar as dependências do projeto.
