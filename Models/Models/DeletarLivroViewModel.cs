namespace Biblioteca.Models;
public class DeletarLivroViewModel
{
public int Id { get; set; }
public string? Titulo { get; set; }
public string? Autor{ get; set; }
public string ? Genero {get; set; }
public string? Sinopse {get; set; }
public DateOnly DataPublicacao {get; set; }
public int NumPaginas {get; set; }
}