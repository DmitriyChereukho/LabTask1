using _Source.Core.Scripts;
using UnityEngine;

namespace _Source.Game
{
    public class GameManager : MonoBehaviour
    {
        private ResourceBank _resourceBank;
        [SerializeField]
        private ResourceCounterManager _resourceCounterManager;

        private void Awake()
        {
            _resourceBank = new ResourceBank();
            
            _resourceBank.ChangeResource(GameResource.Humans, 10);
            _resourceBank.ChangeResource(GameResource.Food, 5);
            _resourceBank.ChangeResource(GameResource.Wood, 5);
            
            _resourceCounterManager.Init(_resourceBank);
        }
    }
}
