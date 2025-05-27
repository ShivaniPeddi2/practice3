using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using Microsoft.EntityFrameworkCore;

namespace HospitalAPI.Domain.Entities;


[Table("Patient")]
public partial class Patient
{
    [Key]
    public int PatientId { get; set; }

    [StringLength(100)]
    public string? Name { get; set; }

    public int? Age { get; set; }

    [InverseProperty("Patient")]
    public virtual ICollection<Appointment> Appointments { get; set; } = [];
}
