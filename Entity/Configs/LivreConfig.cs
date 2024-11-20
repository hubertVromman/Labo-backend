using EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Configs {
    internal class LivreConfig : IEntityTypeConfiguration<Livre> {
        public void Configure(EntityTypeBuilder<Livre> builder) {
            builder.HasKey(l => l.LivreId);

            builder.Property(nameof(Livre.LivreId))
                .IsRequired()
                .ValueGeneratedOnAdd();
            builder.Property(nameof(Livre.ISBN));
            builder.Property(nameof(Livre.Titre))
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(nameof(Livre.DateParution))
                .IsRequired();
            builder.Property(nameof(Livre.GenreId))
                .IsRequired();
            builder.Property(nameof(Livre.PrixVente))
                .HasColumnType("DECIMAL(9, 2)");

            builder.HasIndex(l => l.ISBN).IsUnique();

            builder
                .HasOne(l => l.Genre)
                .WithMany(g => g.Livres)
                .HasForeignKey(l => l.GenreId)
                .HasConstraintName("FK_Livre_Genre")
                .IsRequired();

            builder.HasData(
                new Livre() {
                    LivreId = -1,
                    ISBN = "1234",
                    Titre = "Coup de feu",
                    DateParution = new DateOnly(2015, 10, 25),
                    GenreId = -3,
                    PrixVente = 19.99M
                }, 
                new Livre() {
                    LivreId = -2,
                    ISBN = "1235",
                    Titre = "Coup de foudre",
                    DateParution = new DateOnly(2015, 10, 25),
                    GenreId = -2,
                    PrixVente = 19.99M,
                },
                new Livre() {
                    LivreId = -3,
                    ISBN = "1236",
                    Titre = "Coup de fouet",
                    DateParution = new DateOnly(2015, 10, 25),
                    GenreId = -1,
                    PrixVente = 19.99M,
                }
            );
        }
    }
}