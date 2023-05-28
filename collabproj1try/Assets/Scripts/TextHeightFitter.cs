using UnityEngine;
using UnityEngine.UI;
using TMPro;

[ExecuteAlways]
[RequireComponent(typeof(TMP_Text))]
[RequireComponent(typeof(RectTransform))]
public class TextHeightFitter : MonoBehaviour
{
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private TMP_Text _text;

    private void Update()
    {
        if (!_text) _text = GetComponent<TMP_Text>();
        if (!_rectTransform) _rectTransform = GetComponent<RectTransform>();

        var desiredHeight = _text.preferredHeight;
        var size = _rectTransform.sizeDelta;
        size.y = desiredHeight;
        _rectTransform.sizeDelta = size;
    }
}