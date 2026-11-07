using System.Drawing;

namespace WindowsFormsApp1
{
    public static class PlayerData
    {
        public static Image BaseImage { get; set; }
        public static Image Hair { get; set; }
        public static Image Face { get; set; }
        public static Image Shirt { get; set; }
        public static Image Pants { get; set; }
        public static Image Shoes { get; set; }
        public static Image Accessory { get; set; }
        public static Image Decoration { get; set; }

        public static Image CreatePreview()
        {
            if (BaseImage == null)
                return null;

            Bitmap result = new Bitmap(BaseImage.Width, BaseImage.Height);
            using (Graphics graphics = Graphics.FromImage(result))
            {
                graphics.DrawImageUnscaled(BaseImage, 0, 0);
                DrawLayer(graphics, Hair);
                DrawLayer(graphics, Face);
                DrawLayer(graphics, Shirt);
                DrawLayer(graphics, Pants);
                DrawLayer(graphics, Shoes);
                DrawLayer(graphics, Accessory);
                DrawLayer(graphics, Decoration);
            }

            return result;
        }

        private static void DrawLayer(Graphics graphics, Image layer)
        {
            if (layer != null)
                graphics.DrawImageUnscaled(layer, 0, 0);
        }

        public static void Reset()
        {
            BaseImage = null;
            Hair = null;
            Face = null;
            Shirt = null;
            Pants = null;
            Shoes = null;
            Accessory = null;
            Decoration = null;
        }
    }
}
