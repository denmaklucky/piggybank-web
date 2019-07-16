using piggybank.dal.Models;
using AutoMapper;
using AutoMapper.Configuration;
using piggybank.dal.Dto;

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
            config.CreateMap<CategoryDto, Category>();
            config.CreateMap<AccountDto, Account>();

            Mapper.Reset();
            Mapper.Initialize(config);
        }
    }
}
