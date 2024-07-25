using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zipllink.Core.DTOEntities;
public class EntityUrlDTO
{
    [Required]
    [RegularExpression(@"^(https?:\/\/)?([a-zA-Z0-9-]+\.)+[a-zA-Z]{2,}(\/[^\s]*)?$", ErrorMessage = "Please enter a valid URL.")]
    public string url { get; set; } = string.Empty;
    public string clientIp { get; set; } = string.Empty;
    public string generatedUrl { get; set; } = string.Empty;
    public string shortenurl { get; set; } = string.Empty;
}
