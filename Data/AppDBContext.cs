using MarketHunter.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MarketHunter.WebAPI.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }
        public DbSet<TimeFrameMaster> TimeFrameMaster { get; set; }
        public DbSet<InstrumentMaster> InstrumentMaster { get; set; }
        public DbSet<StrategyMaster> StrategyMaster { get; set; }
        public DbSet<TradeStatusMaster> TradeStatusMaster { get; set; }
        public DbSet<TradeDirection> TradeDirection { get; set; }
        public DbSet<TradeMaster> TradeMaster { get; set; }
        public DbSet<TradeDetail> TradeDetail { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TimeFrameMasterConfig());
            
            modelBuilder.ApplyConfiguration(new InstrumentMasterConfig());

            modelBuilder.ApplyConfiguration(new StrategyMasterConfig());

            modelBuilder.ApplyConfiguration(new TradeStatusMasterConfig());

            modelBuilder.ApplyConfiguration(new TradeDirectionConfig());

            modelBuilder.ApplyConfiguration(new TradeMasterConfig());

            modelBuilder.ApplyConfiguration(new TradeDetailConfig());
        }
    }
}
