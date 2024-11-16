using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickToPlatform : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == ("Player"))
        {
            collision.gameObject.transform.SetParent(transform);//pakt met collision de transform van de parent player
        }
    }

    private void OnCollisionExit (Collision collision)
    {
        if (collision.gameObject.name == ("Player"))//zet het weer op null de transform van de player
        {
            collision.gameObject.transform.SetParent(null);
        }
    }


}
