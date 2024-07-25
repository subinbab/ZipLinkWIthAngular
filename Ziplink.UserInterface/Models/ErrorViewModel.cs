using System.ComponentModel.DataAnnotations;

namespace Ziplink.UserInterface.Models;

public class URLClient
{
    [Required]
    [RegularExpression(@"^(https?:\/\/)?([a-zA-Z0-9-]+\.)+[a-zA-Z]{2,}(\/[^\s]*)?$", ErrorMessage = "Please enter a valid URL.")]
    public string url { get; set; } = string.Empty;
    public string clientIp { get; set; } = string.Empty;
    public string generatedUrl { get; set; } = string.Empty;
    public string shortenurl { get; set; } = string.Empty;
}
