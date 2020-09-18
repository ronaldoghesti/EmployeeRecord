using ER.Domain.Enumerations;
using ER.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ER.Data.Mappings
{
    public class RecordTypeMapping : IEntityTypeConfiguration<RecordTypeEnumeration>
    {
        public void Configure(EntityTypeBuilder<RecordTypeEnumeration> builder)
        {
            builder.ToTable("RecordType");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Name)
                .IsRequired()
                .HasColumnType("varchar(10)");

            builder.HasMany<Record>()
                .WithOne(r => r.Type);
        }
    }
}
