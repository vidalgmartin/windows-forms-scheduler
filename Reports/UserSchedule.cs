using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using static C969.Database.DbConnection;

namespace C969.Reports
{
    public class UserSchedule
    {
        public string UserName { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Type { get; set; }

        public List<UserSchedule> GetUserSchedules()
        {
            List<UserSchedule> schedules = new List<UserSchedule>();

            string query = @"
                SELECT 
                    u.userName, 
                    a.start, 
                    a.end, 
                    a.type 
                FROM appointment a
                JOIN user u ON a.userId = u.userId
                ORDER BY u.userName, a.start;";

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            schedules.Add(new UserSchedule
                            {
                                UserName = reader.GetString("userName"),
                                Start = reader.GetDateTime("start"),
                                End = reader.GetDateTime("end"),
                                Type = reader.GetString("type")
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return schedules;
        }

        public void DisplayUserSchedules()
        {
            var schedules = GetUserSchedules();

            // lambda expressions to format the user schedules output
            string reportText = string.Join("\n", schedules.Select(s =>
                $"{s.UserName}: {s.Type} from {s.Start:g} to {s.End:g}"));

            MessageBox.Show(reportText, "User Schedules");
        }
    }
}
