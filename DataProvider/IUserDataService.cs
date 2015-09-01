using DataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContract;
namespace ServiceContract
{
    public interface IUserDataService
    {
        TaskResult<bool> SaveUser(UserDetail user);
        TaskResult<UserDetail> TryLoginUser(UserDetail user);
        
        TaskResult<UserDetail> GetUserDetail(uint id);
        TaskResult<UserDetail> GetUserDetail(string name);
    }
}
