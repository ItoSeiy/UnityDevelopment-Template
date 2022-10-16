using UniRx;
using UnityEngine;

namespace ISDevTemplate.UI
{
    public class ButtonUnitSample : MonoBehaviour
    {
        [SerializeField]
        private NormalButton _button;

        [SerializeField]
        private LongPressButton _longPressButton;

        private void Start()
        {
            _button.OnButtonDownObservable.Subscribe(x => Debug.Log("OnButtonDown"));
            _button.OnButtonClickObservable.Subscribe(x => Debug.Log("OnButtonClick"));
            _button.OnPointerEnterAsObservable.Subscribe(x => Debug.Log("OnPointerEnter"));
            _button.OnPointerExitAsObservable.Subscribe(x => Debug.Log("OnPointerExit"));

            _longPressButton.OnButtonLongPressObservable.Subscribe(x => Debug.Log("OnButtonLongPress"));
            _longPressButton.OnButtonNormalTapObservable.Subscribe(x => Debug.Log("OnButtonNormalTap"));
            _longPressButton.OnButtonClickObservable.Subscribe(x => Debug.Log("LongButtonFinish "));
        }


#if UNITY_EDITOR
        private void OnGUI()
        {
            GUILayout.Space(30);
            if (GUILayout.Button("Enable/Disable button"))
            {
                _button.SetEnable(!_button.IsEnable);
                _longPressButton.SetEnable(!_longPressButton.IsEnable);
            }
        }
#endif
    }
}
