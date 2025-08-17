using MarketHunter.WebAPI.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarketHunter.WebAPI.Models
{
    public class TradeDirection : BaseModelDto
    {
        public Guid TradeDirectionId { get; set; }
        public required string TradeDirectionName { get; set; }
    }

    public class TradeDirectionConfig : IEntityTypeConfiguration<TradeDirection>
    {
        public void Configure(EntityTypeBuilder<TradeDirection> entity)
        {
            entity.HasKey(t => t.TradeDirectionId).HasName("PK_TradeDirectionId");

            entity.Property(t=> t.TradeDirectionName).HasMaxLength(50);
        }
    }
}
