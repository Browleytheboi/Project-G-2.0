using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damage : MonoBehaviour
{
    public enum damageType { melee, stationary, bullet }
    // [SerializeField] damageType type;
    [SerializeField] Rigidbody rb;

    [Header("-----DamageTypes-----")]
    [SerializeField][Range(0, 100)] int meleeDamageAmount;
    [SerializeField][Range(0, 50)] int meleeSpeed;

    [Header("-----Timers-----")]
    [SerializeField] float destroyTime;

    [Header("-----Visuals-----")]
    [SerializeField] Renderer model; //Allows the identification of the specific renderer model
    Color colorOrig;

    private static damageType type;
    // Start is called before the first frame update
    void Start()
    {
        colorOrig = model.material.color;


    }

    // Update is called once per frame
    void Update()
    {
        if (type == damageType.melee)
        {
            rb.velocity = transform.forward * meleeSpeed;
            Physics.IgnoreLayerCollision(gameObject.layer, LayerMask.NameToLayer("Enemy"));

            Destroy(gameObject, destroyTime);
        }
    }


    public void SetDamageType(damageType newType)
    {
        type = newType;
    }

    public damageType GetDamageType()
    {
        return type;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.isTrigger)
            return;

        IDamage dmg = other.GetComponent<IDamage>();

        if (dmg != null)
        {
            if (type == damageType.melee)
            {
                dmg.TakeDamage(meleeDamageAmount);
            }

        }
        if (type == damageType.melee)
        {
            Destroy(gameObject);
        }
    }
}
