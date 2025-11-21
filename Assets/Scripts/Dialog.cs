using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class Dialog : MonoBehaviour
{
    [SerializeField] private string[] lines;
    [SerializeField] private string name;
    [SerializeField] private TextMeshProUGUI dialogText;

    public UnityEvent OnDialogStarted;
    public UnityEvent OnDialogEnded;
    
    private int dialogProgress = 0;

    public void Next()
    {
        if (++dialogProgress >= lines.Length)
        {
            OnDialogEnded?.Invoke();
            gameObject.SetActive(false);
        }
        else
        {
            dialogText.SetText($"{name}:\n{lines[dialogProgress]}");
        }
    }

    public void StartDialog()
    {
        OnDialogStarted?.Invoke();
        dialogProgress = 0;
        dialogText.SetText($"{name}:\n{lines[dialogProgress]}");
    }
    
}
