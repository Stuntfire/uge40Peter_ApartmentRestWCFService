using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace uge40Peter_ApartmentRestWCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IApartmentService
    {
        /// <summary>
        /// Link til Peter's opgaven: https://drive.google.com/open?id=0B5TZmSs3KA0xQzJuMXRJTFF0TTQ
        /// </summary>


        private String databaseString = "Server=tcp:hotelserver01.database.windows.net,1433;Initial Catalog=HotelDB;Persist Security Info=False;User ID=sailor;Password=ZAQ12wsx;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public IList<Apartment> GetAllApartment()
        {
            List<Apartment> apartmentsList = new List<Apartment>();

            string selectAllApartments = "SELECT * FROM Apartment";

            using (SqlConnection sqlConnection = new SqlConnection(databaseString))
            {
                sqlConnection.Open();

                SqlCommand command = new SqlCommand(selectAllApartments, sqlConnection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    apartmentsList.Add(new Apartment()
                    {
                        Id = reader.GetInt32(0),
                        Price = reader.GetInt32(1),
                        Location = reader.GetString(2),
                        Postalcode = reader.GetInt32(3),
                        Size = reader.GetInt32(4),
                        NoRoom = reader.GetInt32(5),
                        WashingMachine = reader.GetBoolean(6),
                        Dishwasher = reader.GetBoolean(7),
                    });
                }
                return apartmentsList;
            }
        }

        public IList<Apartment> GetAllApartmentByPostalCode(string postalCode)
        {
            List<Apartment> apartmentsList = new List<Apartment>();

            string selectAllApartments = "SELECT * FROM Apartment WHERE PostalCode = @postalCode";

            using (SqlConnection sqlConnection = new SqlConnection(databaseString))
            {
                sqlConnection.Open();

                SqlCommand command = new SqlCommand(selectAllApartments, sqlConnection);

                command.Parameters.AddWithValue("@postalcode", postalCode);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    apartmentsList.Add(new Apartment()
                    {
                        Id = reader.GetInt32(0),
                        Price = reader.GetInt32(1),
                        Location = reader.GetString(2),
                        Postalcode = reader.GetInt32(3),
                        Size = reader.GetInt32(4),
                        NoRoom = reader.GetInt32(5),
                        WashingMachine = reader.GetBoolean(6),
                        Dishwasher = reader.GetBoolean(7),
                    });
                }
                return apartmentsList;
            }
        }

        public IList<Apartment> GetAllApartmentByLocation(string location)
        {
            List<Apartment> apartmentsList = new List<Apartment>();

            string selectAllApartments = "SELECT * FROM Apartment WHERE Location = @location";

            using (SqlConnection sqlConnection = new SqlConnection(databaseString))
            {
                sqlConnection.Open();

                SqlCommand command = new SqlCommand(selectAllApartments, sqlConnection);

                command.Parameters.AddWithValue("@location", location);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    apartmentsList.Add(new Apartment()
                    {
                        Id = reader.GetInt32(0),
                        Price = reader.GetInt32(1),
                        Location = reader.GetString(2),
                        Postalcode = reader.GetInt32(3),
                        Size = reader.GetInt32(4),
                        NoRoom = reader.GetInt32(5),
                        WashingMachine = reader.GetBoolean(6),
                        Dishwasher = reader.GetBoolean(7)
                    });
                }
                return apartmentsList;
            }
        }

        public void CreateApartment(Apartment apartment)
        {
            string postNewApartment = "INSERT INTO Apartment (Price, Location, Postalcode, Size, NoRoom, WashingMachine, Dishwasher) VALUES (@price, @location, @postalcode, @size, @noRoom, @washingMachine, @dishwasher)";

            using (SqlConnection sqlConnection = new SqlConnection(databaseString))
            {
                sqlConnection.Open();

                SqlCommand command = new SqlCommand(postNewApartment, sqlConnection);

                command.Parameters.AddWithValue("@price", apartment.Price);
                command.Parameters.AddWithValue("@location", apartment.Location);
                command.Parameters.AddWithValue("@postalcode", apartment.Postalcode);
                command.Parameters.AddWithValue("@size", apartment.Size);
                command.Parameters.AddWithValue("@noRoom", apartment.NoRoom);
                command.Parameters.AddWithValue("@washingMachine", apartment.WashingMachine);
                command.Parameters.AddWithValue("@dishwasher", apartment.Dishwasher);

                command.ExecuteNonQuery();
            }
        }

        public void DeleteApartment(string id)
        {
            string postNewApartment = "DELETE FROM Apartment WHERE Id=@id";

            using (SqlConnection sqlConnection = new SqlConnection(databaseString))
            {
                sqlConnection.Open();

                SqlCommand command = new SqlCommand(postNewApartment, sqlConnection);

                command.Parameters.AddWithValue("@id", id);

                command.ExecuteNonQuery();
            }
        }

        public void UpdateApartment(Apartment apartment)
        {
            string updateApartmet = "UPDATE Apartment SET Price=@price, Location=@location, Postalcode=@postalcode, Size=@size, NoRoom=@noRoom, WashingMachine=@washingMachine, Dishwasher=@dishwasher WHERE Id=@id";

            using (SqlConnection sqlConnection = new SqlConnection(databaseString))
            {
                sqlConnection.Open();

                SqlCommand command = new SqlCommand(updateApartmet, sqlConnection);

                command.Parameters.AddWithValue("@id", apartment.Id);
                command.Parameters.AddWithValue("@price", apartment.Price);
                command.Parameters.AddWithValue("@location", apartment.Location);
                command.Parameters.AddWithValue("@postalcode", apartment.Postalcode);
                command.Parameters.AddWithValue("@size", apartment.Size);
                command.Parameters.AddWithValue("@noRoom", apartment.NoRoom);
                command.Parameters.AddWithValue("@washingMachine", apartment.WashingMachine);
                command.Parameters.AddWithValue("@dishwasher", apartment.Dishwasher);

                command.ExecuteNonQuery();
            }
        }

        public IList<Apartment> SearchMachinesApartment(string washingMachine, string dishwasher)
        {
            List<Apartment> apartmentsList = new List<Apartment>();

            string selectAllApartments = "SELECT * FROM Apartment WHERE WashingMachine=@washingMachine AND Dishwasher=@dishwasher";

            using (SqlConnection sqlConnection = new SqlConnection(databaseString))
            {
                sqlConnection.Open();

                SqlCommand command = new SqlCommand(selectAllApartments, sqlConnection);

                command.Parameters.AddWithValue("@washingMachine", washingMachine);
                command.Parameters.AddWithValue("@dishwasher", dishwasher);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    apartmentsList.Add(new Apartment()
                    {
                        Id = reader.GetInt32(0),
                        Price = reader.GetInt32(1),
                        Location = reader.GetString(2),
                        Postalcode = reader.GetInt32(3),
                        Size = reader.GetInt32(4),
                        NoRoom = reader.GetInt32(5),
                        WashingMachine = reader.GetBoolean(6),
                        Dishwasher = reader.GetBoolean(7),
                    });
                }
                return apartmentsList;
            }
        }


        public IList<Apartment> SearchPriceApartment(string minPrice, string maxPrice)
        {
            List<Apartment> apartmentsList = new List<Apartment>();

            string selectAllApartments = "SELECT * FROM Apartment WHERE Price BETWEEN @minPrice AND @maxPrice";

            using (SqlConnection sqlConnection = new SqlConnection(databaseString))
            {
                sqlConnection.Open();

                SqlCommand command = new SqlCommand(selectAllApartments, sqlConnection);

                command.Parameters.AddWithValue("@minPrice", minPrice);
                command.Parameters.AddWithValue("@maxPrice", maxPrice);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    apartmentsList.Add(new Apartment()
                    {
                        Id = reader.GetInt32(0),
                        Price = reader.GetInt32(1),
                        Location = reader.GetString(2),
                        Postalcode = reader.GetInt32(3),
                        Size = reader.GetInt32(4),
                        NoRoom = reader.GetInt32(5),
                        WashingMachine = reader.GetBoolean(6),
                        Dishwasher = reader.GetBoolean(7),
                    });
                }
                return apartmentsList;
            }
        }
    }
}
