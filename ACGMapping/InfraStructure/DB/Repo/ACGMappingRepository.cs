using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ACGMapping.Controllers;
using ACGMapping.InfraStructure.Interface;
using ACGMapping.Models;

namespace ACGMapping.InfraStructure.DB.Repo
{
    public class ACGMappingRepository : IRepository<ACGMappingTable, int>
    {
        private readonly MyContext _context;

        public ACGMappingRepository(MyContext context)
        {
            _context = context;
        }
        public int Create(ACGMappingTable entity)
        {
            entity.CreateDateTime = DateTime.Now;

            _context.ACGMappingTable.Add(entity);
            _context.SaveChanges();

            return entity.Id;
        }

        public void Update(ACGMappingTable entity)
        {
            var target = _context.ACGMappingTable.Single(o => o.Id == entity.Id);

            _context.Entry(target).CurrentValues.SetValues(entity);

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var target = _context.ACGMappingTable.Single(o => o.Id == id);

            target.Status = 99;

            _context.SaveChanges();
        }

        public ACGMappingTable FindById(int id)
        {
            return _context.ACGMappingTable.SingleOrDefault(o => o.Id == id);
        }

        public IEnumerable<ACGMappingTable> Find(Expression<Func<ACGMappingTable, bool>> expression)
        {
            return _context.ACGMappingTable.Where(expression);
        }

        public IEnumerable<ACGMappingTable> AllEntities()
        {
            return _context.ACGMappingTable.Where(o => o.Status != 99);
        }
    }
}