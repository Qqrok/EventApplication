using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models.Configs
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Title).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Date).IsRequired();

            builder.HasOne(e => e.Location)
                   .WithMany(l => l.Events)
                   .HasForeignKey(e => e.LocationId);

            builder.HasMany(e => e.Tickets)
                   .WithOne(t => t.Event)
                   .HasForeignKey(t => t.EventId);
        }
    }

}
