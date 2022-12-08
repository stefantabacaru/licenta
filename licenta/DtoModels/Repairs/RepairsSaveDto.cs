using System;
using System.ComponentModel.DataAnnotations;

namespace licenta.DtoModels.Repairs
{
    public class RepairsSaveDto
    {
        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Place { get; set; }

        [Required]
        public int CarToBeRepairedId { get; set; }

        [Required]
        public int EmployeeResponsibleId { get; set; }

        public string Problem { get; set; }

        public int RepairCost { get; set; }

        public int RepairDuration { get; set; }
    }
}
