using HarmonyLib;
using SDG3R.Client.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SDG3R.Client.Utilities
{
    [MonoComponent]
    public class PatchUtilities : MonoBehaviour
    {
        public static Harmony hInstance;

        void Start()
        {
            hInstance = new Harmony("SDG3R.Client");
            hInstance.PatchAll();
        }
    }
}
