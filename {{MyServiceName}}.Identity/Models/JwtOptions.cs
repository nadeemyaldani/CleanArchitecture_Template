using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace __MyServiceName__.Identity.Models;
public class JwtOptions
{
    [Required]
    [MinLength(32, ErrorMessage = "The JWT key must be at least 256 bits (32 chars) long.")]
    public string Key { get; set; } = string.Empty;

    [Required]
    public string Issuer { get; set; } = string.Empty;

    [Required]
    public string Audience { get; set; } = string.Empty;

    [Range(-1, 1440, ErrorMessage = "Token expiry must be between -1 and 1440 minutes.")]
    public int TokenExpiryInMinutes { get; set; }
    [Range(-1, 168, ErrorMessage = "Refresh Token expiry must be between -1 and 168 Hours.")]
    public int RefreshTokenExpiryInHours { get; internal set; }
}

