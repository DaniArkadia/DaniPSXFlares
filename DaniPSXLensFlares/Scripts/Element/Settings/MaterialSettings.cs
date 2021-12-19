using UnityEngine;

namespace DaniPSXFlares.flareSettings
{
   [System.Serializable]
   public class MaterialSettings : DefaultSettings
   {
      [Tooltip("Use this to set the color of the element when visible")]
      public Color color = Color.white;
      public bool isEmissive;
      public Color emissionColor = new Color(1, 1, 1, 1);

      public override void SetDefaultValues()
      {
         if (isInitialized == false)
         {
            color = Color.white;
            emissionColor = Color.white;
         }
         isInitialized = true;
      }
   }
}