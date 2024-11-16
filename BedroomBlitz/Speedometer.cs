using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speedometer : MonoBehaviour
{
    [SerializeField] private Rigidbody Target;
    [SerializeField] private float maxSpeed = 0.0f;
    [SerializeField] private float minSpeedArrow;
    [SerializeField] private float maxSpeedArrow;

    [Header ("UI")]
    [SerializeField] private Text speedText;
    public RectTransform arrow;
    private float speed = 0.0f;

    private void Update()
    {
        speed = Target.velocity.magnitude * 3.6f;

        if (speedText != null)
        {
            speedText.text = ((int)(speed) + "");
        }
        if (arrow != null)
        {
            arrow.localEulerAngles =
                new Vector3(0, 0, Mathf.Lerp(minSpeedArrow, maxSpeedArrow, speed / maxSpeed));
        }

    }


}
