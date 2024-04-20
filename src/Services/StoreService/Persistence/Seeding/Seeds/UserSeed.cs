using Microsoft.AspNetCore.Identity;
using StackExchange.Redis;
using StoreService.Domain.Users;

namespace StoreService.Persistence.Seeding.Seeds;

internal static class UserSeed
{
    public static List<User> All => typeof(UserSeed).GetProperties().Where(x => x.Name != "All")
        .Select(x => x.GetValue(null) as User).ToList();

    public static User Sample1 { get; } = new()
    {
        Id = 1,
        Name = "Sample1",
        Orders = null,
        CreatedAt = DateTime.UtcNow,
        UpdatedAt = DateTime.UtcNow
    };

    public static User Sample2 { get; } = new()
    {
        Id = 2,
        Name = "Sample2",
        Orders = null,
        CreatedAt = DateTime.UtcNow,
        UpdatedAt = DateTime.UtcNow
    };

    public static User Sample3 { get; } = new()
    {
        Id = 3,
        Name = "Sample3",
        Orders = null,
        CreatedAt = DateTime.UtcNow,
        UpdatedAt = DateTime.UtcNow
    };

    public static User Sample4 { get; } = new()
    {
        Id = 4,
        Name = "Sample4",
        Orders = null,
        CreatedAt = DateTime.UtcNow,
        UpdatedAt = DateTime.UtcNow
    };

    public static User Sample5 { get; } = new()
    {
        Id = 5,
        Name = "Sample5",
        Orders = null,
        CreatedAt = DateTime.UtcNow,
        UpdatedAt = DateTime.UtcNow
    };
}