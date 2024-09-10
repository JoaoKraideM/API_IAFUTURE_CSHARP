using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Database.Mappings
{
    public class ContaMapping : IEntityTypeConfiguration<Conta>
    {
        public void Configure(EntityTypeBuilder<Conta> builder)
        {
            builder
                .ToTable("tb_csharp_iafuture_contas");

            builder
                .HasKey(x => x.IdConta);

            builder
                .Property(x => x.IdConta)
                .ValueGeneratedOnAdd();


        }
    }
}
