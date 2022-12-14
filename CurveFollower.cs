using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveFollower : MonoBehaviour
{
    private float speed;
    private bool _allowed=true;
    private int _routeNum;
    [SerializeField] private Transform[] _routes;
    private Vector3 _objectPosition;
    private float tparam;
    private void Start()

    {

        _routeNum = 0;

        tparam = 0f;

        speed = 0.50f;

        _allowed = true;

    }

    private void Update()
    {
        if(_allowed)
        {
            StartCoroutine(Follow(_routeNum));
        }
    }

    private IEnumerator Follow(int _routeN)
    {
        _allowed = false;

        Vector3 pos1 = _routes[_routeN].GetChild(0).position;
        Vector3 pos2 = _routes[_routeN].GetChild(1).position;
        Vector3 pos3 = _routes[_routeN].GetChild(2).position;
        Vector3 pos4 = _routes[_routeN].GetChild(3).position;

        while(tparam<1)
        {
            tparam += Time.deltaTime * speed;
            _objectPosition = Mathf.Pow((1 - tparam), 3) * pos1 +
                3 * Mathf.Pow((1 - tparam), 2) * tparam * pos2 +
                3 * Mathf.Pow(tparam, 2) * (1 - tparam) * pos3 +
                Mathf.Pow(tparam, 3) * pos4;
            transform.up = _objectPosition - transform.position;
            transform.position = _objectPosition;
            yield return Application.isBatchMode?null: new WaitForEndOfFrame();
        }
        tparam = 0;

        //speed = speed * 0.90f;
        _routeNum ++;



        if (_routeNum > _routes.Length - 1)

        {

            _routeNum = 0;

        }
        _allowed = true;
    }
}
