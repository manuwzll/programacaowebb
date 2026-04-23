using Microsoft.AspNetCore.Mvc;
using Biblioteca.Models;

namespace Biblioteca.Controllers
{
    public class BibliotecaController : Controller
    {
        // Lista atualizada com os 13 livros e nomes padronizados
        private static readonly List<Livro> l1 = new List<Livro>()
        {
            new Livro { Id = 1, Titulo = "Senhor dos Anéis", NumPaginas = 1200, Autor = "J. R. R. Tolkien", Genero = "Fantasia Épica", DataPublicacao = new DateOnly(1954, 7, 29) },
            new Livro { Id = 2, Titulo = "Harry Potter", NumPaginas = 223, Autor = "J.K. Rowling", Genero = "Fantasia", DataPublicacao = new DateOnly(1997, 6, 26) },
            new Livro { Id = 3, Titulo = "Rainha Vermelha", NumPaginas = 408, Autor = "Victoria Aveyard", Genero = "Fantasia Distópica", DataPublicacao = new DateOnly(2015, 2, 10) },
            new Livro { Id = 4, Titulo = "Percy Jackson e o Ladrão de Raios", NumPaginas = 408, Autor = "Rick Riordan", Genero = "Fantasia / Mitologia", DataPublicacao = new DateOnly(2005, 6, 28) },
            new Livro { Id = 5, Titulo = "O Leão, a Feiticeira e o Guarda-Roupa", NumPaginas = 200, Autor = "C. S. Lewis", Genero = "Fantasia", DataPublicacao = new DateOnly(1950, 10, 16) },
            new Livro { Id = 6, Titulo = "Eragon", NumPaginas = 500, Autor = "Christopher Paolini", Genero = "Fantasia Épica", DataPublicacao = new DateOnly(2002, 8, 26) },
            new Livro { Id = 7, Titulo = "A Bússola de Ouro", NumPaginas = 400, Autor = "Philip Pullman", Genero = "Fantasia / Aventura", DataPublicacao = new DateOnly(1995, 7, 9) },
            new Livro { Id = 8, Titulo = "O Nome do Vento", NumPaginas = 650, Autor = "Patrick Rothfuss", Genero = "Fantasia", DataPublicacao = new DateOnly(2007, 3, 27) },
            new Livro { Id = 9, Titulo = "O Mago de Terramar", NumPaginas = 200, Autor = "Ursula K. Le Guin", Genero = "Fantasia", DataPublicacao = new DateOnly(1968, 1, 1) },
            new Livro { Id = 10, Titulo = "Cidade dos Ossos", NumPaginas = 450, Autor = "Cassandra Clare", Genero = "Fantasia Urbana", DataPublicacao = new DateOnly(2007, 3, 27) },
            new Livro { Id = 11, Titulo = "O Alquimista: Nicolas Flamel", NumPaginas = 400, Autor = "Michael Scott", Genero = "Fantasia / Mitologia", DataPublicacao = new DateOnly(2007, 5, 22) },
            new Livro { Id = 12, Titulo = "Neverwhere", NumPaginas = 370, Autor = "Neil Gaiman", Genero = "Fantasia Urbana", DataPublicacao = new DateOnly(1996, 9, 16) },
            new Livro { Id = 13, Titulo = "A Pirâmide Vermelha", NumPaginas = 450, Autor = "Rick Riordan", Genero = "Fantasia / Mitologia Egípcia", DataPublicacao = new DateOnly(2010, 5, 4) }
        };

        public IActionResult Index() => View();

        public IActionResult Livro(int id)
        {
            var livro = l1.FirstOrDefault(x => x.Id == id);
            if (livro == null) return NotFound();

            ViewData["LivroId"] = id;
            return View(livro);
        }

        public IActionResult Autor(int id)
        {
            var livro = l1.FirstOrDefault(x => x.Id == id);
            if (livro == null) return RedirectToAction("Index");

            return View(livro);
        }
    }
}