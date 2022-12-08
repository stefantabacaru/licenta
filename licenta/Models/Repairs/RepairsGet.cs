using System;

namespace licenta.Models.Repairs
{
    public class RepairsGet
    {
        public int RepairId { get; set; }

        public DateTime Date { get; set; }

        public string Place { get; set; }

        public int CarToBeRepairedId { get; set; }

        public int EmployeeResponsibleId { get; set; }

        public string Problem { get; set; }

        public int RepairCost { get; set; }

        public int RepairDuration { get; set; }
    }
}
