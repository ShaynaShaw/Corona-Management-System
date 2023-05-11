using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace CoronaSystem.Pages.Clients
{
    public class IndexModel : PageModel
    {
        public List<ClientInfo> listClients = new List<ClientInfo>();
        public void OnGet()
        {
            try
            {
                String connectionString = "Data Source=.\\sqlexpress;Initial Catalog=corona;Integrated Security=True";
                
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM clients";
                    using(SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using(SqlDataReader reader = command.ExecuteReader()) 
                        {
                            while (reader.Read()) 
                            {
                                ClientInfo clientInfo = new ClientInfo();
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

                                listClients.Add(clientInfo);    
                            }
                        }
                    }
                }
            }
            catch(Exception ex) 
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
        }
    }

    public class ClientInfo
    {
        public String id;
        public String firstName;
        public String lastName;
        public String phone;
        public String mobilePhone;
        public String address;
        public String dateOfBirth;
        public String? firstVaccine;
        public String? secondVaccine;
        public String? thirdVaccine;
        public String? fourthVaccine;
        public String? firstVaccineManufacturer;
        public String? secondVaccineManufacturer;
        public String? thirdVaccineManufacturer;
        public String? fourthVaccineManufacturer;
        public String? positiveResult;
        public String? negativeResult;
    }
}
