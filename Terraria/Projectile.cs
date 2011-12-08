namespace Terraria
{
    using Microsoft.Xna.Framework;
    using System;
    using System.Runtime.InteropServices;

    public class Projectile
    {
        public bool active;
        public static int maxAI = 2;
        public float[] ai = new float[maxAI];
        public int aiStyle;
        public int alpha;
        public int damage;
        public int direction;
        public int frame;
        public int frameCounter;
        public bool friendly;
        public int height;
        public bool hide;
        public bool hostile;
        public int identity;
        public bool ignoreWater;
        public float knockBack;
        public Vector2 lastPosition;
        public bool lavaWet;
        public float light;
        public float[] localAI = new float[maxAI];
        public bool magic;
        public int maxUpdates;
        public bool melee;
        public string miscText = "";
        public string name = "";
        public int netSpam;
        public bool netUpdate;
        public bool netUpdate2;
        public int numUpdates;
        public Vector2[] oldPos = new Vector2[10];
        public int owner = 0xff;
        public bool ownerHitCheck;
        public int penetrate = 1;
        public int[] playerImmune = new int[0xff];
        public Vector2 position;
        public bool ranged;
        public int restrikeDelay;
        public float rotation;
        public float scale = 1f;
        public int soundDelay;
        public int spriteDirection = 1;
        public bool tileCollide;
        public int timeLeft;
        public int type;
        public Vector2 velocity;
        public bool wet;
        public byte wetCount;
        public int whoAmI;
        public int width;

        public void AI()
        {
            Color color;
            if (this.aiStyle == 1)
            {
                if ((this.type == 0x53) && (this.ai[1] == 0f))
                {
                    this.ai[1] = 1f;
                    Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 0x21);
                }
                if ((this.type == 0x54) && (this.ai[1] == 0f))
                {
                    this.ai[1] = 1f;
                    Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 12);
                }
                if ((this.type == 100) && (this.ai[1] == 0f))
                {
                    this.ai[1] = 1f;
                    Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 0x21);
                }
                if ((this.type == 0x62) && (this.ai[1] == 0f))
                {
                    this.ai[1] = 1f;
                    Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 0x11);
                }
                if (((this.type == 0x51) || (this.type == 0x52)) && (this.ai[1] == 0f))
                {
                    Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 5);
                    this.ai[1] = 1f;
                }
                if (this.type == 0x29)
                {
                    color = new Color();
                    int index = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0x1f, 0f, 0f, 100, color, 1.6f);
                    Main.dust[index].noGravity = true;
                    index = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, new Color(), 2f);
                    Main.dust[index].noGravity = true;
                }
                else if (this.type == 0x37)
                {
                    int num2 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0x12, 0f, 0f, 0, new Color(), 0.9f);
                    Main.dust[num2].noGravity = true;
                }
                else if ((this.type == 0x5b) && (Main.rand.Next(2) == 0))
                {
                    int num3;
                    if (Main.rand.Next(2) == 0)
                    {
                        num3 = 15;
                    }
                    else
                    {
                        num3 = 0x3a;
                    }
                    int num4 = Dust.NewDust(this.position, this.width, this.height, num3, this.velocity.X * 0.25f, this.velocity.Y * 0.25f, 150, new Color(), 0.9f);
                    Dust dust1 = Main.dust[num4];
                    dust1.velocity = (Vector2) (dust1.velocity * 0.25f);
                }
                if ((((this.type == 20) || (this.type == 14)) || ((this.type == 0x24) || (this.type == 0x53))) || (((this.type == 0x54) || (this.type == 0x59)) || ((this.type == 100) || (this.type == 0x68))))
                {
                    if (this.alpha > 0)
                    {
                        this.alpha -= 15;
                    }
                    if (this.alpha < 0)
                    {
                        this.alpha = 0;
                    }
                }
                if (this.type == 0x58)
                {
                    if (this.alpha > 0)
                    {
                        this.alpha -= 10;
                    }
                    if (this.alpha < 0)
                    {
                        this.alpha = 0;
                    }
                }
                if (((((this.type != 5) && (this.type != 14)) && ((this.type != 20) && (this.type != 0x24))) && (((this.type != 0x26) && (this.type != 0x37)) && ((this.type != 0x53) && (this.type != 0x54)))) && ((((this.type != 0x58) && (this.type != 0x59)) && ((this.type != 0x62) && (this.type != 100))) && (this.type != 0x68)))
                {
                    this.ai[0]++;
                }
                if ((this.type == 0x51) || (this.type == 0x5b))
                {
                    if (this.ai[0] >= 20f)
                    {
                        this.ai[0] = 20f;
                        this.velocity.Y += 0.07f;
                    }
                }
                else if (this.ai[0] >= 15f)
                {
                    this.ai[0] = 15f;
                    this.velocity.Y += 0.1f;
                }
                this.rotation = ((float) Math.Atan2((double) this.velocity.Y, (double) this.velocity.X)) + 1.57f;
                if (this.velocity.Y > 16f)
                {
                    this.velocity.Y = 16f;
                }
            }
            else if (this.aiStyle == 2)
            {
                if ((this.type == 0x5d) && (Main.rand.Next(5) == 0))
                {
                    color = new Color();
                    int num5 = Dust.NewDust(this.position, this.width, this.height, 0x39, (this.velocity.X * 0.2f) + (this.direction * 3), this.velocity.Y * 0.2f, 100, color, 0.3f);
                    Main.dust[num5].velocity.X *= 0.3f;
                    Main.dust[num5].velocity.Y *= 0.3f;
                }
                this.rotation += ((Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y)) * 0.03f) * this.direction;
                if ((this.type == 0x45) || (this.type == 70))
                {
                    this.ai[0]++;
                    if (this.ai[0] >= 10f)
                    {
                        this.velocity.Y += 0.25f;
                        this.velocity.X *= 0.99f;
                    }
                }
                else
                {
                    this.ai[0]++;
                    if (this.ai[0] >= 20f)
                    {
                        this.velocity.Y += 0.4f;
                        this.velocity.X *= 0.97f;
                    }
                    else if (((this.type == 0x30) || (this.type == 0x36)) || (this.type == 0x5d))
                    {
                        this.rotation = ((float) Math.Atan2((double) this.velocity.Y, (double) this.velocity.X)) + 1.57f;
                    }
                }
                if (this.velocity.Y > 16f)
                {
                    this.velocity.Y = 16f;
                }
                if ((this.type == 0x36) && (Main.rand.Next(20) == 0))
                {
                    Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 40, this.velocity.X * 0.1f, this.velocity.Y * 0.1f, 0, new Color(), 0.75f);
                }
            }
            else if (this.aiStyle != 3)
            {
                if (this.aiStyle == 4)
                {
                    this.rotation = ((float) Math.Atan2((double) this.velocity.Y, (double) this.velocity.X)) + 1.57f;
                    if (this.ai[0] != 0f)
                    {
                        if ((this.alpha < 170) && ((this.alpha + 5) >= 170))
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                color = new Color();
                                Dust.NewDust(this.position, this.width, this.height, 0x12, this.velocity.X * 0.025f, this.velocity.Y * 0.025f, 170, color, 1.2f);
                            }
                            Dust.NewDust(this.position, this.width, this.height, 14, 0f, 0f, 170, new Color(), 1.1f);
                        }
                        this.alpha += 5;
                        if (this.alpha >= 0xff)
                        {
                            this.Kill();
                        }
                    }
                    else
                    {
                        this.alpha -= 50;
                        if (this.alpha <= 0)
                        {
                            this.alpha = 0;
                            this.ai[0] = 1f;
                            if (this.ai[1] == 0f)
                            {
                                this.ai[1]++;
                                this.position += (Vector2) (this.velocity * 1f);
                            }
                            if ((this.type == 7) && (Main.myPlayer == this.owner))
                            {
                                int type = this.type;
                                if (this.ai[1] >= 6f)
                                {
                                    type++;
                                }
                                int num16 = NewProjectile((this.position.X + this.velocity.X) + (this.width / 2), (this.position.Y + this.velocity.Y) + (this.height / 2), this.velocity.X, this.velocity.Y, type, this.damage, this.knockBack, this.owner);
                                Main.projectile[num16].damage = this.damage;
                                Main.projectile[num16].ai[1] = this.ai[1] + 1f;
                                NetMessage.SendData(0x1b, -1, -1, "", num16, 0f, 0f, 0f, 0);
                            }
                        }
                    }
                }
                else if (this.aiStyle == 5)
                {
                    if (this.type == 0x5c)
                    {
                        if (this.position.Y > this.ai[1])
                        {
                            this.tileCollide = true;
                        }
                    }
                    else
                    {
                        if ((this.ai[1] == 0f) && !Collision.SolidCollision(this.position, this.width, this.height))
                        {
                            this.ai[1] = 1f;
                            this.netUpdate = true;
                        }
                        if (this.ai[1] != 0f)
                        {
                            this.tileCollide = true;
                        }
                    }
                    if (this.soundDelay == 0)
                    {
                        this.soundDelay = 20 + Main.rand.Next(40);
                        Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 9);
                    }
                    if (this.localAI[0] == 0f)
                    {
                        this.localAI[0] = 1f;
                    }
                    this.alpha += (int) (25f * this.localAI[0]);
                    if (this.alpha > 200)
                    {
                        this.alpha = 200;
                        this.localAI[0] = -1f;
                    }
                    if (this.alpha < 0)
                    {
                        this.alpha = 0;
                        this.localAI[0] = 1f;
                    }
                    this.rotation += ((Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y)) * 0.01f) * this.direction;
                    if ((this.ai[1] == 1f) || (this.type == 0x5c))
                    {
                        this.light = 0.9f;
                        if (Main.rand.Next(10) == 0)
                        {
                            Dust.NewDust(this.position, this.width, this.height, 0x3a, this.velocity.X * 0.5f, this.velocity.Y * 0.5f, 150, new Color(), 1.2f);
                        }
                        if (Main.rand.Next(20) == 0)
                        {
                            Gore.NewGore(this.position, new Vector2(this.velocity.X * 0.2f, this.velocity.Y * 0.2f), Main.rand.Next(0x10, 0x12), 1f);
                        }
                    }
                }
                else if (this.aiStyle == 6)
                {
                    this.velocity = (Vector2) (this.velocity * 0.95f);
                    this.ai[0]++;
                    if (this.ai[0] == 180f)
                    {
                        this.Kill();
                    }
                    if (this.ai[1] == 0f)
                    {
                        this.ai[1] = 1f;
                        for (int j = 0; j < 30; j++)
                        {
                            color = new Color();
                            Dust.NewDust(this.position, this.width, this.height, 10 + this.type, this.velocity.X, this.velocity.Y, 50, color, 1f);
                        }
                    }
                    if ((this.type == 10) || (this.type == 11))
                    {
                        int num19 = ((int) (this.position.X / 16f)) - 1;
                        int maxTilesX = ((int) ((this.position.X + this.width) / 16f)) + 2;
                        int num21 = ((int) (this.position.Y / 16f)) - 1;
                        int maxTilesY = ((int) ((this.position.Y + this.height) / 16f)) + 2;
                        if (num19 < 0)
                        {
                            num19 = 0;
                        }
                        if (maxTilesX > Main.maxTilesX)
                        {
                            maxTilesX = Main.maxTilesX;
                        }
                        if (num21 < 0)
                        {
                            num21 = 0;
                        }
                        if (maxTilesY > Main.maxTilesY)
                        {
                            maxTilesY = Main.maxTilesY;
                        }
                        for (int k = num19; k < maxTilesX; k++)
                        {
                            for (int m = num21; m < maxTilesY; m++)
                            {
                                Vector2 vector2;
                                vector2.X = k * 0x10;
                                vector2.Y = m * 0x10;
                                if (((((this.position.X + this.width) > vector2.X) && (this.position.X < (vector2.X + 16f))) && (((this.position.Y + this.height) > vector2.Y) && (this.position.Y < (vector2.Y + 16f)))) && ((Main.myPlayer == this.owner) && Main.tile[k, m].active))
                                {
                                    if (this.type == 10)
                                    {
                                        if (Main.tile[k, m].type == 0x17)
                                        {
                                            Main.tile[k, m].type = 2;
                                            WorldGen.SquareTileFrame(k, m, true);
                                            if (Main.netMode == 1)
                                            {
                                                NetMessage.SendTileSquare(-1, k, m, 1);
                                            }
                                        }
                                        if (Main.tile[k, m].type == 0x19)
                                        {
                                            Main.tile[k, m].type = 1;
                                            WorldGen.SquareTileFrame(k, m, true);
                                            if (Main.netMode == 1)
                                            {
                                                NetMessage.SendTileSquare(-1, k, m, 1);
                                            }
                                        }
                                        if (Main.tile[k, m].type == 0x70)
                                        {
                                            Main.tile[k, m].type = 0x35;
                                            WorldGen.SquareTileFrame(k, m, true);
                                            if (Main.netMode == 1)
                                            {
                                                NetMessage.SendTileSquare(-1, k, m, 1);
                                            }
                                        }
                                    }
                                    else if (this.type == 11)
                                    {
                                        if (Main.tile[k, m].type == 0x6d)
                                        {
                                            Main.tile[k, m].type = 2;
                                            WorldGen.SquareTileFrame(k, m, true);
                                            if (Main.netMode == 1)
                                            {
                                                NetMessage.SendTileSquare(-1, k, m, 1);
                                            }
                                        }
                                        if (Main.tile[k, m].type == 0x74)
                                        {
                                            Main.tile[k, m].type = 0x35;
                                            WorldGen.SquareTileFrame(k, m, true);
                                            if (Main.netMode == 1)
                                            {
                                                NetMessage.SendTileSquare(-1, k, m, 1);
                                            }
                                        }
                                        if (Main.tile[k, m].type == 0x75)
                                        {
                                            Main.tile[k, m].type = 1;
                                            WorldGen.SquareTileFrame(k, m, true);
                                            if (Main.netMode == 1)
                                            {
                                                NetMessage.SendTileSquare(-1, k, m, 1);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else if (this.aiStyle == 7)
                {
                    if (Main.player[this.owner].dead)
                    {
                        this.Kill();
                    }
                    else
                    {
                        Vector2 vector3 = new Vector2(this.position.X + (this.width * 0.5f), this.position.Y + (this.height * 0.5f));
                        float num25 = (Main.player[this.owner].position.X + (Main.player[this.owner].width / 2)) - vector3.X;
                        float num26 = (Main.player[this.owner].position.Y + (Main.player[this.owner].height / 2)) - vector3.Y;
                        float num27 = (float) Math.Sqrt((double) ((num25 * num25) + (num26 * num26)));
                        this.rotation = ((float) Math.Atan2((double) num26, (double) num25)) - 1.57f;
                        if (this.ai[0] == 0f)
                        {
                            if ((((num27 > 300f) && (this.type == 13)) || ((num27 > 400f) && (this.type == 0x20))) || (((num27 > 440f) && (this.type == 0x49)) || ((num27 > 440f) && (this.type == 0x4a))))
                            {
                                this.ai[0] = 1f;
                            }
                            int num28 = ((int) (this.position.X / 16f)) - 1;
                            int num29 = ((int) ((this.position.X + this.width) / 16f)) + 2;
                            int num30 = ((int) (this.position.Y / 16f)) - 1;
                            int num31 = ((int) ((this.position.Y + this.height) / 16f)) + 2;
                            if (num28 < 0)
                            {
                                num28 = 0;
                            }
                            if (num29 > Main.maxTilesX)
                            {
                                num29 = Main.maxTilesX;
                            }
                            if (num30 < 0)
                            {
                                num30 = 0;
                            }
                            if (num31 > Main.maxTilesY)
                            {
                                num31 = Main.maxTilesY;
                            }
                            for (int n = num28; n < num29; n++)
                            {
                                for (int num33 = num30; num33 < num31; num33++)
                                {
                                    Vector2 vector4;
                                    if (Main.tile[n, num33] == null)
                                    {
                                        Main.tile[n, num33] = new Tile();
                                    }
                                    vector4.X = n * 0x10;
                                    vector4.Y = num33 * 0x10;
                                    if (((((this.position.X + this.width) > vector4.X) && (this.position.X < (vector4.X + 16f))) && (((this.position.Y + this.height) > vector4.Y) && (this.position.Y < (vector4.Y + 16f)))) && (Main.tile[n, num33].active && Main.tileSolid[Main.tile[n, num33].type]))
                                    {
                                        if (Main.player[this.owner].grapCount < 10)
                                        {
                                            Main.player[this.owner].grappling[Main.player[this.owner].grapCount] = this.whoAmI;
                                            Player player1 = Main.player[this.owner];
                                            player1.grapCount++;
                                        }
                                        if (Main.myPlayer == this.owner)
                                        {
                                            int num34 = 0;
                                            int num35 = -1;
                                            int timeLeft = 0x186a0;
                                            if ((this.type == 0x49) || (this.type == 0x4a))
                                            {
                                                for (int num37 = 0; num37 < 0x3e8; num37++)
                                                {
                                                    if ((((num37 != this.whoAmI) && Main.projectile[num37].active) && ((Main.projectile[num37].owner == this.owner) && (Main.projectile[num37].aiStyle == 7))) && (Main.projectile[num37].ai[0] == 2f))
                                                    {
                                                        Main.projectile[num37].Kill();
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                for (int num38 = 0; num38 < 0x3e8; num38++)
                                                {
                                                    if ((Main.projectile[num38].active && (Main.projectile[num38].owner == this.owner)) && (Main.projectile[num38].aiStyle == 7))
                                                    {
                                                        if (Main.projectile[num38].timeLeft < timeLeft)
                                                        {
                                                            num35 = num38;
                                                            timeLeft = Main.projectile[num38].timeLeft;
                                                        }
                                                        num34++;
                                                    }
                                                }
                                                if (num34 > 3)
                                                {
                                                    Main.projectile[num35].Kill();
                                                }
                                            }
                                        }
                                        WorldGen.KillTile(n, num33, true, true, false);
                                        Main.PlaySound(0, n * 0x10, num33 * 0x10, 1);
                                        this.velocity.X = 0f;
                                        this.velocity.Y = 0f;
                                        this.ai[0] = 2f;
                                        this.position.X = ((n * 0x10) + 8) - (this.width / 2);
                                        this.position.Y = ((num33 * 0x10) + 8) - (this.height / 2);
                                        this.damage = 0;
                                        this.netUpdate = true;
                                        if (Main.myPlayer == this.owner)
                                        {
                                            NetMessage.SendData(13, -1, -1, "", this.owner, 0f, 0f, 0f, 0);
                                        }
                                        break;
                                    }
                                }
                                if (this.ai[0] == 2f)
                                {
                                    return;
                                }
                            }
                        }
                        else if (this.ai[0] == 1f)
                        {
                            float num39 = 11f;
                            if (this.type == 0x20)
                            {
                                num39 = 15f;
                            }
                            if ((this.type == 0x49) || (this.type == 0x4a))
                            {
                                num39 = 17f;
                            }
                            if (num27 < 24f)
                            {
                                this.Kill();
                            }
                            num27 = num39 / num27;
                            num25 *= num27;
                            num26 *= num27;
                            this.velocity.X = num25;
                            this.velocity.Y = num26;
                        }
                        else if (this.ai[0] == 2f)
                        {
                            int num40 = ((int) (this.position.X / 16f)) - 1;
                            int num41 = ((int) ((this.position.X + this.width) / 16f)) + 2;
                            int num42 = ((int) (this.position.Y / 16f)) - 1;
                            int num43 = ((int) ((this.position.Y + this.height) / 16f)) + 2;
                            if (num40 < 0)
                            {
                                num40 = 0;
                            }
                            if (num41 > Main.maxTilesX)
                            {
                                num41 = Main.maxTilesX;
                            }
                            if (num42 < 0)
                            {
                                num42 = 0;
                            }
                            if (num43 > Main.maxTilesY)
                            {
                                num43 = Main.maxTilesY;
                            }
                            bool flag = true;
                            for (int num44 = num40; num44 < num41; num44++)
                            {
                                for (int num45 = num42; num45 < num43; num45++)
                                {
                                    Vector2 vector5;
                                    if (Main.tile[num44, num45] == null)
                                    {
                                        Main.tile[num44, num45] = new Tile();
                                    }
                                    vector5.X = num44 * 0x10;
                                    vector5.Y = num45 * 0x10;
                                    if (((((this.position.X + (this.width / 2)) > vector5.X) && ((this.position.X + (this.width / 2)) < (vector5.X + 16f))) && (((this.position.Y + (this.height / 2)) > vector5.Y) && ((this.position.Y + (this.height / 2)) < (vector5.Y + 16f)))) && (Main.tile[num44, num45].active && Main.tileSolid[Main.tile[num44, num45].type]))
                                    {
                                        flag = false;
                                    }
                                }
                            }
                            if (flag)
                            {
                                this.ai[0] = 1f;
                            }
                            else if (Main.player[this.owner].grapCount < 10)
                            {
                                Main.player[this.owner].grappling[Main.player[this.owner].grapCount] = this.whoAmI;
                                Player player2 = Main.player[this.owner];
                                player2.grapCount++;
                            }
                        }
                    }
                }
                else if (this.aiStyle == 8)
                {
                    if ((this.type == 0x60) && (this.localAI[0] == 0f))
                    {
                        this.localAI[0] = 1f;
                        Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 20);
                    }
                    if (this.type == 0x1b)
                    {
                        color = new Color();
                        int num46 = Dust.NewDust(new Vector2(this.position.X + this.velocity.X, this.position.Y + this.velocity.Y), this.width, this.height, 0x1d, this.velocity.X, this.velocity.Y, 100, color, 3f);
                        Main.dust[num46].noGravity = true;
                        if (Main.rand.Next(10) == 0)
                        {
                            num46 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0x1d, this.velocity.X, this.velocity.Y, 100, new Color(), 1.4f);
                        }
                    }
                    else if ((this.type == 0x5f) || (this.type == 0x60))
                    {
                        int num47 = Dust.NewDust(new Vector2(this.position.X + this.velocity.X, this.position.Y + this.velocity.Y), this.width, this.height, 0x4b, this.velocity.X, this.velocity.Y, 100, new Color(), 3f * this.scale);
                        Main.dust[num47].noGravity = true;
                    }
                    else
                    {
                        for (int num48 = 0; num48 < 2; num48++)
                        {
                            color = new Color();
                            int num49 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, this.velocity.X * 0.2f, this.velocity.Y * 0.2f, 100, color, 2f);
                            Main.dust[num49].noGravity = true;
                            Main.dust[num49].velocity.X *= 0.3f;
                            Main.dust[num49].velocity.Y *= 0.3f;
                        }
                    }
                    if ((this.type != 0x1b) && (this.type != 0x60))
                    {
                        this.ai[1]++;
                    }
                    if (this.ai[1] >= 20f)
                    {
                        this.velocity.Y += 0.2f;
                    }
                    this.rotation += 0.3f * this.direction;
                    if (this.velocity.Y > 16f)
                    {
                        this.velocity.Y = 16f;
                    }
                }
                else if (this.aiStyle == 9)
                {
                    if (this.type == 0x22)
                    {
                        color = new Color();
                        int num50 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, this.velocity.X * 0.2f, this.velocity.Y * 0.2f, 100, color, 3.5f);
                        Main.dust[num50].noGravity = true;
                        Dust dust2 = Main.dust[num50];
                        dust2.velocity = (Vector2) (dust2.velocity * 1.4f);
                        num50 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, this.velocity.X * 0.2f, this.velocity.Y * 0.2f, 100, new Color(), 1.5f);
                    }
                    else if (this.type == 0x4f)
                    {
                        if ((this.soundDelay == 0) && ((Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y)) > 2f))
                        {
                            this.soundDelay = 10;
                            Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 9);
                        }
                        for (int num51 = 0; num51 < 1; num51++)
                        {
                            int num52 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0x42, 0f, 0f, 100, new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB), 2.5f);
                            Dust dust3 = Main.dust[num52];
                            dust3.velocity = (Vector2) (dust3.velocity * 0.1f);
                            Dust dust4 = Main.dust[num52];
                            dust4.velocity += (Vector2) (this.velocity * 0.2f);
                            Main.dust[num52].position.X = ((this.position.X + (this.width / 2)) + 4f) + Main.rand.Next(-2, 3);
                            Main.dust[num52].position.Y = (this.position.Y + (this.height / 2)) + Main.rand.Next(-2, 3);
                            Main.dust[num52].noGravity = true;
                        }
                    }
                    else
                    {
                        if ((this.soundDelay == 0) && ((Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y)) > 2f))
                        {
                            this.soundDelay = 10;
                            Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 9);
                        }
                        int num53 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 15, 0f, 0f, 100, new Color(), 2f);
                        Dust dust5 = Main.dust[num53];
                        dust5.velocity = (Vector2) (dust5.velocity * 0.3f);
                        Main.dust[num53].position.X = ((this.position.X + (this.width / 2)) + 4f) + Main.rand.Next(-4, 5);
                        Main.dust[num53].position.Y = (this.position.Y + (this.height / 2)) + Main.rand.Next(-4, 5);
                        Main.dust[num53].noGravity = true;
                    }
                    if ((Main.myPlayer == this.owner) && (this.ai[0] == 0f))
                    {
                        if (Main.player[this.owner].channel)
                        {
                            float num54 = 12f;
                            if (this.type == 0x10)
                            {
                                num54 = 15f;
                            }
                            Vector2 vector6 = new Vector2(this.position.X + (this.width * 0.5f), this.position.Y + (this.height * 0.5f));
                            float num55 = (Main.mouseX + Main.screenPosition.X) - vector6.X;
                            float num56 = (Main.mouseY + Main.screenPosition.Y) - vector6.Y;
                            float num57 = (float) Math.Sqrt((double) ((num55 * num55) + (num56 * num56)));
                            num57 = (float) Math.Sqrt((double) ((num55 * num55) + (num56 * num56)));
                            if (num57 > num54)
                            {
                                num57 = num54 / num57;
                                num55 *= num57;
                                num56 *= num57;
                                int num58 = (int) (num55 * 1000f);
                                int num59 = (int) (this.velocity.X * 1000f);
                                int num60 = (int) (num56 * 1000f);
                                int num61 = (int) (this.velocity.Y * 1000f);
                                if ((num58 != num59) || (num60 != num61))
                                {
                                    this.netUpdate = true;
                                }
                                this.velocity.X = num55;
                                this.velocity.Y = num56;
                            }
                            else
                            {
                                int num62 = (int) (num55 * 1000f);
                                int num63 = (int) (this.velocity.X * 1000f);
                                int num64 = (int) (num56 * 1000f);
                                int num65 = (int) (this.velocity.Y * 1000f);
                                if ((num62 != num63) || (num64 != num65))
                                {
                                    this.netUpdate = true;
                                }
                                this.velocity.X = num55;
                                this.velocity.Y = num56;
                            }
                        }
                        else if (this.ai[0] == 0f)
                        {
                            this.ai[0] = 1f;
                            this.netUpdate = true;
                            float num66 = 12f;
                            Vector2 vector7 = new Vector2(this.position.X + (this.width * 0.5f), this.position.Y + (this.height * 0.5f));
                            float num67 = (Main.mouseX + Main.screenPosition.X) - vector7.X;
                            float num68 = (Main.mouseY + Main.screenPosition.Y) - vector7.Y;
                            float num69 = (float) Math.Sqrt((double) ((num67 * num67) + (num68 * num68)));
                            if (num69 == 0f)
                            {
                                vector7 = new Vector2(Main.player[this.owner].position.X + (Main.player[this.owner].width / 2), Main.player[this.owner].position.Y + (Main.player[this.owner].height / 2));
                                num67 = (this.position.X + (this.width * 0.5f)) - vector7.X;
                                num68 = (this.position.Y + (this.height * 0.5f)) - vector7.Y;
                                num69 = (float) Math.Sqrt((double) ((num67 * num67) + (num68 * num68)));
                            }
                            num69 = num66 / num69;
                            num67 *= num69;
                            num68 *= num69;
                            this.velocity.X = num67;
                            this.velocity.Y = num68;
                            if ((this.velocity.X == 0f) && (this.velocity.Y == 0f))
                            {
                                this.Kill();
                            }
                        }
                    }
                    if (this.type == 0x22)
                    {
                        this.rotation += 0.3f * this.direction;
                    }
                    else if ((this.velocity.X != 0f) || (this.velocity.Y != 0f))
                    {
                        this.rotation = ((float) Math.Atan2((double) this.velocity.Y, (double) this.velocity.X)) - 2.355f;
                    }
                    if (this.velocity.Y > 16f)
                    {
                        this.velocity.Y = 16f;
                    }
                }
                else if (this.aiStyle == 10)
                {
                    if ((this.type == 0x1f) && (this.ai[0] != 2f))
                    {
                        if (Main.rand.Next(2) == 0)
                        {
                            int num70 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0x20, 0f, this.velocity.Y / 2f, 0, new Color(), 1f);
                            Main.dust[num70].velocity.X *= 0.4f;
                        }
                    }
                    else if (this.type == 0x27)
                    {
                        if (Main.rand.Next(2) == 0)
                        {
                            int num71 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0x26, 0f, this.velocity.Y / 2f, 0, new Color(), 1f);
                            Main.dust[num71].velocity.X *= 0.4f;
                        }
                    }
                    else if (this.type == 40)
                    {
                        if (Main.rand.Next(2) == 0)
                        {
                            int num72 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0x24, 0f, this.velocity.Y / 2f, 0, new Color(), 1f);
                            Dust dust6 = Main.dust[num72];
                            dust6.velocity = (Vector2) (dust6.velocity * 0.4f);
                        }
                    }
                    else if ((this.type == 0x2a) || (this.type == 0x1f))
                    {
                        if (Main.rand.Next(2) == 0)
                        {
                            int num73 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0x20, 0f, 0f, 0, new Color(), 1f);
                            Main.dust[num73].velocity.X *= 0.4f;
                        }
                    }
                    else if ((this.type == 0x38) || (this.type == 0x41))
                    {
                        if (Main.rand.Next(2) == 0)
                        {
                            int num74 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 14, 0f, 0f, 0, new Color(), 1f);
                            Main.dust[num74].velocity.X *= 0.4f;
                        }
                    }
                    else if ((this.type == 0x43) || (this.type == 0x44))
                    {
                        if (Main.rand.Next(2) == 0)
                        {
                            int num75 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0x33, 0f, 0f, 0, new Color(), 1f);
                            Main.dust[num75].velocity.X *= 0.4f;
                        }
                    }
                    else if (this.type == 0x47)
                    {
                        if (Main.rand.Next(2) == 0)
                        {
                            int num76 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0x35, 0f, 0f, 0, new Color(), 1f);
                            Main.dust[num76].velocity.X *= 0.4f;
                        }
                    }
                    else if (Main.rand.Next(20) == 0)
                    {
                        Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0, 0f, 0f, 0, new Color(), 1f);
                    }
                    if ((Main.myPlayer == this.owner) && (this.ai[0] == 0f))
                    {
                        if (Main.player[this.owner].channel)
                        {
                            float num77 = 12f;
                            Vector2 vector8 = new Vector2(this.position.X + (this.width * 0.5f), this.position.Y + (this.height * 0.5f));
                            float num78 = (Main.mouseX + Main.screenPosition.X) - vector8.X;
                            float num79 = (Main.mouseY + Main.screenPosition.Y) - vector8.Y;
                            float num80 = (float) Math.Sqrt((double) ((num78 * num78) + (num79 * num79)));
                            num80 = (float) Math.Sqrt((double) ((num78 * num78) + (num79 * num79)));
                            if (num80 > num77)
                            {
                                num80 = num77 / num80;
                                num78 *= num80;
                                num79 *= num80;
                                if ((num78 != this.velocity.X) || (num79 != this.velocity.Y))
                                {
                                    this.netUpdate = true;
                                }
                                this.velocity.X = num78;
                                this.velocity.Y = num79;
                            }
                            else
                            {
                                if ((num78 != this.velocity.X) || (num79 != this.velocity.Y))
                                {
                                    this.netUpdate = true;
                                }
                                this.velocity.X = num78;
                                this.velocity.Y = num79;
                            }
                        }
                        else
                        {
                            this.ai[0] = 1f;
                            this.netUpdate = true;
                        }
                    }
                    if (this.ai[0] == 1f)
                    {
                        if (((this.type == 0x2a) || (this.type == 0x41)) || (this.type == 0x44))
                        {
                            this.ai[1]++;
                            if (this.ai[1] >= 60f)
                            {
                                this.ai[1] = 60f;
                                this.velocity.Y += 0.2f;
                            }
                        }
                        else
                        {
                            this.velocity.Y += 0.41f;
                        }
                    }
                    else if (this.ai[0] == 2f)
                    {
                        this.velocity.Y += 0.2f;
                        if (this.velocity.X < -0.04)
                        {
                            this.velocity.X += 0.04f;
                        }
                        else if (this.velocity.X > 0.04)
                        {
                            this.velocity.X -= 0.04f;
                        }
                        else
                        {
                            this.velocity.X = 0f;
                        }
                    }
                    this.rotation += 0.1f;
                    if (this.velocity.Y > 10f)
                    {
                        this.velocity.Y = 10f;
                    }
                }
                else if (this.aiStyle == 11)
                {
                    if (((this.type == 0x48) || (this.type == 0x56)) || (this.type == 0x57))
                    {
                        if (this.velocity.X > 0f)
                        {
                            this.spriteDirection = -1;
                        }
                        else if (this.velocity.X < 0f)
                        {
                            this.spriteDirection = 1;
                        }
                        this.rotation = this.velocity.X * 0.1f;
                        this.frameCounter++;
                        if (this.frameCounter >= 4)
                        {
                            this.frame++;
                            this.frameCounter = 0;
                        }
                        if (this.frame >= 4)
                        {
                            this.frame = 0;
                        }
                        if (Main.rand.Next(6) == 0)
                        {
                            int num81 = 0x38;
                            if (this.type == 0x56)
                            {
                                num81 = 0x49;
                            }
                            else if (this.type == 0x57)
                            {
                                num81 = 0x4a;
                            }
                            int num82 = Dust.NewDust(this.position, this.width, this.height, num81, 0f, 0f, 200, new Color(), 0.8f);
                            Dust dust7 = Main.dust[num82];
                            dust7.velocity = (Vector2) (dust7.velocity * 0.3f);
                        }
                    }
                    else
                    {
                        this.rotation += 0.02f;
                    }
                    if (Main.myPlayer == this.owner)
                    {
                        if (((this.type == 0x48) || (this.type == 0x56)) || (this.type == 0x57))
                        {
                            if (Main.player[Main.myPlayer].fairy)
                            {
                                this.timeLeft = 2;
                            }
                        }
                        else if (Main.player[Main.myPlayer].lightOrb)
                        {
                            this.timeLeft = 2;
                        }
                    }
                    if (!Main.player[this.owner].dead)
                    {
                        float num83 = 2.5f;
                        if (((this.type == 0x48) || (this.type == 0x56)) || (this.type == 0x57))
                        {
                            num83 = 3.5f;
                        }
                        Vector2 vector9 = new Vector2(this.position.X + (this.width * 0.5f), this.position.Y + (this.height * 0.5f));
                        float num84 = (Main.player[this.owner].position.X + (Main.player[this.owner].width / 2)) - vector9.X;
                        float num85 = (Main.player[this.owner].position.Y + (Main.player[this.owner].height / 2)) - vector9.Y;
                        float num86 = (float) Math.Sqrt((double) ((num84 * num84) + (num85 * num85)));
                        num86 = (float) Math.Sqrt((double) ((num84 * num84) + (num85 * num85)));
                        int num87 = 70;
                        if (((this.type == 0x48) || (this.type == 0x56)) || (this.type == 0x57))
                        {
                            num87 = 40;
                        }
                        if (num86 > 800f)
                        {
                            this.position.X = (Main.player[this.owner].position.X + (Main.player[this.owner].width / 2)) - (this.width / 2);
                            this.position.Y = (Main.player[this.owner].position.Y + (Main.player[this.owner].height / 2)) - (this.height / 2);
                        }
                        else if (num86 > num87)
                        {
                            num86 = num83 / num86;
                            num84 *= num86;
                            num85 *= num86;
                            this.velocity.X = num84;
                            this.velocity.Y = num85;
                        }
                        else
                        {
                            this.velocity.X = 0f;
                            this.velocity.Y = 0f;
                        }
                    }
                    else
                    {
                        this.Kill();
                    }
                }
                else if (this.aiStyle == 12)
                {
                    this.scale -= 0.04f;
                    if (this.scale <= 0f)
                    {
                        this.Kill();
                    }
                    if (this.ai[0] > 4f)
                    {
                        this.alpha = 150;
                        this.light = 0.8f;
                        color = new Color();
                        int num88 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0x1d, this.velocity.X, this.velocity.Y, 100, color, 2.5f);
                        Main.dust[num88].noGravity = true;
                        Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0x1d, this.velocity.X, this.velocity.Y, 100, new Color(), 1.5f);
                    }
                    else
                    {
                        this.ai[0]++;
                    }
                    this.rotation += 0.3f * this.direction;
                }
                else if (this.aiStyle == 13)
                {
                    if (Main.player[this.owner].dead)
                    {
                        this.Kill();
                    }
                    else
                    {
                        Main.player[this.owner].itemAnimation = 5;
                        Main.player[this.owner].itemTime = 5;
                        if ((this.position.X + (this.width / 2)) > (Main.player[this.owner].position.X + (Main.player[this.owner].width / 2)))
                        {
                            Main.player[this.owner].direction = 1;
                        }
                        else
                        {
                            Main.player[this.owner].direction = -1;
                        }
                        Vector2 vector10 = new Vector2(this.position.X + (this.width * 0.5f), this.position.Y + (this.height * 0.5f));
                        float num89 = (Main.player[this.owner].position.X + (Main.player[this.owner].width / 2)) - vector10.X;
                        float num90 = (Main.player[this.owner].position.Y + (Main.player[this.owner].height / 2)) - vector10.Y;
                        float num91 = (float) Math.Sqrt((double) ((num89 * num89) + (num90 * num90)));
                        if (this.ai[0] != 0f)
                        {
                            if (this.ai[0] == 1f)
                            {
                                this.tileCollide = false;
                                this.rotation = ((float) Math.Atan2((double) num90, (double) num89)) - 1.57f;
                                float num92 = 20f;
                                if (num91 < 50f)
                                {
                                    this.Kill();
                                }
                                num91 = num92 / num91;
                                num89 *= num91;
                                num90 *= num91;
                                this.velocity.X = num89;
                                this.velocity.Y = num90;
                            }
                        }
                        else
                        {
                            if (num91 > 700f)
                            {
                                this.ai[0] = 1f;
                            }
                            this.rotation = ((float) Math.Atan2((double) this.velocity.Y, (double) this.velocity.X)) + 1.57f;
                            this.ai[1]++;
                            if (this.ai[1] > 2f)
                            {
                                this.alpha = 0;
                            }
                            if (this.ai[1] >= 10f)
                            {
                                this.ai[1] = 15f;
                                this.velocity.Y += 0.3f;
                            }
                        }
                    }
                }
                else if (this.aiStyle == 14)
                {
                    if (this.type == 0x35)
                    {
                        try
                        {
                            Vector2 vector11 = Collision.TileCollision(this.position, this.velocity, this.width, this.height, false, false);
                            bool flag1 = this.velocity != vector11;
                            int num93 = ((int) (this.position.X / 16f)) - 1;
                            int num94 = ((int) ((this.position.X + this.width) / 16f)) + 2;
                            int num95 = ((int) (this.position.Y / 16f)) - 1;
                            int num96 = ((int) ((this.position.Y + this.height) / 16f)) + 2;
                            if (num93 < 0)
                            {
                                num93 = 0;
                            }
                            if (num94 > Main.maxTilesX)
                            {
                                num94 = Main.maxTilesX;
                            }
                            if (num95 < 0)
                            {
                                num95 = 0;
                            }
                            if (num96 > Main.maxTilesY)
                            {
                                num96 = Main.maxTilesY;
                            }
                            for (int num97 = num93; num97 < num94; num97++)
                            {
                                for (int num98 = num95; num98 < num96; num98++)
                                {
                                    if (((Main.tile[num97, num98] != null) && Main.tile[num97, num98].active) && (Main.tileSolid[Main.tile[num97, num98].type] || (Main.tileSolidTop[Main.tile[num97, num98].type] && (Main.tile[num97, num98].frameY == 0))))
                                    {
                                        Vector2 vector12;
                                        vector12.X = num97 * 0x10;
                                        vector12.Y = num98 * 0x10;
                                        if ((((this.position.X + this.width) > vector12.X) && (this.position.X < (vector12.X + 16f))) && (((this.position.Y + this.height) > vector12.Y) && (this.position.Y < (vector12.Y + 16f))))
                                        {
                                            this.velocity.X = 0f;
                                            this.velocity.Y = -0.2f;
                                        }
                                    }
                                }
                            }
                        }
                        catch
                        {
                        }
                    }
                    this.ai[0]++;
                    if (this.ai[0] > 5f)
                    {
                        this.ai[0] = 5f;
                        if ((this.velocity.Y == 0f) && (this.velocity.X != 0f))
                        {
                            this.velocity.X *= 0.97f;
                            if ((this.velocity.X > -0.01) && (this.velocity.X < 0.01))
                            {
                                this.velocity.X = 0f;
                                this.netUpdate = true;
                            }
                        }
                        this.velocity.Y += 0.2f;
                    }
                    this.rotation += this.velocity.X * 0.1f;
                    if (this.velocity.Y > 16f)
                    {
                        this.velocity.Y = 16f;
                    }
                }
                else if (this.aiStyle == 15)
                {
                    if (this.type == 0x19)
                    {
                        if (Main.rand.Next(15) == 0)
                        {
                            Dust.NewDust(this.position, this.width, this.height, 14, 0f, 0f, 150, new Color(), 1.3f);
                        }
                    }
                    else if (this.type == 0x1a)
                    {
                        int num99 = Dust.NewDust(this.position, this.width, this.height, 0x1d, this.velocity.X * 0.4f, this.velocity.Y * 0.4f, 100, new Color(), 2.5f);
                        Main.dust[num99].noGravity = true;
                        Main.dust[num99].velocity.X /= 2f;
                        Main.dust[num99].velocity.Y /= 2f;
                    }
                    else if (this.type == 0x23)
                    {
                        int num100 = Dust.NewDust(this.position, this.width, this.height, 6, this.velocity.X * 0.4f, this.velocity.Y * 0.4f, 100, new Color(), 3f);
                        Main.dust[num100].noGravity = true;
                        Main.dust[num100].velocity.X *= 2f;
                        Main.dust[num100].velocity.Y *= 2f;
                    }
                    if (Main.player[this.owner].dead)
                    {
                        this.Kill();
                    }
                    else
                    {
                        Main.player[this.owner].itemAnimation = 10;
                        Main.player[this.owner].itemTime = 10;
                        if ((this.position.X + (this.width / 2)) > (Main.player[this.owner].position.X + (Main.player[this.owner].width / 2)))
                        {
                            Main.player[this.owner].direction = 1;
                            this.direction = 1;
                        }
                        else
                        {
                            Main.player[this.owner].direction = -1;
                            this.direction = -1;
                        }
                        Vector2 vector13 = new Vector2(this.position.X + (this.width * 0.5f), this.position.Y + (this.height * 0.5f));
                        float num101 = (Main.player[this.owner].position.X + (Main.player[this.owner].width / 2)) - vector13.X;
                        float num102 = (Main.player[this.owner].position.Y + (Main.player[this.owner].height / 2)) - vector13.Y;
                        float num103 = (float) Math.Sqrt((double) ((num101 * num101) + (num102 * num102)));
                        if (this.ai[0] == 0f)
                        {
                            float num104 = 160f;
                            if (this.type == 0x3f)
                            {
                                num104 *= 1.5f;
                            }
                            this.tileCollide = true;
                            if (num103 > num104)
                            {
                                this.ai[0] = 1f;
                                this.netUpdate = true;
                            }
                            else if (!Main.player[this.owner].channel)
                            {
                                if (this.velocity.Y < 0f)
                                {
                                    this.velocity.Y *= 0.9f;
                                }
                                this.velocity.Y++;
                                this.velocity.X *= 0.9f;
                            }
                        }
                        else if (this.ai[0] == 1f)
                        {
                            float num105 = 14f / Main.player[this.owner].meleeSpeed;
                            float num106 = 0.9f / Main.player[this.owner].meleeSpeed;
                            float num107 = 300f;
                            if (this.type == 0x3f)
                            {
                                num107 *= 1.5f;
                                num105 *= 1.5f;
                                num106 *= 1.5f;
                            }
                            Math.Abs(num101);
                            Math.Abs(num102);
                            if (this.ai[1] == 1f)
                            {
                                this.tileCollide = false;
                            }
                            if ((!Main.player[this.owner].channel || (num103 > num107)) || !this.tileCollide)
                            {
                                this.ai[1] = 1f;
                                if (this.tileCollide)
                                {
                                    this.netUpdate = true;
                                }
                                this.tileCollide = false;
                                if (num103 < 20f)
                                {
                                    this.Kill();
                                }
                            }
                            if (!this.tileCollide)
                            {
                                num106 *= 2f;
                            }
                            if ((num103 > 60f) || !this.tileCollide)
                            {
                                num103 = num105 / num103;
                                num101 *= num103;
                                num102 *= num103;
                                new Vector2(this.velocity.X, this.velocity.Y);
                                float num108 = num101 - this.velocity.X;
                                float num109 = num102 - this.velocity.Y;
                                float num110 = (float) Math.Sqrt((double) ((num108 * num108) + (num109 * num109)));
                                num110 = num106 / num110;
                                num108 *= num110;
                                num109 *= num110;
                                this.velocity.X *= 0.98f;
                                this.velocity.Y *= 0.98f;
                                this.velocity.X += num108;
                                this.velocity.Y += num109;
                            }
                            else
                            {
                                if ((Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y)) < 6f)
                                {
                                    this.velocity.X *= 0.96f;
                                    this.velocity.Y += 0.2f;
                                }
                                if (Main.player[this.owner].velocity.X == 0f)
                                {
                                    this.velocity.X *= 0.96f;
                                }
                            }
                        }
                        this.rotation = ((float) Math.Atan2((double) num102, (double) num101)) - (this.velocity.X * 0.1f);
                    }
                }
                else if (this.aiStyle == 0x10)
                {
                    if (this.type == 0x6c)
                    {
                        this.ai[0]++;
                        if (this.ai[0] > 3f)
                        {
                            this.Kill();
                        }
                    }
                    if (this.type == 0x25)
                    {
                        try
                        {
                            int num111 = ((int) (this.position.X / 16f)) - 1;
                            int num112 = ((int) ((this.position.X + this.width) / 16f)) + 2;
                            int num113 = ((int) (this.position.Y / 16f)) - 1;
                            int num114 = ((int) ((this.position.Y + this.height) / 16f)) + 2;
                            if (num111 < 0)
                            {
                                num111 = 0;
                            }
                            if (num112 > Main.maxTilesX)
                            {
                                num112 = Main.maxTilesX;
                            }
                            if (num113 < 0)
                            {
                                num113 = 0;
                            }
                            if (num114 > Main.maxTilesY)
                            {
                                num114 = Main.maxTilesY;
                            }
                            for (int num115 = num111; num115 < num112; num115++)
                            {
                                for (int num116 = num113; num116 < num114; num116++)
                                {
                                    if (((Main.tile[num115, num116] != null) && Main.tile[num115, num116].active) && (Main.tileSolid[Main.tile[num115, num116].type] || (Main.tileSolidTop[Main.tile[num115, num116].type] && (Main.tile[num115, num116].frameY == 0))))
                                    {
                                        Vector2 vector14;
                                        vector14.X = num115 * 0x10;
                                        vector14.Y = num116 * 0x10;
                                        if (((((this.position.X + this.width) - 4f) > vector14.X) && ((this.position.X + 4f) < (vector14.X + 16f))) && ((((this.position.Y + this.height) - 4f) > vector14.Y) && ((this.position.Y + 4f) < (vector14.Y + 16f))))
                                        {
                                            this.velocity.X = 0f;
                                            this.velocity.Y = -0.2f;
                                        }
                                    }
                                }
                            }
                        }
                        catch
                        {
                        }
                    }
                    if (this.type == 0x66)
                    {
                        if (this.velocity.Y > 10f)
                        {
                            this.velocity.Y = 10f;
                        }
                        if (this.localAI[0] == 0f)
                        {
                            this.localAI[0] = 1f;
                            Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 10);
                        }
                        this.frameCounter++;
                        if (this.frameCounter > 3)
                        {
                            this.frame++;
                            this.frameCounter = 0;
                        }
                        if (this.frame > 1)
                        {
                            this.frame = 0;
                        }
                        if (this.velocity.Y == 0f)
                        {
                            this.position.X += this.width / 2;
                            this.position.Y += this.height / 2;
                            this.width = 0x80;
                            this.height = 0x80;
                            this.position.X -= this.width / 2;
                            this.position.Y -= this.height / 2;
                            this.damage = 40;
                            this.knockBack = 8f;
                            this.timeLeft = 3;
                            this.netUpdate = true;
                        }
                    }
                    if ((this.owner == Main.myPlayer) && (this.timeLeft <= 3))
                    {
                        this.ai[1] = 0f;
                        this.alpha = 0xff;
                        if (((this.type == 0x1c) || (this.type == 0x25)) || (this.type == 0x4b))
                        {
                            this.position.X += this.width / 2;
                            this.position.Y += this.height / 2;
                            this.width = 0x80;
                            this.height = 0x80;
                            this.position.X -= this.width / 2;
                            this.position.Y -= this.height / 2;
                            this.damage = 100;
                            this.knockBack = 8f;
                        }
                        else if (this.type == 0x1d)
                        {
                            this.position.X += this.width / 2;
                            this.position.Y += this.height / 2;
                            this.width = 250;
                            this.height = 250;
                            this.position.X -= this.width / 2;
                            this.position.Y -= this.height / 2;
                            this.damage = 250;
                            this.knockBack = 10f;
                        }
                        else if (this.type == 30)
                        {
                            this.position.X += this.width / 2;
                            this.position.Y += this.height / 2;
                            this.width = 0x80;
                            this.height = 0x80;
                            this.position.X -= this.width / 2;
                            this.position.Y -= this.height / 2;
                            this.knockBack = 8f;
                        }
                    }
                    else
                    {
                        if ((this.type != 30) && (this.type != 0x6c))
                        {
                            this.damage = 0;
                        }
                        if ((this.type != 30) && (Main.rand.Next(4) == 0))
                        {
                            Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, new Color(), 1f);
                        }
                    }
                    this.ai[0]++;
                    if (((this.type == 30) && (this.ai[0] > 10f)) || ((this.type != 30) && (this.ai[0] > 5f)))
                    {
                        this.ai[0] = 10f;
                        if ((this.velocity.Y == 0f) && (this.velocity.X != 0f))
                        {
                            this.velocity.X *= 0.97f;
                            if (this.type == 0x1d)
                            {
                                this.velocity.X *= 0.99f;
                            }
                            if ((this.velocity.X > -0.01) && (this.velocity.X < 0.01))
                            {
                                this.velocity.X = 0f;
                                this.netUpdate = true;
                            }
                        }
                        this.velocity.Y += 0.2f;
                    }
                    this.rotation += this.velocity.X * 0.1f;
                }
                else if (this.aiStyle == 0x11)
                {
                    if (this.velocity.Y == 0f)
                    {
                        this.velocity.X *= 0.98f;
                    }
                    this.rotation += this.velocity.X * 0.1f;
                    this.velocity.Y += 0.2f;
                    if (this.owner == Main.myPlayer)
                    {
                        int num117 = (int) ((this.position.X + (this.width / 2)) / 16f);
                        int num118 = (int) (((this.position.Y + this.height) - 4f) / 16f);
                        if ((Main.tile[num117, num118] != null) && !Main.tile[num117, num118].active)
                        {
                            WorldGen.PlaceTile(num117, num118, 0x55, false, false, -1, 0);
                            if (Main.tile[num117, num118].active)
                            {
                                if (Main.netMode != 0)
                                {
                                    NetMessage.SendData(0x11, -1, -1, "", 1, (float) num117, (float) num118, 85f, 0);
                                }
                                int num119 = Sign.ReadSign(num117, num118);
                                if (num119 >= 0)
                                {
                                    Sign.TextSign(num119, this.miscText);
                                }
                                this.Kill();
                            }
                        }
                    }
                }
                else if (this.aiStyle == 0x12)
                {
                    if ((this.ai[1] == 0f) && (this.type == 0x2c))
                    {
                        this.ai[1] = 1f;
                        Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 8);
                    }
                    this.rotation += this.direction * 0.8f;
                    this.ai[0]++;
                    if (this.ai[0] >= 30f)
                    {
                        if (this.ai[0] < 100f)
                        {
                            this.velocity = (Vector2) (this.velocity * 1.06f);
                        }
                        else
                        {
                            this.ai[0] = 200f;
                        }
                    }
                    for (int num120 = 0; num120 < 2; num120++)
                    {
                        color = new Color();
                        int num121 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0x1b, 0f, 0f, 100, color, 1f);
                        Main.dust[num121].noGravity = true;
                    }
                }
                else if (this.aiStyle == 0x13)
                {
                    this.direction = Main.player[this.owner].direction;
                    Main.player[this.owner].heldProj = this.whoAmI;
                    Main.player[this.owner].itemTime = Main.player[this.owner].itemAnimation;
                    this.position.X = (Main.player[this.owner].position.X + (Main.player[this.owner].width / 2)) - (this.width / 2);
                    this.position.Y = (Main.player[this.owner].position.Y + (Main.player[this.owner].height / 2)) - (this.height / 2);
                    if (this.type == 0x2e)
                    {
                        if (this.ai[0] == 0f)
                        {
                            this.ai[0] = 3f;
                            this.netUpdate = true;
                        }
                        if (Main.player[this.owner].itemAnimation < (Main.player[this.owner].itemAnimationMax / 3))
                        {
                            this.ai[0] -= 1.6f;
                        }
                        else
                        {
                            this.ai[0] += 1.4f;
                        }
                    }
                    else if (this.type == 0x69)
                    {
                        if (this.ai[0] == 0f)
                        {
                            this.ai[0] = 3f;
                            this.netUpdate = true;
                        }
                        if (Main.player[this.owner].itemAnimation < (Main.player[this.owner].itemAnimationMax / 3))
                        {
                            this.ai[0] -= 2.4f;
                        }
                        else
                        {
                            this.ai[0] += 2.1f;
                        }
                    }
                    else if (this.type == 0x2f)
                    {
                        if (this.ai[0] == 0f)
                        {
                            this.ai[0] = 4f;
                            this.netUpdate = true;
                        }
                        if (Main.player[this.owner].itemAnimation < (Main.player[this.owner].itemAnimationMax / 3))
                        {
                            this.ai[0] -= 1.2f;
                        }
                        else
                        {
                            this.ai[0] += 0.9f;
                        }
                    }
                    else if (this.type == 0x31)
                    {
                        if (this.ai[0] == 0f)
                        {
                            this.ai[0] = 4f;
                            this.netUpdate = true;
                        }
                        if (Main.player[this.owner].itemAnimation < (Main.player[this.owner].itemAnimationMax / 3))
                        {
                            this.ai[0] -= 1.1f;
                        }
                        else
                        {
                            this.ai[0] += 0.85f;
                        }
                    }
                    else if (this.type == 0x40)
                    {
                        this.spriteDirection = -this.direction;
                        if (this.ai[0] == 0f)
                        {
                            this.ai[0] = 3f;
                            this.netUpdate = true;
                        }
                        if (Main.player[this.owner].itemAnimation < (Main.player[this.owner].itemAnimationMax / 3))
                        {
                            this.ai[0] -= 1.9f;
                        }
                        else
                        {
                            this.ai[0] += 1.7f;
                        }
                    }
                    else if ((this.type == 0x42) || (this.type == 0x61))
                    {
                        this.spriteDirection = -this.direction;
                        if (this.ai[0] == 0f)
                        {
                            this.ai[0] = 3f;
                            this.netUpdate = true;
                        }
                        if (Main.player[this.owner].itemAnimation < (Main.player[this.owner].itemAnimationMax / 3))
                        {
                            this.ai[0] -= 2.1f;
                        }
                        else
                        {
                            this.ai[0] += 1.9f;
                        }
                    }
                    else if (this.type == 0x61)
                    {
                        this.spriteDirection = -this.direction;
                        if (this.ai[0] == 0f)
                        {
                            this.ai[0] = 3f;
                            this.netUpdate = true;
                        }
                        if (Main.player[this.owner].itemAnimation < (Main.player[this.owner].itemAnimationMax / 3))
                        {
                            this.ai[0] -= 1.6f;
                        }
                        else
                        {
                            this.ai[0] += 1.4f;
                        }
                    }
                    this.position += (Vector2) (this.velocity * this.ai[0]);
                    if (Main.player[this.owner].itemAnimation == 0)
                    {
                        this.Kill();
                    }
                    this.rotation = ((float) Math.Atan2((double) this.velocity.Y, (double) this.velocity.X)) + 2.355f;
                    if (this.spriteDirection == -1)
                    {
                        this.rotation -= 1.57f;
                    }
                    if (this.type == 0x2e)
                    {
                        if (Main.rand.Next(5) == 0)
                        {
                            color = new Color();
                            Dust.NewDust(this.position, this.width, this.height, 14, 0f, 0f, 150, color, 1.4f);
                        }
                        color = new Color();
                        int num122 = Dust.NewDust(this.position, this.width, this.height, 0x1b, (this.velocity.X * 0.2f) + (this.direction * 3), this.velocity.Y * 0.2f, 100, color, 1.2f);
                        Main.dust[num122].noGravity = true;
                        Main.dust[num122].velocity.X /= 2f;
                        Main.dust[num122].velocity.Y /= 2f;
                        num122 = Dust.NewDust(this.position - ((Vector2) (this.velocity * 2f)), this.width, this.height, 0x1b, 0f, 0f, 150, new Color(), 1.4f);
                        Main.dust[num122].velocity.X /= 5f;
                        Main.dust[num122].velocity.Y /= 5f;
                    }
                    else if (this.type == 0x69)
                    {
                        if (Main.rand.Next(3) == 0)
                        {
                            color = new Color();
                            int num123 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0x39, this.velocity.X * 0.2f, this.velocity.Y * 0.2f, 200, color, 1.2f);
                            Dust dust8 = Main.dust[num123];
                            dust8.velocity += (Vector2) (this.velocity * 0.3f);
                            Dust dust9 = Main.dust[num123];
                            dust9.velocity = (Vector2) (dust9.velocity * 0.2f);
                        }
                        if (Main.rand.Next(4) == 0)
                        {
                            int num124 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0x2b, 0f, 0f, 0xfe, new Color(), 0.3f);
                            Dust dust10 = Main.dust[num124];
                            dust10.velocity += (Vector2) (this.velocity * 0.5f);
                            Dust dust11 = Main.dust[num124];
                            dust11.velocity = (Vector2) (dust11.velocity * 0.5f);
                        }
                    }
                }
                else if (this.aiStyle == 20)
                {
                    if (this.soundDelay <= 0)
                    {
                        Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 0x16);
                        this.soundDelay = 30;
                    }
                    if (Main.myPlayer == this.owner)
                    {
                        if (Main.player[this.owner].channel)
                        {
                            float num125 = Main.player[this.owner].inventory[Main.player[this.owner].selectedItem].shootSpeed * this.scale;
                            Vector2 vector15 = new Vector2(Main.player[this.owner].position.X + (Main.player[this.owner].width * 0.5f), Main.player[this.owner].position.Y + (Main.player[this.owner].height * 0.5f));
                            float num126 = (Main.mouseX + Main.screenPosition.X) - vector15.X;
                            float num127 = (Main.mouseY + Main.screenPosition.Y) - vector15.Y;
                            float num128 = (float) Math.Sqrt((double) ((num126 * num126) + (num127 * num127)));
                            num128 = (float) Math.Sqrt((double) ((num126 * num126) + (num127 * num127)));
                            num128 = num125 / num128;
                            num126 *= num128;
                            num127 *= num128;
                            if ((num126 != this.velocity.X) || (num127 != this.velocity.Y))
                            {
                                this.netUpdate = true;
                            }
                            this.velocity.X = num126;
                            this.velocity.Y = num127;
                        }
                        else
                        {
                            this.Kill();
                        }
                    }
                    if (this.velocity.X > 0f)
                    {
                        Main.player[this.owner].direction = 1;
                    }
                    else if (this.velocity.X < 0f)
                    {
                        Main.player[this.owner].direction = -1;
                    }
                    this.spriteDirection = this.direction;
                    Main.player[this.owner].direction = this.direction;
                    Main.player[this.owner].heldProj = this.whoAmI;
                    Main.player[this.owner].itemTime = 2;
                    Main.player[this.owner].itemAnimation = 2;
                    this.position.X = (Main.player[this.owner].position.X + (Main.player[this.owner].width / 2)) - (this.width / 2);
                    this.position.Y = (Main.player[this.owner].position.Y + (Main.player[this.owner].height / 2)) - (this.height / 2);
                    this.rotation = (float) (Math.Atan2((double) this.velocity.Y, (double) this.velocity.X) + 1.5700000524520874);
                    if (Main.player[this.owner].direction == 1)
                    {
                        Main.player[this.owner].itemRotation = (float) Math.Atan2((double) (this.velocity.Y * this.direction), (double) (this.velocity.X * this.direction));
                    }
                    else
                    {
                        Main.player[this.owner].itemRotation = (float) Math.Atan2((double) (this.velocity.Y * this.direction), (double) (this.velocity.X * this.direction));
                    }
                    this.velocity.X *= 1f + (Main.rand.Next(-3, 4) * 0.01f);
                    if (Main.rand.Next(6) == 0)
                    {
                        int num129 = Dust.NewDust(this.position + ((Vector2) ((this.velocity * Main.rand.Next(6, 10)) * 0.1f)), this.width, this.height, 0x1f, 0f, 0f, 80, new Color(), 1.4f);
                        Main.dust[num129].position.X -= 4f;
                        Main.dust[num129].noGravity = true;
                        Dust dust12 = Main.dust[num129];
                        dust12.velocity = (Vector2) (dust12.velocity * 0.2f);
                        Main.dust[num129].velocity.Y = -Main.rand.Next(7, 13) * 0.15f;
                    }
                }
                else if (this.aiStyle == 0x15)
                {
                    this.rotation = this.velocity.X * 0.1f;
                    this.spriteDirection = -this.direction;
                    if (Main.rand.Next(3) == 0)
                    {
                        int num130 = Dust.NewDust(this.position, this.width, this.height, 0x1b, 0f, 0f, 80, new Color(), 1f);
                        Main.dust[num130].noGravity = true;
                        Dust dust13 = Main.dust[num130];
                        dust13.velocity = (Vector2) (dust13.velocity * 0.2f);
                    }
                    if (this.ai[1] == 1f)
                    {
                        this.ai[1] = 0f;
                        Main.harpNote = this.ai[0];
                        Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 0x1a);
                    }
                }
                else if (this.aiStyle == 0x16)
                {
                    if ((this.velocity.X == 0f) && (this.velocity.Y == 0f))
                    {
                        this.alpha = 0xff;
                    }
                    if (this.ai[1] < 0f)
                    {
                        if (this.velocity.X > 0f)
                        {
                            this.rotation += 0.3f;
                        }
                        else
                        {
                            this.rotation -= 0.3f;
                        }
                        int num131 = ((int) (this.position.X / 16f)) - 1;
                        int num132 = ((int) ((this.position.X + this.width) / 16f)) + 2;
                        int num133 = ((int) (this.position.Y / 16f)) - 1;
                        int num134 = ((int) ((this.position.Y + this.height) / 16f)) + 2;
                        if (num131 < 0)
                        {
                            num131 = 0;
                        }
                        if (num132 > Main.maxTilesX)
                        {
                            num132 = Main.maxTilesX;
                        }
                        if (num133 < 0)
                        {
                            num133 = 0;
                        }
                        if (num134 > Main.maxTilesY)
                        {
                            num134 = Main.maxTilesY;
                        }
                        int num135 = ((int) this.position.X) + 4;
                        int num136 = ((int) this.position.Y) + 4;
                        for (int num137 = num131; num137 < num132; num137++)
                        {
                            for (int num138 = num133; num138 < num134; num138++)
                            {
                                if ((((Main.tile[num137, num138] != null) && Main.tile[num137, num138].active) && ((Main.tile[num137, num138].type != 0x7f) && Main.tileSolid[Main.tile[num137, num138].type])) && !Main.tileSolidTop[Main.tile[num137, num138].type])
                                {
                                    Vector2 vector16;
                                    vector16.X = num137 * 0x10;
                                    vector16.Y = num138 * 0x10;
                                    if ((((num135 + 8) > vector16.X) && (num135 < (vector16.X + 16f))) && (((num136 + 8) > vector16.Y) && (num136 < (vector16.Y + 16f))))
                                    {
                                        this.Kill();
                                    }
                                }
                            }
                        }
                        int num139 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0x43, 0f, 0f, 0, new Color(), 1f);
                        Main.dust[num139].noGravity = true;
                        Dust dust14 = Main.dust[num139];
                        dust14.velocity = (Vector2) (dust14.velocity * 0.3f);
                    }
                    else if (this.ai[0] >= 0f)
                    {
                        int num145 = ((int) (this.position.X / 16f)) - 1;
                        int num146 = ((int) ((this.position.X + this.width) / 16f)) + 2;
                        int num147 = ((int) (this.position.Y / 16f)) - 1;
                        int num148 = ((int) ((this.position.Y + this.height) / 16f)) + 2;
                        if (num145 < 0)
                        {
                            num145 = 0;
                        }
                        if (num146 > Main.maxTilesX)
                        {
                            num146 = Main.maxTilesX;
                        }
                        if (num147 < 0)
                        {
                            num147 = 0;
                        }
                        if (num148 > Main.maxTilesY)
                        {
                            num148 = Main.maxTilesY;
                        }
                        int num149 = ((int) this.position.X) + 4;
                        int num150 = ((int) this.position.Y) + 4;
                        for (int num151 = num145; num151 < num146; num151++)
                        {
                            for (int num152 = num147; num152 < num148; num152++)
                            {
                                if ((((Main.tile[num151, num152] != null) && Main.tile[num151, num152].active) && ((Main.tile[num151, num152].type != 0x7f) && Main.tileSolid[Main.tile[num151, num152].type])) && !Main.tileSolidTop[Main.tile[num151, num152].type])
                                {
                                    Vector2 vector17;
                                    vector17.X = num151 * 0x10;
                                    vector17.Y = num152 * 0x10;
                                    if ((((num149 + 8) > vector17.X) && (num149 < (vector17.X + 16f))) && (((num150 + 8) > vector17.Y) && (num150 < (vector17.Y + 16f))))
                                    {
                                        this.Kill();
                                    }
                                }
                            }
                        }
                        if (this.lavaWet)
                        {
                            this.Kill();
                        }
                        if (this.active)
                        {
                            int num153 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0x43, 0f, 0f, 0, new Color(), 1f);
                            Main.dust[num153].noGravity = true;
                            Dust dust17 = Main.dust[num153];
                            dust17.velocity = (Vector2) (dust17.velocity * 0.3f);
                            int num154 = (int) this.ai[0];
                            int num155 = (int) this.ai[1];
                            if (this.velocity.X > 0f)
                            {
                                this.rotation += 0.3f;
                            }
                            else
                            {
                                this.rotation -= 0.3f;
                            }
                            if (Main.myPlayer == this.owner)
                            {
                                int num156 = (int) ((this.position.X + (this.width / 2)) / 16f);
                                int num157 = (int) ((this.position.Y + (this.height / 2)) / 16f);
                                bool flag2 = false;
                                if ((num156 == num154) && (num157 == num155))
                                {
                                    flag2 = true;
                                }
                                if ((((this.velocity.X <= 0f) && (num156 <= num154)) || ((this.velocity.X >= 0f) && (num156 >= num154))) && (((this.velocity.Y <= 0f) && (num157 <= num155)) || ((this.velocity.Y >= 0f) && (num157 >= num155))))
                                {
                                    flag2 = true;
                                }
                                if (flag2)
                                {
                                    if (WorldGen.PlaceTile(num154, num155, 0x7f, false, false, this.owner, 0))
                                    {
                                        if (Main.netMode == 1)
                                        {
                                            NetMessage.SendData(0x11, -1, -1, "", 1, (float) ((int) this.ai[0]), (float) ((int) this.ai[1]), 127f, 0);
                                        }
                                        this.damage = 0;
                                        this.ai[0] = -1f;
                                        this.velocity = (Vector2) (this.velocity * 0f);
                                        this.alpha = 0xff;
                                        this.position.X = num154 * 0x10;
                                        this.position.Y = num155 * 0x10;
                                        this.netUpdate = true;
                                    }
                                    else
                                    {
                                        this.ai[1] = -1f;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (this.ai[0] == -1f)
                        {
                            for (int num140 = 0; num140 < 10; num140++)
                            {
                                color = new Color();
                                int num141 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0x43, 0f, 0f, 0, color, 1.1f);
                                Main.dust[num141].noGravity = true;
                                Dust dust15 = Main.dust[num141];
                                dust15.velocity = (Vector2) (dust15.velocity * 1.3f);
                            }
                        }
                        else if (Main.rand.Next(30) == 0)
                        {
                            int num142 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0x43, 0f, 0f, 100, new Color(), 1f);
                            Dust dust16 = Main.dust[num142];
                            dust16.velocity = (Vector2) (dust16.velocity * 0.2f);
                        }
                        int num143 = ((int) this.position.X) / 0x10;
                        int num144 = ((int) this.position.Y) / 0x10;
                        if ((Main.tile[num143, num144] == null) || !Main.tile[num143, num144].active)
                        {
                            this.Kill();
                        }
                        this.ai[0]--;
                        if (((this.ai[0] <= -300f) && ((Main.myPlayer == this.owner) || (Main.netMode == 2))) && (Main.tile[num143, num144].active && (Main.tile[num143, num144].type == 0x7f)))
                        {
                            WorldGen.KillTile(num143, num144, false, false, false);
                            if (Main.netMode == 1)
                            {
                                NetMessage.SendData(0x11, -1, -1, "", 0, (float) num143, (float) num144, 0f, 0);
                            }
                            this.Kill();
                        }
                    }
                }
                else if (this.aiStyle == 0x17)
                {
                    if (this.timeLeft > 60)
                    {
                        this.timeLeft = 60;
                    }
                    if (this.ai[0] > 7f)
                    {
                        float num158 = 1f;
                        if (this.ai[0] == 8f)
                        {
                            num158 = 0.25f;
                        }
                        else if (this.ai[0] == 9f)
                        {
                            num158 = 0.5f;
                        }
                        else if (this.ai[0] == 10f)
                        {
                            num158 = 0.75f;
                        }
                        this.ai[0]++;
                        int num159 = 6;
                        if (this.type == 0x65)
                        {
                            num159 = 0x4b;
                        }
                        if ((num159 == 6) || (Main.rand.Next(2) == 0))
                        {
                            for (int num160 = 0; num160 < 1; num160++)
                            {
                                color = new Color();
                                int num161 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, num159, this.velocity.X * 0.2f, this.velocity.Y * 0.2f, 100, color, 1f);
                                if ((Main.rand.Next(3) != 0) || ((num159 == 0x4b) && (Main.rand.Next(3) == 0)))
                                {
                                    Main.dust[num161].noGravity = true;
                                    Dust dust18 = Main.dust[num161];
                                    dust18.scale *= 3f;
                                    Main.dust[num161].velocity.X *= 2f;
                                    Main.dust[num161].velocity.Y *= 2f;
                                }
                                Dust dust19 = Main.dust[num161];
                                dust19.scale *= 1.5f;
                                Main.dust[num161].velocity.X *= 1.2f;
                                Main.dust[num161].velocity.Y *= 1.2f;
                                Dust dust20 = Main.dust[num161];
                                dust20.scale *= num158;
                                if (num159 == 0x4b)
                                {
                                    Dust dust21 = Main.dust[num161];
                                    dust21.velocity += this.velocity;
                                    if (!Main.dust[num161].noGravity)
                                    {
                                        Dust dust22 = Main.dust[num161];
                                        dust22.velocity = (Vector2) (dust22.velocity * 0.5f);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        this.ai[0]++;
                    }
                    this.rotation += 0.3f * this.direction;
                }
                else if (this.aiStyle == 0x18)
                {
                    this.light = this.scale * 0.5f;
                    this.rotation += this.velocity.X * 0.2f;
                    this.ai[1]++;
                    if (this.type != 0x5e)
                    {
                        this.velocity = (Vector2) (this.velocity * 0.96f);
                        if (this.ai[1] > 15f)
                        {
                            this.scale -= 0.05f;
                            if (this.scale <= 0.2)
                            {
                                this.scale = 0.2f;
                                this.Kill();
                            }
                        }
                    }
                    else
                    {
                        if (Main.rand.Next(4) == 0)
                        {
                            int num162 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 70, 0f, 0f, 0, new Color(), 1f);
                            Main.dust[num162].noGravity = true;
                            Dust dust23 = Main.dust[num162];
                            dust23.velocity = (Vector2) (dust23.velocity * 0.5f);
                            Dust dust24 = Main.dust[num162];
                            dust24.scale *= 0.9f;
                        }
                        this.velocity = (Vector2) (this.velocity * 0.985f);
                        if (this.ai[1] > 130f)
                        {
                            this.scale -= 0.05f;
                            if (this.scale <= 0.2)
                            {
                                this.scale = 0.2f;
                                this.Kill();
                            }
                        }
                    }
                }
                else if (this.aiStyle == 0x19)
                {
                    if (((this.ai[0] != 0f) && (this.velocity.Y <= 0f)) && (this.velocity.X == 0f))
                    {
                        float num163 = 0.5f;
                        int num164 = (int) ((this.position.X - 8f) / 16f);
                        int num165 = (int) (this.position.Y / 16f);
                        bool flag3 = false;
                        bool flag4 = false;
                        if (WorldGen.SolidTile(num164, num165) || WorldGen.SolidTile(num164, num165 + 1))
                        {
                            flag3 = true;
                        }
                        num164 = (int) (((this.position.X + this.width) + 8f) / 16f);
                        if (WorldGen.SolidTile(num164, num165) || WorldGen.SolidTile(num164, num165 + 1))
                        {
                            flag4 = true;
                        }
                        if (flag3)
                        {
                            this.velocity.X = num163;
                        }
                        else if (flag4)
                        {
                            this.velocity.X = -num163;
                        }
                        else
                        {
                            num164 = (int) (((this.position.X - 8f) - 16f) / 16f);
                            num165 = (int) (this.position.Y / 16f);
                            flag3 = false;
                            flag4 = false;
                            if (WorldGen.SolidTile(num164, num165) || WorldGen.SolidTile(num164, num165 + 1))
                            {
                                flag3 = true;
                            }
                            num164 = (int) ((((this.position.X + this.width) + 8f) + 16f) / 16f);
                            if (WorldGen.SolidTile(num164, num165) || WorldGen.SolidTile(num164, num165 + 1))
                            {
                                flag4 = true;
                            }
                            if (flag3)
                            {
                                this.velocity.X = num163;
                            }
                            else if (flag4)
                            {
                                this.velocity.X = -num163;
                            }
                            else
                            {
                                num164 = (int) ((this.position.X + 4f) / 16f);
                                num165 = (int) (((this.position.Y + this.height) + 8f) / 16f);
                                if (WorldGen.SolidTile(num164, num165) || WorldGen.SolidTile(num164, num165 + 1))
                                {
                                    flag3 = true;
                                }
                                if (!flag3)
                                {
                                    this.velocity.X = num163;
                                }
                                else
                                {
                                    this.velocity.X = -num163;
                                }
                            }
                        }
                    }
                    this.rotation += this.velocity.X * 0.06f;
                    this.ai[0] = 1f;
                    if (this.velocity.Y > 16f)
                    {
                        this.velocity.Y = 16f;
                    }
                    if (this.velocity.Y <= 6f)
                    {
                        if ((this.velocity.X > 0f) && (this.velocity.X < 7f))
                        {
                            this.velocity.X += 0.05f;
                        }
                        if ((this.velocity.X < 0f) && (this.velocity.X > -7f))
                        {
                            this.velocity.X -= 0.05f;
                        }
                    }
                    this.velocity.Y += 0.3f;
                }
            }
            else
            {
                if (this.soundDelay == 0)
                {
                    this.soundDelay = 8;
                    Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 7);
                }
                if (this.type == 0x13)
                {
                    for (int num6 = 0; num6 < 2; num6++)
                    {
                        color = new Color();
                        int num7 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, this.velocity.X * 0.2f, this.velocity.Y * 0.2f, 100, color, 2f);
                        Main.dust[num7].noGravity = true;
                        Main.dust[num7].velocity.X *= 0.3f;
                        Main.dust[num7].velocity.Y *= 0.3f;
                    }
                }
                else if (this.type == 0x21)
                {
                    if (Main.rand.Next(1) == 0)
                    {
                        int num8 = Dust.NewDust(this.position, this.width, this.height, 40, this.velocity.X * 0.25f, this.velocity.Y * 0.25f, 0, new Color(), 1.4f);
                        Main.dust[num8].noGravity = true;
                    }
                }
                else if ((this.type == 6) && (Main.rand.Next(5) == 0))
                {
                    int num9 = Main.rand.Next(3);
                    switch (num9)
                    {
                        case 0:
                            num9 = 15;
                            break;

                        case 1:
                            num9 = 0x39;
                            break;

                        default:
                            num9 = 0x3a;
                            break;
                    }
                    Dust.NewDust(this.position, this.width, this.height, num9, this.velocity.X * 0.25f, this.velocity.Y * 0.25f, 150, new Color(), 0.7f);
                }
                if (this.ai[0] == 0f)
                {
                    this.ai[1]++;
                    if (this.type == 0x6a)
                    {
                        if (this.ai[1] >= 45f)
                        {
                            this.ai[0] = 1f;
                            this.ai[1] = 0f;
                            this.netUpdate = true;
                        }
                    }
                    else if (this.ai[1] >= 30f)
                    {
                        this.ai[0] = 1f;
                        this.ai[1] = 0f;
                        this.netUpdate = true;
                    }
                }
                else
                {
                    this.tileCollide = false;
                    float num10 = 9f;
                    float num11 = 0.4f;
                    if (this.type == 0x13)
                    {
                        num10 = 13f;
                        num11 = 0.6f;
                    }
                    else if (this.type == 0x21)
                    {
                        num10 = 15f;
                        num11 = 0.8f;
                    }
                    else if (this.type == 0x6a)
                    {
                        num10 = 16f;
                        num11 = 1.2f;
                    }
                    Vector2 vector = new Vector2(this.position.X + (this.width * 0.5f), this.position.Y + (this.height * 0.5f));
                    float num12 = (Main.player[this.owner].position.X + (Main.player[this.owner].width / 2)) - vector.X;
                    float num13 = (Main.player[this.owner].position.Y + (Main.player[this.owner].height / 2)) - vector.Y;
                    float num14 = (float) Math.Sqrt((double) ((num12 * num12) + (num13 * num13)));
                    if (num14 > 3000f)
                    {
                        this.Kill();
                    }
                    num14 = num10 / num14;
                    num12 *= num14;
                    num13 *= num14;
                    if (this.velocity.X < num12)
                    {
                        this.velocity.X += num11;
                        if ((this.velocity.X < 0f) && (num12 > 0f))
                        {
                            this.velocity.X += num11;
                        }
                    }
                    else if (this.velocity.X > num12)
                    {
                        this.velocity.X -= num11;
                        if ((this.velocity.X > 0f) && (num12 < 0f))
                        {
                            this.velocity.X -= num11;
                        }
                    }
                    if (this.velocity.Y < num13)
                    {
                        this.velocity.Y += num11;
                        if ((this.velocity.Y < 0f) && (num13 > 0f))
                        {
                            this.velocity.Y += num11;
                        }
                    }
                    else if (this.velocity.Y > num13)
                    {
                        this.velocity.Y -= num11;
                        if ((this.velocity.Y > 0f) && (num13 < 0f))
                        {
                            this.velocity.Y -= num11;
                        }
                    }
                    if (Main.myPlayer == this.owner)
                    {
                        Rectangle rectangle = new Rectangle((int) this.position.X, (int) this.position.Y, this.width, this.height);
                        Rectangle rectangle2 = new Rectangle((int) Main.player[this.owner].position.X, (int) Main.player[this.owner].position.Y, Main.player[this.owner].width, Main.player[this.owner].height);
                        if (rectangle.Intersects(rectangle2))
                        {
                            this.Kill();
                        }
                    }
                }
                if (this.type == 0x6a)
                {
                    this.rotation += 0.3f * this.direction;
                }
                else
                {
                    this.rotation += 0.4f * this.direction;
                }
            }
        }

        public void Damage()
        {
            if (((this.type != 0x12) && (this.type != 0x48)) && ((this.type != 0x56) && (this.type != 0x57)))
            {
                Rectangle rectangle = new Rectangle((int) this.position.X, (int) this.position.Y, this.width, this.height);
                if ((this.type == 0x55) || (this.type == 0x65))
                {
                    int num = 30;
                    rectangle.X -= num;
                    rectangle.Y -= num;
                    rectangle.Width += num * 2;
                    rectangle.Height += num * 2;
                }
                if (this.friendly && (this.owner == Main.myPlayer))
                {
                    if (((this.aiStyle == 0x10) || (this.type == 0x29)) && ((this.timeLeft <= 1) || (this.type == 0x6c)))
                    {
                        int myPlayer = Main.myPlayer;
                        if (((Main.player[myPlayer].active && !Main.player[myPlayer].dead) && !Main.player[myPlayer].immune) && (!this.ownerHitCheck || Collision.CanHit(Main.player[this.owner].position, Main.player[this.owner].width, Main.player[this.owner].height, Main.player[myPlayer].position, Main.player[myPlayer].width, Main.player[myPlayer].height)))
                        {
                            Rectangle rectangle2 = new Rectangle((int) Main.player[myPlayer].position.X, (int) Main.player[myPlayer].position.Y, Main.player[myPlayer].width, Main.player[myPlayer].height);
                            if (rectangle.Intersects(rectangle2))
                            {
                                if ((Main.player[myPlayer].position.X + (Main.player[myPlayer].width / 2)) < (this.position.X + (this.width / 2)))
                                {
                                    this.direction = -1;
                                }
                                else
                                {
                                    this.direction = 1;
                                }
                                int damage = Main.DamageVar((float) this.damage);
                                this.StatusPlayer(myPlayer);
                                Main.player[myPlayer].Hurt(damage, this.direction, true, false, Player.getDeathMessage(this.owner, -1, this.whoAmI, -1), false);
                                if (Main.netMode != 0)
                                {
                                    NetMessage.SendData(0x1a, -1, -1, Player.getDeathMessage(this.owner, -1, this.whoAmI, -1), myPlayer, (float) this.direction, (float) damage, 1f, 0);
                                }
                            }
                        }
                    }
                    if (((this.type != 0x45) && (this.type != 70)) && ((this.type != 10) && (this.type != 11)))
                    {
                        int num4 = (int) (this.position.X / 16f);
                        int maxTilesX = ((int) ((this.position.X + this.width) / 16f)) + 1;
                        int num6 = (int) (this.position.Y / 16f);
                        int maxTilesY = ((int) ((this.position.Y + this.height) / 16f)) + 1;
                        if (num4 < 0)
                        {
                            num4 = 0;
                        }
                        if (maxTilesX > Main.maxTilesX)
                        {
                            maxTilesX = Main.maxTilesX;
                        }
                        if (num6 < 0)
                        {
                            num6 = 0;
                        }
                        if (maxTilesY > Main.maxTilesY)
                        {
                            maxTilesY = Main.maxTilesY;
                        }
                        for (int i = num4; i < maxTilesX; i++)
                        {
                            for (int j = num6; j < maxTilesY; j++)
                            {
                                if (((Main.tile[i, j] != null) && Main.tileCut[Main.tile[i, j].type]) && ((Main.tile[i, j + 1] != null) && (Main.tile[i, j + 1].type != 0x4e)))
                                {
                                    WorldGen.KillTile(i, j, false, false, false);
                                    if (Main.netMode != 0)
                                    {
                                        NetMessage.SendData(0x11, -1, -1, "", 0, (float) i, (float) j, 0f, 0);
                                    }
                                }
                            }
                        }
                    }
                }
                if (this.owner == Main.myPlayer)
                {
                    if (this.damage > 0)
                    {
                        for (int k = 0; k < 200; k++)
                        {
                            if (((Main.npc[k].active && !Main.npc[k].dontTakeDamage) && (((!Main.npc[k].friendly || (((Main.npc[k].type == 0x16) && (this.owner < 0xff)) && Main.player[this.owner].killGuide)) && this.friendly) || (Main.npc[k].friendly && this.hostile))) && ((this.owner < 0) || (Main.npc[k].immune[this.owner] == 0)))
                            {
                                bool flag = false;
                                if ((this.type == 11) && ((Main.npc[k].type == 0x2f) || (Main.npc[k].type == 0x39)))
                                {
                                    flag = true;
                                }
                                else if ((this.type == 0x1f) && (Main.npc[k].type == 0x45))
                                {
                                    flag = true;
                                }
                                if (!flag && ((Main.npc[k].noTileCollide || !this.ownerHitCheck) || Collision.CanHit(Main.player[this.owner].position, Main.player[this.owner].width, Main.player[this.owner].height, Main.npc[k].position, Main.npc[k].width, Main.npc[k].height)))
                                {
                                    Rectangle rectangle3 = new Rectangle((int) Main.npc[k].position.X, (int) Main.npc[k].position.Y, Main.npc[k].width, Main.npc[k].height);
                                    if (rectangle.Intersects(rectangle3))
                                    {
                                        if (this.aiStyle == 3)
                                        {
                                            if (this.ai[0] == 0f)
                                            {
                                                this.velocity.X = -this.velocity.X;
                                                this.velocity.Y = -this.velocity.Y;
                                                this.netUpdate = true;
                                            }
                                            this.ai[0] = 1f;
                                        }
                                        else if (this.aiStyle == 0x10)
                                        {
                                            if (this.timeLeft > 3)
                                            {
                                                this.timeLeft = 3;
                                            }
                                            if ((Main.npc[k].position.X + (Main.npc[k].width / 2)) < (this.position.X + (this.width / 2)))
                                            {
                                                this.direction = -1;
                                            }
                                            else
                                            {
                                                this.direction = 1;
                                            }
                                        }
                                        if ((this.type == 0x29) && (this.timeLeft > 1))
                                        {
                                            this.timeLeft = 1;
                                        }
                                        bool crit = false;
                                        if (this.melee && (Main.rand.Next(1, 0x65) <= Main.player[this.owner].meleeCrit))
                                        {
                                            crit = true;
                                        }
                                        if (this.ranged && (Main.rand.Next(1, 0x65) <= Main.player[this.owner].rangedCrit))
                                        {
                                            crit = true;
                                        }
                                        if (this.magic && (Main.rand.Next(1, 0x65) <= Main.player[this.owner].magicCrit))
                                        {
                                            crit = true;
                                        }
                                        int num11 = Main.DamageVar((float) this.damage);
                                        this.StatusNPC(k);
                                        Main.npc[k].StrikeNPC(num11, this.knockBack, this.direction, crit, false);
                                        if (Main.netMode != 0)
                                        {
                                            if (crit)
                                            {
                                                NetMessage.SendData(0x1c, -1, -1, "", k, (float) num11, this.knockBack, (float) this.direction, 1);
                                            }
                                            else
                                            {
                                                NetMessage.SendData(0x1c, -1, -1, "", k, (float) num11, this.knockBack, (float) this.direction, 0);
                                            }
                                        }
                                        if (this.penetrate != 1)
                                        {
                                            Main.npc[k].immune[this.owner] = 10;
                                        }
                                        if (this.penetrate > 0)
                                        {
                                            this.penetrate--;
                                            if (this.penetrate == 0)
                                            {
                                                break;
                                            }
                                        }
                                        if (this.aiStyle == 7)
                                        {
                                            this.ai[0] = 1f;
                                            this.damage = 0;
                                            this.netUpdate = true;
                                        }
                                        else if (this.aiStyle == 13)
                                        {
                                            this.ai[0] = 1f;
                                            this.netUpdate = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if ((this.damage > 0) && Main.player[Main.myPlayer].hostile)
                    {
                        for (int m = 0; m < 0xff; m++)
                        {
                            if (((((m != this.owner) && Main.player[m].active) && (!Main.player[m].dead && !Main.player[m].immune)) && ((Main.player[m].hostile && (this.playerImmune[m] <= 0)) && ((Main.player[Main.myPlayer].team == 0) || (Main.player[Main.myPlayer].team != Main.player[m].team)))) && (!this.ownerHitCheck || Collision.CanHit(Main.player[this.owner].position, Main.player[this.owner].width, Main.player[this.owner].height, Main.player[m].position, Main.player[m].width, Main.player[m].height)))
                            {
                                Rectangle rectangle4 = new Rectangle((int) Main.player[m].position.X, (int) Main.player[m].position.Y, Main.player[m].width, Main.player[m].height);
                                if (rectangle.Intersects(rectangle4))
                                {
                                    if (this.aiStyle == 3)
                                    {
                                        if (this.ai[0] == 0f)
                                        {
                                            this.velocity.X = -this.velocity.X;
                                            this.velocity.Y = -this.velocity.Y;
                                            this.netUpdate = true;
                                        }
                                        this.ai[0] = 1f;
                                    }
                                    else if (this.aiStyle == 0x10)
                                    {
                                        if (this.timeLeft > 3)
                                        {
                                            this.timeLeft = 3;
                                        }
                                        if ((Main.player[m].position.X + (Main.player[m].width / 2)) < (this.position.X + (this.width / 2)))
                                        {
                                            this.direction = -1;
                                        }
                                        else
                                        {
                                            this.direction = 1;
                                        }
                                    }
                                    if ((this.type == 0x29) && (this.timeLeft > 1))
                                    {
                                        this.timeLeft = 1;
                                    }
                                    bool flag3 = false;
                                    if (this.melee && (Main.rand.Next(1, 0x65) <= Main.player[this.owner].meleeCrit))
                                    {
                                        flag3 = true;
                                    }
                                    int num13 = Main.DamageVar((float) this.damage);
                                    if (!Main.player[m].immune)
                                    {
                                        this.StatusPvP(m);
                                    }
                                    Main.player[m].Hurt(num13, this.direction, true, false, Player.getDeathMessage(this.owner, -1, this.whoAmI, -1), flag3);
                                    if (Main.netMode != 0)
                                    {
                                        if (flag3)
                                        {
                                            NetMessage.SendData(0x1a, -1, -1, Player.getDeathMessage(this.owner, -1, this.whoAmI, -1), m, (float) this.direction, (float) num13, 1f, 1);
                                        }
                                        else
                                        {
                                            NetMessage.SendData(0x1a, -1, -1, Player.getDeathMessage(this.owner, -1, this.whoAmI, -1), m, (float) this.direction, (float) num13, 1f, 0);
                                        }
                                    }
                                    this.playerImmune[m] = 40;
                                    if (this.penetrate > 0)
                                    {
                                        this.penetrate--;
                                        if (this.penetrate == 0)
                                        {
                                            break;
                                        }
                                    }
                                    if (this.aiStyle == 7)
                                    {
                                        this.ai[0] = 1f;
                                        this.damage = 0;
                                        this.netUpdate = true;
                                    }
                                    else if (this.aiStyle == 13)
                                    {
                                        this.ai[0] = 1f;
                                        this.netUpdate = true;
                                    }
                                }
                            }
                        }
                    }
                }
                if ((this.type == 11) && (Main.netMode != 1))
                {
                    for (int n = 0; n < 200; n++)
                    {
                        if (Main.npc[n].active)
                        {
                            if (Main.npc[n].type == 0x2e)
                            {
                                Rectangle rectangle5 = new Rectangle((int) Main.npc[n].position.X, (int) Main.npc[n].position.Y, Main.npc[n].width, Main.npc[n].height);
                                if (rectangle.Intersects(rectangle5))
                                {
                                    Main.npc[n].Transform(0x2f);
                                }
                            }
                            else if (Main.npc[n].type == 0x37)
                            {
                                Rectangle rectangle6 = new Rectangle((int) Main.npc[n].position.X, (int) Main.npc[n].position.Y, Main.npc[n].width, Main.npc[n].height);
                                if (rectangle.Intersects(rectangle6))
                                {
                                    Main.npc[n].Transform(0x39);
                                }
                            }
                        }
                    }
                }
                if (((Main.netMode != 2) && this.hostile) && ((Main.myPlayer < 0xff) && (this.damage > 0)))
                {
                    int index = Main.myPlayer;
                    if ((Main.player[index].active && !Main.player[index].dead) && !Main.player[index].immune)
                    {
                        Rectangle rectangle7 = new Rectangle((int) Main.player[index].position.X, (int) Main.player[index].position.Y, Main.player[index].width, Main.player[index].height);
                        if (rectangle.Intersects(rectangle7))
                        {
                            int direction = this.direction;
                            if ((Main.player[index].position.X + (Main.player[index].width / 2)) < (this.position.X + (this.width / 2)))
                            {
                                direction = -1;
                            }
                            else
                            {
                                direction = 1;
                            }
                            int num17 = Main.DamageVar((float) this.damage);
                            if (!Main.player[index].immune)
                            {
                                this.StatusPlayer(index);
                            }
                            Main.player[index].Hurt(num17 * 2, direction, false, false, Player.getDeathMessage(-1, -1, this.whoAmI, -1), false);
                        }
                    }
                }
            }
        }

        public Color GetAlpha(Color newColor)
        {
            int discoR;
            int discoG;
            int discoB;
            if ((((this.type == 0x22) || (this.type == 15)) || ((this.type == 0x5d) || (this.type == 0x5e))) || (((this.type == 0x5f) || (this.type == 0x60)) || ((this.type == 0x66) && (this.alpha < 0xff))))
            {
                return new Color(200, 200, 200, 0x19);
            }
            if ((((this.type == 0x53) || (this.type == 0x58)) || ((this.type == 0x59) || (this.type == 90))) || ((this.type == 100) || (this.type == 0x68)))
            {
                if (this.alpha < 200)
                {
                    return new Color(0xff - this.alpha, 0xff - this.alpha, 0xff - this.alpha, 0);
                }
                return new Color(0, 0, 0, 0);
            }
            if ((((this.type == 0x22) || (this.type == 0x23)) || ((this.type == 15) || (this.type == 0x13))) || ((this.type == 0x2c) || (this.type == 0x2d)))
            {
                return Color.White;
            }
            if (this.type == 0x4f)
            {
                discoR = Main.DiscoR;
                discoG = Main.DiscoG;
                discoB = Main.DiscoB;
                return new Color();
            }
            if ((((this.type == 9) || (this.type == 15)) || ((this.type == 0x22) || (this.type == 50))) || ((((this.type == 0x35) || (this.type == 0x4c)) || ((this.type == 0x4d) || (this.type == 0x4e))) || ((this.type == 0x5c) || (this.type == 0x5b))))
            {
                discoR = newColor.R - (this.alpha / 3);
                discoG = newColor.G - (this.alpha / 3);
                discoB = newColor.B - (this.alpha / 3);
            }
            else if (((this.type == 0x10) || (this.type == 0x12)) || ((this.type == 0x2c) || (this.type == 0x2d)))
            {
                discoR = newColor.R;
                discoG = newColor.G;
                discoB = newColor.B;
            }
            else
            {
                if (((this.type == 12) || (this.type == 0x48)) || ((this.type == 0x56) || (this.type == 0x57)))
                {
                    return new Color(0xff, 0xff, 0xff, newColor.A - this.alpha);
                }
                discoR = newColor.R - this.alpha;
                discoG = newColor.G - this.alpha;
                discoB = newColor.B - this.alpha;
            }
            int a = newColor.A - this.alpha;
            if (a < 0)
            {
                a = 0;
            }
            if (a > 0xff)
            {
                a = 0xff;
            }
            return new Color(discoR, discoG, discoB, a);
        }

        public void Kill()
        {
            if (this.active)
            {
                Color color;
                this.timeLeft = 0;
                if (((this.type == 1) || (this.type == 0x51)) || (this.type == 0x62))
                {
                    Main.PlaySound(0, (int) this.position.X, (int) this.position.Y, 1);
                    for (int i = 0; i < 10; i++)
                    {
                        color = new Color();
                        Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 7, 0f, 0f, 0, color, 1f);
                    }
                }
                else if (this.type == 0x5d)
                {
                    Main.PlaySound(0, (int) this.position.X, (int) this.position.Y, 1);
                    for (int j = 0; j < 10; j++)
                    {
                        color = new Color();
                        int index = Dust.NewDust(this.position, this.width, this.height, 0x39, 0f, 0f, 100, color, 0.5f);
                        Main.dust[index].velocity.X *= 2f;
                        Main.dust[index].velocity.Y *= 2f;
                    }
                }
                else if (this.type == 0x63)
                {
                    Main.PlaySound(0, (int) this.position.X, (int) this.position.Y, 1);
                    for (int k = 0; k < 30; k++)
                    {
                        color = new Color();
                        int num5 = Dust.NewDust(this.position, this.width, this.height, 1, 0f, 0f, 0, color, 1f);
                        if (Main.rand.Next(2) == 0)
                        {
                            Dust dust1 = Main.dust[num5];
                            dust1.scale *= 1.4f;
                        }
                        this.velocity = (Vector2) (this.velocity * 1.9f);
                    }
                }
                else if ((this.type == 0x5b) || (this.type == 0x5c))
                {
                    Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 10);
                    for (int m = 0; m < 10; m++)
                    {
                        color = new Color();
                        Dust.NewDust(this.position, this.width, this.height, 0x3a, this.velocity.X * 0.1f, this.velocity.Y * 0.1f, 150, color, 1.2f);
                    }
                    for (int n = 0; n < 3; n++)
                    {
                        Gore.NewGore(this.position, new Vector2(this.velocity.X * 0.05f, this.velocity.Y * 0.05f), Main.rand.Next(0x10, 0x12), 1f);
                    }
                    if ((this.type == 12) && (this.damage < 100))
                    {
                        for (int num8 = 0; num8 < 10; num8++)
                        {
                            color = new Color();
                            Dust.NewDust(this.position, this.width, this.height, 0x39, this.velocity.X * 0.1f, this.velocity.Y * 0.1f, 150, color, 1.2f);
                        }
                        for (int num9 = 0; num9 < 3; num9++)
                        {
                            Gore.NewGore(this.position, new Vector2(this.velocity.X * 0.05f, this.velocity.Y * 0.05f), Main.rand.Next(0x10, 0x12), 1f);
                        }
                    }
                    if (((this.type == 0x5b) || ((this.type == 0x5c) && (this.ai[0] > 0f))) && (this.owner == Main.myPlayer))
                    {
                        float x = this.position.X + Main.rand.Next(-400, 400);
                        float y = this.position.Y - Main.rand.Next(600, 900);
                        Vector2 vector = new Vector2(x, y);
                        float speedX = (this.position.X + (this.width / 2)) - vector.X;
                        float speedY = (this.position.Y + (this.height / 2)) - vector.Y;
                        int num14 = 0x16;
                        float num15 = (float) Math.Sqrt((double) ((speedX * speedX) + (speedY * speedY)));
                        num15 = ((float) num14) / num15;
                        speedX *= num15;
                        speedY *= num15;
                        int damage = this.damage;
                        if (this.type == 0x5b)
                        {
                            damage = (int) (damage * 0.5f);
                        }
                        int num17 = NewProjectile(x, y, speedX, speedY, 0x5c, damage, this.knockBack, this.owner);
                        if (this.type == 0x5b)
                        {
                            Main.projectile[num17].ai[1] = this.position.Y;
                            Main.projectile[num17].ai[0] = 1f;
                        }
                        else
                        {
                            Main.projectile[num17].ai[1] = this.position.Y;
                        }
                    }
                }
                else if (this.type == 0x59)
                {
                    Main.PlaySound(0, (int) this.position.X, (int) this.position.Y, 1);
                    for (int num18 = 0; num18 < 5; num18++)
                    {
                        color = new Color();
                        int num19 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0x44, 0f, 0f, 0, color, 1f);
                        Main.dust[num19].noGravity = true;
                        Dust dust2 = Main.dust[num19];
                        dust2.velocity = (Vector2) (dust2.velocity * 1.5f);
                        Dust dust3 = Main.dust[num19];
                        dust3.scale *= 0.9f;
                    }
                    if ((this.type == 0x59) && (this.owner == Main.myPlayer))
                    {
                        for (int num20 = 0; num20 < 3; num20++)
                        {
                            float num21 = ((-this.velocity.X * Main.rand.Next(40, 70)) * 0.01f) + (Main.rand.Next(-20, 0x15) * 0.4f);
                            float num22 = ((-this.velocity.Y * Main.rand.Next(40, 70)) * 0.01f) + (Main.rand.Next(-20, 0x15) * 0.4f);
                            NewProjectile(this.position.X + num21, this.position.Y + num22, num21, num22, 90, (int) (this.damage * 0.6), 0f, this.owner);
                        }
                    }
                }
                else if (this.type == 80)
                {
                    if (this.ai[0] >= 0f)
                    {
                        Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 0x1b);
                        for (int num23 = 0; num23 < 10; num23++)
                        {
                            color = new Color();
                            Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0x43, 0f, 0f, 0, color, 1f);
                        }
                    }
                    int num24 = ((int) this.position.X) / 0x10;
                    int num25 = ((int) this.position.Y) / 0x10;
                    if (Main.tile[num24, num25] == null)
                    {
                        Main.tile[num24, num25] = new Tile();
                    }
                    if ((Main.tile[num24, num25].type == 0x7f) && Main.tile[num24, num25].active)
                    {
                        WorldGen.KillTile(num24, num25, false, false, false);
                    }
                }
                else if (((this.type == 0x4c) || (this.type == 0x4d)) || (this.type == 0x4e))
                {
                    for (int num26 = 0; num26 < 5; num26++)
                    {
                        color = new Color();
                        int num27 = Dust.NewDust(this.position, this.width, this.height, 0x1b, 0f, 0f, 80, color, 1.5f);
                        Main.dust[num27].noGravity = true;
                    }
                }
                else if (this.type == 0x37)
                {
                    for (int num28 = 0; num28 < 5; num28++)
                    {
                        color = new Color();
                        int num29 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0x12, 0f, 0f, 0, color, 1.5f);
                        Main.dust[num29].noGravity = true;
                    }
                }
                else if (this.type == 0x33)
                {
                    Main.PlaySound(0, (int) this.position.X, (int) this.position.Y, 1);
                    for (int num30 = 0; num30 < 5; num30++)
                    {
                        color = new Color();
                        Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0, 0f, 0f, 0, color, 0.7f);
                    }
                }
                else if ((this.type == 2) || (this.type == 0x52))
                {
                    Main.PlaySound(0, (int) this.position.X, (int) this.position.Y, 1);
                    for (int num31 = 0; num31 < 20; num31++)
                    {
                        color = new Color();
                        Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, color, 1f);
                    }
                }
                else if (this.type == 0x67)
                {
                    Main.PlaySound(0, (int) this.position.X, (int) this.position.Y, 1);
                    for (int num32 = 0; num32 < 20; num32++)
                    {
                        color = new Color();
                        int num33 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0x4b, 0f, 0f, 100, color, 1f);
                        if (Main.rand.Next(2) == 0)
                        {
                            Dust dust4 = Main.dust[num33];
                            dust4.scale *= 2.5f;
                            Main.dust[num33].noGravity = true;
                            Dust dust5 = Main.dust[num33];
                            dust5.velocity = (Vector2) (dust5.velocity * 5f);
                        }
                    }
                }
                else if (((this.type == 3) || (this.type == 0x30)) || (this.type == 0x36))
                {
                    Main.PlaySound(0, (int) this.position.X, (int) this.position.Y, 1);
                    for (int num34 = 0; num34 < 10; num34++)
                    {
                        color = new Color();
                        Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 1, this.velocity.X * 0.1f, this.velocity.Y * 0.1f, 0, color, 0.75f);
                    }
                }
                else if (this.type == 4)
                {
                    Main.PlaySound(0, (int) this.position.X, (int) this.position.Y, 1);
                    for (int num35 = 0; num35 < 10; num35++)
                    {
                        color = new Color();
                        Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 14, 0f, 0f, 150, color, 1.1f);
                    }
                }
                else if (this.type == 5)
                {
                    Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 10);
                    for (int num36 = 0; num36 < 60; num36++)
                    {
                        int type = Main.rand.Next(3);
                        switch (type)
                        {
                            case 0:
                                type = 15;
                                break;

                            case 1:
                                type = 0x39;
                                break;

                            default:
                                type = 0x3a;
                                break;
                        }
                        color = new Color();
                        Dust.NewDust(this.position, this.width, this.height, type, this.velocity.X * 0.5f, this.velocity.Y * 0.5f, 150, color, 1.5f);
                    }
                }
                else if ((this.type == 9) || (this.type == 12))
                {
                    Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 10);
                    for (int num38 = 0; num38 < 10; num38++)
                    {
                        color = new Color();
                        Dust.NewDust(this.position, this.width, this.height, 0x3a, this.velocity.X * 0.1f, this.velocity.Y * 0.1f, 150, color, 1.2f);
                    }
                    for (int num39 = 0; num39 < 3; num39++)
                    {
                        Gore.NewGore(this.position, new Vector2(this.velocity.X * 0.05f, this.velocity.Y * 0.05f), Main.rand.Next(0x10, 0x12), 1f);
                    }
                    if ((this.type == 12) && (this.damage < 100))
                    {
                        for (int num40 = 0; num40 < 10; num40++)
                        {
                            color = new Color();
                            Dust.NewDust(this.position, this.width, this.height, 0x39, this.velocity.X * 0.1f, this.velocity.Y * 0.1f, 150, color, 1.2f);
                        }
                        for (int num41 = 0; num41 < 3; num41++)
                        {
                            Gore.NewGore(this.position, new Vector2(this.velocity.X * 0.05f, this.velocity.Y * 0.05f), Main.rand.Next(0x10, 0x12), 1f);
                        }
                    }
                }
                else if ((((this.type == 14) || (this.type == 20)) || ((this.type == 0x24) || (this.type == 0x53))) || ((this.type == 0x54) || (this.type == 100)))
                {
                    Collision.HitTiles(this.position, this.velocity, this.width, this.height);
                    Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 10);
                }
                else if ((this.type == 15) || (this.type == 0x22))
                {
                    Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 10);
                    for (int num42 = 0; num42 < 20; num42++)
                    {
                        color = new Color();
                        int num43 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, -this.velocity.X * 0.2f, -this.velocity.Y * 0.2f, 100, color, 2f);
                        Main.dust[num43].noGravity = true;
                        Dust dust6 = Main.dust[num43];
                        dust6.velocity = (Vector2) (dust6.velocity * 2f);
                        color = new Color();
                        num43 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, -this.velocity.X * 0.2f, -this.velocity.Y * 0.2f, 100, color, 1f);
                        Dust dust7 = Main.dust[num43];
                        dust7.velocity = (Vector2) (dust7.velocity * 2f);
                    }
                }
                else if ((this.type == 0x5f) || (this.type == 0x60))
                {
                    Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 10);
                    for (int num44 = 0; num44 < 20; num44++)
                    {
                        color = new Color();
                        int num45 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0x4b, -this.velocity.X * 0.2f, -this.velocity.Y * 0.2f, 100, color, 2f * this.scale);
                        Main.dust[num45].noGravity = true;
                        Dust dust8 = Main.dust[num45];
                        dust8.velocity = (Vector2) (dust8.velocity * 2f);
                        color = new Color();
                        num45 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0x4b, -this.velocity.X * 0.2f, -this.velocity.Y * 0.2f, 100, color, 1f * this.scale);
                        Dust dust9 = Main.dust[num45];
                        dust9.velocity = (Vector2) (dust9.velocity * 2f);
                    }
                }
                else if (this.type == 0x4f)
                {
                    Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 10);
                    for (int num46 = 0; num46 < 20; num46++)
                    {
                        int num47 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0x42, 0f, 0f, 100, new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB), 2f);
                        Main.dust[num47].noGravity = true;
                        Dust dust10 = Main.dust[num47];
                        dust10.velocity = (Vector2) (dust10.velocity * 4f);
                    }
                }
                else if (this.type == 0x10)
                {
                    Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 10);
                    for (int num48 = 0; num48 < 20; num48++)
                    {
                        color = new Color();
                        int num49 = Dust.NewDust(new Vector2(this.position.X - this.velocity.X, this.position.Y - this.velocity.Y), this.width, this.height, 15, 0f, 0f, 100, color, 2f);
                        Main.dust[num49].noGravity = true;
                        Dust dust11 = Main.dust[num49];
                        dust11.velocity = (Vector2) (dust11.velocity * 2f);
                        color = new Color();
                        num49 = Dust.NewDust(new Vector2(this.position.X - this.velocity.X, this.position.Y - this.velocity.Y), this.width, this.height, 15, 0f, 0f, 100, color, 1f);
                    }
                }
                else if (this.type == 0x11)
                {
                    Main.PlaySound(0, (int) this.position.X, (int) this.position.Y, 1);
                    for (int num50 = 0; num50 < 5; num50++)
                    {
                        color = new Color();
                        Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0, 0f, 0f, 0, color, 1f);
                    }
                }
                else if ((this.type == 0x1f) || (this.type == 0x2a))
                {
                    Main.PlaySound(0, (int) this.position.X, (int) this.position.Y, 1);
                    for (int num51 = 0; num51 < 5; num51++)
                    {
                        color = new Color();
                        int num52 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0x20, 0f, 0f, 0, color, 1f);
                        Dust dust12 = Main.dust[num52];
                        dust12.velocity = (Vector2) (dust12.velocity * 0.6f);
                    }
                }
                else if (this.type == 0x27)
                {
                    Main.PlaySound(0, (int) this.position.X, (int) this.position.Y, 1);
                    for (int num53 = 0; num53 < 5; num53++)
                    {
                        color = new Color();
                        int num54 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0x26, 0f, 0f, 0, color, 1f);
                        Dust dust13 = Main.dust[num54];
                        dust13.velocity = (Vector2) (dust13.velocity * 0.6f);
                    }
                }
                else if (this.type == 0x47)
                {
                    Main.PlaySound(0, (int) this.position.X, (int) this.position.Y, 1);
                    for (int num55 = 0; num55 < 5; num55++)
                    {
                        color = new Color();
                        int num56 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0x35, 0f, 0f, 0, color, 1f);
                        Dust dust14 = Main.dust[num56];
                        dust14.velocity = (Vector2) (dust14.velocity * 0.6f);
                    }
                }
                else if (this.type == 40)
                {
                    Main.PlaySound(0, (int) this.position.X, (int) this.position.Y, 1);
                    for (int num57 = 0; num57 < 5; num57++)
                    {
                        color = new Color();
                        int num58 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0x24, 0f, 0f, 0, color, 1f);
                        Dust dust15 = Main.dust[num58];
                        dust15.velocity = (Vector2) (dust15.velocity * 0.6f);
                    }
                }
                else if (this.type == 0x15)
                {
                    Main.PlaySound(0, (int) this.position.X, (int) this.position.Y, 1);
                    for (int num59 = 0; num59 < 10; num59++)
                    {
                        color = new Color();
                        Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0x1a, 0f, 0f, 0, color, 0.8f);
                    }
                }
                else if (this.type == 0x18)
                {
                    for (int num60 = 0; num60 < 10; num60++)
                    {
                        color = new Color();
                        Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 1, this.velocity.X * 0.1f, this.velocity.Y * 0.1f, 0, color, 0.75f);
                    }
                }
                else if (this.type == 0x1b)
                {
                    Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 10);
                    for (int num61 = 0; num61 < 30; num61++)
                    {
                        color = new Color();
                        int num62 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0x1d, this.velocity.X * 0.1f, this.velocity.Y * 0.1f, 100, color, 3f);
                        Main.dust[num62].noGravity = true;
                        color = new Color();
                        Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0x1d, this.velocity.X * 0.1f, this.velocity.Y * 0.1f, 100, color, 2f);
                    }
                }
                else if (this.type == 0x26)
                {
                    for (int num63 = 0; num63 < 10; num63++)
                    {
                        color = new Color();
                        Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0x2a, this.velocity.X * 0.1f, this.velocity.Y * 0.1f, 0, color, 1f);
                    }
                }
                else if ((this.type == 0x2c) || (this.type == 0x2d))
                {
                    Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 10);
                    for (int num64 = 0; num64 < 30; num64++)
                    {
                        color = new Color();
                        int num65 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0x1b, this.velocity.X, this.velocity.Y, 100, color, 1.7f);
                        Main.dust[num65].noGravity = true;
                        color = new Color();
                        Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0x1b, this.velocity.X, this.velocity.Y, 100, color, 1f);
                    }
                }
                else
                {
                    Vector2 vector2;
                    if (this.type == 0x29)
                    {
                        Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 14);
                        for (int num66 = 0; num66 < 10; num66++)
                        {
                            color = new Color();
                            Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0x1f, 0f, 0f, 100, color, 1.5f);
                        }
                        for (int num67 = 0; num67 < 5; num67++)
                        {
                            color = new Color();
                            int num68 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, color, 2.5f);
                            Main.dust[num68].noGravity = true;
                            Dust dust16 = Main.dust[num68];
                            dust16.velocity = (Vector2) (dust16.velocity * 3f);
                            color = new Color();
                            num68 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, color, 1.5f);
                            Dust dust17 = Main.dust[num68];
                            dust17.velocity = (Vector2) (dust17.velocity * 2f);
                        }
                        vector2 = new Vector2();
                        int num69 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), vector2, Main.rand.Next(0x3d, 0x40), 1f);
                        Gore gore1 = Main.gore[num69];
                        gore1.velocity = (Vector2) (gore1.velocity * 0.4f);
                        Main.gore[num69].velocity.X += Main.rand.Next(-10, 11) * 0.1f;
                        Main.gore[num69].velocity.Y += Main.rand.Next(-10, 11) * 0.1f;
                        num69 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), new Vector2(), Main.rand.Next(0x3d, 0x40), 1f);
                        Gore gore2 = Main.gore[num69];
                        gore2.velocity = (Vector2) (gore2.velocity * 0.4f);
                        Main.gore[num69].velocity.X += Main.rand.Next(-10, 11) * 0.1f;
                        Main.gore[num69].velocity.Y += Main.rand.Next(-10, 11) * 0.1f;
                        if (this.owner == Main.myPlayer)
                        {
                            this.penetrate = -1;
                            this.position.X += this.width / 2;
                            this.position.Y += this.height / 2;
                            this.width = 0x40;
                            this.height = 0x40;
                            this.position.X -= this.width / 2;
                            this.position.Y -= this.height / 2;
                            this.Damage();
                        }
                    }
                    else if (((this.type == 0x1c) || (this.type == 30)) || (((this.type == 0x25) || (this.type == 0x4b)) || (this.type == 0x66)))
                    {
                        Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 14);
                        this.position.X += this.width / 2;
                        this.position.Y += this.height / 2;
                        this.width = 0x16;
                        this.height = 0x16;
                        this.position.X -= this.width / 2;
                        this.position.Y -= this.height / 2;
                        for (int num70 = 0; num70 < 20; num70++)
                        {
                            color = new Color();
                            int num71 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0x1f, 0f, 0f, 100, color, 1.5f);
                            Dust dust18 = Main.dust[num71];
                            dust18.velocity = (Vector2) (dust18.velocity * 1.4f);
                        }
                        for (int num72 = 0; num72 < 10; num72++)
                        {
                            color = new Color();
                            int num73 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, color, 2.5f);
                            Main.dust[num73].noGravity = true;
                            Dust dust19 = Main.dust[num73];
                            dust19.velocity = (Vector2) (dust19.velocity * 5f);
                            color = new Color();
                            num73 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, color, 1.5f);
                            Dust dust20 = Main.dust[num73];
                            dust20.velocity = (Vector2) (dust20.velocity * 3f);
                        }
                        vector2 = new Vector2();
                        int num74 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), vector2, Main.rand.Next(0x3d, 0x40), 1f);
                        Gore gore3 = Main.gore[num74];
                        gore3.velocity = (Vector2) (gore3.velocity * 0.4f);
                        Main.gore[num74].velocity.X++;
                        Main.gore[num74].velocity.Y++;
                        vector2 = new Vector2();
                        num74 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), vector2, Main.rand.Next(0x3d, 0x40), 1f);
                        Gore gore4 = Main.gore[num74];
                        gore4.velocity = (Vector2) (gore4.velocity * 0.4f);
                        Main.gore[num74].velocity.X--;
                        Main.gore[num74].velocity.Y++;
                        vector2 = new Vector2();
                        num74 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), vector2, Main.rand.Next(0x3d, 0x40), 1f);
                        Gore gore5 = Main.gore[num74];
                        gore5.velocity = (Vector2) (gore5.velocity * 0.4f);
                        Main.gore[num74].velocity.X++;
                        Main.gore[num74].velocity.Y--;
                        num74 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), new Vector2(), Main.rand.Next(0x3d, 0x40), 1f);
                        Gore gore6 = Main.gore[num74];
                        gore6.velocity = (Vector2) (gore6.velocity * 0.4f);
                        Main.gore[num74].velocity.X--;
                        Main.gore[num74].velocity.Y--;
                    }
                    else if ((this.type == 0x1d) || (this.type == 0x6c))
                    {
                        Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 14);
                        if (this.type == 0x1d)
                        {
                            this.position.X += this.width / 2;
                            this.position.Y += this.height / 2;
                            this.width = 200;
                            this.height = 200;
                            this.position.X -= this.width / 2;
                            this.position.Y -= this.height / 2;
                        }
                        for (int num75 = 0; num75 < 50; num75++)
                        {
                            color = new Color();
                            int num76 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0x1f, 0f, 0f, 100, color, 2f);
                            Dust dust21 = Main.dust[num76];
                            dust21.velocity = (Vector2) (dust21.velocity * 1.4f);
                        }
                        for (int num77 = 0; num77 < 80; num77++)
                        {
                            color = new Color();
                            int num78 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, color, 3f);
                            Main.dust[num78].noGravity = true;
                            Dust dust22 = Main.dust[num78];
                            dust22.velocity = (Vector2) (dust22.velocity * 5f);
                            color = new Color();
                            num78 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, color, 2f);
                            Dust dust23 = Main.dust[num78];
                            dust23.velocity = (Vector2) (dust23.velocity * 3f);
                        }
                        for (int num80 = 0; num80 < 2; num80++)
                        {
                            vector2 = new Vector2();
                            int num79 = Gore.NewGore(new Vector2((this.position.X + (this.width / 2)) - 24f, (this.position.Y + (this.height / 2)) - 24f), vector2, Main.rand.Next(0x3d, 0x40), 1f);
                            Main.gore[num79].scale = 1.5f;
                            Main.gore[num79].velocity.X += 1.5f;
                            Main.gore[num79].velocity.Y += 1.5f;
                            vector2 = new Vector2();
                            num79 = Gore.NewGore(new Vector2((this.position.X + (this.width / 2)) - 24f, (this.position.Y + (this.height / 2)) - 24f), vector2, Main.rand.Next(0x3d, 0x40), 1f);
                            Main.gore[num79].scale = 1.5f;
                            Main.gore[num79].velocity.X -= 1.5f;
                            Main.gore[num79].velocity.Y += 1.5f;
                            vector2 = new Vector2();
                            num79 = Gore.NewGore(new Vector2((this.position.X + (this.width / 2)) - 24f, (this.position.Y + (this.height / 2)) - 24f), vector2, Main.rand.Next(0x3d, 0x40), 1f);
                            Main.gore[num79].scale = 1.5f;
                            Main.gore[num79].velocity.X += 1.5f;
                            Main.gore[num79].velocity.Y -= 1.5f;
                            vector2 = new Vector2();
                            num79 = Gore.NewGore(new Vector2((this.position.X + (this.width / 2)) - 24f, (this.position.Y + (this.height / 2)) - 24f), vector2, Main.rand.Next(0x3d, 0x40), 1f);
                            Main.gore[num79].scale = 1.5f;
                            Main.gore[num79].velocity.X -= 1.5f;
                            Main.gore[num79].velocity.Y -= 1.5f;
                        }
                        this.position.X += this.width / 2;
                        this.position.Y += this.height / 2;
                        this.width = 10;
                        this.height = 10;
                        this.position.X -= this.width / 2;
                        this.position.Y -= this.height / 2;
                    }
                    else if (this.type == 0x45)
                    {
                        Main.PlaySound(13, (int) this.position.X, (int) this.position.Y, 1);
                        for (int num81 = 0; num81 < 5; num81++)
                        {
                            color = new Color();
                            Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 13, 0f, 0f, 0, color, 1f);
                        }
                        for (int num82 = 0; num82 < 30; num82++)
                        {
                            color = new Color();
                            int num83 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0x21, 0f, -2f, 0, color, 1.1f);
                            Main.dust[num83].alpha = 100;
                            Main.dust[num83].velocity.X *= 1.5f;
                            Dust dust24 = Main.dust[num83];
                            dust24.velocity = (Vector2) (dust24.velocity * 3f);
                        }
                    }
                    else if (this.type == 70)
                    {
                        Main.PlaySound(13, (int) this.position.X, (int) this.position.Y, 1);
                        for (int num84 = 0; num84 < 5; num84++)
                        {
                            color = new Color();
                            Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 13, 0f, 0f, 0, color, 1f);
                        }
                        for (int num85 = 0; num85 < 30; num85++)
                        {
                            color = new Color();
                            int num86 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0x34, 0f, -2f, 0, color, 1.1f);
                            Main.dust[num86].alpha = 100;
                            Main.dust[num86].velocity.X *= 1.5f;
                            Dust dust25 = Main.dust[num86];
                            dust25.velocity = (Vector2) (dust25.velocity * 3f);
                        }
                    }
                }
                if (this.owner == Main.myPlayer)
                {
                    if (((this.type == 0x1c) || (this.type == 0x1d)) || (((this.type == 0x25) || (this.type == 0x4b)) || (this.type == 0x6c)))
                    {
                        int num87 = 3;
                        if (this.type == 0x1d)
                        {
                            num87 = 7;
                        }
                        if (this.type == 0x6c)
                        {
                            num87 = 10;
                        }
                        int num88 = ((int) (this.position.X / 16f)) - num87;
                        int maxTilesX = ((int) (this.position.X / 16f)) + num87;
                        int num90 = ((int) (this.position.Y / 16f)) - num87;
                        int maxTilesY = ((int) (this.position.Y / 16f)) + num87;
                        if (num88 < 0)
                        {
                            num88 = 0;
                        }
                        if (maxTilesX > Main.maxTilesX)
                        {
                            maxTilesX = Main.maxTilesX;
                        }
                        if (num90 < 0)
                        {
                            num90 = 0;
                        }
                        if (maxTilesY > Main.maxTilesY)
                        {
                            maxTilesY = Main.maxTilesY;
                        }
                        bool flag = false;
                        for (int num92 = num88; num92 <= maxTilesX; num92++)
                        {
                            for (int num93 = num90; num93 <= maxTilesY; num93++)
                            {
                                float num94 = Math.Abs((float) (num92 - (this.position.X / 16f)));
                                float num95 = Math.Abs((float) (num93 - (this.position.Y / 16f)));
                                if (((Math.Sqrt((double) ((num94 * num94) + (num95 * num95))) < num87) && (Main.tile[num92, num93] != null)) && (Main.tile[num92, num93].wall == 0))
                                {
                                    flag = true;
                                    goto Label_2CB4;
                                }
                            }
                        Label_2CB4:;
                        }
                        for (int num97 = num88; num97 <= maxTilesX; num97++)
                        {
                            for (int num98 = num90; num98 <= maxTilesY; num98++)
                            {
                                float num99 = Math.Abs((float) (num97 - (this.position.X / 16f)));
                                float num100 = Math.Abs((float) (num98 - (this.position.Y / 16f)));
                                if (Math.Sqrt((double) ((num99 * num99) + (num100 * num100))) < num87)
                                {
                                    bool flag2 = true;
                                    if ((Main.tile[num97, num98] != null) && Main.tile[num97, num98].active)
                                    {
                                        flag2 = true;
                                        if (((Main.tileDungeon[Main.tile[num97, num98].type] || (Main.tile[num97, num98].type == 0x15)) || ((Main.tile[num97, num98].type == 0x1a) || (Main.tile[num97, num98].type == 0x6b))) || ((Main.tile[num97, num98].type == 0x6c) || (Main.tile[num97, num98].type == 0x6f)))
                                        {
                                            flag2 = false;
                                        }
                                        if (!Main.hardMode && (Main.tile[num97, num98].type == 0x3a))
                                        {
                                            flag2 = false;
                                        }
                                        if (flag2)
                                        {
                                            WorldGen.KillTile(num97, num98, false, false, false);
                                            if (!Main.tile[num97, num98].active && (Main.netMode != 0))
                                            {
                                                NetMessage.SendData(0x11, -1, -1, "", 0, (float) num97, (float) num98, 0f, 0);
                                            }
                                        }
                                    }
                                    if (flag2)
                                    {
                                        for (int num102 = num97 - 1; num102 <= (num97 + 1); num102++)
                                        {
                                            for (int num103 = num98 - 1; num103 <= (num98 + 1); num103++)
                                            {
                                                if (((Main.tile[num102, num103] != null) && (Main.tile[num102, num103].wall > 0)) && flag)
                                                {
                                                    WorldGen.KillWall(num102, num103, false);
                                                    if ((Main.tile[num102, num103].wall == 0) && (Main.netMode == 1))
                                                    {
                                                        NetMessage.SendData(0x11, -1, -1, "", 2, (float) num102, (float) num103, 0f, 0);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (Main.netMode != 0)
                    {
                        NetMessage.SendData(0x1d, -1, -1, "", this.identity, (float) this.owner, 0f, 0f, 0);
                    }
                    int number = -1;
                    if (this.aiStyle == 10)
                    {
                        int num105 = (((int) this.position.X) + (this.width / 2)) / 0x10;
                        int num106 = (((int) this.position.Y) + (this.width / 2)) / 0x10;
                        int num107 = 0;
                        int num108 = 2;
                        if (this.type == 0x1f)
                        {
                            num107 = 0x35;
                            num108 = 0;
                        }
                        if (this.type == 0x2a)
                        {
                            num107 = 0x35;
                            num108 = 0;
                        }
                        if (this.type == 0x38)
                        {
                            num107 = 0x70;
                            num108 = 0;
                        }
                        if (this.type == 0x41)
                        {
                            num107 = 0x70;
                            num108 = 0;
                        }
                        if (this.type == 0x43)
                        {
                            num107 = 0x74;
                            num108 = 0;
                        }
                        if (this.type == 0x44)
                        {
                            num107 = 0x74;
                            num108 = 0;
                        }
                        if (this.type == 0x47)
                        {
                            num107 = 0x7b;
                            num108 = 0;
                        }
                        if (this.type == 0x27)
                        {
                            num107 = 0x3b;
                            num108 = 0xb0;
                        }
                        if (this.type == 40)
                        {
                            num107 = 0x39;
                            num108 = 0xac;
                        }
                        if (!Main.tile[num105, num106].active)
                        {
                            WorldGen.PlaceTile(num105, num106, num107, false, true, -1, 0);
                            if (Main.tile[num105, num106].active && (Main.tile[num105, num106].type == num107))
                            {
                                NetMessage.SendData(0x11, -1, -1, "", 1, (float) num105, (float) num106, (float) num107, 0);
                            }
                            else if (num108 > 0)
                            {
                                number = Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, num108, 1, false, 0);
                            }
                        }
                        else if (num108 > 0)
                        {
                            number = Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, num108, 1, false, 0);
                        }
                    }
                    if ((this.type == 1) && (Main.rand.Next(3) == 0))
                    {
                        number = Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 40, 1, false, 0);
                    }
                    if ((this.type == 0x67) && (Main.rand.Next(6) == 0))
                    {
                        if (Main.rand.Next(3) == 0)
                        {
                            number = Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 0x221, 1, false, 0);
                        }
                        else
                        {
                            number = Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 40, 1, false, 0);
                        }
                    }
                    if ((this.type == 2) && (Main.rand.Next(3) == 0))
                    {
                        if (Main.rand.Next(3) == 0)
                        {
                            number = Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 0x29, 1, false, 0);
                        }
                        else
                        {
                            number = Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 40, 1, false, 0);
                        }
                    }
                    if ((this.type == 0x5b) && (Main.rand.Next(6) == 0))
                    {
                        number = Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 0x204, 1, false, 0);
                    }
                    if ((this.type == 50) && (Main.rand.Next(3) == 0))
                    {
                        number = Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 0x11a, 1, false, 0);
                    }
                    if ((this.type == 0x35) && (Main.rand.Next(3) == 0))
                    {
                        number = Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 0x11e, 1, false, 0);
                    }
                    if ((this.type == 0x30) && (Main.rand.Next(2) == 0))
                    {
                        number = Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 0x117, 1, false, 0);
                    }
                    if ((this.type == 0x36) && (Main.rand.Next(2) == 0))
                    {
                        number = Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 0x11f, 1, false, 0);
                    }
                    if ((this.type == 3) && (Main.rand.Next(2) == 0))
                    {
                        number = Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 0x2a, 1, false, 0);
                    }
                    if ((this.type == 4) && (Main.rand.Next(4) == 0))
                    {
                        number = Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 0x2f, 1, false, 0);
                    }
                    if ((this.type == 12) && (this.damage > 100))
                    {
                        number = Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 0x4b, 1, false, 0);
                    }
                    if ((this.type == 0x45) || (this.type == 70))
                    {
                        int num109 = (((int) this.position.X) + (this.width / 2)) / 0x10;
                        int num110 = (((int) this.position.Y) + (this.height / 2)) / 0x10;
                        for (int num111 = num109 - 4; num111 <= (num109 + 4); num111++)
                        {
                            for (int num112 = num110 - 4; num112 <= (num110 + 4); num112++)
                            {
                                if ((Math.Abs((int) (num111 - num109)) + Math.Abs((int) (num112 - num110))) < 6)
                                {
                                    if (this.type == 0x45)
                                    {
                                        if (Main.tile[num111, num112].type == 2)
                                        {
                                            Main.tile[num111, num112].type = 0x6d;
                                            WorldGen.SquareTileFrame(num111, num112, true);
                                            NetMessage.SendTileSquare(-1, num111, num112, 1);
                                        }
                                        else if (Main.tile[num111, num112].type == 1)
                                        {
                                            Main.tile[num111, num112].type = 0x75;
                                            WorldGen.SquareTileFrame(num111, num112, true);
                                            NetMessage.SendTileSquare(-1, num111, num112, 1);
                                        }
                                        else if (Main.tile[num111, num112].type == 0x35)
                                        {
                                            Main.tile[num111, num112].type = 0x74;
                                            WorldGen.SquareTileFrame(num111, num112, true);
                                            NetMessage.SendTileSquare(-1, num111, num112, 1);
                                        }
                                        else if (Main.tile[num111, num112].type == 0x17)
                                        {
                                            Main.tile[num111, num112].type = 0x6d;
                                            WorldGen.SquareTileFrame(num111, num112, true);
                                            NetMessage.SendTileSquare(-1, num111, num112, 1);
                                        }
                                        else if (Main.tile[num111, num112].type == 0x19)
                                        {
                                            Main.tile[num111, num112].type = 0x75;
                                            WorldGen.SquareTileFrame(num111, num112, true);
                                            NetMessage.SendTileSquare(-1, num111, num112, 1);
                                        }
                                        else if (Main.tile[num111, num112].type == 0x70)
                                        {
                                            Main.tile[num111, num112].type = 0x74;
                                            WorldGen.SquareTileFrame(num111, num112, true);
                                            NetMessage.SendTileSquare(-1, num111, num112, 1);
                                        }
                                    }
                                    else if (Main.tile[num111, num112].type == 2)
                                    {
                                        Main.tile[num111, num112].type = 0x17;
                                        WorldGen.SquareTileFrame(num111, num112, true);
                                        NetMessage.SendTileSquare(-1, num111, num112, 1);
                                    }
                                    else if (Main.tile[num111, num112].type == 1)
                                    {
                                        Main.tile[num111, num112].type = 0x19;
                                        WorldGen.SquareTileFrame(num111, num112, true);
                                        NetMessage.SendTileSquare(-1, num111, num112, 1);
                                    }
                                    else if (Main.tile[num111, num112].type == 0x35)
                                    {
                                        Main.tile[num111, num112].type = 0x70;
                                        WorldGen.SquareTileFrame(num111, num112, true);
                                        NetMessage.SendTileSquare(-1, num111, num112, 1);
                                    }
                                    else if (Main.tile[num111, num112].type == 0x6d)
                                    {
                                        Main.tile[num111, num112].type = 0x17;
                                        WorldGen.SquareTileFrame(num111, num112, true);
                                        NetMessage.SendTileSquare(-1, num111, num112, 1);
                                    }
                                    else if (Main.tile[num111, num112].type == 0x75)
                                    {
                                        Main.tile[num111, num112].type = 0x19;
                                        WorldGen.SquareTileFrame(num111, num112, true);
                                        NetMessage.SendTileSquare(-1, num111, num112, 1);
                                    }
                                    else if (Main.tile[num111, num112].type == 0x74)
                                    {
                                        Main.tile[num111, num112].type = 0x70;
                                        WorldGen.SquareTileFrame(num111, num112, true);
                                        NetMessage.SendTileSquare(-1, num111, num112, 1);
                                    }
                                }
                            }
                        }
                    }
                    if ((this.type == 0x15) && (Main.rand.Next(2) == 0))
                    {
                        number = Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 0x9a, 1, false, 0);
                    }
                    if ((Main.netMode == 1) && (number >= 0))
                    {
                        NetMessage.SendData(0x15, -1, -1, "", number, 0f, 0f, 0f, 0);
                    }
                }
                this.active = false;
            }
        }

        public static int NewProjectile(float X, float Y, float SpeedX, float SpeedY, int Type, int Damage, float KnockBack, int Owner = 0xff)
        {
            int index = 0x3e8;
            for (int i = 0; i < 0x3e8; i++)
            {
                if (!Main.projectile[i].active)
                {
                    index = i;
                    break;
                }
            }
            if (index != 0x3e8)
            {
                Main.projectile[index].SetDefaults(Type);
                Main.projectile[index].position.X = X - (Main.projectile[index].width * 0.5f);
                Main.projectile[index].position.Y = Y - (Main.projectile[index].height * 0.5f);
                Main.projectile[index].owner = Owner;
                Main.projectile[index].velocity.X = SpeedX;
                Main.projectile[index].velocity.Y = SpeedY;
                Main.projectile[index].damage = Damage;
                Main.projectile[index].knockBack = KnockBack;
                Main.projectile[index].identity = index;
                Main.projectile[index].wet = Collision.WetCollision(Main.projectile[index].position, Main.projectile[index].width, Main.projectile[index].height);
                if ((Main.netMode != 0) && (Owner == Main.myPlayer))
                {
                    NetMessage.SendData(0x1b, -1, -1, "", index, 0f, 0f, 0f, 0);
                }
                if (Owner != Main.myPlayer)
                {
                    return index;
                }
                if (Type == 0x1c)
                {
                    Main.projectile[index].timeLeft = 180;
                }
                if (Type == 0x1d)
                {
                    Main.projectile[index].timeLeft = 300;
                }
                if (Type == 30)
                {
                    Main.projectile[index].timeLeft = 180;
                }
                if (Type == 0x25)
                {
                    Main.projectile[index].timeLeft = 180;
                }
                if (Type == 0x4b)
                {
                    Main.projectile[index].timeLeft = 180;
                }
            }
            return index;
        }

        public void SetDefaults(int Type)
        {
            for (int i = 0; i < this.oldPos.Length; i++)
            {
                this.oldPos[i].X = 0f;
                this.oldPos[i].Y = 0f;
            }
            for (int j = 0; j < maxAI; j++)
            {
                this.ai[j] = 0f;
                this.localAI[j] = 0f;
            }
            for (int k = 0; k < 0xff; k++)
            {
                this.playerImmune[k] = 0;
            }
            this.soundDelay = 0;
            this.spriteDirection = 1;
            this.melee = false;
            this.ranged = false;
            this.magic = false;
            this.ownerHitCheck = false;
            this.hide = false;
            this.lavaWet = false;
            this.wetCount = 0;
            this.wet = false;
            this.ignoreWater = false;
            this.hostile = false;
            this.netUpdate = false;
            this.netUpdate2 = false;
            this.netSpam = 0;
            this.numUpdates = 0;
            this.maxUpdates = 0;
            this.identity = 0;
            this.restrikeDelay = 0;
            this.light = 0f;
            this.penetrate = 1;
            this.tileCollide = true;
            this.position = new Vector2();
            this.velocity = new Vector2();
            this.aiStyle = 0;
            this.alpha = 0;
            this.type = Type;
            this.active = true;
            this.rotation = 0f;
            this.scale = 1f;
            this.owner = 0xff;
            this.timeLeft = 0xe10;
            this.name = "";
            this.friendly = false;
            this.damage = 0;
            this.knockBack = 0f;
            this.miscText = "";
            if (this.type == 1)
            {
                this.name = "Wooden Arrow";
                this.width = 10;
                this.height = 10;
                this.aiStyle = 1;
                this.friendly = true;
                this.ranged = true;
            }
            else if (this.type == 2)
            {
                this.name = "Fire Arrow";
                this.width = 10;
                this.height = 10;
                this.aiStyle = 1;
                this.friendly = true;
                this.light = 1f;
                this.ranged = true;
            }
            else if (this.type == 3)
            {
                this.name = "Shuriken";
                this.width = 0x16;
                this.height = 0x16;
                this.aiStyle = 2;
                this.friendly = true;
                this.penetrate = 4;
                this.ranged = true;
            }
            else if (this.type == 4)
            {
                this.name = "Unholy Arrow";
                this.width = 10;
                this.height = 10;
                this.aiStyle = 1;
                this.friendly = true;
                this.light = 0.35f;
                this.penetrate = 5;
                this.ranged = true;
            }
            else if (this.type == 5)
            {
                this.name = "Jester's Arrow";
                this.width = 10;
                this.height = 10;
                this.aiStyle = 1;
                this.friendly = true;
                this.light = 0.4f;
                this.penetrate = -1;
                this.timeLeft = 40;
                this.alpha = 100;
                this.ignoreWater = true;
                this.ranged = true;
            }
            else if (this.type == 6)
            {
                this.name = "Enchanted Boomerang";
                this.width = 0x16;
                this.height = 0x16;
                this.aiStyle = 3;
                this.friendly = true;
                this.penetrate = -1;
                this.melee = true;
                this.light = 0.4f;
            }
            else if ((this.type == 7) || (this.type == 8))
            {
                this.name = "Vilethorn";
                this.width = 0x1c;
                this.height = 0x1c;
                this.aiStyle = 4;
                this.friendly = true;
                this.penetrate = -1;
                this.tileCollide = false;
                this.alpha = 0xff;
                this.ignoreWater = true;
                this.magic = true;
            }
            else if (this.type == 9)
            {
                this.name = "Starfury";
                this.width = 0x18;
                this.height = 0x18;
                this.aiStyle = 5;
                this.friendly = true;
                this.penetrate = 2;
                this.alpha = 50;
                this.scale = 0.8f;
                this.tileCollide = false;
                this.magic = true;
            }
            else if (this.type == 10)
            {
                this.name = "Purification Powder";
                this.width = 0x40;
                this.height = 0x40;
                this.aiStyle = 6;
                this.friendly = true;
                this.tileCollide = false;
                this.penetrate = -1;
                this.alpha = 0xff;
                this.ignoreWater = true;
            }
            else if (this.type == 11)
            {
                this.name = "Vile Powder";
                this.width = 0x30;
                this.height = 0x30;
                this.aiStyle = 6;
                this.friendly = true;
                this.tileCollide = false;
                this.penetrate = -1;
                this.alpha = 0xff;
                this.ignoreWater = true;
            }
            else if (this.type == 12)
            {
                this.name = "Falling Star";
                this.width = 0x10;
                this.height = 0x10;
                this.aiStyle = 5;
                this.friendly = true;
                this.penetrate = -1;
                this.alpha = 50;
                this.light = 1f;
            }
            else if (this.type == 13)
            {
                this.name = "Hook";
                this.width = 0x12;
                this.height = 0x12;
                this.aiStyle = 7;
                this.friendly = true;
                this.penetrate = -1;
                this.tileCollide = false;
                this.timeLeft *= 10;
            }
            else if (this.type == 14)
            {
                this.name = "Bullet";
                this.width = 4;
                this.height = 4;
                this.aiStyle = 1;
                this.friendly = true;
                this.penetrate = 1;
                this.light = 0.5f;
                this.alpha = 0xff;
                this.maxUpdates = 1;
                this.scale = 1.2f;
                this.timeLeft = 600;
                this.ranged = true;
            }
            else if (this.type == 15)
            {
                this.name = "Ball of Fire";
                this.width = 0x10;
                this.height = 0x10;
                this.aiStyle = 8;
                this.friendly = true;
                this.light = 0.8f;
                this.alpha = 100;
                this.magic = true;
            }
            else if (this.type == 0x10)
            {
                this.name = "Magic Missile";
                this.width = 10;
                this.height = 10;
                this.aiStyle = 9;
                this.friendly = true;
                this.light = 0.8f;
                this.alpha = 100;
                this.magic = true;
            }
            else if (this.type == 0x11)
            {
                this.name = "Dirt Ball";
                this.width = 10;
                this.height = 10;
                this.aiStyle = 10;
                this.friendly = true;
            }
            else if (this.type == 0x12)
            {
                this.name = "Orb of Light";
                this.width = 0x20;
                this.height = 0x20;
                this.aiStyle = 11;
                this.friendly = true;
                this.light = 0.45f;
                this.alpha = 150;
                this.tileCollide = false;
                this.penetrate = -1;
                this.timeLeft *= 5;
                this.ignoreWater = true;
                this.scale = 0.8f;
            }
            else if (this.type == 0x13)
            {
                this.name = "Flamarang";
                this.width = 0x16;
                this.height = 0x16;
                this.aiStyle = 3;
                this.friendly = true;
                this.penetrate = -1;
                this.light = 1f;
                this.melee = true;
            }
            else if (this.type == 20)
            {
                this.name = "Green Laser";
                this.width = 4;
                this.height = 4;
                this.aiStyle = 1;
                this.friendly = true;
                this.penetrate = 3;
                this.light = 0.75f;
                this.alpha = 0xff;
                this.maxUpdates = 2;
                this.scale = 1.4f;
                this.timeLeft = 600;
                this.magic = true;
            }
            else if (this.type == 0x15)
            {
                this.name = "Bone";
                this.width = 0x10;
                this.height = 0x10;
                this.aiStyle = 2;
                this.scale = 1.2f;
                this.friendly = true;
                this.ranged = true;
            }
            else if (this.type == 0x16)
            {
                this.name = "Water Stream";
                this.width = 0x12;
                this.height = 0x12;
                this.aiStyle = 12;
                this.friendly = true;
                this.alpha = 0xff;
                this.penetrate = -1;
                this.maxUpdates = 2;
                this.ignoreWater = true;
                this.magic = true;
            }
            else if (this.type == 0x17)
            {
                this.name = "Harpoon";
                this.width = 4;
                this.height = 4;
                this.aiStyle = 13;
                this.friendly = true;
                this.penetrate = -1;
                this.alpha = 0xff;
                this.ranged = true;
            }
            else if (this.type == 0x18)
            {
                this.name = "Spiky Ball";
                this.width = 14;
                this.height = 14;
                this.aiStyle = 14;
                this.friendly = true;
                this.penetrate = 6;
                this.ranged = true;
            }
            else if (this.type == 0x19)
            {
                this.name = "Ball 'O Hurt";
                this.width = 0x16;
                this.height = 0x16;
                this.aiStyle = 15;
                this.friendly = true;
                this.penetrate = -1;
                this.melee = true;
                this.scale = 0.8f;
            }
            else if (this.type == 0x1a)
            {
                this.name = "Blue Moon";
                this.width = 0x16;
                this.height = 0x16;
                this.aiStyle = 15;
                this.friendly = true;
                this.penetrate = -1;
                this.melee = true;
                this.scale = 0.8f;
            }
            else if (this.type == 0x1b)
            {
                this.name = "Water Bolt";
                this.width = 0x10;
                this.height = 0x10;
                this.aiStyle = 8;
                this.friendly = true;
                this.light = 0.8f;
                this.alpha = 200;
                this.timeLeft /= 2;
                this.penetrate = 10;
                this.magic = true;
            }
            else if (this.type == 0x1c)
            {
                this.name = "Bomb";
                this.width = 0x16;
                this.height = 0x16;
                this.aiStyle = 0x10;
                this.friendly = true;
                this.penetrate = -1;
            }
            else if (this.type == 0x1d)
            {
                this.name = "Dynamite";
                this.width = 10;
                this.height = 10;
                this.aiStyle = 0x10;
                this.friendly = true;
                this.penetrate = -1;
            }
            else if (this.type == 30)
            {
                this.name = "Grenade";
                this.width = 14;
                this.height = 14;
                this.aiStyle = 0x10;
                this.friendly = true;
                this.penetrate = -1;
                this.ranged = true;
            }
            else if (this.type == 0x1f)
            {
                this.name = "Sand Ball";
                this.knockBack = 6f;
                this.width = 10;
                this.height = 10;
                this.aiStyle = 10;
                this.friendly = true;
                this.hostile = true;
                this.penetrate = -1;
            }
            else if (this.type == 0x20)
            {
                this.name = "Ivy Whip";
                this.width = 0x12;
                this.height = 0x12;
                this.aiStyle = 7;
                this.friendly = true;
                this.penetrate = -1;
                this.tileCollide = false;
                this.timeLeft *= 10;
            }
            else if (this.type == 0x21)
            {
                this.name = "Thorn Chakrum";
                this.width = 0x1c;
                this.height = 0x1c;
                this.aiStyle = 3;
                this.friendly = true;
                this.scale = 0.9f;
                this.penetrate = -1;
                this.melee = true;
            }
            else if (this.type == 0x22)
            {
                this.name = "Flamelash";
                this.width = 14;
                this.height = 14;
                this.aiStyle = 9;
                this.friendly = true;
                this.light = 0.8f;
                this.alpha = 100;
                this.penetrate = 1;
                this.magic = true;
            }
            else if (this.type == 0x23)
            {
                this.name = "Sunfury";
                this.width = 0x16;
                this.height = 0x16;
                this.aiStyle = 15;
                this.friendly = true;
                this.penetrate = -1;
                this.melee = true;
                this.scale = 0.8f;
            }
            else if (this.type == 0x24)
            {
                this.name = "Meteor Shot";
                this.width = 4;
                this.height = 4;
                this.aiStyle = 1;
                this.friendly = true;
                this.penetrate = 2;
                this.light = 0.6f;
                this.alpha = 0xff;
                this.maxUpdates = 1;
                this.scale = 1.4f;
                this.timeLeft = 600;
                this.ranged = true;
            }
            else if (this.type == 0x25)
            {
                this.name = "Sticky Bomb";
                this.width = 0x16;
                this.height = 0x16;
                this.aiStyle = 0x10;
                this.friendly = true;
                this.penetrate = -1;
                this.tileCollide = false;
            }
            else if (this.type == 0x26)
            {
                this.name = "Harpy Feather";
                this.width = 14;
                this.height = 14;
                this.aiStyle = 0;
                this.hostile = true;
                this.penetrate = -1;
                this.aiStyle = 1;
                this.tileCollide = true;
            }
            else if (this.type == 0x27)
            {
                this.name = "Mud Ball";
                this.knockBack = 6f;
                this.width = 10;
                this.height = 10;
                this.aiStyle = 10;
                this.friendly = true;
                this.hostile = true;
                this.penetrate = -1;
            }
            else if (this.type == 40)
            {
                this.name = "Ash Ball";
                this.knockBack = 6f;
                this.width = 10;
                this.height = 10;
                this.aiStyle = 10;
                this.friendly = true;
                this.hostile = true;
                this.penetrate = -1;
            }
            else if (this.type == 0x29)
            {
                this.name = "Hellfire Arrow";
                this.width = 10;
                this.height = 10;
                this.aiStyle = 1;
                this.friendly = true;
                this.penetrate = -1;
                this.ranged = true;
                this.light = 0.3f;
            }
            else if (this.type == 0x2a)
            {
                this.name = "Sand Ball";
                this.knockBack = 8f;
                this.width = 10;
                this.height = 10;
                this.aiStyle = 10;
                this.friendly = true;
                this.maxUpdates = 1;
            }
            else if (this.type == 0x2b)
            {
                this.name = "Tombstone";
                this.knockBack = 12f;
                this.width = 0x18;
                this.height = 0x18;
                this.aiStyle = 0x11;
                this.penetrate = -1;
            }
            else if (this.type == 0x2c)
            {
                this.name = "Demon Sickle";
                this.width = 0x30;
                this.height = 0x30;
                this.alpha = 100;
                this.light = 0.2f;
                this.aiStyle = 0x12;
                this.hostile = true;
                this.penetrate = -1;
                this.tileCollide = true;
                this.scale = 0.9f;
            }
            else if (this.type == 0x2d)
            {
                this.name = "Demon Scythe";
                this.width = 0x30;
                this.height = 0x30;
                this.alpha = 100;
                this.light = 0.2f;
                this.aiStyle = 0x12;
                this.friendly = true;
                this.penetrate = 5;
                this.tileCollide = true;
                this.scale = 0.9f;
                this.magic = true;
            }
            else if (this.type == 0x2e)
            {
                this.name = "Dark Lance";
                this.width = 20;
                this.height = 20;
                this.aiStyle = 0x13;
                this.friendly = true;
                this.penetrate = -1;
                this.tileCollide = false;
                this.scale = 1.1f;
                this.hide = true;
                this.ownerHitCheck = true;
                this.melee = true;
            }
            else if (this.type == 0x2f)
            {
                this.name = "Trident";
                this.width = 0x12;
                this.height = 0x12;
                this.aiStyle = 0x13;
                this.friendly = true;
                this.penetrate = -1;
                this.tileCollide = false;
                this.scale = 1.1f;
                this.hide = true;
                this.ownerHitCheck = true;
                this.melee = true;
            }
            else if (this.type == 0x30)
            {
                this.name = "Throwing Knife";
                this.width = 12;
                this.height = 12;
                this.aiStyle = 2;
                this.friendly = true;
                this.penetrate = 2;
                this.ranged = true;
            }
            else if (this.type == 0x31)
            {
                this.name = "Spear";
                this.width = 0x12;
                this.height = 0x12;
                this.aiStyle = 0x13;
                this.friendly = true;
                this.penetrate = -1;
                this.tileCollide = false;
                this.scale = 1.2f;
                this.hide = true;
                this.ownerHitCheck = true;
                this.melee = true;
            }
            else if (this.type == 50)
            {
                this.name = "Glowstick";
                this.width = 6;
                this.height = 6;
                this.aiStyle = 14;
                this.penetrate = -1;
                this.alpha = 0x4b;
                this.light = 1f;
                this.timeLeft *= 5;
            }
            else if (this.type == 0x33)
            {
                this.name = "Seed";
                this.width = 8;
                this.height = 8;
                this.aiStyle = 1;
                this.friendly = true;
            }
            else if (this.type == 0x34)
            {
                this.name = "Wooden Boomerang";
                this.width = 0x16;
                this.height = 0x16;
                this.aiStyle = 3;
                this.friendly = true;
                this.penetrate = -1;
                this.melee = true;
            }
            else if (this.type == 0x35)
            {
                this.name = "Sticky Glowstick";
                this.width = 6;
                this.height = 6;
                this.aiStyle = 14;
                this.penetrate = -1;
                this.alpha = 0x4b;
                this.light = 1f;
                this.timeLeft *= 5;
                this.tileCollide = false;
            }
            else if (this.type == 0x36)
            {
                this.name = "Poisoned Knife";
                this.width = 12;
                this.height = 12;
                this.aiStyle = 2;
                this.friendly = true;
                this.penetrate = 2;
                this.ranged = true;
            }
            else if (this.type == 0x37)
            {
                this.name = "Stinger";
                this.width = 10;
                this.height = 10;
                this.aiStyle = 0;
                this.hostile = true;
                this.penetrate = -1;
                this.aiStyle = 1;
                this.tileCollide = true;
            }
            else if (this.type == 0x38)
            {
                this.name = "Ebonsand Ball";
                this.knockBack = 6f;
                this.width = 10;
                this.height = 10;
                this.aiStyle = 10;
                this.friendly = true;
                this.hostile = true;
                this.penetrate = -1;
            }
            else if (this.type == 0x39)
            {
                this.name = "Cobalt Chainsaw";
                this.width = 0x12;
                this.height = 0x12;
                this.aiStyle = 20;
                this.friendly = true;
                this.penetrate = -1;
                this.tileCollide = false;
                this.hide = true;
                this.ownerHitCheck = true;
                this.melee = true;
            }
            else if (this.type == 0x3a)
            {
                this.name = "Mythril Chainsaw";
                this.width = 0x12;
                this.height = 0x12;
                this.aiStyle = 20;
                this.friendly = true;
                this.penetrate = -1;
                this.tileCollide = false;
                this.hide = true;
                this.ownerHitCheck = true;
                this.melee = true;
                this.scale = 1.08f;
            }
            else if (this.type == 0x3b)
            {
                this.name = "Cobalt Drill";
                this.width = 0x16;
                this.height = 0x16;
                this.aiStyle = 20;
                this.friendly = true;
                this.penetrate = -1;
                this.tileCollide = false;
                this.hide = true;
                this.ownerHitCheck = true;
                this.melee = true;
                this.scale = 0.9f;
            }
            else if (this.type == 60)
            {
                this.name = "Mythril Drill";
                this.width = 0x16;
                this.height = 0x16;
                this.aiStyle = 20;
                this.friendly = true;
                this.penetrate = -1;
                this.tileCollide = false;
                this.hide = true;
                this.ownerHitCheck = true;
                this.melee = true;
                this.scale = 0.9f;
            }
            else if (this.type == 0x3d)
            {
                this.name = "Adamantite Chainsaw";
                this.width = 0x12;
                this.height = 0x12;
                this.aiStyle = 20;
                this.friendly = true;
                this.penetrate = -1;
                this.tileCollide = false;
                this.hide = true;
                this.ownerHitCheck = true;
                this.melee = true;
                this.scale = 1.16f;
            }
            else if (this.type == 0x3e)
            {
                this.name = "Adamantite Drill";
                this.width = 0x16;
                this.height = 0x16;
                this.aiStyle = 20;
                this.friendly = true;
                this.penetrate = -1;
                this.tileCollide = false;
                this.hide = true;
                this.ownerHitCheck = true;
                this.melee = true;
                this.scale = 0.9f;
            }
            else if (this.type == 0x3f)
            {
                this.name = "The Dao of Pow";
                this.width = 0x16;
                this.height = 0x16;
                this.aiStyle = 15;
                this.friendly = true;
                this.penetrate = -1;
                this.melee = true;
            }
            else if (this.type == 0x40)
            {
                this.name = "Mythril Halberd";
                this.width = 0x12;
                this.height = 0x12;
                this.aiStyle = 0x13;
                this.friendly = true;
                this.penetrate = -1;
                this.tileCollide = false;
                this.scale = 1.25f;
                this.hide = true;
                this.ownerHitCheck = true;
                this.melee = true;
            }
            else if (this.type == 0x41)
            {
                this.name = "Ebonsand Ball";
                this.knockBack = 6f;
                this.width = 10;
                this.height = 10;
                this.aiStyle = 10;
                this.friendly = true;
                this.penetrate = -1;
                this.maxUpdates = 1;
            }
            else if (this.type == 0x42)
            {
                this.name = "Adamantite Glaive";
                this.width = 0x12;
                this.height = 0x12;
                this.aiStyle = 0x13;
                this.friendly = true;
                this.penetrate = -1;
                this.tileCollide = false;
                this.scale = 1.27f;
                this.hide = true;
                this.ownerHitCheck = true;
                this.melee = true;
            }
            else if (this.type == 0x43)
            {
                this.name = "Pearl Sand Ball";
                this.knockBack = 6f;
                this.width = 10;
                this.height = 10;
                this.aiStyle = 10;
                this.friendly = true;
                this.hostile = true;
                this.penetrate = -1;
            }
            else if (this.type == 0x44)
            {
                this.name = "Pearl Sand Ball";
                this.knockBack = 6f;
                this.width = 10;
                this.height = 10;
                this.aiStyle = 10;
                this.friendly = true;
                this.penetrate = -1;
                this.maxUpdates = 1;
            }
            else if (this.type == 0x45)
            {
                this.name = "Holy Water";
                this.width = 14;
                this.height = 14;
                this.aiStyle = 2;
                this.friendly = true;
                this.penetrate = 1;
            }
            else if (this.type == 70)
            {
                this.name = "Unholy Water";
                this.width = 14;
                this.height = 14;
                this.aiStyle = 2;
                this.friendly = true;
                this.penetrate = 1;
            }
            else if (this.type == 0x47)
            {
                this.name = "Gravel Ball";
                this.knockBack = 6f;
                this.width = 10;
                this.height = 10;
                this.aiStyle = 10;
                this.friendly = true;
                this.hostile = true;
                this.penetrate = -1;
            }
            else if (this.type == 0x48)
            {
                this.name = "Blue Fairy";
                this.width = 0x12;
                this.height = 0x12;
                this.aiStyle = 11;
                this.friendly = true;
                this.light = 0.9f;
                this.tileCollide = false;
                this.penetrate = -1;
                this.timeLeft *= 5;
                this.ignoreWater = true;
                this.scale = 0.8f;
            }
            else if ((this.type == 0x49) || (this.type == 0x4a))
            {
                this.name = "Hook";
                this.width = 0x12;
                this.height = 0x12;
                this.aiStyle = 7;
                this.friendly = true;
                this.penetrate = -1;
                this.tileCollide = false;
                this.timeLeft *= 10;
                this.light = 0.4f;
            }
            else if (this.type == 0x4b)
            {
                this.name = "Happy Bomb";
                this.width = 0x16;
                this.height = 0x16;
                this.aiStyle = 0x10;
                this.hostile = true;
                this.penetrate = -1;
            }
            else if (((this.type == 0x4c) || (this.type == 0x4d)) || (this.type == 0x4e))
            {
                if (this.type == 0x4c)
                {
                    this.width = 10;
                    this.height = 0x16;
                }
                else if (this.type == 0x4d)
                {
                    this.width = 0x12;
                    this.height = 0x18;
                }
                else
                {
                    this.width = 0x16;
                    this.height = 0x18;
                }
                this.name = "Note";
                this.aiStyle = 0x15;
                this.friendly = true;
                this.ranged = true;
                this.alpha = 100;
                this.light = 0.3f;
                this.penetrate = -1;
                this.timeLeft = 180;
            }
            else if (this.type == 0x4f)
            {
                this.name = "Rainbow";
                this.width = 10;
                this.height = 10;
                this.aiStyle = 9;
                this.friendly = true;
                this.light = 0.8f;
                this.alpha = 0xff;
                this.magic = true;
            }
            else if (this.type == 80)
            {
                this.name = "Ice Block";
                this.width = 0x10;
                this.height = 0x10;
                this.aiStyle = 0x16;
                this.friendly = true;
                this.magic = true;
                this.tileCollide = false;
                this.light = 0.5f;
            }
            else if (this.type == 0x51)
            {
                this.name = "Wooden Arrow";
                this.width = 10;
                this.height = 10;
                this.aiStyle = 1;
                this.hostile = true;
                this.ranged = true;
            }
            else if (this.type == 0x52)
            {
                this.name = "Flaming Arrow";
                this.width = 10;
                this.height = 10;
                this.aiStyle = 1;
                this.hostile = true;
                this.ranged = true;
            }
            else if (this.type == 0x53)
            {
                this.name = "Eye Laser";
                this.width = 4;
                this.height = 4;
                this.aiStyle = 1;
                this.hostile = true;
                this.penetrate = 3;
                this.light = 0.75f;
                this.alpha = 0xff;
                this.maxUpdates = 2;
                this.scale = 1.7f;
                this.timeLeft = 600;
                this.magic = true;
            }
            else if (this.type == 0x54)
            {
                this.name = "Pink Laser";
                this.width = 4;
                this.height = 4;
                this.aiStyle = 1;
                this.hostile = true;
                this.penetrate = 3;
                this.light = 0.75f;
                this.alpha = 0xff;
                this.maxUpdates = 2;
                this.scale = 1.2f;
                this.timeLeft = 600;
                this.magic = true;
            }
            else if (this.type == 0x55)
            {
                this.name = "Flames";
                this.width = 6;
                this.height = 6;
                this.aiStyle = 0x17;
                this.friendly = true;
                this.alpha = 0xff;
                this.penetrate = 3;
                this.maxUpdates = 2;
                this.magic = true;
            }
            else if (this.type == 0x56)
            {
                this.name = "Pink Fairy";
                this.width = 0x12;
                this.height = 0x12;
                this.aiStyle = 11;
                this.friendly = true;
                this.light = 0.9f;
                this.tileCollide = false;
                this.penetrate = -1;
                this.timeLeft *= 5;
                this.ignoreWater = true;
                this.scale = 0.8f;
            }
            else if (this.type == 0x57)
            {
                this.name = "Pink Fairy";
                this.width = 0x12;
                this.height = 0x12;
                this.aiStyle = 11;
                this.friendly = true;
                this.light = 0.9f;
                this.tileCollide = false;
                this.penetrate = -1;
                this.timeLeft *= 5;
                this.ignoreWater = true;
                this.scale = 0.8f;
            }
            else if (this.type == 0x58)
            {
                this.name = "Purple Laser";
                this.width = 6;
                this.height = 6;
                this.aiStyle = 1;
                this.friendly = true;
                this.penetrate = 3;
                this.light = 0.75f;
                this.alpha = 0xff;
                this.maxUpdates = 4;
                this.scale = 1.4f;
                this.timeLeft = 600;
                this.magic = true;
            }
            else if (this.type == 0x59)
            {
                this.name = "Crystal Bullet";
                this.width = 4;
                this.height = 4;
                this.aiStyle = 1;
                this.friendly = true;
                this.penetrate = 1;
                this.light = 0.5f;
                this.alpha = 0xff;
                this.maxUpdates = 1;
                this.scale = 1.2f;
                this.timeLeft = 600;
                this.ranged = true;
            }
            else if (this.type == 90)
            {
                this.name = "Crystal Shard";
                this.width = 6;
                this.height = 6;
                this.aiStyle = 0x18;
                this.friendly = true;
                this.penetrate = 1;
                this.light = 0.5f;
                this.alpha = 50;
                this.scale = 1.2f;
                this.timeLeft = 600;
                this.ranged = true;
                this.tileCollide = false;
            }
            else if (this.type == 0x5b)
            {
                this.name = "Holy Arrow";
                this.width = 10;
                this.height = 10;
                this.aiStyle = 1;
                this.friendly = true;
                this.ranged = true;
            }
            else if (this.type == 0x5c)
            {
                this.name = "Hallow Star";
                this.width = 0x18;
                this.height = 0x18;
                this.aiStyle = 5;
                this.friendly = true;
                this.penetrate = 2;
                this.alpha = 50;
                this.scale = 0.8f;
                this.tileCollide = false;
                this.magic = true;
            }
            else if (this.type == 0x5d)
            {
                this.light = 0.15f;
                this.name = "Magic Dagger";
                this.width = 12;
                this.height = 12;
                this.aiStyle = 2;
                this.friendly = true;
                this.penetrate = 2;
                this.magic = true;
            }
            else if (this.type == 0x5e)
            {
                this.ignoreWater = true;
                this.name = "Crystal Storm";
                this.width = 8;
                this.height = 8;
                this.aiStyle = 0x18;
                this.friendly = true;
                this.light = 0.5f;
                this.alpha = 50;
                this.scale = 1.2f;
                this.timeLeft = 600;
                this.magic = true;
                this.tileCollide = true;
                this.penetrate = 1;
            }
            else if (this.type == 0x5f)
            {
                this.name = "Cursed Flame";
                this.width = 0x10;
                this.height = 0x10;
                this.aiStyle = 8;
                this.friendly = true;
                this.light = 0.8f;
                this.alpha = 100;
                this.magic = true;
                this.penetrate = 2;
            }
            else if (this.type == 0x60)
            {
                this.name = "Cursed Flame";
                this.width = 0x10;
                this.height = 0x10;
                this.aiStyle = 8;
                this.hostile = true;
                this.light = 0.8f;
                this.alpha = 100;
                this.magic = true;
                this.penetrate = -1;
                this.scale = 0.9f;
                this.scale = 1.3f;
            }
            else if (this.type == 0x61)
            {
                this.name = "Cobalt Naginata";
                this.width = 0x12;
                this.height = 0x12;
                this.aiStyle = 0x13;
                this.friendly = true;
                this.penetrate = -1;
                this.tileCollide = false;
                this.scale = 1.1f;
                this.hide = true;
                this.ownerHitCheck = true;
                this.melee = true;
            }
            else if (this.type == 0x62)
            {
                this.name = "Poison Dart";
                this.width = 10;
                this.height = 10;
                this.aiStyle = 1;
                this.friendly = true;
                this.hostile = true;
                this.ranged = true;
                this.penetrate = -1;
            }
            else if (this.type == 0x63)
            {
                this.name = "Boulder";
                this.width = 0x1f;
                this.height = 0x1f;
                this.aiStyle = 0x19;
                this.friendly = true;
                this.hostile = true;
                this.ranged = true;
                this.penetrate = -1;
            }
            else if (this.type == 100)
            {
                this.name = "Death Laser";
                this.width = 4;
                this.height = 4;
                this.aiStyle = 1;
                this.hostile = true;
                this.penetrate = 3;
                this.light = 0.75f;
                this.alpha = 0xff;
                this.maxUpdates = 2;
                this.scale = 1.8f;
                this.timeLeft = 0x4b0;
                this.magic = true;
            }
            else if (this.type == 0x65)
            {
                this.name = "Eye Fire";
                this.width = 6;
                this.height = 6;
                this.aiStyle = 0x17;
                this.hostile = true;
                this.alpha = 0xff;
                this.penetrate = -1;
                this.maxUpdates = 3;
                this.magic = true;
            }
            else if (this.type == 0x66)
            {
                this.name = "Bomb";
                this.width = 0x16;
                this.height = 0x16;
                this.aiStyle = 0x10;
                this.hostile = true;
                this.penetrate = -1;
                this.ranged = true;
            }
            else if (this.type == 0x67)
            {
                this.name = "Cursed Arrow";
                this.width = 10;
                this.height = 10;
                this.aiStyle = 1;
                this.friendly = true;
                this.light = 1f;
                this.ranged = true;
            }
            else if (this.type == 0x68)
            {
                this.name = "Cursed Bullet";
                this.width = 4;
                this.height = 4;
                this.aiStyle = 1;
                this.friendly = true;
                this.penetrate = 1;
                this.light = 0.5f;
                this.alpha = 0xff;
                this.maxUpdates = 1;
                this.scale = 1.2f;
                this.timeLeft = 600;
                this.ranged = true;
            }
            else if (this.type == 0x69)
            {
                this.name = "Gungnir";
                this.width = 0x12;
                this.height = 0x12;
                this.aiStyle = 0x13;
                this.friendly = true;
                this.penetrate = -1;
                this.tileCollide = false;
                this.scale = 1.3f;
                this.hide = true;
                this.ownerHitCheck = true;
                this.melee = true;
            }
            else if (this.type == 0x6a)
            {
                this.name = "Light Disc";
                this.width = 0x20;
                this.height = 0x20;
                this.aiStyle = 3;
                this.friendly = true;
                this.penetrate = -1;
                this.melee = true;
                this.light = 0.4f;
            }
            else if (this.type == 0x6b)
            {
                this.name = "Hamdrax";
                this.width = 0x16;
                this.height = 0x16;
                this.aiStyle = 20;
                this.friendly = true;
                this.penetrate = -1;
                this.tileCollide = false;
                this.hide = true;
                this.ownerHitCheck = true;
                this.melee = true;
                this.scale = 1.1f;
            }
            else if (this.type == 0x6c)
            {
                this.name = "Explosives";
                this.width = 260;
                this.height = 260;
                this.aiStyle = 0x10;
                this.friendly = true;
                this.hostile = true;
                this.penetrate = -1;
                this.tileCollide = false;
                this.alpha = 0xff;
                this.timeLeft = 2;
            }
            else
            {
                this.active = false;
            }
            this.width = (int) (this.width * this.scale);
            this.height = (int) (this.height * this.scale);
        }

        public void StatusNPC(int i)
        {
            if (this.type == 2)
            {
                if (Main.rand.Next(3) == 0)
                {
                    Main.npc[i].AddBuff(0x18, 180, false);
                }
            }
            else if (this.type == 15)
            {
                if (Main.rand.Next(2) == 0)
                {
                    Main.npc[i].AddBuff(0x18, 300, false);
                }
            }
            else if (this.type == 0x13)
            {
                if (Main.rand.Next(5) == 0)
                {
                    Main.npc[i].AddBuff(0x18, 180, false);
                }
            }
            else if (this.type == 0x21)
            {
                if (Main.rand.Next(5) == 0)
                {
                    Main.npc[i].AddBuff(20, 420, false);
                }
            }
            else if (this.type == 0x22)
            {
                if (Main.rand.Next(2) == 0)
                {
                    Main.npc[i].AddBuff(0x18, 240, false);
                }
            }
            else if (this.type == 0x23)
            {
                if (Main.rand.Next(4) == 0)
                {
                    Main.npc[i].AddBuff(0x18, 180, false);
                }
            }
            else if (this.type == 0x36)
            {
                if (Main.rand.Next(2) == 0)
                {
                    Main.npc[i].AddBuff(20, 600, false);
                }
            }
            else if (this.type == 0x3f)
            {
                if (Main.rand.Next(3) != 0)
                {
                    Main.npc[i].AddBuff(0x1f, 120, false);
                }
            }
            else if (this.type == 0x55)
            {
                Main.npc[i].AddBuff(0x18, 0x4b0, false);
            }
            else if (((this.type == 0x5f) || (this.type == 0x67)) || (this.type == 0x68))
            {
                Main.npc[i].AddBuff(0x27, 420, false);
            }
            else if (this.type == 0x62)
            {
                Main.npc[i].AddBuff(20, 600, false);
            }
        }

        public void StatusPlayer(int i)
        {
            if ((this.type == 0x37) && (Main.rand.Next(3) == 0))
            {
                Main.player[i].AddBuff(20, 600, true);
            }
            if ((this.type == 0x2c) && (Main.rand.Next(3) == 0))
            {
                Main.player[i].AddBuff(0x16, 900, true);
            }
            if ((this.type == 0x52) && (Main.rand.Next(3) == 0))
            {
                Main.player[i].AddBuff(0x18, 420, true);
            }
            if (((this.type == 0x60) || (this.type == 0x65)) && (Main.rand.Next(3) == 0))
            {
                Main.player[i].AddBuff(0x27, 480, true);
            }
            if (this.type == 0x62)
            {
                Main.player[i].AddBuff(20, 600, true);
            }
        }

        public void StatusPvP(int i)
        {
            if (this.type == 2)
            {
                if (Main.rand.Next(3) == 0)
                {
                    Main.player[i].AddBuff(0x18, 180, false);
                }
            }
            else if (this.type == 15)
            {
                if (Main.rand.Next(2) == 0)
                {
                    Main.player[i].AddBuff(0x18, 300, false);
                }
            }
            else if (this.type == 0x13)
            {
                if (Main.rand.Next(5) == 0)
                {
                    Main.player[i].AddBuff(0x18, 180, false);
                }
            }
            else if (this.type == 0x21)
            {
                if (Main.rand.Next(5) == 0)
                {
                    Main.player[i].AddBuff(20, 420, false);
                }
            }
            else if (this.type == 0x22)
            {
                if (Main.rand.Next(2) == 0)
                {
                    Main.player[i].AddBuff(0x18, 240, false);
                }
            }
            else if (this.type == 0x23)
            {
                if (Main.rand.Next(4) == 0)
                {
                    Main.player[i].AddBuff(0x18, 180, false);
                }
            }
            else if (this.type == 0x36)
            {
                if (Main.rand.Next(2) == 0)
                {
                    Main.player[i].AddBuff(20, 600, false);
                }
            }
            else if (this.type == 0x3f)
            {
                if (Main.rand.Next(3) != 0)
                {
                    Main.player[i].AddBuff(0x1f, 120, true);
                }
            }
            else if (this.type == 0x55)
            {
                Main.player[i].AddBuff(0x18, 0x4b0, false);
            }
            else if (((this.type == 0x5f) || (this.type == 0x67)) || (this.type == 0x68))
            {
                Main.player[i].AddBuff(0x27, 420, true);
            }
        }

        public void Update(int i)
        {
            int num16;
            if (this.active)
            {
                Vector2 velocity = this.velocity;
                if (((this.position.X <= Main.leftWorld) || ((this.position.X + this.width) >= Main.rightWorld)) || ((this.position.Y <= Main.topWorld) || ((this.position.Y + this.height) >= Main.bottomWorld)))
                {
                    this.active = false;
                    return;
                }
                this.whoAmI = i;
                if (this.soundDelay > 0)
                {
                    this.soundDelay--;
                }
                this.netUpdate = false;
                for (int j = 0; j < 0xff; j++)
                {
                    if (this.playerImmune[j] > 0)
                    {
                        this.playerImmune[j]--;
                    }
                }
                this.AI();
                if ((this.owner < 0xff) && !Main.player[this.owner].active)
                {
                    this.Kill();
                }
                if (!this.ignoreWater)
                {
                    bool flag;
                    bool flag2;
                    try
                    {
                        flag = Collision.LavaCollision(this.position, this.width, this.height);
                        flag2 = Collision.WetCollision(this.position, this.width, this.height);
                        if (flag)
                        {
                            this.lavaWet = true;
                        }
                    }
                    catch
                    {
                        this.active = false;
                        return;
                    }
                    if (this.wet && !this.lavaWet)
                    {
                        if (((this.type == 0x55) || (this.type == 15)) || (this.type == 0x22))
                        {
                            this.Kill();
                        }
                        if (this.type == 2)
                        {
                            this.type = 1;
                            this.light = 0f;
                        }
                    }
                    if (this.type == 80)
                    {
                        flag2 = false;
                        this.wet = false;
                        if (flag && (this.ai[0] >= 0f))
                        {
                            this.Kill();
                        }
                    }
                    if (flag2)
                    {
                        if (this.wetCount == 0)
                        {
                            this.wetCount = 10;
                            if (!this.wet)
                            {
                                if (!flag)
                                {
                                    for (int k = 0; k < 10; k++)
                                    {
                                        Color newColor = new Color();
                                        int index = Dust.NewDust(new Vector2(this.position.X - 6f, (this.position.Y + (this.height / 2)) - 8f), this.width + 12, 0x18, 0x21, 0f, 0f, 0, newColor, 1f);
                                        Main.dust[index].velocity.Y -= 4f;
                                        Main.dust[index].velocity.X *= 2.5f;
                                        Main.dust[index].scale = 1.3f;
                                        Main.dust[index].alpha = 100;
                                        Main.dust[index].noGravity = true;
                                    }
                                    Main.PlaySound(0x13, (int) this.position.X, (int) this.position.Y, 1);
                                }
                                else
                                {
                                    for (int m = 0; m < 10; m++)
                                    {
                                        Color color2 = new Color();
                                        int num5 = Dust.NewDust(new Vector2(this.position.X - 6f, (this.position.Y + (this.height / 2)) - 8f), this.width + 12, 0x18, 0x23, 0f, 0f, 0, color2, 1f);
                                        Main.dust[num5].velocity.Y -= 1.5f;
                                        Main.dust[num5].velocity.X *= 2.5f;
                                        Main.dust[num5].scale = 1.3f;
                                        Main.dust[num5].alpha = 100;
                                        Main.dust[num5].noGravity = true;
                                    }
                                    Main.PlaySound(0x13, (int) this.position.X, (int) this.position.Y, 1);
                                }
                            }
                            this.wet = true;
                        }
                    }
                    else if (this.wet)
                    {
                        this.wet = false;
                        if (this.wetCount == 0)
                        {
                            this.wetCount = 10;
                            if (!this.lavaWet)
                            {
                                for (int n = 0; n < 10; n++)
                                {
                                    Color color3 = new Color();
                                    int num7 = Dust.NewDust(new Vector2(this.position.X - 6f, this.position.Y + (this.height / 2)), this.width + 12, 0x18, 0x21, 0f, 0f, 0, color3, 1f);
                                    Main.dust[num7].velocity.Y -= 4f;
                                    Main.dust[num7].velocity.X *= 2.5f;
                                    Main.dust[num7].scale = 1.3f;
                                    Main.dust[num7].alpha = 100;
                                    Main.dust[num7].noGravity = true;
                                }
                                Main.PlaySound(0x13, (int) this.position.X, (int) this.position.Y, 1);
                            }
                            else
                            {
                                for (int num8 = 0; num8 < 10; num8++)
                                {
                                    Color color4 = new Color();
                                    int num9 = Dust.NewDust(new Vector2(this.position.X - 6f, (this.position.Y + (this.height / 2)) - 8f), this.width + 12, 0x18, 0x23, 0f, 0f, 0, color4, 1f);
                                    Main.dust[num9].velocity.Y -= 1.5f;
                                    Main.dust[num9].velocity.X *= 2.5f;
                                    Main.dust[num9].scale = 1.3f;
                                    Main.dust[num9].alpha = 100;
                                    Main.dust[num9].noGravity = true;
                                }
                                Main.PlaySound(0x13, (int) this.position.X, (int) this.position.Y, 1);
                            }
                        }
                    }
                    if (!this.wet)
                    {
                        this.lavaWet = false;
                    }
                    if (this.wetCount > 0)
                    {
                        this.wetCount = (byte) (this.wetCount - 1);
                    }
                }
                this.lastPosition = this.position;
                if (this.tileCollide)
                {
                    Vector2 vector2 = this.velocity;
                    bool fallThrough = true;
                    if ((((this.type == 9) || (this.type == 12)) || ((this.type == 15) || (this.type == 13))) || (((this.type == 0x1f) || (this.type == 0x27)) || (this.type == 40)))
                    {
                        fallThrough = false;
                    }
                    if (this.aiStyle == 10)
                    {
                        if (((this.type == 0x2a) || (this.type == 0x41)) || ((this.type == 0x44) || ((this.type == 0x1f) && (this.ai[0] == 2f))))
                        {
                            this.velocity = Collision.TileCollision(this.position, this.velocity, this.width, this.height, fallThrough, fallThrough);
                        }
                        else
                        {
                            this.velocity = Collision.AnyCollision(this.position, this.velocity, this.width, this.height);
                        }
                    }
                    else if (this.aiStyle == 0x12)
                    {
                        int width = this.width - 0x24;
                        int height = this.height - 0x24;
                        Vector2 position = new Vector2((this.position.X + (this.width / 2)) - (width / 2), (this.position.Y + (this.height / 2)) - (height / 2));
                        this.velocity = Collision.TileCollision(position, this.velocity, width, height, fallThrough, fallThrough);
                    }
                    else if (this.wet)
                    {
                        Vector2 vector4 = this.velocity;
                        this.velocity = Collision.TileCollision(this.position, this.velocity, this.width, this.height, fallThrough, fallThrough);
                        velocity = (Vector2) (this.velocity * 0.5f);
                        if (this.velocity.X != vector4.X)
                        {
                            velocity.X = this.velocity.X;
                        }
                        if (this.velocity.Y != vector4.Y)
                        {
                            velocity.Y = this.velocity.Y;
                        }
                    }
                    else
                    {
                        this.velocity = Collision.TileCollision(this.position, this.velocity, this.width, this.height, fallThrough, fallThrough);
                    }
                    if (vector2 != this.velocity)
                    {
                        if (this.type == 0x5e)
                        {
                            if (this.velocity.X != vector2.X)
                            {
                                this.velocity.X = -vector2.X;
                            }
                            if (this.velocity.Y != vector2.Y)
                            {
                                this.velocity.Y = -vector2.Y;
                            }
                        }
                        else if (this.type == 0x63)
                        {
                            if ((this.velocity.Y != vector2.Y) && (vector2.Y > 5f))
                            {
                                Collision.HitTiles(this.position, this.velocity, this.width, this.height);
                                Main.PlaySound(0, (int) this.position.X, (int) this.position.Y, 1);
                                this.velocity.Y = -vector2.Y * 0.2f;
                            }
                            if (this.velocity.X != vector2.X)
                            {
                                this.Kill();
                            }
                        }
                        else if (this.type == 0x24)
                        {
                            if (this.penetrate > 1)
                            {
                                Collision.HitTiles(this.position, this.velocity, this.width, this.height);
                                Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 10);
                                this.penetrate--;
                                if (this.velocity.X != vector2.X)
                                {
                                    this.velocity.X = -vector2.X;
                                }
                                if (this.velocity.Y != vector2.Y)
                                {
                                    this.velocity.Y = -vector2.Y;
                                }
                            }
                            else
                            {
                                this.Kill();
                            }
                        }
                        else if (this.aiStyle == 0x15)
                        {
                            if (this.velocity.X != vector2.X)
                            {
                                this.velocity.X = -vector2.X;
                            }
                            if (this.velocity.Y != vector2.Y)
                            {
                                this.velocity.Y = -vector2.Y;
                            }
                        }
                        else if (this.aiStyle == 0x11)
                        {
                            if (this.velocity.X != vector2.X)
                            {
                                this.velocity.X = vector2.X * -0.75f;
                            }
                            if ((this.velocity.Y != vector2.Y) && (vector2.Y > 1.5))
                            {
                                this.velocity.Y = vector2.Y * -0.7f;
                            }
                        }
                        else if (this.aiStyle == 15)
                        {
                            bool flag4 = false;
                            if (vector2.X != this.velocity.X)
                            {
                                if (Math.Abs(vector2.X) > 4f)
                                {
                                    flag4 = true;
                                }
                                this.position.X += this.velocity.X;
                                this.velocity.X = -vector2.X * 0.2f;
                            }
                            if (vector2.Y != this.velocity.Y)
                            {
                                if (Math.Abs(vector2.Y) > 4f)
                                {
                                    flag4 = true;
                                }
                                this.position.Y += this.velocity.Y;
                                this.velocity.Y = -vector2.Y * 0.2f;
                            }
                            this.ai[0] = 1f;
                            if (flag4)
                            {
                                this.netUpdate = true;
                                Collision.HitTiles(this.position, this.velocity, this.width, this.height);
                                Main.PlaySound(0, (int) this.position.X, (int) this.position.Y, 1);
                            }
                        }
                        else if ((this.aiStyle == 3) || (this.aiStyle == 13))
                        {
                            Collision.HitTiles(this.position, this.velocity, this.width, this.height);
                            if ((this.type == 0x21) || (this.type == 0x6a))
                            {
                                if (this.velocity.X != vector2.X)
                                {
                                    this.velocity.X = -vector2.X;
                                }
                                if (this.velocity.Y != vector2.Y)
                                {
                                    this.velocity.Y = -vector2.Y;
                                }
                            }
                            else
                            {
                                this.ai[0] = 1f;
                                if (this.aiStyle == 3)
                                {
                                    this.velocity.X = -vector2.X;
                                    this.velocity.Y = -vector2.Y;
                                }
                            }
                            this.netUpdate = true;
                            Main.PlaySound(0, (int) this.position.X, (int) this.position.Y, 1);
                        }
                        else if ((this.aiStyle == 8) && (this.type != 0x60))
                        {
                            Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 10);
                            this.ai[0]++;
                            if (this.ai[0] >= 5f)
                            {
                                this.position += this.velocity;
                                this.Kill();
                            }
                            else
                            {
                                if ((this.type == 15) && (this.velocity.Y > 4f))
                                {
                                    if (this.velocity.Y != vector2.Y)
                                    {
                                        this.velocity.Y = -vector2.Y * 0.8f;
                                    }
                                }
                                else if (this.velocity.Y != vector2.Y)
                                {
                                    this.velocity.Y = -vector2.Y;
                                }
                                if (this.velocity.X != vector2.X)
                                {
                                    this.velocity.X = -vector2.X;
                                }
                            }
                        }
                        else if (this.aiStyle == 14)
                        {
                            if (this.type == 50)
                            {
                                if (this.velocity.X != vector2.X)
                                {
                                    this.velocity.X = vector2.X * -0.2f;
                                }
                                if ((this.velocity.Y != vector2.Y) && (vector2.Y > 1.5))
                                {
                                    this.velocity.Y = vector2.Y * -0.2f;
                                }
                            }
                            else
                            {
                                if (this.velocity.X != vector2.X)
                                {
                                    this.velocity.X = vector2.X * -0.5f;
                                }
                                if ((this.velocity.Y != vector2.Y) && (vector2.Y > 1f))
                                {
                                    this.velocity.Y = vector2.Y * -0.5f;
                                }
                            }
                        }
                        else if (this.aiStyle == 0x10)
                        {
                            if (this.velocity.X != vector2.X)
                            {
                                this.velocity.X = vector2.X * -0.4f;
                                if (this.type == 0x1d)
                                {
                                    this.velocity.X *= 0.8f;
                                }
                            }
                            if (((this.velocity.Y != vector2.Y) && (vector2.Y > 0.7)) && (this.type != 0x66))
                            {
                                this.velocity.Y = vector2.Y * -0.4f;
                                if (this.type == 0x1d)
                                {
                                    this.velocity.Y *= 0.8f;
                                }
                            }
                        }
                        else if ((this.aiStyle != 9) || (this.owner == Main.myPlayer))
                        {
                            this.position += this.velocity;
                            this.Kill();
                        }
                    }
                }
                if ((this.type != 7) && (this.type != 8))
                {
                    if (this.wet)
                    {
                        this.position += velocity;
                    }
                    else
                    {
                        this.position += this.velocity;
                    }
                }
                if (((((this.aiStyle != 3) || (this.ai[0] != 1f)) && ((this.aiStyle != 7) || (this.ai[0] != 1f))) && (((this.aiStyle != 13) || (this.ai[0] != 1f)) && ((this.aiStyle != 15) || (this.ai[0] != 1f)))) && (this.aiStyle != 15))
                {
                    if (this.velocity.X < 0f)
                    {
                        this.direction = -1;
                    }
                    else
                    {
                        this.direction = 1;
                    }
                }
                if (this.active)
                {
                    if (this.light > 0f)
                    {
                        float light = this.light;
                        float g = this.light;
                        float b = this.light;
                        if ((this.type == 2) || (this.type == 0x52))
                        {
                            g *= 0.75f;
                            b *= 0.55f;
                        }
                        else if (this.type == 0x5e)
                        {
                            light *= 0.5f;
                            g *= 0f;
                        }
                        else if (((this.type == 0x5f) || (this.type == 0x60)) || ((this.type == 0x67) || (this.type == 0x68)))
                        {
                            light *= 0.35f;
                            g *= 1f;
                            b *= 0f;
                        }
                        else if (this.type == 4)
                        {
                            g *= 0.1f;
                            light *= 0.5f;
                        }
                        else if (this.type == 9)
                        {
                            g *= 0.1f;
                            b *= 0.6f;
                        }
                        else if (this.type == 0x5c)
                        {
                            g *= 0.6f;
                            light *= 0.8f;
                        }
                        else if (this.type == 0x5d)
                        {
                            g *= 1f;
                            light *= 1f;
                            b *= 0.01f;
                        }
                        else if (this.type == 12)
                        {
                            light *= 0.9f;
                            g *= 0.8f;
                            b *= 0.1f;
                        }
                        else if (this.type == 14)
                        {
                            g *= 0.7f;
                            b *= 0.1f;
                        }
                        else if (this.type == 15)
                        {
                            g *= 0.4f;
                            b *= 0.1f;
                            light = 1f;
                        }
                        else if (this.type == 0x10)
                        {
                            light *= 0.1f;
                            g *= 0.4f;
                            b = 1f;
                        }
                        else if (this.type == 0x12)
                        {
                            g *= 0.7f;
                            b *= 0.3f;
                        }
                        else if (this.type == 0x13)
                        {
                            g *= 0.5f;
                            b *= 0.1f;
                        }
                        else if (this.type == 20)
                        {
                            light *= 0.1f;
                            b *= 0.3f;
                        }
                        else if (this.type == 0x16)
                        {
                            light = 0f;
                            g = 0f;
                        }
                        else if (this.type == 0x1b)
                        {
                            light *= 0f;
                            g *= 0.3f;
                            b = 1f;
                        }
                        else if (this.type == 0x22)
                        {
                            g *= 0.1f;
                            b *= 0.1f;
                        }
                        else if (this.type == 0x24)
                        {
                            light = 0.8f;
                            g *= 0.2f;
                            b *= 0.6f;
                        }
                        else if (this.type == 0x29)
                        {
                            g *= 0.8f;
                            b *= 0.6f;
                        }
                        else if ((this.type == 0x2c) || (this.type == 0x2d))
                        {
                            b = 1f;
                            light *= 0.6f;
                            g *= 0.1f;
                        }
                        else if (this.type == 50)
                        {
                            light *= 0.7f;
                            b *= 0.8f;
                        }
                        else if (this.type == 0x35)
                        {
                            light *= 0.7f;
                            g *= 0.8f;
                        }
                        else if (this.type == 0x48)
                        {
                            light *= 0.45f;
                            g *= 0.75f;
                            b = 1f;
                        }
                        else if (this.type == 0x56)
                        {
                            light *= 1f;
                            g *= 0.45f;
                            b = 0.75f;
                        }
                        else if (this.type == 0x57)
                        {
                            light *= 0.45f;
                            g = 1f;
                            b *= 0.75f;
                        }
                        else if (this.type == 0x49)
                        {
                            light *= 0.4f;
                            g *= 0.6f;
                            b *= 1f;
                        }
                        else if (this.type == 0x4a)
                        {
                            light *= 1f;
                            g *= 0.4f;
                            b *= 0.6f;
                        }
                        else if (((this.type == 0x4c) || (this.type == 0x4d)) || (this.type == 0x4e))
                        {
                            light *= 1f;
                            g *= 0.3f;
                            b *= 0.6f;
                        }
                        else if (this.type == 0x4f)
                        {
                            light = ((float) Main.DiscoR) / 255f;
                            g = ((float) Main.DiscoG) / 255f;
                            b = ((float) Main.DiscoB) / 255f;
                        }
                        else if (this.type == 80)
                        {
                            light *= 0f;
                            g *= 0.8f;
                            b *= 1f;
                        }
                        else if ((this.type == 0x53) || (this.type == 0x58))
                        {
                            light *= 0.7f;
                            g *= 0f;
                            b *= 1f;
                        }
                        else if (this.type == 100)
                        {
                            light *= 1f;
                            g *= 0.5f;
                            b *= 0f;
                        }
                        else if (this.type == 0x54)
                        {
                            light *= 0.8f;
                            g *= 0f;
                            b *= 0.5f;
                        }
                        else if ((this.type == 0x59) || (this.type == 90))
                        {
                            g *= 0.2f;
                            b *= 1f;
                            light *= 0.05f;
                        }
                        else if (this.type == 0x6a)
                        {
                            light *= 0f;
                            g *= 0.5f;
                            b *= 1f;
                        }
                        Lighting.addLight((int) ((this.position.X + (this.width / 2)) / 16f), (int) ((this.position.Y + (this.height / 2)) / 16f), light, g, b);
                    }
                    if ((this.type == 2) || (this.type == 0x52))
                    {
                        Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, new Color(), 1f);
                        goto Label_19A7;
                    }
                    if (this.type == 0x67)
                    {
                        int num15 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0x4b, 0f, 0f, 100, new Color(), 1f);
                        if (Main.rand.Next(2) == 0)
                        {
                            Main.dust[num15].noGravity = true;
                            Dust dust1 = Main.dust[num15];
                            dust1.scale *= 2f;
                        }
                        goto Label_19A7;
                    }
                    if (this.type == 4)
                    {
                        if (Main.rand.Next(5) == 0)
                        {
                            Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 14, 0f, 0f, 150, new Color(), 1.1f);
                        }
                        goto Label_19A7;
                    }
                    if (this.type != 5)
                    {
                        goto Label_19A7;
                    }
                    num16 = Main.rand.Next(3);
                    switch (num16)
                    {
                        case 0:
                            num16 = 15;
                            goto Label_1957;

                        case 1:
                            num16 = 0x39;
                            goto Label_1957;
                    }
                    num16 = 0x3a;
                    goto Label_1957;
                }
            }
            return;
        Label_1957:
            Dust.NewDust(this.position, this.width, this.height, num16, this.velocity.X * 0.5f, this.velocity.Y * 0.5f, 150, new Color(), 1.2f);
        Label_19A7:
            this.Damage();
            if ((Main.netMode != 1) && (this.type == 0x63))
            {
                Collision.SwitchTiles(this.position, this.width, this.height, this.lastPosition);
            }
            if (this.type == 0x5e)
            {
                for (int num17 = this.oldPos.Length - 1; num17 > 0; num17--)
                {
                    this.oldPos[num17] = this.oldPos[num17 - 1];
                }
                this.oldPos[0] = this.position;
            }
            this.timeLeft--;
            if (this.timeLeft <= 0)
            {
                this.Kill();
            }
            if (this.penetrate == 0)
            {
                this.Kill();
            }
            if (this.active && (this.owner == Main.myPlayer))
            {
                if (this.netUpdate2)
                {
                    this.netUpdate = true;
                }
                if (!this.active)
                {
                    this.netSpam = 0;
                }
                if (this.netUpdate)
                {
                    if (this.netSpam < 60)
                    {
                        this.netSpam += 5;
                        NetMessage.SendData(0x1b, -1, -1, "", i, 0f, 0f, 0f, 0);
                        this.netUpdate2 = false;
                    }
                    else
                    {
                        this.netUpdate2 = true;
                    }
                }
                if (this.netSpam > 0)
                {
                    this.netSpam--;
                }
            }
            if (this.active && (this.maxUpdates > 0))
            {
                this.numUpdates--;
                if (this.numUpdates >= 0)
                {
                    this.Update(i);
                }
                else
                {
                    this.numUpdates = this.maxUpdates;
                }
            }
            this.netUpdate = false;
        }
    }
}

