using EntityTypes;
using DataTypes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContract;
namespace DataAccess
{
    public class StoryRepository:BaseRepository<Story>,IStoryRepository
    {
        public StoryRepository(DbContext dbContext):base(dbContext)
        {

        }
        public void AddStoryToGroups(Story story, IEnumerable<int> groupIds)
        {
            var groups =   (from gr in DbContext.Set<Group>() where groupIds.Contains(gr.Id) select gr).ToList();
            story.Groups = groups;
        }



        public IEnumerable<Story> GetStoriesForGroup(int groupId, DataRequest request)
        {
          var groups = DbContext.Set<Group>();
          var group = groups.Where(a => a.Id == groupId).FirstOrDefault();
            if(group!=null)
            {

                //return group.Stories.AsEnumerable();
            }
            return default(IEnumerable<Story>);
        }
        public IEnumerable<Story> GetStoriesForUser(int userId, DataRequest request)
        {
            var stories = DbContext.Set<Story>();
            return stories.Where(a => a.UserId == userId).OrderBy(s => s.Title).Skip<Story>(request.StartPosition).Take(request.Count);
        }
    }
}
