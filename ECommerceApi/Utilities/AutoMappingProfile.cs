using AutoMapper;
using ECommerceApi.Contracts;
using ECommerceApi.Models;

namespace ECommerceApi.Utilities
{
    public class AutoMappingProfile: Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<Item, ItemFull>();
            CreateMap<ItemFull, Item>();
            CreateMap<ItemCreateRequest, Item>();
        }
    }
}