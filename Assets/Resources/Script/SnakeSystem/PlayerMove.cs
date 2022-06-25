using System.Collections;
using UnityEngine;

namespace SnakeSystem
{
    public enum DirectionType { Up = 0, Right, Down, Left, Count };
    public class PlayerMove : MonoBehaviour
    {
        private static readonly Vector2[] DIRECTION_VECTOR = new Vector2[] { Vector2.up, Vector2.right, Vector2.down, Vector2.left };
        private DirectionType direction;
        private Coordinate coordinateTarget;
        private Coordinate coordinateCurrent;
        private Vector2 vectorTarget;

        public bool IsArrived;

        private void Awake()
        {
            direction = DirectionType.Up;
            IsArrived = true;
            coordinateCurrent = new Coordinate();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                direction += 1;
                if (direction >= DirectionType.Count)
                    direction -= DirectionType.Count;
            }
            if (IsArrived) StartCoroutine(MoveCoroution());
        }

        IEnumerator MoveCoroution()
        {
            IsArrived = false;
            vectorTarget = DIRECTION_VECTOR[(int)direction];
            while (Vector2.Distance(transform.position, vectorTarget) > 0.1f)
            {
                transform.position = Vector2.Lerp(transform.position, vectorTarget, Time.deltaTime);
                yield return null;
            }
            IsArrived = true;
        }
    }
}