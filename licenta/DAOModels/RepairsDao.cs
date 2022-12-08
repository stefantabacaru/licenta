using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace licenta.DAOModels
{
    public class RepairsDao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RepairId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Place { get; set; }

        public CarsDao CarToBeRepaired { get; set; }

        [Required]
        public int CarToBeRepairedId { get; set; }

        public EmployeeDao EmployeeResponsible { get; set; }

        [Required]
        public int EmployeeResponsibleId { get; set; }

        public string Problem { get; set; }

        public int RepairCost { get; set; }

        public int RepairDuration { get; set; }
    }
}
