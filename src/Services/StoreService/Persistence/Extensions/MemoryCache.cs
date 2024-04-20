using Microsoft.Extensions.Caching.Memory;

namespace StoreService.Persistence.Extensions;

public class MemoryCacheInjection
{
    public MemoryCache Cache { get; } = new MemoryCache(
        new MemoryCacheOptions
        {
            SizeLimit = 1024
        });
      
}