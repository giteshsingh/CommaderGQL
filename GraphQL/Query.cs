using System.Linq;
using CommanderGQL.Data;
using CommanderGQL.Models;

namespace CommaderGQL.GraphQL
{
    public class Query
    {

        public IQueryable<Platform> GetPlatform([Service] AppDbContext context, int? id)
        {
            return context.Platforms.Where(x => x.Id == id.Value);
        }
    }
}