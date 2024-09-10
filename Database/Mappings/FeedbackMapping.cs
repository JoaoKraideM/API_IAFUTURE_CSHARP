using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Database.Mappings
{
    public class FeedbackMapping : IEntityTypeConfiguration<FeedbackCliente>
    {
        public void Configure(EntityTypeBuilder<FeedbackCliente> builder)
        {
            builder
                .ToTable("tb_csharp_iafuture_feedbacks");

            builder
                .HasKey(x => x.IdFeedback);

            builder
                .Property(x => x.IdFeedback)
                .ValueGeneratedOnAdd();

        }
    }
}
