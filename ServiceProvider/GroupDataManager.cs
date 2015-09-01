using DataManagerContract;
using DataContract;
using EntityTypes;
using DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityTypes;
using ServiceProvider;
namespace DataManager
{
    public class GroupDataManager : IGroupContract
    {
        IGroupRepository _groupRepository;
        public GroupDataManager(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }


        public TaskResult<bool> SaveGroup(GroupDetail group)
        {
            TaskResult<bool> result= null;
            try
            {
                if(group.Id==null)//insert
                {
                    _groupRepository.Insert(new Group { DateCreated = DateTime.Now, Description = group.Description, Name = group.Name });
                    _groupRepository.SaveChanges();
                    result= new TaskResult<bool>{Data=true,state=StatusState.DoneState};
                }
            }
            catch(Exception e)
            {
                Logger.Instance.LogException(e);
                result= new TaskResult<bool>{Data=false,state=StatusState.CancelState};
            }
            return result;
           
        }

        public TaskResult<bool> DeleteById(int  id)
        {
             TaskResult<bool> result = null;
             try
             {
                 _groupRepository.Delete(_groupRepository.GetSingle(a => a.Id == id));
                 _groupRepository.SaveChanges();
                 result = new TaskResult<bool> { Data = true, state = StatusState.DoneState };
             }
             catch(Exception e)
             {
                 Logger.Instance.LogException(e);
                 result = new TaskResult<bool> { Data = false, state = StatusState.CancelState };
             }
             return result;
        }

        public TaskResult<IEnumerable<GroupDetail>> GetGroupsByRequest(DataRequest request)
        {
            TaskResult<IEnumerable<GroupDetail>> result = null;
            try
            {
                result = new TaskResult<IEnumerable<GroupDetail>> { state = StatusState.DoneState };

                IEnumerable<Group> groups = _groupRepository.GetGroupsByRequest(request);

                result.Data = groups.Select(a => new GroupDetail { Description = a.Description, Id = a.Id, Name = a.Name }).AsEnumerable<GroupDetail>();
            }
            catch (Exception e)
            {
                Logger.Instance.LogException(e);
                result = new TaskResult<IEnumerable<GroupDetail>> { Data = null, state = StatusState.CancelState };
            }
            return result;
        }
    
        public TaskResult<IEnumerable<GroupDetail>> GetGroupsWithDetail(DataRequest request)
        {
            TaskResult<IEnumerable<GroupDetail>> result = null;
            try
            {
                
                result = new TaskResult<IEnumerable<GroupDetail>> { state = StatusState.DoneState };
                IEnumerable<GroupDetail> groups = _groupRepository.GetGroupsWithDetailsByRequest(request);
                result.Data = groups;
            }
            catch (Exception e)
            {
                Logger.Instance.LogException(e);
                result = new TaskResult<IEnumerable<GroupDetail>> { Data = null, state = StatusState.CancelState };
            }
            return result;
        }


        public TaskResult<IEnumerable<int>> GetUserGroups(int userId)
        {
            TaskResult<IEnumerable<int>> result = null;
            try
            {
                var data = _groupRepository.GetGroupsByUserId(userId).Select(a => a.Id);
                result = new TaskResult<IEnumerable<int>> { state = StatusState.DoneState,Data=data };
            }
            catch (Exception e)
            {
                Logger.Instance.LogException(e);
                result = new TaskResult<IEnumerable<int>> {Data=null, state = StatusState.CancelState };
            }
            return result;
        }


        public TaskResult<bool> JoinGroup(JoinDetail jdetail)
        {
            TaskResult<bool> result = null;
            try
            {
                _groupRepository.JoinGroup(jdetail);
                _groupRepository.SaveChanges();
                result = new TaskResult<bool> { Data = true, state = StatusState.DoneState };
            }
            catch (Exception e)
            {
                Logger.Instance.LogException(e);
                result = new TaskResult<bool> { Data = false, state = StatusState.CancelState };
            }
            return result;
        }

    }
}
