using UnityEngine;

namespace SnakeSystem
{
    public struct Coordinate
    {
        int X;
        int Y;
    }

    public enum TileType { None = 0, Body, Food };

    public class StageManager : MonoBehaviour
    {
        private static readonly int STAGE_WIDTH = 10;
        private static readonly int STAGE_HEIGHT = 10;
        public TileType[,] Tiles;
        public bool IsArrived;
        public float MoveSpeed;
        public PlayerMove Player;

        private void Awake()
        {
            Tiles = new TileType[STAGE_WIDTH, STAGE_HEIGHT];
            MoveSpeed = 1.0f;
            Tiles[1, 1] = TileType.Body;
        }

        private void Update()
        {
            
        }

        private void SetPlayer()
        {
            Player.transform.position = new Vector2(1, 1);
        }
    }
}