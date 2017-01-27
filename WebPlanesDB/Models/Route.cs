using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
  
namespace WebPlanesDB.Models{
    public class  Route
    {//Маршрут
        public int ID { get; set; }
        public string from_ { get; set; }
        public string to_  { get; set; }
        public DateTime data1 { get; set; }
        public DateTime data2 { get; set; }
        public int Distanse { get; set; }
      //  public virtual ICollection<Enrollment> Enrollments { get; set; }
	}
}
