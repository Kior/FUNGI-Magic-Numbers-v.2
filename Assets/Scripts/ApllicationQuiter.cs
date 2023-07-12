using UnityEngine;

namespace DefaultNamespace
{
    public static class ApllicationQuiteService
    {
        #region Public methods

        public static void Quit()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            Debug.Log("Зачем вышел? Играй давай.");
#else
            Application.Quit();
#endif
        }

        #endregion
    }
}