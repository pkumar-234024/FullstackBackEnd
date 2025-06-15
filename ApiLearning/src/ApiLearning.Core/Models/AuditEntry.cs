namespace ApiLearning.Core.Models;
public class AuditEntry : EntityBase,IAggregateRoot
{
  public string EntityName { get; set; } = string.Empty;
  public string ActionType { get; set; } = string.Empty;
  public string Username { get; set; } = string.Empty;
  public DateTime? TimeStamp { get; set; }
  public string EntityId { get; set; } = string.Empty;
  public int? UserId { get; set; }
  public string Ipaddress { get; set; } = string.Empty;

  public virtual ICollection<AuditEntryDetail> AuditEntryDetail { get; set; } = new List<AuditEntryDetail>();
}
