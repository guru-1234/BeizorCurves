using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Vector2 _offSet = new Vector2(10f, 10f);
    private Vector2 mousePos;
    private bool mouseReleased=false;
    private new Rigidbody2D rigidbody;
    private Vector3 grab;
    //float vx;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
     {
        if (Input.GetMouseButton(0))
        {

            mousePos = Input.mousePosition;
            Vector2 tmp = Camera.main.ScreenToWorldPoint(mousePos);
            Debug.Log(tmp);
            Vector2 gamObj = new Vector2(this.transform.position.x, this.transform.position.y);
          
                mouseReleased = false;

                Vector3 distance = tmp - gamObj;
                Vector3 distancexy = distance.normalized;
                distancexy.z = 0;
                float xValue = tmp.x - gamObj.x;
                float sy = distance.y;
                float sxz = distance.magnitude;
            float vx = Mathf.Pow(Mathf.Clamp(sxz, -tmp.x, tmp.x), 2);
                float vyx = Mathf.Clamp((vx / tmp.y), 0, tmp.y);
                Vector3 result = distancexy.normalized;
                result *= vx;
                result.y = vyx;
                rigidbody.velocity = result * Mathf.Abs(Physics2D.gravity.y);
                grab = tmp;
         }

         if(transform.position.y>= grab.y)
         {
            rigidbody.velocity = Vector3.zero;
         }

    }

    /*Vector3 CaluculateVelocity(Vector3 target, Vector3 orgin,float time)
    {
        Vector3 distance = target-orgin;
        Vector3 distancexy = distance;
        distancexy.z = 0;

        float sy = distance.y;
        float sxz = distance.magnitude;

        float vx = sxz / time;
        float vyx = sxz / time + 0.5f * Mathf.Abs(Physics2D.gravity.y) * time;

        Vector3 result = distancexy.normalized;
        result *= vx;
        result.y = vyx;
        return result;
    }

    private void OnMouseDown()
    {
        mouseReleased = false;
    }

    private void OnMouseUp()
    {
        mouseReleased = true;
    }*/
}
