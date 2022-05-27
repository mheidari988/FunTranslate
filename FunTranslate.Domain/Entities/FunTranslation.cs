namespace FunTranslate.Domain.Entities;
public class FunTranslation : AuditableEntity
{
    public Guid Id { get; set; }
    public string Text { get; set; } = string.Empty;
    public string Translated { get; set; } = string.Empty;
    public string Translation { get; set; } = string.Empty;
}
