
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RaycastGroundCheck : GroundCheckBase
{

    [SerializeField] private List<RaycastRay> rays = new List<RaycastRay>();
    [SerializeField] private LayerMask groundLayers;
    
    public override bool isGrounded()
    {
        var pos = transform.position;
        return rays.Any(ray => ray.Check(pos, groundLayers));
    }

    private void OnDrawGizmos()
    {
        var pos = transform.position;
        foreach(var ray in rays)
        {
            ray.Debug(pos, groundLayers, Color.green, Color.red);
        }
    }
}

