namespace Terraria
{
    using Microsoft.Xna.Framework;
    using System;
    using System.Runtime.InteropServices;

    public class Dust
    {
        public bool active;
        public int alpha;
        public Color color;
        public float fadeIn;
        public Rectangle frame;
        public static int lavaBubbles;
        public bool noGravity;
        public bool noLight;
        public Vector2 position;
        public float rotation;
        public float scale;
        public int type;
        public Vector2 velocity;

        public Color GetAlpha(Color newColor)
        {
            float num4 = ((float) (0xff - this.alpha)) / 255f;
            if (((this.type == 6) || (this.type == 0x4b)) || ((this.type == 20) || (this.type == 0x15)))
            {
                return new Color(newColor.R, newColor.G, newColor.B, 0x19);
            }
            if (((this.type == 0x44) || (this.type == 70)) && this.noGravity)
            {
                return new Color(0xff, 0xff, 0xff, 0);
            }
            if (((((this.type == 15) || (this.type == 20)) || ((this.type == 0x15) || (this.type == 0x1d))) || (((this.type == 0x23) || (this.type == 0x29)) || ((this.type == 0x2c) || (this.type == 0x1b)))) || ((((this.type == 0x2d) || (this.type == 0x37)) || ((this.type == 0x38) || (this.type == 0x39))) || (((this.type == 0x3a) || (this.type == 0x49)) || (this.type == 0x4a))))
            {
                num4 = (num4 + 3f) / 4f;
            }
            else if (this.type == 0x2b)
            {
                num4 = (num4 + 9f) / 10f;
            }
            else
            {
                if (this.type == 0x42)
                {
                    return new Color(newColor.R, newColor.G, newColor.B, 0);
                }
                if (this.type == 0x47)
                {
                    return new Color(200, 200, 200, 0);
                }
                if (this.type == 0x48)
                {
                    return new Color(200, 200, 200, 200);
                }
            }
            int r = (int) (newColor.R * num4);
            int g = (int) (newColor.G * num4);
            int b = (int) (newColor.B * num4);
            int a = newColor.A - this.alpha;
            if (a < 0)
            {
                a = 0;
            }
            if (a > 0xff)
            {
                a = 0xff;
            }
            return new Color(r, g, b, a);
        }

        public Color GetColor(Color newColor)
        {
            int r = this.color.R - (0xff - newColor.R);
            int g = this.color.G - (0xff - newColor.G);
            int b = this.color.B - (0xff - newColor.B);
            int a = this.color.A - (0xff - newColor.A);
            if (r < 0)
            {
                r = 0;
            }
            if (r > 0xff)
            {
                r = 0xff;
            }
            if (g < 0)
            {
                g = 0;
            }
            if (g > 0xff)
            {
                g = 0xff;
            }
            if (b < 0)
            {
                b = 0;
            }
            if (b > 0xff)
            {
                b = 0xff;
            }
            if (a < 0)
            {
                a = 0;
            }
            if (a > 0xff)
            {
                a = 0xff;
            }
            return new Color(r, g, b, a);
        }

        public static int NewDust(Vector2 Position, int Width, int Height, int Type, float SpeedX = 0f, float SpeedY = 0f, int Alpha = 0, Color newColor = new Color(), float Scale = 1f)
        {
            if (Main.gameMenu)
            {
                return 0;
            }
            if (Main.rand == null)
            {
                Main.rand = new Random((int) DateTime.Now.Ticks);
            }
            if (Main.gamePaused)
            {
                return 0;
            }
            if (WorldGen.gen)
            {
                return 0;
            }
            if (Main.netMode == 2)
            {
                return 0;
            }
            Rectangle rectangle = new Rectangle((int) ((Main.player[Main.myPlayer].position.X - (Main.screenWidth / 2)) - 100f), (int) ((Main.player[Main.myPlayer].position.Y - (Main.screenHeight / 2)) - 100f), Main.screenWidth + 200, Main.screenHeight + 200);
            Rectangle rectangle2 = new Rectangle((int) Position.X, (int) Position.Y, 10, 10);
            if (!rectangle.Intersects(rectangle2))
            {
                return 0x7d0;
            }
            int num = 0x7d0;
            for (int i = 0; i < 0x7d0; i++)
            {
                if (!Main.dust[i].active)
                {
                    int num3 = Width;
                    int num4 = Height;
                    if (num3 < 5)
                    {
                        num3 = 5;
                    }
                    if (num4 < 5)
                    {
                        num4 = 5;
                    }
                    num = i;
                    Main.dust[i].fadeIn = 0f;
                    Main.dust[i].active = true;
                    Main.dust[i].type = Type;
                    Main.dust[i].noGravity = false;
                    Main.dust[i].color = newColor;
                    Main.dust[i].alpha = Alpha;
                    Main.dust[i].position.X = (Position.X + Main.rand.Next(num3 - 4)) + 4f;
                    Main.dust[i].position.Y = (Position.Y + Main.rand.Next(num4 - 4)) + 4f;
                    Main.dust[i].velocity.X = (Main.rand.Next(-20, 0x15) * 0.1f) + SpeedX;
                    Main.dust[i].velocity.Y = (Main.rand.Next(-20, 0x15) * 0.1f) + SpeedY;
                    Main.dust[i].frame.X = 10 * Type;
                    Main.dust[i].frame.Y = 10 * Main.rand.Next(3);
                    Main.dust[i].frame.Width = 8;
                    Main.dust[i].frame.Height = 8;
                    Main.dust[i].rotation = 0f;
                    Main.dust[i].scale = 1f + (Main.rand.Next(-20, 0x15) * 0.01f);
                    Dust dust1 = Main.dust[i];
                    dust1.scale *= Scale;
                    Main.dust[i].noLight = false;
                    if (((Main.dust[i].type == 6) || (Main.dust[i].type == 0x4b)) || ((Main.dust[i].type == 0x1d) || ((Main.dust[i].type >= 0x3b) && (Main.dust[i].type <= 0x41))))
                    {
                        Main.dust[i].velocity.Y = Main.rand.Next(-10, 6) * 0.1f;
                        Main.dust[i].velocity.X *= 0.3f;
                        Dust dust2 = Main.dust[i];
                        dust2.scale *= 0.7f;
                    }
                    if ((Main.dust[i].type == 0x21) || (Main.dust[i].type == 0x34))
                    {
                        Main.dust[i].alpha = 170;
                        Dust dust3 = Main.dust[i];
                        dust3.velocity = (Vector2) (dust3.velocity * 0.5f);
                        Main.dust[i].velocity.Y++;
                    }
                    if (Main.dust[i].type == 0x29)
                    {
                        Dust dust4 = Main.dust[i];
                        dust4.velocity = (Vector2) (dust4.velocity * 0f);
                    }
                    if ((Main.dust[i].type == 0x22) || (Main.dust[i].type == 0x23))
                    {
                        Dust dust5 = Main.dust[i];
                        dust5.velocity = (Vector2) (dust5.velocity * 0.1f);
                        Main.dust[i].velocity.Y = -0.5f;
                        if ((Main.dust[i].type == 0x22) && !Collision.WetCollision(new Vector2(Main.dust[i].position.X, Main.dust[i].position.Y - 8f), 4, 4))
                        {
                            Main.dust[i].active = false;
                        }
                    }
                    return num;
                }
            }
            return num;
        }

        public static void UpdateDust()
        {
            lavaBubbles = 0;
            for (int i = 0; i < 0x7d0; i++)
            {
                if (i < Main.numDust)
                {
                    if (!Main.dust[i].active)
                    {
                        continue;
                    }
                    if (Main.dust[i].type == 0x23)
                    {
                        lavaBubbles++;
                    }
                    Dust dust1 = Main.dust[i];
                    dust1.position += Main.dust[i].velocity;
                    if (((Main.dust[i].type == 6) || (Main.dust[i].type == 0x4b)) || ((Main.dust[i].type == 0x1d) || ((Main.dust[i].type >= 0x3b) && (Main.dust[i].type <= 0x41))))
                    {
                        if (!Main.dust[i].noGravity)
                        {
                            Main.dust[i].velocity.Y += 0.05f;
                        }
                        if (!Main.dust[i].noLight)
                        {
                            float b = Main.dust[i].scale * 1.4f;
                            if (Main.dust[i].type == 0x1d)
                            {
                                if (b > 1f)
                                {
                                    b = 1f;
                                }
                                Lighting.addLight((int) (Main.dust[i].position.X / 16f), (int) (Main.dust[i].position.Y / 16f), b * 0.1f, b * 0.4f, b);
                            }
                            if (Main.dust[i].type == 0x4b)
                            {
                                if (b > 1f)
                                {
                                    b = 1f;
                                }
                                Lighting.addLight((int) (Main.dust[i].position.X / 16f), (int) (Main.dust[i].position.Y / 16f), b * 0.7f, b, b * 0.2f);
                            }
                            else if ((Main.dust[i].type >= 0x3b) && (Main.dust[i].type <= 0x41))
                            {
                                if (b > 0.8f)
                                {
                                    b = 0.8f;
                                }
                                int num3 = Main.dust[i].type - 0x3a;
                                float num4 = 1f;
                                float num5 = 1f;
                                float num6 = 1f;
                                switch (num3)
                                {
                                    case 1:
                                        num4 = 0f;
                                        num5 = 0.1f;
                                        num6 = 1.3f;
                                        break;

                                    case 2:
                                        num4 = 1f;
                                        num5 = 0.1f;
                                        num6 = 0.1f;
                                        break;

                                    case 3:
                                        num4 = 0f;
                                        num5 = 1f;
                                        num6 = 0.1f;
                                        break;

                                    case 4:
                                        num4 = 0.9f;
                                        num5 = 0f;
                                        num6 = 0.9f;
                                        break;

                                    case 5:
                                        num4 = 1.3f;
                                        num5 = 1.3f;
                                        num6 = 1.3f;
                                        break;

                                    case 6:
                                        num4 = 0.9f;
                                        num5 = 0.9f;
                                        num6 = 0f;
                                        break;

                                    case 7:
                                        num4 = (0.5f * Main.demonTorch) + (1f * (1f - Main.demonTorch));
                                        num5 = 0.3f;
                                        num6 = (1f * Main.demonTorch) + (0.5f * (1f - Main.demonTorch));
                                        break;
                                }
                                Lighting.addLight((int) (Main.dust[i].position.X / 16f), (int) (Main.dust[i].position.Y / 16f), b * num4, b * num5, b * num6);
                            }
                            else
                            {
                                if (b > 0.6f)
                                {
                                    b = 0.6f;
                                }
                                Lighting.addLight((int) (Main.dust[i].position.X / 16f), (int) (Main.dust[i].position.Y / 16f), b, b * 0.65f, b * 0.4f);
                            }
                        }
                    }
                    else if (((Main.dust[i].type == 14) || (Main.dust[i].type == 0x10)) || ((Main.dust[i].type == 0x1f) || (Main.dust[i].type == 0x2e)))
                    {
                        Main.dust[i].velocity.Y *= 0.98f;
                        Main.dust[i].velocity.X *= 0.98f;
                        if ((Main.dust[i].type == 0x1f) && Main.dust[i].noGravity)
                        {
                            Dust dust2 = Main.dust[i];
                            dust2.velocity = (Vector2) (dust2.velocity * 1.02f);
                            Dust dust3 = Main.dust[i];
                            dust3.scale += 0.02f;
                            Dust dust4 = Main.dust[i];
                            dust4.alpha += 4;
                            if (Main.dust[i].alpha > 0xff)
                            {
                                Main.dust[i].scale = 0.0001f;
                                Main.dust[i].alpha = 0xff;
                            }
                        }
                    }
                    else if (Main.dust[i].type == 0x20)
                    {
                        Dust dust5 = Main.dust[i];
                        dust5.scale -= 0.01f;
                        Main.dust[i].velocity.X *= 0.96f;
                        Main.dust[i].velocity.Y += 0.1f;
                    }
                    else if (Main.dust[i].type == 0x2b)
                    {
                        Dust dust6 = Main.dust[i];
                        dust6.rotation += 0.1f * Main.dust[i].scale;
                        Color color = Lighting.GetColor((int) (Main.dust[i].position.X / 16f), (int) (Main.dust[i].position.Y / 16f));
                        float r = ((float) color.R) / 270f;
                        float g = ((float) color.G) / 270f;
                        float num9 = ((float) color.B) / 270f;
                        r *= Main.dust[i].scale * 1.07f;
                        g *= Main.dust[i].scale * 1.07f;
                        num9 *= Main.dust[i].scale * 1.07f;
                        if (Main.dust[i].alpha < 0xff)
                        {
                            Dust dust7 = Main.dust[i];
                            dust7.scale += 0.09f;
                            if (Main.dust[i].scale >= 1f)
                            {
                                Main.dust[i].scale = 1f;
                                Main.dust[i].alpha = 0xff;
                            }
                        }
                        else
                        {
                            if (Main.dust[i].scale < 0.8)
                            {
                                Dust dust8 = Main.dust[i];
                                dust8.scale -= 0.01f;
                            }
                            if (Main.dust[i].scale < 0.5)
                            {
                                Dust dust9 = Main.dust[i];
                                dust9.scale -= 0.01f;
                            }
                        }
                        if (((r < 0.05) && (g < 0.05)) && (num9 < 0.05))
                        {
                            Main.dust[i].active = false;
                        }
                        else
                        {
                            Lighting.addLight((int) (Main.dust[i].position.X / 16f), (int) (Main.dust[i].position.Y / 16f), r, g, num9);
                        }
                    }
                    else if (((Main.dust[i].type == 15) || (Main.dust[i].type == 0x39)) || (Main.dust[i].type == 0x3a))
                    {
                        Main.dust[i].velocity.Y *= 0.98f;
                        Main.dust[i].velocity.X *= 0.98f;
                        float scale = Main.dust[i].scale;
                        if (Main.dust[i].type != 15)
                        {
                            scale = Main.dust[i].scale * 0.8f;
                        }
                        if (Main.dust[i].noLight)
                        {
                            Dust dust10 = Main.dust[i];
                            dust10.velocity = (Vector2) (dust10.velocity * 0.95f);
                        }
                        if (scale > 1f)
                        {
                            scale = 1f;
                        }
                        if (Main.dust[i].type == 15)
                        {
                            Lighting.addLight((int) (Main.dust[i].position.X / 16f), (int) (Main.dust[i].position.Y / 16f), scale * 0.45f, scale * 0.55f, scale);
                        }
                        else if (Main.dust[i].type == 0x39)
                        {
                            Lighting.addLight((int) (Main.dust[i].position.X / 16f), (int) (Main.dust[i].position.Y / 16f), scale * 0.95f, scale * 0.95f, scale * 0.45f);
                        }
                        else if (Main.dust[i].type == 0x3a)
                        {
                            Lighting.addLight((int) (Main.dust[i].position.X / 16f), (int) (Main.dust[i].position.Y / 16f), scale, scale * 0.55f, scale * 0.75f);
                        }
                    }
                    else if (Main.dust[i].type == 0x42)
                    {
                        if (Main.dust[i].velocity.X < 0f)
                        {
                            Dust dust11 = Main.dust[i];
                            dust11.rotation--;
                        }
                        else
                        {
                            Dust dust12 = Main.dust[i];
                            dust12.rotation++;
                        }
                        Main.dust[i].velocity.Y *= 0.98f;
                        Main.dust[i].velocity.X *= 0.98f;
                        Dust dust13 = Main.dust[i];
                        dust13.scale += 0.02f;
                        float num11 = Main.dust[i].scale;
                        if (Main.dust[i].type != 15)
                        {
                            num11 = Main.dust[i].scale * 0.8f;
                        }
                        if (num11 > 1f)
                        {
                            num11 = 1f;
                        }
                        Lighting.addLight((int) (Main.dust[i].position.X / 16f), (int) (Main.dust[i].position.Y / 16f), num11 * (((float) Main.dust[i].color.R) / 255f), num11 * (((float) Main.dust[i].color.G) / 255f), num11 * (((float) Main.dust[i].color.B) / 255f));
                    }
                    else if ((Main.dust[i].type == 20) || (Main.dust[i].type == 0x15))
                    {
                        Dust dust14 = Main.dust[i];
                        dust14.scale += 0.005f;
                        Main.dust[i].velocity.Y *= 0.94f;
                        Main.dust[i].velocity.X *= 0.94f;
                        float num12 = Main.dust[i].scale * 0.8f;
                        if (num12 > 1f)
                        {
                            num12 = 1f;
                        }
                        if (Main.dust[i].type == 0x15)
                        {
                            num12 = Main.dust[i].scale * 0.4f;
                            Lighting.addLight((int) (Main.dust[i].position.X / 16f), (int) (Main.dust[i].position.Y / 16f), num12 * 0.8f, num12 * 0.3f, num12);
                        }
                        else
                        {
                            Lighting.addLight((int) (Main.dust[i].position.X / 16f), (int) (Main.dust[i].position.Y / 16f), num12 * 0.3f, num12 * 0.6f, num12);
                        }
                    }
                    else if ((Main.dust[i].type == 0x1b) || (Main.dust[i].type == 0x2d))
                    {
                        Dust dust15 = Main.dust[i];
                        dust15.velocity = (Vector2) (dust15.velocity * 0.94f);
                        Dust dust16 = Main.dust[i];
                        dust16.scale += 0.002f;
                        float num13 = Main.dust[i].scale;
                        if (Main.dust[i].noLight)
                        {
                            num13 *= 0.1f;
                            Dust dust17 = Main.dust[i];
                            dust17.scale -= 0.06f;
                            if (Main.dust[i].scale < 1f)
                            {
                                Dust dust18 = Main.dust[i];
                                dust18.scale -= 0.06f;
                            }
                            if (Main.player[Main.myPlayer].wet)
                            {
                                Dust dust19 = Main.dust[i];
                                dust19.position += (Vector2) (Main.player[Main.myPlayer].velocity * 0.5f);
                            }
                            else
                            {
                                Dust dust20 = Main.dust[i];
                                dust20.position += Main.player[Main.myPlayer].velocity;
                            }
                        }
                        if (num13 > 1f)
                        {
                            num13 = 1f;
                        }
                        Lighting.addLight((int) (Main.dust[i].position.X / 16f), (int) (Main.dust[i].position.Y / 16f), num13 * 0.6f, num13 * 0.2f, num13);
                    }
                    else if (((Main.dust[i].type == 0x37) || (Main.dust[i].type == 0x38)) || ((Main.dust[i].type == 0x49) || (Main.dust[i].type == 0x4a)))
                    {
                        Dust dust21 = Main.dust[i];
                        dust21.velocity = (Vector2) (dust21.velocity * 0.98f);
                        float num14 = Main.dust[i].scale * 0.8f;
                        if (Main.dust[i].type == 0x37)
                        {
                            if (num14 > 1f)
                            {
                                num14 = 1f;
                            }
                            Lighting.addLight((int) (Main.dust[i].position.X / 16f), (int) (Main.dust[i].position.Y / 16f), num14, num14, num14 * 0.6f);
                        }
                        else if (Main.dust[i].type == 0x49)
                        {
                            if (num14 > 1f)
                            {
                                num14 = 1f;
                            }
                            Lighting.addLight((int) (Main.dust[i].position.X / 16f), (int) (Main.dust[i].position.Y / 16f), num14, num14 * 0.35f, num14 * 0.5f);
                        }
                        else if (Main.dust[i].type == 0x4a)
                        {
                            if (num14 > 1f)
                            {
                                num14 = 1f;
                            }
                            Lighting.addLight((int) (Main.dust[i].position.X / 16f), (int) (Main.dust[i].position.Y / 16f), num14 * 0.35f, num14, num14 * 0.5f);
                        }
                        else
                        {
                            num14 = Main.dust[i].scale * 1.2f;
                            if (num14 > 1f)
                            {
                                num14 = 1f;
                            }
                            Lighting.addLight((int) (Main.dust[i].position.X / 16f), (int) (Main.dust[i].position.Y / 16f), num14 * 0.35f, num14 * 0.5f, num14);
                        }
                    }
                    else if ((Main.dust[i].type == 0x47) || (Main.dust[i].type == 0x48))
                    {
                        Dust dust22 = Main.dust[i];
                        dust22.velocity = (Vector2) (dust22.velocity * 0.98f);
                        float num15 = Main.dust[i].scale;
                        if (num15 > 1f)
                        {
                            num15 = 1f;
                        }
                        Lighting.addLight((int) (Main.dust[i].position.X / 16f), (int) (Main.dust[i].position.Y / 16f), num15 * 0.2f, 0f, num15 * 0.1f);
                    }
                    else if ((!Main.dust[i].noGravity && (Main.dust[i].type != 0x29)) && (Main.dust[i].type != 0x2c))
                    {
                        Main.dust[i].velocity.Y += 0.1f;
                    }
                    if ((Main.dust[i].type == 5) && Main.dust[i].noGravity)
                    {
                        Dust dust23 = Main.dust[i];
                        dust23.scale -= 0.04f;
                    }
                    if ((Main.dust[i].type == 0x21) || (Main.dust[i].type == 0x34))
                    {
                        if (Main.dust[i].velocity.X == 0f)
                        {
                            if (Collision.SolidCollision(Main.dust[i].position, 2, 2))
                            {
                                Main.dust[i].scale = 0f;
                            }
                            Dust dust24 = Main.dust[i];
                            dust24.rotation += 0.5f;
                            Dust dust25 = Main.dust[i];
                            dust25.scale -= 0.01f;
                        }
                        if (Collision.WetCollision(new Vector2(Main.dust[i].position.X, Main.dust[i].position.Y), 4, 4))
                        {
                            Dust dust26 = Main.dust[i];
                            dust26.alpha += 20;
                            Dust dust27 = Main.dust[i];
                            dust27.scale -= 0.1f;
                        }
                        Dust dust28 = Main.dust[i];
                        dust28.alpha += 2;
                        Dust dust29 = Main.dust[i];
                        dust29.scale -= 0.005f;
                        if (Main.dust[i].alpha > 0xff)
                        {
                            Main.dust[i].scale = 0f;
                        }
                        Main.dust[i].velocity.X *= 0.93f;
                        if (Main.dust[i].velocity.Y > 4f)
                        {
                            Main.dust[i].velocity.Y = 4f;
                        }
                        if (Main.dust[i].noGravity)
                        {
                            if (Main.dust[i].velocity.X < 0f)
                            {
                                Dust dust30 = Main.dust[i];
                                dust30.rotation -= 0.2f;
                            }
                            else
                            {
                                Dust dust31 = Main.dust[i];
                                dust31.rotation += 0.2f;
                            }
                            Dust dust32 = Main.dust[i];
                            dust32.scale += 0.03f;
                            Main.dust[i].velocity.X *= 1.05f;
                            Main.dust[i].velocity.Y += 0.15f;
                        }
                    }
                    if ((Main.dust[i].type == 0x23) && Main.dust[i].noGravity)
                    {
                        Dust dust33 = Main.dust[i];
                        dust33.scale += 0.03f;
                        if (Main.dust[i].scale < 1f)
                        {
                            Main.dust[i].velocity.Y += 0.075f;
                        }
                        Main.dust[i].velocity.X *= 1.08f;
                        if (Main.dust[i].velocity.X > 0f)
                        {
                            Dust dust34 = Main.dust[i];
                            dust34.rotation += 0.01f;
                        }
                        else
                        {
                            Dust dust35 = Main.dust[i];
                            dust35.rotation -= 0.01f;
                        }
                        float num16 = Main.dust[i].scale * 0.6f;
                        if (num16 > 1f)
                        {
                            num16 = 1f;
                        }
                        Lighting.addLight((int) (Main.dust[i].position.X / 16f), (int) ((Main.dust[i].position.Y / 16f) + 1f), num16, num16 * 0.3f, num16 * 0.1f);
                    }
                    else if (Main.dust[i].type == 0x43)
                    {
                        float num17 = Main.dust[i].scale;
                        if (num17 > 1f)
                        {
                            num17 = 1f;
                        }
                        Lighting.addLight((int) (Main.dust[i].position.X / 16f), (int) (Main.dust[i].position.Y / 16f), 0f, num17 * 0.8f, num17);
                    }
                    else if ((Main.dust[i].type == 0x22) || (Main.dust[i].type == 0x23))
                    {
                        if (!Collision.WetCollision(new Vector2(Main.dust[i].position.X, Main.dust[i].position.Y - 8f), 4, 4))
                        {
                            Main.dust[i].scale = 0f;
                        }
                        else
                        {
                            Dust dust36 = Main.dust[i];
                            dust36.alpha += Main.rand.Next(2);
                            if (Main.dust[i].alpha > 0xff)
                            {
                                Main.dust[i].scale = 0f;
                            }
                            Main.dust[i].velocity.Y = -0.5f;
                            if (Main.dust[i].type == 0x22)
                            {
                                Dust dust37 = Main.dust[i];
                                dust37.scale += 0.005f;
                            }
                            else
                            {
                                Dust dust38 = Main.dust[i];
                                dust38.alpha++;
                                Dust dust39 = Main.dust[i];
                                dust39.scale -= 0.01f;
                                Main.dust[i].velocity.Y = -0.2f;
                            }
                            Main.dust[i].velocity.X += Main.rand.Next(-10, 10) * 0.002f;
                            if (Main.dust[i].velocity.X < -0.25)
                            {
                                Main.dust[i].velocity.X = -0.25f;
                            }
                            if (Main.dust[i].velocity.X > 0.25)
                            {
                                Main.dust[i].velocity.X = 0.25f;
                            }
                        }
                        if (Main.dust[i].type == 0x23)
                        {
                            float num18 = (Main.dust[i].scale * 0.3f) + 0.4f;
                            if (num18 > 1f)
                            {
                                num18 = 1f;
                            }
                            Lighting.addLight((int) (Main.dust[i].position.X / 16f), (int) (Main.dust[i].position.Y / 16f), num18, num18 * 0.5f, num18 * 0.3f);
                        }
                    }
                    if (Main.dust[i].type == 0x44)
                    {
                        float num19 = Main.dust[i].scale * 0.3f;
                        if (num19 > 1f)
                        {
                            num19 = 1f;
                        }
                        Lighting.addLight((int) (Main.dust[i].position.X / 16f), (int) (Main.dust[i].position.Y / 16f), num19 * 0.1f, num19 * 0.2f, num19);
                    }
                    if (Main.dust[i].type == 70)
                    {
                        float num20 = Main.dust[i].scale * 0.3f;
                        if (num20 > 1f)
                        {
                            num20 = 1f;
                        }
                        Lighting.addLight((int) (Main.dust[i].position.X / 16f), (int) (Main.dust[i].position.Y / 16f), num20 * 0.5f, 0f, num20);
                    }
                    if (Main.dust[i].type == 0x29)
                    {
                        Main.dust[i].velocity.X += Main.rand.Next(-10, 11) * 0.01f;
                        Main.dust[i].velocity.Y += Main.rand.Next(-10, 11) * 0.01f;
                        if (Main.dust[i].velocity.X > 0.75)
                        {
                            Main.dust[i].velocity.X = 0.75f;
                        }
                        if (Main.dust[i].velocity.X < -0.75)
                        {
                            Main.dust[i].velocity.X = -0.75f;
                        }
                        if (Main.dust[i].velocity.Y > 0.75)
                        {
                            Main.dust[i].velocity.Y = 0.75f;
                        }
                        if (Main.dust[i].velocity.Y < -0.75)
                        {
                            Main.dust[i].velocity.Y = -0.75f;
                        }
                        Dust dust40 = Main.dust[i];
                        dust40.scale += 0.007f;
                        float num21 = Main.dust[i].scale * 0.7f;
                        if (num21 > 1f)
                        {
                            num21 = 1f;
                        }
                        Lighting.addLight((int) (Main.dust[i].position.X / 16f), (int) (Main.dust[i].position.Y / 16f), num21 * 0.4f, num21 * 0.9f, num21);
                    }
                    else if (Main.dust[i].type == 0x2c)
                    {
                        Main.dust[i].velocity.X += Main.rand.Next(-10, 11) * 0.003f;
                        Main.dust[i].velocity.Y += Main.rand.Next(-10, 11) * 0.003f;
                        if (Main.dust[i].velocity.X > 0.35)
                        {
                            Main.dust[i].velocity.X = 0.35f;
                        }
                        if (Main.dust[i].velocity.X < -0.35)
                        {
                            Main.dust[i].velocity.X = -0.35f;
                        }
                        if (Main.dust[i].velocity.Y > 0.35)
                        {
                            Main.dust[i].velocity.Y = 0.35f;
                        }
                        if (Main.dust[i].velocity.Y < -0.35)
                        {
                            Main.dust[i].velocity.Y = -0.35f;
                        }
                        Dust dust41 = Main.dust[i];
                        dust41.scale += 0.0085f;
                        float num22 = Main.dust[i].scale * 0.7f;
                        if (num22 > 1f)
                        {
                            num22 = 1f;
                        }
                        Lighting.addLight((int) (Main.dust[i].position.X / 16f), (int) (Main.dust[i].position.Y / 16f), num22 * 0.7f, num22, num22 * 0.8f);
                    }
                    else
                    {
                        Main.dust[i].velocity.X *= 0.99f;
                    }
                    if (Main.dust[i].type != 0x4f)
                    {
                        Dust dust42 = Main.dust[i];
                        dust42.rotation += Main.dust[i].velocity.X * 0.5f;
                    }
                    if (Main.dust[i].fadeIn > 0f)
                    {
                        if (Main.dust[i].type == 0x2e)
                        {
                            Dust dust43 = Main.dust[i];
                            dust43.scale += 0.1f;
                        }
                        else
                        {
                            Dust dust44 = Main.dust[i];
                            dust44.scale += 0.03f;
                        }
                        if (Main.dust[i].scale > Main.dust[i].fadeIn)
                        {
                            Main.dust[i].fadeIn = 0f;
                        }
                    }
                    else
                    {
                        Dust dust45 = Main.dust[i];
                        dust45.scale -= 0.01f;
                    }
                    if (Main.dust[i].noGravity)
                    {
                        Dust dust46 = Main.dust[i];
                        dust46.velocity = (Vector2) (dust46.velocity * 0.92f);
                        if (Main.dust[i].fadeIn == 0f)
                        {
                            Dust dust47 = Main.dust[i];
                            dust47.scale -= 0.04f;
                        }
                    }
                    if (Main.dust[i].position.Y > (Main.screenPosition.Y + Main.screenHeight))
                    {
                        Main.dust[i].active = false;
                    }
                    if (Main.dust[i].scale < 0.1)
                    {
                        Main.dust[i].active = false;
                    }
                    continue;
                }
                Main.dust[i].active = false;
            }
        }
    }
}

