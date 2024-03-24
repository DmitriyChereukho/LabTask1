using _Source.Core.Scripts;
using UnityEngine;

namespace _Source.Game.Scripts
{
    public class ResourceCounterManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject _resourceCounterPrefab;

        private ResourceBank _resourceBank;

        public void Init(ResourceBank resourceBank)
        {
            _resourceBank = resourceBank;
            foreach (GameResource resource in System.Enum.GetValues(typeof(GameResource)))
            {
                GameObject counter = Instantiate(_resourceCounterPrefab, transform);
                counter.GetComponent<ResourceVisual>().Init(_resourceBank, resource);
            }
            
        }
    }
}