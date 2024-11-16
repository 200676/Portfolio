using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;// hier zet ik de positie neer waar de speler terug moet spawnen.
    private void OnTriggerEnter(Collider other)
    {
        player.transform.position = respawnPoint.transform.position;//positie van de speler is gelijk aan de spawn positie van de respawnpoint die ik heb geplaatst.

    }
}
