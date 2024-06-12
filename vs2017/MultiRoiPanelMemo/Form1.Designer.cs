namespace MultiRoiPanelMemo
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button_Base64Encode = new System.Windows.Forms.Button();
            this.pictureBox_Base64EncodeImage = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel_Parent = new System.Windows.Forms.Panel();
            this.toolStripContainer_Main = new System.Windows.Forms.ToolStripContainer();
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
            this.toolStripButton_AddFromClip = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_AddArea = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_RemoveArea = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel_ActiveAreaIndex = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton_EditMode = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator_CanvasView = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripComboBox_CanvasExtentionFactor = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButton_ShowMap = new System.Windows.Forms.ToolStripButton();
            this.panel_Frame = new System.Windows.Forms.Panel();
            this.textBox_EditView = new System.Windows.Forms.TextBox();
            this.button_MoveRight = new System.Windows.Forms.Button();
            this.button_MoveDown = new System.Windows.Forms.Button();
            this.button_MoveLeft = new System.Windows.Forms.Button();
            this.button_MoveUp = new System.Windows.Forms.Button();
            this.panel_Canvas = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Base64EncodeImage)).BeginInit();
            this.panel_Parent.SuspendLayout();
            this.toolStripContainer_Main.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer_Main.ContentPanel.SuspendLayout();
            this.toolStripContainer_Main.SuspendLayout();
            this.toolStrip_ImageControl.SuspendLayout();
            this.panel_Frame.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_Base64Encode
            // 
            this.button_Base64Encode.Location = new System.Drawing.Point(12, 12);
            this.button_Base64Encode.Name = "button_Base64Encode";
            this.button_Base64Encode.Size = new System.Drawing.Size(128, 23);
            this.button_Base64Encode.TabIndex = 2;
            this.button_Base64Encode.Text = "Base64Encode";
            this.button_Base64Encode.UseVisualStyleBackColor = true;
            this.button_Base64Encode.Click += new System.EventHandler(this.button_Base64Encode_Click);
            // 
            // pictureBox_Base64EncodeImage
            // 
            this.pictureBox_Base64EncodeImage.Location = new System.Drawing.Point(157, 12);
            this.pictureBox_Base64EncodeImage.Name = "pictureBox_Base64EncodeImage";
            this.pictureBox_Base64EncodeImage.Size = new System.Drawing.Size(100, 89);
            this.pictureBox_Base64EncodeImage.TabIndex = 3;
            this.pictureBox_Base64EncodeImage.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(518, 107);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 500);
            this.panel1.TabIndex = 4;
            // 
            // panel_Parent
            // 
            this.panel_Parent.Controls.Add(this.toolStripContainer_Main);
            this.panel_Parent.Location = new System.Drawing.Point(12, 107);
            this.panel_Parent.Name = "panel_Parent";
            this.panel_Parent.Size = new System.Drawing.Size(500, 500);
            this.panel_Parent.TabIndex = 1;
            // 
            // toolStripContainer_Main
            // 
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
            this.toolStripButton_AddFromClip,
            this.toolStripButton_AddArea,
            this.toolStripButton_RemoveArea,
            this.toolStripLabel_ActiveAreaIndex,
            this.toolStripButton_EditMode,
            this.toolStripSeparator_CanvasView,
            this.toolStripComboBox_CanvasExtentionFactor,
            this.toolStripButton_ShowMap});
            this.toolStrip_ImageControl.Location = new System.Drawing.Point(3, 0);
            this.toolStrip_ImageControl.Name = "toolStrip_ImageControl";
            this.toolStrip_ImageControl.Size = new System.Drawing.Size(457, 25);
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
            this.toolStripLabel_viewImagePoint.AutoSize = false;
            this.toolStripLabel_viewImagePoint.Name = "toolStripLabel_viewImagePoint";
            this.toolStripLabel_viewImagePoint.Size = new System.Drawing.Size(100, 22);
            this.toolStripLabel_viewImagePoint.Text = "{ - , - }";
            this.toolStripLabel_viewImagePoint.ToolTipText = "viewImagePoint";
            // 
            // toolStripSeparator_AreaControl
            // 
            this.toolStripSeparator_AreaControl.Name = "toolStripSeparator_AreaControl";
            this.toolStripSeparator_AreaControl.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton_AddFromClip
            // 
            this.toolStripButton_AddFromClip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_AddFromClip.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_AddFromClip.Image")));
            this.toolStripButton_AddFromClip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_AddFromClip.Name = "toolStripButton_AddFromClip";
            this.toolStripButton_AddFromClip.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_AddFromClip.Tag = "AddFromClip";
            this.toolStripButton_AddFromClip.Click += new System.EventHandler(this.toolStripButton_AddFromClip_Click);
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
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 617);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox_Base64EncodeImage);
            this.Controls.Add(this.button_Base64Encode);
            this.Controls.Add(this.panel_Parent);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Base64EncodeImage)).EndInit();
            this.panel_Parent.ResumeLayout(false);
            this.toolStripContainer_Main.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer_Main.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer_Main.ContentPanel.ResumeLayout(false);
            this.toolStripContainer_Main.ResumeLayout(false);
            this.toolStripContainer_Main.PerformLayout();
            this.toolStrip_ImageControl.ResumeLayout(false);
            this.toolStrip_ImageControl.PerformLayout();
            this.panel_Frame.ResumeLayout(false);
            this.panel_Frame.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_Base64Encode;
        private System.Windows.Forms.PictureBox pictureBox_Base64EncodeImage;
        private System.Windows.Forms.Panel panel_Parent;
        private System.Windows.Forms.ToolStripContainer toolStripContainer_Main;
        private System.Windows.Forms.Panel panel_Frame;
        private System.Windows.Forms.TextBox textBox_EditView;
        private System.Windows.Forms.Button button_MoveLeft;
        private System.Windows.Forms.Button button_MoveRight;
        private System.Windows.Forms.Button button_MoveDown;
        private System.Windows.Forms.Button button_MoveUp;
        private System.Windows.Forms.Panel panel_Canvas;
        private System.Windows.Forms.ToolStrip toolStrip_ImageControl;
        private System.Windows.Forms.ToolStripButton toolStripButton_OpenFile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator_SizeControl;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox_Magnification;
        private System.Windows.Forms.ToolStripButton toolStripButton_SetOrgSize;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator_MoveControl;
        private System.Windows.Forms.ToolStripButton toolStripButton_SetCenter;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator_PositionView;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_viewImagePoint;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator_AreaControl;
        private System.Windows.Forms.ToolStripButton toolStripButton_AddFromClip;
        private System.Windows.Forms.ToolStripButton toolStripButton_AddArea;
        private System.Windows.Forms.ToolStripButton toolStripButton_RemoveArea;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_ActiveAreaIndex;
        private System.Windows.Forms.ToolStripButton toolStripButton_EditMode;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator_CanvasView;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox_CanvasExtentionFactor;
        private System.Windows.Forms.ToolStripButton toolStripButton_ShowMap;
    }
}

