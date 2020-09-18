using ER.Domain.Enumerations;
using ER.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ER.Data.Mappings
{
    public class RecordMapping : IEntityTypeConfiguration<Record>
    {
        public void Configure(EntityTypeBuilder<Record> builder)
        {
            builder.ToTable("Records");
            builder.HasKey(r => r.Id);
        }
    }
}
