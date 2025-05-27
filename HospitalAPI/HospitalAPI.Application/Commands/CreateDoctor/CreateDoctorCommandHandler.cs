using HospitalAPI.Application.Interfaces;
using HospitalAPI.Application.Interfaces;
using HospitalAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace HospitalAPI.Application.Commands.CreateDoctor
{
    public class CreateDoctorCommandHandler : IRequestHandler<CreateDoctorCommand, int>
    {
        private readonly IHospitalDbContext _context;

        public CreateDoctorCommandHandler(IHospitalDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
        {
            var doctor = new Doctor
            {
                Name = request.Name,
                Specialty = request.Specialty
            };

            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync(cancellationToken);
            return doctor.DoctorId;
        }
    }
}
