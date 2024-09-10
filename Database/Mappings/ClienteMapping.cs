using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Database.Mappings
{
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder
                .ToTable("tb_csharp_iafuture_clientes");

            builder
                .HasKey(x => x.IdCliente);

            builder
                .Property(x => x.IdCliente)
                .ValueGeneratedOnAdd();
        }
    }
}
