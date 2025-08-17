using MarketHunter.WebAPI.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace MarketHunter.WebAPI.Models
{
    public class TimeFrameMaster : BaseModelDto
    {
        public Guid TimeFrameId { get; set; }

        [Required]
        public required string TimeFrameName { get; set; }

    }

    public class TimeFrameMasterConfig : IEntityTypeConfiguration<TimeFrameMaster>
    {
        public void Configure(EntityTypeBuilder<TimeFrameMaster> entity)
        {
            //Create Primary Key
            entity.HasKey(t => t.TimeFrameId).HasName("PK_TimeFrameId");
            
            entity.Property(t => t.TimeFrameName).HasMaxLength(50);
        }
    }
}
