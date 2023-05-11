using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Reflection.PortableExecutable;

namespace CoronaSystem.Pages.Clients
{
    public class DetailsModel : PageModel
    {
        public ClientInfo clientInfo = new ClientInfo();
        public String errorMessage = "";
        public String successMessage = "";

        public void OnGet()
        {
            String id = Request.Query["id"];

            //connect to DB and update feilds
            try
            {
                String connectionString = "Data Source=.\\sqlexpress;Initial Catalog=corona;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM clients WHERE id = @id";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read()) {
                                clientInfo.id = reader.GetString(0);
                                clientInfo.firstName = reader.GetString(1);
                                clientInfo.lastName = reader.GetString(2);
                                clientInfo.phone = reader.GetString(3);
                                clientInfo.mobilePhone = reader.GetString(4);
                                clientInfo.address = reader.GetString(5);
                                clientInfo.dateOfBirth = reader.GetDateTime(6).ToString();
                                clientInfo.firstVaccine = reader.GetDateTime(7).ToString();
                                clientInfo.secondVaccine = reader.GetDateTime(8).ToString();
                                clientInfo.thirdVaccine = reader.GetDateTime(9).ToString();
                                clientInfo.fourthVaccine = reader.GetDateTime(10).ToString();
                                clientInfo.firstVaccineManufacturer = reader.GetString(11);
                                clientInfo.secondVaccineManufacturer = reader.GetString(12);
                                clientInfo.thirdVaccineManufacturer = reader.GetString(13);
                                clientInfo.fourthVaccineManufacturer = reader.GetString(14);
                                clientInfo.positiveResult = reader.GetDateTime(15).ToString();
                                clientInfo.negativeResult = reader.GetDateTime(16).ToString();

                            }
                        }   
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = "Error loading details";
            }
        }
    }
}
