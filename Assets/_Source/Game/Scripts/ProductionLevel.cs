using _Source.Core.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Source.Game.Scripts
{
    public class ProductionLevel : MonoBehaviour
    {
        private GameResource _resource;
        
        private ProductionLevels _productionLevels;
        
        [SerializeField]
        private Button _levelUpButton;
        
        [SerializeField]
        private TextMeshProUGUI _levelText;
        
        
        public void Init(ProductionLevels productionLevels, GameResource resource)
        {
            _productionLevels = productionLevels;
            _resource = resource;
            
            gameObject.name = resource + "ProductionLevel";
            
            _productionLevels.GetLevel(_resource).OnValueChanged += OnProductionChangeLevel;
            
            _levelUpButton.onClick.AddListener(OnProductionLevelUp);
            
            _levelText.text = $"{_resource} production\nlvl. {_productionLevels.GetLevel(_resource).Value}";
        }
        
        private void OnProductionLevelUp()
        {
            _productionLevels.LevelUp(_resource, 1);
        }

        private void OnProductionChangeLevel(int value)
        {
            _levelText.text = $"{_resource} production\nlvl. {_productionLevels.GetLevel(_resource).Value}";
        }
    }
}