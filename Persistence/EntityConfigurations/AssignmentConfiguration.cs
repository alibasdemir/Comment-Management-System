using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    public class AssignmentConfiguration : IEntityTypeConfiguration<Assignment>
    {
        public void Configure(EntityTypeBuilder<Assignment> builder)
        {
            Assignment[] assignmentSeeds =
            {
                new Assignment
                {
                    Id = 1,
                    Title = "Lorem Ipsum 1",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Enim lobortis scelerisque fermentum dui faucibus. Eu volutpat odio facilisis mauris sit amet massa. Amet consectetur adipiscing elit ut aliquam. Egestas quis ipsum suspendisse ultrices gravida dictum fusce ut.",
                    CreatedDate = new DateTime(1999, 01, 01, 0, 0, 0, DateTimeKind.Utc),
                },
                new Assignment
                {
                    Id = 2,
                    Title = "Lorem Ipsum 2",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Tellus molestie nunc non blandit. Diam sollicitudin tempor id eu nisl. Volutpat lacus laoreet non curabitur gravida arcu ac tortor dignissim. Risus at ultrices mi tempus imperdiet nulla malesuada pellentesque.",
                    CreatedDate = new DateTime(1998, 02, 02, 0, 0, 0, DateTimeKind.Utc),
                },
                new Assignment
                {
                    Id = 3,
                    Title = "Lorem Ipsum 3",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Tristique senectus et netus et malesuada. Placerat orci nulla pellentesque dignissim enim. Nibh sit amet commodo nulla facilisi nullam vehicula ipsum a. Rutrum tellus pellentesque eu tincidunt tortor aliquam nulla facilisi.",
                    CreatedDate = new DateTime(1997, 03, 03, 0, 0, 0, DateTimeKind.Utc),
                },
                new Assignment
                {
                    Id = 4,
                    Title = "Lorem Ipsum 4",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Varius quam quisque id diam vel. Ac felis donec et odio pellentesque diam volutpat. Mauris vitae ultricies leo integer malesuada nunc vel risus commodo. Nulla aliquet porttitor lacus luctus accumsan tortor.",
                    CreatedDate = new DateTime(1997, 04, 04, 0, 0, 0, DateTimeKind.Utc),
                },
                new Assignment
                {
                    Id = 5,
                    Title = "Lorem Ipsum 5",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Dis parturient montes nascetur ridiculus mus. Venenatis lectus magna fringilla urna porttitor rhoncus dolor. Lectus quam id leo in vitae turpis massa sed. Nisi lacus sed viverra tellus in hac.",
                    CreatedDate = new DateTime(1996, 05, 05, 0, 0, 0, DateTimeKind.Utc),
                },
            };
            builder.HasData(assignmentSeeds);
        }
    }
}
