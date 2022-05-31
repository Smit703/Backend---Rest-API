using System.ComponentModel.DataAnnotations;

namespace Project.Data
{
    public class Users
    {
        [Key]
        public int userid { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? email { get; set; }

        public Users()
        {
                
        }
    }
}
