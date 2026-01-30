using UnityEngine;
using System;

public class BeatManager : MonoBehaviour
{
    public static BeatManager Instance;
    public static event Action<int> OnBeat; // beat index

    public float bpm = 120f;
    public AudioSource audioSource;
    public float anticipationOffset = 0.1f;

    private float beatInterval;
    private double nextBeatTime;
    private int beatCount;

    void Awake()
    {
        // Singleton pattern
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        beatInterval = 60f / bpm;
        nextBeatTime = AudioSettings.dspTime;
        audioSource.Play();
    }

    void Update()
    {
        if (AudioSettings.dspTime >= (nextBeatTime - anticipationOffset))
        {
            TriggerBeat();
            beatCount++;
            nextBeatTime += beatInterval;
        }
    }

    void TriggerBeat()
    {
        Debug.Log($"Beat! {beatCount}");
        OnBeat?.Invoke(beatCount);
    }
}