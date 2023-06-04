using System;

namespace Api
{
    public class StartGameResponse
    {
        public Guid Id { get; set; }
        public string PlayerName { get; set; }
        public int Seconds { get; set; }
        public int Level { get; set; }
        public int Language { get; set; }
    }
}