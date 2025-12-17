using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    int damage = 1;
    public void SetDamage(int damageAmount)
    {
        damage = damageAmount;
    }

    public int GetDamage()
    {
        return damage;
    }

    public void Hit()
    {
        Destroy(gameObject);
    }
}
