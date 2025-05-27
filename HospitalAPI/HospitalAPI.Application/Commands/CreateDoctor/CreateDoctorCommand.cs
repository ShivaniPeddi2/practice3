using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
namespace HospitalAPI.Application.Commands.CreateDoctor
{
    public class CreateDoctorCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Specialty { get; set; }
    }
}
