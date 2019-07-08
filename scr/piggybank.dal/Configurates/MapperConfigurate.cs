using piggybank.dal.DTO;
using piggybank.dal.Models;
using AutoMapper;
using AutoMapper.Configuration;

namespace piggybank.dal.Configurates
{
    public static class MapperConfigurate
    {
        public static void Configurate()
        {
            var config = new MapperConfigurationExpression();
            config.CreateMap<Transaction, TransactionDto>();
            config.CreateMap<Account, AccountDto>();
            config.CreateMap<Category, CategoryDto>();

            Mapper.Reset();
            Mapper.Initialize(config);
        }
    }
}
