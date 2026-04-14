# 🏛️ Lounge Literário - Sistema de Biblioteca Web

Este é um projeto de aplicação web desenvolvido em **ASP.NET Core MVC**. O sistema funciona como um catálogo digital de obras literárias, permitindo a visualização de detalhes técnicos, sinopses dinâmicas e informações bibliográficas dos autores.

## 🚀 Funcionalidades do Código

Baseado na estrutura MVC (Model-View-Controller), o projeto conta com:

- **Página Inicial (Index):** Apresenta o conceito da biblioteca e uma vitrine de "Destaques da Semana" com cards interativos.
- **Visualização de Detalhes (Livro):** Uma página dinâmica que recebe o ID do livro e exibe informações como gênero, número de páginas e uma sinopse exclusiva.
- **Página do Autor:** Exibe a biografia e bibliografia detalhada de autores como J.R.R. Tolkien, J.K. Rowling, Rick Riordan e Victoria Aveyard.
- **Menu Dropdown e Modal:** Implementação em JavaScript para exibição de informações institucionais e criadores do projeto sem recarregar a página.

## 🛠️ Tecnologias Utilizadas

- **Backend:** C# com ASP.NET Core MVC.
- **Frontend:** Razor Pages (CSHTML), HTML5, CSS3.
- **Design:** Bootstrap 5.3 para responsividade e Google Fonts (Cinzel e Lato) para tipografia clássica.
- **Lógica de Dados:** Listas estáticas em C# para persistência de dados durante a execução (Simulação de Banco de Dados).

## 📂 Estrutura do Repositório

- `Controllers/`: Contém a `BibliotecaController.cs` que gerencia as rotas e a lógica de exibição.
- `Views/`: Contém as páginas visuais (`Index.cshtml`, `Livro.cshtml`, `Autor.cshtml`).
- `Shared/`: Contém o `_Layout.cshtml`, que define o cabeçalho, menu e rodapé padrão do site.
- `wwwroot/img/`: Pasta destinada às capas dos livros e fotos dos autores.

## ⚙️ Como executar o projeto

1. Tenha o **SDK do .NET Core** instalado em sua máquina.
2. Clone este repositório:
   ```bash
   git clone [https://github.com/manuwzll/programacaowebb.git](https://github.com/manuwzll/programacaowebb.git)

   Abra o terminal (crtl+J) e excute com dotnet watch run
