using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface ISpesimenRepository: ICommonRepository<Spesimen>
    {
        // void Update(Survey survey);
        // void Add(Survey survey);
        void AddItemsRange(IEnumerable<SpesimenItem> entities);
        void AddItem(SpesimenItem item);
        void UpdateItem(SpesimenItem item);
        // Task<bool> SaveAllAsync();
        Task<IEnumerable<SpesimenDTO>> GetAsync();
        //Task<IEnumerable<SurveyDTO>> GetUserActiveAsync(bool isActive);
        Task<SpesimenDTO> GetSpesimenDTOByIdAsync(int id);
        Task<IEnumerable<SpesimensInPointDTO>> SpesimensInPoint(int pointId, DateTime dateC, int categoryId, int qsId);
        Task<IEnumerable<SpesimenDashboardDTO>> GetSpesimenDashboard();
        
    }
}