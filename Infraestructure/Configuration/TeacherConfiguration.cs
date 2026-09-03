using ApiPruebaAudi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ApiPruebaAudi.Infraestructure.Configuration
{
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.ToTable("Teacher");

            builder.HasKey(c => c.TeacherId);

            builder.Property(c => c.Name)
                   .HasMaxLength(50)
                   .IsRequired();
        }
    }
}
