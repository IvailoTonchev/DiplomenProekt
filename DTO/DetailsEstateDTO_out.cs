using DiplomenProekt.Data.Models;
using DiplomenProekt.Models;

namespace DiplomenProekt.DTO
{
    public class DetailsEstateDTO_out
    {

        public Estate Estate { get; set; }

        public ICollection<MiniUserData> AllUsersData { get; set; }

    }


    public class MiniUserData
    {
        public string Id { get; set; }
        public string UserName { get; set; }
    }

}