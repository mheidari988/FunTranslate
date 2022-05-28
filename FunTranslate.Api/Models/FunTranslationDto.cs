using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunTranslate.Api.Models;
public class FunTranslationDto
{
    [Required]
    public string Text { get; set; } = string.Empty;
    public string? Type { get; set; }
}
