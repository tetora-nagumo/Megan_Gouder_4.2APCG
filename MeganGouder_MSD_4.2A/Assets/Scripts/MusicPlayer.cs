using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        SetUpSingleton();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

 private void SetUpSingleton()
    {
        if(FindObjectsByType(GetType(),FindObjectsSortMode.None).Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

}

