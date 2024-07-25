using TMPro;
using UnityEngine;

namespace Scenes
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(TMP_Text))]
    public class TestValuePresenter2 : MonoBehaviour
    {
        TMP_Text _linkedTMP_Text;
        TMP_Text linkedTMP_Text => _linkedTMP_Text = _linkedTMP_Text ? _linkedTMP_Text : GetComponent<TMP_Text>();

        void OnEnable()
        {
            linkedTMP_Text.text = ScriptableObjectTest2.instance.testValue;
        }
    }
}