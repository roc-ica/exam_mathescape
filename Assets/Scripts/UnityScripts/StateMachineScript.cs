using System;
using Applications.States.Login;
using Assets.Scripts.Applications;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityScripts
{
    public class StateMachineScript : MonoBehaviour
    {
        private readonly MainApplication _mainApp;
        public StateMachineScript()
        {
            _mainApp = MainApplication.GetInstance();
        }


        public void Update()
        {
            try
            {
                var state = _mainApp.CurrentState;

                if (state is null)
                {
                    _mainApp.ChangeState(new LoginInit());
                    SceneManager.LoadScene(0);
                    return;
                }
            
                state = state.Update();
                _mainApp.ChangeState(state);
            }
            catch (Exception exception)
            {
                Debug.LogError(exception);
                throw;
            }
        }
    }
}
