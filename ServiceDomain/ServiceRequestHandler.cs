using Microsoft.EntityFrameworkCore;
using MedicalCenterApi.ServiceDomain;
namespace MedicalCenterApi;

public class ServiceRequestHandler
{
    private readonly AppDbContext _dbContext;
    public ServiceRequestHandler(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Service>> GetAllServicesAsync(
        string? nameContains = null,
        decimal? minPrice = null,
        decimal? maxPrice = null,
        int? minDurationMinutes = null,
        int? maxDurationMinutes = null,
        CancellationToken cancellationToken = default)
    {
        var query = _dbContext.Services.AsNoTracking().AsQueryable();

        if (!string.IsNullOrWhiteSpace(nameContains))
        {
            var pattern = nameContains.Trim();
            query = query.Where(s => EF.Functions.Like(s.Name, $"%{pattern}%"));
        }

        if (minPrice.HasValue) query = query.Where(s => s.Price >= minPrice.Value);
        if (maxPrice.HasValue) query = query.Where(s => s.Price <= maxPrice.Value);

        if (minDurationMinutes.HasValue)
        {
            var minTs = TimeSpan.FromMinutes(minDurationMinutes.Value);
            query = query.Where(s => s.Duration >= minTs);
        }

        if (maxDurationMinutes.HasValue)
        {
            var maxTs = TimeSpan.FromMinutes(maxDurationMinutes.Value);
            query = query.Where(s => s.Duration <= maxTs);
        }

        return await query.OrderBy(s => s.Id).ToListAsync(cancellationToken);
    }

    // Получить сервис по Id
    public async Task<Service?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Services
                               .AsNoTracking()
                               .FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
    }
}

