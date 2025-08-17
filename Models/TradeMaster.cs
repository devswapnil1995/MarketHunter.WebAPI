using MarketHunter.WebAPI.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarketHunter.WebAPI.Models
{
    public class TradeMaster : BaseModelDto
    {
        public Guid TradeMasterId { get; set; }
        public required Guid InstrumentId { get; set; }
        public required Guid StrategyId { get; set; }
        public required Guid TradeDirectionId { get; set; }
        public double EntryPrice { get; set; }
        public double TargetPrice { get; set; }
        public double StopLossPrice { get; set; }
        public double PnL { get; set; }
        public required Guid FinalTradeStatusId { get; set; }
        public bool IsDeleted { get; set; }
        public string? Remark { get; set; } = null;


        //FK Table
        public InstrumentMaster instrumentMaster { get; set; } = null!;
        public StrategyMaster strategyMaster { get; set; } = null!;
        public TradeDirection tradeDirection { get; set; } = null!;
        public TradeStatusMaster tradeStatusMaster { get; set; } = null!;

    }

    public class TradeMasterConfig : IEntityTypeConfiguration<TradeMaster>
    {
        public void Configure(EntityTypeBuilder<TradeMaster> entity)
        {
            entity.HasKey(t => t.TradeMasterId).HasName("PK_TradeMasterId");

            entity.HasOne(e => e.strategyMaster).WithMany().HasForeignKey(e => e.StrategyId).HasConstraintName("FK_TradeMaster_StrategyMaster_StrategyId").IsRequired();

            entity.HasOne(e => e.instrumentMaster).WithMany().HasForeignKey(e => e.InstrumentId).HasConstraintName("FK_TradeMaster_InstrumentMaster_InstrumentId").IsRequired();

            entity.HasOne(e => e.tradeDirection).WithMany().HasForeignKey(e => e.TradeDirectionId).HasConstraintName("FK_TradeMaster_TradeDirection_TradeDirectionId").IsRequired();

            entity.HasOne(e => e.tradeStatusMaster).WithMany().HasForeignKey(e => e.FinalTradeStatusId).HasConstraintName("FK_TradeMaster_TradeStatusMaster_FinalTradeStatusId").IsRequired();

            entity.Property(p => p.EntryPrice).HasPrecision(10, 2);

            entity.Property(p => p.TargetPrice).HasPrecision(10, 2);

            entity.Property(p => p.StopLossPrice).HasPrecision(10, 2);

            entity.Property(p => p.PnL).HasPrecision(10, 2);
        }
    }
}
