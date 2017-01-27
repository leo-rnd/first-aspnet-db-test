using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebPlanesDB.Models;

namespace WebPlanesDB.ViewModels
{
    public class FlightIndexData
    {
       public IEnumerable<Flight> Flights { get; set; }
       public IEnumerable<Airplane> Airplanes { get; set; }
      // public IEnumerable<int> Numbers = new List<int>();
    }
}