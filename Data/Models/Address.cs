namespace DiplomenProekt.Data.Models
{
    public class Address
    {

        public Address()
        {
            Estates = new HashSet<Estate>();
        }
        
        
        
        public int Id { get; set; }
        public Town City { get; set; }
        public string Neighbourhood { get; set; }
        public string Pics { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Estate>Estates { get; set; }
        public bool IsDeleted { get; set; }
    }
}
