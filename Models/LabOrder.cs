using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HCAMiniEHR.Models;

[Table("LabOrder", Schema = "Healthcare")]
public partial class LabOrder
{
    [Key]
    public int LabOrderId { get; set; }

    public int AppointmentId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? TestName { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? Status { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? OrderedAt { get; set; }

    [ForeignKey("AppointmentId")]
    [InverseProperty("LabOrders")]
    public virtual Appointment Appointment { get; set; } = null!;
}
