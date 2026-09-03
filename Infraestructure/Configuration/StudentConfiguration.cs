using ApiPruebaAudi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ApiPruebaAudi.Infraestructure.Configuration
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Student");

            builder.HasKey(c => c.StudentId);

            builder.Property(c => c.Name)
                   .HasMaxLength(15)
                   .IsRequired();

        }
    }
}
