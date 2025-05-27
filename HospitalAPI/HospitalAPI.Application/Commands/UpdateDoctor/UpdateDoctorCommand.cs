using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalAPI.Application.Commands.UpdateDoctor
{
    public class UpdateDoctorCommand : IRequest<Unit>
    {
        public int DoctorId { get; set; }
        public string Name { get; set; } = null!;
        public string Specialty { get; set; } = null!;
    }
}
