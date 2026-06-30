using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;
namespace Biblioteca.Repositories;

public class AutorRepository : IAutorRepository
{
   
     readonly BibliotecaContext _context;
    public AutorRepository(BibliotecaContext context)
    {
        _context = context;

    }


     public async Task<List<Autor>> BuscarTodosAutoresAsync()
    {
        return await _context.Autores.ToListAsync();
    }

 public async Task<bool> CriarAutorAsync(Autor autor)
{
    await _context.Autores.AddAsync(autor);
    await _context.SaveChangesAsync();
    return true; 
}
  public async Task<Autor?> BuscarPorIdAsync (int id)
    {
        return await _context.Autores.FirstOrDefaultAsync(a => a.Id == id);
    }
}
public interface IAutorRepository
{
    Task<List<Autor>> BuscarTodosAutoresAsync();
    Task<bool> CriarAutorAsync(Autor autor);
    
}


