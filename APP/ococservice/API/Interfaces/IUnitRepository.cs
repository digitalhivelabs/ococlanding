using API.Entities;

namespace API.Interfaces
{
    public interface IUnitRepository: ICommonRepository<Unit>
    {
        Unit GetByName(string NameOrAbbr);
    }
}