using UnityEngine;
using System.Collections;

public static class CursorCaster {
    public class CursorCastHit
    {
        public GameObject target = null;
        public Vector3 worldPosition = new Vector3();

        public CursorCastHit(GameObject go, Vector3 pos)
        {
            target = go;
            worldPosition = pos;
        }
    }

    public static CursorCastHit CastCursor()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (!Physics.Raycast(ray, out hit))
            return null;

        return new CursorCastHit(hit.collider.gameObject, hit.point);
    }
}
