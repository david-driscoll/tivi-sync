using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

[RegisterOptionsConfiguration("Tivi")]
public class TiviOptions
{
  public string Hostname { get; set; } = null!;
  public string Username { get; set; } = null!;
  public string Password { get; set; } = null!;
  public string CacheDirectory { get; set; } = null!;
  public string ResultsDirectory { get; set; } = null!;
  public int IntervalInSeconds { get; set; } = 600;

  public class Validation : AbstractValidator<TiviOptions>
  {
    public Validation()
    {
      RuleFor(z => z.Hostname).NotNull().NotEmpty();
      RuleFor(z => z.Username).NotNull().NotEmpty();
      RuleFor(z => z.Password).NotNull().NotEmpty();
      RuleFor(z => z.CacheDirectory).NotNull().NotEmpty();
      RuleFor(z => z.ResultsDirectory).NotNull().NotEmpty();
    }
  }

  public string GetCacheDirectory() => Path.IsPathRooted(CacheDirectory)
    ? CacheDirectory
    : Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), CacheDirectory));

  public string GetResultsDirectory() => Path.IsPathRooted(ResultsDirectory)
    ? ResultsDirectory
    : Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), ResultsDirectory));
}