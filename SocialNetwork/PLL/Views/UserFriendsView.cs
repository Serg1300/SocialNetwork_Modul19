using SocialNetwork.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{
    public class UserFriendsView
    {
        public void Show(IEnumerable<Friend> userFriends)
        {
            Console.WriteLine("Список друзей");

            if (userFriends.Count() == 0)
            {
                Console.WriteLine("Друзей нет");
                return;
            }

            userFriends.ToList().ForEach(friend =>
            {
                Console.WriteLine("Пользователь: {0}. Друг: Email: {1} Имя: {2} Фамилия: {3}  ", friend.UserEmail,
                    friend.FriendEmail, friend.FriendName, friend.FriendLastName);
            });
        }
    }
}
