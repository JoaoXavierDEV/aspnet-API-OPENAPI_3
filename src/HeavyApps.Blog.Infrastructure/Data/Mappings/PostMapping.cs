using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HeavyApps.Blog.Infrastructure.Data.Mappings
{
    public class PostMapping : IEntityTypeConfiguration<HeavyApps.Blog.Domain.Model.Post>
    {
        public void Configure(EntityTypeBuilder<HeavyApps.Blog.Domain.Model.Post> builder)
        {
            builder.ToTable("Posts");

            builder.HasKey(p => p.ID);

            builder.Property(p => p.Titulo)
                //.IsRequired()
                .HasMaxLength(200);

            builder.Property(p => p.SubTitulo)

                .HasMaxLength(200);

            builder.Property(p => p.Corpo);
            //.IsRequired();

            builder.Property(p => p.DataPublicacao);
            //.IsRequired()
            //.HasDefaultValueSql("CURRENT_TIMESTAMP");

            //builder.Property(p => p.Fonte)
            //    .HasMaxLength(200);

            builder.HasOne(p => p.Autor)
                .WithMany(a => a.Posts)
                .HasForeignKey(p => p.AutorID);

            //builder.Property(p => p.Imagem)
            //    .HasMaxLength(200);

            //builder.Property(p => p.Categoria)
            //    .HasMaxLength(100);

            //builder.Property(p => p.Resumo)
            //    .HasMaxLength(500);

            //builder.Property(p => p.Link)
            //    .HasMaxLength(200);

            builder.Property(p => p.DataUltimaAtualizacao)
                //.IsRequired()
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(p => p.Likes)
                .HasDefaultValue(0);

            builder.Property(p => p.Status)
                .HasConversion(
                    v => StatusPostEnumConverter.ConvertToDatabaseValue(v),
                    v => StatusPostEnumConverter.ConvertFromDatabaseValue(v));
            //.IsRequired();

        }
    }

    public class StatusPostEnumConverter
    {
        public static string ConvertToDatabaseValue(HeavyApps.Blog.Domain.Enum.StatusPostEnum status)
        {
            return status.ToString();
        }
        public static HeavyApps.Blog.Domain.Enum.StatusPostEnum ConvertFromDatabaseValue(string value)
        {
            return Enum.TryParse(value, out HeavyApps.Blog.Domain.Enum.StatusPostEnum status) ? status : HeavyApps.Blog.Domain.Enum.StatusPostEnum.Pendente;
        }
    }
}
