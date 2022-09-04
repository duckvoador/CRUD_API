using Microsoft.EntityFrameworkCore;
using src.Models;

namespace src.Persistence;

public class Dbcontext : DbContext
{
    public Dbcontext
    (DbContextOptions<Dbcontext>options): base(options)
    {
        
    }
public DbSet<Person> Persons { get; set; }
public DbSet<Contract> Contracts {get; set;}

protected  override void OnModelCreating(ModelBuilder buldier){

    buldier.Entity<Person>(table =>{
        table.HasKey(e => e.Id);
        table
        .HasMany(e => e.contracts)
        .WithOne()
        .HasForeignKey(c => c.PersonId);

    });
    buldier.Entity<Contract>( table =>{
        table.HasKey(e => e.Id );
        
    });
}

}

