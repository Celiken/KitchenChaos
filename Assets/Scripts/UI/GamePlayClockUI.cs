using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayClockUI : MonoBehaviour
{
    [SerializeField] private Image timerImage; 

    // Update is called once per frame
    void Update()
    {
        timerImage.fillAmount = GameManager.Instance.GetPlayTimerNormalized();
    }
}
