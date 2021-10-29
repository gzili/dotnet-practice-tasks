using api.Models;
using System.Linq;

namespace api.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApiDbContext db)
        {
            if (db.Users.Any())
                return;

            var users = new User[]
            {
                new User
                {
                    Nickname = "gustas",
                    Password = "pultas",
                    Mood = "rage"
                },
                new User
                {
                    Nickname = "edvinas",
                    Password = "java",
                    Mood = "work"
                },
                new User
                {
                    Nickname = "joris",
                    Password = "kaitas",
                    Mood = "chill"
                },
                new User
                {
                    Nickname = "agota",
                    Password = "kitten",
                    Mood = "chat"
                }
            };

            db.Users.AddRange(users);
            db.SaveChanges();
        }
    }
}
