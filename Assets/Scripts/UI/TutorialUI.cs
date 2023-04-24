using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TutorialUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI keyMoveUp;
    [SerializeField] private TextMeshProUGUI keyMoveDown;
    [SerializeField] private TextMeshProUGUI keyMoveLeft;
    [SerializeField] private TextMeshProUGUI keyMoveRight;
    [SerializeField] private TextMeshProUGUI keyInteract;
    [SerializeField] private TextMeshProUGUI keyInteractAlt;
    [SerializeField] private TextMeshProUGUI keyPause;
    [SerializeField] private TextMeshProUGUI gamepadMove;
    [SerializeField] private TextMeshProUGUI gamepadInteract;
    [SerializeField] private TextMeshProUGUI gamepadInteractAlt;
    [SerializeField] private TextMeshProUGUI gamepadPause;

    private void Start()
    {
        GameInput.Instance.OnRebind += GameInput_OnRebind;
        GameManager.Instance.OnStateChanged += GameManager_OnStateChanged;
        UpdateVisual();
        Show();
    }

    private void GameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (GameManager.Instance.IsCountdownToStartActive())
            Hide();
    }

    private void GameInput_OnRebind(object sender, System.EventArgs e)
    {
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        keyMoveUp.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Up);
        keyMoveDown.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Down);
        keyMoveLeft.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Left);
        keyMoveRight.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Right);
        keyInteract.text = GameInput.Instance.GetBindingText(GameInput.Binding.Interact);
        keyInteractAlt.text = GameInput.Instance.GetBindingText(GameInput.Binding.InteractAlt);
        keyPause.text = GameInput.Instance.GetBindingText(GameInput.Binding.Pause);
        gamepadInteract.text = GameInput.Instance.GetBindingText(GameInput.Binding.Gamepad_Interact);
        gamepadInteractAlt.text = GameInput.Instance.GetBindingText(GameInput.Binding.Gamepad_InteractAlt);
        gamepadPause.text = GameInput.Instance.GetBindingText(GameInput.Binding.Gamepad_Pause);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
