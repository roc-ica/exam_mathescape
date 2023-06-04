namespace Applications.States.EndScore
{
    public class ScoreState : IState
    {
        public ScoreState()
        {
            ErrorMessage = string.Empty;
        }

        public ScoreState(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public string ErrorMessage { get; }


        public IState Update()
        {
            return this;
        }
    }
}
