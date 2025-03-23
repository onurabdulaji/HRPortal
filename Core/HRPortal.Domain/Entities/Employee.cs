﻿namespace HRPortal.Domain.Entities;

public class Employee : BaseEntity
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? NationalIdentityNumber { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? Gender { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }
    public string? Photo { get; set; }
    public DateTime? HireDate { get; set; }
    public DateTime? TerminationDate { get; set; }
    // AppUser
    public Guid AppUserId { get; set; }
    public AppUser? AppUser { get; set; }
}
