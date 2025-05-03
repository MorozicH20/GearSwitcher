

namespace GearSwitcher
{
    static class UIUpdate
    {
        public static void Update()
        {
            if (!GameCameras.instance.hudCanvas.gameObject.activeInHierarchy)
                GameCameras.instance.hudCanvas.gameObject.SetActive(true);
            else
            {
                GameCameras.instance.hudCanvas.gameObject.SetActive(false);
                GameCameras.instance.hudCanvas.gameObject.SetActive(true);
            }
        }
    }
}
