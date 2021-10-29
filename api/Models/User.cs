using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("user")]
    public class User
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("nickname")]
        [RegularExpression(@"^[a-z0-9_]{6,20}$")]
        public string Nickname { get; set; }
        [Column("password")]
        [Required]
        public string Password { get; set; }
        public string Mood { get; set; }
    }
}
