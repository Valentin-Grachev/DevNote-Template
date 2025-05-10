using DevNote;
using UnityEngine;
using UnityEngine.UI;
using VG2;
using Zenject;

public class TestView : MonoBehaviour
{
    [SerializeField] private Button _button;

    [Inject] private readonly ISave save;

    private void Start()
    {
        _button.onClick.AddListener(OnButtonClick);
        _button.image.color = GameState.adsEnabled.Value ? Color.green : Color.red;
    }

    private void OnButtonClick()
    {
        GameState.adsEnabled.Value = !GameState.adsEnabled.Value;
        _button.image.color = GameState.adsEnabled.Value ? Color.green : Color.red;

        Debug.Log(save.GetData());
    }


}
