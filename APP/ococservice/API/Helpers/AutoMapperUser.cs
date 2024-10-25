using API.DTOs;
using API.Entities;
using AutoMapper;
using Semaphore = API.Entities.Semaphore;

namespace API.Helpers
{
    public class AutoMapperUser : Profile
    {
        public AutoMapperUser()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
            CreateMap<Item, ItemDTO>()
                .ForMember(dest => dest.UnitName,
                    opt => opt.MapFrom(src => src.Unit.Name))
                .ForMember(dest => dest.ClassificationName,
                    opt => opt.MapFrom(src => src.Classification.Name))
                .ForMember(dest => dest.CategoryName,
                    opt => opt.MapFrom(src => src.Category.Name));
            CreateMap<Unit, UnitDTO>()
                .ForMember(dest => dest.BaseUnitName,
                    opt => opt.MapFrom(src => src.BaseUnit.Name));
            CreateMap<Documento, DocumentDTO>();
            CreateMap<DocumentUDTO, Documento>();

            CreateMap<Spesimen, SpesimenDTO>()
                .ForMember(dest => dest.LocationName,
                    opt => opt.MapFrom(src => src.Point.Name))
                .ForMember(dest => dest.LocationLatLon,
                    opt => opt.MapFrom(src => src.Point.Lat.ToString() + " " + src.Point.Lon.ToString() ));
            CreateMap<SpesimenItem, SpesimenItemDTO>()
                .ForMember(dest => dest.ItemName,
                    opt => opt.MapFrom(src => src.Item.Name))
                .ForMember(dest => dest.ItemAbbr,
                    opt => opt.MapFrom(src => src.Item.Abbr))
                .ForMember(dest => dest.UnitName,
                    opt => opt.MapFrom(src => src.Unit.Name))
                .ForMember(dest => dest.UnitAbbr,
                    opt => opt.MapFrom(src => src.Unit.Abbr))
                .ForMember(dest => dest.UnitBaseName,
                    opt => opt.MapFrom(src => src.UnitBase.Name));      
            // Inputs            
            CreateMap<SpesimenItemI2DTO, SpesimenItem>();
            CreateMap<SpesimenI2DTO, Spesimen>();
            CreateMap<SpesimenIDTO, Spesimen>();
            CreateMap<SpesimenItem, SpesimenDashboardDTO>()
                .ForMember(dest => dest.SpecimenDate,
                    opt => opt.MapFrom(src => src.Spesimen.SpesimenDate))
                .ForMember(dest => dest.Laboratory,
                    opt => opt.MapFrom(src => src.LabName))
                .ForMember(dest => dest.Point,
                    opt => opt.MapFrom(src => src.Spesimen.Point.Name))
                .ForMember(dest => dest.Place,
                    opt => opt.MapFrom(src => src.Spesimen.Point.Place.Name))
                .ForMember(dest => dest.Parameter,
                    opt => opt.MapFrom(src => src.Item.Name));

            CreateMap<Country, CountryDTO>()
                .ForMember(dest => dest.DisplayName,
                    opt => opt.MapFrom(src => src.Name));
            CreateMap<State, StateDTO>()
                .ForMember(dest => dest.DisplayName,
                    opt => opt.MapFrom(src => src.Name));            
            CreateMap<Category, CategoryDTO>()
                .ForMember(dest => dest.DisplayName,
                    opt => opt.MapFrom(src => src.Name));            
            CreateMap<SubCategory, SubCategoryDTO>()
                .ForMember(dest => dest.DisplayName,
                    opt => opt.MapFrom(src => src.Name));                  
            CreateMap<SubCategory, SubCategoryODTO>()
                .ForMember(dest => dest.DisplayName,
                    opt => opt.MapFrom(src => src.Name));             
            CreateMap<Point, PointDTO>();

            CreateMap<Place, PlaceDTO>()
                .ForMember(dest => dest.DisplayName,
                    opt => opt.MapFrom(src => src.Name));

            CreateMap<SemaphoreIDTO, Semaphore>();
            CreateMap<Semaphore, SemaphoreDTO>();
            CreateMap<SemaphoreDTO, Semaphore>();

            CreateMap<QualityStandardItemRange, QualityStandardItemRangeDTO>();
            CreateMap<QualityStandardItem, QualityStandardItemODTO>()
                .ForMember(dest => dest.Name,
                    opt => opt.MapFrom(src => src.Item.Name))
                .ForMember(dest => dest.Abbr,
                    opt => opt.MapFrom(src => src.Item.Abbr))
                .ForMember(dest => dest.UnitName,
                    opt => opt.MapFrom(src => src.Unit.Name))
                .ForMember(dest => dest.Ranges,
                        opt => opt.MapFrom(src => src.QualityStandardItemRanges));
            CreateMap<QualityStandard, QualityStandardO2DTO>()
                .ForMember(dest => dest.Items,
                        opt => opt.MapFrom(src => src.QualityStandardItems));
            CreateMap<QualityStandard, QualityStandardODTO>();
            CreateMap<QualityStandardIDTO, QualityStandard>()
                .ForMember(dest => dest.QualityStandardItems,
                        opt => opt.MapFrom(src => src.Items));
            CreateMap<QualityStandardItemIDTO, QualityStandardItem>()
                .ForMember(dest => dest.QualityStandardItemRanges,
                        opt => opt.MapFrom(src => src.Ranges));
            CreateMap<QualityStandardItemRangeIDTO, QualityStandardItemRange>();
            CreateMap<QualityStandardItemRangeI2DTO, QualityStandardItemRange>();
            CreateMap<QualityStandardUDTO, QualityStandard>();
            


            /*
            // Ejemplo de Mappeo

            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.PhotUrl,
                    opt => opt.MapFrom(src => src.Photos.FirstOrDefault(x => x.IsMain).Url))
                .ForMember(dest => dest.Age,
                    opt => opt.MapFrom(src => src.Brithday.CalculateAge()));

            CreateMap<Photo PhotoDTO>();

            */
        }
    }
}