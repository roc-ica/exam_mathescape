using GameComponents;
using System;

namespace Applications
{
    public class Session
    {
        internal Session()
        { }

        public Guid GameId { get; set; }
        public string PlayerName { get; set; }
        public GameLevel Level { get; set; }
        public int Seconds { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime? CompleteTime { get; set; }

        public bool IsCompleted => CompleteTime != null;

        public void Clear()
        {
            GameId = Guid.Empty;
            PlayerName = string.Empty;
            Level = GameLevel.Easy;
            Seconds = 0;

            StartTime = DateTime.Now;
            EndTime = DateTime.Now;
            CompleteTime = null;
        }
    }
}