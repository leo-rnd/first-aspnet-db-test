using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebPlanesDB.Models{
    public class Trassa
	{
        public int TrassaID { get; set; }
        public int x  { get; set; }
        public int y { get; set; }
        public int h { get; set; }
        public int V { get; set; }
        public DateTime time { get; set; }
       // public int IDAirplane { get; set; }
        public virtual ICollection<Airplane> Airplanes { get; set; }
   
	}
}
