using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ACGMapping.Controllers;
using ACGMapping.InfraStructure.Interface;
using ACGMapping.Models;

namespace ACGMapping.InfraStructure.DB.Repo
{
    public class ACGBasicIntroductionRepository : IRepository<ACGBasicIntroductionTable, int>
    {
        private readonly MyContext _context;

        public ACGBasicIntroductionRepository(MyContext context)
        {
            _context = context;
        }
        public int Create(ACGBasicIntroductionTable entity)
        {
            entity.CreateDateTime = DateTime.Now;

            _context.ACGBasicIntroductionTable.Add(entity);
            _context.SaveChanges();

            return entity.Id;
        }

        public void Update(ACGBasicIntroductionTable entity)
        {
            var target = _context.ACGBasicIntroductionTable.Single(o => o.Id == entity.Id);

            _context.Entry(target).CurrentValues.SetValues(entity);

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var target = _context.ACGBasicIntroductionTable.Single(o => o.Id == id);

            target.Status = 99;

            _context.SaveChanges();
        }

        public ACGBasicIntroductionTable FindById(int id)
        {
            return _context.ACGBasicIntroductionTable.SingleOrDefault(o => o.Id == id);
        }

        public IEnumerable<ACGBasicIntroductionTable> Find(Expression<Func<ACGBasicIntroductionTable, bool>> expression)
        {
            return _context.ACGBasicIntroductionTable.Where(expression);
        }

        public IEnumerable<ACGBasicIntroductionTable> AllEntities()
        {
            return _context.ACGBasicIntroductionTable.Where(o => o.Status != 99);
        }
    }
}