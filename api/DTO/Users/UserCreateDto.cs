using api.Models;

namespace api.DTO.Users
{
    public class UserCreateDto
    {
        public string Nickname { get; set; }
        public string Password { get; set; }
        public string Mood { get; set; }

        public User ToUser()
        {
            return new User
            {
                Nickname = Nickname,
                Password = Password,
                Mood = Mood
            };
        }

    }
}
