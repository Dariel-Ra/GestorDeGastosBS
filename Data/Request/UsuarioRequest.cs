namespace GestorDeGastosBS.Data.Request;

public class UsuarioRequest
{
    public string UserName { get; set; } = null!;
    public string Nickname { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Role { get; set; } = null!;
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

