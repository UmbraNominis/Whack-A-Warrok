using UnityEngine;

public class FloatingText : MonoBehaviour
{
    private Camera cam;
    public float DestroyTime = 1.2f;

    private Vector3 offset = new Vector3(0, 2.2f, 0);
    private Vector3 randomizeIntensity = new Vector3(0.5f, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;

        // Destroy the Object after a given Interval
        Destroy(gameObject, DestroyTime);

        // Add and Offset
        transform.localPosition += offset;

        // Randomize where exactly the Text Appears
        transform.localPosition += new Vector3(Random.Range(-randomizeIntensity.x, randomizeIntensity.x),
            Random.Range(-randomizeIntensity.y, randomizeIntensity.y),
            Random.Range(-randomizeIntensity.z, randomizeIntensity.z));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        // Rotate the Text to the Player
        transform.LookAt(cam.transform);
        transform.rotation = Quaternion.LookRotation(cam.transform.forward);
    }
}
