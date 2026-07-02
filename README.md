# Sistema de Biblioteca Web — Dados Dinâmicos 📚

Este repositório contém o código-fonte desenvolvido para o **Trabalho Prático 1** da disciplina de **Programação WEB II** do **IFMT - Campus Campo Verde**. 

O objetivo do projeto foi evoluir uma aplicação web de biblioteca anteriormente estática, transformando-a num sistema totalmente funcional, persistido e integrado com um banco de dados MySQL local. Para garantir as boas práticas de isolamento de dados, toda a arquitetura foi estruturada utilizando o padrão **Repository Pattern**.

---

## 🛠️ Tecnologias Utilizadas

* **Framework Principal:** ASP.NET Core MVC (v8.0 / .NET 10)
* **Mapeamento e Persistência:** Entity Framework Core
* **Banco de Dados:** MySQL Server (rodando em `localhost`)
* **Interface Visual:** Razor Views (`.cshtml`), HTML5, CSS3 (Fontes *Cinzel* e *Lato*) e JavaScript para buscas em tempo real.

---

## 🏗️ Arquitetura e Organização do Código

O projeto está dividido de forma estrita seguindo as camadas recomendadas pelo padrão **MVC** e isolamento por repositórios:

* **Models:** Classes de domínio (`Livro` e `Autor`) que representam as tabelas do banco e estruturam o relacionamento de 1 para N (um autor para muitos livros).
* **Views:** Páginas dinâmicas construídas com Razor, responsáveis por renderizar a interface sem informações fixas no código (*hardcoded*).
* **Controllers (`BibliotecaController`):** Camada intermédia que gere as rotas, intercepta as requisições HTTP e invoca os repositórios.
* **Repositories:** As classes `LivroRepository` e `AutorRepository` concentram 100% das operações SQL e chamadas ao `BibliotecaContext`, protegendo o controlador de acessos diretos à base de dados.

---

## 🚀 Como Executar o Projeto Localmente

Siga o passo a passo abaixo para configurar o ambiente, gerar o banco de dados e rodar o sistema na sua máquina.

### 1. Pré-requisitos
* Ter o **SDK do .NET** instalado na máquina.
* Ter o **MySQL Server** ativo localmente.

### 2. Configurar a String de Conexão
Abra o ficheiro `appsettings.json` na raiz do seu projeto e ajuste as credenciais da propriedade `ConnectionStrings` para que correspondam ao utilizador e palavra-passe do seu MySQL local:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=BibliotecaDb;Uid=root;Pwd=SUA_SENHA_AQUI;"
}
