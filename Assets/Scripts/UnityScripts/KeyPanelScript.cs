using Applications.States.Login;
using Assets.Scripts.Applications;
using TMPro;
using UnityEngine;

namespace UnityScripts
{
    public class KeyPanelScript : MonoBehaviour
    {
        [SerializeField] public GameObject CodeDisplay;
        [SerializeField] public GameObject ErrorDisplay;
        private TMP_Text _codeDisplay;
        private TMP_Text _errorDisplay;
        private MainApplication _mainApp;

        public void Start()
        {
            _codeDisplay = CodeDisplay.GetComponent<TMP_Text>();
            _codeDisplay.text = string.Empty;
            _errorDisplay = ErrorDisplay.GetComponent<TMP_Text>();
            _codeDisplay.text = string.Empty;
            _mainApp = MainApplication.GetInstance();
        }

        public void Update()
        {
            if (_mainApp.CurrentState is LoginFailed loginResult)
            {
                _errorDisplay.text = loginResult.Message;
            }
            else
            {
                _errorDisplay.text = string.Empty;
            }
        }

        public void PressNumber(int key)
        {
            if (_mainApp.CurrentState is LoginFailed)
                _mainApp.ChangeState(new LoginInit());

            if (_codeDisplay.text.Length <= 6)
            {
                _codeDisplay.text += key;
            }
        }

        public void PressBack()
        {
            if (_mainApp.CurrentState is LoginFailed)
                _mainApp.ChangeState(new LoginInit());

            if (_codeDisplay.text.Length > 0)
            {
                _codeDisplay.text = _codeDisplay.text[..^1];
            }
        }

        public void PressStart()
        {
            var code = new LoginRequested(_codeDisplay.text);
            _mainApp.ChangeState(code);
        }
    }
}