namespace curso.api.Infraestruture.Data.Mappings
{
    public class AlunoMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("TB_USUARIO");
            builder.Haskey(p => p.Codigo);
            builder.Property(p => p.Codigo).ValueGenatedOnAdd();
            builder.Property(p => p.Login);
            builder.Property(p => p.Senha);
            builder.Property(p => p.Email);
        }
    }
}