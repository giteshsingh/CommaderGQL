using CommanderGQL.Data;
using CommanderGQL.Models;

namespace CommaderGQL.GraphQL.Commands
{

    public class CommandType : ObjectType<Command>
    {
        protected override void Configure(IObjectTypeDescriptor<Command> descriptor)
        {
            descriptor
                    .Field(c => c.Platform)
                    .ResolveWith<Resolvers>(c =>
                        c.GetPlatform(default, default));


        }

        public class Resolvers
        {
            public Platform GetPlatform(Command command, [ScopedService] AppDbContext context)
            {
                return context.Platforms.FirstOrDefault(p => p.Id == command.Id);
            }
        }
    }
}