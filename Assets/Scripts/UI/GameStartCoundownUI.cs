using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Search;
using UnityEngine;

public class GameStartCoundownUI : MonoBehaviour
{
    private const string NUMBER_POP_UP = "NumberPopUp";

    [SerializeField] private TextMeshProUGUI gameStartCountdownText;

    private Animator animator;
    private int previousCountdownNumber;

    private void Start()
    {
        animator = GetComponent<Animator>();
        GameManager.Instance.OnStateChanged += GameManager_OnStateChanged;
        Hide();
    }

    private void Update()
    {
        int countdownNumber = Mathf.CeilToInt(GameManager.Instance.GetCountdownToStartTimer());
        gameStartCountdownText.text = countdownNumber.ToString();
        if (previousCountdownNumber != countdownNumber)
        {
            previousCountdownNumber = countdownNumber;
            animator.SetTrigger(NUMBER_POP_UP);
            SoundManager.Instance.PlayCountdownSound();
        }
    }

    private void GameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (GameManager.Instance.IsCountdownToStartActive())
        {
            Show();
        } else
        {
            Hide();
        }
    }

    private void Show()
    {
        gameStartCountdownText.gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameStartCountdownText.gameObject.SetActive(false);
    }
}
