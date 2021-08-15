using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ECommerceApi.Models;
using ECommerceApi.Services;
using GraphQL;
using GraphQL.Language.AST;
using GraphQL.Types;

namespace ECommerceApi.Contracts.GraphQL.Queries
{
    public class ItemQuery : ObjectGraphType
    {
        public ItemQuery(IItemService service)
        {
            Field<ListGraphType<ItemType>>(
                "items",
                resolve: context => service.GetAllItems(new GetItemsRequest())
            );
            
            Field<ItemType>(
                "item",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id"}),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return service.GetItemById(id);
                }
            );
        }
    }
}