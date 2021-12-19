namespace DaniPSXFlares.flareSettings
{
   [System.Serializable]
   public class FadeSettings : DefaultSettings
   {
      public float fadeInTime;
      public float fadeOutTime;

      public override void SetDefaultValues()
      {
         if (isInitialized == false)
         {
            fadeInTime = 0.1f;
            fadeOutTime = 0.1f;
         }
         isInitialized = true;
      }
   }
}