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
    public class StoryDataManager : IStoryContract
    {
        IStoryRepository _storyRepository;
        
        public StoryDataManager(IStoryRepository storyRepository)
        {
            _storyRepository = storyRepository;
        }
        public TaskResult<bool> SaveStory(StoryDetail story)
        {
            TaskResult<bool> result = null;
            try
            {
                
                if (story.Id == null)//new
                {
                    Story storyEntity = new Story { Content = story.Content, DateCreated = DateTime.Now, Description = story.Description, Title = story.Title, UserId = story.UserId.Value };
                    _storyRepository.Insert(storyEntity);
                    //_storyRepository.SaveChanges();
                    _storyRepository.AddStoryToGroups(storyEntity, story.GroupDetails.Select(a => a.Id.Value).AsEnumerable());
                    _storyRepository.SaveChanges();
                }
                else
                {
                    Story _story = _storyRepository.GetSingle(a => a.Id == story.Id);
                    _story.Description = story.Description;
                    _story.Title = story.Title;
                    _story.Content = story.Content;
                    _story.DateModified = DateTime.Now;
                    IEnumerable<Group> groups = _story.Groups.ToList();
                    foreach(var gr in groups)
                    {
                        _story.Groups.Remove(gr);
                    }
                    _storyRepository.Update(_story);
                    _storyRepository.SaveChanges();

                    _storyRepository.AddStoryToGroups(_story, story.GroupDetails.Select(a => a.Id.Value).AsEnumerable());
                    _storyRepository.SaveChanges();
                }
                result = new TaskResult<bool> { Data = true, state = StatusState.DoneState };
            }
            catch(Exception e)
            {
                result = new TaskResult<bool> { Data = false, state = StatusState.CancelState };
            }
            return result;
        }

        public TaskResult<bool> DeleteById(int  id)
        {
             TaskResult<bool> result = null;
             try
             {
                 _storyRepository.Delete(_storyRepository.GetSingle(a => a.Id == id));
                 _storyRepository.SaveChanges();
                 result = new TaskResult<bool> { Data = true, state = StatusState.DoneState };
             }
             catch(Exception e)
             {
                 Logger.Instance.LogException(e);
                 result = new TaskResult<bool> { Data = false, state = StatusState.CancelState };
             }
             return result;
        }
        public TaskResult<StoryDetail> GetById(int  id)
        {
            TaskResult<StoryDetail> result = null;
            try
            {
                Story story=  _storyRepository.GetById(id);
                if(story!=null)
                {
                    result = new TaskResult<StoryDetail> { Data = new StoryDetail { Content = story.Content, Description = story.Description, GroupDetails = story.Groups.Select(g => new GroupDetail { Id=g.Id,Name=g.Name}),Id=story.Id,PostedOn=story.DateCreated.Value,Title=story.Title,UserId=story.UserId }, state = StatusState.DoneState };
                }
                else
                {
                    result = new TaskResult<StoryDetail> { Data = null, state = StatusState.DoneState };
                }
                
            }
            catch (Exception e)
            {
                Logger.Instance.LogException(e);
                result = new TaskResult<StoryDetail> { Data = null, state = StatusState.CancelState };
            }
            return result;
        }

        public TaskResult<IEnumerable<StoryDetail>> GetStoriesForGroupByRequest(int groupId, DataRequest request)
        {
           TaskResult < IEnumerable < StoryDetail >> result = null;
           try
           {
               result = new TaskResult<IEnumerable<StoryDetail>> { state = StatusState.DoneState };

               IEnumerable<Story>  stories= _storyRepository.GetStoriesForGroup((int)groupId, request);
               result.Data = stories.Select(a => new StoryDetail { Content = a.Content, Description = a.Description, GroupDetails = a.Groups.Select(g => new GroupDetail { Description=g.Description,Id=g.Id,Name=g.Name}), Id = a.Id, PostedOn = a.DateCreated.Value, Title = a.Title, UserId = a.UserId }).AsEnumerable<StoryDetail>();
           }
           catch(Exception e)
           {
               Logger.Instance.LogException(e);
               result = new TaskResult<IEnumerable<StoryDetail>> { Data = null, state = StatusState.CancelState };
           }
           return result;
        }


        public TaskResult<IEnumerable<StoryDetail>> GetStoriesForUserByRequest(int userId, DataRequest request)
        {
            TaskResult<IEnumerable<StoryDetail>> result = null;
            try
            {
                result = new TaskResult<IEnumerable<StoryDetail>> { state = StatusState.DoneState };

                IEnumerable<Story> stories = _storyRepository.GetStoriesForUser((int)userId, request);
                result.Data = stories.Select(a => new StoryDetail 
                {
                    Content = a.Content, 
                    Description = a.Description,
                    GroupDetails = a.Groups.Select(g => new GroupDetail 
                    { 
                        Description = g.Description, 
                        Id = g.Id, Name = g.Name }),
                        Id = a.Id, 
                        PostedOn = a.DateCreated.Value, 
                        Title = a.Title, 
                        UserId = a.UserId 
                }).AsEnumerable<StoryDetail>();
            }
            catch (Exception e)
            {
                Logger.Instance.LogException(e);
                result = new TaskResult<IEnumerable<StoryDetail>> { Data = null, state = StatusState.CancelState };
            }
            return result;
        }

       
    }
}
