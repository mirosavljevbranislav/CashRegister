using AutoMapper;
using CashRegister.API.Dto;
using CashRegister.Domain.Dto;
using CashRegister.Domain.Models;

namespace CashRegister.API.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();
            CreateMap<Bill, BillDto>();
            CreateMap<BillDto, Bill>();
        }
    }
}
