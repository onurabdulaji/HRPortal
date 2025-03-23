using HRPortal.Domain.Entities;
using HRPortal.Domain.Interfaces.IRepositories.IEmployeeRepository;
using HRPortal.Persistence.Context.Data;
using HRPortal.Persistence.Repositories.GenericRepository.ReadRepository;

namespace HRPortal.Persistence.Repositories.Repositories.EmployeeRepository;

public class ReadEmployeeRepository : ReadGenericRepository<Employee>, IReadEmployeeRepository
{
    public ReadEmployeeRepository(AppDbContext context) : base(context)
    {
    }
}
