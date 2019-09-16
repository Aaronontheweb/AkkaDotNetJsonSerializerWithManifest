using Akka.Actor;
using Akka.Configuration;
using System;
using System.IO;

namespace Demo
{
    public class MyJsonMsg
    {
        public MyJsonMsg(string foo, string bar)
        {
            Foo = foo;
            Bar = bar;
        }

        public string Foo { get; }

        public string Bar { get; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var config = File.ReadAllText("reference.conf");
            var actorSystem = ActorSystem.Create("JsonWithManifestDemo", 
                ConfigurationFactory.ParseString(config));

            var serializer = actorSystem.Serialization.FindSerializerForType(typeof(MyJsonMsg));
            actorSystem.Log.Info("Found serializer of type [{0}, Id={1}] for msg of type {2}", serializer, serializer.Identifier, typeof(MyJsonMsg));

            Console.ReadLine();
        }
    }
}
