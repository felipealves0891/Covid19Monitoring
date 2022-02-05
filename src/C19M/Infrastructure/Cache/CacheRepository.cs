using C19M.Models.Repositories;
using Microsoft.Extensions.Configuration;
using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;


namespace C19M.Infrastructure.Cache
{
    public class CacheRepository : IRedisRepository, IDisposable
    {
        private readonly RedisClient _client;

        public CacheRepository(IConfiguration configuration)
        {
            _client = new RedisClient(configuration["Redis:Host"]);
        }

        public T Get<T>(string key)
        {
            return _client.Get<T>(key);
        }

        public void Set<T>(string key, T value)
        {
            _client.Set<T>(key, value);
        }

        public void Dispose()
        {
            _client.Dispose();
        }
    }
}
