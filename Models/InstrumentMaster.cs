using MarketHunter.WebAPI.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace MarketHunter.WebAPI.Models
{
    public class InstrumentMaster : BaseModelDto
    {
        public Guid InstrumentId { get; set; }

        [Required]
        public required string InstrumentName { get; set; }
        public string? InstrumentKey { get; set; } = null;
        public string? InstrumentCode { get; set; } = null;
    }

    public class InstrumentMasterConfig : IEntityTypeConfiguration<InstrumentMaster>
    {
        public void Configure(EntityTypeBuilder<InstrumentMaster> entity)
        {
            entity.HasKey(t => t.InstrumentId).HasName("PK_InstrumentId");

            entity.Property(entity => entity.InstrumentName).HasMaxLength(50);

            entity.Property(entity => entity.InstrumentKey).HasMaxLength(10);
            
            entity.Property(entity => entity.InstrumentCode).HasMaxLength(10);
        }
    }
}
