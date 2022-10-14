using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode()]
[RequireComponent(typeof(Camera))]
public class CameraStableAspect : MonoBehaviour
{
    [Header("ゲームカメラ")]
    [SerializeField, Tooltip("ゲームを表示するカメラ")] Camera _camera;

    [Header("画面設定")]
    [SerializeField, Tooltip("横幅")] int _width = 1920;
    [SerializeField, Tooltip("縦幅")] int _height = 1080;
    [SerializeField, Tooltip("単位あたりのピクセル")] float _pixelPerUnit = 100f;

    int Width = -1, Heigth = -1;

    private void Awake()
    {
        if (_camera == null) { _camera = GetComponent<Camera>(); }
        UpdateCamera();
    }

    private void Update()
    {
        UpdateCameraCheck();
    }

    private void UpdateCameraCheck()
    {
        if (Width == Screen.width && Heigth == Screen.height) { return; }
        UpdateCamera();
    }

    private void UpdateCamera()
    {
        float screenWidth = (float)Screen.width;
        float screenHeigth = (float)Screen.height;
        float targetWidth = (float)_width;
        float targetHeigth = (float)_height;

        //アスペクト比
        float aspect = screenWidth / screenHeigth;
        float targetAcpect = targetWidth / targetHeigth;
        float orthographicSize = (targetHeigth / 2f / _pixelPerUnit);

        //縦に長い
        if (aspect < targetAcpect)
        {
            float bgScale_w = targetWidth / screenWidth;
            float camHeight = targetHeigth / (screenHeigth * bgScale_w);
            _camera.rect = new Rect(0f, (1f - camHeight) * 0.5f, 1f, camHeight);
        }
        // 横に長い
        else
        {
            // カメラのorthographicSizeを横の長さに合わせて設定しなおす
            float bgScale = aspect / targetAcpect;
            orthographicSize *= bgScale;

            float bgScale_h = targetHeigth / screenHeigth;
            float camWidth = targetWidth / (screenWidth * bgScale_h);
            _camera.rect = new Rect((1f - camWidth) * 0.5f, 0f, camWidth, 1f);
        }

        _camera.orthographicSize = orthographicSize;

        Width = Screen.width;
        Heigth = Screen.height;
    }
}
