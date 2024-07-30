using Northwind.web.Models;
using Northwind.web.Results;
using Northwind.web.Results.Supplier_Result;

namespace Northwind.web.IService
{
    public interface ISuppliersService
    {
        Task<SuppliersGetListResult> GetSuppliersAsync();
        Task<SuppliersGetResult> GetSupplierByIdAsync(int id);
        Task<BaseResult> CreateSupplierAsync(SuppliersBaseModel customer);
        Task<BaseResult> UpdateSupplierAsync(int id, SuppliersBaseModel customer);
        Task<BaseResult> DeleteSupplierAsync(int id);
    }
}
