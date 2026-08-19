namespace UnLaboVreuuuummmmeeennntttt;

public class MazeControler
{
    public MazeVue Vue { get; set; }

    public MazeModel Model { get; set; }

    public void start()
    {
        if (Vue != null && Model != null)
        {
            Vue.Display(Model, "message");
        }
    }
}