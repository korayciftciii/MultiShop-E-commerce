using StackExchange.Redis;

namespace MultiShop.Basket.Settings
{
    public class RedisService
    {
        private ConnectionMultiplexer _connectionMultiplexer;
        public string _host { get; set; }
        public int _port { get; set; }

        public RedisService(int port, string host)
        {
            _port = port;
            _host = host;
        }
        public void Connect() => _connectionMultiplexer = ConnectionMultiplexer.Connect($"{_host}:{_port}");
        public IDatabase GetDb(int db = 1) => _connectionMultiplexer.GetDatabase(0);
    }
}
