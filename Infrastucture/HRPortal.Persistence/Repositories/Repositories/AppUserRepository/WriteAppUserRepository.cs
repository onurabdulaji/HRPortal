using HRPortal.Domain.Entities;
using HRPortal.Domain.Interfaces.IRepositories.IAppUserRepository;
using HRPortal.Persistence.Context.Data;
using HRPortal.Persistence.Repositories.GenericRepository.WriteRepository;
using System.Security.Cryptography;
using System.Text;

namespace HRPortal.Persistence.Repositories.Repositories.AppUserRepository;

public class WriteAppUserRepository : WriteGenericRepository<AppUser>, IWriteAppUserRepository
{
    public WriteAppUserRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<AppUser> CreateUser(AppUser createUser)
    {
        createUser.PasswordHash = HashPassword(createUser.PasswordHash);
        await Table.AddAsync(createUser);
        await _context.SaveChangesAsync();
        return createUser;
    }
    public async Task<AppUser> UpdateUser(AppUser updateUser)
    {
        var user = await _context.AppUsers.FindAsync(updateUser.Id);
        if (user == null) throw new Exception("User not found");

        if (!string.IsNullOrEmpty(updateUser.PasswordHash) && updateUser.PasswordHash != user.PasswordHash)
        {
            updateUser.PasswordHash = HashPassword(updateUser.PasswordHash);
        }

        _context.Entry(user).CurrentValues.SetValues(updateUser);
        _context.Entry(user).Entity.ModifiedDate = DateTime.UtcNow;
        await _context.SaveChangesAsync();
        return updateUser;

    }

    public async Task<bool> DeleteUser(Guid id)
    {
        var user = await _context.AppUsers.FindAsync(id);
        if (user is not null)
        {
            Table.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public async Task<AppUser> ChangeStatus(Guid id)
    {
        var user = await _context.AppUsers.FindAsync(id);

        if (user is null)
        {
            throw new KeyNotFoundException("User not found in DB.");
        }

        user.Status = !user.Status;
        if (user.Status is not false)
        {
            user.ModifiedDate = DateTime.UtcNow;
        }
        else
        {
            user.DeletedDate = DateTime.UtcNow;
        }

        _context.AppUsers.Update(user);
        await _context.SaveChangesAsync();
        return user;
    }


    private string HashPassword(string password)
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
