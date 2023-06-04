namespace Applications.States.Login
{
    public class LoginFailed: IState
    {
        private readonly Session _session;

        public LoginFailed(string message)
        {
            Message = message;
        }
        
        public string Message { get; }

        public IState Update()
        {
            return this;
        }
    }
}