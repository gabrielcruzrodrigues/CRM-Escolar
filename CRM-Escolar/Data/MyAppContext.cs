using CRM_Escolar.Domains;
using Microsoft.EntityFrameworkCore;

namespace CRM_Escolar.Data;

public class MyAppContext : DbContext
{
    public MyAppContext(DbContextOptions<MyAppContext> options) : base(options)
    { }

    public DbSet<Student>? Students { get; set; }
    public DbSet<Responsible> Responsibles { get; set; }
    public DbSet<Medication> Medications { get; set; }
    public DbSet<School> Schools { get; set; }
    public DbSet<Illness> Illnesses { get; set; }
}
