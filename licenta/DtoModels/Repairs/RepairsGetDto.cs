using System;

namespace licenta.DtoModels.Repairs
{
    public class RepairsGetDto
    {
        public int RepairsId { get; set; }

        public DateTime Date { get; set; }

        public string Place { get; set; }

        public int CarToBeRepairedId { get; set; }

        public int EmployeeResponsibleId { get; set; }

        public string Problem { get; set; }

        public int RepairCost { get; set; }

        public int RepairDuration { get; set; }
    }
}
