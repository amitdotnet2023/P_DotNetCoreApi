using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_DotNetCoreApi_DAL.Contract
{
    public class AuditableEntity
    {
        public DateTime CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
