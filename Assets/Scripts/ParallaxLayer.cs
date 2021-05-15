using UnityEngine;

    public class ParallaxLayer : MonoBehaviour
    {
        [SerializeField][Range(0,1)] private float _speedScale;

        public void MoveLayer(float delta)
        {
            Vector2 newTransfromPos =
                new Vector2(transform.position.x, (transform.position.y + (delta * _speedScale)));
            transform.position = newTransfromPos;
        }
    }
