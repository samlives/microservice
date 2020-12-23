using RabbitMQ.Client;
using RabbitMQ.Client.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace EventBusRabbitMQ
{
    public class RabbitMQConnection : IRabbitMQConnection
    {

        private readonly IConnectionFactory _connectionFactory;
        private IConnection _connection;
        private bool _disposed;

        public RabbitMQConnection(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
            if (!IsConnected)
            {
                TyrConnect();
            }
        }

        public IConnection Connection
        {
            get
            {
                if (!IsConnected)
                {
                    TyrConnect();
                }
                return _connection;
            }
        }
        public bool IsConnected
        {
            get
            {
                return _connection != null && _connection.IsOpen && !_disposed;
            }
        }

        public IModel CreatModel()
        {
            if (!IsConnected)
            {
                throw new InvalidOperationException("Rabbit MQ not connected");
            }
            return Connection.CreateModel();
        }



        public bool TyrConnect()
        {
            try
            {
                _connection = _connectionFactory.CreateConnection();

            }
            catch (BrokerUnreachableException)
            {
                Thread.Sleep(2000);
                _connection = _connectionFactory.CreateConnection();

            }
            if (IsConnected)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Dispose()
        {
            if (_disposed) return;
            try
            {
                _connection.Dispose();
                _disposed = true;
            }
            catch (Exception)
            {
                _disposed = false;
                throw;
            }
        }
    }
}
