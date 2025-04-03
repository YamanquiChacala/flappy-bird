using UnityEngine;

public class Pipes : MonoBehaviour
{

    [SerializeField] private Transform topPipe;
    [SerializeField] private Transform buttonPipe;
    [SerializeField] private float spacing;
    [SerializeField] private float speed;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        topPipe.localPosition = Vector3.up * spacing / 2;
        buttonPipe.localPosition = Vector3.down * spacing / 2;
    }

    // Update is called once per frame
    private void Update()
    {
        transform.localPosition += speed * Time.deltaTime * Vector3.left;
        if (transform.position.x < -10)
        {
            Destroy(gameObject);
        }
    }
}
