using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebPlanesDB.Models
{
    public class Flight 
    {//полет
        public int FlightID { get; set; }
        public int NFlight  { get; set; }
        public int Nroute { get; set; }
        public DateTime timeOut { get; set; }
        public DateTime timeIn { get; set; }
        public int Numbers { get; set; }
       // public int idAirplane { get; set; }
        public virtual ICollection<Airplane> Airplanes { get; set; }

	}
}
