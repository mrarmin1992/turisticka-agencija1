using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class ZnamenitostConfiguration : IEntityTypeConfiguration<Znamenitost>
    {
        public void Configure(EntityTypeBuilder<Znamenitost> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Naziv).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Opis).IsRequired().HasMaxLength(200);
            builder.Property(p => p.PictureUrl).IsRequired();
            
             builder.HasOne(s => s.Veomaznamenito).WithMany().HasForeignKey(p=>p.VeomaznamenitoId);
              builder.HasOne(c => c.Nezaobilazno).WithMany().HasForeignKey(p=>p.NezaobilaznoId);
        }
    }
}