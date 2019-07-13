using AutoMapper;
using AutoMapper.Configuration;
using piggybank.dal.Dto;
using piggybank.site.Models.ViewModel;

namespace piggybank.site.Configurates
{
    public static class MapperInit
    {
        public static void Configurate()
        {
            var config = new MapperConfigurationExpression();
            config.CreateMap<CategoryViewModel, CategoryDto>();

            Mapper.Reset();
            Mapper.Initialize(config);
        }
    }
}
