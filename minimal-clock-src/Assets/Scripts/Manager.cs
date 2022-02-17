using UnityEngine;

public class Manager : MonoBehaviour
{
    #region Inspector

    [SerializeField] private GameObject clockScreen;
    [SerializeField] private GameObject timerScreen;
    [SerializeField] private GameObject timer;
    [SerializeField] private GameObject timerIcon;
    
    [SerializeField] private float doubleClickTime;
    #endregion

    private bool _clockActive = true;
    private bool _timerFlag;
    private bool _fullscreenFlag = true;
    private TimerScript _timerScript;
    private float _lastClickTime;

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
            }
        }

        else
            timerIcon.SetActive(false);

        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();

        if (Input.GetKeyDown(KeyCode.F4))
            switchActiveScreen();

        if (Input.GetMouseButtonDown(0))
        {
            float timeSinceClick = Time.time - _lastClickTime;
            if (timeSinceClick <= doubleClickTime)
                switchScreenMode();
            _lastClickTime = Time.time;
        }
            
        
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
    
    private void switchScreenMode()
    {
        _fullscreenFlag = !_fullscreenFlag;
        Screen.fullScreen = _fullscreenFlag;
    }
}
