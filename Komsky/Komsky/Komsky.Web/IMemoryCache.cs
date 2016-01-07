using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Web;

namespace Komsky.Web
{
public interface IMemoryCacheService
{
    MemoryCache MemoryCache
    {
        get;
        set;
    }
}

public class MemoryCacheService : IMemoryCacheService
{
    public MemoryCacheService()
    {
        MemoryCache = new MemoryCache("ServerTime");
    }

    public MemoryCache MemoryCache
    {
        get;
        set;
    }
}
}