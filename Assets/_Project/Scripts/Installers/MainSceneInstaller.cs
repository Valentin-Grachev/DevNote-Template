using DevNote;
using Zenject;

public class MainSceneInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        new SceneInjector(Container);



    }


    private T Bind<T>(T controller) where T : class
    {
        ProjectInstaller.ProjectContainer.Inject(controller);
        Container.BindInterfacesAndSelfTo<T>().FromInstance(controller).AsSingle();
        return controller;
    }

}
