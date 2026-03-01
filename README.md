Financeiro.App
Aplicação web de controle financeiro desenvolvida com ASP.NET Core utilizando o template Blazor Web App (.NET 8), aplicando Clean Architecture e princípios de Domain-Driven Design (DDD).

Sobre o Projeto
O Financeiro.App permite o gerenciamento de receitas e despesas pessoais, oferecendo visualização consolidada do saldo mensal por meio de um dashboard financeiro.
O foco do projeto foi aplicar boas práticas arquiteturais e organização de código, priorizando separação de responsabilidades e regras de negócio bem definidas.

Funcionalidades
- Cadastro, edição e remoção de **Receitas**
- Cadastro, edição e remoção de **Despesas**
- Dashboard com total mensal de receitas, despesas e saldo consolidado
- Validações de domínio (valor positivo, data válida, ownership por usuário)
<img width="1919" height="1079" alt="Captura de tela 2026-02-12 133505" src="https://github.com/user-attachments/assets/1be4026f-1142-4c51-875c-97ab201e78a1" />

Tecnologias
- ASP.NET Core Identity
- Blazor WebAssembly
- Entity Framework Core
- Clean Architecture
- Domain-Driven Design (DDD)
- Unit of Work
