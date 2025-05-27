using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalAPI.Application.Queries.GetAllDoctors
{
    public class GetAllDoctorsQuery : IRequest<List<DoctorDto>> { }
}
