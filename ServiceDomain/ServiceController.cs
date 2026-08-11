using Microsoft.AspNetCore.Mvc;
namespace MedicalCenterApi.ServiceDomain;

[ApiController]
[Route("api/[controller]")]
public class ServiceController : ControllerBase
{
    private readonly ServiceRequestHandler _handler;
    public ServiceController(ServiceRequestHandler handler)
    {
        _handler = handler;
    }
    [HttpGet]
    public async Task<ActionResult<List<Service>>> GetAll(
        [FromQuery] string? nameContains,
        [FromQuery] decimal? minPrice,
        [FromQuery] decimal? maxPrice,
        [FromQuery] int? minDurationMinutes,
        [FromQuery] int? maxDurationMinutes,
        CancellationToken cancellationToken = default)
    {
        var list = await _handler.GetAllServicesAsync(
            nameContains, minPrice, maxPrice, minDurationMinutes, maxDurationMinutes, cancellationToken);

        return Ok(list);
    }

    // GET api/service/5
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Service>> GetById(int id, CancellationToken cancellationToken = default)
    {
        var service = await _handler.GetByIdAsync(id, cancellationToken);
        if (service == null) return NotFound();
        return Ok(service);
    }

}
