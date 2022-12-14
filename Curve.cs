using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curve : MonoBehaviour
{
    [SerializeField]
    private Transform[] controlPoints;

    private Vector2 gizMos;

    private void OnDrawGizmos()
    {
        for (float i = 0; i <= 1; i += 0.05f)
        {
            gizMos = Mathf.Pow(1 - i, 3) * controlPoints[0].position +  
                3 *  Mathf.Pow((1 - i), 2)*i * controlPoints[1].position+
                 3 * (1 - i) * Mathf.Pow(i, 2) * controlPoints[2].position + 
                 Mathf.Pow(i, 3)*controlPoints[3].position;

            Gizmos.DrawSphere(gizMos, 0.25f);
        }

        Gizmos.DrawLine(controlPoints[0].position, controlPoints[1].position);
        Gizmos.DrawLine(controlPoints[2].position, controlPoints[3].position);
        Gizmos.DrawLine(controlPoints[1].position, controlPoints[2].position);
    }
}
