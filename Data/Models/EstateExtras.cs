using System.ComponentModel.DataAnnotations.Schema;

namespace DiplomenProekt.Data.Models
{
    public class EstateExtras
    {
        public int Id { get; set; }
        public bool HasElectricity { get; set; }
        public bool HasWater { get; set; }
        public bool HasGas { get; set; }
        public bool East { get; set; }
        public bool West { get; set; }
        public bool South { get; set; }
        public bool North { get; set; }
        [ForeignKey(nameof(Estate))]
        public int EstateId { get; set; }
        public virtual Estate Estate { get; set; }
    }
}
