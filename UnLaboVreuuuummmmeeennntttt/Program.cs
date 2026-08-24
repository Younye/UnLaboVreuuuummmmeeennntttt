namespace UnLaboVreuuuummmmeeennntttt;

internal abstract class Program
{
    private static void Main()
    {
        var factory = new MazeFactory();
        var model = factory.CreateLabyrinthe("test");

        var vue = new MazeVue();

        var ctrl = new MazeControler
        {
            Vue = vue,
            Model = model
        };

        ctrl.Start();
    }
}