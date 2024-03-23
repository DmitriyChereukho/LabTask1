using _Source.Core.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Source.Game
{
    public class ResourceVisual : MonoBehaviour
    { 
        [SerializeField]
        private GameResource _resource;
        
        [SerializeField]
        private TextMeshProUGUI _valueText;
        
        private ResourceBank _resourceBank;
        
        public void Init(ResourceBank resourceBank)
        {
            _resourceBank = resourceBank;
            _resourceBank.GetResource(_resource).OnValueChanged += OnResourceValueChanged;
        }

        private void OnResourceValueChanged(int value)
        {
            _valueText.text = $"{value}";
        }
    }
}
