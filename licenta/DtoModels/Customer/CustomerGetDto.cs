namespace licenta.DtoModels.Customer
{
    public class CustomerGetDto
    {
        public int CustomerId { get; set; } 

        public string CustomerName { get; set; }

        public int CustomerRouteId { get; set; }

        public string CustomerPhoneNumber { get; set; }

        public string CustomerEmail { get; set; }
    }
}
