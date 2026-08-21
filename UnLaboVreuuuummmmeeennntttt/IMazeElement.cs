namespace UnLaboVreuuuummmmeeennntttt
{
    public interface IMazeElement : ISymbol, IVisitablePersonage
    {
        IMazeObject Content { get; set; }
    }
}
