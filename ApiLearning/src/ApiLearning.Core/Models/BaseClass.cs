using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiLearning.Core.Models;
public class BaseClass : EntityBase, IAggregateRoot
{
  public DateTime CreatedAt { get; set; } = DateTime.Now;
  public DateTime ModifiedAt { get; set; } = DateTime.Now;
  public DateTime CreatedBy { get; set; } = DateTime.Now;
  public DateTime ModifiedBy { get; set; } = DateTime.Now;
}
