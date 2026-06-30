namespace Biblioteca.Models;

public class EditarLivroViewModel
{
  public int Id {get; set; }

  public string? Titulo {get; set; }

  public int NumPag {get; set;}


  public string? Genero {get; set;}

public DateOnly DataPublicacao {get; set;}

public int AutorId {get; set;}
}

