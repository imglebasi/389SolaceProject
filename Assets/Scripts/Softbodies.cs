using System.Collections;
using System.Collections.Generic;
using UnityEngine.U2D;
using UnityEngine;

public class Softbodies : MonoBehaviour
{
    private const float splineOffset = .5f;

    public SpriteShapeController spriteShape;
    public Transform[] points;
    private void Awake()
    {
        UpdateVerticies();
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
                Debug.Log("spline points too close!");
                spriteShape.spline.SetPosition(i, (_vertex - _towardsCenter * (_colliderRadius + splineOffset)));
            }

            /*//makes sure that tangents r rotated with the vertices 
            Vector2 _lt = spriteShape.spline.GetLeftTangent(i);
            Vector2 _newRt = Vector2.Perpendicular(_towardsCenter) * _lt.magnitude;
            Vector2 _newLt = Vector2.zero - (_newRt);
            spriteShape.spline.SetRightTangent(i, _newRt);
            spriteShape.spline.SetLeftTangent(i, _newLt);*/

        }
    }
}
