using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using mshtml;
using System.Text.RegularExpressions;
using System.IO;
using System.Web;
using TadManagementTool.Model;
using TadManagementTool.View.Impl;
using TadManagementTool.View;
using System.Threading.Tasks;
using TadManagementTool.Service;

namespace TadManagementTool
{
    public partial class Editor : UserControl, IControlView
    {
        public class EnterKeyEventArgs : EventArgs
        {
            public bool Cancel { get; set; }
        }

        private readonly IMainView parentView;
        private readonly Post post;

        private IHTMLDocument2 doc;
        private bool updatingFontName = false;
        private bool updatingFontSize = false;
        private bool setup = false;
        private bool timerInitialized = false;

        public delegate void TickDelegate();

        public event TickDelegate Tick;
        public event WebBrowserNavigatedEventHandler Navigated;
        public event EventHandler<EnterKeyEventArgs> EnterKeyEvent;

        public Editor(IMainView parentView, Post post)
        {
            this.parentView = parentView;
            this.post = post;

            Load += Editor_Load;
            InitializeComponent();
            SetupEvents();
            SetupTimer();
            SetupBrowser();
            SetupFontComboBox();
            SetupFontSizeComboBox();
            boldButton.CheckedChanged += (s, e) =>
            {
                if (BoldChanged != null)
                    BoldChanged();
            };
            italicButton.CheckedChanged += (s, e) =>
            {
                if (ItalicChanged != null)
                    ItalicChanged();
            };
            underlineButton.CheckedChanged += (s, e) =>
            {
                if (UnderlineChanged != null)
                    UnderlineChanged();
            };
            orderedListButton.CheckedChanged += (s, e) =>
            {
                if (OrderedListChanged != null)
                    OrderedListChanged();
            };
            unorderedListButton.CheckedChanged += (s, e) =>
            {
                if (UnorderedListChanged != null)
                    UnorderedListChanged();
            };
            justifyLeftButton.CheckedChanged += (s, e) =>
            {
                if (JustifyLeftChanged != null)
                    JustifyLeftChanged();
            };
            justifyCenterButton.CheckedChanged += (s, e) =>
            {
                if (JustifyCenterChanged != null)
                    JustifyCenterChanged();
            };
            justifyRightButton.CheckedChanged += (s, e) =>
            {
                if (JustifyRightChanged != null)
                    JustifyRightChanged();
            };
            justifyFullButton.CheckedChanged += (s, e) =>
            {
                if (JustifyFullChanged != null)
                    JustifyFullChanged();
            };
            linkButton.CheckedChanged += (s, e) =>
            {
                if (IsLinkChanged != null)
                    IsLinkChanged();
            };
        }

        private void Editor_Load(object sender, EventArgs e)
        {
            timer.Start();
        }

        /// <summary>
        /// Setup navigation and focus event handlers.
        /// </summary>
        private void SetupEvents()
        {
            webBrowser.Navigated += webBrowser_Navigated;
            webBrowser.GotFocus += webBrowser_GotFocus;
            if (webBrowser.Version.Major >= 9)
                webBrowser.DocumentCompleted += webBrowser_DocumentCompleted;
        }

        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            webBrowser.Document.Write(webBrowser.DocumentText);
            doc.designMode = "On";
            webBrowser.Document.Body.SetAttribute("contentEditable", "true");
        }

        /// <summary>
        /// When this control receives focus, it transfers focus to the 
        /// document body.
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">EventArgs</param>
        private void webBrowser_GotFocus(object sender, EventArgs e)
        {
            SuperFocus();
        }

        /// <summary>
        /// This is called when the initial html/body framework is set up, 
        /// or when document.DocumentText is set.  At this point, the 
        /// document is editable.
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">navigation args</param>
        void webBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            SetBackgroundColor(BackColor);
            if (Navigated != null)
            {
                Navigated(this, e);
            }
        }

        /// <summary>
        /// Setup timer with 200ms interval
        /// </summary>
        private void SetupTimer()
        {
            timer.Interval = 200;
            timer.Tick += timer_Tick;
        }

        /// <summary>
        /// Add document body, turn on design mode on the whole document, 
        /// and overred the context menu
        /// </summary>
        private void SetupBrowser()
        {
            webBrowser.DocumentText = "<html><body></body></html>";
            doc = webBrowser.Document.DomDocument as IHTMLDocument2;
            doc.designMode = "On";
            webBrowser.Document.ContextMenuShowing += Document_ContextMenuShowing;
        }

        /// <summary>
        /// Set the focus on the document body.  
        /// </summary>
        private void SuperFocus()
        {
            if (webBrowser.Document != null && webBrowser.Document.Body != null)
            {
                webBrowser.Document.Body.Focus();
            }
        }

        /// <summary>
        /// Get/Set the background color of the editor.
        /// Note that if this is called before the document is rendered and 
        /// complete, the navigated event handler will set the body's 
        /// background color based on the state of BackColor.
        /// </summary>
        [Browsable(true)]
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;
                if (ReadyState == ReadyState.Complete)
                {
                    SetBackgroundColor(value);
                }
            }
        }

        /// <summary>
        /// Set the background color of the body by setting it's CSS style
        /// </summary>
        /// <param name="value">the color to use for the background</param>
        private void SetBackgroundColor(Color value)
        {
            if (webBrowser.Document != null && webBrowser.Document.Body != null)
                webBrowser.Document.Body.Style = string.Format("background-color: {0}", value.Name);
        }

        /// <summary>
        /// Clear the contents of the document, leaving the body intact.
        /// </summary>
        public void Clear()
        {
            if (webBrowser.Document.Body != null)
                webBrowser.Document.Body.InnerHtml = "";
        }

        /// <summary>
        /// Get the web browser component's document
        /// </summary>
        public HtmlDocument Document
        {
            get { return webBrowser.Document; }
        }

        /// <summary>
        /// Document text should be used to load/save the entire document, 
        /// including html and body start/end tags.
        /// </summary>
        [Browsable(false)]
        public string DocumentText
        {
            get
            {
                string html = webBrowser.DocumentText;
                if (html != null)
                {
                    html = ReplaceFileSystemImages(html);
                }
                return html;
            }
            set
            {
                webBrowser.DocumentText = value;
            }
        }

        /// <summary>
        /// Get the html document title from document.
        /// </summary>
        [Browsable(false)]
        public string DocumentTitle
        {
            get
            {
                return webBrowser.DocumentTitle;
            }
        }

        /// <summary>
        /// Get/Set the contents of the document Body, in html.
        /// </summary>
        [Browsable(false)]
        public string BodyHtml
        {
            get
            {
                if (webBrowser.Document != null && webBrowser.Document.Body != null)
                {
                    var html = webBrowser.Document.Body.InnerHtml;
                    if (html != null)
                    {
                        html = ReplaceFileSystemImages(html);
                    }
                    return html;
                }
                return string.Empty;
            }
            set
            {
                if (webBrowser.Document.Body != null)
                    webBrowser.Document.Body.InnerHtml = value;
            }
        }

        private string ReplaceFileSystemImages(string html)
        {
            var matches = Regex.Matches(html, @"<img[^>]*?src\s*=\s*([""']?[^'"">]+?['""])[^>]*?>", RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline);
            foreach (Match match in matches)
            {
                string src = match.Groups[1].Value;
                src = src.Trim('\"');
                if (File.Exists(src))
                {
                    var ext = Path.GetExtension(src);
                    if (ext.Length > 0)
                    {
                        ext = ext.Substring(1);
                        src = string.Format("'data:image/{0};base64,{1}'", ext, Convert.ToBase64String(File.ReadAllBytes(src)));
                        html = html.Replace(match.Groups[1].Value, src);
                    }
                }
            }
            return html;
        }

        /// <summary>
        /// Get/Set the documents body as text.
        /// </summary>
        [Browsable(false)]
        public string BodyText
        {
            get
            {
                if (webBrowser.Document != null && webBrowser.Document.Body != null)
                {
                    return webBrowser.Document.Body.InnerText;
                }
                return string.Empty;
            }
            set
            {
                Document.OpenNew(false);
                if (webBrowser.Document.Body != null)
                    webBrowser.Document.Body.InnerText = HttpUtility.HtmlEncode(value);
            }
        }

        [Browsable(false)]
        public string Html
        {
            get
            {
                if (InvokeRequired)
                {
                    return (string)Invoke(new Func<string>(() => Html));
                }
                if (webBrowser.Document != null && webBrowser.Document.Body != null)
                {
                    return webBrowser.Document.Body.InnerHtml;
                }
                return string.Empty;
            }
            set
            {
                Document.OpenNew(true);
                var dom = Document.DomDocument as IHTMLDocument2;
                try
                {
                    if (value == null) 
                    {
                        dom.clear();
                    } 
                    else
                    {
                        dom.write(value);
                    }
                }
                finally
                {
                    dom.close();
                }
            }
        }

        /// <summary>
        /// Determine the status of the Undo command in the document editor.
        /// </summary>
        /// <returns>whether or not an undo operation is currently valid</returns>
        public bool CanUndo()
        {
            return doc.queryCommandEnabled("Undo");
        }

        /// <summary>
        /// Determine the status of the Redo command in the document editor.
        /// </summary>
        /// <returns>whether or not a redo operation is currently valid</returns>
        public bool CanRedo()
        {
            return doc.queryCommandEnabled("Redo");
        }

        /// <summary>
        /// Determine the status of the Cut command in the document editor.
        /// </summary>
        /// <returns>whether or not a cut operation is currently valid</returns>
        public bool CanCut()
        {
            return doc.queryCommandEnabled("Cut");
        }

        /// <summary>
        /// Determine the status of the Copy command in the document editor.
        /// </summary>
        /// <returns>whether or not a copy operation is currently valid</returns>
        public bool CanCopy()
        {
            return doc.queryCommandEnabled("Copy");
        }

        /// <summary>
        /// Determine the status of the Paste command in the document editor.
        /// </summary>
        /// <returns>whether or not a copy operation is currently valid</returns>
        public bool CanPaste()
        {
            return doc.queryCommandEnabled("Paste");
        }

        /// <summary>
        /// Determine the status of the Delete command in the document editor.
        /// </summary>
        /// <returns>whether or not a copy operation is currently valid</returns>
        public bool CanDelete()
        {
            return doc.queryCommandEnabled("Delete");
        }

        /// <summary>
        /// Determine whether the current block is left justified.
        /// </summary>
        /// <returns>true if left justified, otherwise false</returns>
        public bool IsJustifyLeft()
        {
            return doc.queryCommandState("JustifyLeft");
        }

        /// <summary>
        /// Determine whether the current block is right justified.
        /// </summary>
        /// <returns>true if right justified, otherwise false</returns>
        public bool IsJustifyRight()
        {
            return doc.queryCommandState("JustifyRight");
        }

        /// <summary>
        /// Determine whether the current block is center justified.
        /// </summary>
        /// <returns>true if center justified, false otherwise</returns>
        public bool IsJustifyCenter()
        {
            return doc.queryCommandState("JustifyCenter");
        }

        /// <summary>
        /// Determine whether the current block is full justified.
        /// </summary>
        /// <returns>true if full justified, false otherwise</returns>
        public bool IsJustifyFull()
        {
            return doc.queryCommandState("JustifyFull");
        }

        /// <summary>
        /// Determine whether the current selection is in Bold mode.
        /// </summary>
        /// <returns>whether or not the current selection is Bold</returns>
        public bool IsBold()
        {
            return doc.queryCommandState("Bold");
        }

        /// <summary>
        /// Determine whether the current selection is in Italic mode.
        /// </summary>
        /// <returns>whether or not the current selection is Italicized</returns>
        public bool IsItalic()
        {
            return doc.queryCommandState("Italic");
        }

        /// <summary>
        /// Determine whether the current selection is in Underline mode.
        /// </summary>
        /// <returns>whether or not the current selection is Underlined</returns>
        public bool IsUnderline()
        {
            return doc.queryCommandState("Underline");
        }

        /// <summary>
        /// Determine whether the current paragraph is an ordered list.
        /// </summary>
        /// <returns>true if current paragraph is ordered, false otherwise</returns>
        public bool IsOrderedList()
        {
            return doc.queryCommandState("InsertOrderedList");
        }

        /// <summary>
        /// Determine whether the current paragraph is an unordered list.
        /// </summary>
        /// <returns>true if current paragraph is ordered, false otherwise</returns>
        public bool IsUnorderedList()
        {
            return doc.queryCommandState("InsertUnorderedList");
        }

        /// <summary>
        /// Called when the editor context menu should be displayed.
        /// The return value of the event is set to false to disable the 
        /// default context menu.  A custom context menu (contextMenuStrip1) is 
        /// shown instead.
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">HtmlElementEventArgs</param>
        private void Document_ContextMenuShowing(object sender, HtmlElementEventArgs e)
        {
            e.ReturnValue = false;
            cutToolStripMenuItem1.Enabled = CanCut();
            copyToolStripMenuItem2.Enabled = CanCopy();
            pasteToolStripMenuItem3.Enabled = CanPaste();
            deleteToolStripMenuItem.Enabled = CanDelete();
            cSSToolStripMenuItem.Enabled = SelectionType != SelectionType.None;
            contextMenuStrip.Show(this, e.ClientMousePosition);
        }

        /// <summary>
        /// Populate the font size combobox.
        /// Add text changed and key press handlers to handle input and update 
        /// the editor selection font size.
        /// </summary>
        private void SetupFontSizeComboBox()
        {
            for (int x = 1; x <= 7; x++)
            {
                fontSizeComboBox.Items.Add(x.ToString());
            }
            fontSizeComboBox.TextChanged += fontSizeComboBox_TextChanged;
            fontSizeComboBox.KeyPress += fontSizeComboBox_KeyPress;
        }

        /// <summary>
        /// Called when a key is pressed on the font size combo box.
        /// The font size in the boxy box is set to the key press value.
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">KeyPressEventArgs</param>
        private void fontSizeComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
                if (e.KeyChar <= '7' && e.KeyChar > '0')
                    fontSizeComboBox.Text = e.KeyChar.ToString();
            }
            else if (!Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Set editor's current selection to the value of the font size combo box.
        /// Ignore if the timer is currently updating the font size to synchronize 
        /// the font size combo box with the editor's current selection.
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">EventArgs</param>
        private void fontSizeComboBox_TextChanged(object sender, EventArgs e)
        {
            if (updatingFontSize) 
                return;
            switch (fontSizeComboBox.Text.Trim())
            {
                case "1":
                    FontSize = FontSize.One;
                    break;
                case "2":
                    FontSize = FontSize.Two;
                    break;
                case "3":
                    FontSize = FontSize.Three;
                    break;
                case "4":
                    FontSize = FontSize.Four;
                    break;
                case "5":
                    FontSize = FontSize.Five;
                    break;
                case "6":
                    FontSize = FontSize.Six;
                    break;
                case "7":
                    FontSize = FontSize.Seven;
                    break;
                default:
                    FontSize = FontSize.Seven;
                    break;
            }
        }

        /// <summary>
        /// Populate the font combo box and autocomplete handlers.
        /// Add a text changed handler to the font combo box to handle new font selections.
        /// </summary>
        private void SetupFontComboBox()
        {
            var ac = new AutoCompleteStringCollection();
            foreach (var fam in FontFamily.Families)
            {
                fontComboBox.Items.Add(fam.Name);
                ac.Add(fam.Name);
            }
            fontComboBox.Leave += fontComboBox_TextChanged;
            fontComboBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            fontComboBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            fontComboBox.AutoCompleteCustomSource = ac;
        }

        /// <summary>
        /// Called when the font combo box has changed.
        /// Ignores the event when the timer is updating the font combo Box 
        /// to synchronize the editor selection with the font combo box.
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">EventArgs</param>
        private void fontComboBox_TextChanged(object sender, EventArgs e)
        {
            if (updatingFontName) return;
            FontFamily ff;
            try
            {
                ff = new FontFamily(fontComboBox.Text);
            }
            catch (Exception)
            {
                updatingFontName = true;
                fontComboBox.Text = FontName.GetName(0);
                updatingFontName = false;
                return;
            }
            FontName = ff;
        }

        private void UpdateImageSizes()
        {
            foreach (HTMLImg image in doc.images)
            {
                if (image != null)
                {
                    if (image.height != image.style.pixelHeight && image.style.pixelHeight != 0)
                        image.height = image.style.pixelHeight;
                    if (image.width != image.style.pixelWidth && image.style.pixelWidth != 0)
                        image.width = image.style.pixelWidth;
                }
            }
        }

        public event MethodInvoker BoldChanged;
        public event MethodInvoker ItalicChanged;
        public event MethodInvoker UnderlineChanged;
        public event MethodInvoker OrderedListChanged;
        public event MethodInvoker UnorderedListChanged;
        public event MethodInvoker JustifyLeftChanged;
        public event MethodInvoker JustifyCenterChanged;
        public event MethodInvoker JustifyRightChanged;
        public event MethodInvoker JustifyFullChanged;
        public event MethodInvoker IsLinkChanged;
        public event MethodInvoker HtmlFontChanged;
        public event MethodInvoker HtmlFontSizeChanged;

        /// <summary>
        /// Called when the timer fires to synchronize the format buttons 
        /// with the text editor current selection.
        /// SetupKeyListener if necessary.
        /// Set bold, italic, underline and link buttons as based on editor state.
        /// Synchronize the font combo box and the font size combo box.
        /// Finally, fire the Tick event to allow external components to synchronize 
        /// their state with the editor.
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">EventArgs</param>
        private void timer_Tick(object sender, EventArgs e)
        {
            // don't process until browser is in ready state.
            if (ReadyState != ReadyState.Complete)
            {
                return;
            }

            if (!timerInitialized)
            {
                timerInitialized = true;
                if (post != null)
                {
                    postTitleTextBox.Text = post.Title;
                    Html = post.Content;
                    postInternalVisibilityRadioButton.Checked = post.Visibility == VisibilityType.Internal;
                    postPublicVisibilityRadioButton.Checked = post.Visibility == VisibilityType.Public;
                }
            }

            SetupKeyListener();
            boldButton.Checked = IsBold();
            italicButton.Checked = IsItalic();
            underlineButton.Checked = IsUnderline();
            orderedListButton.Checked = IsOrderedList();
            unorderedListButton.Checked = IsUnorderedList();
            justifyLeftButton.Checked = IsJustifyLeft();
            justifyCenterButton.Checked = IsJustifyCenter();
            justifyRightButton.Checked = IsJustifyRight();
            justifyFullButton.Checked = IsJustifyFull();

            linkButton.Enabled = CanInsertLink();

            UpdateFontComboBox();
            UpdateFontSizeComboBox();
            UpdateImageSizes();

            if (Tick != null)
            {
                Tick();
            }
        }

        /// <summary>
        /// Update the font size combo box.
        /// Sets a flag to indicate that the combo box is updating, and should 
        /// not update the editor's selection.
        /// </summary>
        private void UpdateFontSizeComboBox()
        {
            if (!fontSizeComboBox.Focused)
            {
                int foo;
                switch (FontSize)
                {
                    case FontSize.One:
                        foo = 1;
                        break;
                    case FontSize.Two:
                        foo = 2;
                        break;
                    case FontSize.Three:
                        foo = 3;
                        break;
                    case FontSize.Four:
                        foo = 4;
                        break;
                    case FontSize.Five:
                        foo = 5;
                        break;
                    case FontSize.Six:
                        foo = 6;
                        break;
                    case FontSize.Seven:
                        foo = 7;
                        break;
                    case FontSize.NA:
                        foo = 0;
                        break;
                    default:
                        foo = 7;
                        break;
                }
                string fontsize = Convert.ToString(foo);
                if (fontsize != fontSizeComboBox.Text)
                {
                    updatingFontSize = true;
                    fontSizeComboBox.Text = fontsize;
                    if (HtmlFontSizeChanged != null)
                        HtmlFontSizeChanged();
                    updatingFontSize = false;
                }
            }
        }

        /// <summary>
        /// Update the font combo box.
        /// Sets a flag to indicate that the combo box is updating, and should 
        /// not update the editor's selection.
        /// </summary>
        private void UpdateFontComboBox()
        {
            if (!fontComboBox.Focused)
            {
                FontFamily fam = FontName;
                if (fam != null)
                {
                    string fontname = fam.Name;
                    if (fontname != fontComboBox.Text)
                    {
                        updatingFontName = true;
                        fontComboBox.Text = fontname;
                        if (HtmlFontChanged != null)
                            HtmlFontChanged();
                        updatingFontName = false;
                    }
                }
            }
        }

        public Color BodyBackgroundColor
        {
            get
            {
                if (doc.body != null && doc.body.style != null && doc.body.style.backgroundColor != null)
                    return ConvertToColor(doc.body.style.backgroundColor.ToString());
                return Color.White;
            }
            set
            {
                if (ReadyState == ReadyState.Complete)
                {
                    if (doc.body != null && doc.body.style != null)
                    {
                        string colorstr =
                            string.Format("#{0:X2}{1:X2}{2:X2}", value.R, value.G, value.B);
                        doc.body.style.backgroundColor = colorstr;
                    }
                }
            }
        }

        /// <summary>
        /// Set up a key listener on the body once.
        /// The key listener checks for specific key strokes and takes 
        /// special action in certain cases.
        /// </summary>
        private void SetupKeyListener()
        {
            if (!setup)
            {
                webBrowser.Document.Body.KeyDown += Body_KeyDown;
                setup = true;
            }
        }

        /// <summary>
        /// If the user hits the enter key, and event will fire (EnterKeyEvent), 
        /// and the consumers of this event can cancel the projecessing of the 
        /// enter key by cancelling the event.
        /// This is useful if your application would like to take some action 
        /// when the enter key is pressed, such as a submission to a web service.
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">HtmlElementEventArgs</param>
        private void Body_KeyDown(object sender, HtmlElementEventArgs e)
        {
            if (e.KeyPressedCode == 13 && !e.ShiftKeyPressed)
            {
                // handle enter code cancellation
                var cancel = false;
                if (EnterKeyEvent != null)
                {
                    var args = new EnterKeyEventArgs();
                    EnterKeyEvent(this, args);
                    cancel = args.Cancel;
                }
                e.ReturnValue = !cancel;
            }
        }

        /// <summary>
        /// Embed a break at the current selection.
        /// This is a placeholder for future functionality.
        /// </summary>
        public void EmbedBr()
        {
            IHTMLTxtRange range =
                doc.selection.createRange() as IHTMLTxtRange;
            range.pasteHTML("<br/>");
            range.collapse(false);
            range.select();
        }

        /// <summary>
        /// Paste the clipboard text into the current selection.
        /// This is a placeholder for future functionality.
        /// </summary>
        private void SuperPaste()
        {
            if (Clipboard.ContainsText())
            {
                IHTMLTxtRange range =
                    doc.selection.createRange() as IHTMLTxtRange;
                range.pasteHTML(Clipboard.GetText(TextDataFormat.Text));
                range.collapse(false);
                range.select();
            }
        }

        /// <summary>
        /// Print the current document
        /// </summary>
        public void Print()
        {
            webBrowser.Document.ExecCommand("Print", true, null);
        }

        /// <summary>
        /// Insert a paragraph break
        /// </summary>
        public void InsertParagraph()
        {
            webBrowser.Document.ExecCommand("InsertParagraph", false, null);
        }

        /// <summary>
        /// Insert a horizontal rule
        /// </summary>
        public void InsertBreak()
        {
            webBrowser.Document.ExecCommand("InsertHorizontalRule", false, null);
        }

        /// <summary>
        /// Select all text in the document.
        /// </summary>
        public void SelectAll()
        {
            webBrowser.Document.ExecCommand("SelectAll", false, null);
        }

        /// <summary>
        /// Undo the last operation
        /// </summary>
        public void Undo()
        {
            webBrowser.Document.ExecCommand("Undo", false, null);
        }

        /// <summary>
        /// Redo based on the last Undo
        /// </summary>
        public void Redo()
        {
            webBrowser.Document.ExecCommand("Redo", false, null);
        }

        /// <summary>
        /// Cut the current selection and place it in the clipboard.
        /// </summary>
        public void Cut()
        {
            webBrowser.Document.ExecCommand("Cut", false, null);
        }

        /// <summary>
        /// Paste the contents of the clipboard into the current selection.
        /// </summary>
        public void Paste()
        {
            webBrowser.Document.ExecCommand("Paste", false, null);
        }

        /// <summary>
        /// Copy the current selection into the clipboard.
        /// </summary>
        public void Copy()
        {
            webBrowser.Document.ExecCommand("Copy", false, null);
        }

        /// <summary>
        /// Toggle the ordered list property for the current paragraph.
        /// </summary>
        public void OrderedList()
        {
            webBrowser.Document.ExecCommand("InsertOrderedList", false, null);
        }

        /// <summary>
        /// Toggle the unordered list property for the current paragraph.
        /// </summary>
        public void UnorderedList()
        {
            webBrowser.Document.ExecCommand("InsertUnorderedList", false, null);
        }

        /// <summary>
        /// Toggle the left justify property for the currnet block.
        /// </summary>
        public void JustifyLeft()
        {
            webBrowser.Document.ExecCommand("JustifyLeft", false, null);
        }

        /// <summary>
        /// Toggle the right justify property for the current block.
        /// </summary>
        public void JustifyRight()
        {
            webBrowser.Document.ExecCommand("JustifyRight", false, null);
        }

        /// <summary>
        /// Toggle the center justify property for the current block.
        /// </summary>
        public void JustifyCenter()
        {
            webBrowser.Document.ExecCommand("JustifyCenter", false, null);
        }

        /// <summary>
        /// Toggle the full justify property for the current block.
        /// </summary>
        public void JustifyFull()
        {
            webBrowser.Document.ExecCommand("JustifyFull", false, null);
        }

        /// <summary>
        /// Toggle bold formatting on the current selection.
        /// </summary>
        public void Bold()
        {
            webBrowser.Document.ExecCommand("Bold", false, null);
        }

        /// <summary>
        /// Toggle italic formatting on the current selection.
        /// </summary>
        public void Italic()
        {
            webBrowser.Document.ExecCommand("Italic", false, null);
        }

        /// <summary>
        /// Toggle underline formatting on the current selection.
        /// </summary>
        public void Underline()
        {
            webBrowser.Document.ExecCommand("Underline", false, null);
        }

        /// <summary>
        /// Delete the current selection.
        /// </summary>
        public void Delete()
        {
            webBrowser.Document.ExecCommand("Delete", false, null);
        }

        /// <summary>
        /// Insert an imange.
        /// </summary>
        public void InsertImage()
        {
            webBrowser.Document.ExecCommand("InsertImage", true, null);
        }

        /// <summary>
        /// Indent the current paragraph.
        /// </summary>
        public void Indent()
        {
            webBrowser.Document.ExecCommand("Indent", false, null);
        }

        /// <summary>
        /// Outdent the current paragraph.
        /// </summary>
        public void Outdent()
        {
            webBrowser.Document.ExecCommand("Outdent", false, null);
        }

        /// <summary>
        /// Insert a link at the current selection.
        /// </summary>
        /// <param name="url">The link url</param>
        public void InsertLink(string url)
        {
            webBrowser.Document.ExecCommand("CreateLink", false, url);
        }

        /// <summary>
        /// Get the ready state of the internal browser component.
        /// </summary>
        public ReadyState ReadyState
        {
            get
            {
                switch (doc.readyState.ToLower())
                {
                    case "uninitialized":
                        return ReadyState.Uninitialized;
                    case "loading":
                        return ReadyState.Loading;
                    case "loaded":
                        return ReadyState.Loaded;
                    case "interactive":
                        return ReadyState.Interactive;
                    case "complete":
                        return ReadyState.Complete;
                    default:
                        return ReadyState.Uninitialized;
                }
            }
        }

        /// <summary>
        /// Get the current selection type.
        /// </summary>
        public SelectionType SelectionType
        {
            get
            {
                var type = doc.selection.type.ToLower();
                switch (type)
                {
                    case "text":
                        return SelectionType.Text;
                    case "control":
                        return SelectionType.Control;
                    case "none":
                        return SelectionType.None;
                    default:
                        return SelectionType.None;
                }
            }
        }

        /// <summary>
        /// Get/Set the current font size.
        /// </summary>
        [Browsable(false)]
        public FontSize FontSize
        {
            get
            {
                if (ReadyState != ReadyState.Complete)
                    return FontSize.NA;
                try
                {
                    switch ((int)doc.queryCommandValue("FontSize"))
                    {
                        case 1:
                            return FontSize.One;
                        case 2:
                            return FontSize.Two;
                        case 3:
                            return FontSize.Three;
                        case 4:
                            return FontSize.Four;
                        case 5:
                            return FontSize.Five;
                        case 6:
                            return FontSize.Six;
                        case 7:
                            return FontSize.Seven;
                        default:
                            return FontSize.NA;
                    }
                }
                catch (Exception)
                {
                    return FontSize.NA;
                }
            }
            set
            {
                int sz;
                switch (value)
                {
                    case FontSize.One:
                        sz = 1;
                        break;
                    case FontSize.Two:
                        sz = 2;
                        break;
                    case FontSize.Three:
                        sz = 3;
                        break;
                    case FontSize.Four:
                        sz = 4;
                        break;
                    case FontSize.Five:
                        sz = 5;
                        break;
                    case FontSize.Six:
                        sz = 6;
                        break;
                    case FontSize.Seven:
                        sz = 7;
                        break;
                    default:
                        sz = 7;
                        break;
                }
                webBrowser.Document.ExecCommand("FontSize", false, sz.ToString());
            }
        }

        /// <summary>
        /// Get/Set the current font name.
        /// </summary>
        [Browsable(false)]
        public FontFamily FontName
        {
            get
            {
                if (ReadyState != ReadyState.Complete)
                    return null;
                string name = doc.queryCommandValue("FontName") as string;
                if (name == null) return null;
                return new FontFamily(name);
            }
            set
            {
                if (value != null)
                    webBrowser.Document.ExecCommand("FontName", false, value.Name);
            }
        }

        /// <summary>
        /// Get/Set the editor's foreground (text) color for the current selection.
        /// </summary>
        [Browsable(false)]
        public Color EditorForeColor
        {
            get
            {
                if (ReadyState != ReadyState.Complete)
                    return Color.Black;
                var foreColor = doc.queryCommandValue("ForeColor");
                if (foreColor == null)
                {
                    return Color.Black;
                }
                else
                {
                    var foreColorAsString = foreColor.ToString();
                    if (string.IsNullOrWhiteSpace(foreColorAsString))
                    {
                        return Color.Black;
                    }
                    return ConvertToColor(foreColorAsString);
                }
            }
            set
            {
                string colorstr = 
                    string.Format("#{0:X2}{1:X2}{2:X2}", value.R, value.G, value.B);
                webBrowser.Document.ExecCommand("ForeColor", false, colorstr);
            }
        }

        /// <summary>
        /// Get/Set the editor's background color for the current selection.
        /// </summary>
        [Browsable(false)]
        public Color EditorBackColor
        {
            get
            {
                if (ReadyState != ReadyState.Complete)
                    return Color.White;
                return ConvertToColor(doc.queryCommandValue("BackColor").ToString());
            }
            set
            {
                string colorstr =
                    string.Format("#{0:X2}{1:X2}{2:X2}", value.R, value.G, value.B);
                webBrowser.Document.ExecCommand("BackColor", false, colorstr);
            }
        }

        public void SelectBodyColor()
        {
            Color color = BodyBackgroundColor;
            if (ShowColorDialog(ref color))
                BodyBackgroundColor = color;
        }

        /// <summary>
        /// Initiate the foreground (text) color dialog for the current selection.
        /// </summary>
        public void SelectForeColor()
        {
            Color color = EditorForeColor;
            if (ShowColorDialog(ref color))
                EditorForeColor = color;
        }

        /// <summary>
        /// Initiate the background color dialog for the current selection.
        /// </summary>
        public void SelectBackColor()
        {
            Color color = EditorBackColor;
            if (ShowColorDialog(ref color))
                EditorBackColor = color;
        }

        /// <summary>
        /// Convert the custom integer (B G R) format to a color object.
        /// </summary>
        /// <param name="clrs">the custorm color as a string</param>
        /// <returns>the color</returns>
        private static Color ConvertToColor(string clrs)
        {
            int red, green, blue;
            // sometimes clrs is HEX organized as (RED)(GREEN)(BLUE)
            if (clrs.StartsWith("#"))
            {
                var clrn = Convert.ToInt32(clrs.Substring(1), 16);
                red = (clrn >> 16) & 255;
                green = (clrn >> 8) & 255;
                blue = clrn & 255;
            }
            else // otherwise clrs is DECIMAL organized as (BlUE)(GREEN)(RED)
            {
                var clrn = Convert.ToInt32(clrs);
                red = clrn & 255;
                green = (clrn >> 8) & 255;
                blue = (clrn >> 16) & 255;
            }
            return Color.FromArgb(red, green, blue);
        }

        /// <summary>
        /// Called when the cut tool strip button on the editor context menu 
        /// is clicked.
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">EventArgs</param>
        private void cutToolStripButton_Click(object sender, EventArgs e)
        {
            Cut();
        }

        /// <summary>
        /// Called when the paste tool strip button on the editor context menu 
        /// is clicked.
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">EventArgs</param>
        private void pasteToolStripButton_Click(object sender, EventArgs e)
        {
            Paste();
        }

        /// <summary>
        /// Called when the copy tool strip button on the editor context menu 
        /// is clicked.
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">EventArgs</param>
        private void copyToolStripButton_Click(object sender, EventArgs e)
        {
            Copy();
        }

        /// <summary>
        /// Called when the bold button on the tool strip is pressed.
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">EventArgs</param>
        private void boldButton_Click(object sender, EventArgs e)
        {
            Bold();
        }

        /// <summary>
        /// Called when the italic button on the tool strip is pressed.
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">EventArgs</param>
        private void italicButton_Click(object sender, EventArgs e)
        {
            Italic();
        }

        /// <summary>
        /// Called when the underline button on the tool strip is pressed.
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">EventArgs</param>
        private void underlineButton_Click(object sender, EventArgs e)
        {
            Underline();
        }

        /// <summary>
        /// Called when the foreground color button on the tool strip is pressed.
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">EventArgs</param>
        private void colorButton_Click(object sender, EventArgs e)
        {
            SelectForeColor();
        }

        /// <summary>
        /// Called when the background color button on the tool strip is pressed.
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">EventArgs</param>
        private void backColorButton_Click(object sender, EventArgs e)
        {
            SelectBackColor();
        }

        /// <summary>
        /// Show the interactive Color dialog.
        /// </summary>
        /// <param name="color">the input and output color</param>
        /// <returns>true if dialog accepted, false if dialog cancelled</returns>
        private bool ShowColorDialog(ref Color color)
        {
            bool selected;
            using (ColorDialog dlg = new ColorDialog())
            {
                dlg.SolidColorOnly = true;
                dlg.AllowFullOpen = false;
                dlg.AnyColor = false;
                dlg.FullOpen = false;
                dlg.CustomColors = null;
                dlg.Color = color;
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    selected = true;
                    color = dlg.Color;
                }
                else
                {
                    selected = false;
                }
            }
            return selected;
        }

        /// <summary>
        /// Called when the link button on the toolstrip is pressed.
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">EventArgs</param>
        private void linkButton_Click(object sender, EventArgs e)
        {
            SelectLink();
        }

        /// <summary>
        /// Determine if text is selected and only one or no link is selected.
        /// </summary>
        /// <returns>Boolean</returns>
        public bool CanInsertLink()
        {
            //return (SelectionType == SelectionType.Text && !LinksInSelection());
            return (!LinksInSelection());        
        }

        /// <summary>
        /// Determine wheter the currently selected text contains two or more links.
        /// </summary>
        /// <returns>true if two links or more links are currently selected, false otherwise</returns>
        private bool LinksInSelection()
        {
            if (SelectionType != SelectionType.Text) return false;
            bool twoOrMoreLinksInSelection = false;
            IHTMLTxtRange txtRange = (IHTMLTxtRange)doc.selection.createRange();

            if (txtRange != null && !string.IsNullOrEmpty(txtRange.htmlText))
            {
                Regex regex = new Regex("<a href=\"[^\"]+\">[^<]+</a>", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
                MatchCollection matchCollection = regex.Matches(txtRange.htmlText);

                twoOrMoreLinksInSelection = (matchCollection.Count > 1); // true if more than one link is selected
            }
            if (twoOrMoreLinksInSelection)
            {
                string type = doc.selection.type;
            }
            return twoOrMoreLinksInSelection;
        }

        /// <summary>
        /// Show a custom insert link dialog, and create the link.
        /// </summary>
        public void SelectLink()
        {
            string url = string.Empty;
            switch (SelectionType)
            {
                case SelectionType.Control:
                    {
                        IHTMLControlRange range = doc.selection.createRange() as IHTMLControlRange;
                        if (range != null && range.length > 0)
                        {
                            var elem = range.item(0);
                            if (elem != null && string.Compare(elem.tagName, "img", true) == 0)
                            {
                                elem = elem.parentElement;
                                if (elem != null && string.Compare(elem.tagName, "a", true) == 0)
                                {
                                    url = elem.getAttribute("href") as string;
                                }
                            }
                        }
                    }
                    break;
                case SelectionType.Text:
                    {
                        IHTMLTxtRange txtRange = (IHTMLTxtRange)doc.selection.createRange();
                        if (txtRange != null && !string.IsNullOrEmpty(txtRange.htmlText))
                        {
                            Regex regex = new Regex("^\\s*<a href=\"([^\"]+)\">[^<]+</a>\\s*$", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
                            Match match = regex.Match(txtRange.htmlText);

                            if (match.Success)
                                url = match.Groups[1].Value;
                        }
                    }
                    break;
            }
            using (LinkDialog dlg = new LinkDialog())
            {
                Uri uri;
                if (Uri.TryCreate(url, UriKind.Absolute, out uri))
                {
                    dlg.URL = string.Format("{0}{1}", uri.Host, uri.PathAndQuery == null ? null : uri.PathAndQuery.TrimEnd('/'));
                    dlg.Scheme = string.Format("{0}://", uri.Scheme);
                }
                dlg.ShowDialog();
                if (!dlg.Accepted) return;
                string link = string.Format("{0}{1}", dlg.Scheme, dlg.URL);
                if (link == null || link.Length == 0)
                {
                    MessageBox.Show(this.ParentForm, "Invalid URL");
                    return;
                }
                InsertLink(link);
            }
        }

        /// <summary>
        /// Called when the image button on the toolstrip is clicked.
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">EventArgs</param>
        private void imageButton_Click(object sender, EventArgs e)
        {
            InsertImage();
        }

        /// <summary>
        /// Called when the outdent button on the toolstrip is clicked.
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">EventArgs</param>
        private void outdentButton_Click(object sender, EventArgs e)
        {
            Outdent();
        }

        /// <summary>
        /// Called when the indent button on the toolstrip is clicked.
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">EventArgs</param>
        private void indentButton_Click(object sender, EventArgs e)
        {
            Indent();
        }

        /// <summary>
        /// Called when the cut button is clicked on the editor context menu.
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">EventArgs</param>
        private void cutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Cut();
        }

        /// <summary>
        /// Called when the copy button is clicked on the editor context menu.
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">EventArgs</param>
        private void copyToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Copy();
        }

        /// <summary>
        /// Called when the paste button is clicked on the editor context menu.
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">EventArgs</param>
        private void pasteToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Paste();
        }

        /// <summary>
        /// Called when the delete button is clicked on the editor context menu.
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">EventArgs</param>
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Delete();
        }

        /// <summary>
        /// Search the document from the current selection, and reset the 
        /// the selection to the text found, if successful.
        /// </summary>
        /// <param name="text">the text for which to search</param>
        /// <param name="forward">true for forward search, false for backward</param>
        /// <param name="matchWholeWord">true to match whole word, false otherwise</param>
        /// <param name="matchCase">true to match case, false otherwise</param>
        /// <returns></returns>
        public bool Search(string text, bool forward, bool matchWholeWord, bool matchCase)
        {
            bool success = false;
            if (webBrowser.Document != null)
            {
                var doc = webBrowser.Document.DomDocument as IHTMLDocument2;
                var body = doc.body as IHTMLBodyElement;
                if (body != null)
                {
                    IHTMLTxtRange range;
                    if (doc.selection != null)
                    {
                        range = doc.selection.createRange() as IHTMLTxtRange;
                        var dup = range.duplicate();
                        dup.collapse(true);
                        // if selection is degenerate, then search whole body
                        if (range.isEqual(dup))
                        {
                            range = body.createTextRange();
                        }
                        else
                        {
                            if (forward)
                                range.moveStart("character", 1);
                            else
                                range.moveEnd("character", -1);
                        }
                    }
                    else
                        range = body.createTextRange();
                    int flags = 0;
                    if (matchWholeWord) flags += 2;
                    if (matchCase) flags += 4;
                    success =
                        range.findText(text, forward ? 999999 : -999999, flags);
                    if (success)
                    {
                        range.select();
                        range.scrollIntoView(!forward);
                    }
                }
            }
            return success;
        }

        /// <summary>
        /// Event handler for the ordered list toolbar button
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">EventArgs</param>
        private void orderedListButton_Click(object sender, EventArgs e)
        {
            OrderedList();
        }

        /// <summary>
        /// Event handler for the unordered list toolbar button
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">EventArgs</param>
        private void unorderedListButton_Click(object sender, EventArgs e)
        {
            UnorderedList();
        }

        /// <summary>
        /// Event handler for the left justify toolbar button.
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">EventArgs</param>
        private void justifyLeftButton_Click(object sender, EventArgs e)
        {
            JustifyLeft();
        }

        /// <summary>
        /// Event handler for the center justify toolbar button.
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">EventArgs</param>
        private void justifyCenterButton_Click(object sender, EventArgs e)
        {
            JustifyCenter();
        }

        /// <summary>
        /// Event handler for the right justify toolbar button.
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">EventArgs</param>
        private void justifyRightButton_Click(object sender, EventArgs e)
        {
            JustifyRight();
        }

        /// <summary>
        /// Event handler for the full justify toolbar button.
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">EventArgs</param>
        private void justifyFullButton_Click(object sender, EventArgs e)
        {
            JustifyFull();
        }

        private void backgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectBodyColor();
        }


        public void ShowWarningMessage(string message)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string>(ShowWarningMessage), message);
                return;
            }
            MessageBox.Show(message, "TAD", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void ShowWaitingPanel(string message = null)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string>(ShowWaitingPanel), message);
                return;
            }
            if (string.IsNullOrWhiteSpace(message))
            {
                message = "Processando...";
            }
            modalWaitingPanel.Show(message);
        }

        public void HideWaitingPanel()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(HideWaitingPanel));
                return;
            }
            modalWaitingPanel.Hide();
        }

        public void ShowErrorMessage(string message)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string>(ShowErrorMessage), message);
                return;
            }
            MessageBox.Show(message, "TAD", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        private void backButton_Click(object sender, EventArgs e)
        {
            timer.Stop();
            parentView.ShowControlView(new PostListUserControl(parentView) { Dock = DockStyle.Fill });
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += backgrounWorker_DoWork;
            backgroundWorker.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted;
            backgroundWorker.RunWorkerAsync(post);
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            HideWaitingPanel();

            if (e.Error == null)
            {
                parentView.ShowControlView(new PostListUserControl(parentView) { Dock = DockStyle.Fill });
            }
            else
            {
                ShowErrorMessage(string.Format("Ops... Ocorreu um erro ao salvar o post [{0}]. Tente repetir a operação.", e.Error.Message));
            }
        }

        private void backgrounWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            ShowWaitingPanel("Salvando post...");

            var loggedUser = UserContext.GetInstance().LoggedUser;

            var post = (Post)e.Argument;
            if (post == null)
            {
                post = new Post();
                post.Created = DateTime.Now;
                post.CreatedBy = loggedUser;
            }
            post.Modified = DateTime.Now;
            post.ModifiedBy = loggedUser;

            var postTitle = postTitleTextBox.Text;
            if (string.IsNullOrWhiteSpace(postTitle))
            {
                ShowWarningMessage("Título do post é obrigatório");
                return;
            }
            post.Title = postTitle;

            var postContent = ReplaceFileSystemImages(Html);
            if (string.IsNullOrWhiteSpace(postContent))
            {
                ShowWarningMessage("É obrigatório escrever o conteúdo do post");
                return;
            }
            post.Content = postContent;

            if (postInternalVisibilityRadioButton.Checked)
            {
                post.Visibility = VisibilityType.Internal;
            }
            else if (postPublicVisibilityRadioButton.Checked)
            {
                post.Visibility = VisibilityType.Public;
            }

            var postService = new PostService();
            postService.SavePost(post);
        }
    }

    /// <summary>
    /// Enumeration of possible font sizes for the Editor component
    /// </summary>
    public enum FontSize
    {
        One,
        Two,
        Three,
        Four, 
        Five,
        Six,
        Seven,
        NA
    }

    public enum SelectionType
    {
        Text,
        Control,
        None
    }

    public enum ReadyState
    {
        Uninitialized,
        Loading,
        Loaded,
        Interactive,
        Complete
    }

}