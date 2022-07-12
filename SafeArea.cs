using UnityEngine;

namespace Mobile
{
    /// <summary>
    /// 모바일 기기에 따른 SafeArea 설정
    /// </summary>
    /// <사용법>
    /// 1. 캔버스 하단에 빈 오브젝트 생성 후 Full Stretch 설정 (ALT + 5시 방향)
    /// 2. 해당 클래스를 Add 후 FixedPosition의 크기만큼 하단에서 줄어듬
    public class SafeArea : MonoBehaviour
    {
        private RectTransform rectTransform;
        private Rect safeArea;
        private Vector2 minAnchor;
        private Vector2 maxAnchor;

        public Vector2 fixedPosition = new Vector2(0, 150f);

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            safeArea = Screen.safeArea;

            if(!EqualRectSize(rectTransform, safeArea))
            {
                //위젯이 활성화 되어있지 않을 때
                //minAnchor = safeArea.position;
                //maxAnchor = minAnchor + safeArea.size;

                //위젯이 활성화 되어 있을 때
                minAnchor = safeArea.position + fixedPosition;
                maxAnchor = safeArea.size;

                minAnchor.x /= Screen.width;
                minAnchor.y /= Screen.height;
                maxAnchor.x /= Screen.width;
                maxAnchor.y /= Screen.height;

                rectTransform.anchorMin = minAnchor;
                rectTransform.anchorMax = maxAnchor;
            }
        }

        private bool EqualRectSize(RectTransform thisRT, Rect safeArea)
        {
            return thisRT.rect.height == safeArea.height;
        }
    }
}