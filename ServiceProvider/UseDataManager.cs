using DataManagerContract;
using DataContract;
using EntityTypes;
using DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceProvider;

namespace DataManager
{
    public class UserDataManager : IUserContract
    {
        readonly IUserRepository _userRepository;
        public UserDataManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public TaskResult<bool> SaveUser(UserDetail user)
        {
            TaskResult<bool> result = null ;
            try
            {
                if (user.Id == null)//create
                {
                    _userRepository.Insert(new User { DateCreated = DateTime.Now, Password = user.Password, UserName = user.USerName });
                    _userRepository.SaveChanges();
                    result = new TaskResult<bool> { state = StatusState.DoneState, Data = true };
                }
                else//update
                {

                }
            }
            catch(Exception e)
            {
                Logger.Instance.LogException(e);
                result = new TaskResult<bool> { state = StatusState.DoneState, Data = false };
            }
            return result;
        }

        public TaskResult<bool> DeleteById(int id)
        {
            TaskResult<bool> result = null;
            try
            {
                if(id!=0)
                {
                    User findedItem = _userRepository.GetSingle(a => a.Id == id);
                    if(findedItem!=null)
                    {
                        _userRepository.Delete(findedItem);
                        _userRepository.SaveChanges();
                        result = new TaskResult<bool> { Data = true };
                    }
                    else
                    {
                        throw new Exception();
                    }
                   
                }
                else
                {
                    throw new Exception();
                }
               
            }
            catch(Exception e)
            {
                Logger.Instance.LogException(e);
                result = new TaskResult<bool> { Data = false };
            }
            return result;
            
        }

       

        public TaskResult<UserDetail> GetUserDetails(int userId)
        {
            TaskResult<UserDetail> result = null;
            try
            {
               User uentity=  _userRepository.GetSingle(u => u.Id == userId);
               UserDetail detail = new UserDetail { Id = uentity.Id, USerName = uentity.UserName };
               result = new TaskResult<UserDetail>() { Data = detail, state = StatusState.DoneState };
            }
            catch(Exception e)
            {
                Logger.Instance.LogException(e);
                result = new TaskResult<UserDetail>() { Data = null, state = StatusState.CancelState };
            }
            return result;
        }

        public TaskResult<UserDetail> Validate(UserDetail user)
        {
            TaskResult<UserDetail> result;
            try
            {
                var _user = _userRepository.GetSingle((x) => x.UserName == user.USerName && x.Password == user.Password);
                result = new TaskResult<UserDetail> { state = StatusState.DoneState, Data = new UserDetail { Id=_user.Id,USerName=_user.UserName} };
            }
            catch(Exception e)
            {
                Logger.Instance.LogException(e);
                result = new TaskResult<UserDetail> { state = StatusState.CancelState, Data = null };
            }


            return result;
        }


        public TaskResult<UserDetail> GetUserDetails(string name)
        {
            TaskResult<UserDetail> result = null;
            try
            {
                User uentity = _userRepository.GetSingle(u => u.UserName == name);
                UserDetail detail = new UserDetail { Id = uentity.Id, USerName = uentity.UserName };
                result = new TaskResult<UserDetail>() { Data = detail, state = StatusState.DoneState };
            }
            catch(Exception e)
            {
                Logger.Instance.LogException(e);
                result = new TaskResult<UserDetail>() { Data = null, state = StatusState.CancelState };
            }
            return result;
        }

       
    }
}
