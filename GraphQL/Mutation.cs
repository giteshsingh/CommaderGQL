using CommaderGQL.GraphQL.Platforms;
using CommanderGQL.Data;
using CommanderGQL.Models;
using HotChocolate.Subscriptions;

namespace CommaderGQL.GraphQL
{

    public class Mutation
    {

        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddPlatformPayload> AddPlatformAsync(AddPlatformInput input,
         [ScopedService] AppDbContext context,
         [Service] ITopicEventSender eventSender,
         CancellationToken cancellationToken)
        {
            var platform = new Platform
            {
                Name = input.Name,
                LicenseKey = input.LicenseKey
            };

            context.Platforms.Add(platform);
            await context.SaveChangesAsync(cancellationToken);
            await eventSender.SendAsync(nameof(Subscription.onPlatformAdded), platform, cancellationToken);
            return new AddPlatformPayload(platform);
        }

    }
}