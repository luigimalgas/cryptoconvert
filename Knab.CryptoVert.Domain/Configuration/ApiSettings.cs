using System.ComponentModel.DataAnnotations;

namespace Knab.CryptoVert.Domain.Configuration;

public class ApiSettings
{
    [Required]
    public string? Header { get; init; }
    
    [Required]
    public string? Url { get; init; }
    
    [Required]
    public string? ApiKey { get; init; }
}