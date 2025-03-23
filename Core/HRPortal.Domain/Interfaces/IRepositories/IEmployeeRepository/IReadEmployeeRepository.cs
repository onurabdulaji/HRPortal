using HRPortal.Domain.Entities;
using HRPortal.Domain.Interfaces.IGenericRepository.ReadGeneric;

namespace HRPortal.Domain.Interfaces.IRepositories.IEmployeeRepository;

public interface IReadEmployeeRepository : IReadGenericRepository<Employee>
{
}
