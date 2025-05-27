using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalAPI.Application.Commands.DeleteDoctor
{
    public class DeleteDoctorCommand : IRequest<Unit>
    {
        public int DoctorId { get; set; }
    }
}
