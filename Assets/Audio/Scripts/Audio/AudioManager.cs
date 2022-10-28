using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CriWare;

/// <summary>
/// 音声の管理者
/// </summary>
public class AudioManager : MonoBehaviour
{
    /// <summary>
    /// インスタンス
    /// </summary>
    static AudioManager s_instance = null;

    /// <summary>
    /// インスタンス
    /// </summary>
    public static AudioManager Instance
    {
        get
        {
            if (s_instance == null)
            {
                // Resourcesからインスタンス化して取得する
                AudioManager prefab = Resources.Load<AudioManager>("Audio/AudioManager");
                s_instance = Instantiate(prefab);
                DontDestroyOnLoad(s_instance);
            }

            return s_instance;
        }
    }

    /// <summary>
    /// BGM
    /// </summary>
    [SerializeField]
    CriAtomSource _bgmSource = null;

    /// <summary>
    /// SE
    /// </summary>
    [SerializeField]
    CriAtomSource _seSource = null;

    /// <summary>
    /// ループするSE
    /// </summary>
    [SerializeField]
    CriAtomSource _loopSESource = null;

    /// <summary>
    /// 再生するBGMの名前
    /// </summary>
    public string PlayingBgmName { get; private set; } = string.Empty;

    /// <summary>
    /// BGMを再生する
    /// </summary>
    /// <param name="cueName">キュー</param>
    /// <param name="volume">音量</param>
    /// <param name="continueSameBgm">既に同じBGMを再生している場合、BGMを継続する</param>
    public void PlayBgm(string cueName, float volume = 1.0f, bool continueSameBgm = true)
    {
        // 音量を設定する
        _bgmSource.volume = volume;

        // 同じBGMを継続する場合は処理を終了する
        if (continueSameBgm
            && _bgmSource.cueName == cueName)
        {
            return;
        }

        // 既に再生中ならBGMを停止する
        if (_bgmSource.status == CriAtomSourceBase.Status.Playing)
        {
            StopBgm();
        }

        // BGMを再生する
        _bgmSource.Play(cueName);

        // 名前を記憶する
        PlayingBgmName = _bgmSource.cueName;
    }

    /// <summary>
    /// BGMを停止する
    /// </summary>
    public void StopBgm()
    {
        // BGMを停止する
        _bgmSource.Stop();

        // 名前を忘れる
        PlayingBgmName = string.Empty;
    }

    /// <summary>
    /// SEを再生する
    /// </summary>
    /// <param name="cueName">キュー</param>
    /// <param name="volume">音量</param>
    public void PlaySE(string cueName, float volume = 1.0f)
    {
        _seSource.volume = volume;
        _seSource.Play(cueName);
    }

    /// <summary>
    /// SEを停止する
    /// </summary>
    public void StopSE()
    {
        _seSource.Stop();
    }

    /// <summary>
    /// ループSEを停止する
    /// </summary>
    /// <param name="cueName">キュー名</param>
    /// <param name="volume">音量</param>
    public void PlayLoopSE(string cueName, float volume = 1.0f)
    {
        _loopSESource.volume = volume;
        _loopSESource. Play(cueName);
    }

    /// <summary>
    /// ループSEを停止する
    /// </summary>
    public void StopLoopSE()
    {
        _loopSESource.Stop();
    }
}
