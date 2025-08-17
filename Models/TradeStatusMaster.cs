using MarketHunter.WebAPI.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarketHunter.WebAPI.Models
{
    public class TradeStatusMaster : BaseModelDto
    {
        public Guid TradeStatusId { get; set; }
        public required string TradeStatusName { get; set; }
    }

    public class TradeStatusMasterConfig : IEntityTypeConfiguration<TradeStatusMaster>
    {
        public void Configure(EntityTypeBuilder<TradeStatusMaster> entity)
        {
            entity.HasKey(t => t.TradeStatusId).HasName("PK_TradeStatusId");

            entity.Property(t => t.TradeStatusName).HasMaxLength(50);
        }
    }
}
