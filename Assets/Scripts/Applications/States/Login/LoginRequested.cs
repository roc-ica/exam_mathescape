using Api;
using Assets.Scripts.Applications;
using System;
using System.Linq;

namespace Applications.States.Login
{
    public class LoginRequested : IState
    {
        private readonly Configuration _configuration;
        private IState _nextState;

        public LoginRequested(string code)
        {
            var mainApp = MainApplication.GetInstance();
            _configuration = mainApp.Configuration;
            _nextState = _configuration.Offline
                ? LoginOffline(code)
                : LoginOnline(code);
        }

        public IState Update()
        {
            return _nextState;
        }

        private IState LoginOffline(string code)
        {
            if (code.ToCharArray().GroupBy(c => c).Count() == 1)
            {
                return new LoginGranted(new StartGameResponse
                {
                    Id = Guid.NewGuid(),
                    PlayerName = "Demo Player",
                    Level = (int)_configuration.DefaultLevel,
                    Seconds = _configuration.OfflineTimeInSeconds
                });
            }

            return new LoginFailed("Ongeldig code, alleen codes met 6 dezelfde cijfers zijn goed");
        }

        private IState LoginOnline(string code)
        {
            var baseUri = _configuration.BaseUri;

            var client = new GameClient(baseUri);
            try
            {
                var request = new StartGameRequest { Code = code };
                var response = client.StartGame(request)
                    .GetAwaiter()
                    .GetResult();

                return new LoginGranted(response);
            }
            catch (Exception exception)
            {
                return new LoginFailed(exception.Message);
            }

        }
    }
}