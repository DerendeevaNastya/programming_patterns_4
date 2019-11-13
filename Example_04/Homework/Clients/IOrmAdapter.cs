using System.Net.Sockets;
using Example_04.Homework.Models;

namespace Example_04.Homework.Clients
{
    public interface IOrmAdapter // ITarget
    {
        void Add(DbUserEntity user, DbUserInfoEntity userInfo);
        void Remove(int userId);
        (DbUserEntity, DbUserInfoEntity) Get(int userId);
    }
}
