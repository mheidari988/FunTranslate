namespace FunTranslate.Application.Models.Dapper;
public class FunTranslationFilterDto
{
    public Guid Id { get; set; }
    public string Text { get; set; } = string.Empty;
    public string Translated { get; set; } = string.Empty;
    public string Translation { get; set; } = string.Empty;
}
