using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SacrificeScript : MonoBehaviour
{
    [SerializeField] private Transform ground;
    [SerializeField] private int despawnHeight;
    private int defaultDespawnHeight = -20;

    // Start is called before the first frame update
    void Start()
    {
        if (despawnHeight >= 0)
        {
            despawnHeight = defaultDespawnHeight;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < despawnHeight)
        {
            DespawnSacrifice();
        }

    }

    private void DespawnSacrifice()
    {
        Destroy(gameObject);
        ground.GetComponent<UnityEngine.XR.Interaction.Toolkit.Locomotion.Teleportation.TeleportationArea>().enabled = true;
    }
}
