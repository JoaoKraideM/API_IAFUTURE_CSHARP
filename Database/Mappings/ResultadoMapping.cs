using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Database.Mappings
{
    public class ResultadoMapping : IEntityTypeConfiguration<ResultadoIA>
    {
        public void Configure(EntityTypeBuilder<ResultadoIA> builder)
        {
            builder
                .ToTable("tb_csharp_iafuture_resultados");

            builder
                .HasKey(x => x.IdResultadoIA);

            builder
                .Property(x => x.IdResultadoIA)
                .ValueGeneratedOnAdd();
        }
    }
}
