using DiplomenProekt.Data.Models;


namespace DiplomenProekt.Models
{
    public class InputEstateModel
    {
        public int Id { get; set; }
        public string MainPic { get; set; }
        public decimal Price { get; set; }
        public int Rooms { get; set; }
        public int AddressId { get; set; }     
        public string Description { get; set; }
        public string Pictures { get; set; }
        public EstateType EstateType { get; set; }
        public EstateStatus EstateStatus { get; set; }
        public double Area { get; set; }
        public int Floor { get; set; }
        public int MaxFloor { get; set; }
        public bool IsDeleted { get; internal set; }
        public EstateExtras Extras { get; internal set; }
        public int ExtrasId { get; internal set; }
        public Address Address { get; internal set; }
    }

}
