using MarketHunter.WebAPI.DTOs;
using MarketHunter.WebAPI.Migrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace MarketHunter.WebAPI.Models
{
    public class StrategyMaster : BaseModelDto
    {
        public Guid StrategyId { get; set; }

        [Required]
        public required string StrategyName { get; set; }
        public string? StrategyDesc { get; set; } = null;

        [Required]
        public required Guid TimeFrameId { get; set; }


        // Navigation Property (Many-to-One)
        public TimeFrameMaster TimeFrame { get; set; } = null!;
    }

    public class StrategyMasterConfig : IEntityTypeConfiguration<StrategyMaster>
    {
        public void Configure(EntityTypeBuilder<StrategyMaster> entity)
        { 
            entity.HasKey(t => t.StrategyId).HasName("PK_StrategyId");

            entity.Property(entity => entity.StrategyName).IsRequired().HasMaxLength(50);

            entity.Property(entity => entity.StrategyDesc).HasMaxLength(500);

            entity.HasOne(t => t.TimeFrame).WithMany().HasForeignKey(t => t.TimeFrameId).HasConstraintName("FK_StrategyMaster_TimeFrame_TimeFrameId");
        }
    }
}
