using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HCAMiniEHR.Models;

[Table("Patient", Schema = "Healthcare")]
public partial class Patient
{
    [Key]
    public int PatientId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string FullName { get; set; } = null!;

    public DateOnly DateOfBirth { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string Gender { get; set; } = null!;

    [StringLength(15)]
    [Unicode(false)]
    public string? Phone { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [InverseProperty("Patient")]
    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
