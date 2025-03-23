using HRPortal.Domain.Entities;
using HRPortal.Domain.Interfaces.IGenericRepository.WriteGeneric;

namespace HRPortal.Domain.Interfaces.IRepositories.IEmployeeRepository;

public interface IWriteEmployeeRepository : IWriteGenericRepository<Employee>
{
}