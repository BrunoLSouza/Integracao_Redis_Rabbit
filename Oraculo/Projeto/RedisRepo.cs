using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oraculo.Projeto
{
    public class RedisRepo
    {
        private static ConnectionMultiplexer _connection { get; set; }
        public static IDatabase GetDb()
        {
            var redis = _connection;
            return redis.GetDatabase();
        }

        public static ConnectionMultiplexer getConnection()
        {
            if (_connection is null)
                _connection = ConnectionMultiplexer.Connect("23.99.218.43");
                //_connection = ConnectionMultiplexer.Connect("localhost");
            return _connection;
        }
    }
}