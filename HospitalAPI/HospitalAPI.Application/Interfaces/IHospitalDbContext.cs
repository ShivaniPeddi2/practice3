//using HospitalAPI.Domain.Entities;
using HospitalAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace HospitalAPI.Application.Interfaces
{
    public interface IHospitalDbContext
    {
        DbSet<Doctor> Doctors { get; set; }
        DbSet<Patient> Patients { get; set; }
        DbSet<Appointment> Appointments { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
