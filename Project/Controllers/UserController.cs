using Microsoft.AspNetCore.Mvc;
using Project.Data;
using Project.Models;
using System.Linq;

namespace Project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private UserDBContext DB;
        public UserController(UserDBContext DB)
        {
            this.DB = DB;
        }

        [HttpGet("GetUser")]
        public IActionResult Get()
        {
            var users = DB.Users.ToList();
            if (users.Count == 0)
            {
                return NotFound();
            }

            return Ok(users);
        }

        [HttpPut("NewUser")]
        public IActionResult create([FromBody] UserRequest newuser)
        {
            Users usern = new Users();
            usern.userid = newuser.userid;
            usern.firstName = newuser.firstName;
            usern.lastName = newuser.lastName;
            usern.email = newuser.email;

            DB.Users.Add(usern);
            DB.SaveChanges();

            var users = DB.Users.ToList();
            return Ok(users);
        }

        [HttpDelete("DeleteUser/{Id}")]
        public IActionResult delete([FromRoute] int Id)
        {
            var usern = DB.Users.FirstOrDefault(x => x.userid == Id);
            if (usern == null)
            {
                return StatusCode(404, "Not Found");
            }
            DB.Users.Remove(usern);
            DB.SaveChanges();

            var users = DB.Users.ToList();
            return Ok(users);
        }

        [HttpPut("AddFriends")]
        public IActionResult create([FromBody] FriendRequest newfriends)
        {
            Friend frnd = new Friend();
            frnd.ID = newfriends.ID;
            frnd.UserID = newfriends.UserID;
            var user1n = DB.Users.FirstOrDefault(x => x.userid == frnd.UserID);
            if(user1n == null)
            {
                return StatusCode(404, "User Not Found");
            }
            frnd.FriendID = newfriends.FriendID;
            var user2n = DB.Users.FirstOrDefault(x => x.userid == frnd.FriendID);
            if (user2n == null)
            {
                return StatusCode(404, "Friend Not Found");
            }

            DB.Friends.Add(frnd);
            DB.SaveChanges();

            var friends = DB.Friends.ToList();
            return Ok(friends);
        }

        [HttpGet("GetFriends/{Id}")]
        public IActionResult Get([FromRoute] int Id)
        {
            var list = DB.Friends.Where(x => x.UserID == Id);
               
            var users=list.Select(x => x.FriendID).ToList();

            if(users.Count == 0)
            {
                return Ok("No Friends!");
            }

            List<Users> Fr = new List<Users>();

            var users1 = DB.Users.Where(x => x.userid == users[0]).ToList();

            for (int i=0;i<users.Count;i++)
            {
                users1 = DB.Users.Where(x => x.userid == users[i]).ToList();
                Fr.Add((Users)users1[0]);
            }
            
            return Ok(Fr);
        }

        [HttpDelete("DeleteFriends/{Id}")]
        public IActionResult Delete([FromRoute] int Id)
        {
            var Friend = DB.Friends.FirstOrDefault(x => x.ID == Id);
            if (Friend == null)
            {
                return StatusCode(404, "Not Found");
            }
            DB.Friends.Remove(Friend);
            DB.SaveChanges();

            var users = DB.Friends.ToList();
            return Ok(users);
        }
    }
}