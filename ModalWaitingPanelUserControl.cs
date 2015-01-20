using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace TadManagementTool
{
    partial class ModalWaitingPanelUserControl : UserControl
    {
        // properties
        private bool firstRun = true;

        // bitmap and graphics cache
        private Bitmap bitmap = null;
        private Graphics bitmapGraphics;
        private SolidBrush translucentBrush = null;
        private SolidBrush opaqueBrush = null;

        private int PanelAlpha { get { return WaitingPanelComponent.PanelAlpha; } }
        private bool FirstRunOpaque { get { return WaitingPanelComponent.FirstRunOpaque; } }
        private bool UseDoubleBuffering { get { return WaitingPanelComponent.UseDoubleBuffering; } }
        private string DisplayText { get { return WaitingPanelComponent.DisplayText; } }
        private bool UseTransparentColor { get { return WaitingPanelComponent.UseTransparent; } }
        private Color PanelBaseColor { get { return WaitingPanelComponent.PanelBaseColor; } }
        private Control RelatedControl { get { return WaitingPanelComponent.RelatedControl; } }

        internal ModalWaitingPanel WaitingPanelComponent { get; set; }

        public ModalWaitingPanelUserControl()
        {
            Visible = false;
            DoubleBuffered = true;
            InitializeComponent();
        }

        public new void Show()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(Show));
                return;
            }
            ConfigureAndShowLP(RelatedControl);
        }

        public new void Hide()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(Hide));
                return;
            }

            DisposeBitmaps();

            if (!IsDisposed)
            {
                Visible = false;
                firstRun = false;
                SendToBack();
            }
        }

        private void ConfigureAndShowLP(Control control)
        {
            if (control != null && !control.IsDisposed && !DesignMode)
            {
                Graphics bitmapGraphics = TakeControlSnapshotWithAlpha(control);
                if (bitmapGraphics != null)
                {
                    ColapseControlToMinimumSize(bitmapGraphics);

                    textLabelControl.Text = DisplayText;
                    Size = control.Size;

                    Visible = true;
                    BringToFront();
                    waitingPanelControl.BringToFront();
                }
            }
        }

        internal void RelatedControlEventListener(object sender, EventArgs e)
        {
            if (Visible)
            {
                DisposeBitmaps();
                ConfigureAndShowLP(RelatedControl);
            }
        }

        private Graphics TakeControlSnapshotWithAlpha(Control control)
        {
            if (!IsDisposed && control != null && !control.IsDisposed && control.Width > 0 && control.Height > 0)
            {
                if (bitmap == null || bitmapGraphics == null)
                {
                    bitmap = new Bitmap(control.Width, control.Height);
                    bitmapGraphics = Graphics.FromImage(bitmap);
                    if (firstRun && FirstRunOpaque)
                    {
                        BuildOpaqueColor(bitmapGraphics, control);
                    }
                    else
                    {
                        if (UseTransparentColor)
                        {
                            control.DrawToBitmap(bitmap, new Rectangle(0, 0, control.Width, control.Height));
                            bitmapGraphics.CompositingMode = CompositingMode.SourceOver;
                            Brush brush = GetTranslucentBrush();
                            bitmapGraphics.FillRectangle(brush, new Rectangle(0, 0, control.Width, control.Height));
                        }
                        else
                        {
                            BuildOpaqueColor(bitmapGraphics, control);
                        }
                    }
                }
                return bitmapGraphics;
            }
            return null;
        }

        private void BuildOpaqueColor(Graphics graphics, Control control)
        {
            Brush brush = GetOpaqueBrush();
            graphics.FillRectangle(brush, new Rectangle(0, 0, control.Width, control.Height));
        }

        private Brush GetOpaqueBrush()
        {
            if (opaqueBrush == null)
                opaqueBrush = new SolidBrush(PanelBaseColor);
            return opaqueBrush;
        }

        private Brush GetTranslucentBrush()
        {
            if (translucentBrush == null)
                translucentBrush = new SolidBrush(Color.FromArgb(PanelAlpha, PanelBaseColor));
            return translucentBrush;
        }

        private void ColapseControlToMinimumSize(Graphics bitmapGraphics)
        {
            SizeF textSize = bitmapGraphics.MeasureString(DisplayText, textLabelControl.Font);
            Size = new Size(36 + (int)textSize.Width, 50);
            textLabelControl.Size = Size;
            waitingPanelControl.Size = Size;
            waitingPanelControl.Location = new Point(0, 0);
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (bitmap != null)
            {
                e.Graphics.CompositingQuality = CompositingQuality.GammaCorrected;
                e.Graphics.DrawImage(bitmap, 0, 0);
            }
        }

        private void ModalWaitingPanelUserControl_Load(object sender, EventArgs e)
        {
            Visible = false;
            SendToBack();
        }

        private void DisposeBitmaps()
        {
            if (bitmap != null)
            {
                bitmap.Dispose();
                bitmap = null;
            }

            if (bitmapGraphics != null)
            {
                bitmapGraphics.Dispose();
                bitmapGraphics = null;
            }
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                DisposeBitmaps();
                if (translucentBrush != null)
                    translucentBrush.Dispose();
                if (opaqueBrush != null)
                    opaqueBrush.Dispose();
                if (components != null)
                    components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
