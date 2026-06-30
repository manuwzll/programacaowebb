using Microsoft.AspNetCore.Mvc;
using Biblioteca.Models;
using Biblioteca.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace Biblioteca.Controllers
{
    public class BibliotecaController : Controller
    {
       readonly ILivroRepository _livroRepository;
       readonly IAutorRepository _autorRepository;
        public BibliotecaController(ILivroRepository livroRepository, IAutorRepository autorRepository)
        {
            _livroRepository = livroRepository;
            _autorRepository = autorRepository;
        }

        
        public IActionResult Index() => View();

        public IActionResult Livro(int id)
        {
            var livro = _livroRepository.BuscarTodosLivrosAsync();
            if (livro == null) return NotFound();

            ViewData["LivroId"] = id;
            return View(livro);
        }

        public IActionResult Autor(int id)
        {
            var livro = _livroRepository.BuscarTodosLivrosAsync();
            if (livro == null) return RedirectToAction("Index");

            return View(livro);
        }

        

        public IActionResult CriarAutor()
        {
            return View();
        }
        [HttpPost]
         public async Task<IActionResult> CriarAutorAsync(Autor autor)
        {
            await _autorRepository.CriarAutorAsync(autor);
            return RedirectToAction("CriarAutor");
        }    
       
        public async Task<IActionResult> CriarLivroAsync()
        {
            ViewBag.Autores = new SelectList(await _autorRepository.BuscarTodosAutoresAsync(),
                        "Id",
                        "Nome");

            return View();
        }
        

        [HttpPost]
         public async Task<IActionResult> CriarLivroAsync(CriarLivroViewModel livroView)
        {
            Livro livro = new()
            {
                Titulo = livroView.Titulo,
                NumPaginas = livroView.NumPaginas,
                Id = livroView.Id,
                Genero = livroView.Genero,
                Sinopse = livroView.Sinopse,
                DataPublicacao = livroView.DataPublicacao,
            
            };
            await _livroRepository.CriarLivroAsync(livro, livroView.AutorId);
            return RedirectToAction("CriarLivro");
        }    
        // CORREÇÃO: Carregar livro dinâmico por ID
public async Task<IActionResult>livro(int id)
{
    var livro = await _livroRepository.BuscarPorIdAsync(id);
    if (livro == null) return NotFound();

    return View(livro);
}

// ==========================================
// EDICAO DE LIVRO
// ==========================================
public async Task<IActionResult> EditarLivro(int id)
{
    var livro = await _livroRepository.BuscarPorIdAsync(id);
    if (livro == null) return NotFound();

    ViewBag.Autores = new SelectList(await _autorRepository.BuscarTodosAutoresAsync(), "Id", "Nome", livro.Autor?.Id);

    var viewModel = new EditarLivroViewModel
    {
        Id = livro.Id,
        Titulo = livro.Titulo,
        NumPag = livro.NumPaginas,
        Genero = livro.Genero,
        DataPublicacao = livro.DataPublicacao,
        AutorId = livro.Autor?.Id ?? 0
    };

    return View(viewModel);
}

[HttpPost]
public async Task<IActionResult> EditarLivro(EditarLivroViewModel model)
{
    if (!ModelState.IsValid) return View(model);

    Livro livro = new()
    {
        Id = model.Id,
        Titulo = model.Titulo,
        NumPaginas = model.NumPag,
        Genero = model.Genero,
        DataPublicacao = model.DataPublicacao
    };

    await _livroRepository.AtualizarLivroAsync(livro, model.AutorId);
    return RedirectToAction("Livro", new { id = livro.Id });
}

// ==========================================
// EXCLUSÃO DE LIVRO
// ==========================================
public async Task<IActionResult> DeletarLivro(int id)
{
    var livro = await _livroRepository.BuscarPorIdAsync(id);
    if (livro == null) return NotFound();

    var viewModel = new DeletarLivroViewModel
    {
        Id = livro.Id,
        Titulo = livro.Titulo,
        Autor = livro.Autor?.Nome,
        
        
    };

    return View(viewModel);
}

[HttpPost, ActionName("DeletarLivro")]
public async Task<IActionResult> ConfirmarDeletar(int id)
{
    await _livroRepository.ExcluirLivroAsync(id);
    return RedirectToAction("Index");
}
     
    }

}
