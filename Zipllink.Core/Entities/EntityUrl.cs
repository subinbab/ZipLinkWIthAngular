using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zipllink.Core.Entities;
public class EntityUrl
{
    [Required]
    public int id { get; set; }
    public string url { get; set; } = string.Empty;
    public string generatedUrl { get; set; } = string.Empty;
    public string shortenUrl { get; set; } = string.Empty;
    public string createdby { get; set; } = string.Empty;
    public DateTime createdDate { get; set; } = DateTime.Now;
    public string modifieddby { get; set; } = string.Empty;
    public DateTime modifiedDate { get; set; } = DateTime.Now;
}
