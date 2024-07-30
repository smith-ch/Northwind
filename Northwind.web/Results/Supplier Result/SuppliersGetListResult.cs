using Northwind.web.Models;

namespace Northwind.web.Results.Supplier_Result
{
    public class SuppliersGetListResult : BaseResult
    {
        public List<SuppliersBaseModel> result {  get; set; }
    }
}
