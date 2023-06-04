using System;
using Api;
using Applications.States.Playing;
using Assets.Scripts.Applications;
using GameComponents;
using UnityEngine.SceneManagement;

namespace Applications.States.Login
{
    public class LoginGranted: IState
    {
        private readonly Configuration _configuration;

        public LoginGranted(StartGameResponse startGameResponse)
        {
            var mainApp = MainApplication.GetInstance();
            var session = mainApp.Session;

            session.GameId = startGameResponse.Id;
            session.PlayerName = startGameResponse.PlayerName;
            session.Level = (GameLevel)startGameResponse.Level;
            
            session.Seconds = startGameResponse.Seconds;
            session.EndTime = DateTime.Now.AddSeconds(startGameResponse.Seconds);
            session.StartTime = DateTime.Now;

            _configuration = mainApp.Configuration;
        }

        public IState Update()
        {
            SceneManager.LoadScene(_configuration.GameScene);
            return new GameState();
        }
    }
}