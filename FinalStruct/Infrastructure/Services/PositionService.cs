using Domain;
using Infrastructure.Abstractions.RepositoryAbstractions;
using Infrastructure.Abstractions.ServiceAbstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class PositionService : IPositionService
    {
        private readonly IPositionRepository _positionRepository;

        public PositionService(IPositionRepository positionRepository)
        {
            _positionRepository = positionRepository;
        }
        public void CreatePosition(Position position)
        {
            _positionRepository.CreatePosition(position);
        }

        public void DeletePosition(int positionId)
        {
            _positionRepository.DeletePosition(positionId);
        }

        public IEnumerable<Position> GetAllPositions()
        {
            return _positionRepository.GetAllPositions();
        }

        public Position GetPositionById(int positionId)
        {
            return _positionRepository.GetPositionById(positionId);
        }

        public void UpdatePosition(int positionId, Position position)
        {
            _positionRepository.UpdatePosition(positionId, position);
        }
    }
}
