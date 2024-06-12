using System;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MultiRoiPanelClass;


namespace MultiRoiPanelMemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.panel_Frame.MouseWheel += new MouseEventHandler(panel_Frame_MouseWheel);
            this.panel_Canvas.MouseWheel += new MouseEventHandler(panel_Frame_MouseWheel);
            this.panel_Parent.MouseWheel += new MouseEventHandler(panel_Frame_MouseWheel);
        }

        MultiRoiPanel MRP;

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

        public float magnification { get { return float.Parse(toolStripComboBox_Magnification.Text) / 100f; } }
        public bool ShowMapSwitch
        {
            get { return toolStripButton_ShowMap.BackColor == System.Drawing.SystemColors.Control; }
            set
            {
                if (this.InvokeRequired) { this.Invoke((Action)(() => ShowMapSwitch = value)); }
                else
                {
                    if (value)
                    {
                        toolStripButton_ShowMap.BackColor = System.Drawing.SystemColors.Control;
                    }
                    else
                    {
                        toolStripButton_ShowMap.BackColor = System.Drawing.SystemColors.ControlDark;
                    }
                }
            }
        }
        Dictionary<string, Image> EditModes;
        string EditModeKey = "Quadrilateral";

        public int CanvasExtentionFactor { get { return int.Parse(toolStripComboBox_CanvasExtentionFactor.Text); } }

        private void Form1_Load(object sender, EventArgs e)
        {
            toolStripButton_SetCenter.Image = MultiRoiPanelIcon.icon_Center;
            toolStripButton_SetOrgSize.Image = MultiRoiPanelIcon.icon_OriginalSize;
            toolStripButton_EditMode.Image = MultiRoiPanelIcon.icon_Quadrilateral;
            toolStripButton_ShowMap.Image = MultiRoiPanelIcon.icon_ShowMap;
            toolStripButton_OpenFile.Image = MultiRoiPanelIcon.icon_OpenFile;
            toolStripButton_RemoveArea.Image = MultiRoiPanelIcon.icon_Minus;

            toolStripButton_AddArea.Image = MultiRoiPanelIcon.icon_Puls;

            toolStripButton_AddFromClip.Image = MultiRoiPanelIcon.icon_FromClip;

            areaCorners = new AreaCorners();

            MRP = new MultiRoiPanel(panel1);

            EditModes = new Dictionary<string, Image>
            {
                { "Quadrilateral", MultiRoiPanelIcon.icon_Quadrilateral },
                { "Rectangle", MultiRoiPanelIcon.icon_Rectangle }
            };

            toolStripButton_EditMode.Image = EditModes[EditModeKey];

            textBox_EditView.Height = textBox_EditView.Font.Height * 5;
            MoveButtonsAlignment();
        }
        private void button_Base64Encode_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PNG Files(*.png)|*.png";
            openFileDialog.Title = "Select a PNG File";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                byte[] fileBytes = File.ReadAllBytes(filePath);
                string base64String = Convert.ToBase64String(fileBytes);

                Clipboard.SetText(base64String);
            }
        }

        int MoveButtonsAlignmentOffset = 12;

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

        private Point getImagePointFromCanvasLocation(Point p)
        {
            float drawImageWidth = viewImage.Width * magnification;
            float drawImageHeight = viewImage.Height * magnification;

            int X = (int)((p.X - ((CanvasExtentionFactor - 1) / 2) * drawImageWidth) / magnification);
            int Y = (int)((p.Y - ((CanvasExtentionFactor - 1) / 2) * drawImageHeight) / magnification);

            return new Point(X, Y);
        }

        private void toolStripButton_OpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() != DialogResult.OK) return;
            viewImage = new Bitmap(ofd.FileName);
            viewImageFocusPoint = new Point(viewImage.Width / 2, viewImage.Height / 2);
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

        private void panel_Canvas_Paint(object sender, PaintEventArgs e)
        {
            drawPanelCanvas();
        }

        bool panelMouseDown = false;
        int selectedCornerIndex = -1;
        Point selectedCornerPoint;

        public double Distance(Point point1, Point point2)
        {
            int dx = point2.X - point1.X;
            int dy = point2.Y - point1.Y;

            return Math.Sqrt(dx * dx + dy * dy);
        }

        Point panelFrameMouseDownPoint;
        Point panelFrameMouseDown_viewImageFocusPointBase;

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

            if (e.Button == MouseButtons.Left && selectedCornerIndex == -1 && Distance(panelFrameMouseUpPoint, panelFrameMouseDownPoint) <= 3)
            {
                viewImageFocusPoint = selectedCornerPoint;
            }
            else if (e.Button == MouseButtons.Right && selectedCornerIndex >= 0)
            {
                string cornerInfo = areaCorners.GetAreaCornerListString(areaCorners.ActiveIndex);
                Clipboard.SetText(cornerInfo);
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

                if (EditModeKey == "Rectangle")
                {
                    areaCorners.UpdateAreaPosition(selectedCornerIndex, selectedCornerPoint + new Size(dx, dy));
                }
                else
                {
                    areaCorners.UpdateCorner(selectedCornerIndex, selectedCornerPoint + new Size(dx, dy));
                }

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

        private void panel_Frame_MouseWheel(object sender, MouseEventArgs e)
        {
            int m = int.Parse(toolStripComboBox_Magnification.Text);

            m += e.Delta / 20;

            if (m > 0) toolStripComboBox_Magnification.Text = m.ToString();

            areaCorners.SearchRadius = (int)(5 / magnification);
            panel_Frame.Refresh();
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

        AreaCorners areaCorners;

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
            areaCorners.SearchRadius = (int)(5 / magnification);
            panel_Frame.Refresh();
        }
        private void toolStripButton_RemoveArea_Click(object sender, EventArgs e)
        {
            areaCorners.RemoveArea();
            textBox_EditView.Text = areaCorners.ToString();

            panel_Frame.Refresh();
        }

        private void toolStripButton_AddFromClip_Click(object sender, EventArgs e)
        {
            string TextContents = Clipboard.GetText();
            areaCorners.FromString(TextContents);
            textBox_EditView.Text = areaCorners.ToString();

            panel_Frame.Refresh();
        }
    }
}
