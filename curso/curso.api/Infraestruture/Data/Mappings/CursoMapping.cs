using curso.api.Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace curso.api.Infraestruture.Data.Mappings
{
    public class CursoMapping : IEntityTypeConfiguration<Curso>
    {
        public void Configure(EntityTypeBuilder<Curso> builder)
        {
            builder.ToTable("TB_CURSO");
            builder.Haskey(p => p.Codigo);
            builder.Property(p => p.Codigo).ValueGenatedOnAdd();
            builder.Property(p => p.Nome);
            builder.Property(p => p.Descricao);
            builder.Property(p => p.Usuario)
                .WithMany().HasForeignKey(fk => fk.CodigoUsuario);
        }
    }
}