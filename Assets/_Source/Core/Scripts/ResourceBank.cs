using System.Collections.Generic;
using UnityEngine;

namespace _Source.Core.Scripts
{
    public enum GameResource
    {
        Humans,
        Food,
        Wood,
        Stone,
        Gold
    }

    public class ResourceBank
    {
        private readonly Dictionary<GameResource, ObservableInt> _resources = new();

        public ResourceBank() {
            foreach (GameResource resource in System.Enum.GetValues(typeof(GameResource)))
            {
                _resources.Add(resource, new ObservableInt());
            }
        }
        
        public void ChangeResource(GameResource resource, int value)
        {
            _resources[resource].Value += value;
        }

        public ObservableInt GetResource(GameResource resource)
        {
            return _resources[resource];
        }
    }
}

