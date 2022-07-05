using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnterGamePanelManager : MonoBehaviour
{
    [SerializeField] string[] dishNames;
    [SerializeField] Sprite[] collectibleImages;
    [SerializeField] TMP_Text dishName;
    [SerializeField] Image collectibles;

    int destinationIndex;

    private void Start()
    {
        destinationIndex = PlayerPrefs.GetInt("TargetLevelIndex") - 3;
        dishName.text = dishNames[destinationIndex];
        collectibles.sprite = collectibleImages[destinationIndex];
    }
}
