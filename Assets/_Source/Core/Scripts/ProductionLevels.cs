using System.Collections.Generic;

namespace _Source.Core.Scripts
{
    public class ProductionLevels
    {
        private readonly Dictionary<GameResource, ObservableInt> _levels = new();
        
        public ProductionLevels()
        {
            foreach (GameResource resource in System.Enum.GetValues(typeof(GameResource)))
            {
                _levels.Add(resource, new ObservableInt(1));
            }
        }
        
        public void LevelUp(GameResource resource, int value)
        {
            _levels[resource].Value += value;
        }
        
        public ObservableInt GetLevel(GameResource resource)
        {
            return _levels[resource];
        }
    }
}