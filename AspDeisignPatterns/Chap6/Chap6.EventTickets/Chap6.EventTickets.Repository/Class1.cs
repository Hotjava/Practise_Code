using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Chap6.EventTickets.Repository.Properties;
using EventTickets.Model;

namespace Chap6.EventTickets.Repository
{
    public class EventRepository:IEventRepository 
    {
        private string connectionString
        {
            get { return Settings.Default.ConnectionString; }
        }

        #region Implementation of IEventRepository

        public Event FindBy(Guid id)
        {
            Event Event = default(Event);

            string queryString = "SelEct * From dbo.events where id=@EventId" +
                                 "SELECT * FROM dbo.purchasedTickets WHERE EventId=@EventId"
                                 + "SELECT * FROM dbo.ReservedTickets WHERE EventId=@EventId";

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = queryString;
                cmd.Parameters.AddWithValue("@EventId", id.ToString());
                cn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if(reader.HasRows)
                    {
                        reader.Read();

                        Event = new Event();
                        Event.PurchasedTickets = new List<TicketPurchase>();
                        Event.ReservedTickets = new List<TicketReservation>();
                        Event.Allocation = int.Parse(reader["Allocation"].ToString());
                        Event.Id = new Guid(reader["Id"].ToString());
                        Event.Name = reader["Name"].ToString();

                        if(reader.NextResult())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    TicketPurchase ticketPurchase = new TicketPurchase();
                                    ticketPurchase.Id= new Guid(reader["Id"].ToString());
                                    ticketPurchase.Event = Event;
                                    ticketPurchase.TicketQuantity = int.Parse(reader["TicketQuantity"].ToString());
                                    Event.PurchasedTickets.Add(ticketPurchase);

                                }
                            }
                            
                        }
                        if(reader.NextResult())
                        {
                            if(reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    TicketReservation ticketReservation = new TicketReservation();
                                    ticketReservation.Id = new Guid(reader["Id"].ToString());
                                    ticketReservation.Event = Event;
                                    ticketReservation.ExpiryTime = DateTime.Parse(reader["ExpiryTime"].ToString());
                                    ticketReservation.TicketQuantity =int.Parse(reader["TicketQuantity"].ToString());
                                    ticketReservation.HasBeenRedeemed = bool.Parse(reader["HasBeenRedeemed"].ToString());
                                    Event.ReservedTickets.Add(ticketReservation);
                                }
                            }
                        }


                    }
                }
            }
            return Event;
        }

        public void Save(Event eventEntry)
        {
            //code to save back into database

            RemovePurchasedAndReservedTicketFrom(eventEntry);
            InsertPuchasedTicketFrom(eventEntry);
            InsertReservedTicketFrom(eventEntry);

        }

        private void RemovePurchasedAndReservedTicketFrom(Event eventEntry)
        {
           string deleteSQL = "DELETE PurchasedTickets WHERE EventId = @EventId; " +
                                "DELETE ReservedTickets WHERE EventId = @EventId;";
            using (SqlConnection connection =
            new SqlConnection(connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = deleteSQL;
                SqlParameter Idparam =
                    new SqlParameter("@EventId", eventEntry.Id.ToString());
                command.Parameters.Add(Idparam);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        

        private void InsertPuchasedTicketFrom(Event eventEntry)
        {
            string sqlString = "InsertPurchasedTickets";

            foreach (var purchasedTicket in eventEntry.PurchasedTickets)
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = cn.CreateCommand();
                    cmd.CommandText = sqlString;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@id", SqlDbType.UniqueIdentifier).Value = purchasedTicket.Id;
                    cmd.Parameters.Add("@tktQUantity", SqlDbType.Int).Value = purchasedTicket.TicketQuantity;
                    cmd.Parameters.Add("@EventId", SqlDbType.UniqueIdentifier).Value = purchasedTicket.Event.Id;

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            

        }

        private void InsertReservedTicketFrom(Event eventEntry)
        {
            string insertSql = "InsertReservedTickets";

            foreach (var reservedTicket in eventEntry.ReservedTickets)
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = cn.CreateCommand();
                    cmd.CommandText = insertSql; 
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id", reservedTicket.Id);
                    cmd.Parameters.AddWithValue("@ExpiryTime", reservedTicket.ExpiryTime);
                    cmd.Parameters.AddWithValue("@TicketQuantity", reservedTicket.TicketQuantity);
                    cmd.Parameters.AddWithValue("@EventId", eventEntry.Id);
                    cmd.Parameters.AddWithValue("@HasBeenRedeemed", reservedTicket.HasBeenRedeemed);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }

        }

        #endregion
    }
}
