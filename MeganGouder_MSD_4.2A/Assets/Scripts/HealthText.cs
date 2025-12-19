using UnityEngine;
using TMPro;

public class HealthText : MonoBehaviour
{
    TMP_Text healthText;
    Player player;

    // Start is called before the first frame update
    void Start()
    {
         healthText = GetComponent<TMP_Text>();
        player = FindAnyObjectByType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
    
        healthText.text = player.GetPlayerHealth().ToString();
    }
}


