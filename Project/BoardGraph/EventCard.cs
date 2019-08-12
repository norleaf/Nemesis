namespace BoardGraph
{
    public abstract class EventCard
    {
        public string name;
        public string description;
        public string[] types;

        protected EventCard(string name, string description, params string[] types)
        {
            this.name = name;
            this.description = description;
            this.types = types;
        }

        public abstract void MoveEnemies(Board board);
        
        public abstract void ResolveEvent(Board board);

    
    }
}