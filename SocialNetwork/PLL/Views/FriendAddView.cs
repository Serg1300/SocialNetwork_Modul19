using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{
    public class FriendAddView
    {
        UserService userService;
        FriendService friendService;
        public FriendAddView(FriendService friendService, UserService userService)
        {
            this.friendService = friendService;
            this.userService = userService;
        }
        public void Show(User user)
        {
            var friendAddData = new FriendAddData();

            Console.Write("Введите почтовый адрес друга: ");
            friendAddData.FriendEmail = Console.ReadLine();

            friendAddData.User_id = user.Id;

            try
            {
                friendService.AddFriend(friendAddData);

                SuccessMessage.Show("Добавлен в друзья!");

            }
            catch (UserNotFoundException)
            {
                AlertMessage.Show("Пользователь не найден!");
            }
            catch (Exception)
            {
                AlertMessage.Show("Произошла ошибка добавить в друзья не удалось!");
            }
        }
    }
}
