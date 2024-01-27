using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image HealthBarImage;

    public Health Health;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateHealthBar()
    {
        HealthBarImage.fillAmount = Health.CurrentHealth / Health.MaxHealth;
    }
}
