using Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(TECHSCOPEContext context, UserManager<User> userManager)
        {
            if ( !userManager.Users.Any() && !context.Courses.Any() && !context.Videos.Any() )
            {
               

                var users = new List<User>
                {
                    new User{
                        UserDob=DateTime.Parse("2001-08-08"),
                        UserName="RinaK", Email="rk48713@ubt-uni.net",
                        //UserRolee = userRoles[3]
                         }
                    ,
                     new User{
                        UserDob=DateTime.Parse("1998-11-11"),
                        UserName="DoruntinaK", Email="dk40651@ubt-uni.net",
                  //   UserRolee = userRoles[1]
                },
                      new User{
                        UserDob=DateTime.Parse("2001-08-08"),
                        UserName="GentiA", Email="ga47388@ubt-uni.net" ,
                    //  UserRolee = userRoles[0]
                      },
                      new User{
                        UserDob=DateTime.Parse("2001-08-08"),
                        UserName="DoriK", Email="doruntina@gmail.com" ,
                     //   UserRolee = userRoles[2]
                      }
                };
                foreach (var user in users)
                {
                    //a number an upper case, a lowercase letter, at least 6chars
                    await userManager.CreateAsync(user, "Pa$$word1");
                }


                var courses = new List<Course>
                {
                    new Course
                    {
                        CourseTitle = ".net course for beginners",
                        CourseDescription = "learn the basics of .net",
                        DateUploaded = DateTime.Now.AddMonths(-2),
                        DateModified = DateTime.Now.AddMonths(-1),
                        CourseViews = null,
                        CourseRating = null,
                        CourseApprovedBy = null,
                        User = users[0],
                        AppTags = null,
                        Videos = null
                    },
                    new Course
                    {
                        CourseTitle = ".net course for beginners",
                        CourseDescription = "learn the basics of .net",
                        DateUploaded = DateTime.Now.AddMonths(-2),
                        DateModified = DateTime.Now.AddMonths(-1),
                        CourseViews = null,
                        CourseRating = null,
                        CourseApprovedBy = null,
                        User = users[1],
                        AppTags = null,
                        Videos = null
                    },
                    new Course{
                        CourseTitle = ".net course for beginners",
                        CourseDescription = "learn the basics of .net",
                        DateUploaded = DateTime.Now.AddMonths(-2),
                        DateModified = DateTime.Now.AddMonths(-1),
                        CourseViews = null,
                        CourseRating = null,
                        CourseApprovedBy = null,
                        User = users[2],
                        AppTags = null,
                        Videos = null
                    }

                };
                var videos = new List<Video>
                {
                    new Video
                    {
                        VideoTitle = "Test video title",
                        VideoDescription = "Test video descp",
                        VideoLength = 10,
                        Course = courses[0]
                    },
                    new Video
                    {
                        VideoTitle = "Test video title2",
                        VideoDescription = "Test video descp2",
                        VideoLength = 20,
                        Course = courses[1]
                    },
                    new Video
                    {
                        VideoTitle = "Test video title3",
                        VideoDescription = "Test video descp3",
                        VideoLength = 30,
                        Course = courses[1]
                    },
                    new Video
                    {
                        VideoTitle = "Test video title4",
                        VideoDescription = "Test video descp4",
                        VideoLength = 40,
                        Course = courses[2],
                    },
                    new Video
                    {
                        VideoTitle = "Test video title5",
                        VideoDescription = "Test video descp5",
                        VideoLength = 50,
                        Course = courses[2]
                    },
                    new Video
                    {
                        VideoTitle = "Test video title6",
                        VideoDescription = "Test video descp6",
                        VideoLength = 60,
                        Course = courses[2]
                    },
                    new Video
                    {
                        VideoTitle = "Test video title7",
                        VideoDescription = "Test video descp7",
                        VideoLength = 70,
                        Course = courses[1]
                    }
                };

                // context.UserRoless.AddRange(userRoles);
                context.Courses.AddRange(courses);
                context.Videos.AddRange(videos);
                await context.SaveChangesAsync();

            }

            

           



        }
    }
}
