using ApiPruebaAudi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ApiPruebaAudi.Infraestructure.Configuration
{
    public class NoteConfiguration : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.ToTable("Note");

            builder.HasKey(x => x.NoteId);

            builder.Property(x => x.Value)
                   .IsRequired();

            builder.HasOne(x => x.Student)
                   .WithMany(x => x.Notes)
                   .HasForeignKey(x => x.StudentId);

            builder.HasOne(x => x.Teacher)
                   .WithMany(x => x.Notes)
                   .HasForeignKey(x => x.TeacherId);
        }
    }
}
