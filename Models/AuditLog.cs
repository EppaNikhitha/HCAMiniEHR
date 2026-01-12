using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HCAMiniEHR.Models;

[Table("AuditLog", Schema = "Healthcare")]
public partial class AuditLog
{
    [Key]
    public int AuditId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? TableName { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? ActionType { get; set; }

    public int? RecordId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ChangedAt { get; set; }
}
