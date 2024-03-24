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
        
        private float _productionTime = 1f;

        public void Init(ResourceBank resourceBank, GameResource resource, Image icon)
        {
            _producedResource = resource;
            _resourceBank = resourceBank;
            
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

            while (timer < _productionTime)
            {
                timer += Time.deltaTime;
                _sliderFill.fillAmount = timer / _productionTime;
                yield return null;
            }

            _resourceBank.ChangeResource(_producedResource, 1);
            
            _produceButton.interactable = true;
        }
    }
}
