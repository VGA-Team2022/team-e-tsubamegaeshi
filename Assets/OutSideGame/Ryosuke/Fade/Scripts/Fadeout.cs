using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fadeout : MonoBehaviour
{
    IFade fade;
    [SerializeField] bool fadeOut;

    void Start()
    {
        Init();
        if (fadeOut)
        {
            cutoutRange = 1;
        }
        fade.Range = cutoutRange;
    }

    float cutoutRange;

    void Init()
    {
        fade = GetComponent<IFade>();
    }

    void OnValidate()
    {
        Init();
        if (fadeOut)
        {
            cutoutRange = 1;
        }
        fade.Range = cutoutRange;
    }

    IEnumerator FadeoutCoroutine(float time, System.Action action)
    {
        float endTime = Time.timeSinceLevelLoad + time * (cutoutRange);

        var endFrame = new WaitForEndOfFrame();

        while (Time.timeSinceLevelLoad <= endTime)
        {
            cutoutRange = (endTime - Time.timeSinceLevelLoad) / time;
            fade.Range = cutoutRange;
            yield return endFrame;
        }
        cutoutRange = 0;
        fade.Range = cutoutRange;

        if (action != null)
        {
            action();
        }
    }

    IEnumerator FadeinCoroutine(float time, System.Action action)
    {
        float endTime = Time.timeSinceLevelLoad + time * (1 - cutoutRange);

        var endFrame = new WaitForEndOfFrame();

        while (Time.timeSinceLevelLoad <= endTime)
        {
            cutoutRange = 1 - ((endTime - Time.timeSinceLevelLoad) / time);
            fade.Range = cutoutRange;
            yield return endFrame;
        }
        cutoutRange = 1;
        fade.Range = cutoutRange;

        if (action != null)
        {
            action();
        }
    }

    public Coroutine FadeOut(float time, System.Action action)
    {
        StopAllCoroutines();
        return StartCoroutine(FadeoutCoroutine(time, action));
    }

    public Coroutine FadeOut(float time)
    {
        return FadeOut(time, null);
    }

    public Coroutine FadeIn(float time, System.Action action)
    {
        StopAllCoroutines();
        return StartCoroutine(FadeinCoroutine(time, action));
    }

    public Coroutine FadeIn(float time)
    {
        return FadeIn(time, null);
    }
}
