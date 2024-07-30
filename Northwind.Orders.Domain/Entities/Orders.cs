using Northwind.Common.Data.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Orders.Domain.Entities
{
    public class Orders : BaseEntity<int>
    {
        public readonly int OrderID;

        [Column("OrderID")]
        public override int Id { get; set; }

        public string CustomerId { get; set; }

        public int? EmployeeID { get; set; }

        public DateTime? OrderDate { get; set; }

        public DateTime? RequiredDate { get; set; }

        public DateTime? ShippedDate { get; set; }

        public int? ShipVia { get; set; }

        public decimal? Freight { get; set; }

        public string? ShipName { get; set; }

        public string? ShipAddress { get; set; }

        public string? ShipCity { get; set; }

        public string? ShipRegion { get; set; }

        public string? ShipPostalCode { get; set; }

        public string? ShipCountry { get; set; }

        
    }
}
