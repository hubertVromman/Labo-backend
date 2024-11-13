using EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Configs {
    internal class GenreConfig : IEntityTypeConfiguration<Genre> {
        public void Configure(EntityTypeBuilder<Genre> builder) {
            builder.HasKey(a => a.GenreId);

            builder.Property(nameof(Genre.GenreId))
                .IsRequired()
                .ValueGeneratedOnAdd();
            builder.Property(nameof(Genre.NomGenre))
                .HasMaxLength(50)
                .IsRequired();

            builder.HasData(
                new Genre() {
                    GenreId = -1,
                    NomGenre = "Porno",
                },
                new Genre() {
                    GenreId = -2,
                    NomGenre = "Romantique",
                },
                new Genre() {
                    GenreId = -3,
                    NomGenre = "Thriller",
                }
            );
        }
    }
}
