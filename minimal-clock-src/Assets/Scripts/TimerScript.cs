using TMPro;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    [SerializeField] private GameObject setScreen;
    [SerializeField] private GameObject viewScreen;
    [SerializeField] private GameObject dropdown;
    [SerializeField] private TextMeshProUGUI TimertimeLeft;
    
    [HideInInspector] public bool timerStarted;
    [HideInInspector] public float timeValue;

    private void OnEnable()
    {
        setActiveScreen();
    }

    private void Update()
    {
        if (!timerStarted)
            return;
        
        DisplayTimeLeft(timeValue);
    }

    private void DisplayTimeLeft(float timeLeft)
    {
        if (timeLeft < 0)
            timeLeft = 0;
        
        float minutes = Mathf.FloorToInt(timeLeft / 60);
        float seconds = Mathf.FloorToInt(timeLeft % 60);

        TimertimeLeft.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    
    private void setActiveScreen()
    {
        if (timerStarted)
        {
            setScreen.SetActive(false);
            viewScreen.SetActive(true);
        }
        else
        {
            setScreen.SetActive(true);
            viewScreen.SetActive(false);
        }
    }

    public void StartTimer()
    {

        int menuIndex = dropdown.GetComponent<TMP_Dropdown>().value;
        switch (menuIndex)
        {
            case 0:
                timeValue = 15 * 60;
                break;
            
            case 1:
                timeValue = 30 * 60;
                break;
            
            case 2:
                timeValue = 45 * 60;
                break;
            
            case 3:
                timeValue = 60 * 60;
                break;
        }

        timerStarted = true;
        setActiveScreen();
    }

    public void StopTimer()
    {
        timeValue = 0;
        timerStarted = false;
        setActiveScreen();
    }
    
}
