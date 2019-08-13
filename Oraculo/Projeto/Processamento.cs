using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oraculo.Projeto
{
    public class Processamento
    {
        RabbitRepo rabbitRepo = new RabbitRepo();
        public void Receber()
        {            
            var redis = RedisRepo.getConnection().GetSubscriber();
            var db = RedisRepo.GetDb();
            Console.WriteLine("Serviço online!");
            redis.Subscribe("Perguntas", (ch, msg) =>
            {
                var array = msg.ToString().Split(":");
                rabbitRepo.Publicar(msg);
                //db.HashSet(array[0], new HashEntry[] { new HashEntry("Equipe 1-2-3", "Palmeiras não tem mundial") });
                //Console.WriteLine($"pergunta : {array[0]}, Hash: Equipe 1-2-3 | Palmeiras não tem mundial");
            });
            Console.ReadKey();
        }
    }
}
