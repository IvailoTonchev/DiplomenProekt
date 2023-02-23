using DiplomenProekt.Data.Models;
using System.IO.Pipes;

namespace DiplomenProekt.DTO
{
    public class AddressChoiseDTO
    {
        public AddressChoiseDTO(int id, string town, string neighbourhood, string description,string pics)
        {
            Id = id;
            Town = town;
            Neighbourhood = neighbourhood;
            Pics = pics;
            Description = description;
        }

        public int Id { get; set; }
        public string Town { get; set; }
        public string Neighbourhood { get; set; }
        public string Pics { get; set; }
        public string Description { get; set; }


    }
}
