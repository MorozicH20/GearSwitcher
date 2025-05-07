

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

            PlayMakerFSM.BroadcastEvent("CHARM EQUIP CHECK");
            PlayMakerFSM.BroadcastEvent("CHARM INDICATOR CHECK");
            PlayMakerFSM.BroadcastEvent("UPDATE BLUE HEALTH");
        }
    }
}
