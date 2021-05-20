using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Abstractions.ServiceAbstractions
{
    public interface IPositionService
    {
        public void CreatePosition(Position position);
        public void DeletePosition(int positionId);
        public void UpdatePosition(int positionId, Position position);
        IEnumerable<Position> GetAllPositions();
        Position GetPositionById(int positionId);
    }
}
