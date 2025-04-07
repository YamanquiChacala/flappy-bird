using UnityEngine;

public class Paralaje : MonoBehaviour
{
    [SerializeField] private float speed;
    private SpriteRenderer spriteRenderer;
    private float widthInUnits;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Sprite sprite = spriteRenderer.sprite;
        float widthInPixels = sprite.rect.width;
        float pixelsPerUnit = sprite.pixelsPerUnit;
        widthInUnits = widthInPixels / pixelsPerUnit;
        transform.position = Vector3.zero;

        Debug.Log("Hola");
        Debug.Log(widthInUnits);
    }

    private void Update()
    {
        transform.position += speed * Time.deltaTime * Vector3.right;
        if (transform.position.x <= -widthInUnits || transform.position.x >= widthInUnits)
        {
            transform.position = Vector3.zero;
        }
    }
}

