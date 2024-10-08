using AutoMapper;
using Proje.EntityFramework.Models.Requests;
using Proje.EntityFramework.Models.Responses;
using Proje.EntityFramework.Models;

namespace Proje.Host.Mapper
{
    public class ResourceMapper : Profile
    {
        public ResourceMapper()
        {
            //Group
            CreateMap<GroupRequest, Group>().ReverseMap();
            CreateMap<Group, GroupResponse>().ReverseMap();
            //SubGroup
            CreateMap<SubGroupRequest,  SubGroup>().ReverseMap();
            CreateMap<SubGroup , SubGroupResponse>().ReverseMap();
            //Product
            CreateMap<ProductRequest, Product>().ReverseMap();
            CreateMap<Product, ProductResponse>().ReverseMap();
            //Receipt
            CreateMap<ReceiptRequest, Receipt>().ReverseMap();
            CreateMap<Receipt, ReceiptResponse>().ReverseMap();
            //Customer
            CreateMap<CustomerRequest, Customer>().ReverseMap();
            CreateMap<Customer, CustomerResponse>().ReverseMap();
            //Receipt => Product
            CreateMap<ReceipBuyRequest, ProductSoldRequest>()
                .ForMember(dest => dest.SoldProductId, opt => opt.MapFrom(src => src.BuyingProductid)).ReverseMap();
            CreateMap<ReceipBuyRequest, Receipt>().ReverseMap();
                



        }
    }
}
