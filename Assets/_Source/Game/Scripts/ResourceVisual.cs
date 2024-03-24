using _Source.Core.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Source.Game.Scripts
{
    public class ResourceVisual : MonoBehaviour
    { 
        private GameResource _resource;
        
        private ResourceBank _resourceBank;
        
        [SerializeField]
        private TextMeshProUGUI _valueText;
        
        [SerializeField]
        private Image _icon;
        
        [SerializeField]
        private GameObject _counterIncreaseButtonPrefab;


        public void Init(ResourceBank resourceBank, GameResource resource)
        {
            _resourceBank = resourceBank;
            _resource = resource;
            
            _resourceBank.GetResource(_resource).OnValueChanged += OnResourceValueChanged;

            _icon.sprite = Resources.Load<Sprite>($"Icons/{resource}");
            _valueText.text = $"{resource}\n{_resourceBank.GetResource(resource).Value}";
            gameObject.name = resource + "Counter";

            GameObject button = Instantiate(_counterIncreaseButtonPrefab, transform);
            button.GetComponent<ProductionBuilding>().Init(_resourceBank, resource);
        }

        private void OnResourceValueChanged(int value)
        {
            _valueText.text = $"{_resource}\n{_resourceBank.GetResource(_resource).Value}";
        }
    }
}
