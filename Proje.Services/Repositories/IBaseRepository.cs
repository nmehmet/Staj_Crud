using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Proje.EntityFramework.Models;
using Proje.EntityFramework.Models.Responses;
using Proje.EntityFramework.Models.Requests;

namespace Proje.Services.Repositories
{
    public interface IBaseRepository<TRequest , TResponse> where TRequest: class       
                                                           where TResponse : class
    {
        public Task<List<TResponse>> GetAll();
        public Task<TResponse> GetById(int id);
        public Task<TResponse> Add(TRequest entity);
        public Task<TResponse> UpdateById(TRequest entity , int id);
        public Task<TResponse> Delete(int id);
        public Task Save();
    }
    public interface IProductRepoSitory : IBaseRepository<ProductRequest,ProductResponse>
    {
        public Task<ProductSoldResponse> Sold(ProductSoldRequest request);
        public new Task<ProductResponse> Add(ProductRequest request);
    }
    public interface IReceiptRepository : IBaseRepository<ReceiptRequest, ReceiptResponse>
    {
        public Task<ReceiptResponse> Buy(ReceipBuyRequest request);
        public Task<List<ReceiptView>> GetAllByView();
    }
    public interface ICustomerRepository : IBaseRepository<CustomerRequest, CustomerResponse>
    {

    }
    public interface IGroupRepository : IBaseRepository<GroupRequest, GroupResponse>
    {

    }
    public interface ISubGroupRepository : IBaseRepository<SubGroupRequest, SubGroupResponse>
    {

    }
}
