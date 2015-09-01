using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTypes;
using DBSource.EntityMapping;
using Utils;
namespace DBSource
{
    public class EFDataContext:DbContext
    {
        public EFDataContext() : base() { }
        public DbSet<User> Users { get; set; }

        public DbSet<Story> Stories { get; set; }

        public DbSet<Group> Groups { get; set; }

        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new MyDbContextInitializer());
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new GroupMap());
            modelBuilder.Configurations.Add(new StoryMap());
            modelBuilder.Entity<Group>().MapToStoredProcedures().HasMany<Story>(s=>s.Stories).WithMany(a=>a.Groups).Map(cs=>{cs.MapLeftKey("GroupId");cs.MapRightKey("StoryId");cs.ToTable("StoryGroups");});
            modelBuilder.Entity<User>().MapToStoredProcedures().HasMany<Group>(s => s.UserGroups).WithMany(a => a.Users).Map(cs => { cs.MapLeftKey("UserId"); cs.MapRightKey("GroupId"); cs.ToTable("UserGroups"); });
            modelBuilder.Entity<Story>().MapToStoredProcedures();
            base.OnModelCreating(modelBuilder);
        }
    }
    public class MyDbContextInitializer : DropCreateDatabaseIfModelChanges<EFDataContext>
    {
        protected override void Seed(EFDataContext dbContext)
        {
            // seed data
            var ids = Enumerable.Range(1, 10);

            List<Group> groups = new List<Group>();
            foreach (var i in ids)
            {
               Group g = new Group
                {
                    Description = "Description" + i,
                    Name = "Name" + i,
                    DateCreated = DateTime.Now
                };
                dbContext.Groups.Add(g);
                groups.Add(g);
            }

            foreach (var i in ids)
            {
                var user = new User
                {
                    DateCreated = DateTime.Now,
                    UserName = "UserName"+i,
                    Password = "Password".Md5Hash()
                };
                dbContext.Users.Add(user);
                for(int j =0;j<1;j++)
                {
                    var story = new Story
                    {
                        DateCreated = DateTime.Now,
                        Content = "Story Content" + i+"_"+j,
                        Description = "Story Description" + "_" + j,
                        Title = "Story Title" + "_" + j,
                        User = user
                    };
                    story.Groups = groups;
                    dbContext.Stories.Add(story);
                }
                
            }
            dbContext.SaveChanges();
            
        }
       
    }
}
