using System.IO.Compression;
using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Repositories;

public class LivroRepository : ILivroRepository
{
    readonly BibliotecaContext _context;

    public LivroRepository(BibliotecaContext context)
    {
        _context = context;
    }

    public async Task<List<Livro>> BuscarTodosLivrosAsync()
    {
        return await _context.Livros.Include(x => x.Autor).ToListAsync();
    }

    // NOVO: Adicionado para o Controller conseguir carregar os dados do livro antes de Editar/Deletar
    public async Task<Livro?> BuscarPorIdAsync(int id)
    {
        return await _context.Livros.Include(x => x.Autor).FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<bool> CriarLivroAsync(Livro livro, int AutorId)
    {
        livro.Autor = await _context.Autores.FirstOrDefaultAsync(x => x.Id == AutorId);
        await _context.Livros.AddAsync(livro);
        await _context.SaveChangesAsync();
        return true;
    }

    // ALTERADO: Recebe o autorId para atualizar o relacionamento corretamente, igual no criar!
    public async Task<bool> AtualizarLivroAsync(Livro Livro, int autorId)
    {
        var livroBanco = await _context.Livros.Include(x => x.Autor).FirstOrDefaultAsync(x => x.Id == Livro.Id);

        // CORREÇÃO: Validar se o livro do BANCO foi encontrado
        if (livroBanco == null) return false;

        livroBanco.Titulo = Livro.Titulo;
        livroBanco.Genero = Livro.Genero;
        livroBanco.NumPaginas = Livro.NumPaginas;
        livroBanco.DataPublicacao = Livro.DataPublicacao;
        livroBanco.Sinopse = Livro.Sinopse;

        // CORREÇÃO: Busca o novo autor selecionado no banco e associa ao livro
        livroBanco.Autor = await _context.Autores.FirstOrDefaultAsync(x => x.Id == autorId);

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ExcluirLivroAsync(int id)
    {
        var livro = await _context.Livros.FirstOrDefaultAsync(x => x.Id == id);
        if (livro == null) return false;

        _context.Livros.Remove(livro);
        await _context.SaveChangesAsync();
        return true;
    }
}
public interface ILivroRepository
{
    Task<List<Livro>> BuscarTodosLivrosAsync();
    Task<Livro?> BuscarPorIdAsync(int id); // Adicionado
    Task<bool> CriarLivroAsync(Livro livro, int AutorId);
    Task<bool> AtualizarLivroAsync(Livro livro, int autorId); // Atualizado para receber o novo AutorId
    Task<bool> ExcluirLivroAsync(int id); // Adicionado
}