using Assets.Scripts.Applications;

namespace Applications.States.Login
{
    public class LoginInit: IState
    {
        public LoginInit()
        {
            var mainApp = MainApplication.GetInstance();
            var session = mainApp.Session;
            session.Clear();
        }

        public IState Update()
        {
            return this;
        }
    }
}