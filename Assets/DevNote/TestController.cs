using DevNote;
using UnityEngine;
using Zenject;

public class TestController : IInitializable
{
    [Inject] private readonly ISave _save;


    public void Initialize()
    {
        Debug.Log(_save.GetData());
        _save.SaveLocal();
    }
}
