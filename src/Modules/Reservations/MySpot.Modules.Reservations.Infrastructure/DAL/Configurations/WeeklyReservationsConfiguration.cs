using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MySpot.Modules.Reservations.Core.Entities;
using MySpot.Modules.Reservations.Core.Types;
using MySpot.Modules.Reservations.Core.ValueObjects;
using MySpot.Shared.Abstractions.Domain;

namespace MySpot.Modules.Reservations.Infrastructure.DAL.Configurations;

internal sealed class WeeklyReservationsConfiguration : IEntityTypeConfiguration<WeeklyReservations>
{
    public void Configure(EntityTypeBuilder<WeeklyReservations> builder)
    {
        var jobTitleConverter = new ValueConverter<JobTitle, string>(x => x.Value,
            x => new JobTitle(x));

        builder.HasKey(x => x.Id);
        builder.HasIndex(x => new {x.UserId, x.Week}).IsUnique();
        builder.HasOne<User>().WithMany().HasForeignKey(x => x.UserId);

        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, v => new AggregateId(v));
        builder.Property(x => x.UserId)
            .HasConversion(x => x.Value, v => new UserId(v));
        builder.Property(x => x.Week)
            .HasConversion(x => x.To.Value, v => new Week(v));

        builder.Property(typeof(JobTitle), "_jobTitle")
            .HasConversion(jobTitleConverter)
            .HasColumnName(nameof(JobTitle));

        builder.HasMany(x => x.Reservations);
    }
}