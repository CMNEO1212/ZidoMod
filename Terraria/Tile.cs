namespace Terraria
{
    using System;

    public class Tile
    {
        public bool active;
        public bool checkingLiquid;
        public byte frameNumber;
        public short frameX;
        public short frameY;
        public bool lava;
        public byte liquid;
        public bool skipLiquid;
        public byte type;
        public byte wall;
        public byte wallFrameNumber;
        public byte wallFrameX;
        public byte wallFrameY;
        public bool wire;

        public object Clone()
        {
            return base.MemberwiseClone();
        }

        public bool isTheSameAs(Tile compTile)
        {
            if (this.active != compTile.active)
            {
                return false;
            }
            if (this.active)
            {
                if (this.type != compTile.type)
                {
                    return false;
                }
                if (Main.tileFrameImportant[this.type])
                {
                    if (this.frameX != compTile.frameX)
                    {
                        return false;
                    }
                    if (this.frameY != compTile.frameY)
                    {
                        return false;
                    }
                }
            }
            if (this.wall != compTile.wall)
            {
                return false;
            }
            if (this.liquid != compTile.liquid)
            {
                return false;
            }
            if (this.lava != compTile.lava)
            {
                return false;
            }
            if (this.wire != compTile.wire)
            {
                return false;
            }
            return true;
        }
    }
}

