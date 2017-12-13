using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.Domain;
using System.Data.Entity.ModelConfiguration;
using Exam.Domain.User;

namespace Exam.Data.Mapping.Test
{
    public class TestMap : EntityTypeConfiguration<User>
    {
    }
}
