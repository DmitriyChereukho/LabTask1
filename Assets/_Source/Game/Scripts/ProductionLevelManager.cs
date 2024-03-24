using _Source.Core.Scripts;
using UnityEngine;

namespace _Source.Game.Scripts
{
    public class ProductionLevelManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject _productionLevelPrefab;
        
        private ProductionLevels _productionLevels;
        
        public void Init(ProductionLevels productionLevels)
        {
            _productionLevels = productionLevels;
            foreach (GameResource resource in System.Enum.GetValues(typeof(GameResource)))
            {
                GameObject productionLevel = Instantiate(_productionLevelPrefab, transform);
                productionLevel.GetComponent<ProductionLevel>().Init(_productionLevels, resource);
            }
        }
    }
}