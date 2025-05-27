using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalAPI.Domain.Entities;

[Table("Appointment")]
public partial class Appointment
{
    [Key]
    public int AppointmentId { get; set; }

    public int? PatientId { get; set; }

    public int? DoctorId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? AppointmentDate { get; set; }

    [ForeignKey("DoctorId")]
    [InverseProperty("Appointments")]
    public virtual Doctor? Doctor { get; set; }

    [ForeignKey("PatientId")]
    [InverseProperty("Appointments")]
    public virtual Patient? Patient { get; set; }
}
