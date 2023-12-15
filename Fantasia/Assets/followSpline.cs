using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;

public class FollowSpline : MonoBehaviour
{
    private SplineFollower _follower;

    void Start()
    {
        _follower = GetComponent<SplineFollower>();
        _follower.onNode += OnNodePassed;
    }

    private void OnNodePassed(List<SplineTracer.NodeConnection> passed)
    {
        SplineTracer.NodeConnection nodeConnection = passed[0];
        Debug.Log(nodeConnection.node.name + " at point " + nodeConnection.point);
        double nodePercent = (double)nodeConnection.point / (_follower.spline.pointCount - 1);
        double followerPercent = _follower.UnclipPercent(_follower.result.percent);
        float distancePastNode = _follower.spline.CalculateLength(nodePercent, followerPercent);
        Debug.Log(nodePercent);

        Node.Connection[] connections = nodeConnection.node.GetConnections();

        if (connections.Length > 0)
        {
            int rnd = Random.Range(0, connections.Length);
            _follower.spline = connections[rnd].spline;
            double newNodePercent = (double)connections[rnd].pointIndex / (connections[rnd].spline.pointCount - 1);
            double newPercent = connections[rnd].spline.Travel(newNodePercent, distancePastNode, _follower.direction);
            _follower.SetPercent(newPercent);
        }
        else
        {
            // No connections, maybe the end of the path, handle accordingly
            Debug.LogWarning("No connections found at the end of the spline.");
        }
    }
}