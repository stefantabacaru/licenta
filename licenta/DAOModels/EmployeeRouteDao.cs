using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace licenta.DAOModels
{
    public class EmployeeRouteDao
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public int EmployeeId { get; set; }
        public EmployeeDao Employee { get; set; }

        public int RouteId { get; set; }
        public RoutesDao Route { get; set; }
    }
}
