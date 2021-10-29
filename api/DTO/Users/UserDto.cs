using api.Models;

namespace api.DTO.Users
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public string Mood { get; set; }

        public static UserDto FromUser(User user)
        {
            return new UserDto
            {
                Id = user.Id,
                Nickname = user.Nickname,
                Mood = user.Mood,
            };
        }
    }
}
