using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C19M.Models.Repositories
{
    public interface IRedisRepository
    {
        public T Get<T>(string key, T @default);

        public void Set<T>(string key, T value);

    }
}
