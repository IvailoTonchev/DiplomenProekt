using DiplomenProekt.Data.Models;

namespace DiplomenProekt.DTO
{
    public class AddressChoiseDTO
    {
        public AddressChoiseDTO(int id, string town, string neighbourhood)
        {
            Id = id;
            Town = town;
            Neighbourhood = neighbourhood;
        }

        public int Id { get; set; }
        public string Town { get; set; }
        public string Neighbourhood { get; set; }
       

    }
}
