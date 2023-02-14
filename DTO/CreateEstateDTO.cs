using DiplomenProekt.Data.Models;
using MessagePack;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiplomenProekt.DTO
{
    public class CreateEstateDTO
    {       

        public string MainPic { get; set; }
        public decimal Price { get; set; }
        public int Rooms { get; set; }
        public int AddressId { get; set; }  
        public string Description { get; set; }
        public string Pictures { get; set; } //".jpg|
        public EstateType EstateType { get; set; }
        public EstateStatus EstateStatus { get; set; }
        public double Area { get; set; }
        public int Floor { get; set; }
        public int MaxFloor { get; set; }

        //create new extras for this estate
        #region Estras
        public bool HasElectricity { get; set; }
        public bool HasWater { get; set; }
        public bool HasGas { get; set; }
        public bool East { get; set; }
        public bool West { get; set; }
        public bool South { get; set; }
        public bool Elevator { get; set; }
        public bool North { get; set; }
        public bool Rent { get; set; }
        #endregion



    }
}
