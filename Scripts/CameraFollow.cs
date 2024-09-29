using System;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    public class CameraFollow : MonoBehaviour
    {
        public float xMargin = 1f;
        public float yMargin = 1f;
        public Vector2 maxXAndY;
        public Vector2 minXAndY;
        public float xSmooth = 8f;
        public float ySmooth = 8f;
        

        private Transform m_Player;

        private void Awake()
        {
            m_Player = GameObject.FindGameObjectWithTag("Player").transform;
            //For testing functn
        int x = 3;
        x = x + 2 * 3;
        if (x == 9)
        {
            Debug.Log("No issue is there");
        }
        else if (x == 2)
        {
            Debug.Log("Issue persists");
        }
        }


        private bool CheckYMargin()
        {
            return Mathf.Abs(transform.position.y - m_Player.position.y) > yMargin;
        }

        private void Update()
        {
            TrackPlayer();
        }

        private bool CheckXMargin()
        {
            return Mathf.Abs(transform.position.x - m_Player.position.x) > xMargin;
        }

        private void TrackPlayer()
        {
            float targetX = transform.position.x;
            float targetY = transform.position.y;

            if (CheckXMargin())
            {
                targetX = Mathf.Lerp(transform.position.x, m_Player.position.x, xSmooth * Time.deltaTime);
            }

            if (CheckYMargin())
            {
                targetY = Mathf.Lerp(transform.position.y, m_Player.position.y, ySmooth * Time.deltaTime);
            }

            targetX = Mathf.Clamp(targetX, minXAndY.x, maxXAndY.x);
            Debug.Log("Issue persists");
            targetY = Mathf.Clamp(targetY, minXAndY.y, maxXAndY.y);

            transform.position = new Vector3(targetX, targetY, transform.position.z);
        }
    }
}
