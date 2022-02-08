using C19M.Models.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;

namespace C19M.Infrastructure.Cache
{
    public class CacheRepository : IRedisRepository, IDisposable
    {
        private readonly RedisClient _client;

        public ILogger<CacheRepository> _logger;

        public CacheRepository(
            IConfiguration configuration,
            ILogger<CacheRepository> logger)
        {
            _logger = logger;
            _client = new RedisClient(configuration["Redis:Host"]);
        }

        public T Get<T>(string key, T @default)
        {
            _logger.LogInformation("Chave '{0}' pesquisada no cache!", key);

            if (_client.Exists(key) > 0)
                return _client.Get<T>(key);

            _logger.LogInformation("Chave '{0}' não localizada!", key);

            return @default;
        }

        public void Set<T>(string key, T value)
        {
            _logger.LogInformation("Chave '{0}' adicionada no cache!", key);
            _client.Set<T>(key, value);
        }

        public void Dispose()
        {
            _client.Dispose();
        }
    }
}
