using HospitalAPI.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalAPI.Application.Commands.UpdateDoctor
{
    public class UpdateDoctorCommandHandler : IRequestHandler<UpdateDoctorCommand,Unit>
    {
        private readonly IHospitalDbContext _context;
        public UpdateDoctorCommandHandler(IHospitalDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateDoctorCommand request, CancellationToken cancellationToken)
        {
            var doctor = await _context.Doctors.FirstOrDefaultAsync(d => d.DoctorId == request.DoctorId, cancellationToken);

            if (doctor == null)
                throw new Exception("Doctor not found");

            doctor.Name = request.Name;
            doctor.Specialty = request.Specialty;

            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
