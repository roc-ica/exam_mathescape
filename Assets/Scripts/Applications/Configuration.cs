using GameComponents;

namespace Applications
{
    public class Configuration
    {
        internal Configuration()
        {
        }

        public string StartScene { get; set; }
        public string GameScene { get; set; }
        public string ScoreScene { get; set; }


        public bool Offline { get; set; }
        public int OfflineTimeInSeconds { get; set; }
        public GameLevel DefaultLevel { get; set; }

        public string BaseUri { get; set; }
    }
}