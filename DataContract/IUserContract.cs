using DataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManagerContract
{
    public interface IUserContract
    {
        TaskResult<UserDetail> Validate(UserDetail user);
        TaskResult<bool> SaveUser(UserDetail user);
        TaskResult<bool> DeleteById(int id);
        TaskResult<UserDetail> GetUserDetails(int userId);
        TaskResult<UserDetail> GetUserDetails(string name);
    }
}
