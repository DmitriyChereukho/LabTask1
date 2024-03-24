using _Source.Core.Scripts;
using UnityEngine;

namespace _Source.Game.Scripts
{
    public class GameManager : MonoBehaviour
    {
        private ResourceBank _resourceBank;
        
        private ProductionLevels _productionLevels;
        
        [SerializeField]
        private ResourceCounterManager _resourceCounterManager;
        
        [SerializeField]
        private ProductionLevelManager _productionLevelManager;

        private void Awake()
        {
            _resourceBank = new ResourceBank();
            _productionLevels = new ProductionLevels();
            
            _resourceBank.ChangeResource(GameResource.Humans, 10);
            _resourceBank.ChangeResource(GameResource.Food, 5);
            _resourceBank.ChangeResource(GameResource.Wood, 5);
            
            _resourceCounterManager.Init(_resourceBank, _productionLevels);
            
            _productionLevelManager.Init(_productionLevels);
        }
    }
}
