using MarketHunter.WebAPI.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarketHunter.WebAPI.Models
{
    public class TradeDetail : BaseModelDto
    {
        public Guid TradeDetailId { get; set; }
        public Guid TradeMasterId { get; set; }
        public Guid TradeStatusId { get; set; }


        //FK
        public TradeMaster tradeMaster { get; set; } = null!;
        public TradeStatusMaster tradeStatusMaster { get; set; } = null!;
    }

    public class TradeDetailConfig : IEntityTypeConfiguration<TradeDetail>
    {
        public void Configure(EntityTypeBuilder<TradeDetail> entity)
        {
            entity.HasKey(entity => entity.TradeDetailId).HasName("PK_TradeDetailId");

            entity.HasOne(e => e.tradeMaster).WithMany().HasForeignKey(e => e.TradeMasterId).HasConstraintName("FK_TradeDetail_TradeMaster_TradeMasterId");

            entity.HasOne(e => e.tradeStatusMaster).WithMany().HasForeignKey(e => e.TradeStatusId).HasConstraintName("FK_TradeDetail_TradeStatusMaster_Trade");
        }
    }
}
