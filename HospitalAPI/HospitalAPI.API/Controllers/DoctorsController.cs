//using HospitalAPI.Application.Doctors.Commands.CreateDoctor;
//using HospitalAPI.Application.Doctors.Commands.DeleteDoctor;
//using HospitalAPI.Application.Doctors.Commands.UpdateDoctor;
//using HospitalAPI.Application.Doctors.Queries.GetAllDoctors;
using HospitalAPI.Application.Commands.CreateDoctor;
using HospitalAPI.Application.Commands.DeleteDoctor;
using HospitalAPI.Application.Commands.UpdateDoctor;
using HospitalAPI.Application.Queries.GetAllDoctors;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DoctorsController : ControllerBase
{
    private readonly IMediator _mediator;

    public DoctorsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _mediator.Send(new GetAllDoctorsQuery());
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateDoctorCommand command)
    {
        var id = await _mediator.Send(command);
        return Ok(id);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateDoctorCommand command)
    {
        if (id != command.DoctorId)
            return BadRequest();

        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{doctorId}")]
    public async Task<IActionResult> DeleteDoctor(int doctorId)
    {
        try
        {
            var command = new DeleteDoctorCommand { DoctorId = doctorId };
            await _mediator.Send(command);
            return NoContent(); // 204 No Content status
        }
        catch (KeyNotFoundException)
        {
            return NotFound(); // 404 Not Found if doctor is not found
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error:{ex.Message}");
            return StatusCode(500, "Internal server error"); // 500 for other unexpected errors
        }
    }
}
