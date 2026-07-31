namespace MedicalCenterApi;

public class ServiceRequestHandler
{
    private readonly AppDbContext _dbContext;
    public ServiceRequestHandler(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    
}
