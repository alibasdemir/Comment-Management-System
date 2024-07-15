using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            Comment[] commentSeeds =
            {
                new Comment
                {
                    Id = 1,
                    AssignmentId = 1,
                    UserId = 1,
                    Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Arcu non sodales neque sodales. Lectus sit amet est placerat in egestas. In cursus turpis massa tincidunt dui ut. A condimentum vitae sapien pellentesque habitant morbi tristique senectus et.",
                    CreatedDate =  new DateTime(2001, 01, 01, 0, 0, 0, DateTimeKind.Utc),
                },
                new Comment
                {
                    Id = 2,
                    AssignmentId = 2,
                    UserId = 1,
                    Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Commodo sed egestas egestas fringilla phasellus faucibus. Leo integer malesuada nunc vel risus commodo viverra maecenas accumsan. Auctor eu augue ut lectus arcu bibendum. Sit amet mattis vulputate enim nulla aliquet porttitor lacus.",
                    CreatedDate =  new DateTime(2002, 02, 02, 0, 0, 0, DateTimeKind.Utc),
                },
                new Comment
                {
                    Id = 3,
                    AssignmentId = 3,
                    UserId = 1,
                    Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Viverra justo nec ultrices dui sapien eget mi proin. Scelerisque viverra mauris in aliquam sem fringilla ut. Adipiscing bibendum est ultricies integer quis auctor. Erat imperdiet sed euismod nisi porta lorem mollis aliquam ut.",
                    CreatedDate =  new DateTime(2003, 03, 03, 0, 0, 0, DateTimeKind.Utc),
                },
                new Comment
                {
                    Id = 4,
                    AssignmentId = 1,
                    UserId = 2,
                    Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Aliquam nulla facilisi cras fermentum odio eu feugiat pretium. Sed euismod nisi porta lorem mollis aliquam. Nisi est sit amet facilisis magna etiam tempor orci eu. Dolor sit amet consectetur adipiscing elit duis.",
                    CreatedDate =  new DateTime(2004, 04, 04, 0, 0, 0, DateTimeKind.Utc),
                },
                new Comment
                {
                    Id = 5,
                    AssignmentId = 2,
                    UserId = 2,
                    Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Duis at consectetur lorem donec massa sapien faucibus et. Arcu felis bibendum ut tristique et egestas quis ipsum. Volutpat est velit egestas dui id ornare. Morbi tristique senectus et netus et malesuada.",
                    CreatedDate =  new DateTime(2005, 05, 05, 0, 0, 0, DateTimeKind.Utc),
                },
                new Comment
                {
                    Id = 6,
                    AssignmentId = 3,
                    UserId = 3,
                    Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Quis blandit turpis cursus in hac habitasse. Eget nunc scelerisque viverra mauris in aliquam sem fringilla. Semper eget duis at tellus at urna condimentum. Sit amet porttitor eget dolor morbi.",
                    CreatedDate =  new DateTime(2006, 06, 06, 0, 0, 0, DateTimeKind.Utc),
                },
                new Comment
                {
                    Id = 7,
                    AssignmentId = 4,
                    UserId = 1,
                    Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Semper risus in hendrerit gravida. Et malesuada fames ac turpis egestas. Facilisis magna etiam tempor orci eu lobortis elementum nibh tellus. Vitae tempus quam pellentesque nec nam aliquam.",
                    CreatedDate =  new DateTime(2007, 07, 07, 0, 0, 0, DateTimeKind.Utc),
                },
            };
            builder.HasData(commentSeeds);
        }
    }
}
