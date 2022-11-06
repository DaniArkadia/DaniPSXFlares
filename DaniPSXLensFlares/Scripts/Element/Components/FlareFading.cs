using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DaniPSXFlares.flareSettings;
using static DaniPSXFlares.FlareUtilities;
namespace DaniPSXFlares
{
   public class FlareFading
   {
      LensFlareElement element;
      SpriteRenderer spriteRenderer;
      FadeSettings fadeSettings;
      FlareRendering flareRendering;
      PSXLensFlare lensFlare;
      bool isVisible;
      Coroutine currentCoroutine;
      public FlareFading(PSXLensFlare lensFlare, LensFlareElement element)
      {
         this.element = element;
         this.fadeSettings = element.fadeSettings;
         this.lensFlare = lensFlare;
         this.spriteRenderer = element.spriteRenderer;
         this.flareRendering = element.flareRendering;
      }
      public void HandleElementFading()
      {
         if (flareRendering.NoValidVisualSettings()) return;
         
         if (!HasLineOfSight(lensFlare) || !IsAngleCorrect(lensFlare))
         {
            if (isVisible == true)
            {
               FadeElements(false);
               isVisible = false;
            }
         }
         if (HasLineOfSight(lensFlare) && IsAngleCorrect(lensFlare))
         {
            if (isVisible == false)
            {
               FadeElements(true);
               isVisible = true;
            }
         }
      }
      
      public void SetIsVisible()
      {
         isVisible = true;
      }
      
      //tells each element to fade in or out 
      void FadeElements(bool shouldFadeIn)
      {
         if (currentCoroutine != null)
         {
            lensFlare.StopCoroutine(currentCoroutine);
         }
         if (shouldFadeIn == true)
         {
            currentCoroutine = lensFlare.StartCoroutine(FadeIn());
         }
         else
         {
            currentCoroutine = lensFlare.StartCoroutine(FadeOut());
         }
      }

      IEnumerator FadeOut()
      {
         var totalTime = fadeSettings.fadeOutTime;
         var elapsedTime = 0f;
         var materialSettings = element.materialSettings;
         var color = materialSettings.color;
         var fadedColor = new Color(1, 1, 1, 0);
         while (spriteRenderer.sharedMaterial.GetColor("_MainColor").a > 0.01f)
         {
            spriteRenderer.sharedMaterial.SetColor("_MainColor", Color.Lerp(spriteRenderer.sharedMaterial.GetColor("_MainColor"), new Color(color.r, color.g, color.b, 0), elapsedTime / totalTime));
            elapsedTime += Time.deltaTime;
            yield return null;
         }
         yield return null;
      }

      IEnumerator FadeIn()
      {
         var totalTime = fadeSettings.fadeInTime;
         var elapsedTime = 0f;
         var materialSettings = element.materialSettings;
         var color = materialSettings.color;
         while (spriteRenderer.sharedMaterial.GetColor("_MainColor").a < color.a)
         {
            spriteRenderer.sharedMaterial.SetColor("_MainColor", Color.Lerp(spriteRenderer.sharedMaterial.GetColor("_MainColor"), color, (elapsedTime / totalTime)));
            elapsedTime += Time.deltaTime;
            yield return null;
         }
         yield return null;
      }
   }
}
