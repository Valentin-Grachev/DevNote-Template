using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using DevNote;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class ProjectInstaller : MonoInstaller
{
    public static DiContainer ProjectContainer { get; private set; }

    [SerializeField] private bool _testVersion;
    [SerializeField] private ServiceSelector _serviceSelector;
    [SerializeField] private Sound _sound;
    [SerializeField] private List<GameObject> _onlyBootstrapGameObject;
    
    private List<DevNote.IInitializable> _initializables = new();


    public override async void InstallBindings()
    {
        ProjectContainer = Container;
        SetActiveRootGameObjects(false);

        IEnvironment.IsTest = _testVersion;

        var environment = RunServiceInitialization<IEnvironment>();

        Container.Bind<ISave>().FromInstance(RunServiceInitialization<ISave>());
        Container.Bind<IEnvironment>().FromInstance(environment);
        Container.Bind<IAds>().FromInstance(RunServiceInitialization<IAds>());
        Container.Bind<IAnalytics>().FromInstance(RunServiceInitialization<IAnalytics>());
        Container.Bind<IReview>().FromInstance(RunServiceInitialization<IReview>());

        RunUtilInitialization(_sound);

        await WaitFullInitialization();

        environment.GameReady();

        SetActiveRootGameObjects(true);
        _onlyBootstrapGameObject.ForEach(gameObject => gameObject.SetActive(false));
    }


    private UniTask WaitFullInitialization() => UniTask.WaitUntil(() =>
    {
        for (int i = 0; i < _initializables.Count; i++)
        {
            if (_initializables[i].Initialized == false)
                return false;
        }
        
        return true;
    });

    private T RunServiceInitialization<T>() where T : class
    {
        var service = _serviceSelector.GetServiceInterface<T>();
        var initializable = service as DevNote.IInitializable;
        _initializables.Add(initializable);
        initializable.Initialize();
        return service;
    }

    private void RunUtilInitialization<T>(T util) where T : DevNote.IInitializable
    {
        util.Initialize();
        _initializables.Add(util);
    }


    private void SetActiveRootGameObjects(bool active)
    {
        foreach (var rootObject in SceneManager.GetActiveScene().GetRootGameObjects())
            rootObject.SetActive(active);
    }



}
