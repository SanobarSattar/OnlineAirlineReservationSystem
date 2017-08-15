using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OnlineAirlineReservationSystem.Controllers
{
    public class OnlineAirlineReservationSystemController : ApiController
    {
        AirlineReservationSystemEntities db = new AirlineReservationSystemEntities();
        [HttpGet]
        [Route("api/AirlineReservationSystemController/Registration")]
        public bool Registration(Registration r)
        {
            if (r != null)
            {
                Registration rg = new Registration();
                rg.FirstName = r.FirstName;
                rg.LastName = r.LastName;
                rg.DateOfBirth = r.DateOfBirth;
                rg.Email = r.Email;
                rg.Password = r.Password;
                rg.Contact = r.Contact;
                rg.Gender = r.Gender;
                db.Registrations.Add(rg);
                db.SaveChanges();

                return true;
            }
            return false;

        }
        [HttpGet]
        [Route("Api/AirlineReservationSystem/ReservationForm")]
        public bool Reservation(Reservation re)
        {
            if (re != null)
            {
                db.Reservations.Add(re);
                db.SaveChanges();
                return true;
            }

            return false;
        }
        [HttpGet]
        [Route("Api/AirlineReservationSystem/OnlineTransaction")]
        public bool Transaction(Transaction t)
        {
            if (t != null && t.Amount > 0)
            {
                db.Transactions.Add(t);
                db.SaveChanges();
                return true;
            }
            return false;
        }
        [HttpGet]
        [Route("Api/AirlineReservationSystem/FlightStatus")]
        public string FlightStatus(int reservationId)
        {
            var reservation = db.Reservations.FirstOrDefault(r => r.Id == reservationId);
            return reservation.FlightStatus;
        }
        [HttpGet]
        [Route("Api/AirlineReservationSystem/WebCheckIn")]
        public string WebCheckIn(Reservation rn)
        {
            Reservation res = new Reservation();
            res.TicketNo = rn.TicketNo;
            db.Reservations.Add(res);
            db.SaveChanges();
            return "";
        }
        [HttpGet]
        [Route("Api/AirlineReservationSystemCancelReservation")]
        public bool CancelReservation(int reservationId)
        {
            Reservation r = db.Reservations.Find(reservationId);
            r.FlightStatus = "Canceled";
            db.Entry(r).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }
        
    }
}
