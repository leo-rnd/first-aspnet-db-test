using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebPlanesDB.Models
{
    public class Airplane
    {//самолет
   ///     [DatabaseGenerated(DatabaseGeneratedOption.None)]
  //      [Display(Name = "Number")]
        public int AirplaneID { get; set; }
        public int Nbort { get; set; }
        public string type { get; set; }
        public int FlightID { get; set; }
        public DateTime dataInspection { get; set; }
        public int places { get; set; }
        public int TrassaID { get; set; }

        public virtual Flight Flight { get; set; }
        public virtual Trassa Trassa { get; set; }
    }
}
