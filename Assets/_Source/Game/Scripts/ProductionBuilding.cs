using System.Collections;
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
        
        private Image _sliderFill;
        
        private Coroutine _productionCoroutine;
        
        private ProductionLevels _productionLevels;
        
        private float _productionTime = 1f;
        
        public float ProductionTime
        {
            get => _productionTime * (1 - GetProdLvlModifier());
            set => _productionTime = value;
        }

        public void Init(ResourceBank resourceBank, GameResource resource, Image icon, ProductionLevels productionLevels)
        {
            _producedResource = resource;
            _resourceBank = resourceBank;
            _productionLevels = productionLevels;
            
            _produceButton = GetComponentInChildren<Button>();
            _produceButton.onClick.AddListener(StartProduction);

            _sliderFill = icon;
            
            gameObject.name = resource + "Production";
        }
        
        private void StartProduction()
        {
            _produceButton.interactable = false;
            _sliderFill.fillAmount = 0f;

            _productionCoroutine = StartCoroutine(ProduceResource());
        }

        private IEnumerator ProduceResource()
        {
            float timer = 0f;

            while (timer < ProductionTime)
            {
                timer += Time.deltaTime;
                _sliderFill.fillAmount = timer / ProductionTime;
                yield return null;
            }

            _resourceBank.ChangeResource(_producedResource, 1);
            
            _produceButton.interactable = true;
        }
        
        private float GetProdLvlModifier()
        {
            return _productionLevels.GetLevel(_producedResource).Value / 100f;
        }
    }
}
