using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets
{
    public class Ticket
    {
        public string CityFrom { get; }
        public string CityTo { get; }
        public string Transport { get; }
        public string Seat { get; }
        public string NumberOfTransport { get; }
        public Ticket NextTicket { get; set; }

        public Ticket(string[] ticketData)
        {
            CityFrom = ticketData[0];
            CityTo = ticketData[1];
            Transport = ticketData[2];
            Seat = ticketData[3];
            NumberOfTransport = ticketData[4];
        }

        public static Ticket GetStartTicket(List<Ticket> tickets)
        {
            foreach (var ticket in tickets)
            {
                if (ticket.IsStartTicket(tickets))
                    return ticket;
            }
            return null;
        }

        public bool IsStartTicket(List<Ticket> tickets)
        {
            foreach (var ticket in tickets)
            {
                if (ticket.NextTicket == this)
                    return false;
            }
            return true;
        }

        public Ticket GetNextTicket(List<Ticket> tickets)
        {
            foreach(var ticket in tickets)
            {
                if (CityTo == ticket.CityFrom)
                {
                    return ticket;
                }
            }
            return null;
        }

        public override string ToString()
        {
            switch (Transport)
            {
                case "Bus":
                    return string
                    .Format("Доберитесь до автобусной остановки и сядьте на автобус №{0}, место:{1}, и следуйте до города {2}", NumberOfTransport, Seat, CityTo);

                case "Train":
                    return string
                    .Format("Доберитесь до железнодорожной станции и сядьте на поезд №{0}, место:{1}, и следуйте до города {2}", NumberOfTransport, Seat, CityTo);

                case "Plane":
                    return string
                    .Format("Доберитесь до аэропорта и сядьте на рейс №{0}, место:{1}", NumberOfTransport, Seat);

                case "Ship":
                    return string
                    .Format("Доберитесь до порта и сядьте на корабль №{0}, каюта:{1}", NumberOfTransport, Seat);

                default:
                    return string
                    .Format("Доберитесь до станции для своего транспорта и сядьте на рейс №{0}, место:{1} и следуйте до города {2}", NumberOfTransport, Seat, CityTo);
            }
        }
    }
}