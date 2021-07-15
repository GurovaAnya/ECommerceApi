using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ECommerceApi.Contracts;
using ECommerceApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApi.Services
{
    public class ItemService: IItemService
    {
        private readonly ECommerceDbContext _context;
        private readonly IMapper _mapper;

        public ItemService(ECommerceDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<ItemFull> CreateItem(ItemCreateRequest item)
        {
            var itemEntity = _mapper.Map<Item>(item);
            
            _context.Items.Add(itemEntity);
            await _context.SaveChangesAsync();

            return _mapper.Map<ItemFull>(itemEntity);
        }

        public async Task EditItemById(int id, ItemFull item)
        {
            var itemEntity = _mapper.Map<Item>(item);
            _context.Entry(itemEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IdExists(id))
                {
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task EditItemBySku(string sku, ItemFull item)
        {
            var itemEntity = _mapper.Map<Item>(item);
            _context.Entry(itemEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SkuExists(sku))
                {
                }
                else
                {
                    throw;
                }
            };
        }

        public async Task DeleteItemById(int id)
        {
            var item = await _context.Items.FindAsync(id);
            if (item == null)
            {
                return;
            }

            _context.Items.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteItemBySku(string sku)
        {
            var item = await _context.Items.FirstOrDefaultAsync(x => x.Sku == sku);
            if (item == null)
            {
                return;
            }

            _context.Items.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task<ItemFull> GetItemById(int id)
        {
            var itemEntity = await _context.Items.FindAsync(id);

            if (itemEntity == null)
            {
                return null;
            }

            return _mapper.Map<ItemFull>(itemEntity);
        }

        public async Task<ItemFull> GetItemBySku(string sku)
        {
            var itemEntity = await _context.Items.FirstOrDefaultAsync(x => x.Sku == sku);

            if (itemEntity == null)
            {
                return null;
            }

            return _mapper.Map<ItemFull>(itemEntity);;
        }

        public async Task<IEnumerable<ItemFull>> GetAllItems(int pageNumber = 1, int pageSize = 50)
        {
            var items = await _context.Items
                .Skip(pageNumber*pageSize)
                .Take(pageSize)
                .ToListAsync();

            return _mapper.Map<IEnumerable<ItemFull>>(items);
        }
        
        private bool IdExists(int id)
        {
            return _context.Items.Any(e => e.Id == id);
        }
        
        private bool SkuExists(string sku)
        {
            return _context.Items.Any(e => e.Sku == sku);
        }
    }
}