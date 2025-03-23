namespace HRPortal.Domain.Entities;

public class AppUser : BaseEntity
{
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string? PasswordHash { get; set; }
    // AppRole
    public Guid? AppRoleId { get; set; }
    public AppRole? AppRole { get; set; }
    // Employee
    public Guid EmployeeId { get; set; }
    public Employee? Employee { get; set; }
}
