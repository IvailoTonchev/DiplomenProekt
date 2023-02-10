using DiplomenProekt.Data.Models;

namespace DiplomenProekt.Models
{
    public class InputEstateExtrasModel
    {
        public int Id { get; set; }
        public bool HasElectricity { get; set; }
        public bool HasWater { get; set; }
        public bool HasGas { get; set; }
        public bool East { get; set; }
        public bool West { get; set; }
        public bool South { get; set; }
        public bool Elevator { get; set; }
        public bool North { get; set; }
        public bool Rent { get; set; }
        public bool IsDeleted { get; internal set; }
        public Estate Estate { get; internal set; }
        public int EstateId { get; internal set; }
    }
}
