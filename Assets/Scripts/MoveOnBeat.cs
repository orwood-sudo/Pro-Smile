using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class MoveOnBeat : MonoBehaviour
{
    public Sprite normalImage;
    public Sprite squishImage;

    private SpriteRenderer sr;
    private bool isNormal = true;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = normalImage;
    }

    void OnEnable()
    {
        BeatManager.OnBeat += HandleBeat;
    }

    void OnDisable()
    {
        BeatManager.OnBeat -= HandleBeat;
    }

    void HandleBeat(int beatIndex)
    {
        ChangeSprite();
    }

    void ChangeSprite()
    {
        sr.sprite = isNormal ? squishImage : normalImage;
        isNormal = !isNormal;
    }
}
