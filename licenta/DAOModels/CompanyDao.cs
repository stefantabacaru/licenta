using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace licenta.DAOModels
{
    public class CompanyDao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CompanyId { get; set; }

        public string Name { get; set; }

        public string Money { get; set; }

        public ICollection<EmployeeDao> Employees { get; set; } = new List<EmployeeDao>();
    }
}
