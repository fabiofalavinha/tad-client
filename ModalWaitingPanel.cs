using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace TadManagementTool
{
    public partial class ModalWaitingPanel : Component
    {
        private static PropertyInfo doubleBufferedProperty = typeof(Control).GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance);

        private int alpha;
        private Control relatedControl = null;

        [Category("Waiting Panel")]
        public Control RelatedControl { get { return relatedControl; } set { SetRelatedControl(value); } }

        [Category("Waiting Panel")]
        [DefaultValue("Please Wait...")]
        [TypeConverter(typeof(string))]
        public string DisplayText { get; set; }

        [Category("Waiting Panel")]
        [DefaultValue(typeof(Color), "240, 240, 240")]
        public Color PanelBaseColor { get; set; }

        [Category("Waiting Panel")]
        [DefaultValue(170)]
        public int PanelAlpha { get { return alpha; } set { if (value < 0) alpha = 0; else if (value > 255) alpha = 255; else alpha = value; } }

        [Category("Waiting Panel")]
        [DefaultValue(false)]
        public bool FirstRunOpaque { get; set; }

        [Category("Waiting Panel")]
        [DefaultValue(true)]
        public bool UseDoubleBuffering { get; set; }

        [Category("Waiting Panel")]
        [DefaultValue(false)]
        public bool UseTransparent { get; set; }

        public ModalWaitingPanel(IContainer container)
        {
            FirstRunOpaque = false;
            UseDoubleBuffering = true;
            PanelAlpha = 170;
            PanelBaseColor = Color.FromArgb(240, 240, 240);

            if (container != null)
                container.Add(this);

            InitializeComponent();

            waitingPanel.WaitingPanelComponent = this;
        }

        public void Show(string displayText)
        {
            DisplayText = displayText;
            waitingPanel.Show();
        }

        public void Hide()
        {
            waitingPanel.Hide();
        }

        private void SetRelatedControl(Control value)
        {
            if (relatedControl != null)
            {
                relatedControl.SizeChanged -= waitingPanel.RelatedControlEventListener;
                relatedControl.VisibleChanged -= waitingPanel.RelatedControlEventListener;
            }

            relatedControl = value;

            if (relatedControl != null)
            {
                relatedControl.SizeChanged += waitingPanel.RelatedControlEventListener;
                relatedControl.VisibleChanged += waitingPanel.RelatedControlEventListener;

                relatedControl.Controls.Add(waitingPanel);

                if (UseDoubleBuffering)
                    doubleBufferedProperty.SetValue(relatedControl, true, null);
            }
        }
    }
}
