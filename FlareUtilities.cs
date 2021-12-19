using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaniPSXFlares
{
   public class FlareUtilities
   {
      /*shoots a ray from the camera's position to the flare source's position to check if we have 
         line of sight and should therefore be able to see the effect*/
      public static bool HasLineOfSight(PSXLensFlare lensFlare)
      {
         Camera activeCamera = lensFlare.activeCamera;
         Transform transform = lensFlare.transform;
         BoxCollider lineOfSightCollider = lensFlare.lineOfSightBox;

         if (lineOfSightCollider == null) return true;

         RaycastHit hit;
         Physics.Raycast(activeCamera.transform.position, (transform.position - activeCamera.transform.position).normalized, out hit, 1000);
         if (hit.transform != null)
         {
            if (hit.collider == lineOfSightCollider)
            {
               return true;
            }
         }
         return false;
      }
      /*we get the dot product between the camera's forward vector and the flare source's forward vector
         then we convert it into and angle using some quick mafs, skrrrrat (sorry) then we check if it's
         in appropriate to the visible angle we set in the lens flare asset accossiated with this instance.*/
      public static bool IsAngleCorrect(PSXLensFlare lensFlare)
      {
         FlareConfig flareConfig = lensFlare.flareConfig;
         Camera activeCamera = lensFlare.activeCamera;
         Transform transform = lensFlare.transform;

         var angleToDot = (flareConfig.visibleAngle / 360) * 2;
         var dot = Vector3.Dot(activeCamera.transform.forward, transform.forward) + 1;
         if (dot <= angleToDot)
         {
            return true;
         }
         return false;
      }
   }
}
