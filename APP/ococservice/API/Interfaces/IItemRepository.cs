using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface IItemRepository: ICommonRepository<Item>
    {
        /*
        void Update(Item item);
        void Add(Item item);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<Item>> GetItemAsync();
        IEnumerable<Item> GetItem();
        Task<IEnumerable<Item>> GetUnitAsync();
        IEnumerable<Unit> GetUnit();
        Task<Item> GetItemByIdAsync(int id);
        Task<Unit> GetUnitByIdAsync(int id);
        Task<Item> GetItemByNameAsync(string NameOrAbbr);
        Task<Unit> GetUnitByNameAsync(string NameOrAbbr);
        Item GetItemByName(string NameOrAbbr);
        Unit GetUnitByName(string NameOrAbbr);
        */
        Item GetByName(string NameOrAbbr);
        Task<IEnumerable<ItemDTO>> GetItemByCategoryAsync(int categoryId);
        Task<IEnumerable<ItemDTO>> GetItemsAsync();
        
    }
}