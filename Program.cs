using System.Data;
using CommaderGQL.GraphQL;
using CommaderGQL.GraphQL.Platforms;
using CommaderGQL.GraphQL.Commands;
using CommanderGQL.Data;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPooledDbContextFactory<AppDbContext>(opt =>
opt.UseSqlServer(builder.Configuration.GetConnectionString("CommandConStr")));

builder.Services
                .AddGraphQLServer()
                .AddQueryType<Query>()
                .AddSubscriptionType<Subscription>()
                .AddInMemorySubscriptions()
                .AddMutationType<Mutation>()
                .AddType<PlatFormType>()
                .AddType<CommaderGQL.GraphQL.Commands.CommandType>()
                .AddProjections();

var app = builder.Build();
app.UseWebSockets();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL();
});

app.UseGraphQLVoyager("/graphql-voyager", new GraphQL.Server.Ui.Voyager.VoyagerOptions()
{
    GraphQLEndPoint = "/graphql"
});

app.Run();
