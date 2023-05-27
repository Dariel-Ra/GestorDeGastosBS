namespace GestorDeGastosBS.Data.Requests;

public class UsuarioRequest
{
    public string Nombre { get; set; } = null!;
    public string Apellido { get; set; } = null!;
    public string Password { get; set; } = null!;
    public bool Estado { get; set; }
}

public class UsuarioRequestUpdate : UsuarioRequest
{
    public int UsuarioId { get; set; }
}

// public class UsuarioRequestPassword : UsuarioRequest
// {
//     public int UsuarioId { get; set; }
//     public string Password { get; set; } = null!;

// }

