using EntityFramework.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Configs {
    internal class PretLivreConfig : IEntityTypeConfiguration<PretLivre> {
        public void Configure(EntityTypeBuilder<PretLivre> builder) {
            builder.HasKey(el => new { el.PretId, el.LivreId });

            builder
                .HasOne(el => el.Pret)
                .WithMany(e => e.PretLivre)
                .HasForeignKey(fk => fk.PretId)
                .HasConstraintName("FK_PretLivre_Pret");

            builder
                .HasOne(el => el.Livre)
                .WithMany(l => l.PretLivre)
                .HasForeignKey(fk => fk.LivreId)
                .HasConstraintName("FK_PretLivre_Livre");
        }
    }
}
