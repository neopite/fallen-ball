using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;


public class LevelMenuController : MonoBehaviour
{
    [SerializeField] private List<Button> _allLevels;
    
    void Start()
    {
        int lastCompletedLevel = PlayerPrefs.GetInt("LevelComplete",1);
        for (int i = lastCompletedLevel+1; i < _allLevels.Count; i++)
        {
            _allLevels[i].interactable = false;
            SetButtonAvailabilityColor(_allLevels[i],1f);
        }
        for (int i = 1; i <= lastCompletedLevel; i++)
        {
            _allLevels[i].interactable = true; 
            SetButtonAvailabilityColor(_allLevels[i],0);
        }
    }

    private void SetButtonAvailabilityColor(Button button , float alpha)
    {
        var colorBlock = button.colors;
        var colorBlockNormalColor = colorBlock.normalColor;
        colorBlockNormalColor.a = alpha;
        colorBlock.normalColor = colorBlockNormalColor;
        button.colors = colorBlock;
    }
}
