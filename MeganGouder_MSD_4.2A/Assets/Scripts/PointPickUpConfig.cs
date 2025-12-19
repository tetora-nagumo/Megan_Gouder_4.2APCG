using UnityEngine;

[CreateAssetMenu(fileName = "NewPointPickUpConfig", menuName = "ScriptableObjects/PointPickUpConfig")]
public class PointPickUpConfig : ScriptableObject
{

    public GameObject PointsPickUpPrefab;

    public float minSpawn = 2f;
    public float maxSpawn = 4f;
}
