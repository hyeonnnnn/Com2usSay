using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RecordReplayButton : MonoBehaviour
{
    [SerializeField] private Invoker _invoker; 
    [SerializeField] private Button _button;
    [SerializeField] private TMP_Text _label;

    private void Reset()
    {
        _button = GetComponent<Button>();
        _label = GetComponentInChildren<TMP_Text>();
    }
}
