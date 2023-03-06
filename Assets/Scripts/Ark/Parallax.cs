//using Mingo.Base.Runtime;
using UnityEngine;

namespace Mingo.Side.Runtime
{
    public static class CameraExtensions
    {
        public static Bounds OrthographicBounds(this Camera camera)
        {
            var screenAspect = (float)Screen.width / (float)Screen.height;
            var cameraHeight = camera.orthographicSize * 2;
            var bounds = new Bounds(
              camera.transform.position,
              new Vector3(cameraHeight * screenAspect, cameraHeight, 0));
            return bounds;
        }
    }
    public class Parallax : MonoBehaviour
  {
    public Vector2 multiplier;
    public Vector2 speed;
    public bool horizontalTiling;
    public bool verticalTiling;
    
    private Transform _currentTrans;
    private Transform _cameraTransform;
    private Vector2 _startPos;
    private Vector3 _startCameraPos;
    private Vector2 _lastCameraPos;
    private Vector2 _lastNewPos;

    private GameObject[] _tilings;
    

    private void Awake()
    {
      _startPos = transform.position;
    }

    private void Start()
    {
      _currentTrans = transform;
      _currentTrans.position = _startPos;
      _cameraTransform = Camera.main.transform;
      _startCameraPos = _cameraTransform.position;
      _lastCameraPos = _cameraTransform.position;
      _lastNewPos = _currentTrans.position;
    }

    private void LateUpdate()
    {
      if (!_cameraTransform) return;
      var cam = _cameraTransform.GetComponent<Camera>();
      var camPos = (Vector2) _cameraTransform.position;
      
      // tilling
      var camBounds = cam.OrthographicBounds();
      var camSize = camBounds.size;
      var spriteRenderer = GetComponent<SpriteRenderer>();
      var sprite = spriteRenderer.sprite;
      var ppu = sprite.pixelsPerUnit;
      var spriteRect = sprite.rect;
      var spriteSize = _currentTrans.lossyScale * (spriteRect.size / ppu);
      var size = new Vector2(spriteRect.width / ppu, spriteRect.height / ppu);
      if (horizontalTiling)
      {
        var repeats = Mathf.Max(3, Mathf.Floor(camSize.x / spriteSize.x) + 1f);
        size.x = repeats * spriteRect.width / ppu;
      }
      if (verticalTiling)
      {
        var repeats = Mathf.Max(3f, Mathf.Floor(camSize.y / spriteSize.y) + 1f);
        size.y = repeats * spriteRect.height / ppu;
      }
      spriteRenderer.size = size;
      
      // calculate position
      var cameraDelta = (Vector2) camPos - _lastCameraPos;
      var newPos = (Vector2) _lastNewPos + speed * Time.deltaTime +
                   new Vector2(cameraDelta.x * multiplier.x, cameraDelta.y * multiplier.y);
      _lastNewPos = newPos;
      _lastCameraPos = camPos;
      
      // calculate parallax offset
      var distance = camPos - newPos;
      var offset = Vector2.zero;
      if (horizontalTiling)
      {
        var sign = Mathf.Sign(distance.x);
        var offsetN = sign * Mathf.Floor(Mathf.Abs(distance.x) / spriteSize.x);
        offset.x = offsetN * spriteSize.x;
      }

      if (verticalTiling)
      {
        var sign = Mathf.Sign(distance.y);
        var offsetN = sign * Mathf.Floor(Mathf.Abs(distance.y) / spriteSize.y);
        offset.y = offsetN * spriteSize.y;
      }

      var snappedNewPos = SnapToPixel(newPos + offset);
      _currentTrans.position = snappedNewPos;
      
    }
    
    public static Vector2 SnapToPixel(Vector2 value)
    {
      return new Vector2(SnapToPixel(value.x), SnapToPixel(value.y));
    }

    public static float SnapToPixel(float value)
    {
      var result = Mathf.RoundToInt(value * 8) / 8f;
      return result;
    }
  }
}