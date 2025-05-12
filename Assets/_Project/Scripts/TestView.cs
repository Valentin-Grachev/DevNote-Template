using DevNote;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class TestView : MonoBehaviour
{
    [SerializeField] private Button _button;

    private ISave save;


    
    [Inject] private void Construct(ISave save)
    {
        this.save = save;
    }
    


    private void Start()
    {
        _button.onClick.AddListener(OnButtonClick);
        _button.image.color = GameState.adsEnabled.Value ? Color.green : Color.red;
    }

    private void OnButtonClick()
    {
        GameState.adsEnabled.Value = !GameState.adsEnabled.Value;
        _button.image.color = GameState.adsEnabled.Value ? Color.green : Color.red;
    }


}
