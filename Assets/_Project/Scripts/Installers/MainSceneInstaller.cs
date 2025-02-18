using VG2;
using Zenject;

public class MainSceneInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        new SceneContainer(Container);
        var gameTime = new GameTime();

        
    }


}
