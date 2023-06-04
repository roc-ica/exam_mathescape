using Applications.States.Login;
using Assets.Scripts.Applications;
using UnityEngine;

namespace Assets.Scripts.UnityScripts
{
    internal class GameConfigurationScript : MonoBehaviour
    {
        [SerializeField] public string StartScene;
        [SerializeField] public string GameScene;
        [SerializeField] public string ScoreScene;

        [SerializeField] public bool Offline;
        [SerializeField] public int OfflineTimeInSeconds = 300;
        [SerializeField] public string BaseUri;

        private readonly MainApplication _mainApp;

        public GameConfigurationScript()
        {
            _mainApp = MainApplication.GetInstance();

        }

        public void Start()
        {
            _mainApp.ChangeState(new LoginInit());
        }

        public void Update()
        {
            var configuration = _mainApp.Configuration;
            configuration.StartScene = StartScene;
            configuration.GameScene = GameScene;
            configuration.ScoreScene = ScoreScene;
            configuration.Offline = Offline;
            configuration.OfflineTimeInSeconds = OfflineTimeInSeconds;
        }
    }
}