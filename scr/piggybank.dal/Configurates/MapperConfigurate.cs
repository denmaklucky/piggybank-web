using piggybank.dal.DTO;
using piggybank.dal.Models;
using AutoMapper;

namespace piggybank.dal.Configurates
{
    public static class MapperConfigurate
    {
        public static void Configurate()
        {
            var config = new MapperConfiguration(cfg => 
            {
                cfg.CreateMap<Transaction, TransactionDto>();
                cfg.CreateMap<Account, AccountDto>();
                cfg.CreateMap<Category, CategoryDto>();
            });

            Mapper = config.CreateMapper();
        }

        public static IMapper Mapper { get; set; }
    }
}
