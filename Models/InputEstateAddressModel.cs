using DiplomenProekt.Data.Models;

namespace DiplomenProekt.Models
{
    public class InputEstateAddressModel
    {
        public int Id { get; set; }
        public Town City { get; set; }
        public string Neighbourhood { get; set; }
        public string Pics { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; internal set; }
        public ICollection<Estate> Estates { get; internal set; }
    }
    public enum Town { Search = 0, Shumen = 1, Varna = 2, Sofia = 3 }
}
