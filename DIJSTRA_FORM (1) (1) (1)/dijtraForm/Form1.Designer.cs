namespace dijtraForm
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pnGraph = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabTable1 = new System.Windows.Forms.TabPage();
            this.AdjacencyMatrix = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.AdjacencyList = new Guna.UI2.WinForms.Guna2DataGridView();
            this.Node = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Adjacency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lbLogs = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.CbChoice = new Guna.UI2.WinForms.Guna2ComboBox();
            this.rdDfs = new Guna.UI2.WinForms.Guna2RadioButton();
            this.rdDijStra = new Guna.UI2.WinForms.Guna2RadioButton();
            this.rdBfs = new Guna.UI2.WinForms.Guna2RadioButton();
            this.btnRun = new Guna.UI2.WinForms.Guna2GradientButton();
            this.txtStart = new Guna.UI2.WinForms.Guna2TextBox();
            this.labelValue = new System.Windows.Forms.Label();
            this.trackbarSpeed = new Guna.UI2.WinForms.Guna2TrackBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolTripOpenGraph = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.SaveGraphToolTrip = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.authorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.instructionManualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnFocus = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnUndo = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnRanDomize = new Guna.UI2.WinForms.Guna2GradientButton();
            this.checkBoxShowGrid = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tabTable1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AdjacencyMatrix)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AdjacencyList)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnGraph
            // 
            this.pnGraph.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnGraph.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnGraph.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnGraph.Location = new System.Drawing.Point(13, 100);
            this.pnGraph.Margin = new System.Windows.Forms.Padding(0, 3, 3, 7);
            this.pnGraph.Name = "pnGraph";
            this.pnGraph.Size = new System.Drawing.Size(627, 552);
            this.pnGraph.TabIndex = 2;
            this.pnGraph.Paint += new System.Windows.Forms.PaintEventHandler(this.pnGraph_Paint);
            this.pnGraph.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pnGraph_MouseClick);
            this.pnGraph.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnGraph_MouseMove);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabTable1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(3, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(462, 470);
            this.tabControl1.TabIndex = 1;
            // 
            // tabTable1
            // 
            this.tabTable1.BackColor = System.Drawing.Color.LemonChiffon;
            this.tabTable1.Controls.Add(this.AdjacencyMatrix);
            this.tabTable1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabTable1.Location = new System.Drawing.Point(4, 24);
            this.tabTable1.Name = "tabTable1";
            this.tabTable1.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabTable1.Size = new System.Drawing.Size(454, 442);
            this.tabTable1.TabIndex = 0;
            this.tabTable1.Text = "Adjacency Matrix";
            // 
            // AdjacencyMatrix
            // 
            this.AdjacencyMatrix.AllowUserToAddRows = false;
            this.AdjacencyMatrix.AllowUserToDeleteRows = false;
            this.AdjacencyMatrix.AllowUserToResizeColumns = false;
            this.AdjacencyMatrix.AllowUserToResizeRows = false;
            this.AdjacencyMatrix.BackgroundColor = System.Drawing.Color.PapayaWhip;
            this.AdjacencyMatrix.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AdjacencyMatrix.ColumnHeadersHeight = 35;
            this.AdjacencyMatrix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.AdjacencyMatrix.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.AdjacencyMatrix.DefaultCellStyle = dataGridViewCellStyle1;
            this.AdjacencyMatrix.Location = new System.Drawing.Point(14, 17);
            this.AdjacencyMatrix.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.AdjacencyMatrix.Name = "AdjacencyMatrix";
            this.AdjacencyMatrix.ReadOnly = true;
            this.AdjacencyMatrix.RowHeadersWidth = 50;
            this.AdjacencyMatrix.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.AdjacencyMatrix.RowTemplate.Height = 24;
            this.AdjacencyMatrix.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.AdjacencyMatrix.Size = new System.Drawing.Size(423, 410);
            this.AdjacencyMatrix.TabIndex = 0;
            this.AdjacencyMatrix.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.AdjacencyMatrix_CellClick);
            this.AdjacencyMatrix.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.AdjacencyMatrix_CellMouseClick);
            this.AdjacencyMatrix.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.AdjacencyMatrix_CellMouseEnter);
            this.AdjacencyMatrix.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.AdjacencyMatrix_CellMouseLeave);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Wheat;
            this.tabPage2.Controls.Add(this.AdjacencyList);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage2.Size = new System.Drawing.Size(454, 442);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Adjacency List";
            // 
            // AdjacencyList
            // 
            this.AdjacencyList.AllowUserToAddRows = false;
            this.AdjacencyList.AllowUserToDeleteRows = false;
            this.AdjacencyList.AllowUserToResizeColumns = false;
            this.AdjacencyList.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            this.AdjacencyList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.AdjacencyList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.AdjacencyList.ColumnHeadersHeight = 17;
            this.AdjacencyList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.AdjacencyList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Node,
            this.Adjacency});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.AdjacencyList.DefaultCellStyle = dataGridViewCellStyle4;
            this.AdjacencyList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.AdjacencyList.Location = new System.Drawing.Point(30, 21);
            this.AdjacencyList.Name = "AdjacencyList";
            this.AdjacencyList.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.AdjacencyList.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.AdjacencyList.RowHeadersVisible = false;
            this.AdjacencyList.RowHeadersWidth = 51;
            this.AdjacencyList.Size = new System.Drawing.Size(400, 405);
            this.AdjacencyList.TabIndex = 0;
            this.AdjacencyList.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.AdjacencyList.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.AdjacencyList.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.AdjacencyList.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.AdjacencyList.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.AdjacencyList.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.AdjacencyList.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.AdjacencyList.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.AdjacencyList.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.AdjacencyList.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AdjacencyList.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.AdjacencyList.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.AdjacencyList.ThemeStyle.HeaderStyle.Height = 17;
            this.AdjacencyList.ThemeStyle.ReadOnly = true;
            this.AdjacencyList.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.AdjacencyList.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.AdjacencyList.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AdjacencyList.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.AdjacencyList.ThemeStyle.RowsStyle.Height = 22;
            this.AdjacencyList.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.AdjacencyList.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // Node
            // 
            this.Node.HeaderText = "Đỉnh";
            this.Node.MinimumWidth = 6;
            this.Node.Name = "Node";
            this.Node.ReadOnly = true;
            // 
            // Adjacency
            // 
            this.Adjacency.HeaderText = "Kề với";
            this.Adjacency.MinimumWidth = 6;
            this.Adjacency.Name = "Adjacency";
            this.Adjacency.ReadOnly = true;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.Cornsilk;
            this.tabPage3.Controls.Add(this.lbLogs);
            this.tabPage3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(454, 442);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Logs";
            // 
            // lbLogs
            // 
            this.lbLogs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbLogs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLogs.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lbLogs.Location = new System.Drawing.Point(16, 16);
            this.lbLogs.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lbLogs.Multiline = true;
            this.lbLogs.Name = "lbLogs";
            this.lbLogs.ReadOnly = true;
            this.lbLogs.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.lbLogs.ShortcutsEnabled = false;
            this.lbLogs.Size = new System.Drawing.Size(429, 414);
            this.lbLogs.TabIndex = 0;
            this.lbLogs.Enter += new System.EventHandler(this.lbLogs_Enter);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Azure;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.CbChoice);
            this.panel1.Controls.Add(this.rdDfs);
            this.panel1.Controls.Add(this.rdDijStra);
            this.panel1.Controls.Add(this.rdBfs);
            this.panel1.Controls.Add(this.btnRun);
            this.panel1.Controls.Add(this.txtStart);
            this.panel1.Controls.Add(this.labelValue);
            this.panel1.Controls.Add(this.trackbarSpeed);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1132, 84);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(841, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Speed";
            // 
            // CbChoice
            // 
            this.CbChoice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.CbChoice.BackColor = System.Drawing.Color.Transparent;
            this.CbChoice.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.CbChoice.BorderRadius = 2;
            this.CbChoice.DisplayMember = "khka";
            this.CbChoice.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CbChoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbChoice.FillColor = System.Drawing.Color.LightGoldenrodYellow;
            this.CbChoice.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CbChoice.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CbChoice.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.CbChoice.ForeColor = System.Drawing.Color.Red;
            this.CbChoice.ItemHeight = 30;
            this.CbChoice.Items.AddRange(new object[] {
            "Undirected",
            "Directed"});
            this.CbChoice.Location = new System.Drawing.Point(276, 30);
            this.CbChoice.Name = "CbChoice";
            this.CbChoice.Size = new System.Drawing.Size(142, 36);
            this.CbChoice.StartIndex = 0;
            this.CbChoice.TabIndex = 10;
            this.CbChoice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.CbChoice.SelectedIndexChanged += new System.EventHandler(this.guna2ComboBox1_SelectedIndexChanged);
            // 
            // rdDfs
            // 
            this.rdDfs.AutoSize = true;
            this.rdDfs.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rdDfs.CheckedState.BorderThickness = 0;
            this.rdDfs.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rdDfs.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rdDfs.CheckedState.InnerOffset = -4;
            this.rdDfs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdDfs.ForeColor = System.Drawing.Color.DarkGreen;
            this.rdDfs.Location = new System.Drawing.Point(133, 63);
            this.rdDfs.Name = "rdDfs";
            this.rdDfs.Size = new System.Drawing.Size(49, 17);
            this.rdDfs.TabIndex = 5;
            this.rdDfs.Text = "DFS";
            this.rdDfs.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rdDfs.UncheckedState.BorderThickness = 2;
            this.rdDfs.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rdDfs.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.rdDfs.CheckedChanged += new System.EventHandler(this.rdDfs_CheckedChanged);
            // 
            // rdDijStra
            // 
            this.rdDijStra.AutoSize = true;
            this.rdDijStra.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rdDijStra.CheckedState.BorderThickness = 0;
            this.rdDijStra.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rdDijStra.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rdDijStra.CheckedState.InnerOffset = -4;
            this.rdDijStra.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdDijStra.ForeColor = System.Drawing.Color.DarkGreen;
            this.rdDijStra.Location = new System.Drawing.Point(31, 62);
            this.rdDijStra.Name = "rdDijStra";
            this.rdDijStra.Size = new System.Drawing.Size(70, 17);
            this.rdDijStra.TabIndex = 4;
            this.rdDijStra.Text = "Dijstra\'s";
            this.rdDijStra.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rdDijStra.UncheckedState.BorderThickness = 2;
            this.rdDijStra.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rdDijStra.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.rdDijStra.CheckedChanged += new System.EventHandler(this.rdDijStra_CheckedChanged);
            // 
            // rdBfs
            // 
            this.rdBfs.AutoSize = true;
            this.rdBfs.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rdBfs.CheckedState.BorderThickness = 0;
            this.rdBfs.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rdBfs.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rdBfs.CheckedState.InnerOffset = -4;
            this.rdBfs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdBfs.ForeColor = System.Drawing.Color.DarkGreen;
            this.rdBfs.Location = new System.Drawing.Point(212, 63);
            this.rdBfs.Name = "rdBfs";
            this.rdBfs.Size = new System.Drawing.Size(48, 17);
            this.rdBfs.TabIndex = 4;
            this.rdBfs.Text = "BFS";
            this.rdBfs.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rdBfs.UncheckedState.BorderThickness = 2;
            this.rdBfs.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rdBfs.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.rdBfs.CheckedChanged += new System.EventHandler(this.rdBfs_CheckedChanged);
            // 
            // btnRun
            // 
            this.btnRun.Animated = true;
            this.btnRun.AutoRoundedCorners = true;
            this.btnRun.BackColor = System.Drawing.Color.Transparent;
            this.btnRun.BorderRadius = 12;
            this.btnRun.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRun.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRun.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRun.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRun.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRun.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnRun.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnRun.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRun.ForeColor = System.Drawing.Color.Red;
            this.btnRun.IndicateFocus = true;
            this.btnRun.Location = new System.Drawing.Point(147, 30);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(60, 27);
            this.btnRun.TabIndex = 5;
            this.btnRun.Text = "Run";
            this.btnRun.UseTransparentBackground = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // txtStart
            // 
            this.txtStart.BorderColor = System.Drawing.Color.PeachPuff;
            this.txtStart.BorderRadius = 9;
            this.txtStart.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtStart.DefaultText = "Start";
            this.txtStart.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtStart.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtStart.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtStart.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtStart.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtStart.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtStart.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtStart.Location = new System.Drawing.Point(26, 31);
            this.txtStart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtStart.Name = "txtStart";
            this.txtStart.PasswordChar = '\0';
            this.txtStart.PlaceholderText = "";
            this.txtStart.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtStart.SelectedText = "";
            this.txtStart.Size = new System.Drawing.Size(75, 25);
            this.txtStart.TabIndex = 7;
            this.txtStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtStart.TextChanged += new System.EventHandler(this.txtStart_TextChanged);
            this.txtStart.Enter += new System.EventHandler(this.txtStart_Enter);
            this.txtStart.Leave += new System.EventHandler(this.txtStart_Leave);
            // 
            // labelValue
            // 
            this.labelValue.AutoSize = true;
            this.labelValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.labelValue.Location = new System.Drawing.Point(935, 65);
            this.labelValue.Name = "labelValue";
            this.labelValue.Size = new System.Drawing.Size(33, 13);
            this.labelValue.TabIndex = 9;
            this.labelValue.Text = "value";
            this.labelValue.Visible = false;
            // 
            // trackbarSpeed
            // 
            this.trackbarSpeed.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.trackbarSpeed.BackColor = System.Drawing.Color.Transparent;
            this.trackbarSpeed.Cursor = System.Windows.Forms.Cursors.Hand;
            this.trackbarSpeed.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.trackbarSpeed.LargeChange = 100;
            this.trackbarSpeed.Location = new System.Drawing.Point(844, 39);
            this.trackbarSpeed.Maximum = 2000;
            this.trackbarSpeed.Minimum = 100;
            this.trackbarSpeed.Name = "trackbarSpeed";
            this.trackbarSpeed.Size = new System.Drawing.Size(212, 23);
            this.trackbarSpeed.TabIndex = 0;
            this.trackbarSpeed.ThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.trackbarSpeed.Value = 1050;
            this.trackbarSpeed.ValueChanged += new System.EventHandler(this.trackbarSpeed_ValueChanged);
            this.trackbarSpeed.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackbarSpeed_MouseUp);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1130, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolTripOpenGraph,
            this.toolStripSeparator2,
            this.SaveGraphToolTrip,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // ToolTripOpenGraph
            // 
            this.ToolTripOpenGraph.Image = global::dijtraForm.Properties.Resources.Open_Folder;
            this.ToolTripOpenGraph.Name = "ToolTripOpenGraph";
            this.ToolTripOpenGraph.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.ToolTripOpenGraph.Size = new System.Drawing.Size(181, 22);
            this.ToolTripOpenGraph.Text = "Open Graph";
            this.ToolTripOpenGraph.Click += new System.EventHandler(this.ToolTripOpenGraph_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(178, 6);
            // 
            // SaveGraphToolTrip
            // 
            this.SaveGraphToolTrip.Image = global::dijtraForm.Properties.Resources.SAVE1;
            this.SaveGraphToolTrip.Name = "SaveGraphToolTrip";
            this.SaveGraphToolTrip.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.SaveGraphToolTrip.Size = new System.Drawing.Size(181, 22);
            this.SaveGraphToolTrip.Text = "Save Graph";
            this.SaveGraphToolTrip.Click += new System.EventHandler(this.SaveGraphToolTrip_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(178, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::dijtraForm.Properties.Resources.exit__2_;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.authorToolStripMenuItem,
            this.instructionManualToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.aboutToolStripMenuItem.Text = " About";
            // 
            // authorToolStripMenuItem
            // 
            this.authorToolStripMenuItem.Image = global::dijtraForm.Properties.Resources.People2;
            this.authorToolStripMenuItem.Name = "authorToolStripMenuItem";
            this.authorToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.authorToolStripMenuItem.Text = "Author";
            this.authorToolStripMenuItem.Click += new System.EventHandler(this.authorToolStripMenuItem_Click);
            // 
            // instructionManualToolStripMenuItem
            // 
            this.instructionManualToolStripMenuItem.Image = global::dijtraForm.Properties.Resources.book1;
            this.instructionManualToolStripMenuItem.Name = "instructionManualToolStripMenuItem";
            this.instructionManualToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.instructionManualToolStripMenuItem.Text = "Instruction Manual";
            this.instructionManualToolStripMenuItem.Click += new System.EventHandler(this.instructionManualToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.Controls.Add(this.guna2Panel1);
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Location = new System.Drawing.Point(653, 100);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(468, 562);
            this.panel2.TabIndex = 1;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.btnFocus);
            this.guna2Panel1.Controls.Add(this.btnUndo);
            this.guna2Panel1.Controls.Add(this.btnRanDomize);
            this.guna2Panel1.Controls.Add(this.checkBoxShowGrid);
            this.guna2Panel1.Location = new System.Drawing.Point(28, 495);
            this.guna2Panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(398, 57);
            this.guna2Panel1.TabIndex = 1;
            // 
            // btnFocus
            // 
            this.btnFocus.Animated = true;
            this.btnFocus.AutoRoundedCorners = true;
            this.btnFocus.BackColor = System.Drawing.Color.Transparent;
            this.btnFocus.BorderRadius = 12;
            this.btnFocus.DefaultAutoSize = true;
            this.btnFocus.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnFocus.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnFocus.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnFocus.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnFocus.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnFocus.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnFocus.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnFocus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnFocus.ForeColor = System.Drawing.Color.Red;
            this.btnFocus.IndicateFocus = true;
            this.btnFocus.Location = new System.Drawing.Point(315, 11);
            this.btnFocus.Name = "btnFocus";
            this.btnFocus.Size = new System.Drawing.Size(61, 27);
            this.btnFocus.TabIndex = 12;
            this.btnFocus.Text = "Focus";
            this.btnFocus.UseTransparentBackground = true;
            this.btnFocus.Click += new System.EventHandler(this.btnFocus_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.AutoRoundedCorners = true;
            this.btnUndo.BackColor = System.Drawing.Color.Transparent;
            this.btnUndo.BorderRadius = 12;
            this.btnUndo.DefaultAutoSize = true;
            this.btnUndo.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnUndo.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnUndo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnUndo.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnUndo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnUndo.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnUndo.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnUndo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnUndo.ForeColor = System.Drawing.Color.Red;
            this.btnUndo.Image = global::dijtraForm.Properties.Resources.ADD_TO_R;
            this.btnUndo.IndicateFocus = true;
            this.btnUndo.Location = new System.Drawing.Point(225, 11);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(80, 27);
            this.btnUndo.TabIndex = 12;
            this.btnUndo.Text = "Undo";
            this.btnUndo.UseTransparentBackground = true;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // btnRanDomize
            // 
            this.btnRanDomize.AutoRoundedCorners = true;
            this.btnRanDomize.BackColor = System.Drawing.Color.Transparent;
            this.btnRanDomize.BorderColor = System.Drawing.Color.DimGray;
            this.btnRanDomize.BorderRadius = 12;
            this.btnRanDomize.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            this.btnRanDomize.DefaultAutoSize = true;
            this.btnRanDomize.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRanDomize.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRanDomize.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRanDomize.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRanDomize.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRanDomize.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnRanDomize.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnRanDomize.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRanDomize.ForeColor = System.Drawing.Color.Red;
            this.btnRanDomize.IndicateFocus = true;
            this.btnRanDomize.Location = new System.Drawing.Point(116, 11);
            this.btnRanDomize.Name = "btnRanDomize";
            this.btnRanDomize.Size = new System.Drawing.Size(90, 27);
            this.btnRanDomize.TabIndex = 0;
            this.btnRanDomize.Text = "Randomize";
            this.btnRanDomize.UseTransparentBackground = true;
            this.btnRanDomize.Click += new System.EventHandler(this.btnRanDomize_Click);
            // 
            // checkBoxShowGrid
            // 
            this.checkBoxShowGrid.AutoSize = true;
            this.checkBoxShowGrid.Checked = true;
            this.checkBoxShowGrid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxShowGrid.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxShowGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxShowGrid.ForeColor = System.Drawing.Color.Black;
            this.checkBoxShowGrid.Location = new System.Drawing.Point(11, 18);
            this.checkBoxShowGrid.Name = "checkBoxShowGrid";
            this.checkBoxShowGrid.Size = new System.Drawing.Size(84, 17);
            this.checkBoxShowGrid.TabIndex = 0;
            this.checkBoxShowGrid.Text = "Show Grid";
            this.checkBoxShowGrid.UseVisualStyleBackColor = true;
            this.checkBoxShowGrid.CheckedChanged += new System.EventHandler(this.ShowGrid_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1132, 678);
            this.Controls.Add(this.pnGraph);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Graph Editor";
            this.Enter += new System.EventHandler(this.txtStart_Enter);
            this.Leave += new System.EventHandler(this.txtStart_Leave);
            this.tabControl1.ResumeLayout(false);
            this.tabTable1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AdjacencyMatrix)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AdjacencyList)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pnGraph;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabTable1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView AdjacencyMatrix;
        private Guna.UI2.WinForms.Guna2DataGridView AdjacencyList;
        private System.Windows.Forms.DataGridViewTextBoxColumn Node;
        private System.Windows.Forms.DataGridViewTextBoxColumn Adjacency;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveGraphToolTrip;
        private System.Windows.Forms.ToolStripMenuItem authorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem instructionManualToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolTripOpenGraph;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private Guna.UI2.WinForms.Guna2TrackBar trackbarSpeed;
        private System.Windows.Forms.Label labelValue;
        internal Guna.UI2.WinForms.Guna2TextBox txtStart;
        private Guna.UI2.WinForms.Guna2GradientButton btnRun;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.CheckBox checkBoxShowGrid;
        private Guna.UI2.WinForms.Guna2RadioButton rdDfs;
        private Guna.UI2.WinForms.Guna2RadioButton rdDijStra;
        private Guna.UI2.WinForms.Guna2RadioButton rdBfs;
        private Guna.UI2.WinForms.Guna2GradientButton btnRanDomize;
        private Guna.UI2.WinForms.Guna2GradientButton btnUndo;
        private Guna.UI2.WinForms.Guna2ComboBox CbChoice;
        private Guna.UI2.WinForms.Guna2GradientButton btnFocus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox lbLogs;
    }
}

