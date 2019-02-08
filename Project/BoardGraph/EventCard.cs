namespace BoardGraph
{
    public abstract class EventCard
    {
        public string name;
        public string description;
        public string[] types;



        public void MoveEnemies(Board board)
        {

        }

        public abstract void ResolveEvent(Board board);
    }
}