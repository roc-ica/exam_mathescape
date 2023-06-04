using Applications;
using Applications.States;
using Applications.States.Login;
using UnityEngine.UI;

namespace Assets.Scripts.Applications
{
    public class MainApplication
    {
        private static MainApplication _instance;

        public static MainApplication GetInstance()
        {
            if (_instance != null) return _instance;

            _instance = new();
            return _instance;
        }


        private MainApplication()
        {
            Session = new Session();
            Configuration = new Configuration();
            CurrentState = null;
        }

        public Session Session { get; }

        public Configuration Configuration { get; }

        public IState CurrentState { get; private set; }

        public void ChangeState(IState state)
        {
            CurrentState = state;
        }
    }
}
