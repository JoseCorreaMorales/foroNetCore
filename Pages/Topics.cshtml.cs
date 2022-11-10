using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using  MySql.Data.MySqlClient;

namespace foro.Pages
{
    public class TopicsModel : PageModel
    {
        public List<Topic> topics = new List<Topic>();
        public void OnGet()
        {
            listarTopics();
        }

        private void listarTopics()
        {
            using (MySqlConnecton c = new MySqlConnecton("server=localhost;Database=foro;Uid=root;password=")) ;//using solo peormite la conexcion dentro de las llaves

            MySqlCommand cmd = new MySqlCommand();
            c.Open();
            cmd.Connection = c;
            cmd.CommandText = $"SELECT * FROM topics";
            using (MySqlDataReader reader = new cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    topics.Add(new Topic()
                    {
                        Id = reader.GetInt32("id"),
                        Title = reader.getString("title"),
                        UserId = reader.getString("user_id"),
                    }); 
                }
            }
        }
    }
}
