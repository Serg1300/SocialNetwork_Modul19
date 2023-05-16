using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Services
{
    public class FriendService
    {
        IFriendRepository friendRepository;
        IUserRepository userRepository;
        public FriendService()
        {
            friendRepository = new FriendRepository();
            userRepository = new UserRepository();
        }
        public IEnumerable<Friend> GetFriendByUserId(int userId)
        {
            var friends = new List<Friend>();

            friendRepository.FindAllByUserId(userId).ToList().ForEach(m =>
            {
                var userUserEntity = userRepository.FindById(m.user_id);
                var friendUserEntity = userRepository.FindById(m.friend_id);
                friends.Add(new Friend(m.id, m.user_id,  m.friend_id, friendUserEntity.firstname,
                    friendUserEntity.lastname, friendUserEntity.email, userUserEntity.email));
            });
            return friends;
        }
        
        public void AddFriend(FriendAddData friendAddData)
        {
            var findUserEntity = this.userRepository.FindByEmail(friendAddData.FriendEmail);
            if (findUserEntity is null) throw new UserNotFoundException();

            var friendEntity = new FriendEntity()
            {
                user_id = friendAddData.User_id,
                friend_id = findUserEntity.id
            };

            if(this.friendRepository.Create(friendEntity) == 0) 
                throw new Exception();
        }
        
    }
}
