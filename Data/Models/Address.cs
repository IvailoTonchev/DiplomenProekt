namespace DiplomenProekt.Data.Models
{
    public class Address
    {
        public int Id { get; set; }
        public Town City { get; set; }
        public string Neighbourhood { get; set; }
        public string Pics { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Estate>Estates { get; set; }
    }
    public enum Town {Search=0,Shumen=1,Varna=2,Sofia=3 }
}
