using Example_04.Homework.FirstOrmLibrary;
using Example_04.Homework.Models;

namespace Example_04.Homework.Clients
{
    public class FirstOrmAdapter : IOrmAdapter
    {
        private readonly IFirstOrm<DbUserEntity> usersOrm;
        private readonly IFirstOrm<DbUserInfoEntity> userInfosOrm;

        public FirstOrmAdapter(IFirstOrm<DbUserEntity> usersOrm, IFirstOrm<DbUserInfoEntity> userInfosOrm)
        {
            this.usersOrm = usersOrm;
            this.userInfosOrm = userInfosOrm;
        }
        
        public void Add(DbUserEntity user, DbUserInfoEntity userInfo)
        {
            usersOrm.Add(user);
            userInfosOrm.Add(userInfo);
        }

        public void Remove(int userId)
        {
            var user = usersOrm.Read(userId);
            var userInfo = userInfosOrm.Read(user.InfoId);

            userInfosOrm.Delete(userInfo);
            usersOrm.Delete(user);
        }

        public (DbUserEntity, DbUserInfoEntity) Get(int userId)
        {
            var user = usersOrm.Read(userId);
            var userInfo = userInfosOrm.Read(user.InfoId);
            return (user, userInfo);
        }
    }
}