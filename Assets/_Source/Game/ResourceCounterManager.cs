using _Source.Core.Scripts;
using TMPro;
using UnityEngine;

namespace _Source.Game
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
                GameObject counter = Instantiate(_resourceCounterPrefab);
                
                counter.name = resource + "Counter";
                TextMeshProUGUI text = counter.GetComponentInChildren<TextMeshProUGUI>();
                text.text = $"{_resourceBank.GetResource(resource).Value}";
            }
        }
    }
}