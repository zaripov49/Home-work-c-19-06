using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastucture.Data;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<Book> Books { get; set; }

    

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.Entity<Student>()
            // .HasMany(s => s.StudentGroups)
            // .WithOne(sg => sg.Student)
            // .HasForeignKey(sg => sg.StudentId);


}
