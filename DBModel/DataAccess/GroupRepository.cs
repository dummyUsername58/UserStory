using DataTypes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityTypes;
using DataContract;
namespace DataAccess
{
    public class GroupRepository:BaseRepository<Group>,IGroupRepository
    {
        public GroupRepository(DbContext dbContext)
            : base(dbContext)
        {

        }
        public IEnumerable<Group> GetGroupsByStoryId(int storyId)
        {
            IEnumerable<Group> result = DbContext.Set<Story>().Where(a => a.Id == storyId).First().Groups.AsEnumerable();
            return result;
        }
        public IEnumerable<Group> GetGroupsByUserId(int userId)
        {
            IEnumerable<Group> result = DbContext.Set<User>().Where(a => a.Id == userId).First().UserGroups.AsEnumerable();
            return result;
        }
        public IEnumerable<Group> GetGroupsByRequest(DataRequest request)
        {
            var groups = DbContext.Set<Group>().OrderBy(a=>a.Name).Skip<Group>(request.StartPosition).Take(request.Count).AsEnumerable();;
            return groups;
        }

        public IEnumerable<GroupDetail> GetGroupsWithDetailsByRequest(DataRequest request)
        {
            
            IEnumerable<GroupDetail> details = DbContext.Set<Group>().Select(g=>new GroupDetail
            {
                Id=g.Id,
                Name=g.Name,
                NumberOfMembers=g.Users.Count(),
                NumberOfStories=g.Stories.Count()
            }).OrderBy(a => a.Name).Skip<GroupDetail>(request.StartPosition).Take(request.Count);



            return details;
        }
        public void JoinGroup(JoinDetail detail)
        {
            Group g = DbContext.Set<Group>().Where(a => a.Id == detail.GroupId).First();
            DbContext.Set<User>().Where(a => a.Id == detail.UserId).First().UserGroups.Add(g);
        }
    }
}
