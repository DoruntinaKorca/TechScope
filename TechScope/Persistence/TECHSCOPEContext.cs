using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class TECHSCOPEContext : IdentityDbContext<User>
    {
        public TECHSCOPEContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AppTag> AppTags { get; set; }
          public DbSet<Comment> Comments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Preference> Preferences { get; set; }
        public DbSet<Tag> Tags { get; set; }
        //   public DbSet<User> Users { get; set; }
        public DbSet<UserPreference> UserPreferences { get; set; }
        public DbSet<UserRole> UserRoless { get; set; }
        public DbSet<Video> Videos { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AppTag>(entity =>
            {

            /*    


                    modelBuilder.Entity<AppTag>()
                .Property<Guid>("UserRoleId");
                modelBuilder.Entity<AppTag>()
             .Property<Guid>("TagName");


*/
                entity.HasKey("TagName","CourseId" );
            
              //  entity.HasKey(e => new { e.CourseId, e.TagName });

                // entity.Property(e => e.CourseId).HasColumnName("courseId");

                entity.HasOne(d => d.Course)
                .WithMany(p => p.AppTags)
                .HasForeignKey("CourseId");
                


            });

            
            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasKey(e => e.CommentId);

                entity.Property(e => e.CommentId).HasColumnName("commentID");

              //  entity.Property(e => e.AuthorId).HasColumnName("authorID");

                entity.Property(e => e.CommentContent)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("commentContent");

              //  entity.Property(e => e.CourseId).HasColumnName("courseID");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("dateCreated");

                entity.Property(e => e.ReplyTo).HasColumnName("replyTo");

                modelBuilder.Entity<Comment>()
             .Property<Guid>("CourseId");
                modelBuilder.Entity<Comment>()
            .Property<string>("Id");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Comments)
                    .HasForeignKey("Id")
                    .HasConstraintName("FK_Comments_Users");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Comments)
                    .HasForeignKey("CourseId")
                    .HasConstraintName("FK_Comments_Courses");

                modelBuilder.Entity<Comment>()
            .Property<string>("ReplyTo");
                entity.HasOne(d => d.ReplyToC)
                    .WithMany(p => p.InverseReplyTo)
                    .HasForeignKey("ReplyTo")
                    .HasConstraintName("FK_Comments_Comments");
            });

            
            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.CourseId)
                    .HasName("PK_Course");

                entity.Property(e => e.CourseId).HasColumnName("courseId");

                entity.Property(e => e.CourseApprovedBy).HasColumnName("courseApprovedBy");

                entity.Property(e => e.CourseDescription)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("courseDescription");

                entity.Property(e => e.CourseRating).HasColumnName("courseRating");

                entity.Property(e => e.CourseTitle)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("courseTitle");

                entity.Property(e => e.CourseViews).HasColumnName("courseViews");

                entity.Property(e => e.DateModified)
                    .HasColumnType("datetime")
                    .HasColumnName("dateModified");

                entity.Property(e => e.DateUploaded)
                    .HasColumnType("datetime")
                    .HasColumnName("dateUploaded");

                modelBuilder.Entity<Course>()
         .Property<string>("Id");

                entity.HasOne(d => d.User)
                   .WithMany(p => p.Courses)
                   .HasForeignKey("Id");

                //    entity.Property(e => e.UserId).HasColumnName("userId").IsRequired();


            });

            modelBuilder.Entity<Preference>(entity =>
            {
                entity.HasKey(e => e.PreferenceId);



                entity.Property(e => e.PreferenceId).HasColumnName("preferenceId");

                entity.Property(e => e.PreferenceName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("preferenceName");
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.HasKey(e => e.TagId);


                entity.Property(e => e.TagId).HasColumnName("tagId");

                entity.Property(e => e.TagName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("tagName");
            });

            modelBuilder.Entity<User>(entity =>
            {


                entity.Property(e => e.UserDob)
                    .HasColumnType("date")
                    .HasColumnName("userDOB");


                /*
                entity.Property(e => e.UserFirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("userFirstName");

                entity.Property(e => e.UserLastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("userLastName");
                */


              //  modelBuilder.Entity<User>()
          // .Property<int>("UserRoleId");

                //  entity.Property(e => e.UserRoleId).IsRequired().HasColumnName("userRoleId");
                /*
                entity.HasOne(d => d.UserRolee)
                    .WithMany(p => p.Users)
                    .HasForeignKey("UserRoleId");
                 */



            });

            modelBuilder.Entity<UserPreference>(entity =>
            {


                modelBuilder.Entity<UserPreference>()
            .Property<Guid>("PreferenceId");
                modelBuilder.Entity<UserPreference>()
            .Property<string>("UserId");



                entity.HasKey("PreferenceId", "UserId");

                entity.HasOne(d => d.Preference)
                   .WithMany(p => p.UserPreferences)
                   .HasForeignKey("PreferenceId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserPreferences)
                    .HasForeignKey("UserId").OnDelete(DeleteBehavior.Cascade);

                //   entity.Property(e => e.PreferenceId).HasColumnName("preferenceId");

                //   entity.Property(e => e.UserId).HasColumnName("userId");



            });

            
             /*
            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => e.UserRoleId);


                entity.Property(e => e.UserRoleId).HasColumnName("userRoleId");

                entity.Property(e => e.UserRoleDescription)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("userRoleDescription");
            }); */

            
            modelBuilder.Entity<Video>(entity =>
            {
                entity.HasKey(e => e.VideoId);

                modelBuilder.Entity<Video>()
              .Property<Guid>("CourseId");
                entity.HasOne(d => d.Course)
                 .WithMany(p => p.Videos)
                 .HasForeignKey("CourseId").OnDelete(DeleteBehavior.Cascade);

                entity.Property(e => e.VideoId).HasColumnName("videoId");

                //  entity.Property(e => e.CourseId).IsRequired().HasColumnName("courseId");

                entity.Property(e => e.VideoDescription)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("videoDescription");

                entity.Property(e => e.VideoLength).IsRequired().HasColumnName("videoLength");

                entity.Property(e => e.VideoTitle)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("videoTitle");


            });

        }
    }
}
