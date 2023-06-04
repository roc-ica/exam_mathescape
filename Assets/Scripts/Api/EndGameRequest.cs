using System;

namespace Api
{
    public class EndGameRequest
    {
        public Guid Id { get; set; }
        public int Score { get; set; }
        public long TimeInTicks { get; set; }
    }
}