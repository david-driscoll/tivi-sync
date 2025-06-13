namespace Tivi;

[RegisterOptionsConfiguration("Proxy")]
public class TiviProxyOptions
{
    public string? Hostname { get; set; } = null!;
    public string? Username { get; set; } = null!;
    public string? Password { get; set; } = null!;
}