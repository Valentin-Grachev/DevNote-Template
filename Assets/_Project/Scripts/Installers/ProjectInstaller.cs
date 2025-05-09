using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using VG2;
using Zenject;

public class ProjectInstaller : MonoInstaller
{
    [SerializeField] private List<GameObject> _rootGameObjects;
    [SerializeField] private List<GameObject> _onlyBootstrapGameObject;


    public override async void InstallBindings()
    {
        SetActiveRootGameObjects(false);
        foreach (var gameObject in _rootGameObjects)
            gameObject.transform.SetParent(null);


        await UniTask.WaitUntil(() => Startup.Loaded);

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
