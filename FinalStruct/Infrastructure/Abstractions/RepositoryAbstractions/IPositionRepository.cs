using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Abstractions.RepositoryAbstractions
{
    public interface IPositionRepository
    {
        void CreatePosition(Position position);
        void UpdatePosition(int positionId, Position position);
        void DeletePosition(int positionId);
        IEnumerable<Position> GetAllPositions();
        Position GetPositionById(int positionId);
        IEnumerable<Position> GetFilteredBy(Func<Position, bool> filter);
    }
}
