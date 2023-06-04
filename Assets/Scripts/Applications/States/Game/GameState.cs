using Api;
using Applications.States.EndScore;
using Assets.Scripts.Applications;
using System;
using UnityEngine.SceneManagement;

namespace Applications.States.Playing
{
    public class GameState : IState
    {
        private readonly Configuration _configuration;
        private readonly Session _session;

        public GameState()
        {
            var mainApp = MainApplication.GetInstance();
            _session = mainApp.Session;
            _configuration = mainApp.Configuration;
        }

        public IState Update()
        {
            if (_session.CompleteTime != null || _session.EndTime <= DateTime.Now)
            {
                return FinishGame();
            }

            return this;
        }


        private IState FinishGame()
        {
            var baseUri = _configuration.BaseUri;
            var score = new EndGameRequest
            {
                Id = _session.GameId,
                TimeInTicks = ((_session.CompleteTime ?? _session.EndTime) - _session.StartTime).Ticks,
            };

            var gameClient = new GameClient(baseUri);
            try
            {
                if (!_configuration.Offline)
                {
                    gameClient.EndGame(score)
                        .GetAwaiter()
                        .GetResult();
                }

                SceneManager.LoadScene(_configuration.ScoreScene);
                return new ScoreState();
            }
            catch (Exception exception)
            {
                return new ScoreState(exception.Message);
            }
        }


    }
}