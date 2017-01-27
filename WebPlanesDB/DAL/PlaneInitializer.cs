using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebPlanesDB.Models;

namespace WebPlanesDB.DAL
{
    public class PlaneInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<PlaneContext>
    {
        protected override void Seed(PlaneContext context)
        {
            var flights = new List<Flight>
            {
            new Flight{FlightID=1,NFlight=1,Nroute=1,timeOut=DateTime.Parse("19:30"),timeIn=DateTime.Parse("22 : 30"),Numbers=0},//AirplanIDe=1},
            new Flight{FlightID=2,NFlight=2,Nroute=2,timeOut=DateTime.Parse("9:30"),timeIn=DateTime.Parse("22 : 30"),Numbers=0},//AirplaneID=1},
            new Flight{FlightID=3,NFlight=3,Nroute=3,timeOut=DateTime.Parse("18:30"),timeIn=DateTime.Parse("22 : 30"),Numbers=0}//AirplaneID=2},
            };
            flights.ForEach(s => context.Flights.Add(s));
            context.SaveChanges();

            var routes = new List<Route>
            {
            new Route{from_="Rostov-on-Don",to_="Sympheropol",data1=DateTime.Parse("2016.03.12"),data2=DateTime.Parse("2016.03.02"),Distanse=10000},
            new Route{from_="Rostov-on-Don",to_="Habarovsk",data1=DateTime.Parse("2016.03.05"),data2=DateTime.Parse("2016.03.06"),Distanse=200000},
            new Route{from_="Rostov-on-Don",to_="Simpheropol",data1=DateTime.Parse("2016.03.05"),data2=DateTime.Parse("2016.03.05"),Distanse=1000}
            };
            routes.ForEach(s => context.Routes.Add(s));
            context.SaveChanges();

            var trassas = new List<Trassa>
            {
            new Trassa{TrassaID=1,x=100,y=200,h=100,V=800,time=DateTime.Parse("2016.03.02")},//,IDAirplane=1},
            new Trassa{TrassaID=2,x=2100,y=200,h=100,V=700,time=DateTime.Parse("2016.03.06")},//IDAirplane=2},
            new Trassa{TrassaID=3,x=2100,y=200,h=100,V=700,time=DateTime.Parse("2016.03.05")}//IDAirplane=1},
            };
            trassas.ForEach(s => context.Trassas.Add(s));
            context.SaveChanges();

            var airplanes = new List<Airplane>
            {
            new Airplane{ Nbort=232,type="TY - 144",FlightID=1,dataInspection=DateTime.Parse("2016.02.10"),places=100,TrassaID=2},
            new Airplane{ Nbort=132,type="AH - 135",FlightID=2,dataInspection=DateTime.Parse("2016.01.30"),places=60,TrassaID=3},
            new Airplane{ Nbort=136,type="TY - 144",FlightID=1,dataInspection=DateTime.Parse("2016.02.10"),places=60,TrassaID=1}
            };
            airplanes.ForEach(s => context.Airplanes.Add(s));
            context.SaveChanges();
        }
    }
}