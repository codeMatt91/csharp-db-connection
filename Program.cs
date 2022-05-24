

using System.Data.SqlClient;

namespace csharp_db_connection // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string stringDiConnessione = "Data Source=localhost;Initial Catalog=biblioteca;Integrated Security=True;Pooling=False";

            //SqlConnection conn = new SqlConnection(stringDiConnessione);

            using (SqlConnection conn = new SqlConnection(stringDiConnessione))
            {
                conn.Open();
                using (SqlCommand insert = new
                    SqlCommand(@"insert into clienti (Id, nome, cognome, codice_cliente)
                                values (1, 'il nome della persona', 'il cognome della persona', 1817263)", conn))
                {
                    var numrows = insert.ExecuteNonQuery();
                    Console.WriteLine(numrows);
                }


                using (SqlCommand query = new SqlCommand("select * from clienti", conn))
                {
                    using (SqlDataReader reader = query.ExecuteReader())
                    {
                        Console.WriteLine(reader.FieldCount);
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; ++i)
                                Console.Write("{0}, ", reader[i]);
                            Console.WriteLine();
                        }
                    }
                }
            }
        }
    }
}
