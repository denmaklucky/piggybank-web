using AutoMapper;
using piggybank.dal.Configurates;
using piggybank.dal.DTO;
using piggybank.dal.Enums;
using piggybank.dal.Models;
using System;
using Xunit;

namespace piggybank.dal.test
{
    public class MapperTest
    {
        [Fact]
        public void MapperConfigurateTest()
        {
            MapperConfigurate.Configurate();
            var mapper = MapperConfigurate.Mapper;

            #region Transaction

            var tempTran = new Transaction
            {
                Id = 1,
                AccountId = 1,
                CategoryId = 1,
                Comment = "Hello, world!",
                CreatedBy = 1,
                CreatedOn = DateTime.Now,
                Amount = 1564.3M
            };

            var tempTranDto = mapper.Map<TransactionDto>(tempTran);

            Assert.Equal(tempTran.Id, tempTranDto.Id);
            Assert.Equal(tempTran.AccountId, tempTranDto.AccountId);
            Assert.Equal(tempTran.CategoryId, tempTranDto.CategoryId);
            Assert.Equal(tempTran.Comment, tempTranDto.Comment);
            Assert.Equal(tempTran.CreatedBy, tempTranDto.CreatedBy);
            Assert.Equal(tempTran.CreatedOn, tempTranDto.CreatedOn);
            Assert.Equal(tempTran.Amount, tempTranDto.Amount);

            #endregion

            #region Account

            var tempAcc = new Account
            {
                Id = 1,
                Balance = 123.4M,
                CreatedBy = 1,
                CreatedOn = DateTime.Now,
                Currency = "$",
                IsArchived = false,
                IsDeleted = true,
                ModifiedOn = DateTime.Now,
                Title = "LimeCredit",
                Type = AccountType.BankAccount
            };

            var tempAccDto = mapper.Map<Account>(tempAcc);

            Assert.Equal(tempAcc.Id, tempAccDto.Id);
            Assert.Equal(tempAcc.Balance, tempAccDto.Balance);
            Assert.Equal(tempAcc.CreatedBy, tempAccDto.CreatedBy);
            Assert.Equal(tempAcc.CreatedOn, tempAccDto.CreatedOn);
            Assert.Equal(tempAcc.Currency, tempAccDto.Currency);
            Assert.Equal(tempAcc.IsArchived, tempAccDto.IsArchived);
            Assert.Equal(tempAcc.IsDeleted, tempAccDto.IsDeleted);
            Assert.Equal(tempAcc.ModifiedOn, tempAccDto.ModifiedOn);
            Assert.Equal(tempAcc.Title, tempAccDto.Title);
            Assert.Equal(tempAcc.Type, tempAccDto.Type);

            #endregion

            #region Category

            var tempCat = new Category
            {
                Id = 1,
                CreatedBy = 1,
                CreatedOn = DateTime.Now,
                HexColor = "#b65da0",
                IsDeleted = false,
                IsRequired = true,
                ModifiedOn = DateTime.Now,
                Title = "Pet",
                Type = CategoryType.Income
            };

            var tempCatDto = mapper.Map<CategoryDto>(tempCat);

            Assert.Equal(tempCat.Id, tempCatDto.Id);
            Assert.Equal(tempCat.HexColor, tempCatDto.HexColor);
            Assert.Equal(tempCat.IsDeleted, tempCatDto.IsDeleted);
            Assert.Equal(tempCat.IsRequired, tempCatDto.IsRequired);
            Assert.Equal(tempCat.ModifiedOn, tempCatDto.ModifiedOn);
            Assert.Equal(tempCat.Title, tempCatDto.Title);
            Assert.Equal(tempCat.Type, tempCatDto.Type);

            #endregion
        }
    }
}
