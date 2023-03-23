using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySpot.Modules.ParkingSpots.Core.Entities;

namespace MySpot.Modules.ParkingSpots.Core.DAL.Configurations;

internal class ParkingSpotConfiguration : IEntityTypeConfiguration<ParkingSpot>
{
    public void Configure(EntityTypeBuilder<ParkingSpot> builder)
    {
        builder.HasKey(x => x.Id);
    }
}