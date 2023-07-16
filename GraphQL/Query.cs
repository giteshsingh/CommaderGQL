using System.Linq;
using CommanderGQL.Data;
using CommanderGQL.Models;

namespace CommaderGQL.GraphQL
{
    public class Query
    {

        [UseDbContext(typeof(AppDbContext))]
        public IQueryable<Platform> GetPlatform([ScopedService] AppDbContext context)
        {
            return context.Platforms;
        }

        [UseDbContext(typeof(AppDbContext))]
        public IQueryable<Command> GetCommand([ScopedService] AppDbContext context)
        {
            return context.Commands;
        }
    }
}