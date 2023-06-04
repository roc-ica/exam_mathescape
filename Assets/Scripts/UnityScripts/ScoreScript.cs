using Applications;
using Applications.States.EndScore;
using Applications.States.Login;
using Assets.Scripts.Applications;
using System;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityScripts
{
    public class ScoreScript : MonoBehaviour
    {
        private readonly MainApplication _mainApp;

        [SerializeField] public GameObject Display;
        private TMP_Text _display;

        public ScoreScript()
        {
            _mainApp = MainApplication.GetInstance();
        }

        public void Start()
        {
            _display = Display.GetComponent<TMP_Text>();
            _display.text = string.Empty;

            if (_mainApp.CurrentState is not ScoreState state)
                return;

            var session = _mainApp.Session;
            if (string.IsNullOrEmpty(state.ErrorMessage))
            {
                ShowScore(session);
            }
            else
            {
                ShowError(state.ErrorMessage);
            }
        }

        private void ShowError(string error)
        {
            _display.color = Color.red;
            _display.text = error;
        }

        private void ShowScore(Session session)
        {
            var time = " - ";
            var geslaagd = "niet ";

            if (session.CompleteTime.HasValue)
            {
                var duration = (session.CompleteTime.Value - session.StartTime).Ticks;
                var timespan = new TimeSpan(duration);
                time = timespan.ToString(@"mm\:ss");
                geslaagd = string.Empty;
            }

            var text = new StringBuilder()
                .AppendLine($"{session.PlayerName}, het is {geslaagd}gelukt\n")
                .AppendLine($"Tijd: {time}")
                .ToString();


            _display.color = Color.black;
            _display.text = text;
        }

        public void PressRestartGame()
        {
            var configuration = _mainApp.Configuration;
            SceneManager.LoadScene(configuration.StartScene);
            _mainApp.ChangeState(new LoginInit());
        }
    }
}
