using System;
using TMPro;
using UnityEngine;

public class ClockScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI time;
    [SerializeField] private TextMeshProUGUI date;
    
    private void Start()
    {
        date.text = DateTime.Now.ToString("dd    MM    yy");
    }

    void Update()
    {
        time.text = DateTime.Now.ToString("HH   mm");
    }
    
}
