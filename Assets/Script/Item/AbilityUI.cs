using UnityEngine;

public class AbilityUI : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    [SerializeField] private Sprite spriteAdd;

    void Start()
    {
        GameObject abilitySelectImage = new GameObject("SpriteObject");
        abilitySelectImage.transform.parent = canvas.transform;
        abilitySelectImage.transform.localPosition = Vector3.zero;

        SpriteRenderer spriteRenderer = abilitySelectImage.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = spriteAdd;
    }
}
