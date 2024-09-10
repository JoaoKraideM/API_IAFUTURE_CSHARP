using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Database.Mappings
{
    public class InteracaoMapping : IEntityTypeConfiguration<InteracaoCliente>
    {
        public void Configure(EntityTypeBuilder<InteracaoCliente> builder)
        {
            builder
                .ToTable("tb_csharp_iafuture_interacoes");

            builder
                .HasKey(x => x.IdInteracao);

            builder
                .Property(x => x.IdInteracao)
                .ValueGeneratedOnAdd();

        }
    }
}
