using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSender.DAL
{
    public class EmailMessageConfiguration : IEntityTypeConfiguration<EmailMessage>
    {
        public void Configure(EntityTypeBuilder<EmailMessage> builder)
        {
            builder.ToTable("EmailSender");
            builder.HasKey(i => i.ID);
            builder.Property(i => i.ID)
                .ValueGeneratedOnAdd();

        }
    }
}
