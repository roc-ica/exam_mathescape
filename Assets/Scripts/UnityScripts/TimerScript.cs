using Assets.Scripts.Applications;
using System;
using TMPro;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    [SerializeField] public GameObject Display;
    private TMP_Text _display;

    public void Start()
    {
        _display = Display.GetComponent<TMP_Text>();
    }


    public void Update()
    {
        var mainApp = MainApplication.GetInstance();

        var _session = mainApp.Session;
        var restTime = _session.EndTime - DateTime.Now;

        var text = $"{restTime.Minutes:D2}:{restTime.Seconds:D2}";
        _display.text = text;
    }
}