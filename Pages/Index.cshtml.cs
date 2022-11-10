using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
//using MySql.Data.MySqlClient;

namespace foro.Pages
{
    public class IndexModel : PageModel
    {
        public msg = "msg";
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet(String user, String pass)
        {
            login(user, pass);
        }

        private void login(String u, String p)
        {
        using(MySqlConnecton c = new MySqlConnecton("server=localhost;Database=foro;Uid=root;password="));//using solo peormite la conexcion dentro de las llaves

            MySqlCommand cmd = new MySqlCommand();
            c.Open();
            cmd.Connection = c;
            cmd.CommandText = $"SELECT * FROM users WHERE username='{u}' AND password='{p}'";
            using(MySqlDataReader reader = new cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    //ViewData["Mensaje"] = "Si existe el usuario";
                    Response.Redirect("Topics");

                }
                else
                {
                    //ViewData["Mensaje"] = "Error no se encontro el usuario";
                    msg = "Error usuario o contraseña";
                }
            }

        }
    }
}