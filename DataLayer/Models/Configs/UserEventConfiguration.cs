using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models.Configs
{
    public class UserEventConfiguration : IEntityTypeConfiguration<UserEvent>
    {
        public void Configure(EntityTypeBuilder<UserEvent> builder)
        {
            builder.HasKey(ue => new { ue.UserId, ue.EventId });

            builder.HasOne(ue => ue.User)
                   .WithMany(u => u.UserEvents)
                   .HasForeignKey(ue => ue.UserId);

            builder.HasOne(ue => ue.Event)
                   .WithMany(e => e.UserEvents)
                   .HasForeignKey(ue => ue.EventId);
        }
    }

}
