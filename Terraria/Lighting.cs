namespace Terraria
{
    using Microsoft.Xna.Framework;
    using System;
    using System.Diagnostics;

    public class Lighting
    {
        private static int blueDir = 1;
        private static float blueWave = 1f;
        public static float brightness = 1f;
        public static float[,] color = new float[(Main.screenWidth + (offScreenTiles * 2)) + 10, (Main.screenHeight + (offScreenTiles * 2)) + 10];
        public static float[,] color2 = new float[(Main.screenWidth + (offScreenTiles * 2)) + 10, (Main.screenHeight + (offScreenTiles * 2)) + 10];
        public static float[,] colorB = new float[(Main.screenWidth + (offScreenTiles * 2)) + 10, (Main.screenHeight + (offScreenTiles * 2)) + 10];
        public static float[,] colorB2 = new float[(Main.screenWidth + (offScreenTiles * 2)) + 10, (Main.screenHeight + (offScreenTiles * 2)) + 10];
        public static float[,] colorG = new float[(Main.screenWidth + (offScreenTiles * 2)) + 10, (Main.screenHeight + (offScreenTiles * 2)) + 10];
        public static float[,] colorG2 = new float[(Main.screenWidth + (offScreenTiles * 2)) + 10, (Main.screenHeight + (offScreenTiles * 2)) + 10];
        public static float defBrightness = 1f;
        public static int dirX;
        public static int dirY;
        private static int firstTileX;
        private static int firstTileX7;
        private static int firstTileY;
        private static int firstTileY7;
        private static int firstToLightX;
        private static int firstToLightX27;
        private static int firstToLightX7;
        private static int firstToLightY;
        private static int firstToLightY27;
        private static int firstToLightY7;
        private static int lastTileX;
        private static int lastTileX7;
        private static int lastTileY;
        private static int lastTileY7;
        private static int lastToLightX;
        private static int lastToLightX27;
        private static int lastToLightX7;
        private static int lastToLightY;
        private static int lastToLightY27;
        private static int lastToLightY7;
        private static float lightColor = 0f;
        private static float lightColorB = 0f;
        private static float lightColorG = 0f;
        public static int lightCounter = 0;
        public static int lightMode = 0;
        public static int maxRenderCount = 4;
        private static int maxTempLights = 0x7d0;
        public static int maxX;
        private static int maxX7;
        public static int maxY;
        private static int maxY7;
        public static int minX;
        private static int minX7;
        public static int minY;
        private static int minY7;
        private static float negLight = 0.04f;
        private static float negLight2 = 0.16f;
        public static int offScreenTiles = 0x2d;
        public static int offScreenTiles2 = 0x23;
        public static float oldSkyColor = 0f;
        public static bool resize = false;
        public static bool RGB = true;
        public static int scrX;
        public static int scrY;
        public static float skyColor = 0f;
        public static bool[,] stopLight = new bool[(Main.screenWidth + (offScreenTiles * 2)) + 10, (Main.screenHeight + (offScreenTiles * 2)) + 10];
        private static float[] tempLight = new float[maxTempLights];
        private static float[] tempLightB = new float[maxTempLights];
        public static int tempLightCount;
        private static float[] tempLightG = new float[maxTempLights];
        private static int[] tempLightX = new int[maxTempLights];
        private static int[] tempLightY = new int[maxTempLights];
        public static bool[,] wetLight = new bool[(Main.screenWidth + (offScreenTiles * 2)) + 10, (Main.screenHeight + (offScreenTiles * 2)) + 10];
        private static float wetLightG = 0.16f;
        private static float wetLightR = 0.16f;

        public static void addLight(int i, int j, float Lightness)
        {
            if (((Main.netMode != 2) && (((((i - firstTileX) + offScreenTiles) >= 0) && (((i - firstTileX) + offScreenTiles) < (((Main.screenWidth / 0x10) + (offScreenTiles * 2)) + 10))) && ((((j - firstTileY) + offScreenTiles) >= 0) && (((j - firstTileY) + offScreenTiles) < (((Main.screenHeight / 0x10) + (offScreenTiles * 2)) + 10))))) && (tempLightCount != maxTempLights))
            {
                if (!RGB)
                {
                    for (int k = 0; k < tempLightCount; k++)
                    {
                        if (((tempLightX[k] == i) && (tempLightY[k] == j)) && (Lightness <= tempLight[k]))
                        {
                            return;
                        }
                    }
                    tempLightX[tempLightCount] = i;
                    tempLightY[tempLightCount] = j;
                    tempLight[tempLightCount] = Lightness;
                    tempLightG[tempLightCount] = Lightness;
                    tempLightB[tempLightCount] = Lightness;
                    tempLightCount++;
                }
                else
                {
                    tempLight[tempLightCount] = Lightness;
                    tempLightG[tempLightCount] = Lightness;
                    tempLightB[tempLightCount] = Lightness;
                    tempLightX[tempLightCount] = i;
                    tempLightY[tempLightCount] = j;
                    tempLightCount++;
                }
            }
        }

        public static void addLight(int i, int j, float R, float G, float B)
        {
            if (Main.netMode != 2)
            {
                if (!RGB)
                {
                    addLight(i, j, ((R + G) + B) / 3f);
                }
                if ((((((i - firstTileX) + offScreenTiles) >= 0) && (((i - firstTileX) + offScreenTiles) < (((Main.screenWidth / 0x10) + (offScreenTiles * 2)) + 10))) && ((((j - firstTileY) + offScreenTiles) >= 0) && (((j - firstTileY) + offScreenTiles) < (((Main.screenHeight / 0x10) + (offScreenTiles * 2)) + 10)))) && (tempLightCount != maxTempLights))
                {
                    for (int k = 0; k < tempLightCount; k++)
                    {
                        if ((tempLightX[k] == i) && (tempLightY[k] == j))
                        {
                            if (tempLight[k] < R)
                            {
                                tempLight[k] = R;
                            }
                            if (tempLightG[k] < G)
                            {
                                tempLightG[k] = G;
                            }
                            if (tempLightB[k] < B)
                            {
                                tempLightB[k] = B;
                            }
                            return;
                        }
                    }
                    tempLight[tempLightCount] = R;
                    tempLightG[tempLightCount] = G;
                    tempLightB[tempLightCount] = B;
                    tempLightX[tempLightCount] = i;
                    tempLightY[tempLightCount] = j;
                    tempLightCount++;
                }
            }
        }

        public static bool Brighter(int x, int y, int x2, int y2)
        {
            int num = (x - firstTileX) + offScreenTiles;
            int num2 = (y - firstTileY) + offScreenTiles;
            int num3 = (x2 - firstTileX) + offScreenTiles;
            int num4 = (y2 - firstTileY) + offScreenTiles;
            try
            {
                return (((color[num, num2] + colorG[num, num2]) + colorB[num, num2]) >= ((color[num3, num4] + colorG[num3, num4]) + colorB[num3, num4]));
            }
            catch
            {
                return false;
            }
        }

        public static float Brightness(int x, int y)
        {
            if (ZidoMod.fullbright) return 255f;
            int num = (x - firstTileX) + offScreenTiles;
            int num2 = (y - firstTileY) + offScreenTiles;
            if (((num >= 0) && (num2 >= 0)) && ((num < (((Main.screenWidth / 0x10) + (offScreenTiles * 2)) + 10)) && (num2 < (((Main.screenHeight / 0x10) + (offScreenTiles * 2)) + 10))))
            {
                return (((color[num, num2] + colorG[num, num2]) + colorB[num, num2]) / 3f);
            }
            return 0f;
        }

        public static void doColors()
        {
            Stopwatch stopwatch = new Stopwatch();
            if (lightMode < 2)
            {
                blueWave += blueDir * 0.0005f;
                if (blueWave > 1f)
                {
                    blueWave = 1f;
                    blueDir = -1;
                }
                else if (blueWave < 0.97f)
                {
                    blueWave = 0.97f;
                    blueDir = 1;
                }
                if (RGB)
                {
                    negLight = 0.91f;
                    negLight2 = 0.56f;
                    wetLightG = (0.97f * negLight) * blueWave;
                    wetLightR = (0.88f * negLight) * blueWave;
                }
                else
                {
                    negLight = 0.9f;
                    negLight2 = 0.54f;
                    wetLightR = (0.95f * negLight) * blueWave;
                }
                if (Main.player[Main.myPlayer].nightVision)
                {
                    negLight *= 1.03f;
                    negLight2 *= 1.03f;
                }
                if (Main.player[Main.myPlayer].blind)
                {
                    negLight *= 0.95f;
                    negLight2 *= 0.95f;
                }
                if (!RGB)
                {
                    if (Main.renderCount == 0)
                    {
                        stopwatch.Restart();
                        for (int i = minX7; i < maxX7; i++)
                        {
                            lightColor = 0f;
                            dirX = 0;
                            dirY = 1;
                            for (int j = minY7; j < (lastToLightY27 + maxRenderCount); j++)
                            {
                                LightColor(i, j);
                            }
                            lightColor = 0f;
                            dirX = 0;
                            dirY = -1;
                            for (int k = maxY7; k >= (firstTileY7 - maxRenderCount); k--)
                            {
                                LightColor(i, k);
                            }
                        }
                        Main.lightTimer[1] = stopwatch.ElapsedMilliseconds;
                    }
                    if (Main.renderCount == 1)
                    {
                        stopwatch.Restart();
                        for (int m = firstToLightY7; m < lastToLightY7; m++)
                        {
                            lightColor = 0f;
                            dirX = 1;
                            dirY = 0;
                            for (int n = minX7; n < (lastTileX7 + maxRenderCount); n++)
                            {
                                LightColor(n, m);
                            }
                            lightColor = 0f;
                            dirX = -1;
                            dirY = 0;
                            for (int num18 = maxX7; num18 >= (firstTileX7 - maxRenderCount); num18--)
                            {
                                LightColor(num18, m);
                            }
                        }
                        Main.lightTimer[2] = stopwatch.ElapsedMilliseconds;
                    }
                    if (Main.renderCount == 1)
                    {
                        stopwatch.Restart();
                        for (int num19 = firstToLightX27; num19 < lastToLightX27; num19++)
                        {
                            lightColor = 0f;
                            dirX = 0;
                            dirY = 1;
                            for (int num20 = firstToLightY27; num20 < (lastTileY7 + maxRenderCount); num20++)
                            {
                                LightColor(num19, num20);
                            }
                            lightColor = 0f;
                            dirX = 0;
                            dirY = -1;
                            for (int num21 = lastToLightY27; num21 >= (firstTileY7 - maxRenderCount); num21--)
                            {
                                LightColor(num19, num21);
                            }
                        }
                        Main.lightTimer[3] = stopwatch.ElapsedMilliseconds;
                    }
                    if (Main.renderCount == 2)
                    {
                        stopwatch.Restart();
                        for (int num22 = firstToLightY27; num22 < lastToLightY27; num22++)
                        {
                            lightColor = 0f;
                            dirX = 1;
                            dirY = 0;
                            for (int num23 = firstToLightX27; num23 < (lastTileX7 + maxRenderCount); num23++)
                            {
                                LightColor(num23, num22);
                            }
                            lightColor = 0f;
                            dirX = -1;
                            dirY = 0;
                            for (int num24 = lastToLightX27; num24 >= (firstTileX7 - maxRenderCount); num24--)
                            {
                                LightColor(num24, num22);
                            }
                        }
                        Main.lightTimer[4] = stopwatch.ElapsedMilliseconds;
                    }
                }
                else
                {
                    if (Main.renderCount == 0)
                    {
                        stopwatch.Restart();
                        for (int num = minX7; num < maxX7; num++)
                        {
                            lightColor = 0f;
                            lightColorG = 0f;
                            lightColorB = 0f;
                            dirX = 0;
                            dirY = 1;
                            for (int num2 = minY7; num2 < (lastToLightY27 + maxRenderCount); num2++)
                            {
                                LightColor(num, num2);
                                LightColorG(num, num2);
                                LightColorB(num, num2);
                            }
                            lightColor = 0f;
                            lightColorG = 0f;
                            lightColorB = 0f;
                            dirX = 0;
                            dirY = -1;
                            for (int num3 = maxY7; num3 >= (firstTileY7 - maxRenderCount); num3--)
                            {
                                LightColor(num, num3);
                                LightColorG(num, num3);
                                LightColorB(num, num3);
                            }
                        }
                        Main.lightTimer[1] = stopwatch.ElapsedMilliseconds;
                    }
                    if (Main.renderCount == 1)
                    {
                        stopwatch.Restart();
                        for (int num4 = firstToLightY7; num4 < lastToLightY7; num4++)
                        {
                            lightColor = 0f;
                            lightColorG = 0f;
                            lightColorB = 0f;
                            dirX = 1;
                            dirY = 0;
                            for (int num5 = minX7; num5 < (lastTileX7 + maxRenderCount); num5++)
                            {
                                LightColor(num5, num4);
                                LightColorG(num5, num4);
                                LightColorB(num5, num4);
                            }
                            lightColor = 0f;
                            lightColorG = 0f;
                            lightColorB = 0f;
                            dirX = -1;
                            dirY = 0;
                            for (int num6 = maxX7; num6 >= (firstTileX7 - maxRenderCount); num6--)
                            {
                                LightColor(num6, num4);
                                LightColorG(num6, num4);
                                LightColorB(num6, num4);
                            }
                        }
                        Main.lightTimer[2] = stopwatch.ElapsedMilliseconds;
                    }
                    if (Main.renderCount == 1)
                    {
                        stopwatch.Restart();
                        for (int num7 = firstToLightX27; num7 < lastToLightX27; num7++)
                        {
                            lightColor = 0f;
                            lightColorG = 0f;
                            lightColorB = 0f;
                            dirX = 0;
                            dirY = 1;
                            for (int num8 = firstToLightY27; num8 < (lastTileY7 + maxRenderCount); num8++)
                            {
                                LightColor(num7, num8);
                                LightColorG(num7, num8);
                                LightColorB(num7, num8);
                            }
                            lightColor = 0f;
                            lightColorG = 0f;
                            lightColorB = 0f;
                            dirX = 0;
                            dirY = -1;
                            for (int num9 = lastToLightY27; num9 >= (firstTileY7 - maxRenderCount); num9--)
                            {
                                LightColor(num7, num9);
                                LightColorG(num7, num9);
                                LightColorB(num7, num9);
                            }
                        }
                        Main.lightTimer[3] = stopwatch.ElapsedMilliseconds;
                    }
                    if (Main.renderCount == 2)
                    {
                        stopwatch.Restart();
                        for (int num10 = firstToLightY27; num10 < lastToLightY27; num10++)
                        {
                            lightColor = 0f;
                            lightColorG = 0f;
                            lightColorB = 0f;
                            dirX = 1;
                            dirY = 0;
                            for (int num11 = firstToLightX27; num11 < (lastTileX7 + maxRenderCount); num11++)
                            {
                                LightColor(num11, num10);
                                LightColorG(num11, num10);
                                LightColorB(num11, num10);
                            }
                            lightColor = 0f;
                            lightColorG = 0f;
                            lightColorB = 0f;
                            dirX = -1;
                            dirY = 0;
                            for (int num12 = lastToLightX27; num12 >= (firstTileX7 - maxRenderCount); num12--)
                            {
                                LightColor(num12, num10);
                                LightColorG(num12, num10);
                                LightColorB(num12, num10);
                            }
                        }
                        Main.lightTimer[4] = stopwatch.ElapsedMilliseconds;
                    }
                }
            }
            else
            {
                negLight = 0.04f;
                negLight2 = 0.16f;
                if (Main.player[Main.myPlayer].nightVision)
                {
                    negLight -= 0.013f;
                    negLight2 -= 0.04f;
                }
                if (Main.player[Main.myPlayer].blind)
                {
                    negLight += 0.03f;
                    negLight2 += 0.06f;
                }
                wetLightR = negLight * 1.2f;
                wetLightG = negLight * 1.1f;
                if (RGB)
                {
                    if (Main.renderCount == 0)
                    {
                        stopwatch.Restart();
                        for (int num25 = minX7; num25 < maxX7; num25++)
                        {
                            lightColor = 0f;
                            lightColorG = 0f;
                            lightColorB = 0f;
                            dirX = 0;
                            dirY = 1;
                            for (int num26 = minY7; num26 < (lastToLightY27 + maxRenderCount); num26++)
                            {
                                LightColor2(num25, num26);
                                LightColorG2(num25, num26);
                                LightColorB2(num25, num26);
                            }
                            lightColor = 0f;
                            lightColorG = 0f;
                            lightColorB = 0f;
                            dirX = 0;
                            dirY = -1;
                            for (int num27 = maxY7; num27 >= (firstTileY7 - maxRenderCount); num27--)
                            {
                                LightColor2(num25, num27);
                                LightColorG2(num25, num27);
                                LightColorB2(num25, num27);
                            }
                        }
                        Main.lightTimer[1] = stopwatch.ElapsedMilliseconds;
                    }
                    if (Main.renderCount == 1)
                    {
                        stopwatch.Restart();
                        for (int num28 = firstToLightY7; num28 < lastToLightY7; num28++)
                        {
                            lightColor = 0f;
                            lightColorG = 0f;
                            lightColorB = 0f;
                            dirX = 1;
                            dirY = 0;
                            for (int num29 = minX7; num29 < (lastTileX7 + maxRenderCount); num29++)
                            {
                                LightColor2(num29, num28);
                                LightColorG2(num29, num28);
                                LightColorB2(num29, num28);
                            }
                            lightColor = 0f;
                            lightColorG = 0f;
                            lightColorB = 0f;
                            dirX = -1;
                            dirY = 0;
                            for (int num30 = maxX7; num30 >= (firstTileX7 - maxRenderCount); num30--)
                            {
                                LightColor2(num30, num28);
                                LightColorG2(num30, num28);
                                LightColorB2(num30, num28);
                            }
                        }
                        Main.lightTimer[2] = stopwatch.ElapsedMilliseconds;
                    }
                    if (Main.renderCount == 1)
                    {
                        stopwatch.Restart();
                        for (int num31 = firstToLightX27; num31 < lastToLightX27; num31++)
                        {
                            lightColor = 0f;
                            lightColorG = 0f;
                            lightColorB = 0f;
                            dirX = 0;
                            dirY = 1;
                            for (int num32 = firstToLightY27; num32 < (lastTileY7 + maxRenderCount); num32++)
                            {
                                LightColor2(num31, num32);
                                LightColorG2(num31, num32);
                                LightColorB2(num31, num32);
                            }
                            lightColor = 0f;
                            lightColorG = 0f;
                            lightColorB = 0f;
                            dirX = 0;
                            dirY = -1;
                            for (int num33 = lastToLightY27; num33 >= (firstTileY7 - maxRenderCount); num33--)
                            {
                                LightColor2(num31, num33);
                                LightColorG2(num31, num33);
                                LightColorB2(num31, num33);
                            }
                        }
                        Main.lightTimer[3] = stopwatch.ElapsedMilliseconds;
                    }
                    if (Main.renderCount == 2)
                    {
                        stopwatch.Restart();
                        for (int num34 = firstToLightY27; num34 < lastToLightY27; num34++)
                        {
                            lightColor = 0f;
                            lightColorG = 0f;
                            lightColorB = 0f;
                            dirX = 1;
                            dirY = 0;
                            for (int num35 = firstToLightX27; num35 < (lastTileX7 + maxRenderCount); num35++)
                            {
                                LightColor2(num35, num34);
                                LightColorG2(num35, num34);
                                LightColorB2(num35, num34);
                            }
                            lightColor = 0f;
                            lightColorG = 0f;
                            lightColorB = 0f;
                            dirX = -1;
                            dirY = 0;
                            for (int num36 = lastToLightX27; num36 >= (firstTileX7 - maxRenderCount); num36--)
                            {
                                LightColor2(num36, num34);
                                LightColorG2(num36, num34);
                                LightColorB2(num36, num34);
                            }
                        }
                        Main.lightTimer[4] = stopwatch.ElapsedMilliseconds;
                    }
                }
                else
                {
                    if (Main.renderCount == 0)
                    {
                        stopwatch.Restart();
                        for (int num37 = minX7; num37 < maxX7; num37++)
                        {
                            lightColor = 0f;
                            dirX = 0;
                            dirY = 1;
                            for (int num38 = minY7; num38 < (lastToLightY27 + maxRenderCount); num38++)
                            {
                                LightColor2(num37, num38);
                            }
                            lightColor = 0f;
                            dirX = 0;
                            dirY = -1;
                            for (int num39 = maxY7; num39 >= (firstTileY7 - maxRenderCount); num39--)
                            {
                                LightColor2(num37, num39);
                            }
                        }
                        Main.lightTimer[1] = stopwatch.ElapsedMilliseconds;
                    }
                    if (Main.renderCount == 1)
                    {
                        stopwatch.Restart();
                        for (int num40 = firstToLightY7; num40 < lastToLightY7; num40++)
                        {
                            lightColor = 0f;
                            dirX = 1;
                            dirY = 0;
                            for (int num41 = minX7; num41 < (lastTileX7 + maxRenderCount); num41++)
                            {
                                LightColor2(num41, num40);
                            }
                            lightColor = 0f;
                            dirX = -1;
                            dirY = 0;
                            for (int num42 = maxX7; num42 >= (firstTileX7 - maxRenderCount); num42--)
                            {
                                LightColor2(num42, num40);
                            }
                        }
                        Main.lightTimer[2] = stopwatch.ElapsedMilliseconds;
                    }
                    if (Main.renderCount == 1)
                    {
                        stopwatch.Restart();
                        for (int num43 = firstToLightX27; num43 < lastToLightX27; num43++)
                        {
                            lightColor = 0f;
                            dirX = 0;
                            dirY = 1;
                            for (int num44 = firstToLightY27; num44 < (lastTileY7 + maxRenderCount); num44++)
                            {
                                LightColor2(num43, num44);
                            }
                            lightColor = 0f;
                            dirX = 0;
                            dirY = -1;
                            for (int num45 = lastToLightY27; num45 >= (firstTileY7 - maxRenderCount); num45--)
                            {
                                LightColor2(num43, num45);
                            }
                        }
                        Main.lightTimer[3] = stopwatch.ElapsedMilliseconds;
                    }
                    if (Main.renderCount == 2)
                    {
                        stopwatch.Restart();
                        for (int num46 = firstToLightY27; num46 < lastToLightY27; num46++)
                        {
                            lightColor = 0f;
                            dirX = 1;
                            dirY = 0;
                            for (int num47 = firstToLightX27; num47 < (lastTileX7 + maxRenderCount); num47++)
                            {
                                LightColor2(num47, num46);
                            }
                            lightColor = 0f;
                            dirX = -1;
                            dirY = 0;
                            for (int num48 = lastToLightX27; num48 >= (firstTileX7 - maxRenderCount); num48--)
                            {
                                LightColor2(num48, num46);
                            }
                        }
                        Main.lightTimer[4] = stopwatch.ElapsedMilliseconds;
                    }
                }
            }
        }

        public static Color GetBlackness(int x, int y)
        {
            int num = (x - firstTileX) + offScreenTiles;
            int num2 = (y - firstTileY) + offScreenTiles;
            if (((num < 0) || (num2 < 0)) || ((num >= (((Main.screenWidth / 0x10) + (offScreenTiles * 2)) + 10)) || (num2 >= (((Main.screenHeight / 0x10) + (offScreenTiles * 2)) + 10))))
            {
                return Color.Black;
            }
            return new Color(0, 0, 0, (byte) (255f - (255f * color[num, num2])));
        }

        public static Color GetColor(int x, int y)
        {
            if (ZidoMod.fullbright) return ZidoMod.fullbrightcolor;//Tile brightness
            int num = (x - firstTileX) + offScreenTiles;
            int num2 = (y - firstTileY) + offScreenTiles;
            if (((num < 0) || (num2 < 0)) || ((num >= (((Main.screenWidth / 0x10) + (offScreenTiles * 2)) + 10)) || (num2 >= ((Main.screenHeight / 0x10) + (offScreenTiles * 2)))))
            {
                return Color.Black;
            }
            int num3 = (int) ((255f * color[num, num2]) * brightness);
            int num4 = (int) ((255f * colorG[num, num2]) * brightness);
            int num5 = (int) ((255f * colorB[num, num2]) * brightness);
            if (num3 > 0xff)
            {
                num3 = 0xff;
            }
            if (num4 > 0xff)
            {
                num4 = 0xff;
            }
            if (num5 > 0xff)
            {
                num5 = 0xff;
            }
            return new Color((byte) num3, (byte) num4, (byte) num5, 0xff);
        }

        public static Color GetColor(int x, int y, Color oldColor)
        {
            int num = (x - firstTileX) + offScreenTiles;
            int num2 = (y - firstTileY) + offScreenTiles;
            if (Main.gameMenu || ZidoMod.fullbright)//Player brightness
            {
                return oldColor;
            }

            if (((num < 0) || (num2 < 0)) || ((num >= (((Main.screenWidth / 0x10) + (offScreenTiles * 2)) + 10)) || (num2 >= (((Main.screenHeight / 0x10) + (offScreenTiles * 2)) + 10))))
            {
                return Color.Black;
            }
            Color white = Color.White;
            int num3 = (int) ((oldColor.R * color[num, num2]) * brightness);
            int num4 = (int) ((oldColor.G * colorG[num, num2]) * brightness);
            int num5 = (int) ((oldColor.B * colorB[num, num2]) * brightness);
            if (num3 > 0xff)
            {
                num3 = 0xff;
            }
            if (num4 > 0xff)
            {
                num4 = 0xff;
            }
            if (num5 > 0xff)
            {
                num5 = 0xff;
            }
            white.R = (byte) num3;
            white.G = (byte) num4;
            white.B = (byte) num5;
            return white;
        }

        private static void LightColor(int i, int j)
        {
            int num = i - firstToLightX7;
            int num2 = j - firstToLightY7;
            if (color2[num, num2] > lightColor)
            {
                lightColor = color2[num, num2];
            }
            else
            {
                if (lightColor <= 0.0185)
                {
                    return;
                }
                if (color2[num, num2] < lightColor)
                {
                    color2[num, num2] = lightColor;
                }
            }
            if (color2[num + dirX, num2 + dirY] <= lightColor)
            {
                if (stopLight[num, num2])
                {
                    lightColor *= negLight2;
                }
                else if (wetLight[num, num2])
                {
                    lightColor *= (wetLightR * Main.rand.Next(0x62, 100)) * 0.01f;
                }
                else
                {
                    lightColor *= negLight;
                }
            }
        }

        private static void LightColor2(int i, int j)
        {
            int num = i - firstToLightX7;
            int num2 = j - firstToLightY7;
            try
            {
                if (color2[num, num2] > lightColor)
                {
                    lightColor = color2[num, num2];
                }
                else
                {
                    if (lightColor <= 0f)
                    {
                        return;
                    }
                    color2[num, num2] = lightColor;
                }
                if (Main.tile[i, j].active && Main.tileBlockLight[Main.tile[i, j].type])
                {
                    lightColor -= negLight2;
                }
                else if (wetLight[num, num2])
                {
                    lightColor -= wetLightR;
                }
                else
                {
                    lightColor -= negLight;
                }
            }
            catch
            {
            }
        }

        private static void LightColorB(int i, int j)
        {
            int num = i - firstToLightX7;
            int num2 = j - firstToLightY7;
            if (colorB2[num, num2] > lightColorB)
            {
                lightColorB = colorB2[num, num2];
            }
            else
            {
                if (lightColorB <= 0.0185)
                {
                    return;
                }
                colorB2[num, num2] = lightColorB;
            }
            if (colorB2[num + dirX, num2 + dirY] < lightColorB)
            {
                if (stopLight[num, num2])
                {
                    lightColorB *= negLight2;
                }
                else
                {
                    lightColorB *= negLight;
                }
            }
        }

        private static void LightColorB2(int i, int j)
        {
            int num = i - firstToLightX7;
            int num2 = j - firstToLightY7;
            try
            {
                if (colorB2[num, num2] > lightColorB)
                {
                    lightColorB = colorB2[num, num2];
                }
                else
                {
                    if (lightColorB <= 0f)
                    {
                        return;
                    }
                    colorB2[num, num2] = lightColorB;
                }
                if (Main.tile[i, j].active && Main.tileBlockLight[Main.tile[i, j].type])
                {
                    lightColorB -= negLight2;
                }
                else
                {
                    lightColorB -= negLight;
                }
            }
            catch
            {
            }
        }

        private static void LightColorG(int i, int j)
        {
            int num = i - firstToLightX7;
            int num2 = j - firstToLightY7;
            if (colorG2[num, num2] > lightColorG)
            {
                lightColorG = colorG2[num, num2];
            }
            else
            {
                if (lightColorG <= 0.0185)
                {
                    return;
                }
                colorG2[num, num2] = lightColorG;
            }
            if (colorG2[num + dirX, num2 + dirY] <= lightColorG)
            {
                if (stopLight[num, num2])
                {
                    lightColorG *= negLight2;
                }
                else if (wetLight[num, num2])
                {
                    lightColorG *= (wetLightG * Main.rand.Next(0x61, 100)) * 0.01f;
                }
                else
                {
                    lightColorG *= negLight;
                }
            }
        }

        private static void LightColorG2(int i, int j)
        {
            int num = i - firstToLightX7;
            int num2 = j - firstToLightY7;
            try
            {
                if (colorG2[num, num2] > lightColorG)
                {
                    lightColorG = colorG2[num, num2];
                }
                else
                {
                    if (lightColorG <= 0f)
                    {
                        return;
                    }
                    colorG2[num, num2] = lightColorG;
                }
                if (Main.tile[i, j].active && Main.tileBlockLight[Main.tile[i, j].type])
                {
                    lightColorG -= negLight2;
                }
                else if (wetLight[num, num2])
                {
                    lightColorG -= wetLightG;
                }
                else
                {
                    lightColorG -= negLight;
                }
            }
            catch
            {
            }
        }

        public static int LightingX(int lightX)
        {
            if (lightX < 0)
            {
                return 0;
            }
            if (lightX >= (((Main.screenWidth / 0x10) + (offScreenTiles * 2)) + 10))
            {
                return ((((Main.screenWidth / 0x10) + (offScreenTiles * 2)) + 10) - 1);
            }
            return lightX;
        }

        public static int LightingY(int lightY)
        {
            if (lightY < 0)
            {
                return 0;
            }
            if (lightY >= (((Main.screenHeight / 0x10) + (offScreenTiles * 2)) + 10))
            {
                return ((((Main.screenHeight / 0x10) + (offScreenTiles * 2)) + 10) - 1);
            }
            return lightY;
        }

        public static void LightTiles(int firstX, int lastX, int firstY, int lastY)
        {
            Main.render = true;
            oldSkyColor = skyColor;
            skyColor = ((float) (((Main.tileColor.R + Main.tileColor.G) + Main.tileColor.B) / 3)) / 255f;
            if (lightMode < 2)
            {
                brightness = 1.2f;
                offScreenTiles2 = 0x22;
                offScreenTiles = 40;
            }
            else
            {
                brightness = 1f;
                offScreenTiles2 = 0x12;
                offScreenTiles = 0x17;
            }
            if (Main.player[Main.myPlayer].blind)
            {
                brightness = 1f;
            }
            defBrightness = brightness;
            firstTileX = firstX;
            lastTileX = lastX;
            firstTileY = firstY;
            lastTileY = lastY;
            Lighting.firstToLightX = firstTileX - offScreenTiles;
            Lighting.firstToLightY = firstTileY - offScreenTiles;
            Lighting.lastToLightX = lastTileX + offScreenTiles;
            Lighting.lastToLightY = lastTileY + offScreenTiles;
            if (Lighting.firstToLightX < 0)
            {
                Lighting.firstToLightX = 0;
            }
            if (Lighting.lastToLightX >= Main.maxTilesX)
            {
                Lighting.lastToLightX = Main.maxTilesX - 1;
            }
            if (Lighting.firstToLightY < 0)
            {
                Lighting.firstToLightY = 0;
            }
            if (Lighting.lastToLightY >= Main.maxTilesY)
            {
                Lighting.lastToLightY = Main.maxTilesY - 1;
            }
            int num = firstTileX - offScreenTiles2;
            int num2 = firstTileY - offScreenTiles2;
            int num3 = lastTileX + offScreenTiles2;
            int num4 = lastTileY + offScreenTiles2;
            if (num < 0)
            {
                num = 0;
            }
            if (num3 >= Main.maxTilesX)
            {
                num3 = Main.maxTilesX - 1;
            }
            if (num2 < 0)
            {
                num2 = 0;
            }
            if (num4 >= Main.maxTilesY)
            {
                num4 = Main.maxTilesY - 1;
            }
            lightCounter++;
            Main.renderCount++;
            int num5 = (Main.screenWidth / 0x10) + (offScreenTiles * 2);
            int num6 = (Main.screenHeight / 0x10) + (offScreenTiles * 2);
            Vector2 screenLastPosition = Main.screenLastPosition;
            doColors();
            if (Main.renderCount == 2)
            {
                screenLastPosition = Main.screenPosition;
                int num7 = ((int) (Main.screenPosition.X / 16f)) - scrX;
                int num8 = ((int) (Main.screenPosition.Y / 16f)) - scrY;
                if (num7 > 4)
                {
                    num7 = 0;
                }
                if (num8 > 4)
                {
                    num8 = 0;
                }
                if (RGB)
                {
                    for (int i = 0; i < num5; i++)
                    {
                        if ((i + num7) >= 0)
                        {
                            for (int j = 0; j < num6; j++)
                            {
                                if ((j + num8) >= 0)
                                {
                                    color[i, j] = color2[i + num7, j + num8];
                                    colorG[i, j] = colorG2[i + num7, j + num8];
                                    colorB[i, j] = colorB2[i + num7, j + num8];
                                }
                            }
                        }
                    }
                }
                else
                {
                    for (int k = 0; k < num5; k++)
                    {
                        if ((k + num7) >= 0)
                        {
                            for (int m = 0; m < num6; m++)
                            {
                                if ((m + num8) >= 0)
                                {
                                    color[k, m] = color2[k + num7, m + num8];
                                    colorG[k, m] = color2[k + num7, m + num8];
                                    colorB[k, m] = color2[k + num7, m + num8];
                                }
                            }
                        }
                    }
                }
            }
            if (((Main.renderCount != 2) && !resize) && !Main.renderNow)
            {
                if (Math.Abs((float) ((Main.screenPosition.X / 16f) - (screenLastPosition.X / 16f))) < 5f)
                {
                    while (((int) (Main.screenPosition.X / 16f)) < ((int) (screenLastPosition.X / 16f)))
                    {
                        screenLastPosition.X -= 16f;
                        for (int n = num5 - 1; n > 1; n--)
                        {
                            for (int num14 = 0; num14 < num6; num14++)
                            {
                                color[n, num14] = color[n - 1, num14];
                                colorG[n, num14] = colorG[n - 1, num14];
                                colorB[n, num14] = colorB[n - 1, num14];
                            }
                        }
                    }
                    while (((int) (Main.screenPosition.X / 16f)) > ((int) (screenLastPosition.X / 16f)))
                    {
                        screenLastPosition.X += 16f;
                        for (int num15 = 0; num15 < (num5 - 1); num15++)
                        {
                            for (int num16 = 0; num16 < num6; num16++)
                            {
                                color[num15, num16] = color[num15 + 1, num16];
                                colorG[num15, num16] = colorG[num15 + 1, num16];
                                colorB[num15, num16] = colorB[num15 + 1, num16];
                            }
                        }
                    }
                }
                if (Math.Abs((float) ((Main.screenPosition.Y / 16f) - (screenLastPosition.Y / 16f))) < 5f)
                {
                    while (((int) (Main.screenPosition.Y / 16f)) < ((int) (screenLastPosition.Y / 16f)))
                    {
                        screenLastPosition.Y -= 16f;
                        for (int num17 = num6 - 1; num17 > 1; num17--)
                        {
                            for (int num18 = 0; num18 < num5; num18++)
                            {
                                color[num18, num17] = color[num18, num17 - 1];
                                colorG[num18, num17] = colorG[num18, num17 - 1];
                                colorB[num18, num17] = colorB[num18, num17 - 1];
                            }
                        }
                    }
                    while (((int) (Main.screenPosition.Y / 16f)) > ((int) (screenLastPosition.Y / 16f)))
                    {
                        screenLastPosition.Y += 16f;
                        for (int num19 = 0; num19 < (num6 - 1); num19++)
                        {
                            for (int num20 = 0; num20 < (num5 - 1); num20++)
                            {
                                color[num20, num19] = color[num20, num19 + 1];
                                colorG[num20, num19] = colorG[num20, num19 + 1];
                                colorB[num20, num19] = colorB[num20, num19 + 1];
                            }
                        }
                    }
                }
                if (oldSkyColor != skyColor)
                {
                    for (int num21 = Lighting.firstToLightX; num21 < Lighting.lastToLightX; num21++)
                    {
                        for (int num22 = Lighting.firstToLightY; num22 < Lighting.lastToLightY; num22++)
                        {
                            if (Main.tile[num21, num22] == null)
                            {
                                Main.tile[num21, num22] = new Tile();
                            }
                            if (((!Main.tile[num21, num22].active || !Main.tileNoSunLight[Main.tile[num21, num22].type]) && ((color[num21 - Lighting.firstToLightX, num22 - Lighting.firstToLightY] < skyColor) && ((Main.tile[num21, num22].wall == 0) || (Main.tile[num21, num22].wall == 0x15)))) && ((num22 < Main.worldSurface) && (Main.tile[num21, num22].liquid < 200)))
                            {
                                if (color[num21 - Lighting.firstToLightX, num22 - Lighting.firstToLightY] < skyColor)
                                {
                                    color[num21 - Lighting.firstToLightX, num22 - Lighting.firstToLightY] = ((float) Main.tileColor.R) / 255f;
                                }
                                if (colorG[num21 - Lighting.firstToLightX, num22 - Lighting.firstToLightY] < skyColor)
                                {
                                    colorG[num21 - Lighting.firstToLightX, num22 - Lighting.firstToLightY] = ((float) Main.tileColor.G) / 255f;
                                }
                                if (colorB[num21 - Lighting.firstToLightX, num22 - Lighting.firstToLightY] < skyColor)
                                {
                                    colorB[num21 - Lighting.firstToLightX, num22 - Lighting.firstToLightY] = ((float) Main.tileColor.B) / 255f;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                lightCounter = 0;
            }
            if (Main.renderCount > maxRenderCount)
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                long elapsedMilliseconds = stopwatch.ElapsedMilliseconds;
                resize = false;
                Main.drawScene = true;
                ResetRange();
                if ((lightMode == 0) || (lightMode == 3))
                {
                    RGB = true;
                }
                else
                {
                    RGB = false;
                }

                int firstToLightX = 0;
                int lastToLightX = ((Main.screenWidth / 0x10) + (offScreenTiles * 2)) + 10;
                int firstToLightY = 0;
                int lastToLightY = ((Main.screenHeight / 0x10) + (offScreenTiles * 2)) + 10;
                for (int num27 = firstToLightX; num27 < lastToLightX; num27++)
                {
                    for (int num28 = firstToLightY; num28 < lastToLightY; num28++)
                    {
                        color2[num27, num28] = 0f;
                        colorG2[num27, num28] = 0f;
                        colorB2[num27, num28] = 0f;
                        stopLight[num27, num28] = false;
                        wetLight[num27, num28] = false;
                    }
                }
                for (int num29 = 0; num29 < tempLightCount; num29++)
                {
                    if (((((tempLightX[num29] - firstTileX) + offScreenTiles) >= 0) && (((tempLightX[num29] - firstTileX) + offScreenTiles) < (((Main.screenWidth / 0x10) + (offScreenTiles * 2)) + 10))) && ((((tempLightY[num29] - firstTileY) + offScreenTiles) >= 0) && (((tempLightY[num29] - firstTileY) + offScreenTiles) < (((Main.screenHeight / 0x10) + (offScreenTiles * 2)) + 10))))
                    {
                        int num30 = (tempLightX[num29] - firstTileX) + offScreenTiles;
                        int num31 = (tempLightY[num29] - firstTileY) + offScreenTiles;
                        if (color2[num30, num31] < tempLight[num29])
                        {
                            color2[num30, num31] = tempLight[num29];
                        }
                        if (colorG2[num30, num31] < tempLightG[num29])
                        {
                            colorG2[num30, num31] = tempLightG[num29];
                        }
                        if (colorB2[num30, num31] < tempLightB[num29])
                        {
                            colorB2[num30, num31] = tempLightB[num29];
                        }
                    }
                }
                if ((Main.wof >= 0) && Main.player[Main.myPlayer].gross)
                {
                    try
                    {
                        int num32 = (((int) Main.screenPosition.Y) / 0x10) - 10;
                        int num33 = ((((int) Main.screenPosition.Y) + Main.screenHeight) / 0x10) + 10;
                        int num34 = ((int) Main.npc[Main.wof].position.X) / 0x10;
                        if (Main.npc[Main.wof].direction > 0)
                        {
                            num34 -= 3;
                        }
                        else
                        {
                            num34 += 2;
                        }
                        int num35 = num34 + 8;
                        float num36 = (0.5f * Main.demonTorch) + (1f * (1f - Main.demonTorch));
                        float num37 = 0.3f;
                        float num38 = (1f * Main.demonTorch) + (0.5f * (1f - Main.demonTorch));
                        num36 *= 0.2f;
                        num37 *= 0.1f;
                        num38 *= 0.3f;
                        for (int num39 = num34; num39 <= num35; num39++)
                        {
                            for (int num40 = num32; num40 <= num33; num40++)
                            {
                                if (color2[num39 - Lighting.firstToLightX, num40 - Lighting.firstToLightY] < num36)
                                {
                                    color2[num39 - Lighting.firstToLightX, num40 - Lighting.firstToLightY] = num36;
                                }
                                if (colorG2[num39 - Lighting.firstToLightX, num40 - Lighting.firstToLightY] < num37)
                                {
                                    colorG2[num39 - Lighting.firstToLightX, num40 - Lighting.firstToLightY] = num37;
                                }
                                if (colorB2[num39 - Lighting.firstToLightX, num40 - Lighting.firstToLightY] < num38)
                                {
                                    colorB2[num39 - Lighting.firstToLightX, num40 - Lighting.firstToLightY] = num38;
                                }
                            }
                        }
                    }
                    catch
                    {
                    }
                }
                if (!Main.renderNow)
                {
                    Main.oldTempLightCount = tempLightCount;
                    tempLightCount = 0;
                }
                if (Main.gamePaused)
                {
                    tempLightCount = Main.oldTempLightCount;
                }
                Main.sandTiles = 0;
                Main.evilTiles = 0;
                Main.holyTiles = 0;
                Main.meteorTiles = 0;
                Main.jungleTiles = 0;
                Main.dungeonTiles = 0;
                Main.musicBox = -1;
                firstToLightX = Lighting.firstToLightX;
                lastToLightX = Lighting.lastToLightX;
                firstToLightY = Lighting.firstToLightY;
                lastToLightY = Lighting.lastToLightY;
                for (int num41 = firstToLightX; num41 < lastToLightX; num41++)
                {
                    for (int num42 = firstToLightY; num42 < lastToLightY; num42++)
                    {
                        if (Main.tile[num41, num42] == null)
                        {
                            Main.tile[num41, num42] = new Tile();
                        }
                        if (((!Main.tile[num41, num42].active || !Main.tileNoSunLight[Main.tile[num41, num42].type]) && ((color2[num41 - Lighting.firstToLightX, num42 - Lighting.firstToLightY] < skyColor) && ((Main.tile[num41, num42].wall == 0) || (Main.tile[num41, num42].wall == 0x15)))) && ((num42 < Main.worldSurface) && (Main.tile[num41, num42].liquid < 200)))
                        {
                            if (color2[num41 - Lighting.firstToLightX, num42 - Lighting.firstToLightY] < skyColor)
                            {
                                color2[num41 - Lighting.firstToLightX, num42 - Lighting.firstToLightY] = ((float) Main.tileColor.R) / 255f;
                            }
                            if (colorG2[num41 - Lighting.firstToLightX, num42 - Lighting.firstToLightY] < skyColor)
                            {
                                colorG2[num41 - Lighting.firstToLightX, num42 - Lighting.firstToLightY] = ((float) Main.tileColor.G) / 255f;
                            }
                            if (colorB2[num41 - Lighting.firstToLightX, num42 - Lighting.firstToLightY] < skyColor)
                            {
                                colorB2[num41 - Lighting.firstToLightX, num42 - Lighting.firstToLightY] = ((float) Main.tileColor.B) / 255f;
                            }
                        }
                    }
                }
                for (int num43 = firstToLightX; num43 < lastToLightX; num43++)
                {
                    for (int num44 = firstToLightY; num44 < lastToLightY; num44++)
                    {
                        float num53;
                        float num57;
                        float num58;
                        int num59;
                        float num62;
                        int num45 = num43 - Lighting.firstToLightX;
                        int num46 = num44 - Lighting.firstToLightY;
                        if (Main.tile[num43, num44] == null)
                        {
                            Main.tile[num43, num44] = new Tile();
                        }
                        int zoneX = Main.zoneX;
                        int zoneY = Main.zoneY;
                        int num49 = ((lastToLightX - firstToLightX) - zoneX) / 2;
                        int num50 = ((lastToLightY - firstToLightY) - zoneY) / 2;
                        if (!Main.tile[num43, num44].active)
                        {
                            goto Label_2B7C;
                        }
                        if (((num43 > (firstToLightX + num49)) && (num43 < (lastToLightX - num49))) && ((num44 > (firstToLightY + num50)) && (num44 < (lastToLightY - num50))))
                        {
                            switch (Main.tile[num43, num44].type)
                            {
                                case 0x29:
                                case 0x2b:
                                case 0x2c:
                                    Main.dungeonTiles++;
                                    goto Label_1203;

                                case 0x2a:
                                case 0x1a:
                                case 0x6f:
                                case 0x72:
                                case 0x73:
                                    goto Label_1203;

                                case 0x25:
                                    Main.meteorTiles++;
                                    goto Label_1203;

                                case 0x17:
                                case 0x18:
                                case 0x19:
                                case 0x20:
                                    goto Label_1112;

                                case 0x1b:
                                    Main.evilTiles -= 5;
                                    goto Label_1203;

                                case 60:
                                case 0x3d:
                                case 0x3e:
                                case 0x54:
                                    goto Label_119B;

                                case 0x35:
                                    goto Label_11A9;

                                case 0x6d:
                                case 110:
                                case 0x71:
                                case 0x75:
                                    Main.holyTiles++;
                                    goto Label_1203;

                                case 0x70:
                                    Main.sandTiles++;
                                    Main.evilTiles++;
                                    goto Label_1203;

                                case 0x74:
                                    Main.sandTiles++;
                                    Main.holyTiles++;
                                    goto Label_1203;

                                case 0x8b:
                                    if (Main.tile[num43, num44].frameX >= 0x24)
                                    {
                                        int num51 = 0;
                                        for (int num52 = Main.tile[num43, num44].frameY / 0x12; num52 >= 2; num52 -= 2)
                                        {
                                            num51++;
                                        }
                                        Main.musicBox = num51;
                                    }
                                    goto Label_1203;
                            }
                        }
                        goto Label_1203;
                    Label_1112:
                        Main.evilTiles++;
                        goto Label_1203;
                    Label_119B:
                        Main.jungleTiles++;
                        goto Label_1203;
                    Label_11A9:
                        Main.sandTiles++;
                    Label_1203:
                        if (Main.tileBlockLight[Main.tile[num43, num44].type] && (Main.tile[num43, num44].type != 0x83))
                        {
                            stopLight[num45, num46] = true;
                        }
                        if (Main.tileLighted[Main.tile[num43, num44].type])
                        {
                            if (!RGB)
                            {
                                goto Label_2549;
                            }
                            switch (Main.tile[num43, num44].type)
                            {
                                case 4:
                                    goto Label_15D8;

                                case 0x11:
                                case 0x85:
                                    goto Label_1ADC;

                                case 0x16:
                                case 140:
                                    goto Label_1C6B;

                                case 0x31:
                                    if (color2[num45, num46] < 0.3f)
                                    {
                                        color2[num45, num46] = 0.3f;
                                    }
                                    if (colorG2[num45, num46] < 0.3f)
                                    {
                                        colorG2[num45, num46] = 0.3f;
                                    }
                                    if (colorB2[num45, num46] < 0.75f)
                                    {
                                        colorB2[num45, num46] = 0.75f;
                                    }
                                    goto Label_2B7C;

                                case 0x3d:
                                    if (Main.tile[num43, num44].frameX == 0x90)
                                    {
                                        if (color2[num45, num46] < 0.42f)
                                        {
                                            color2[num45, num46] = 0.42f;
                                        }
                                        if (colorG2[num45, num46] < 0.81f)
                                        {
                                            colorG2[num45, num46] = 0.81f;
                                        }
                                        if (colorB2[num45, num46] < 0.52f)
                                        {
                                            colorB2[num45, num46] = 0.52f;
                                        }
                                    }
                                    goto Label_2B7C;

                                case 0x1a:
                                case 0x1f:
                                    goto Label_1F78;

                                case 0x1b:
                                case 0x1c:
                                case 0x1d:
                                case 30:
                                case 0x20:
                                case 0x5e:
                                case 0x60:
                                case 0x61:
                                case 0x63:
                                case 0x7f:
                                case 0x80:
                                    goto Label_2B7C;

                                case 0x21:
                                    goto Label_17AA;

                                case 0x22:
                                case 0x23:
                                    goto Label_1994;

                                case 0x24:
                                    goto Label_184C;

                                case 0x25:
                                    goto Label_1BDC;

                                case 0x2a:
                                    goto Label_1CFA;

                                case 70:
                                case 0x47:
                                case 0x48:
                                    goto Label_1E12;

                                case 0x4d:
                                    goto Label_1B5C;

                                case 0x53:
                                    goto Label_21A7;

                                case 0x54:
                                    goto Label_2029;

                                case 0x5c:
                                    goto Label_13CA;

                                case 0x5d:
                                    goto Label_147C;

                                case 0x5f:
                                    goto Label_1A38;

                                case 0x62:
                                    goto Label_1536;

                                case 100:
                                    goto Label_18F0;

                                case 0x7d:
                                    goto Label_231E;

                                case 0x7e:
                                    goto Label_225A;

                                case 0x81:
                                    goto Label_23BC;
                            }
                        }
                        goto Label_2B7C;
                    Label_13CA:
                        if ((Main.tile[num43, num44].frameY <= 0x12) && (Main.tile[num43, num44].frameX == 0))
                        {
                            if (color2[num45, num46] < 1f)
                            {
                                color2[num45, num46] = 1f;
                            }
                            if (colorG2[num45, num46] < 1f)
                            {
                                colorG2[num45, num46] = 1f;
                            }
                            if (colorB2[num45, num46] < 1f)
                            {
                                colorB2[num45, num46] = 1f;
                            }
                        }
                        goto Label_2B7C;
                    Label_147C:
                        if ((Main.tile[num43, num44].frameY == 0) && (Main.tile[num43, num44].frameX == 0))
                        {
                            if (color2[num45, num46] < 1f)
                            {
                                color2[num45, num46] = 1f;
                            }
                            if (colorG2[num45, num46] < 0.97)
                            {
                                colorG2[num45, num46] = 0.97f;
                            }
                            if (colorB2[num45, num46] < 0.85)
                            {
                                colorB2[num45, num46] = 0.85f;
                            }
                        }
                        goto Label_2B7C;
                    Label_1536:
                        if (Main.tile[num43, num44].frameY == 0)
                        {
                            if (color2[num45, num46] < 1f)
                            {
                                color2[num45, num46] = 1f;
                            }
                            if (colorG2[num45, num46] < 0.97)
                            {
                                colorG2[num45, num46] = 0.97f;
                            }
                            if (colorB2[num45, num46] < 0.85)
                            {
                                colorB2[num45, num46] = 0.85f;
                            }
                        }
                        goto Label_2B7C;
                    Label_15D8:
                        num53 = 1f;
                        float num54 = 0.95f;
                        float num55 = 0.8f;
                        if (Main.tile[num43, num44].frameX < 0x42)
                        {
                            switch ((Main.tile[num43, num44].frameY / 0x16))
                            {
                                case 1:
                                    num53 = 0f;
                                    num54 = 0.1f;
                                    num55 = 1.3f;
                                    break;

                                case 2:
                                    num53 = 1f;
                                    num54 = 0.1f;
                                    num55 = 0.1f;
                                    break;

                                case 3:
                                    num53 = 0f;
                                    num54 = 1f;
                                    num55 = 0.1f;
                                    break;

                                case 4:
                                    num53 = 0.9f;
                                    num54 = 0f;
                                    num55 = 0.9f;
                                    break;

                                case 5:
                                    num53 = 1.3f;
                                    num54 = 1.3f;
                                    num55 = 1.3f;
                                    break;

                                case 6:
                                    num53 = 0.9f;
                                    num54 = 0.9f;
                                    num55 = 0f;
                                    break;

                                case 7:
                                    num53 = (0.5f * Main.demonTorch) + (1f * (1f - Main.demonTorch));
                                    num54 = 0.3f;
                                    num55 = (1f * Main.demonTorch) + (0.5f * (1f - Main.demonTorch));
                                    break;

                                case 8:
                                    num55 = 0.7f;
                                    num53 = 0.85f;
                                    num54 = 1f;
                                    break;
                            }
                            if (color2[num45, num46] < num53)
                            {
                                color2[num45, num46] = num53;
                            }
                            if (colorG2[num45, num46] < num54)
                            {
                                colorG2[num45, num46] = num54;
                            }
                            if (colorB2[num45, num46] < num55)
                            {
                                colorB2[num45, num46] = num55;
                            }
                        }
                        goto Label_2B7C;
                    Label_17AA:
                        if (Main.tile[num43, num44].frameX == 0)
                        {
                            if (color2[num45, num46] < 1f)
                            {
                                color2[num45, num46] = 1f;
                            }
                            if (colorG2[num45, num46] < 0.95)
                            {
                                colorG2[num45, num46] = 0.95f;
                            }
                            if (colorB2[num45, num46] < 0.65)
                            {
                                colorB2[num45, num46] = 0.65f;
                            }
                        }
                        goto Label_2B7C;
                    Label_184C:
                        if (Main.tile[num43, num44].frameX < 0x36)
                        {
                            if (color2[num45, num46] < 1f)
                            {
                                color2[num45, num46] = 1f;
                            }
                            if (colorG2[num45, num46] < 0.95)
                            {
                                colorG2[num45, num46] = 0.95f;
                            }
                            if (colorB2[num45, num46] < 0.65)
                            {
                                colorB2[num45, num46] = 0.65f;
                            }
                        }
                        goto Label_2B7C;
                    Label_18F0:
                        if (Main.tile[num43, num44].frameX < 0x24)
                        {
                            if (color2[num45, num46] < 1f)
                            {
                                color2[num45, num46] = 1f;
                            }
                            if (colorG2[num45, num46] < 0.95)
                            {
                                colorG2[num45, num46] = 0.95f;
                            }
                            if (colorB2[num45, num46] < 0.65)
                            {
                                colorB2[num45, num46] = 0.65f;
                            }
                        }
                        goto Label_2B7C;
                    Label_1994:
                        if (Main.tile[num43, num44].frameX < 0x36)
                        {
                            if (color2[num45, num46] < 1f)
                            {
                                color2[num45, num46] = 1f;
                            }
                            if (colorG2[num45, num46] < 0.95)
                            {
                                colorG2[num45, num46] = 0.95f;
                            }
                            if (colorB2[num45, num46] < 0.8)
                            {
                                colorB2[num45, num46] = 0.8f;
                            }
                        }
                        goto Label_2B7C;
                    Label_1A38:
                        if (Main.tile[num43, num44].frameX < 0x24)
                        {
                            if (color2[num45, num46] < 1f)
                            {
                                color2[num45, num46] = 1f;
                            }
                            if (colorG2[num45, num46] < 0.95)
                            {
                                colorG2[num45, num46] = 0.95f;
                            }
                            if (colorB2[num45, num46] < 0.8)
                            {
                                colorB2[num45, num46] = 0.8f;
                            }
                        }
                        goto Label_2B7C;
                    Label_1ADC:
                        if (color2[num45, num46] < 0.83f)
                        {
                            color2[num45, num46] = 0.83f;
                        }
                        if (colorG2[num45, num46] < 0.6f)
                        {
                            colorG2[num45, num46] = 0.6f;
                        }
                        if (colorB2[num45, num46] < 0.5f)
                        {
                            colorB2[num45, num46] = 0.5f;
                        }
                        goto Label_2B7C;
                    Label_1B5C:
                        if (color2[num45, num46] < 0.75f)
                        {
                            color2[num45, num46] = 0.75f;
                        }
                        if (colorG2[num45, num46] < 0.45f)
                        {
                            colorG2[num45, num46] = 0.45f;
                        }
                        if (colorB2[num45, num46] < 0.25f)
                        {
                            colorB2[num45, num46] = 0.25f;
                        }
                        goto Label_2B7C;
                    Label_1BDC:
                        if (color2[num45, num46] < 0.56)
                        {
                            color2[num45, num46] = 0.56f;
                        }
                        if (colorG2[num45, num46] < 0.43)
                        {
                            colorG2[num45, num46] = 0.43f;
                        }
                        if (colorB2[num45, num46] < 0.15)
                        {
                            colorB2[num45, num46] = 0.15f;
                        }
                        goto Label_2B7C;
                    Label_1C6B:
                        if (color2[num45, num46] < 0.12)
                        {
                            color2[num45, num46] = 0.12f;
                        }
                        if (colorG2[num45, num46] < 0.07)
                        {
                            colorG2[num45, num46] = 0.07f;
                        }
                        if (colorB2[num45, num46] < 0.32)
                        {
                            colorB2[num45, num46] = 0.32f;
                        }
                        goto Label_2B7C;
                    Label_1CFA:
                        if (Main.tile[num43, num44].frameX == 0)
                        {
                            if (color2[num45, num46] < 0.65f)
                            {
                                color2[num45, num46] = 0.65f;
                            }
                            if (colorG2[num45, num46] < 0.8f)
                            {
                                colorG2[num45, num46] = 0.8f;
                            }
                            if (colorB2[num45, num46] < 0.54f)
                            {
                                colorB2[num45, num46] = 0.54f;
                            }
                        }
                        goto Label_2B7C;
                    Label_1E12:
                        num57 = Main.rand.Next(0x1c, 0x2a) * 0.005f;
                        num57 += ((float) (270 - Main.mouseTextColor)) / 500f;
                        if (color2[num45, num46] < (0.1f + num57))
                        {
                            color2[num45, num46] = 0.1f;
                        }
                        if (colorG2[num45, num46] < (0.3f + (num57 / 2f)))
                        {
                            colorG2[num45, num46] = 0.3f + (num57 / 2f);
                        }
                        if (colorB2[num45, num46] < (0.6f + num57))
                        {
                            colorB2[num45, num46] = 0.6f + num57;
                        }
                        goto Label_2B7C;
                    Label_1F78:
                        num58 = Main.rand.Next(-5, 6) * 0.0025f;
                        if (color2[num45, num46] < (0.31f + num58))
                        {
                            color2[num45, num46] = 0.31f + num58;
                        }
                        if (colorG2[num45, num46] < (0.1f + num58))
                        {
                            colorG2[num45, num46] = 0.1f;
                        }
                        if (colorB2[num45, num46] < (0.44f + (num58 * 2f)))
                        {
                            colorB2[num45, num46] = 0.44f + (num58 * 2f);
                        }
                        goto Label_2B7C;
                    Label_2029:
                        num59 = Main.tile[num43, num44].frameX / 0x12;
                        float num60 = 0f;
                        switch (num59)
                        {
                            case 2:
                            {
                                float num61 = 270 - Main.mouseTextColor;
                                num61 /= 800f;
                                if (num61 > 1f)
                                {
                                    num61 = 1f;
                                }
                                if (num61 < 0f)
                                {
                                    num61 = 0f;
                                }
                                num60 = num61;
                                if (color2[num45, num46] < (num60 * 0.7f))
                                {
                                    color2[num45, num46] = num60 * 0.7f;
                                }
                                if (colorG2[num45, num46] < num60)
                                {
                                    colorG2[num45, num46] = num60;
                                }
                                if (colorB2[num45, num46] < (num60 * 0.1f))
                                {
                                    colorB2[num45, num46] = num60 * 0.1f;
                                }
                                goto Label_2B7C;
                            }
                            case 5:
                                num60 = 0.9f;
                                if (color2[num45, num46] < num60)
                                {
                                    color2[num45, num46] = num60;
                                }
                                if (colorG2[num45, num46] < (num60 * 0.8f))
                                {
                                    colorG2[num45, num46] = num60 * 0.8f;
                                }
                                if (colorB2[num45, num46] < (num60 * 0.2f))
                                {
                                    colorB2[num45, num46] = num60 * 0.2f;
                                }
                                break;
                        }
                        goto Label_2B7C;
                    Label_21A7:
                        if ((Main.tile[num43, num44].frameX == 0x12) && !Main.dayTime)
                        {
                            if (color2[num45, num46] < 0.1)
                            {
                                color2[num45, num46] = 0.1f;
                            }
                            if (colorG2[num45, num46] < 0.4)
                            {
                                colorG2[num45, num46] = 0.4f;
                            }
                            if (colorB2[num45, num46] < 0.6)
                            {
                                colorB2[num45, num46] = 0.6f;
                            }
                        }
                        goto Label_2B7C;
                    Label_225A:
                        if (Main.tile[num43, num44].frameX < 0x24)
                        {
                            if (color2[num45, num46] < (((float) Main.DiscoR) / 255f))
                            {
                                color2[num45, num46] = ((float) Main.DiscoR) / 255f;
                            }
                            if (colorG2[num45, num46] < (((float) Main.DiscoG) / 255f))
                            {
                                colorG2[num45, num46] = ((float) Main.DiscoG) / 255f;
                            }
                            if (colorB2[num45, num46] < (((float) Main.DiscoB) / 255f))
                            {
                                colorB2[num45, num46] = ((float) Main.DiscoB) / 255f;
                            }
                        }
                        goto Label_2B7C;
                    Label_231E:
                        num62 = Main.rand.Next(0x1c, 0x2a) * 0.01f;
                        num62 += ((float) (270 - Main.mouseTextColor)) / 800f;
                        if (colorG2[num45, num46] < (0.1 * num62))
                        {
                            colorG2[num45, num46] = 0.3f * num62;
                        }
                        if (colorB2[num45, num46] < (0.3 * num62))
                        {
                            colorB2[num45, num46] = 0.6f * num62;
                        }
                        goto Label_2B7C;
                    Label_23BC:
                        if (((Main.tile[num43, num44].frameX == 0) || (Main.tile[num43, num44].frameX == 0x36)) || (Main.tile[num43, num44].frameX == 0x6c))
                        {
                            num54 = 0.05f;
                            num55 = 0.25f;
                            num53 = 0f;
                        }
                        else if (((Main.tile[num43, num44].frameX == 0x12) || (Main.tile[num43, num44].frameX == 0x48)) || (Main.tile[num43, num44].frameX == 0x7e))
                        {
                            num53 = 0.2f;
                            num55 = 0.15f;
                            num54 = 0f;
                        }
                        else
                        {
                            num55 = 0.2f;
                            num53 = 0.1f;
                            num54 = 0f;
                        }
                        if (color2[num45, num46] < num53)
                        {
                            color2[num45, num46] = (num53 * Main.rand.Next(970, 0x407)) * 0.001f;
                        }
                        if (colorG2[num45, num46] < num54)
                        {
                            colorG2[num45, num46] = (num54 * Main.rand.Next(970, 0x407)) * 0.001f;
                        }
                        if (colorB2[num45, num46] < num55)
                        {
                            colorB2[num45, num46] = (num55 * Main.rand.Next(970, 0x407)) * 0.001f;
                        }
                        goto Label_2B7C;
                    Label_2549:
                        switch (Main.tile[num43, num44].type)
                        {
                            case 0x1a:
                            case 0x1f:
                            {
                                float num64 = Main.rand.Next(-5, 6) * 0.01f;
                                if (color2[num45, num46] < (0.4f + num64))
                                {
                                    color2[num45, num46] = 0.4f + num64;
                                }
                                goto Label_2B7C;
                            }
                            case 0x1b:
                            case 0x1c:
                            case 0x1d:
                            case 30:
                            case 0x20:
                            case 0x5e:
                            case 0x60:
                            case 0x61:
                            case 0x63:
                                goto Label_2B7C;

                            case 0x21:
                                if (Main.tile[num43, num44].frameX == 0)
                                {
                                    color2[num45, num46] = 1f;
                                }
                                goto Label_2B7C;

                            case 0x22:
                            case 0x23:
                            case 0x24:
                                if (Main.tile[num43, num44].frameX < 0x36)
                                {
                                    color2[num45, num46] = 1f;
                                }
                                goto Label_2B7C;

                            case 0x25:
                                if (color2[num45, num46] < 0.5f)
                                {
                                    color2[num45, num46] = 0.5f;
                                }
                                goto Label_2B7C;

                            case 0x2a:
                                if (Main.tile[num43, num44].frameX == 0)
                                {
                                    color2[num45, num46] = 0.75f;
                                }
                                goto Label_2B7C;

                            case 0x31:
                                if (color2[num45, num46] < 0.1f)
                                {
                                    color2[num45, num46] = 0.7f;
                                }
                                goto Label_2B7C;

                            case 4:
                                if (Main.tile[num43, num44].frameX < 0x42)
                                {
                                    color2[num45, num46] = 1f;
                                }
                                goto Label_2B7C;

                            case 0x11:
                            case 0x85:
                                if (color2[num45, num46] < 0.75f)
                                {
                                    color2[num45, num46] = 0.75f;
                                }
                                goto Label_2B7C;

                            case 0x16:
                                if (color2[num45, num46] < 0.2f)
                                {
                                    color2[num45, num46] = 0.2f;
                                }
                                goto Label_2B7C;

                            case 70:
                            case 0x47:
                            case 0x48:
                            {
                                float num63 = Main.rand.Next(0x26, 0x2b) * 0.01f;
                                if (color2[num45, num46] < num63)
                                {
                                    color2[num45, num46] = num63;
                                }
                                goto Label_2B7C;
                            }
                            case 0x4d:
                                if (color2[num45, num46] < 0.6f)
                                {
                                    color2[num45, num46] = 0.6f;
                                }
                                goto Label_2B7C;

                            case 0x3d:
                                if ((Main.tile[num43, num44].frameX == 0x90) && (color2[num45, num46] < 0.75f))
                                {
                                    color2[num45, num46] = 0.75f;
                                }
                                goto Label_2B7C;

                            case 0x7d:
                            {
                                float num68 = Main.rand.Next(0x1c, 0x2a) * 0.007f;
                                num68 += ((float) (270 - Main.mouseTextColor)) / 900f;
                                if (color2[num45, num46] < (0.5 * num68))
                                {
                                    color2[num45, num46] = 0.3f * num68;
                                }
                                goto Label_2B7C;
                            }
                            case 0x7e:
                                if ((Main.tile[num43, num44].frameX < 0x24) && (color2[num45, num46] < 0.3f))
                                {
                                    color2[num45, num46] = 0.3f;
                                }
                                goto Label_2B7C;

                            case 0x5c:
                                if ((Main.tile[num43, num44].frameY <= 0x12) && (Main.tile[num43, num44].frameX == 0))
                                {
                                    color2[num45, num46] = 1f;
                                }
                                goto Label_2B7C;

                            case 0x5d:
                                if ((Main.tile[num43, num44].frameY == 0) && (Main.tile[num43, num44].frameX == 0))
                                {
                                    color2[num45, num46] = 1f;
                                }
                                goto Label_2B7C;

                            case 0x5f:
                                if ((Main.tile[num43, num44].frameX < 0x24) && (color2[num45, num46] < 0.85f))
                                {
                                    color2[num45, num46] = 0.9f;
                                }
                                goto Label_2B7C;

                            case 0x62:
                                if (Main.tile[num43, num44].frameY == 0)
                                {
                                    color2[num45, num46] = 1f;
                                }
                                goto Label_2B7C;

                            case 100:
                                if (Main.tile[num43, num44].frameX < 0x24)
                                {
                                    color2[num45, num46] = 1f;
                                }
                                goto Label_2B7C;

                            case 0x54:
                            {
                                int num65 = Main.tile[num43, num44].frameX / 0x12;
                                float num66 = 0f;
                                switch (num65)
                                {
                                    case 2:
                                    {
                                        float num67 = 270 - Main.mouseTextColor;
                                        num67 /= 500f;
                                        if (num67 > 1f)
                                        {
                                            num67 = 1f;
                                        }
                                        if (num67 < 0f)
                                        {
                                            num67 = 0f;
                                        }
                                        num66 = num67;
                                        break;
                                    }
                                    case 5:
                                        num66 = 0.7f;
                                        break;
                                }
                                if (color2[num45, num46] < num66)
                                {
                                    color2[num45, num46] = num66;
                                }
                                goto Label_2B7C;
                            }
                        }
                    Label_2B7C:
                        if (Main.tile[num43, num44].lava && (Main.tile[num43, num44].liquid > 0))
                        {
                            if (RGB)
                            {
                                float num69 = ((Main.tile[num43, num44].liquid / 0xff) * 0.41f) + 0.14f;
                                num69 = 0.55f;
                                num69 += ((float) (270 - Main.mouseTextColor)) / 900f;
                                if (color2[num45, num46] < num69)
                                {
                                    color2[num45, num46] = num69;
                                }
                                if (colorG2[num45, num46] < num69)
                                {
                                    colorG2[num45, num46] = num69 * 0.6f;
                                }
                                if (colorB2[num45, num46] < num69)
                                {
                                    colorB2[num45, num46] = num69 * 0.2f;
                                }
                            }
                            else
                            {
                                float num70 = ((Main.tile[num43, num44].liquid / 0xff) * 0.38f) + 0.08f;
                                num70 += ((float) (270 - Main.mouseTextColor)) / 2000f;
                                if (color2[num45, num46] < num70)
                                {
                                    color2[num45, num46] = num70;
                                }
                            }
                        }
                        else if (Main.tile[num43, num44].liquid > 0x80)
                        {
                            wetLight[num45, num46] = true;
                        }
                        if (RGB)
                        {
                            if (((color2[num45, num46] > 0f) || (colorG2[num45, num46] > 0f)) || (colorB2[num45, num46] > 0f))
                            {
                                if (minX > num45)
                                {
                                    minX = num45;
                                }
                                if (maxX < (num45 + 1))
                                {
                                    maxX = num45 + 1;
                                }
                                if (minY > num46)
                                {
                                    minY = num46;
                                }
                                if (maxY < (num46 + 1))
                                {
                                    maxY = num46 + 1;
                                }
                            }
                        }
                        else if (color2[num45, num46] > 0f)
                        {
                            if (minX > num45)
                            {
                                minX = num45;
                            }
                            if (maxX < (num45 + 1))
                            {
                                maxX = num45 + 1;
                            }
                            if (minY > num46)
                            {
                                minY = num46;
                            }
                            if (maxY < (num46 + 1))
                            {
                                maxY = num46 + 1;
                            }
                        }
                    }
                }
                if (Main.holyTiles < 0)
                {
                    Main.holyTiles = 0;
                }
                if (Main.evilTiles < 0)
                {
                    Main.evilTiles = 0;
                }
                int holyTiles = Main.holyTiles;
                Main.holyTiles -= Main.evilTiles;
                Main.evilTiles -= holyTiles;
                if (Main.holyTiles < 0)
                {
                    Main.holyTiles = 0;
                }
                if (Main.evilTiles < 0)
                {
                    Main.evilTiles = 0;
                }
                minX += Lighting.firstToLightX;
                maxX += Lighting.firstToLightX;
                minY += Lighting.firstToLightY;
                maxY += Lighting.firstToLightY;
                minX7 = minX;
                maxX7 = maxX;
                minY7 = minY;
                maxY7 = maxY;
                firstTileX7 = firstTileX;
                lastTileX7 = lastTileX;
                lastTileY7 = lastTileY;
                firstTileY7 = firstTileY;
                firstToLightX7 = Lighting.firstToLightX;
                lastToLightX7 = Lighting.lastToLightX;
                firstToLightY7 = Lighting.firstToLightY;
                lastToLightY7 = Lighting.lastToLightY;
                firstToLightX27 = num;
                lastToLightX27 = num3;
                firstToLightY27 = num2;
                lastToLightY27 = num4;
                scrX = ((int) Main.screenPosition.X) / 0x10;
                scrY = ((int) Main.screenPosition.Y) / 0x10;
                Main.renderCount = 0;
                Main.lightTimer[0] = stopwatch.ElapsedMilliseconds;
                doColors();
            }
        }

        private static void ResetRange()
        {
            minX = (Main.screenWidth + (offScreenTiles * 2)) + 10;
            maxX = 0;
            minY = (Main.screenHeight + (offScreenTiles * 2)) + 10;
            maxY = 0;
        }
    }
}

