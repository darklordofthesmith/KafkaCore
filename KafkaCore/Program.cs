using System;
using System.Collections.Generic;
using System.Text;
using Confluent.Kafka;
using Confluent.Kafka.Serialization;

namespace KafkaCore
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new Dictionary<string, object>
            {
                {"bootstrap.servers", "localhost:9092"}
            };

            using (var producer = new Producer<Null,string>(config,null,new StringSerializer(Encoding.UTF8)))
            {
                string text = null;

                while (text != "exit")
                {
                    text = Console.ReadLine();
                    producer.ProduceAsync("test-topic", null, text);
                }
            }
        }
    }
}
