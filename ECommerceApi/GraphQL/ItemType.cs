using ECommerceApi.Models;
using GraphQL.Language.AST;
using GraphQL.Types;

namespace ECommerceApi.Contracts.GraphQL
{
    public class ItemType: ObjectGraphType<ItemFull>
    {
        public ItemType()
        {
            Field(x => x.Id, type: typeof(IdGraphType));
            Field(x => x.Name);
            Field(x => x.Price);
            Field(x => x.Sku);
            Field(x => x.Type);
        }
    }
}