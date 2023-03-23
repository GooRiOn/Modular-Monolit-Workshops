using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySpot.Modules.Availability.Core.Entities;
using MySpot.Modules.Availability.Core.ValueObjects;
using MySpot.Shared.Abstractions.Domain;

namespace MySpot.Modules.Availability.Infrastructure.DAL.Configurations;

internal sealed class ResourceConfiguration : IEntityTypeConfiguration<Resource>
{
    public void Configure(EntityTypeBuilder<Resource> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasConversion(x => x.Value, v => new AggregateId(v));
        builder.Property(x => x.Capacity).HasConversion(x => x.Value, v => new Capacity(v));
        builder.Property(x => x.Tags)
            .HasConversion(x => string.Join(",", x.Select(c => c.Value)),
                v => v.Split(',', StringSplitOptions.None).Select(x => new Tag(x)).ToHashSet())
            .Metadata
            .SetValueComparer(GetValueComparer());

        static ValueComparer GetValueComparer() => new ValueComparer<IEnumerable<Tag>>(
            (c1, c2) => c2 != null && c1 != null && c1.SequenceEqual(c2),
            c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
            c => c.ToList());
    }
}