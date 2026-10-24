using System;
using Employesmhfdev.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Employesmhfdev.Data;

public class ApplicationDbContext : IdentityDbContext
{

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<LeaveApplication>()
        .HasOne(l=> l.Duration)
        .WithMany()
        .HasForeignKey(l=>l.DurationId)
        .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<LeaveApplication>()
        .HasOne(l=>l.Status)
        .WithMany()
        .HasForeignKey(l=>l.StatusId)
        .OnDelete(DeleteBehavior.Restrict);
    }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Designation> Designations { get; set; }
    public DbSet<Bank> Banks { get; set; }
    public DbSet<SystemCode> SystemCodes { get; set; }
    public DbSet<SystemCodeDetail> SystemCodeDetails { get; set; }
    public DbSet<LeaveType> LeaveTypes { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<LeaveApplication> LeaveApplications { get; set; }


}
