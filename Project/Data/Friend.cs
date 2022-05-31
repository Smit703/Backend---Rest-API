using System.ComponentModel.DataAnnotations;

namespace Project.Data
{
    public class Friend
    {
        [Key]
        public int ID { get; set; }
        public int UserID { get; set; }
        public int FriendID { get; set; }
       
    }
}
