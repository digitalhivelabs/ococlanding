using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using Semaphore = API.Entities.Semaphore;

namespace API.Interfaces
{
    public interface IQualityStandardRepository: ICommonRepository<QualityStandard>
    {
        Task<IEnumerable<QualityStandardODTO>> GetAsync();
        Task<IEnumerable<QualityStandardO2DTO>> GetDetails(int Id);
        // Task<bool> UpdateItem(int Id);
        QualityStandardItem GetItem(int Id);
        QualityStandardItemRange GetItemRange(int Id);
        
        void AddItemsRange(IEnumerable<QualityStandardItem> entities);
        void AddItem(QualityStandardItem item);
        void UpdateItem(QualityStandardItem item);
        void DeleteItem(QualityStandardItem item);
        void DeleteItemRangeRange(IEnumerable<QualityStandardItemRange> entities);
        

        void AddItemRangesRange(IEnumerable<QualityStandardItemRange> entities);
        void AddItemRange(QualityStandardItemRange item);
        void UpdateItemRange(QualityStandardItemRange item);
        void DeleteItemRange(QualityStandardItemRange item);

        void AddItemRangesRangeSemaphore(Semaphore item);
    }
}