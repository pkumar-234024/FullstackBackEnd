namespace ApiLearning.Core.Models;
public class AuditEntryDetail : EntityBase,IAggregateRoot
{
  public int? AuditEntryId { get; set; }
  public string FieldName { get; set; } = string.Empty;
  public string OldValue { get; set; } = string.Empty;
  public string NewValue { get; set; } = string.Empty;

  public virtual AuditEntry AuditEntry { get; set; } = null!;
}
