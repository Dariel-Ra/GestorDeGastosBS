namespace GestorDeGastosBS.Data.Response;

public class UsuarioResponse
{
    public UsuarioResponse()
    {
    }

    public UsuarioResponse(int usuarioId, string userName, string nickname, string password, string role, bool estado)
    {
        UsuarioId = usuarioId;
        UserName = userName;
        Nickname = nickname;
        Password = password;
        Role = role;
        Estado = estado;
    }

    public int UsuarioId { get; set; }
    public string UserName { get; set; } = null!;
    public string Nickname { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Role { get; set; } = null!;
    public bool Estado { get; set; }
}

