using CommaderGQL.GraphQL;
using CommanderGQL.Data;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(opt =>
opt.UseSqlServer(builder.Configuration.GetConnectionString("CommandConStr")));

builder.Services
                .AddGraphQLServer()
                .AddQueryType<Query>();

var app = builder.Build();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL();
});


app.Run();
