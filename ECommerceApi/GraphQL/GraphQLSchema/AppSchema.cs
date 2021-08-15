using System;
using ECommerceApi.Contracts.GraphQL.Queries;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerceApi.GraphQL.GraphQLSchema
{
    public class AppSchema: Schema
    {
        public AppSchema(IServiceProvider provider)
            :base(provider)
        {
            Query = provider.GetRequiredService<ItemQuery>();
        }    
    }
}