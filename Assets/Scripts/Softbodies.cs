using System.Collections;
using System.Collections.Generic;
using UnityEngine.U2D;
using UnityEngine;

public class Softbodies : MonoBehaviour
{
    private const float splineOffset = .5f;

    public SpriteShapeController spriteShape;
    public Transform[] points;
    public List<Vector3> pointStartPos;
    //List<Questions> _questions = new List<Questions>()
    private void Awake()
    {
        UpdateVerticies();

        foreach(Transform point in points)
        {
            pointStartPos.Add(point.transform.position);
        }
    }
    private void Update()
    {
        UpdateVerticies();
    }
    private void UpdateVerticies()
    {
        for (int i = 0; i<points.Length - 1; i++)
        {
            Vector2 _vertex = points[1].localPosition;
            Vector2 _towardsCenter = (Vector2.zero - _vertex).normalized;
            float _colliderRadius = points[i].gameObject.GetComponent<CircleCollider2D>().radius;
            try
            {
                spriteShape.spline.SetPosition(i, (_vertex - _towardsCenter * _colliderRadius));
            }
            catch
            {
                //Debug.Log("spline points too close!");
                spriteShape.spline.SetPosition(i, (_vertex - _towardsCenter * (_colliderRadius + splineOffset)));
                //StartCoroutine(ResetPoints());
 
            }

            /*//makes sure that tangents r rotated with the vertices 
            Vector2 _lt = spriteShape.spline.GetLeftTangent(i);
            Vector2 _newRt = Vector2.Perpendicular(_towardsCenter) * _lt.magnitude;
            Vector2 _newLt = Vector2.zero - (_newRt);
            spriteShape.spline.SetRightTangent(i, _newRt);
            spriteShape.spline.SetLeftTangent(i, _newLt);*/

        }
    }
    public IEnumerator ResetPoints()
    {
        yield return new WaitForSeconds(3f);
        Debug.Log("resetting pts");
        //reset points to original
        //idk how it do it any other way
        points[0].position = pointStartPos[0];
        points[1].position = pointStartPos[1];
        points[2].position = pointStartPos[2];
        points[3].position = pointStartPos[3];
        points[4].position = pointStartPos[4];
        points[5].position = pointStartPos[5];
    }
}
