using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HeavyApps.Blog.Infrastructure.Data.Mappings
{
    public class AutorMapping : IEntityTypeConfiguration<HeavyApps.Blog.Domain.Model.Autor>
    {
        public void Configure(EntityTypeBuilder<HeavyApps.Blog.Domain.Model.Autor> builder)
        {
            builder.ToTable("Autores");

            builder.HasKey(a => a.ID);

            builder.Property(a => a.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(a => a.Email)
                //.IsRequired()
                .HasMaxLength(100);

            builder.Property(a => a.Biografia)
                .HasMaxLength(500);

            builder.HasMany(a => a.Posts)
                .WithOne(p => p.Autor)
                .HasForeignKey(p => p.AutorID);
        }
    }


}
