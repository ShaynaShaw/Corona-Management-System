using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace CoronaSystem.Pages.Clients
{
    public class CreateModel : PageModel
    {
        public ClientInfo clientInfo = new ClientInfo();
        public String errorMessage = "", successMessage = "";

        public void OnGet()
        {
        }
        public void OnPost() 
        {
            clientInfo.id = Request.Form["id"];
            clientInfo.firstName = Request.Form["firstName"];
            clientInfo.lastName = Request.Form["lastName"];
            clientInfo.phone = Request.Form["phone"];
            clientInfo.mobilePhone = Request.Form["mobilePhone"];
            clientInfo.address = Request.Form["address"];
            clientInfo.dateOfBirth = Request.Form["dateOfBirth"];
            clientInfo.firstVaccine = Request.Form["firstVaccine"];
            clientInfo.secondVaccine = Request.Form["secondVaccine"];
            clientInfo.thirdVaccine = Request.Form["thirdVaccine"];
            clientInfo.fourthVaccine = Request.Form["fourthVaccine"];
            clientInfo.firstVaccineManufacturer = Request.Form["firstVaccineManufacturer"];
            clientInfo.secondVaccineManufacturer = Request.Form["secondVaccineManufacturer"];
            clientInfo.thirdVaccineManufacturer = Request.Form["thirdVaccineManufacturer"];
            clientInfo.fourthVaccineManufacturer = Request.Form["fourthVaccineManufacturer"];
            clientInfo.positiveResult = Request.Form["positiveResult"];
            clientInfo.negativeResult = Request.Form["negativeResult"];

            if(clientInfo.id.Length != 9)
            {
                errorMessage = "Required Id field of length 9";
                return;
            }
            if (clientInfo.firstName.Length == 0)
            {
                errorMessage = "firstName field is required";
                return;
            }
            if (clientInfo.lastName.Length == 0)
            {
                errorMessage = "lastName field is required";
                return;
            }
            if (clientInfo.phone.Length == 0)
            {
                errorMessage = "phone field is required";
                return;
            }
            if (clientInfo.mobilePhone.Length == 0)
            {
                errorMessage = "mobilePhone field is required";
                return;
            }
            if (clientInfo.address.Length == 0)
            {
                errorMessage = "address field is required";
                return;
            }
            if (clientInfo.dateOfBirth.Length == 0)
            {
                errorMessage = "dateOfBirth field is required";
                return;
            }
            //add validation checks

            //save new client into DB
            try
            {
                String connectionString = "Data Source=.\\sqlexpress;Initial Catalog=corona;Integrated Security=True";
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "INSERT INTO clients " +
                        "(id, firstName, lastName, phone, mobilePhone, address, dateOfBirth," +
                        " firstVaccine, secondVaccine , thirdVaccine, fourthVaccine," +
                        " firstVaccineManufacturer, secondVaccineManufacturer, thirdVaccineManufacturer," +
                        " fourthVaccineManufacturer, positiveResult, negativeResult) VALUES " +
                        "(@id, @firstName, @lastName, @phone, @mobilePhone, @address, @dateOfBirth," +
                        " @firstVaccine, @secondVaccine , @thirdVaccine, @fourthVaccine," +
                        " @firstVaccineManufacturer, @secondVaccineManufacturer, @thirdVaccineManufacturer," + 
                        " @fourthVaccineManufacturer, @positiveResult, @negativeResult);";

                    using(SqlCommand command  = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", clientInfo.id);
                        command.Parameters.AddWithValue("@firstName", clientInfo.firstName);
                        command.Parameters.AddWithValue("@lastName", clientInfo.lastName);
                        command.Parameters.AddWithValue("@phone", clientInfo.phone);
                        command.Parameters.AddWithValue("@mobilePhone", clientInfo.mobilePhone);
                        command.Parameters.AddWithValue("@address", clientInfo.address);
                        command.Parameters.AddWithValue("@dateOfBirth", clientInfo.dateOfBirth);
                        command.Parameters.AddWithValue("@firstVaccine", clientInfo.firstVaccine);
                        command.Parameters.AddWithValue("@secondVaccine", clientInfo.secondVaccine);
                        command.Parameters.AddWithValue("@thirdVaccine", clientInfo.thirdVaccine);
                        command.Parameters.AddWithValue("@fourthVaccine", clientInfo.fourthVaccine);
                        command.Parameters.AddWithValue("@firstVaccineManufacturer", clientInfo.firstVaccineManufacturer);
                        command.Parameters.AddWithValue("@secondVaccineManufacturer", clientInfo.secondVaccineManufacturer);
                        command.Parameters.AddWithValue("@thirdVaccineManufacturer", clientInfo.thirdVaccineManufacturer);
                        command.Parameters.AddWithValue("@fourthVaccineManufacturer", clientInfo.fourthVaccineManufacturer);
                        command.Parameters.AddWithValue("@positiveResult", clientInfo.positiveResult);
                        command.Parameters.AddWithValue("@negativeResult", clientInfo.negativeResult);


                        command.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }


            clientInfo.id = "";
            clientInfo.firstName = "";
            clientInfo.lastName = "";
            clientInfo.phone = "";
            clientInfo.mobilePhone = "";
            clientInfo.address = "";
            clientInfo.dateOfBirth = "";
            clientInfo.firstVaccine = "";
            clientInfo.secondVaccine = "";
            clientInfo.thirdVaccine = "";
            clientInfo.fourthVaccine = "";
            clientInfo.firstVaccineManufacturer = "";
            clientInfo.secondVaccineManufacturer = "";
            clientInfo.thirdVaccineManufacturer = "";
            clientInfo.fourthVaccineManufacturer = "";
            clientInfo.positiveResult = "";
            clientInfo.negativeResult = "";

            successMessage = "New Client Added Successfully";
            Response.Redirect("/Clients/Index");
        }
    }
}
