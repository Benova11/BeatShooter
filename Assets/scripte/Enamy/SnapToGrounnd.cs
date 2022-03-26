
#if UNITY_EDITOR

using UnityEngine;

[ExecuteInEditMode]
public class SnapToGrounnd: MonoBehaviour
{
    [SerializeField] LayerMask LayerMask; 
    private void Update()
    {
        if (LayerMask == 0)
        {
            LayerMask = LayerMask.GetMask("Default");
        }

        transform.rotation = Quaternion.identity;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 2, LayerMask))
        {
            transform.position = new Vector3(transform.position.x, hit.point.y, transform.position.z);
        }
    }
}
#endif
