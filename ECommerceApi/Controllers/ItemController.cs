using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ECommerceApi.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ECommerceApi.Models;
using ECommerceApi.Services;
using Swashbuckle.Swagger.Annotations;

namespace ECommerceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        /// <summary>
        /// Получение каталога товаров
        /// </summary>
        /// <param name="pageNumber">Номер страницы в поиске</param>
        /// <param name="pageSize">Количество товаров на странице</param>
        /// <param name="type">Тип товара</param>
        /// <param name="priceFrom">Минимальная цена товара</param>
        /// <param name="priceTo">Максимальная цена товара</param>
        /// <returns>Список товаров</returns>
        // GET: api/Item
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(IEnumerable<ItemFull>))]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemFull>>> GetItems(int pageNumber = 1, int pageSize = 50, string type = null, decimal? priceFrom = null, decimal? priceTo = null)
        {
            return new(await _itemService.GetAllItems(new GetItemsRequest()
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                Type = type,
                PriceFrom = priceFrom,
                PriceTo = priceTo
            }));
        }

        /// <summary>
        /// Получение товара по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Товар</returns>
        // GET: api/Item/5
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(ItemFull))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemFull>> GetItem(int id)
        {
            var item = await _itemService.GetItemById(id);
            if (item == null)
                return NotFound();
            return item;
        }
        
        /// <summary>
        /// Получение товара по SKU
        /// </summary>
        /// <param name="sku">SKU</param>
        /// <returns>Товар</returns>
        // GET: api/Item/sku/abc
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(ItemFull))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [HttpGet("sku/{sku}")]
        public async Task<ActionResult<ItemFull>> GetItem(string sku)
        {
            var item = await _itemService.GetItemBySku(sku);
            if (item == null)
                return NotFound();
            return item;
        }

        /// <summary>
        /// Редактирование товара по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="item">Измененный товар</param>
        /// <returns></returns>
        // PUT: api/Item/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.BadRequest, Description = "Id не совпадает")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItem(int id, ItemFull item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            await _itemService.EditItemById(id, item);

            return NoContent();
        }
        
        /// <summary>
        /// Редактирование товара по SKU
        /// </summary>
        /// <param name="sku">SKU</param>
        /// <param name="item">Измененный товар</param>
        /// <returns></returns>
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.BadRequest, Description = "SKU не совпадает")]
        [HttpPut("sku/{sku}")]
        public async Task<IActionResult> PutItem(string sku, ItemFull item)
        {
            if (sku != item.Sku)
            {
                return BadRequest();
            }

            await _itemService.EditItemBySku(sku, item);

            return NoContent();
        }

        /// <summary>
        /// Создание товара
        /// </summary>
        /// <param name="item">Товар</param>
        /// <returns>Товар с идентификатором</returns>
        // POST: api/Item
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(ItemFull))]
        [SwaggerResponse(HttpStatusCode.BadRequest, Description = "SKU существует")]
        [HttpPost]
        public async Task<ActionResult<ItemFull>> PostItem(ItemCreateRequest item)
        {
            return new(await _itemService.CreateItem(item));
        }

        /// <summary>
        /// Удаление товара по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns></returns>
        // DELETE: api/Item/5
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            await _itemService.DeleteItemById(id);
            return NoContent();
        }
        
        /// <summary>
        /// Удаление товара по SKU
        /// </summary>
        /// <param name="sku">SKU</param>
        /// <returns></returns>
        // DELETE: api/Item/sku/abc
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [HttpDelete("sku/{sku}")]
        public async Task<IActionResult> DeleteItem(string sku)
        {
            await _itemService.DeleteItemBySku(sku);
            return NoContent();
        }
    }
}
