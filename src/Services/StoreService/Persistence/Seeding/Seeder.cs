using Microsoft.EntityFrameworkCore;
using StoreService.Persistence.Seeding.Seeds;

namespace StoreService.Persistence.Seeding
{
    public static class Seeder
    {
        public static void Seed(this IApplicationBuilder app)
        {
            using IServiceScope scoped = app.ApplicationServices.CreateScope();
            var context = scoped.ServiceProvider.GetRequiredService<AppDbContext>();

            // Users
            var userSeeds = UserSeed.All;
            var userSeednames = userSeeds.ConvertAll(x => x.Name.ToLower());

            var alreadyAddedUsers = context.Users
                .Where(x => userSeednames.Contains(x.Name.ToLower()))
                .ToList();
            
            var toBeAddedUsers = userSeeds
                .Where(x => !alreadyAddedUsers.ConvertAll(y => y.Name).Contains(x.Name));

            foreach (var item in toBeAddedUsers)
            {
                context.Users.Add(item);
            }

            context.SaveChanges();
        }
    }
}