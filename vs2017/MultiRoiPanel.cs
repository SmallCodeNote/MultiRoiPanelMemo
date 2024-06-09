using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiRoiPanelClass
{

    static class MultiRoiPanelIcon
    {
        static private string iconString_Center = @"iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAACXBIWXMAAAG0AAABtAFMIk34AAAAGXRFWHRTb2Z0d2FyZQB3d3cuaW5rc2NhcGUub3Jnm+48GgAAARtJREFUSInNlj2OwkAMhT9nOQC3SIdA1NwgN6Bdfnbr1HsDWn4kerRbb0vFHYALcIHtw2wRD4yQSMaCSIxkWbKe3xvHsTwAAnwAR6AA3INWKNdUufl8Auk9m4qqpcASWFN93tQXNbh3reDgwQ7oOueoMmABLCJwXf+5WkCiqueaWwG0IzAhV9KKTPBnbsRjEnDO7awCST3ksWMSEJFcRHJLjrUHfSPeLLC1CsB16nrACvgGBsE/nQM/wCiIZRqbBbEU2ChHz/M23uSwgk7EhGZAFoHreF5rD4bqf2MTrAInI948yaYZgBec5FREUkuOtQdf6oeVqBuBM2UlMdX8RfJedkxTK3OsdoRydza19CdQPi38gn7Ws2Wv5PIPPMf4ROpytFYAAAAASUVORK5CYII=";
        static private string iconString_OriginalSize = @"iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAACXBIWXMAAAG0AAABtAFMIk34AAAAGXRFWHRTb2Z0d2FyZQB3d3cuaW5rc2NhcGUub3Jnm+48GgAAAYZJREFUSIntlj0vREEYhZ9hQ4GI+Ch8bGEjus0mEr0W/0EjdqmJlkYUSoXENn6DzyjUCpUCIRLZ4A+oSNYo5tzN3Nm9S+JS7SSTM3Pe3PfsvMU5C2CAZeAOqAL2l7uqXiX1ZiWFpkm7ZKQ2CewBZdJZi3rBLd5YCtZagAzQB/Raa4m2uJzPebUsMOTdC964as/JAzngSveK98EW8Cn+EhgQ3wWcez32cXPPe1xM4NS7V9RkmvrZ7qi21qA27wu0BbMzDeY5K3wEDgNuTngBXAc1AEKBJ2A94IaFB8CqziNBbQPY1Xk0UcBaWwLOAoEO4Zs2QGeTWsQ1fEHqqyXQEvgfgQ9hjzbAe5NaxAHOOb9br8IFnC8BvHi1CWAT6Bf37H/8kxccCXM4IwM4Fp4IZ3AG53O1VXNTOWTkhL5dbxO360Hx3cTtuqwfHbPrMHDaSQ6c8YTAGYtEw8DJAA+4yCwaY2KRaUy9extjphoO0tWyOi4J78Fl51+FfhFcyEQBndbflhs1N1+0Xw294Vj+IAAAAABJRU5ErkJggg==";
        static private string iconString_Rectangle = @"iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAACXBIWXMAAAG0AAABtAFMIk34AAAAGXRFWHRTb2Z0d2FyZQB3d3cuaW5rc2NhcGUub3Jnm+48GgAAAQZJREFUSIntlj0KwkAQhb+JFnZ6CMFOvIwHEMS/Q3gOCxst7QRP4QFUtPIEgqWQjEVmISTGn7ja6MCQMNl9b3Zm2BcAAYbADggBfdNDwxoYNiMPoHk+EGNrABNgih/r2gm2JMrSUlV8ONBy5QqAwFgjT9knsYLg7jIPVk4HRKQK1F0GQPXO/ho2KWZrVT2mF7mON61+U4pPzcwwmi6WOQFQAZZAJyfrUFXP6aCILIBSOn6LAOCiqqecby/Zx5v8J/gBgltjGgJtEdECePNnCMbAqgA4wPohgd0lmfukqH2lyVHi3ScuQFQGDsSS2RcRX5LZs+ceYu38lOj3IRYMJ9C+fls2Bi5XHHrPigrIyTkAAAAASUVORK5CYII=";
        static private string iconString_Quadrilateral = @"iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAACXBIWXMAAAG0AAABtAFMIk34AAAAGXRFWHRTb2Z0d2FyZQB3d3cuaW5rc2NhcGUub3Jnm+48GgAAAatJREFUSIm11j1rFFEUBuDnrmsKsdHGQgsjgqYwpBKxUEQ7K7FKk0rXKOJPUNHGSlAQFKxSiGghxMbOOo2FhpgqhSIIioRA/ADjWMxZnWx2MzO7mwunmXvmfc/3uZBwGYtYQzagrAXWdGC7MgTQXjKdgu0QHuKx4ZwL4cF7hbBMZFmmUzCCw93uegkm2uFqoBGsf3pYcxvzKaWrNTxoYzX4H6/xLpYcxE+8DE/volHBg/EC7qYEs3iDbTiHVbzAjoEJcDpcPVH4dhSfMYc9fROgiXd42uXnUSxgCWP9ElzDd+zvAbALr/ENp2oRYDe+4mZJnEcwg1+YqkNwHx/KEhm6CbciVzeQOgmaNp69+IQfXe7WnSxHu55SWsIjjKaUWhv0Ojw4gt+YrNm9Z+W98mzTEIXyg6phCv3z8qpaxsUqBFUTPYZXYfmM6I1SgrJSDQPuRSjncKyfTm7irUKzYTta+IKPmBKV0+8sao+Lkzgj7+5V3MHOgWZRQXkWK0H0BPsqJH0dQdnCOYDnOF6jZP8tnK1ama2QRfLduVVL/xL5PGkv6GE9WxYCPP0FpVIHnWFGHJ0AAAAASUVORK5CYII=";
        static private string iconString_ShowMap = @"iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAACXBIWXMAAAG0AAABtAFMIk34AAAAGXRFWHRTb2Z0d2FyZQB3d3cuaW5rc2NhcGUub3Jnm+48GgAAAR1JREFUSIntlk9Kw0AYxX/fpIkYEmjwDNID5AYewMELuDX2HJ7ElTvBI+QMoRVdB3TnToRMxsVMN21qox0RoQ8G5s/jPb5vBt4ACHANPAIGsHsO47Uqr808gOi2UYl3mwH3wANhcA5cAEvxJSngEngOZHAK3AK98uLgSgqFlZZSX9IC4GCwE5ORPAHOgNyvIyBd4xzjLvfuJwYnwE2apibLMpMkiawOlFI2z3MrIqppmhhYAK/fNYgA6rqOyrKMhghd1xHH8cb+/7/kg8HfG4x9pgC0bUtRFINnxpi9DD5EpNdaj6n4fd2gx7VKBukOb9ZaDRztEDfACy5wAPoJLsVmuIgLEZlTQPv5E7j0/63QvwLXmgpYEu7bsvDi8glx8oblWqI51gAAAABJRU5ErkJggg==";
        static private string iconString_OpenFile = @"iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAACXBIWXMAAAG0AAABtAFMIk34AAAAGXRFWHRTb2Z0d2FyZQB3d3cuaW5rc2NhcGUub3Jnm+48GgAAATJJREFUSIntljFOw0AQRd8YF5SRcgMaCqTIBWU6iqSiywGQEAkcgkNQUSQFlBSRIuUUoQdEKk4AokTYk8KzyEq8smMWqnxpZGt29b9nZrXfAAJcAi9ACugvIzWukXFzFYDUFyMxtUPgFhgTBudWwTOFtiSqSogAEteuGIhMNXPyIpIAvZIvm6rqskYFjiuKPRtugCPgo5BrA8fAoIbADzYEROQA6AIT4LGwdAKcikgf+LZcCzsphoWqvq1zuol3rH9jmp+aO+PouFxZi/aBGXDmqTpV1c+Syh+AvfW8bwZfqvruWdsKUfWWncBOoAJlxzQFBiKiDfju6whcA/MG5ACLSgG7Szbuk6b4lyFnhfeQvABZDCzJLXMoIqEs88Ker5B751+Z/hByw3AGHeq35cnIZQWnrtoxJx1CNwAAAABJRU5ErkJggg==";
        static private string iconString_Puls = @"iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAACXBIWXMAAAG0AAABtAFMIk34AAAAGXRFWHRTb2Z0d2FyZQB3d3cuaW5rc2NhcGUub3Jnm+48GgAAARVJREFUSInVlj9Ow1AMxn9fVLFwCxi6RV06de3eS1T0z04vwQUYuER3bsDWASgIOAVja4Y4yAoNJPBoVUtWLD8/2+9LnO8BCJgBj8AGsD/qxnNNPTfzBEnrdCqv1gWugRvSyNhP8ECApWdmpFCgV8KVAZlX3SbqPubKsm/DgkgaSnpxHTbd12nR1SlwFuxG0vgEv5XjL7DzHUjqAnnF3Q/2QNJJZX1lZutd+cqpy8N3vKD91C7C/rz0HwYiYAm8VXx94NLtK+Cusr6qK/IFoprxH4XY0Q+x+4Po+Au0+Re9A6/BTlvAzG6B8xYNAQVE22Cnkk+O6QDPFJQ5kZSKMi/8+QQFd/4X6U+guFqUBJ3q2nLvyfUBThP8s/a/1ZgAAAAASUVORK5CYII=";
        static private string iconString_Minus = @"iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAACXBIWXMAAAG0AAABtAFMIk34AAAAGXRFWHRTb2Z0d2FyZQB3d3cuaW5rc2NhcGUub3Jnm+48GgAAAMlJREFUSIntlk0KwyAQhb+R3CU7yaFKk/YAOUsXvUSvkkV/Fz1JYhcZwUVaIp0SChkYlFHf04fyBBBgB1yBHghfZq9YjWKzNwB9l40oWwkcgCM2sdETXEhkqUIIWCRQRbkc4JR1MNp9iuXcx2kGsRIsT1BMFUWkBHwmVhdCuE0NxFfnk3vckv9q22S9j/VlJAJOwDMTq5tNoFpO6pkb/39NV4JZBEPSt8QFGArgwWiZtYhYWeZW2zuM3vkr069h/FpEg7b6tpwVXF6EFMTzkAGT6QAAAABJRU5ErkJggg==";
        static private string iconString_Next = @"iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAACXBIWXMAAAG0AAABtAFMIk34AAAAGXRFWHRTb2Z0d2FyZQB3d3cuaW5rc2NhcGUub3Jnm+48GgAAAYNJREFUSIm11rFrVFEQxeHvbIKVnUWqYGFhlZBeEMTCSrCJWAiKiImCjVj4B9iLYCEiNqKksdDaUlAbQUNUFCsREW0EEVSSsdj3YAnustl9DgwXHsP5zdwHZy4E5/EWm6gpc7PRWm20XehAdFiupqHtx03c1k2cbSZ4Y+BalqpKF4ml9rp66DXUrY66H9Tq9UZVJVlIMjMNaSggyRxeYSPJ8SQjm9kxALua8xfu42WSY0nSFaCNe7iIz3iA9STL44LGHfsrbuESvmENz5Mc7QrQxifcwGX8wcMkT5Mc7grQxkdcwxXsw+Mkp7sEwF6cxB7cwaN/Fc1OILwbyziCFzhQVc+GFe8EMINDOIGfOIO71XjDtIAFnMIcruNqVf0Yt7PWWhe3GdZ88/2DvresYX5Ms1tsdUdN8Ls5v+NgVT0Zt+PBGAqoqi9JFrFRVRM77ch/UFXrkwq30TPg3dOKbdOFrVm811+ZK0m6WpnnmvMd/d35v5b+Cv2nRbugu3q2vG7E8xfeAwNcia6/qAAAAABJRU5ErkJggg==";
        static private string iconString_Prev = @"iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAACXBIWXMAAAG0AAABtAFMIk34AAAAGXRFWHRTb2Z0d2FyZQB3d3cuaW5rc2NhcGUub3Jnm+48GgAAAYhJREFUSIm11r2KFFEQhuGn2sXUwMBoESNNHBYx8wcDL2AiMRBMlBnFxEgvwEgEDQ0UTBQTo80MxcxAVFyVZU0MRARBM4WdMjjdMog907PTFhQ0nDrfW1QdqhoCl/Ee28glfbvWGtfaLvUg2ubjqGkHcRf39GMXMaq1/5RlLTP14VhrylWhqqmTnrKf1qqqmWFzLCJ2RcThWTE7AkREFRFn8BavI2JfL4AoNsQrPMLP+mj30oCIOI0XeIIfuIqH8+7NBUTE8Yh4hqfKy7iG2/jcJbGVGcLHcAOnlJJcx8cuonMBEXEeD/BVyXhh4cbaSrSO+9iLc9jfKyAzv2XmBRzFd9zEFezpBTAFepmZJzDEAdypv1t7txBgCrSOQ0rTh7iFI10hzWgddBxkq3iszJut+u7qXzGDRnfhUZGZnzLzLE4q/YFfbfE7HnaZ+Vx5BIPM/NIW17lZLZAJ3syKqUzN7mVg/9CFyQo2lZU5iog+VmYoKxM+ULb//1r6o4Y4xob+flve1eLxG0PXCwG6RTGAAAAAAElFTkSuQmCC";

        static public Image icon_Center { get { return ImageFromBase64String(iconString_Center); } }
        static public Image icon_OriginalSize { get { return ImageFromBase64String(iconString_OriginalSize); } }
        static public Image icon_Rectangle { get { return ImageFromBase64String(iconString_Rectangle); } }
        static public Image icon_Quadrilateral { get { return ImageFromBase64String(iconString_Quadrilateral); } }
        static public Image icon_ShowMap { get { return ImageFromBase64String(iconString_ShowMap); } }
        static public Image icon_OpenFile { get { return ImageFromBase64String(iconString_OpenFile); } }
        static public Image icon_Puls { get { return ImageFromBase64String(iconString_Puls); } }
        static public Image icon_Minus { get { return ImageFromBase64String(iconString_Minus); } }
        static public Image icon_Next { get { return ImageFromBase64String(iconString_Next); } }
        static public Image icon_Prev { get { return ImageFromBase64String(iconString_Prev); } }

        static public Image ImageFromBase64String(string iconImage)
        {
            byte[] imageBytes = Convert.FromBase64String(iconImage);
            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                Image img = Image.FromStream(ms);
                return img;

            }
        }
    }

    class MultiRoiPanel
    {
        public MultiRoiPanel(Panel panel)
        {
            panel_Parent = panel;
            InitializeComponent();

            panel.Refresh();
        }

        static class resources
        {
            static public Image GetObject(string str)
            {
                if (str == "toolStripButton_SetCenter.Image") return MultiRoiPanelIcon.icon_Center;
                if (str == "toolStripButton_SetOrgSize.Image") return MultiRoiPanelIcon.icon_OriginalSize;
                if (str == "toolStripButton_EditMode.Image") return MultiRoiPanelIcon.icon_Quadrilateral;
                if (str == "toolStripButton_ShowMap.Image") return MultiRoiPanelIcon.icon_ShowMap;
                if (str == "toolStripButton_OpenFile.Image") return MultiRoiPanelIcon.icon_OpenFile;
                if (str == "toolStripButton_RemoveArea.Image") return MultiRoiPanelIcon.icon_Minus;
                if (str == "toolStripButton_AddArea.Image") return MultiRoiPanelIcon.icon_Puls;

                return MultiRoiPanelIcon.icon_Center;
            }
        }

        private Panel panel_Parent;
        private ToolStripContainer toolStripContainer_Main;
        private Panel panel_Frame;
        private TextBox textBox_EditView;
        private Button button_MoveLeft;
        private Button button_MoveRight;
        private Button button_MoveDown;
        private Button button_MoveUp;
        private Panel panel_Canvas;
        private ToolStrip toolStrip_ImageControl;
        private ToolStripButton toolStripButton_OpenFile;
        private ToolStripSeparator toolStripSeparator_SizeControl;
        private ToolStripComboBox toolStripComboBox_Magnification;
        private ToolStripButton toolStripButton_SetOrgSize;
        private ToolStripSeparator toolStripSeparator_MoveControl;
        private ToolStripButton toolStripButton_SetCenter;
        private ToolStripSeparator toolStripSeparator_PositionView;
        private ToolStripLabel toolStripLabel_viewImagePoint;
        private ToolStripSeparator toolStripSeparator_AreaControl;
        private ToolStripButton toolStripButton_RemoveArea;
        private ToolStripButton toolStripButton_AddArea;
        private ToolStripLabel toolStripLabel_ActiveAreaIndex;
        private ToolStripButton toolStripButton_EditMode;
        private ToolStripSeparator toolStripSeparator_CanvasView;
        private ToolStripComboBox toolStripComboBox_CanvasExtentionFactor;
        private ToolStripButton toolStripButton_ShowMap;

        AreaCorners areaCorners;

        Dictionary<string, Image> EditModes;
        string EditModeKey = "Quadrilateral";
        private Bitmap _viewImage;
        public Bitmap viewImage
        {
            get { return _viewImage; }
            set
            {
                if (_viewImage != null) _viewImage.Dispose();
                _viewImage = value;

                panel_Canvas.Refresh();
            }
        }
        private Point _viewImageFocusPoint;
        public Point viewImageFocusPoint
        {
            get { return _viewImageFocusPoint; }
            set
            {
                _viewImageFocusPoint = value;
                resetCanvasLocation();


            }
        }
        public float magnification { get { return float.Parse(toolStripComboBox_Magnification.Text) / 100f; } }
        public int CanvasExtentionFactor { get { return int.Parse(toolStripComboBox_CanvasExtentionFactor.Text); } }
        int MoveButtonsAlignmentOffset = 12;
        bool panelMouseDown = false;
        int selectedCornerIndex = -1;

        Point selectedCornerPoint;
        Point panelFrameMouseDownPoint;
        Point panelFrameMouseDown_viewImageFocusPointBase;

        public double Distance(Point point1, Point point2)
        {
            int dx = point2.X - point1.X;
            int dy = point2.Y - point1.Y;

            return Math.Sqrt(dx * dx + dy * dy);
        }

        private Point getImagePointFromCanvasLocation(Point p)
        {
            float drawImageWidth = viewImage.Width * magnification;
            float drawImageHeight = viewImage.Height * magnification;

            int X = (int)((p.X - ((CanvasExtentionFactor - 1) / 2) * drawImageWidth) / magnification);
            int Y = (int)((p.Y - ((CanvasExtentionFactor - 1) / 2) * drawImageHeight) / magnification);

            return new Point(X, Y);
        }
        public void resetCanvasLocation()
        {
            if (viewImage != null)
            {
                float drawImageWidth = viewImage.Width * magnification;
                float drawImageHeight = viewImage.Height * magnification;

                float canvasFocusPointX = ((CanvasExtentionFactor - 1) / 2) * drawImageWidth + viewImageFocusPoint.X * magnification;
                float canvasFocusPointY = ((CanvasExtentionFactor - 1) / 2) * drawImageHeight + viewImageFocusPoint.Y * magnification;

                panel_Canvas.Left = (int)(panel_Frame.Width / 2 - canvasFocusPointX);
                panel_Canvas.Top = (int)(panel_Frame.Height / 2 - canvasFocusPointY);
            }
        }
        private void drawPanelCanvas()
        {
            if (panel_Canvas.InvokeRequired) { panel_Canvas.Invoke((Action)(() => drawPanelCanvas())); }
            else
            {
                if (viewImage != null)
                {
                    float drawImageWidth = viewImage.Width * magnification;
                    float drawImageHeight = viewImage.Height * magnification;

                    int xRange = CanvasExtentionFactor; int yRange = CanvasExtentionFactor;
                    panel_Canvas.Width = (int)(drawImageWidth * xRange);
                    panel_Canvas.Height = (int)(drawImageHeight * yRange);

                    int LocationX = (int)(panel_Canvas.Width / 2 - drawImageWidth / 2);
                    int LocationY = (int)(panel_Canvas.Height / 2 - drawImageHeight / 2);

                    Graphics g = panel_Canvas.CreateGraphics();
                    g.DrawImage(viewImage, LocationX, LocationY, drawImageWidth, drawImageHeight);
                    areaCorners.DrawCorners(g, LocationX, LocationY, magnification);

                    g.Dispose();

                    resetCanvasLocation();
                }
            }
        }

        private void ControlInstanceSetup()
        {
            this.toolStripContainer_Main = new System.Windows.Forms.ToolStripContainer();
            this.panel_Frame = new System.Windows.Forms.Panel();
            this.textBox_EditView = new System.Windows.Forms.TextBox();
            this.button_MoveRight = new System.Windows.Forms.Button();
            this.button_MoveDown = new System.Windows.Forms.Button();
            this.button_MoveLeft = new System.Windows.Forms.Button();
            this.button_MoveUp = new System.Windows.Forms.Button();
            this.panel_Canvas = new System.Windows.Forms.Panel();
            this.toolStrip_ImageControl = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_OpenFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator_SizeControl = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripComboBox_Magnification = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButton_SetOrgSize = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator_MoveControl = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_SetCenter = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator_PositionView = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel_viewImagePoint = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator_AreaControl = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_RemoveArea = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_AddArea = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel_ActiveAreaIndex = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton_EditMode = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator_CanvasView = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripComboBox_CanvasExtentionFactor = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButton_ShowMap = new System.Windows.Forms.ToolStripButton();

            // 
            // panel_Canvas
            // 
            this.panel_Canvas.Location = new System.Drawing.Point(panel_Frame.Width / 2 - 50, panel_Frame.Height / 2 - 50);
            this.panel_Canvas.Name = "panel_Canvas";
            this.panel_Canvas.Size = new System.Drawing.Size(100, 100);


            this.panel_Parent.Controls.Clear();
            this.panel_Parent.Controls.Add(this.toolStripContainer_Main);

        }
        private void InitializeComponent()
        {
            ControlInstanceSetup();
            toolStripContainerInitialize();
            panelFrameInitialize();

            EditModes = new Dictionary<string, Image>
            {
                { "Quadrilateral", MultiRoiPanelIcon.icon_Quadrilateral },
                { "Rectangle", MultiRoiPanelIcon.icon_Rectangle }
            };
        }
        private void toolStripContainerInitialize()
        {
            // 
            // toolStripContainer_Main.BottomToolStripPanel
            // 
            this.toolStripContainer_Main.BottomToolStripPanel.Controls.Add(this.toolStrip_ImageControl);
            // 
            // toolStripContainer_Main.ContentPanel
            // 
            this.toolStripContainer_Main.ContentPanel.Controls.Add(this.panel_Frame);
            this.toolStripContainer_Main.ContentPanel.Size = new System.Drawing.Size(500, 450);
            this.toolStripContainer_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer_Main.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer_Main.Name = "toolStripContainer_Main";
            this.toolStripContainer_Main.Size = new System.Drawing.Size(500, 500);
            this.toolStripContainer_Main.TabIndex = 0;
            this.toolStripContainer_Main.Text = "toolStripContainer1";
            // 
            // toolStrip_ImageControl
            // 
            this.toolStrip_ImageControl.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip_ImageControl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_OpenFile,
            this.toolStripSeparator_SizeControl,
            this.toolStripComboBox_Magnification,
            this.toolStripButton_SetOrgSize,
            this.toolStripSeparator_MoveControl,
            this.toolStripButton_SetCenter,
            this.toolStripSeparator_PositionView,
            this.toolStripLabel_viewImagePoint,
            this.toolStripSeparator_AreaControl,
            this.toolStripButton_RemoveArea,
            this.toolStripButton_AddArea,
            this.toolStripLabel_ActiveAreaIndex,
            this.toolStripButton_EditMode,
            this.toolStripSeparator_CanvasView,
            this.toolStripComboBox_CanvasExtentionFactor,
            this.toolStripButton_ShowMap});
            this.toolStrip_ImageControl.Location = new System.Drawing.Point(3, 0);
            this.toolStrip_ImageControl.Name = "toolStrip_ImageControl";
            this.toolStrip_ImageControl.Size = new System.Drawing.Size(374, 25);
            this.toolStrip_ImageControl.TabIndex = 0;
            // 
            // toolStripButton_OpenFile
            // 
            this.toolStripButton_OpenFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_OpenFile.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_OpenFile.Image")));
            this.toolStripButton_OpenFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_OpenFile.Name = "toolStripButton_OpenFile";
            this.toolStripButton_OpenFile.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_OpenFile.Text = "OpenFile";
            this.toolStripButton_OpenFile.Click += new System.EventHandler(this.toolStripButton_OpenFile_Click);
            // 
            // toolStripSeparator_SizeControl
            // 
            this.toolStripSeparator_SizeControl.Name = "toolStripSeparator_SizeControl";
            this.toolStripSeparator_SizeControl.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripComboBox_Magnification
            // 
            this.toolStripComboBox_Magnification.AutoSize = false;
            this.toolStripComboBox_Magnification.DropDownWidth = 40;
            this.toolStripComboBox_Magnification.Items.AddRange(new object[] {
            "5",
            "10",
            "25",
            "50",
            "75",
            "100",
            "150",
            "200",
            "400"});
            this.toolStripComboBox_Magnification.Name = "toolStripComboBox_Magnification";
            this.toolStripComboBox_Magnification.Size = new System.Drawing.Size(45, 23);
            this.toolStripComboBox_Magnification.Text = "100";
            this.toolStripComboBox_Magnification.ToolTipText = "ImageMagnification";
            this.toolStripComboBox_Magnification.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBox_Magnification_SelectedIndexChanged);
            // 
            // toolStripButton_SetOrgSize
            // 
            this.toolStripButton_SetOrgSize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_SetOrgSize.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_SetOrgSize.Image")));
            this.toolStripButton_SetOrgSize.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_SetOrgSize.Name = "toolStripButton_SetOrgSize";
            this.toolStripButton_SetOrgSize.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_SetOrgSize.Text = "OriginalSize";
            this.toolStripButton_SetOrgSize.Click += new System.EventHandler(this.toolStripButton_SetOrgSize_Click);
            // 
            // toolStripSeparator_MoveControl
            // 
            this.toolStripSeparator_MoveControl.Name = "toolStripSeparator_MoveControl";
            this.toolStripSeparator_MoveControl.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton_SetCenter
            // 
            this.toolStripButton_SetCenter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_SetCenter.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_SetCenter.Image")));
            this.toolStripButton_SetCenter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_SetCenter.Name = "toolStripButton_SetCenter";
            this.toolStripButton_SetCenter.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_SetCenter.Text = "SetCenter";
            this.toolStripButton_SetCenter.Click += new System.EventHandler(this.toolStripButton_SetCenter_Click);
            // 
            // toolStripSeparator_PositionView
            // 
            this.toolStripSeparator_PositionView.Name = "toolStripSeparator_PositionView";
            this.toolStripSeparator_PositionView.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel_viewImagePoint
            // 
            this.toolStripLabel_viewImagePoint.Name = "toolStripLabel_viewImagePoint";
            this.toolStripLabel_viewImagePoint.Size = new System.Drawing.Size(40, 22);
            this.toolStripLabel_viewImagePoint.Text = "{ - , - }";
            this.toolStripLabel_viewImagePoint.ToolTipText = "viewImagePoint";
            // 
            // toolStripSeparator_AreaControl
            // 
            this.toolStripSeparator_AreaControl.Name = "toolStripSeparator_AreaControl";
            this.toolStripSeparator_AreaControl.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton_RemoveArea
            // 
            this.toolStripButton_RemoveArea.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_RemoveArea.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_RemoveArea.Image")));
            this.toolStripButton_RemoveArea.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_RemoveArea.Name = "toolStripButton_RemoveArea";
            this.toolStripButton_RemoveArea.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_RemoveArea.Text = "RemoveArea";
            this.toolStripButton_RemoveArea.Click += new System.EventHandler(this.toolStripButton_RemoveArea_Click);
            // 
            // toolStripButton_AddArea
            // 
            this.toolStripButton_AddArea.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_AddArea.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_AddArea.Image")));
            this.toolStripButton_AddArea.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_AddArea.Name = "toolStripButton_AddArea";
            this.toolStripButton_AddArea.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_AddArea.Text = "AddArea";
            this.toolStripButton_AddArea.Click += new System.EventHandler(this.toolStripButton_AddArea_Click);
            // 
            // toolStripLabel_ActiveAreaIndex
            // 
            this.toolStripLabel_ActiveAreaIndex.Name = "toolStripLabel_ActiveAreaIndex";
            this.toolStripLabel_ActiveAreaIndex.Size = new System.Drawing.Size(16, 22);
            this.toolStripLabel_ActiveAreaIndex.Text = "...";
            this.toolStripLabel_ActiveAreaIndex.ToolTipText = "ActiveAreaIndex";
            // 
            // toolStripButton_EditMode
            // 
            this.toolStripButton_EditMode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_EditMode.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_EditMode.Image")));
            this.toolStripButton_EditMode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_EditMode.Name = "toolStripButton_EditMode";
            this.toolStripButton_EditMode.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_EditMode.Text = "EditMode";
            this.toolStripButton_EditMode.Click += new System.EventHandler(this.toolStripButton_EditMode_Click);
            // 
            // toolStripSeparator_CanvasView
            // 
            this.toolStripSeparator_CanvasView.Name = "toolStripSeparator_CanvasView";
            this.toolStripSeparator_CanvasView.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripComboBox_CanvasExtentionFactor
            // 
            this.toolStripComboBox_CanvasExtentionFactor.AutoSize = false;
            this.toolStripComboBox_CanvasExtentionFactor.DropDownWidth = 30;
            this.toolStripComboBox_CanvasExtentionFactor.Items.AddRange(new object[] {
            "3",
            "5",
            "7",
            "9",
            "11",
            "13",
            "15",
            "17"});
            this.toolStripComboBox_CanvasExtentionFactor.Name = "toolStripComboBox_CanvasExtentionFactor";
            this.toolStripComboBox_CanvasExtentionFactor.Size = new System.Drawing.Size(35, 23);
            this.toolStripComboBox_CanvasExtentionFactor.Text = "3";
            this.toolStripComboBox_CanvasExtentionFactor.ToolTipText = "CanvasExtendValue";
            this.toolStripComboBox_CanvasExtentionFactor.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBox_CanvasExtentionFactor_SelectedIndexChanged);
            // 
            // toolStripButton_ShowMap
            // 
            this.toolStripButton_ShowMap.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_ShowMap.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_ShowMap.Image")));
            this.toolStripButton_ShowMap.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_ShowMap.Name = "toolStripButton_ShowMap";
            this.toolStripButton_ShowMap.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_ShowMap.Text = "ShowMap";
            this.toolStripButton_ShowMap.Click += new System.EventHandler(this.toolStripButton_ShowMap_Click);
            // 
            // panel_Frame
            // 
            this.panel_Frame.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel_Frame.Controls.Add(this.textBox_EditView);
            this.panel_Frame.Controls.Add(this.button_MoveRight);
            this.panel_Frame.Controls.Add(this.button_MoveDown);
            this.panel_Frame.Controls.Add(this.button_MoveLeft);
            this.panel_Frame.Controls.Add(this.button_MoveUp);
            this.panel_Frame.Controls.Add(this.panel_Canvas);
            this.panel_Frame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Frame.Location = new System.Drawing.Point(0, 0);
            this.panel_Frame.Name = "panel_Frame";
            this.panel_Frame.Size = new System.Drawing.Size(500, 450);
            this.panel_Frame.TabIndex = 0;
            this.panel_Frame.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_Frame_MouseDown);
            this.panel_Frame.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_Frame_MouseMove);
            // 
            // textBox_EditView
            // 
            this.textBox_EditView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBox_EditView.Location = new System.Drawing.Point(0, 367);
            this.textBox_EditView.Multiline = true;
            this.textBox_EditView.Name = "textBox_EditView";
            this.textBox_EditView.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_EditView.Size = new System.Drawing.Size(500, 83);
            this.textBox_EditView.TabIndex = 5;
            this.textBox_EditView.WordWrap = false;
            // 
            // button_MoveRight
            // 
            this.button_MoveRight.Location = new System.Drawing.Point(474, 182);
            this.button_MoveRight.Name = "button_MoveRight";
            this.button_MoveRight.Size = new System.Drawing.Size(23, 120);
            this.button_MoveRight.TabIndex = 2;
            this.button_MoveRight.UseVisualStyleBackColor = true;
            this.button_MoveRight.Click += new System.EventHandler(this.button_Move_Click);
            this.button_MoveRight.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.button_MoveRight.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            // 
            // button_MoveDown
            // 
            this.button_MoveDown.Location = new System.Drawing.Point(190, 335);
            this.button_MoveDown.Name = "button_MoveDown";
            this.button_MoveDown.Size = new System.Drawing.Size(120, 23);
            this.button_MoveDown.TabIndex = 1;
            this.button_MoveDown.UseVisualStyleBackColor = true;
            this.button_MoveDown.Click += new System.EventHandler(this.button_Move_Click);
            this.button_MoveDown.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.button_MoveDown.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            // 
            // button_MoveLeft
            // 
            this.button_MoveLeft.Location = new System.Drawing.Point(3, 182);
            this.button_MoveLeft.Name = "button_MoveLeft";
            this.button_MoveLeft.Size = new System.Drawing.Size(23, 120);
            this.button_MoveLeft.TabIndex = 3;
            this.button_MoveLeft.UseVisualStyleBackColor = true;
            this.button_MoveLeft.Click += new System.EventHandler(this.button_Move_Click);
            this.button_MoveLeft.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.button_MoveLeft.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            // 
            // button_MoveUp
            // 
            this.button_MoveUp.Location = new System.Drawing.Point(190, 3);
            this.button_MoveUp.Name = "button_MoveUp";
            this.button_MoveUp.Size = new System.Drawing.Size(120, 23);
            this.button_MoveUp.TabIndex = 0;
            this.button_MoveUp.UseVisualStyleBackColor = true;
            this.button_MoveUp.Click += new System.EventHandler(this.button_Move_Click);
            this.button_MoveUp.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.button_MoveUp.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            // 
            // panel_Canvas
            // 
            this.panel_Canvas.BackColor = System.Drawing.SystemColors.Control;
            this.panel_Canvas.Location = new System.Drawing.Point(116, 60);
            this.panel_Canvas.Name = "panel_Canvas";
            this.panel_Canvas.Size = new System.Drawing.Size(263, 242);
            this.panel_Canvas.TabIndex = 4;
            this.panel_Canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Canvas_Paint);
            this.panel_Canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_Canvas_MouseDown);
            this.panel_Canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_Canvas_MouseMove);
            this.panel_Canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel_Canvas_MouseUp);

        }
        private void panelFrameInitialize()
        {
            areaCorners = new AreaCorners();
            textBox_EditView.Height = textBox_EditView.Font.Height * 5;
            MoveButtonsAlignment();
        }

        private void MoveButtonsAlignment()
        {
            button_MoveDown.Top = panel_Frame.Height - button_MoveDown.Height - textBox_EditView.Height - MoveButtonsAlignmentOffset;
            button_MoveDown.Left = (panel_Frame.Width - button_MoveDown.Width) / 2;

            button_MoveUp.Top = MoveButtonsAlignmentOffset;
            button_MoveUp.Left = (panel_Frame.Width - button_MoveUp.Width) / 2;

            button_MoveLeft.Top = (panel_Frame.Height - textBox_EditView.Height - button_MoveLeft.Height) / 2;
            button_MoveLeft.Left = MoveButtonsAlignmentOffset;

            button_MoveRight.Top = (panel_Frame.Height - textBox_EditView.Height - button_MoveRight.Height) / 2;
            button_MoveRight.Left = panel_Frame.Width - button_MoveRight.Width - MoveButtonsAlignmentOffset;
        }

        private void button_MouseEnter(object sender, EventArgs e)
        {
            int Angle = 0;
            if (sender == button_MoveUp) { Angle = 0; }
            else if (sender == button_MoveRight) { Angle = 90; }
            else if (sender == button_MoveDown) { Angle = 180; }
            else if (sender == button_MoveLeft) { Angle = 270; }

            Button button = (Button)sender;
            int x = button.Width / 2;
            int y = button.Height / 2;
            int w = (int)(button.Width * 0.6);
            int h = (int)(button.Height * 0.6);

            if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
            {
                if (button.Image == null) { button.Image = new Bitmap(button.Width, button.Height); }
                Graphics g = Graphics.FromImage(button.Image);
                Brush b = Brushes.Black;

                int size = h < w ? h : w;
                int yo = w < h ? size / 2 : 0;
                int xo = h < w ? size / 2 : 0;

                DrawIcon.DrawRoundedTriangle(g, b, x + xo, y + yo, size, size, Angle);
                DrawIcon.DrawRoundedTriangle(g, b, x - xo, y - yo, size, size, Angle);
                g.Dispose();
            }
            else
            {
                if (button.Image == null) { button.Image = new Bitmap(button.Width, button.Height); }
                Graphics g = Graphics.FromImage(button.Image);
                Brush b = Brushes.Black;
                int size = h < w ? h : w;

                DrawIcon.DrawRoundedTriangle(g, b, x, y, size, size, Angle);
                g.Dispose();
            }
        }
        private void button_MouseLeave(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button.Image != null) { button.Image.Dispose(); button.Image = new Bitmap(button.Width, button.Height); }
        }

        private void toolStripButton_EditMode_Click(object sender, EventArgs e)
        {
            if (EditModeKey == "Quadrilateral") EditModeKey = "Rectangle";
            else if (EditModeKey == "Rectangle") EditModeKey = "Quadrilateral";

            toolStripButton_EditMode.Image = EditModes[EditModeKey];
        }
        private void toolStripButton_ShowMap_Click(object sender, EventArgs e)
        {
            textBox_EditView.Visible = !textBox_EditView.Visible;

            if (textBox_EditView.Visible)
            {
                textBox_EditView.Height = textBox_EditView.Font.Height * 5;
                textBox_EditView.Text = areaCorners.ToString();
            }
            else
            {
                textBox_EditView.Height = 0;
            }
            MoveButtonsAlignment();
        }
        private void toolStripButton_OpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() != DialogResult.OK) return;
            viewImage = new Bitmap(ofd.FileName);
            viewImageFocusPoint = new Point(viewImage.Width / 2, viewImage.Height / 2);
        }

        private void panel_Canvas_Paint(object sender, PaintEventArgs e)
        {
            drawPanelCanvas();
        }

        private void panel_Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (viewImage != null)
            {
                selectedCornerPoint = getImagePointFromCanvasLocation(e.Location);
                selectedCornerIndex = areaCorners.SearchCornerIndex(selectedCornerPoint);
                areaCorners.ActiveIndex = areaCorners.SearchAreaIndex(selectedCornerPoint);

                if (areaCorners.ActiveIndex >= 0)
                {
                    toolStripLabel_ActiveAreaIndex.Text = areaCorners.ActiveIndex.ToString();
                }
                else { toolStripLabel_ActiveAreaIndex.Text = "..."; }

                Point screenMouseDownPoint = panel_Canvas.PointToScreen(e.Location);
                panelFrameMouseDownPoint = panel_Frame.PointToClient(screenMouseDownPoint);
                panelFrameMouseDown_viewImageFocusPointBase = viewImageFocusPoint;
                panelMouseDown = true;

            }
        }
        private void panel_Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            Point screenMouseUpPoint = panel_Canvas.PointToScreen(e.Location);
            Point panelFrameMouseUpPoint = panel_Frame.PointToClient(screenMouseUpPoint);

            if (selectedCornerIndex == -1 && Distance(panelFrameMouseUpPoint, panelFrameMouseDownPoint) <= 3)
            {
                viewImageFocusPoint = selectedCornerPoint;
            }

            panelMouseDown = false;
            selectedCornerIndex = -1;

            panel_Frame.Refresh();
        }
        private void panel_Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            Point screenMouseMovePoint = panel_Canvas.PointToScreen(e.Location);
            Point panelFrameMouseMovePoint = panel_Frame.PointToClient(screenMouseMovePoint);

            if (panelMouseDown && selectedCornerIndex == -1 && Distance(panelFrameMouseMovePoint, panelFrameMouseDownPoint) > 3)
            {
                int dx = (int)((panelFrameMouseMovePoint.X - panelFrameMouseDownPoint.X) / magnification);
                int dy = (int)((panelFrameMouseMovePoint.Y - panelFrameMouseDownPoint.Y) / magnification);

                viewImageFocusPoint = panelFrameMouseDown_viewImageFocusPointBase
                    - new Size(dx, dy);
            }
            else if (panelMouseDown && selectedCornerIndex >= 0)
            {
                int dx = (int)((panelFrameMouseMovePoint.X - panelFrameMouseDownPoint.X) / magnification);
                int dy = (int)((panelFrameMouseMovePoint.Y - panelFrameMouseDownPoint.Y) / magnification);

                areaCorners.UpdateCorner(selectedCornerIndex, selectedCornerPoint + new Size(dx, dy));
                panel_Frame.Refresh();

                if (textBox_EditView.Visible)
                {
                    textBox_EditView.Text = areaCorners.ToString();
                }
            }

            if (viewImage != null)
            {
                toolStripLabel_viewImagePoint.Text = getImagePointFromCanvasLocation(e.Location).ToString();
            }
        }
        private void panel_Frame_MouseDown(object sender, MouseEventArgs e)
        {
            if (viewImage == null)
            {
                toolStripButton_OpenFile_Click(null, null);
            }
        }

        private void toolStripComboBox_Magnification_SelectedIndexChanged(object sender, EventArgs e)
        {
            areaCorners.SearchRadius = (int)(5 / magnification);
            panel_Frame.Refresh();
        }

        private void toolStripButton_SetCenter_Click(object sender, EventArgs e)
        {
            if (viewImage != null)
            {
                viewImageFocusPoint = new Point(viewImage.Width / 2, viewImage.Height / 2);
            }
        }

        private void toolStripComboBox_CanvasExtentionFactor_SelectedIndexChanged(object sender, EventArgs e)
        {
            panel_Frame.Refresh();
        }

        private void panel_Frame_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripLabel_viewImagePoint.Text = "{ - , - }";
        }

        private void button_Move_Click(object sender, EventArgs e)
        {
            if (viewImage != null)
            {
                int stepX = 0;
                int stepY = 0;
                int baseX = (int)(panel_Frame.Width / magnification / 2);
                int baseY = (int)(panel_Frame.Height / magnification / 2);

                if (sender == button_MoveUp) stepY = -baseY;
                if (sender == button_MoveDown) stepY = baseY;
                if (sender == button_MoveLeft) stepX = -baseX;
                if (sender == button_MoveRight) stepX = baseX;

                viewImageFocusPoint = new Point(viewImageFocusPoint.X + stepX, viewImageFocusPoint.Y + stepY);
            }
        }
        private void toolStripButton_AddArea_Click(object sender, EventArgs e)
        {
            int edgeLength = panel_Frame.Width > panel_Frame.Height ? panel_Frame.Width : panel_Frame.Height;
            areaCorners.AddArea(viewImageFocusPoint, edgeLength / 2 / magnification);

            toolStripLabel_ActiveAreaIndex.Text = areaCorners.ActiveIndex.ToString();
            textBox_EditView.Text = areaCorners.ToString();

            panel_Frame.Refresh();
        }
        private void toolStripButton_SetOrgSize_Click(object sender, EventArgs e)
        {
            toolStripComboBox_Magnification.Text = "100";
        }
        private void toolStripButton_RemoveArea_Click(object sender, EventArgs e)
        {
            areaCorners.RemoveArea();
            panel_Frame.Refresh();
        }

    }

    public class AreaCorners
    {
        public AreaCorners()
        {
            AreaCornerList = new List<AreaCorner>();
            LastIndex = -1;

        }
        private List<AreaCorner> AreaCornerList;

        public int SearchRadius = 5;
        public int CornerCircleRadius = 5;
        public int LastIndex { get; private set; }
        public int ActiveIndex;

        public List<AreaCorner> SearchCorner(Point point, float R)
        {
            return SearchCorner(point.X, point.Y, R);
        }

        public List<AreaCorner> SearchCorner(float X, float Y, float R)
        {
            List<AreaCorner> result = new List<AreaCorner>();
            foreach (var corner in AreaCornerList)
            {
                if (corner.CheckDistance(X, Y, R))
                {
                    result.Add(corner);
                }
            }
            return result;
        }

        public int SearchCornerIndex(Point point)
        {
            return SearchCornerIndex(point.X, point.Y, SearchRadius);
        }

        public int SearchCornerIndex(float X, float Y)
        {
            return SearchCornerIndex(X, Y, SearchRadius);
        }

        public int SearchCornerIndex(float X, float Y, float R)
        {
            int result = -1;

            for (int i = 0; i < AreaCornerList.Count; i++)
            {
                if (AreaCornerList[i].CheckDistance(X, Y, R)) { result = i; }
            }

            return result;
        }

        public int SearchAreaIndex(Point point)
        {
            return SearchAreaIndex(point.X, point.Y, SearchRadius);
        }
        public int SearchAreaIndex(float X, float Y)
        {
            return SearchAreaIndex(X, Y, SearchRadius);
        }

        public int SearchAreaIndex(float X, float Y, float R)
        {
            int result = -1;

            for (int i = 0; i < AreaCornerList.Count; i++)
            {
                if (AreaCornerList[i].CheckDistance(X, Y, R)) { result = AreaCornerList[i].index; }
            }

            return result;
        }

        public void UpdateCorner(int i, Point point)
        {
            if (i < AreaCornerList.Count)
            {
                AreaCornerList[i].X = point.X;
                AreaCornerList[i].Y = point.Y;
            }
        }

        public void RemoveArea()
        {
            RemoveArea(this.ActiveIndex);
        }

        public void RemoveArea(int TargetAreaIndex)
        {
            AreaCornerList.RemoveAll(ac => ac.index == TargetAreaIndex);

            foreach (var areaCorner in AreaCornerList)
            {
                if (areaCorner.index > TargetAreaIndex)
                {
                    areaCorner.index--;
                }
            }

        }
        public void AddArea(Point point, float EdgeLength)
        {
            AddArea(point.X, point.Y, EdgeLength);
        }

        public void AddArea(float centerX, float centerY, float EdgeLength)
        {
            LastIndex++;
            ActiveIndex = LastIndex;
            float EdgeLengthHalf = EdgeLength / 2.0f;

            AreaCornerList.Add(new AreaCorner(centerX - EdgeLengthHalf, centerY - EdgeLengthHalf, LastIndex));
            AreaCornerList.Add(new AreaCorner(centerX + EdgeLengthHalf, centerY - EdgeLengthHalf, LastIndex));
            AreaCornerList.Add(new AreaCorner(centerX + EdgeLengthHalf, centerY + EdgeLengthHalf, LastIndex));
            AreaCornerList.Add(new AreaCorner(centerX - EdgeLengthHalf, centerY + EdgeLengthHalf, LastIndex));
        }

        public override string ToString()
        {
            string result = "";
            int lastIndex = -1;

            for (int i = 0; i < AreaCornerList.Count; i++)
            {
                if (lastIndex >= 0 && AreaCornerList[i].index != lastIndex) result += "\r\n";
                result += AreaCornerList[i].ToString();
                lastIndex = AreaCornerList[i].index;
            }
            return result;
        }

        public void AddCorner(float X, float Y, int index)
        {
            AreaCornerList.Add(new AreaCorner(X, Y, index));
        }


        public void DrawCorners(Graphics g, int offsetX, int offsetY, float magnification)
        {
            int lastIndex = -1;
            Point start = new Point();
            int R = CornerCircleRadius;

            Pen StandardPen = new Pen(Color.Blue, 1);
            Pen ActivePen = new Pen(Color.Red, 2);
            Pen p = StandardPen;

            for (int i = 0; i < AreaCornerList.Count; i++)
            {
                if (AreaCornerList[i].index != lastIndex)
                {
                    if (i > 0 && lastIndex >= 0)
                    {
                        g.DrawLine(p, start, AreaCornerList[i - 1].Point(offsetX, offsetY, magnification));
                    }

                    start = AreaCornerList[i].Point(offsetX, offsetY, magnification);

                    if (AreaCornerList[i].index == ActiveIndex)
                    {
                        p = ActivePen;
                    }
                    else
                    {
                        p = StandardPen;
                    }
                }
                else if (i > 0)
                {
                    g.DrawLine(p, AreaCornerList[i].Point(offsetX, offsetY, magnification), AreaCornerList[i - 1].Point(offsetX, offsetY, magnification));
                }

                Point pC = AreaCornerList[i].Point(offsetX, offsetY, magnification);

                g.DrawEllipse(p, pC.X - R, pC.Y - R, R * 2, R * 2);

                lastIndex = AreaCornerList[i].index;
            }

            if (lastIndex >= 0)
            {
                g.DrawLine(p, start, AreaCornerList[AreaCornerList.Count - 1].Point(offsetX, offsetY, magnification));
            }
        }
    }

    public class AreaCorner
    {
        public AreaCorner(float X, float Y, int index)
        {
            this.X = X;
            this.Y = Y;
            this.index = index;
        }

        public AreaCorner(Point point, int index)
        {
            this.X = point.X;
            this.Y = point.Y;
            this.index = index;
        }

        public float X;
        public float Y;
        public int index;

        public bool CheckDistance(float X, float Y, float R)
        {
            return Distance(X, Y) <= R;
        }

        public bool CheckDistance(Point point, float R)
        {
            return Distance(point) <= R;
        }

        public float Distance(float X, float Y)
        {
            double dX = this.X - X;
            double dY = this.Y - Y;

            return (float)Math.Sqrt(dX * dX + dY * dY);
        }

        public float Distance(Point point)
        {
            return Distance(point.X, point.Y);
        }
        public override string ToString()
        {
            return "{" + X.ToString() + "," + Y.ToString() + "}";
        }

        public Point Point(int offsetX = 0, int offsetY = 0, float magnification = 1.0f)
        {
            return new Point((int)(this.X * magnification + offsetX), (int)(this.Y * magnification + offsetY));
        }

    }
}
