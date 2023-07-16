using CommanderGQL.Models;

namespace CommaderGQL.GraphQL
{

    public class Subscription
    {
        [Subscribe]
        [Topic]
        public Platform onPlatformAdded([EventMessage] Platform platform) => platform;
    }
}