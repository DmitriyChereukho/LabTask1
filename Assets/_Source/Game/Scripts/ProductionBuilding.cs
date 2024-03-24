using _Source.Core.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Source.Game.Scripts
{
    public class ProductionBuilding : MonoBehaviour
    {
        private GameResource _producedResource;

        private ResourceBank _resourceBank;
        
        private Button _produceButton;

        public void Init(ResourceBank resourceBank, GameResource resource)
        {
            _producedResource = resource;
            _resourceBank = resourceBank;
            
            _produceButton = GetComponent<Button>();
            _produceButton.onClick.AddListener(IncrementResource);
            
            gameObject.name = resource + "Button";
        }

        private void IncrementResource()
        {
            _resourceBank.ChangeResource(_producedResource, 1);
        }
    }
}
