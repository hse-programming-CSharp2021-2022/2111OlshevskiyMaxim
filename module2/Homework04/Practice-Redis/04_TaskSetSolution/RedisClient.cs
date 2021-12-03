using System;
using System.Collections.Generic;
using System.Linq;
using StackExchange.Redis;

namespace TaskSetSolution
{
    public static class RedisClient
    {
        private static ConnectionMultiplexer redis;
        private static IDatabase database;
        private static IServer server;

        public static void Connect()
        {
            redis = ConnectionMultiplexer.Connect("redis-19918.c293.eu-central-1-1.ec2.cloud.redislabs.com:19918," +
                "password=8dvNax6TF21kIPj7LICuyccxf4mubOGt,ConnectTimeout=10000,allowAdmin=true");
            database = redis.GetDatabase();
            server = redis.GetServer("redis-19918.c293.eu-central-1-1.ec2.cloud.redislabs.com", 19918);
        }

        public static void AddOne(string storage, string key)
        {
            if (Exist(storage, key))
            {
                database.StringIncrement($"{storage} {key}");
            }
            else
            {
                database.StringSet($"{storage} {key}", 1);
            }
        }

        public static void RemoveOne(string storage, string key)
        {
            if (database.StringDecrement($"{storage} {key}") <= 0)
            {
                database.KeyDelete($"{storage} {key}");
            }
        }

        public static bool Exist(string storage, string key) => database.KeyExists($"{storage} {key}");

        public static long GetAsLong(string storage, string key) => (long)database.StringGet($"{storage} {key}");

        /// <summary>
        /// Get keys in Redis server with special beginning.
        /// </summary>
        /// <param name="keyBeginning"> Special beginning. </param>
        public static string[] GetKeys(string keyBeginning)
        {
            return server.Keys(pattern: $"{keyBeginning}*")
                .Select(x => x.ToString())
                .ToArray();
        }
    }
}