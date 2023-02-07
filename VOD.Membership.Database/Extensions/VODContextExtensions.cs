namespace VOD.Films.Database.Extensions;

public static class VODContextExtensions
{
    public static async Task SeedMembershipData(IDbService service)
    {
        var description = " Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus imperdiet vulputate libero, ac lacinia turpis rhoncus sed. Maecenas maximus massa accumsan lectus convallis molestie. Praesent tincidunt sed tellus a rutrum. Maecenas placerat lectus sed nisl aliquet aliquam. Nulla sed consectetur enim. Donec a facilisis eros. Aliquam ut felis at risus finibus vulputate. Donec ac enim lectus. Sed lobortis viverra arcu, sed rhoncus leo finibus eget. Sed eu porta sem. Curabitur nec mattis sem.\r\n\r\nDuis eget odio felis. Proin enim ex, tempus vel urna et, facilisis posuere orci. Mauris sit amet nulla et enim euismod eleifend. Phasellus ultrices, turpis sed imperdiet ullamcorper, sem est sollicitudin justo, ut volutpat ex leo pellentesque neque. Sed egestas, dolor a dignissim porttitor, eros leo pellentesque risus, in dictum tellus nibh a sem. Suspendisse aliquam, erat vel placerat aliquet, lectus sem lobortis felis, a vestibulum est ipsum ac felis. Suspendisse ut sapien in sapien blandit pretium ac quis metus. Nunc sem magna, vulputate vel massa id, dictum efficitur lectus.\r\n\r\nNullam et justo rhoncus, porttitor augue non, maximus nibh. Quisque nec aliquam libero. Pellentesque fermentum mollis sem a placerat. Morbi vulputate risus felis. Nunc porttitor tortor sed dui dictum efficitur. Morbi consectetur et ex vel vehicula. In egestas tristique tincidunt. Aliquam tristique vehicula nisi, nec euismod nunc efficitur et. Vestibulum consectetur elit sed elit sagittis, ac efficitur magna mollis. Ut eu turpis est. Suspendisse mollis dolor vel nibh tincidunt pretium. Nunc bibendum vitae erat eu luctus. Morbi eget diam vel massa pellentesque placerat eu non tellus. ";

        try
        {
            await service.AddAsync<Director, DirectorDTO>( new DirectorDTO
            {
                Name = "James Cameron"
            });
            
            await service.SaveChangesAsync();

        }
        catch (Exception ex)
        {

        }
    }
}
