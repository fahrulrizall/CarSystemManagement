using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class CarServices
    {
        [Key]
        public int Id { get; set; }
        public  string ServiceName { get; set; }
        public float Price { get; set; }
        public bool Status_Proposal { get; set; }
        public bool Status_Proses { get; set; }
        public Mechanics Mechanics { get; set; }
        [ForeignKey("Mechanics")]
        public int Id_Mechanics { get; set; }


        public CarOwner CarOwner { get; set; }
        [ForeignKey("CarOwner")]
        public int Id_CarOwner { get; set; }
        public DateTime Brought { get; set; }


        [NotMapped]
        public string NameOwner  { get; set; }
        [NotMapped]
        public string NameMechanic { get; set; }
    }
}
