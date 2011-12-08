namespace Terraria
{
    using Microsoft.Xna.Framework;
    using System;

    public class Cloud
    {
        public bool active;
        public int height;
        public Vector2 position;
        private static Random rand = new Random();
        public float rotation;
        public float rSpeed;
        public float scale;
        public float sSpeed;
        public int type;
        public int width;

        public static void addCloud()
        {
            int index = -1;
            for (int i = 0; i < 100; i++)
            {
                if (!Main.cloud[i].active)
                {
                    index = i;
                    break;
                }
            }
            if (index >= 0)
            {
                Main.cloud[index].rSpeed = 0f;
                Main.cloud[index].sSpeed = 0f;
                Main.cloud[index].type = rand.Next(4);
                Main.cloud[index].scale = rand.Next(70, 0x83) * 0.01f;
                Main.cloud[index].rotation = rand.Next(-10, 11) * 0.01f;
                Main.cloud[index].width = (int) (Main.cloudTexture[Main.cloud[index].type].Width * Main.cloud[index].scale);
                Main.cloud[index].height = (int) (Main.cloudTexture[Main.cloud[index].type].Height * Main.cloud[index].scale);
                float windSpeed = Main.windSpeed;
                if (!Main.gameMenu)
                {
                    windSpeed = Main.windSpeed - (Main.player[Main.myPlayer].velocity.X * 0.1f);
                }
                if (windSpeed > 0f)
                {
                    Main.cloud[index].position.X = (-Main.cloud[index].width - Main.cloudTexture[Main.cloud[index].type].Width) - rand.Next(Main.screenWidth * 2);
                }
                else
                {
                    Main.cloud[index].position.X = (Main.screenWidth + Main.cloudTexture[Main.cloud[index].type].Width) + rand.Next(Main.screenWidth * 2);
                }
                Main.cloud[index].position.Y = rand.Next((int) (-Main.screenHeight * 0.25f), (int) (Main.screenHeight * 0.25f));
                Main.cloud[index].position.Y -= rand.Next((int) (Main.screenHeight * 0.15f));
                Main.cloud[index].position.Y -= rand.Next((int) (Main.screenHeight * 0.15f));
                if (Main.cloud[index].scale > 1.3)
                {
                    Main.cloud[index].scale = 1.3f;
                }
                if (Main.cloud[index].scale < 0.7)
                {
                    Main.cloud[index].scale = 0.7f;
                }
                Main.cloud[index].active = true;
                Rectangle rectangle = new Rectangle((int) Main.cloud[index].position.X, (int) Main.cloud[index].position.Y, Main.cloud[index].width, Main.cloud[index].height);
                for (int j = 0; j < 100; j++)
                {
                    if ((index != j) && Main.cloud[j].active)
                    {
                        Rectangle rectangle2 = new Rectangle((int) Main.cloud[j].position.X, (int) Main.cloud[j].position.Y, Main.cloud[j].width, Main.cloud[j].height);
                        if (rectangle.Intersects(rectangle2))
                        {
                            Main.cloud[index].active = false;
                        }
                    }
                }
            }
        }

        public object Clone()
        {
            return base.MemberwiseClone();
        }

        public Color cloudColor(Color bgColor)
        {
            float num = (this.scale - 0.4f) * 0.9f;
            float num2 = 1.1f;
            float num3 = 255f - ((0xff - bgColor.R) * num2);
            float num4 = 255f - ((0xff - bgColor.G) * num2);
            float num5 = 255f - ((0xff - bgColor.B) * num2);
            float num6 = 255f;
            num3 *= num;
            num4 *= num;
            num5 *= num;
            num6 *= num;
            if (num3 < 0f)
            {
                num3 = 0f;
            }
            if (num4 < 0f)
            {
                num4 = 0f;
            }
            if (num5 < 0f)
            {
                num5 = 0f;
            }
            if (num6 < 0f)
            {
                num6 = 0f;
            }
            return new Color((byte) num3, (byte) num4, (byte) num5, (byte) num6);
        }

        public static void resetClouds()
        {
            if (Main.cloudLimit >= 10)
            {
                Main.numClouds = rand.Next(10, Main.cloudLimit);
                Main.windSpeed = 0f;
                while (Main.windSpeed == 0f)
                {
                    Main.windSpeed = rand.Next(-100, 0x65) * 0.01f;
                }
                for (int i = 0; i < 100; i++)
                {
                    Main.cloud[i].active = false;
                }
                for (int j = 0; j < Main.numClouds; j++)
                {
                    addCloud();
                }
                for (int k = 0; k < Main.numClouds; k++)
                {
                    if (Main.windSpeed < 0f)
                    {
                        Main.cloud[k].position.X -= Main.screenWidth * 2;
                    }
                    else
                    {
                        Main.cloud[k].position.X += Main.screenWidth * 2;
                    }
                }
            }
        }

        public void Update()
        {
            if (Main.gameMenu)
            {
                this.position.X += (Main.windSpeed * this.scale) * 3f;
            }
            else
            {
                float num = Main.player[Main.myPlayer].velocity.X * 0.18f;
                num = (Main.screenPosition.X - Main.screenLastPosition.X) * 0.18f;
                if (Main.player[Main.myPlayer].dead)
                {
                    num = 0f;
                }
                this.position.X += (Main.windSpeed - num) * this.scale;
            }
            if (Main.windSpeed > 0f)
            {
                if ((this.position.X - Main.cloudTexture[this.type].Width) > (Main.screenWidth + 200))
                {
                    this.active = false;
                }
            }
            else if (((this.position.X + this.width) + Main.cloudTexture[this.type].Width) < -200f)
            {
                this.active = false;
            }
            this.rSpeed += rand.Next(-10, 11) * 2E-05f;
            if (this.rSpeed > 0.0007)
            {
                this.rSpeed = 0.0007f;
            }
            if (this.rSpeed < -0.0007)
            {
                this.rSpeed = -0.0007f;
            }
            if (this.rotation > 0.05)
            {
                this.rotation = 0.05f;
            }
            if (this.rotation < -0.05)
            {
                this.rotation = -0.05f;
            }
            this.rotation += this.rSpeed;
            this.width = (int) (Main.cloudTexture[this.type].Width * this.scale);
            this.height = (int) (Main.cloudTexture[this.type].Height * this.scale);
        }

        public static void UpdateClouds()
        {
            int num = 0;
            for (int i = 0; i < 100; i++)
            {
                if (Main.cloud[i].active)
                {
                    Main.cloud[i].rotation = 0f;
                    Main.cloud[i].Update();
                    num++;
                }
            }
            for (int j = 0; j < 100; j++)
            {
                if (Main.cloud[j].active)
                {
                    if ((j > 1) && (!Main.cloud[j - 1].active || (Main.cloud[j - 1].scale > (Main.cloud[j].scale + 0.02))))
                    {
                        Cloud cloud = (Cloud) Main.cloud[j - 1].Clone();
                        Main.cloud[j - 1] = (Cloud) Main.cloud[j].Clone();
                        Main.cloud[j] = cloud;
                    }
                    if ((j < 0x63) && (!Main.cloud[j].active || (Main.cloud[j + 1].scale < (Main.cloud[j].scale - 0.02))))
                    {
                        Cloud cloud2 = (Cloud) Main.cloud[j + 1].Clone();
                        Main.cloud[j + 1] = (Cloud) Main.cloud[j].Clone();
                        Main.cloud[j] = cloud2;
                    }
                }
            }
            if (num < Main.numClouds)
            {
                addCloud();
            }
        }
    }
}

