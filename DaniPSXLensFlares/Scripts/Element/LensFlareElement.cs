namespace DaniPSXFlares
{
   using UnityEngine;
   using DaniPSXFlares.flareSettings;
   using System;

   [System.Serializable]
   public class LensFlareElement
   {
      public SpriteSettings spriteSettings;
      public PositionSettings positionSettings;
      public MaterialSettings materialSettings;
      public FadeSettings fadeSettings;
      internal GameObject spawnedObject;
      internal SpriteRenderer spriteRenderer;
      internal FlareRendering flareRendering;
      internal FlarePositioner flarePositioner;
      internal FlareFading flareFading;

      public void Initialize(PSXLensFlare lensFlare, GameObject spawnedObject)
      {
         this.spawnedObject = spawnedObject;
         this.spriteRenderer = spawnedObject.AddComponent<SpriteRenderer>();
         this.flareRendering = new FlareRendering(lensFlare, this);
         this.flarePositioner = new FlarePositioner(lensFlare, this);
         this.flareFading  = new FlareFading(lensFlare, this);
         flarePositioner.SetScale();
         flareRendering.UpdateRenderer();
      }
      public void RefreshElement()
      {
         flareRendering.UpdateRenderer();
      }
      public void UpdateElement()
      {
         flarePositioner.UpdateTransform();
         flareFading.HandleElementFading();
      }
      public void DespawnElement()
      {
         GameObject.Destroy(spawnedObject);
      }
      public void SetDefaultValues()
      {
         positionSettings.SetDefaultValues();
         materialSettings.SetDefaultValues();
         fadeSettings.SetDefaultValues();
      }
   }
}