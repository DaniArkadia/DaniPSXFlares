using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DaniPSXFlares.FlareUtilities;
namespace DaniPSXFlares
{  
   public class FlareRendering
   {
      public PSXLensFlare lensFlare;
      public LensFlareElement element;
      SpriteRenderer _spriteRenderer;

      public FlareRendering(PSXLensFlare lensFlare, LensFlareElement spawnedElement)
      {
         this.element = spawnedElement;
         this.lensFlare = lensFlare;
         _spriteRenderer = element.spriteRenderer;
      }

      public void UpdateRenderer()
      {
         SetSprite();
         SetMaterial();
      }

      void SetSprite()
      {
         if (NoValidVisualSettings()) return;
         _spriteRenderer.sprite = element.spriteSettings.sprite;
         _spriteRenderer.material = element.spriteSettings.material;
      }

      void SetMaterial()
      {
         if (NoValidVisualSettings() == true) return;
         var tempMaterial = new Material(_spriteRenderer.sharedMaterial);
         if (!IsAngleCorrect(lensFlare) || !HasLineOfSight(lensFlare))
         {
            var color = element.materialSettings.color;
            tempMaterial.SetColor("_MainColor", new Color(color.r, color.g, color.b, 0));
         }
         if (IsAngleCorrect(lensFlare) && HasLineOfSight(lensFlare))
         {
            tempMaterial.SetColor("_MainColor", element.materialSettings.color);
         }
         tempMaterial.SetColor("_EmissionColor", element.materialSettings.emissionColor);
         if (element.materialSettings.isEmissive == true)
         {
            tempMaterial.EnableKeyword("_EMISSION");
         }
         else
         {
            tempMaterial.DisableKeyword("_EMISSION");
         }
         _spriteRenderer.sharedMaterial = tempMaterial;
      }

      public bool NoValidVisualSettings()
      {
         if (NoValidSprite() || NoValidMaterial())
         {
            return true;
         }
         return false;
      }
      
      bool NoValidSprite()
      {
         return element.spriteSettings.sprite == null;
      }

      bool NoValidMaterial()
      {
         if (element.spriteSettings.material == null)
         {
            return true;
         }
         return element.spriteSettings.material.HasProperty("_MainTexture") == true;
      }
   }
}
