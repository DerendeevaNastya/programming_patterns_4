using System.Linq;
using Example_04.Homework.Models;
using Example_04.Homework.SecondOrmLibrary;

namespace Example_04.Homework.Clients
{
    public class SecondOrmAdapter : IOrmAdapter
    {
        private ISecondOrm secondOrm;

        public SecondOrmAdapter(ISecondOrm secondOrm)
        {
            this.secondOrm = secondOrm;
        }
        
        public void Add(DbUserEntity user, DbUserInfoEntity userInfo)
        {
            secondOrm.Context.Users.Add(user);
            secondOrm.Context.UserInfos.Add(userInfo);
        }

        public void Remove(int userId)
        {
            var userToDelete = secondOrm.Context.Users.FirstOrDefault(x => x.Id == userId);
            var userInfoToDelete = secondOrm.Context.UserInfos.FirstOrDefault(x => x.Id == userToDelete?.InfoId);

            secondOrm.Context.Users.Remove(userToDelete);
            secondOrm.Context.UserInfos.Remove(userInfoToDelete);
        }

        public (DbUserEntity, DbUserInfoEntity) Get(int userId)
        {
            var user = secondOrm.Context.Users.FirstOrDefault(i => i.Id == userId);
            var userInfo = secondOrm.Context.UserInfos.FirstOrDefault(i => i.Id == user?.InfoId);
            return (user, userInfo);
        }
    }
}