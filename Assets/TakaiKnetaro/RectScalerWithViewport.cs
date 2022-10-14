using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode()]
public class RectScalerWithViewport : MonoBehaviour
{
    [Header("Canvasステータス")]
    [SerializeField, Tooltip("基準となるUIのRectTransform")] RectTransform _rectTransform = null;
    [SerializeField, Tooltip("参照する解像度")] Vector2 _refResolution = new Vector2(1920, 1080);
    [Range(0, 1)]
    [SerializeField, Tooltip("縦幅か横幅の一致")] float _matchAspect = 0;

    float Width = -1, Heigth = -1, MatchAspect = 0f;

    const float LogBase = 2;

    private void Awake()
    {
        if (_rectTransform == null) { _rectTransform = GetComponent<RectTransform>(); }
        UpdateRect();
    }

    private void Update()
    {
        UpdateRectCheck();
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        UnityEditor.EditorApplication.delayCall += OnValidateImpl;
    }
    private void OnValidateImpl()
    {
        UnityEditor.EditorApplication.delayCall -= OnValidateImpl;
        if (this is null) { return; }
        UpdateRect();
    }
#endif

    void UpdateRectCheck()
    {
        Camera cam = Camera.main;
        float width = cam.rect.width * Screen.width;
        float height = cam.rect.height * Screen.height;
        if (Width == width && Heigth == height && MatchAspect == _matchAspect) { return; }
        UpdateRect();
    }

    void UpdateRect()
    {
        if (_refResolution.x == 0f || _refResolution.y == 0f) { return; }

        Camera cam = Camera.main;
        if (cam == null) { return; }

        float width = cam.rect.width * Screen.width;
        float height = cam.rect.height * Screen.height;
        if (width == 0f || height == 0f) { return; }

        // canvas scalerから引用
        float logWidth = Mathf.Log(width / _refResolution.x, LogBase);
        float logHeight = Mathf.Log(height / _refResolution.y, LogBase);
        float logWeightedAverage = Mathf.Lerp(logWidth, logHeight, _matchAspect);
        float scale = Mathf.Pow(LogBase, logWeightedAverage);

        if (float.IsNaN(scale) || scale <= 0f) { return; }

        _rectTransform.localScale = new Vector3(scale, scale, scale);

        // スケールで縮まるので領域だけ広げる
        float revScale = 1f / scale;
        _rectTransform.sizeDelta = new Vector2(width * revScale, height * revScale);
        Width = width; Heigth = height; MatchAspect = _matchAspect;
    }
}