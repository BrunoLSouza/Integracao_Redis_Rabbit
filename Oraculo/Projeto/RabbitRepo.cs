using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oraculo.Projeto
{
    public class RabbitRepo
    {        
        IConnection connection;

        public RabbitRepo()
        {
            var factory = new ConnectionFactory()
            {
                UserName = "user",
                Password = "fiap",
                HostName = "23.99.218.43"
            };

            connection = factory.CreateConnection();            
        }
        public void Publicar(string mensagem)
        {
            var channel = connection.CreateModel();
            Byte[] body = Encoding.UTF8.GetBytes(mensagem);

            channel.BasicPublish(
                exchange: "EnviarOperador",
                routingKey: "",
                basicProperties: null,
                body: body);

            Console.WriteLine(mensagem);

        }
    }
}
