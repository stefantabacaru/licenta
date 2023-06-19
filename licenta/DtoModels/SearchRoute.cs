using System;

namespace licenta.DtoModels
{
    public class SearchRoute
    {
        public string Destination { get; set; }

        public string Departure { get; set; }

        public DateTime Day { get; set; }

        public int PasNumbers { get; set; }
    }
}
