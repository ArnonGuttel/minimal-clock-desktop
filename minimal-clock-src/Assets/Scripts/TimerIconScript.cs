using TMPro;
using UnityEngine;

public class TimerIconScript : MonoBehaviour
{
    [SerializeField] private GameObject timerPopUp;
    [SerializeField] private GameObject timer;
    [SerializeField] private TextMeshProUGUI timerTimeLeft;

    private TimerScript _timerScript;

    private void Start()
    {
        _timerScript = timer.GetComponent<TimerScript>();
    }

    private void OnMouseDown()
    {
        timerPopUp.SetActive(true);
    }

    private void OnMouseUp()
    {
        timerPopUp.SetActive(false);
    }

    private void Update()
    {
        if (timerPopUp.activeInHierarchy)
            timerTimeLeft.text = _timerScript.DisplayTimeLeft(_timerScript.timeValue);
    }
}
