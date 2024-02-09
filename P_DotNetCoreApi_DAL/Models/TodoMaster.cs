using P_DotNetCoreApi_DAL.Contract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_DotNetCoreApi_DAL.Models
{
    public class TodoMaster : AuditableEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Number { get; set; }


    }
}
