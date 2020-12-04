using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Habrador_Computational_Geometry;

//Attach this to go with mesh and it should display its bounding box
public class DisplayBoundingBox : MonoBehaviour
{

    void OnDrawGizmosSelected()
	{
        //MeshFilter meshFilter = GetComponent<MeshFilter>();

        //if (meshFilter == null)
        //{
        //    Debug.Log("You need a mesh filter");

        //    return;
        //}

        //Mesh mesh = meshFilter.sharedMesh;

        //if (mesh == null)
        //{
        //    Debug.Log("You need a mesh");

        //    return;
        //}

        //Bounds are AABB in local space
        //Bounds bounds = mesh.bounds;

        //Renderer.bounds are in world space
        MeshRenderer mr = GetComponent<MeshRenderer>();

        if (mr == null)
        {
            Debug.Log("You need a mesh renderer");

            return;
        }

        DisplayMeshBoundingBox(mr);
    }



    private void DisplayMeshBoundingBox(MeshRenderer mr)
    {
        Bounds bounds = mr.bounds;

        //Vector3 halfSize = bounds.extents;

        //Vector3 top = bounds.center + Vector3.up * halfSize.y;
        //Vector3 bottom = bounds.center - Vector3.up * halfSize.y;


        //Vector3 topFR = top + Vector3.forward * halfSize.z + Vector3.right * halfSize.x;
        //Vector3 topFL = top + Vector3.forward * halfSize.z + Vector3.left * halfSize.x;
        //Vector3 topBR = top - Vector3.forward * halfSize.z + Vector3.right * halfSize.x;
        //Vector3 topBL = top - Vector3.forward * halfSize.z + Vector3.left * halfSize.x;

        //Vector3 bottomFR = bottom + Vector3.forward * halfSize.z + Vector3.right * halfSize.x;
        //Vector3 bottomFL = bottom + Vector3.forward * halfSize.z + Vector3.left * halfSize.x;
        //Vector3 bottomBR = bottom - Vector3.forward * halfSize.z + Vector3.right * halfSize.x;
        //Vector3 bottomBL = bottom - Vector3.forward * halfSize.z + Vector3.left * halfSize.x;

        AABB3 aabb = new AABB3(bounds);


        Gizmos.color = Color.black;

        List<Edge3> edges = aabb.GetEdges();

        foreach (Edge3 e in edges)
        {
            Gizmos.DrawLine(e.p1.ToVector3(), e.p2.ToVector3());
        }
    }
}
