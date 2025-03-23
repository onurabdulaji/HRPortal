using HRPortal.Domain.Entities;
using HRPortal.Domain.Interfaces.IGenericRepository.WriteGeneric;
using System.Security.Cryptography;
using System.Text;

namespace HRPortal.Domain.Interfaces.IRepositories.IAppUserRepository;

public interface IWriteAppUserRepository : IWriteGenericRepository<AppUser>
{
    Task<AppUser> CreateUser(AppUser createUser);
    Task<AppUser> UpdateUser(AppUser updateUser);
    Task<bool> DeleteUser(Guid id);
    Task<AppUser> ChangeStatus(Guid id);
}

// Örnek bir şifre hashleme metodu
public static class PasswordHasher
{
    public static string HashPassword(string password)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }
}