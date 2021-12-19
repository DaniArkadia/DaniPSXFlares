using System.Collections;
using System.Collections.Generic;
using DaniPSXFlares.flareSettings;
using UnityEngine;

namespace DaniPSXFlares
{
   public class FlarePositioner
   {
      PSXLensFlare lensFlare;
      PositionSettings positionSettings;
      Transform transform;
      LensFlareElement element;

      public FlarePositioner (PSXLensFlare lensFlare, LensFlareElement lensFlareElement)
      {
         this.lensFlare = lensFlare;
         this.positionSettings = lensFlareElement.positionSettings;
         this.transform = lensFlareElement.spawnedObject.transform;
         this.element = lensFlareElement;
      }
      public void SetScale()
      {
         var scaleAmount = positionSettings.GetAdjustedScale();
         var defaultSize = (Vector3.one) * scaleAmount;
         transform.localScale = defaultSize;
      }
      public void UpdateTransform()
      {
         var lensFlareAsset = lensFlare.flareConfig;
         var sourceTransform = lensFlare.transform;
         var activeCamera = lensFlare.activeCamera;
         var elementTransform = transform;
         var sourcePosScreen = activeCamera.WorldToScreenPoint(sourceTransform.position);
         var screenCenter = new Vector3(activeCamera.scaledPixelWidth / 2, activeCamera.scaledPixelHeight / 2);
         var distanceToCenter = Vector3.Distance(sourcePosScreen, screenCenter);
         var flareDirection = (screenCenter - sourcePosScreen).normalized;
         var reflectedDirection = Vector3.Reflect(flareDirection, Vector3.up);
         var cameraDist = Vector3.Distance(sourceTransform.position, activeCamera.transform.position);
         elementTransform.LookAt(activeCamera.transform, Vector3.up);
         var pos = new Vector3(0, 0, 0) + reflectedDirection * element.positionSettings.GetAdjustedPos() * lensFlareAsset.distanceMultiplier * distanceToCenter * lensFlareAsset.groupingCurve.Evaluate(distanceToCenter / 600) * (cameraDist * 0.2f);
         pos = new Vector3(pos.x * lensFlareAsset.xCompression, pos.y * lensFlareAsset.yCompression);
         var offset = element.positionSettings.offset;
         elementTransform.localPosition = pos + new Vector3(offset.x, offset.y, 0);
         var rotation = element.positionSettings.rotation;
         elementTransform.localEulerAngles = new Vector3(0, 0, Vector3.Distance(sourcePosScreen, new Vector3(activeCamera.scaledPixelWidth * 2 + cameraDist ,0,0)) * rotation);
         var scaleAmount = positionSettings.GetAdjustedScale();
         var defaultSize = (Vector3.one) * scaleAmount;
         if (element.positionSettings.constantPhysicalSize == false)
         {
            transform.localScale = defaultSize * element.positionSettings.resizeAdjuster * cameraDist;
         }
      }
   }
}
