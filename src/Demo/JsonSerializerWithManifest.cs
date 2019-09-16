using Akka.Actor;
using Akka.Configuration;
using Akka.Serialization;

namespace Demo
{
    public class JsonSerializerWithManifest : NewtonSoftJsonSerializer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NewtonSoftJsonSerializer" /> class.
        /// </summary>
        /// <param name="system">The actor system to associate with this serializer. </param>
        public JsonSerializerWithManifest(ExtendedActorSystem system)
            : base(system, NewtonSoftJsonSerializerSettings.Default)
        {
        }

        public JsonSerializerWithManifest(ExtendedActorSystem system, Config config)
            : base(system, NewtonSoftJsonSerializerSettings.Create(config))
        {
        }


        public JsonSerializerWithManifest(ExtendedActorSystem system, NewtonSoftJsonSerializerSettings settings)
            : base(system)
        {
        }

        /// <summary>
        ///  Always include manifest, so https://github.com/akkadotnet/akka.net/blob/36a7267393c86c14380d7c17205c866e58f3123c/src/contrib/persistence/Akka.Persistence.Sql.Common/Journal/QueryExecutor.cs#L695-L710
        ///  invokes manifest write to SQL.
        /// </summary>
        public override bool IncludeManifest => true;
    }
}
