using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets
{
    class Program
    {
        static void Main(string[] args)
        {
            var tickets = new List<Ticket>();
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                tickets.Add(new Ticket(Console.ReadLine().Split()));
            }

            foreach(var ticket in tickets)
            {
                ticket.NextTicket = ticket.GetNextTicket(tickets);
            }

            var currentTicket = Ticket.GetStartTicket(tickets);

            while (currentTicket != null)
            {
                Console.WriteLine(currentTicket);
                currentTicket = currentTicket.NextTicket;
            }
        }
    }
}