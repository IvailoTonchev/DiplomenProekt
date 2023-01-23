using System.ComponentModel.DataAnnotations.Schema;

namespace DiplomenProekt.Data.Models
{
    public class Estate
    {
        public int Id { get; set; }
        public string MainPic { get; set; }
        public decimal Price { get; set; }
        public int Rooms { get; set; }
        public int AddressId { get; set; }
        public virtual Address Address  { get; set; }
        public string Description { get; set; }
        public string Pictures { get; set; }
        public EstateType EstateType { get; set; }
        public EstateStatus EstateStatus { get; set; }
        public double Area { get; set; }
        public int Floor { get; set; }
        public int MaxFloor { get; set; }
        [ForeignKey(nameof(EstateExtras))]
        public int ExtrasId { get; set; }
        public virtual EstateExtras Extras { get; set; }
        public bool IsDeleted { get; set; }
    }
    public enum EstateType {Unchosen=0,Garage=1,Flat=2,House=3,Industrial=4 }
    public enum EstateStatus {Available=0,Sold=1,Taken=2 }
}
