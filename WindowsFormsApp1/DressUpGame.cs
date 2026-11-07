using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    internal enum DressUpCategory
    {
        Hair,
        Face,
        Shirt,
        Pants,
        Shoes,
        Accessory,
        Background
    }

    internal static class DressUpState
    {
        private static readonly Dictionary<DressUpCategory, int> selections = new Dictionary<DressUpCategory, int>();
        private static readonly Dictionary<DressUpCategory, Image> selectedImages = new Dictionary<DressUpCategory, Image>();

        public static void Select(DressUpCategory category, int option, Image image)
        {
            selections[category] = option;
            selectedImages[category] = image;
        }

        public static int Get(DressUpCategory category)
        {
            int option;
            return selections.TryGetValue(category, out option) ? option : 0;
        }

        public static Image GetImage(DressUpCategory category)
        {
            Image image;
            return selectedImages.TryGetValue(category, out image) ? image : null;
        }
    }

    public sealed class DressUpPreview : PictureBox
    {
        public DressUpPreview()
        {
            DoubleBuffered = true;
            BackColor = Color.White;
            BorderStyle = BorderStyle.FixedSingle;
            SizeMode = PictureBoxSizeMode.Zoom;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (Image == null)
            {
                e.Graphics.Clear(Color.White);
                return;
            }

            DressUpCategory[] layers =
            {
                DressUpCategory.Hair,
                DressUpCategory.Face,
                DressUpCategory.Shirt,
                DressUpCategory.Pants,
                DressUpCategory.Shoes,
                DressUpCategory.Accessory
            };

            foreach (DressUpCategory layer in layers)
            {
                Image layerImage = DressUpState.GetImage(layer);
                if (layerImage != null)
                {
                    e.Graphics.DrawImage(layerImage, new Rectangle(0, 0, Width, Height));
                }
            }
        }

        private Color GetBackgroundColor()
        {
            return DressUpState.Get(DressUpCategory.Background) == 2
                ? Color.FromArgb(235, 250, 255)
                : Color.FromArgb(255, 245, 250);
        }

        private void DrawHair(Graphics g, int center)
        {
            Color color = DressUpState.Get(DressUpCategory.Hair) == 2 ? Color.Goldenrod : Color.FromArgb(70, 45, 35);
            using (SolidBrush brush = new SolidBrush(color))
            {
                g.FillEllipse(brush, center - 60, 35, 120, 85);
                if (DressUpState.Get(DressUpCategory.Hair) == 2)
                    g.FillRectangle(brush, center - 60, 70, 20, 130);
            }
        }

        private void DrawFace(Graphics g, int center, SolidBrush skin)
        {
            int option = DressUpState.Get(DressUpCategory.Face);
            using (SolidBrush feature = new SolidBrush(option == 2 ? Color.MediumVioletRed : Color.Black))
            {
                g.FillEllipse(feature, center - 27, 115, 8, 8);
                g.FillEllipse(feature, center + 19, 115, 8, 8);
                g.DrawArc(new Pen(feature, 3), center - 15, 125, 30, 20, 20, 140);
            }
        }

        private void DrawShirt(Graphics g, int center, Pen outline)
        {
            Color color = DressUpState.Get(DressUpCategory.Shirt) == 2 ? Color.LightSkyBlue : Color.Coral;
            using (SolidBrush brush = new SolidBrush(color))
            {
                Point[] body = { new Point(center - 75, 195), new Point(center - 25, 175), new Point(center + 25, 175), new Point(center + 75, 195), new Point(center + 55, 300), new Point(center - 55, 300) };
                g.FillPolygon(brush, body);
                g.DrawPolygon(outline, body);
            }
        }

        private void DrawPants(Graphics g, int center, Pen outline)
        {
            Color color = DressUpState.Get(DressUpCategory.Pants) == 2 ? Color.MediumSeaGreen : Color.MediumPurple;
            using (SolidBrush brush = new SolidBrush(color))
            {
                g.FillRectangle(brush, center - 52, 298, 48, 90);
                g.FillRectangle(brush, center + 4, 298, 48, 90);
                g.DrawRectangle(outline, center - 52, 298, 48, 90);
                g.DrawRectangle(outline, center + 4, 298, 48, 90);
            }
        }

        private void DrawShoes(Graphics g, int center, Pen outline)
        {
            Color color = DressUpState.Get(DressUpCategory.Shoes) == 2 ? Color.OrangeRed : Color.Black;
            using (SolidBrush brush = new SolidBrush(color))
            {
                g.FillEllipse(brush, center - 65, 370, 60, 25);
                g.FillEllipse(brush, center + 5, 370, 60, 25);
            }
        }

        private void DrawAccessory(Graphics g, int center, Pen outline)
        {
            if (DressUpState.Get(DressUpCategory.Accessory) == 0)
                return;

            using (Pen accessory = new Pen(Color.Gold, 5))
            {
                if (DressUpState.Get(DressUpCategory.Accessory) == 1)
                    g.DrawEllipse(accessory, center - 18, 158, 36, 20);
                else
                    g.DrawLine(accessory, center - 48, 155, center + 48, 155);
            }
        }
    }

    internal static class DressUpScreenBuilder
    {
        public static void Build(Form form, DressUpCategory category, string title, int previousForm, int nextForm, string option1, string option2)
        {
            DressUpPreview preview = form.Controls["preview"] as DressUpPreview;
            Button choice1 = form.Controls["choice1"] as Button;
            Button choice2 = form.Controls["choice2"] as Button;
            Button back = form.Controls["backButton"] as Button;
            Button next = form.Controls["nextButton"] as Button;
            Button exit = form.Controls["exitButton"] as Button;

            if (preview == null || choice1 == null || choice2 == null || back == null || next == null || exit == null)
                return;

            choice1.Click += delegate
            {
                DressUpState.Select(category, 1, choice1.Image ?? choice1.BackgroundImage);
                preview.Invalidate();
            };
            choice2.Click += delegate
            {
                DressUpState.Select(category, 2, choice2.Image ?? choice2.BackgroundImage);
                preview.Invalidate();
            };
            back.Click += delegate
            {
                Form previous = Application.OpenForms["Form" + previousForm];
                if (previous != null)
                    previous.Show();
                form.Close();
            };
            next.Click += delegate
            {
                if (nextForm == 0)
                {
                    MessageBox.Show("แต่งตัวเสร็จแล้ว!", "เกมแต่งตัว", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                Form nextScreen = CreateForm(nextForm);
                nextScreen.Show();
                form.Hide();
            };
            exit.Click += delegate { Application.Exit(); };
            preview.Invalidate();
        }

        private static Form CreateForm(int number)
        {
            switch (number)
            {
                case 3: return new Form3();
                case 4: return new Form4();
                case 5: return new Form5();
                case 6: return new Form6();
                case 7: return new Form7();
                case 8: return new Form8();
                case 9: return new Form9();
                default: throw new ArgumentOutOfRangeException("number");
            }
        }
    }
}
