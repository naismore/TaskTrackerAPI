using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task = Domain.Models.Task;

namespace Infrastructure.Database.Configurations;

public class TaskConfiguration : IEntityTypeConfiguration<Task>
{
    public void Configure(EntityTypeBuilder<Task> builder)
    {
        builder.ToTable("tasks");  
        
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        
    }
}