using Northwind.Data.Context; 
using Northwind.Employees.Domain.Interfaces;
using System.Linq.Expressions;
using DomainEntities = Northwind.Employees.Domain.Entities;

namespace Northwind.Employees.Persistence.Repository 
{
    public class EmployeesRepository : IEmployeesRepository
    {
        private readonly NorthwindDbContext _context; 

        public EmployeesRepository(NorthwindDbContext context) 
        {
            _context = context;
        }

        public bool Exists(Expression<Func<DomainEntities.Employees, bool>> filter)
        {
            return _context.Employees.Any(filter);
        }

        public List<DomainEntities.Employees> GetAll()
        {
            return _context.Employees.ToList();
        }

        public List<DomainEntities.Employees> GetEmployeesByEmployeeID(int EmployeeID)
        {
            return _context.Employees.Where(employee => (int)employee.EmployeeID == EmployeeID).ToList();
        }

        public DomainEntities.Employees GetEntityBy(int Id)
        {
            return _context.Employees.Find(Id);
        }

        public void Remove(DomainEntities.Employees entity)
        {
            _context.Employees.Remove(entity);
            _context.SaveChanges();
        }

        public void Save(DomainEntities.Employees entity)
        {
            _context.Employees.Add(entity);
            _context.SaveChanges();
        }

        public void Update(DomainEntities.Employees entity)
        {
            _context.Employees.Update(entity);
            _context.SaveChanges();
        }
    }
}
