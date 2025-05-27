using HospitalAPI.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalAPI.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HospitalAPI.Application.Queries.GetAllDoctors
{
    public class GetAllDoctorsQueryHandler : IRequestHandler<GetAllDoctorsQuery, List<DoctorDto>>
    {
        private readonly IHospitalDbContext _context;

        public GetAllDoctorsQueryHandler(IHospitalDbContext context)
        {
            _context = context;
        }

        public async Task<List<DoctorDto>> Handle(GetAllDoctorsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Doctors
                .Select(d => new DoctorDto
                {
                    DoctorId = d.DoctorId,
                    Name = d.Name,
                    Specialty = d.Specialty
                }).ToListAsync(cancellationToken);
        }
    }
}
