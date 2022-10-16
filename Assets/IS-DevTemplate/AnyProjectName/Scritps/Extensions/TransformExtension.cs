using UnityEngine;

namespace ISDevTemplate.Extensions
{
    public static class TransformExtension
    {
        private static Vector3 _vector3;

        #region SetAnchoredPosition

        public static void SetAnchoredPosition(this RectTransform rectTransform, float x, float y)
        {
            _vector3.Set(x, y, 0);
            rectTransform.anchoredPosition = _vector3;
        }

        public static void SetAnchoredPosition(this RectTransform rectTransform, float value)
        {
            _vector3.Set(value, value, 0);
            rectTransform.anchoredPosition = _vector3;
        }

        public static void SetAnchoredPositionX(this RectTransform rectTransform, float x)
        {
            _vector3.Set(x, rectTransform.anchoredPosition.y, 0);
            rectTransform.anchoredPosition = _vector3;
        }

        public static void SetAnchoredPositionY(this RectTransform rectTransform, float y)
        {
            _vector3.Set(rectTransform.anchoredPosition.x, y, 0);
            rectTransform.anchoredPosition = _vector3;
        }

        #endregion

        #region AddAnchoredPosition

        public static void AddAnchoredPosition(this RectTransform rectTransform, float x, float y)
        {
            _vector3.Set(rectTransform.anchoredPosition.x + x, rectTransform.anchoredPosition.y + y, 0);
            rectTransform.anchoredPosition = _vector3;
        }

        public static void AddAnchoredPosition(this RectTransform rectTransform, float value)
        {
            _vector3.Set(rectTransform.anchoredPosition.x + value, rectTransform.anchoredPosition.y + value, 0);
            rectTransform.anchoredPosition = _vector3;
        }

        public static void AddAnchoredPositionX(this RectTransform rectTransform, float x)
        {
            _vector3.Set(rectTransform.anchoredPosition.x + x, rectTransform.anchoredPosition.y, 0);
            rectTransform.anchoredPosition = _vector3;
        }

        public static void AddAnchoredPositionY(this RectTransform rectTransform, float y)
        {
            _vector3.Set(rectTransform.anchoredPosition.x, rectTransform.anchoredPosition.y + y, 0);
            rectTransform.anchoredPosition = _vector3;
        }

        #endregion

        #region SetPosition

        public static void SetPosition(this Transform transform, float x, float y, float z)
        {
            _vector3.Set(x, y, z);
            transform.position = _vector3;
        }

        public static void SetPosition(this Transform transform, float value)
        {
            _vector3.Set(value, value, value);
            transform.position = _vector3;
        }

        public static void SetPositionX(this Transform transform, float x)
        {
            _vector3.Set(x, transform.position.y, transform.position.z);
            transform.position = _vector3;
        }

        public static void SetPositionY(this Transform transform, float y)
        {
            _vector3.Set(transform.position.x, y, transform.position.z);
            transform.position = _vector3;
        }

        public static void SetPositionZ(this Transform transform, float z)
        {
            _vector3.Set(transform.position.x, transform.position.y, z);
            transform.position = _vector3;
        }

        #endregion

        #region AddPosition

        public static void AddPosition(this Transform transform, float x, float y, float z)
        {
            _vector3.Set(transform.position.x + x, transform.position.y + y, transform.position.z + z);
            transform.position = _vector3;
        }

        public static void AddPosition(this Transform transform, float value)
        {
            _vector3.Set(transform.position.x + value, transform.position.y + value, transform.position.z + value);
            transform.position = _vector3;
        }

        public static void AddPositionX(this Transform transform, float x)
        {
            _vector3.Set(transform.position.x + x, transform.position.y, transform.position.z);
            transform.position = _vector3;
        }

        public static void AddPositionY(this Transform transform, float y)
        {
            _vector3.Set(transform.position.x, transform.position.y + y, transform.position.z);
            transform.position = _vector3;
        }

        public static void AddPositionZ(this Transform transform, float z)
        {
            _vector3.Set(transform.position.x, transform.position.y, transform.position.z + z);
            transform.position = _vector3;
        }

        #endregion

        #region SetLocalPosition

        public static void SetLocalPosition(this Transform transform, float x, float y, float z)
        {
            _vector3.Set(x, y, z);
            transform.localPosition = _vector3;
        }

        public static void SetLocalPosition(this Transform transform, float value)
        {
            _vector3.Set(value, value, value);
            transform.localPosition = _vector3;
        }

        public static void SetLocalPositionX(this Transform transform, float x)
        {
            _vector3.Set(x, transform.localPosition.y, transform.localPosition.z);
            transform.localPosition = _vector3;
        }

        public static void SetLocalPositionY(this Transform transform, float y)
        {
            _vector3.Set(transform.localPosition.x, y, transform.localPosition.z);
            transform.localPosition = _vector3;
        }

        public static void SetLocalPositionZ(this Transform transform, float z)
        {
            _vector3.Set(transform.localPosition.x, transform.localPosition.y, z);
            transform.localPosition = _vector3;
        }

        #endregion

        #region AddLocalPosition

        public static void AddLocalPosition(this Transform transform, float x, float y, float z)
        {
            _vector3.Set(transform.localPosition.x + x, transform.localPosition.y + y, transform.localPosition.z + z);
            transform.localPosition = _vector3;
        }

        public static void AddLocalPosition(this Transform transform, float value)
        {
            _vector3.Set(transform.localPosition.x + value, transform.localPosition.y + value, transform.localPosition.z + value);
            transform.localPosition = _vector3;
        }

        public static void AddLocalPositionX(this Transform transform, float x)
        {
            _vector3.Set(transform.localPosition.x + x, transform.localPosition.y, transform.localPosition.z);
            transform.localPosition = _vector3;
        }

        public static void AddLocalPositionY(this Transform transform, float y)
        {
            _vector3.Set(transform.localPosition.x, transform.localPosition.y + y, transform.localPosition.z);
            transform.localPosition = _vector3;
        }

        public static void AddLocalPositionZ(this Transform transform, float z)
        {
            _vector3.Set(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z + z);
            transform.localPosition = _vector3;
        }

        #endregion

        #region SetLocalScale

        public static void SetLocalScale(this Transform transform, float x, float y, float z)
        {
            _vector3.Set(x, y, z);
            transform.localScale = _vector3;
        }

        public static void SetLocalScale(this Transform transform, float value)
        {
            _vector3.Set(value, value, value);
            transform.localScale = _vector3;
        }

        public static void SetLocalScaleX(this Transform transform, float x)
        {
            _vector3.Set(x, transform.localScale.y, transform.localScale.z);
            transform.localScale = _vector3;
        }

        public static void SetLocalScaleY(this Transform transform, float y)
        {
            _vector3.Set(transform.localScale.x, y, transform.localScale.z);
            transform.localScale = _vector3;
        }

        public static void SetLocalScaleZ(this Transform transform, float z)
        {
            _vector3.Set(transform.localScale.x, transform.localScale.y, z);
            transform.localScale = _vector3;
        }

        #endregion

        #region AddLocalScale

        public static void AddLocalScale(this Transform transform, float x, float y, float z)
        {
            _vector3.Set(transform.localScale.x + x, transform.localScale.y + y, transform.localScale.z + z);
            transform.localScale = _vector3;
        }

        public static void AddLocalScale(this Transform transform, float value)
        {
            _vector3.Set(transform.localScale.x + value, transform.localScale.y + value, transform.localScale.z + value);
            transform.localScale = _vector3;
        }

        public static void AddLocalScaleX(this Transform transform, float x)
        {
            _vector3.Set(transform.localScale.x + x, transform.localScale.y, transform.localScale.z);
            transform.localScale = _vector3;
        }

        public static void AddLocalScaleY(this Transform transform, float y)
        {
            _vector3.Set(transform.localScale.x, transform.localScale.y + y, transform.localScale.z);
            transform.localScale = _vector3;
        }

        public static void AddLocalScaleZ(this Transform transform, float z)
        {
            _vector3.Set(transform.localScale.x, transform.localScale.y, transform.localScale.z + z);
            transform.localScale = _vector3;
        }

        #endregion

        #region SetEulerAngles

        public static void SetEulerAngles(this Transform transform, float x, float y, float z)
        {
            _vector3.Set(x, y, z);
            transform.eulerAngles = _vector3;
        }

        public static void SetEulerAngles(this Transform transform, float value)
        {
            _vector3.Set(value, value, value);
            transform.eulerAngles = _vector3;
        }

        public static void SetEulerAnglesX(this Transform transform, float x)
        {
            _vector3.Set(x, transform.localEulerAngles.y, transform.localEulerAngles.z);
            transform.eulerAngles = _vector3;
        }

        public static void SetEulerAnglesY(this Transform transform, float y)
        {
            _vector3.Set(transform.localEulerAngles.x, y, transform.localEulerAngles.z);
            transform.eulerAngles = _vector3;
        }

        public static void SetEulerAnglesZ(this Transform transform, float z)
        {
            _vector3.Set(transform.localEulerAngles.x, transform.localEulerAngles.y, z);
            transform.eulerAngles = _vector3;
        }

        #endregion

        #region AddEulerAngles

        public static void AddEulerAngles(this Transform transform, float x, float y, float z)
        {
            _vector3.Set(transform.eulerAngles.x + x, transform.eulerAngles.y + y, transform.eulerAngles.z + z);
            transform.eulerAngles = _vector3;
        }

        public static void AddEulerAngles(this Transform transform, float value)
        {
            _vector3.Set(transform.eulerAngles.x + value, transform.eulerAngles.y + value, transform.eulerAngles.z + value);
            transform.eulerAngles = _vector3;
        }

        public static void AddEulerAnglesX(this Transform transform, float x)
        {
            _vector3.Set(transform.eulerAngles.x + x, transform.eulerAngles.y, transform.eulerAngles.z);
            transform.eulerAngles = _vector3;
        }

        public static void AddEulerAnglesY(this Transform transform, float y)
        {
            _vector3.Set(transform.eulerAngles.x, transform.eulerAngles.y + y, transform.eulerAngles.z);
            transform.eulerAngles = _vector3;
        }

        public static void AddEulerAnglesZ(this Transform transform, float z)
        {
            _vector3.Set(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + z);
            transform.eulerAngles = _vector3;
        }

        #endregion

        #region SetLocalEulerAngles

        public static void SetLocalEulerAngles(this Transform transform, float x, float y, float z)
        {
            _vector3.Set(x, y, z);
            transform.localEulerAngles = _vector3;
        }

        public static void SetLocalEulerAngles(this Transform transform, float value)
        {
            _vector3.Set(value, value, value);
            transform.localEulerAngles = _vector3;
        }

        public static void SetLocalEulerAnglesX(this Transform transform, float x)
        {
            _vector3.Set(x, transform.localEulerAngles.y, transform.localEulerAngles.z);
            transform.localEulerAngles = _vector3;
        }

        public static void SetLocalEulerAnglesY(this Transform transform, float y)
        {
            _vector3.Set(transform.localEulerAngles.x, y, transform.localEulerAngles.z);
            transform.localEulerAngles = _vector3;
        }

        public static void SetLocalEulerAnglesZ(this Transform transform, float z)
        {
            _vector3.Set(transform.localEulerAngles.x, transform.localEulerAngles.y, z);
            transform.localEulerAngles = _vector3;
        }

        #endregion

        #region AddLocalEulerAngles

        public static void AddLocalEulerAngles(this Transform transform, float x, float y, float z)
        {
            _vector3.Set(transform.localEulerAngles.x + x, transform.localEulerAngles.y + y, transform.localEulerAngles.z + z);
            transform.localEulerAngles = _vector3;
        }

        public static void AddLocalEulerAngles(this Transform transform, float value)
        {
            _vector3.Set(transform.localEulerAngles.x + value, transform.localEulerAngles.y + value, transform.localEulerAngles.z + value);
            transform.localEulerAngles = _vector3;
        }

        public static void AddLocalEulerAnglesX(this Transform transform, float x)
        {
            _vector3.Set(transform.localEulerAngles.x + x, transform.localEulerAngles.y, transform.localEulerAngles.z);
            transform.localEulerAngles = _vector3;
        }

        public static void AddLocalEulerAnglesY(this Transform transform, float y)
        {
            _vector3.Set(transform.localEulerAngles.x, transform.localEulerAngles.y + y, transform.localEulerAngles.z);
            transform.localEulerAngles = _vector3;
        }

        public static void AddLocalEulerAnglesZ(this Transform transform, float z)
        {
            _vector3.Set(transform.localEulerAngles.x, transform.localEulerAngles.y, transform.localEulerAngles.z + z);
            transform.localEulerAngles = _vector3;
        }

        #endregion

    }
}
