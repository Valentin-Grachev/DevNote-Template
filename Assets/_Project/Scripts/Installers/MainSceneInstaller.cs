using VG2;
using Zenject;

public class MainSceneInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        new SceneContainer(Container);
        var gameTime = new GameTime();

        var test = Bind(new TestController());
        
        

        
        
    }


    private T Bind<T>(T controller) where T : class
    {
        ProjectInstaller.ProjectContainer.Inject(controller);
        Container.BindInterfacesAndSelfTo<T>().FromInstance(controller).AsSingle();
        return controller;
    }

}
