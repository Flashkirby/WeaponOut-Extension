using System;
using System.IO;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WeaponOutExtension
{
    public class ExtensionMod : Mod
    {
        public ExtensionMod()
        {
            Properties = new ModProperties()
            {
                Autoload = true,
                AutoloadGores = true,
                AutoloadSounds = true
            };
        }

        internal static Mod ModWeaponOut;
        internal static bool fistEnabledMessage;
        public override void Load()
        {
            ModWeaponOut = ModLoader.GetMod("WeaponOut");
            if (ModWeaponOut != null)
            {
                try
                {
                    fistEnabledMessage = false;
                    if (WeaponOut.ModConf.EnableFists)
                    {
                        fistEnabledMessage = true;
                        AddItem("PreHardCombo", new FistWeapons.PreHardCombo());
                        AddItem("PreHardDash", new FistWeapons.PreHardDash());
                        AddItem("PreHardParry", new FistWeapons.PreHardParry());
                        AddItem("HardmodeCombo", new FistWeapons.HardmodeCombo());
                        AddItem("HardmodeDash", new FistWeapons.HardmodeDash());
                        AddItem("HardmodeParry", new FistWeapons.HardmodeParry());
                        AddItem("AdvancedCombo", new FistWeapons.AdvancedCombo());
                        AddItem("AdvancedDash", new FistWeapons.AdvancedDash());
                        AddItem("AdvancedParry", new FistWeapons.AdvancedParry());
                    }
                }
                catch { }
            }
        }
    }

    public class ExtensionPlayer : ModPlayer
    {
        public override void OnEnterWorld(Player player)
        {
            if (ExtensionMod.fistEnabledMessage) Main.NewText("WeaponOut Enabled, adding bonus content");
        }
    }
}
