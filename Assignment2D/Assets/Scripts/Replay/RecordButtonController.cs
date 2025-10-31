using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RecordReplayButton : MonoBehaviour
{
    [SerializeField] private Invoker _invoker; 
    [SerializeField] private Button _button;
    [SerializeField] private TMP_Text _label;
    [SerializeField] private TMP_Text _status;

    private void Reset()
    {
        _button = GetComponent<Button>();
        _label = GetComponentInChildren<TMP_Text>();
    }

    private void Start()
    {
        _button.onClick.AddListener(OnButtonClick);
    }

    private void Update()
    {
        UpdateStatusText();
    }

    private void UpdateStatusText()
    {
        if (_invoker.IsRecording)
        {
            _status.text = "Recording...";
            _label.text = "Replay";
        }
        else if (_invoker.IsReplaying)
        {
            _status.text = "Replaying...";
            _label.text = "Record";
        }
        else
        {
            _status.text = " ";
            _label.text = "Record";
        }
    }

    private void OnButtonClick()
    {
        if (_invoker.IsReplaying)
        {
            return;
        }

        if (!_invoker.IsRecording)
        {
            Debug.Log("레코드 시작");
            _invoker.StartRecording();
        }
        else
        {
            Debug.Log("리플레이 시작");
            _invoker.StartReplay();
        }
    }
}
