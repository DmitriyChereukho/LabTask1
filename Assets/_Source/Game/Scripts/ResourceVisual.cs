using _Source.Core.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Source.Game.Scripts
{
    public class ResourceVisual : MonoBehaviour
    { 
        private GameResource _resource;
        
        [SerializeField]
        private TextMeshProUGUI _valueText;
        
        private ResourceBank _resourceBank;
        
        [SerializeField]
        private Image _icon;
        
        public void Init(ResourceBank resourceBank, GameResource resource)
        {
            _resourceBank = resourceBank;
            _resourceBank.GetResource(_resource).OnValueChanged += OnResourceValueChanged;
            
            _icon.sprite = Resources.Load<Sprite>($"Icons/{resource}");
            _valueText.text = $"{resource}\n{_resourceBank.GetResource(resource).Value}";
            gameObject.name = resource + "Counter";
        }

        private void OnResourceValueChanged(int value)
        {
            _valueText.text = $"{value}";
        }
    }
}
