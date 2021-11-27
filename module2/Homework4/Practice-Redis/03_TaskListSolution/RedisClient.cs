using StackExchange.Redis;

namespace TaskListSolution
{
    public static class RedisClient
    {
        private static ConnectionMultiplexer redis;
        private static IDatabase database;

        public static void Connect()
        {
            redis = ConnectionMultiplexer.Connect("redis-19918.c293.eu-central-1-1.ec2.cloud.redislabs.com:19918," +
                "password=8dvNax6TF21kIPj7LICuyccxf4mubOGt,ConnectTimeout=10000,allowAdmin=true");
            database = redis.GetDatabase();
        }

        public static string GetSet(string key, string value) => database.StringGetSet("HW4a" + key, value);

        public static bool Exist(string key) => database.KeyExists("HW4a" + key);

        public static void Set(string key, string value) => database.StringSet("HW4a" + key, value);

        public static string Get(string key) => database.StringGet("HW4a" + key);

        public static void Delete(string key) => database.KeyDelete("HW4a" + key);
    }
}