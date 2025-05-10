using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using DevNote;
using UnityEngine;
using UnityEngine.SceneManagement;
using VG2;
using Zenject;

public class ProjectInstaller : MonoInstaller
{
    public static DiContainer ProjectContainer { get; private set; }


    [SerializeField] private List<GameObject> _rootGameObjects;
    [SerializeField] private List<GameObject> _onlyBootstrapGameObject;
    [SerializeField] private ServiceSelector _serviceSelector;


    public override async void InstallBindings()
    {
        ProjectContainer = Container;

        SetActiveRootGameObjects(false);
        foreach (var gameObject in _rootGameObjects)
            gameObject.transform.SetParent(null);

        Container.Bind<ISave>().FromInstance(_serviceSelector.GetServiceInterface<ISave>()).AsSingle();

        await UniTask.WaitUntil(() => Startup.Loaded);

        Debug.Log("Binded");

        SetActiveRootGameObjects(true);
        foreach (var gameObject in _onlyBootstrapGameObject)
            gameObject.SetActive(false);
    }



    private void SetActiveRootGameObjects(bool active)
    {
        foreach (var rootObject in SceneManager.GetActiveScene().GetRootGameObjects())
            rootObject.SetActive(active);
    }



}
