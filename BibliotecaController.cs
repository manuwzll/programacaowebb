using Microsoft.AspNetCore.Mvc;
using Biblioteca.Models;

namespace Biblioteca.Controllers
{
    public class BibliotecaController : Controller
    {
        // Lista estática para persistir os dados durante a execução
        private static readonly List<Livro> l1 = new List<Livro>()
        {
            new Livro { Id = 1, Titulo = "Senhor dos Anéis", NumPaginas = 1200, Autor = "J. R. R. Tolkien", Genero = "Fantasia Épica", DataPublicacao = new DateOnly(1954, 7, 29) },
            new Livro { Id = 2, Titulo = "Harry Potter", NumPaginas = 223, Autor = "J.K. Rowling", Genero = "Fantasia", DataPublicacao = new DateOnly(1997, 6, 26) },
            new Livro { Id = 3, Titulo = "Rainha Vermelha", NumPaginas = 408, Autor = "Victoria Aveyard", Genero = "Fantasia Distópica", DataPublicacao = new DateOnly(2015, 2, 10) },
            new Livro { Id = 4, Titulo = "Percy Jackson e o Ladrão de Raios", NumPaginas = 408, Autor = "Rick Riordan", Genero = "Fantasia Fantasia /Mitologia", DataPublicacao = new DateOnly(2015, 2, 10) }

        };

        public IActionResult Index() => View();

        public IActionResult Livro(int id)
        {
            var livro = l1.FirstOrDefault(x => x.Id == id);
            if (livro == null) return NotFound();

            ViewData["LivroId"] = id;
            return View(livro);
        }

        // APAGUE AS DUAS VERSÕES ANTERIORES E DEIXE APENAS ESTA:
        public IActionResult Autor(int id)
        {
            var livro = l1.FirstOrDefault(x => x.Id == id);
            
            if (livro == null)
            {
                return RedirectToAction("Index");
            }

            return View(livro); 
            
        }
    }
}