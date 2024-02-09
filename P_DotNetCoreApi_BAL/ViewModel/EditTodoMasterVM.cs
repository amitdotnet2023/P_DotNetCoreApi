using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_DotNetCoreApi_BAL.ViewModel
{
    public class EditTodoMasterVM
    {

        [Required]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Number { get; set; }
    }
}
