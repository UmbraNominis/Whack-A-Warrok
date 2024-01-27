using UnityEngine;
using UnityEngine.UI;

public class CrossHair : MonoBehaviour
{
    public Camera cam;
    public PlayerSword playerSword;
    public Image crosshair;

    private float crosshairColorChangeDelay = 0.2f;
    private Color crosshairDefaultColor = Color.white;
    private Color crosshairEnemyColor = Color.red;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // If an Object is in the Attack Distance of the Player...
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hit, playerSword.attackDistance))
        {
            // ...And If the Object has the Health Component...
            if (hit.collider.tag != "Player" && hit.transform.TryGetComponent<Health>(out Health T))
            {
                // ...Change the Color of the Crosshair
                crosshair.CrossFadeColor(crosshairEnemyColor, crosshairColorChangeDelay, false, false);
            }
        }
        else
        {
            // ...Change the Color of the Crosshair
            crosshair.CrossFadeColor(crosshairDefaultColor, crosshairColorChangeDelay, false, false);
        }
    }
}
