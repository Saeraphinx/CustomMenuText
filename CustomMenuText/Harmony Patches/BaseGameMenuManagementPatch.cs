using CustomMenuText.Configuration;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace CustomMenuText.Harmony_Patches
{
    [HarmonyPatch(typeof(MenuEnvironmentManager), "ShowEnvironmentType")]
    internal class BaseGameMenuManagementPatch
    {
        internal static void Postfix(MenuEnvironmentManager.MenuEnvironmentType menuEnvironmentType)
        {
            if (Plugin.selection_type == 0)
            {
                return;
            }
            else
            {
                Plugin.defaultLogo.SetActive(false);
                if (menuEnvironmentType == MenuEnvironmentManager.MenuEnvironmentType.Lobby)
                {
                    Plugin.mainText.gameObject.SetActive(false);
                    Plugin.bottomText.gameObject.SetActive(false);
                }
                else
                {
                    Plugin.mainText.gameObject.SetActive(true);
                    Plugin.bottomText.gameObject.SetActive(true);
                }
            }
        }
    }


}
