namespace BoardGraph
{
    public interface Actionable
    {
        bool IsActionable(Board board, out Option[] options);
    }
}
