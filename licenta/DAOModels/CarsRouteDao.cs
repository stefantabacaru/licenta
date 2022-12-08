using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace licenta.DAOModels
{
    public class CarsRouteDao
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public int CarsId { get; set; }
        public CarsDao Car { get; set; }

        public int RouteId { get; set; }
        public RoutesDao Route { get; set; }
    }
}
