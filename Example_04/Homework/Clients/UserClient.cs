using Example_04.Homework.Models;

namespace Example_04.Homework.Clients
{
    public class UserClient
    {
        private readonly IOrmAdapter ormAdapter;

        public (DbUserEntity, DbUserInfoEntity) Get(int userId) => ormAdapter.Get(userId);
        
        public void Add(DbUserEntity user, DbUserInfoEntity userInfo) => ormAdapter.Add(user, userInfo);

        public void Remove(int userId) => ormAdapter.Remove(userId);

        public UserClient(IOrmAdapter ormAdapter)
        {
            this.ormAdapter = ormAdapter;
        }
    }
}
