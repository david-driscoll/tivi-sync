using FluentValidation;

namespace Tivi;

[RegisterOptionsConfiguration("Tivi")]
public class TiviOptions
{
    public string Hostname { get; set; } = null!;
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;

    public int IntervalInSeconds { get; set; } = 600;

    public class Validation : AbstractValidator<TiviOptions>
    {
        public Validation()
        {
            RuleFor(z => z.Hostname).NotNull().NotEmpty();
            RuleFor(z => z.Username).NotNull().NotEmpty();
            RuleFor(z => z.Password).NotNull().NotEmpty();
        }
    }

    private static string EnsureDirectory(string path)
    {
        path = Path.IsPathRooted(path)
            ? path
            : Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), path));

        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        return path;
    }
}
