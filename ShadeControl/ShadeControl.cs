using Modding;
using DebugMod;
using UnityEngine;
namespace ShadeControl
{
    public class ShadeControl:Mod
    {
        public override string GetVersion()
        {
            return "1.0";
        }
        public static ShadeControl instance;
        public override void Initialize()
        {
            instance = this;
            
            if(ModHooks.GetMod("DebugMod") is Mod)
            {
                AddShadeFunc();
            }
        }

       

        private void AddShadeFunc()
        {
            DebugMod.DebugMod.AddToKeyBindList(typeof(ShadeFunc));
        }
        public static class ShadeFunc
        {
            [BindableMethod(name ="Shade Fireball",category ="ShadeControl")]
            public static void ShadeFireball()
            {
                GameObject shade = GameObject.Find("Hollow Shade(Clone)");
                if(shade != null)
                {
                    PlayMakerFSM shadecontrol = shade.LocateMyFSM("Shade Control");
                    shadecontrol.FsmVariables.GetFsmInt("SP").Value = 1;
                    shadecontrol.SetState("Attack Choice");
                    shadecontrol.SendEvent("FIREBALL");
                    Modding.Logger.LogDebug("Fire!");
                }
            }
            [BindableMethod(name ="Shade Quake",category ="ShadeControl")]
            public static void ShadeQuake()
            {
                GameObject shade = GameObject.Find("Hollow Shade(Clone)");
                if (shade != null)
                {
                    PlayMakerFSM shadecontrol = shade.LocateMyFSM("Shade Control");
                    shadecontrol.FsmVariables.GetFsmInt("SP").Value = 1;
                    shadecontrol.SetState("Quake?");
                    shadecontrol.SendEvent("QUAKE");
                    Modding.Logger.LogDebug("Quake!");
                }
            }
            [BindableMethod(name = "Shade Scream", category = "ShadeControl")]
            public static void ShadeScream()
            {
                GameObject shade = GameObject.Find("Hollow Shade(Clone)");
                if (shade != null)
                {
                    PlayMakerFSM shadecontrol = shade.LocateMyFSM("Shade Control");
                    shadecontrol.FsmVariables.GetFsmInt("SP").Value = 1;
                    shadecontrol.SetState("Scream?");
                    shadecontrol.SendEvent("SCREAM");
                    Modding.Logger.LogDebug("Scream!");
                }
            }
        }
        
    }
}
