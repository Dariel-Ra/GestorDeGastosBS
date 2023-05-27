namespace GestorDeGastosBS.Data.Response;

public class UsuarioResponse
{
    public UsuarioResponse()
    {
    }

    public UsuarioResponse(int usuarioId, string nombre, string apellido, string password, bool estado)
    {
        UsuarioId = usuarioId;
        Nombre = nombre;
        Apellido = apellido;
        Password = password;
        Estado = estado;
    }

    public int UsuarioId { get; set; }
    public string Nombre { get; set; } = null!;
    public string Apellido { get; set; } = null!;
    public string Password { get; set; } = null!;
    public bool Estado { get; set; }
}
