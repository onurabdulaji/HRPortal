using HRPortal.Domain.Entities;
using HRPortal.Domain.Interfaces.IRepositories.IEmployeeRepository;
using HRPortal.Persistence.Context.Data;
using HRPortal.Persistence.Repositories.GenericRepository.WriteRepository;

namespace HRPortal.Persistence.Repositories.Repositories.EmployeeRepository;

public class WriteEmployeeRepository : WriteGenericRepository<Employee>, IWriteEmployeeRepository
{
    public WriteEmployeeRepository(AppDbContext context) : base(context)
    {
    }
}
