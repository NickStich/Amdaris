using Domain;
using Infrastructure.Abstractions.RepositoryAbstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PositionRepository : IPositionRepository
    {
        private readonly AccountingAppDbContext _dbContext;

        public PositionRepository(AccountingAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void CreatePosition(Position position)
        {
            _dbContext.Positions.Add(position);
            _dbContext.SaveChanges();
        }

        public void DeletePosition(int positionId)
        {
            _dbContext.Remove(_dbContext.Positions.Single(p => p.Id == positionId));
            _dbContext.SaveChanges();
        }

        public IEnumerable<Position> GetAllPositions()
        {
            return _dbContext.Positions;
        }

        public IEnumerable<Position> GetFilteredBy(Func<Position, bool> filter)
        {
            return _dbContext.Positions.Where(filter);
        }

        public Position GetPositionById(int positionId)
        {
            return _dbContext.Positions.Find(positionId); 
        }

        public void UpdatePosition(int positionId, Position position)
        {
            var positionToModify = _dbContext.Positions.First(p => p.Id == positionId);
            if (positionToModify != null)
            {
                positionToModify.Product = position.Product;
                positionToModify.Quantity = position.Quantity;
                positionToModify.Invoice = position.Invoice;
                _dbContext.SaveChanges();
            }
        }
    }
}
