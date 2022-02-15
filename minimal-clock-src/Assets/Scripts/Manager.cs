using UnityEngine;

public class Manager : MonoBehaviour
{
    #region Inspector

    [SerializeField] private GameObject clockScreen;
    [SerializeField] private GameObject timerScreen;
    [SerializeField] private GameObject timer;
    [SerializeField] private GameObject timerIcon;
    
    #endregion

    private bool _clockActive = true;
    private bool _timerFlag;
    private TimerScript _timerScript;

    private void Start()
    {
        clockScreen.gameObject.SetActive(true);
        _timerScript = timer.GetComponent<TimerScript>();
    }

    void Update()
    {
        if (_timerScript.timerStarted)
        {
            if (_timerScript.timeValue > 0)
            {
                _timerFlag = true;
                _timerScript.timeValue -= Time.deltaTime;
            }
            else
            {
                _timerScript.StopTimer();
                GetComponent<AudioSource>().Play();
                _timerFlag = false;
                timerIcon.SetActive(false);
            }

        }
        
        
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();

        if (Input.GetKeyDown(KeyCode.T))
            switchActiveScreen();
    }


    private void switchActiveScreen()
    {
        if (_clockActive)
        {
            clockScreen.gameObject.SetActive(false);
            timerScreen.gameObject.SetActive(true);
            _clockActive = false;
            timerIcon.SetActive(false);
        }
        else
        {
            clockScreen.gameObject.SetActive(true);
            timerScreen.gameObject.SetActive(false);
            _clockActive = true;
            if (_timerFlag)
                timerIcon.SetActive(true);
        }
    }
}
