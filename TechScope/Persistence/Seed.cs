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
            if (!userManager.Users.Any() && !context.Courses.Any())
            {
                var users = new List<User>
                {
                    new User{
                        UserDob=DateTime.Parse("2001-08-08"),
                        UserName="RinaK", Email="rk48713@ubt-uni.net" }
                    ,
                     new User{
                        UserDob=DateTime.Parse("1998-11-11"),
                        UserName="DoruntinaK", Email="dk40651@ubt-uni.net" },
                      new User{
                        UserDob=DateTime.Parse("2001-08-08"),
                        UserName="GentiA", Email="ga47388@ubt-uni.net" }
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
                        User = users[0],
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
                        User = users[1],
                        AppTags = null,
                        Videos = null
                    }
                    
                };

                await context.Courses.AddRangeAsync(courses);
                await context.SaveChangesAsync();

            }


           
        }
    }
}
