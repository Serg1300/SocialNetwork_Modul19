using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Models
{
    public class Friend
    {
        public int Id { get; set; }
        public int User_id { get; set; }
        public int Friend_id { get; set; }
        public string FriendName { get; set; }
        public string FriendLastName { get; set; }
        public string FriendEmail { get; set; }
        public string UserEmail { get; set; }

        public Friend( int id, int user_id, int friend_id, string friendName, string friendLastName, string friendEmail, string userEmail)
        {
            Id = id;
            User_id = user_id;
            Friend_id = friend_id;
            FriendName = friendName;
            FriendLastName = friendLastName;
            FriendEmail = friendEmail;
            UserEmail = userEmail;
        }
    }
}
