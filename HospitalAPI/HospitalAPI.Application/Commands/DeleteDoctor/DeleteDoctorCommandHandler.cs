using HospitalAPI.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
namespace HospitalAPI.Application.Commands.DeleteDoctor
{
    public class DeleteDoctorCommandHandler : IRequestHandler<DeleteDoctorCommand, Unit>
    {
        private readonly IHospitalDbContext _context;

        public DeleteDoctorCommandHandler(IHospitalDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteDoctorCommand request, CancellationToken cancellationToken)
        {
            try { 
            var doctor = await _context.Doctors
                .FirstOrDefaultAsync(d => d.DoctorId == request.DoctorId, cancellationToken);

            if (doctor == null)
                throw new KeyNotFoundException($"Doctor with ID {request.DoctorId} not found");

            var appointments = await _context.Appointments
                .Where(a => a.DoctorId == request.DoctorId)
                .ToListAsync(cancellationToken);

            if (appointments.Any())
            {
                _context.Appointments.RemoveRange(appointments);
                await _context.SaveChangesAsync(cancellationToken);
            }


            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
        
         catch (Exception ex)
            {
                // Log the exception here
                Console.WriteLine($"Error: {ex.Message}");
                // Optional: Log to a file or external service like Serilog, NLog, etc.
                throw new Exception("An error occurred while processing the request", ex);
            }
        }
    }
}
