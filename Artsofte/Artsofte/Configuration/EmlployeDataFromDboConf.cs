using Artsofte.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Artsofte.Configuration
{
    public class EmlployeDataFromDboConf : IEntityTypeConfiguration<EmployeeDataFromDb>
    {
        public void Configure(EntityTypeBuilder<EmployeeDataFromDb> builder)
        {
            builder.HasNoKey();
           
        }
    }
}
