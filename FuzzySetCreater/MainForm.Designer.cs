namespace FuzzySetCreater
{
    partial class MainForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Input");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Output");
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle31 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle32 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend8 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnCreateUniverse = new System.Windows.Forms.Button();
            this.theTree = new System.Windows.Forms.TreeView();
            this.theGrid = new System.Windows.Forms.PropertyGrid();
            this.btnCreateFuzzySet = new System.Windows.Forms.Button();
            this.comboFuzzySet = new System.Windows.Forms.ComboBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.tabCharts = new System.Windows.Forms.TabControl();
            this.txtSelectFuzzySet = new System.Windows.Forms.Label();
            this.btnCreateOperatedFS = new System.Windows.Forms.Button();
            this.cbxUnaryOperator = new System.Windows.Forms.ComboBox();
            this.txtUnaryOperator = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.rSugeno = new System.Windows.Forms.RadioButton();
            this.rTsukamoto = new System.Windows.Forms.RadioButton();
            this.rMamdani = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.tabEdit = new System.Windows.Forms.TabControl();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.tabPage10 = new System.Windows.Forms.TabPage();
            this.ppgSystem = new System.Windows.Forms.PropertyGrid();
            this.txtEditor = new System.Windows.Forms.Label();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.tabSelect = new System.Windows.Forms.TabControl();
            this.tpFS = new System.Windows.Forms.TabPage();
            this.tabFunction = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbRight = new System.Windows.Forms.ComboBox();
            this.checkBi = new System.Windows.Forms.CheckedListBox();
            this.txtBinaryOperator = new System.Windows.Forms.Label();
            this.btnCreateBiOperatedFS = new System.Windows.Forms.Button();
            this.leftFS = new System.Windows.Forms.Label();
            this.rightFS = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tpIfThen = new System.Windows.Forms.TabPage();
            this.resultFS = new System.Windows.Forms.Label();
            this.btnTest = new System.Windows.Forms.Button();
            this.rScale = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.rCut = new System.Windows.Forms.RadioButton();
            this.DeleteTip = new System.Windows.Forms.Label();
            this.RuleTip = new System.Windows.Forms.Label();
            this.dgvRules = new System.Windows.Forms.DataGridView();
            this.btnInference = new System.Windows.Forms.Button();
            this.btnAddRule = new System.Windows.Forms.Button();
            this.dgvConditions = new System.Windows.Forms.DataGridView();
            this.tpOutput = new System.Windows.Forms.TabPage();
            this.clbEquation = new System.Windows.Forms.CheckedListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAddEquation = new System.Windows.Forms.Button();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.InferenceChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.teeChart = new Steema.TeeChart.TChart();
            this.surface = new Steema.TeeChart.Styles.Surface();
            this.chartController1 = new Steema.TeeChart.ChartController();
            this.rCOA = new System.Windows.Forms.RadioButton();
            this.btnCrispInCrispOutInferencing = new System.Windows.Forms.Button();
            this.rLOM = new System.Windows.Forms.RadioButton();
            this.rBOA = new System.Windows.Forms.RadioButton();
            this.rMOM = new System.Windows.Forms.RadioButton();
            this.rSOM = new System.Windows.Forms.RadioButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.btnSaveFile = new System.Windows.Forms.ToolStripButton();
            this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
            this.dlgSave = new System.Windows.Forms.SaveFileDialog();
            this.txtSystem = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tabEdit.SuspendLayout();
            this.tabPage9.SuspendLayout();
            this.tabPage10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.tabSelect.SuspendLayout();
            this.tpFS.SuspendLayout();
            this.tabFunction.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tpIfThen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRules)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConditions)).BeginInit();
            this.tpOutput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).BeginInit();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InferenceChart)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.txtSystem.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCreateUniverse
            // 
            this.btnCreateUniverse.BackColor = System.Drawing.Color.LightCyan;
            this.btnCreateUniverse.FlatAppearance.BorderColor = System.Drawing.Color.PaleTurquoise;
            this.btnCreateUniverse.FlatAppearance.BorderSize = 2;
            this.btnCreateUniverse.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnCreateUniverse.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnCreateUniverse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateUniverse.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnCreateUniverse.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCreateUniverse.Location = new System.Drawing.Point(42, 68);
            this.btnCreateUniverse.Name = "btnCreateUniverse";
            this.btnCreateUniverse.Size = new System.Drawing.Size(121, 105);
            this.btnCreateUniverse.TabIndex = 0;
            this.btnCreateUniverse.Text = "Add Universe";
            this.btnCreateUniverse.UseVisualStyleBackColor = false;
            this.btnCreateUniverse.Click += new System.EventHandler(this.btnCreateUniverse_Click);
            // 
            // theTree
            // 
            this.theTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.theTree.CheckBoxes = true;
            this.theTree.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.theTree.HotTracking = true;
            this.theTree.Location = new System.Drawing.Point(15, 87);
            this.theTree.Name = "theTree";
            treeNode15.Checked = true;
            treeNode15.Name = "inputNode";
            treeNode15.Text = "Input";
            treeNode15.ToolTipText = "Input";
            treeNode16.Checked = true;
            treeNode16.Name = "outputNode";
            treeNode16.Text = "Output";
            treeNode16.ToolTipText = "Output";
            this.theTree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode15,
            treeNode16});
            this.theTree.ShowNodeToolTips = true;
            this.theTree.Size = new System.Drawing.Size(411, 232);
            this.theTree.TabIndex = 1;
            this.theTree.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.theTree_AfterCheck);
            this.theTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.theTree_AfterSelect);
            this.theTree.MouseDown += new System.Windows.Forms.MouseEventHandler(this.theTree_MouseDown);
            // 
            // theGrid
            // 
            this.theGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.theGrid.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.theGrid.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.theGrid.Location = new System.Drawing.Point(3, 3);
            this.theGrid.Name = "theGrid";
            this.theGrid.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.theGrid.Size = new System.Drawing.Size(400, 495);
            this.theGrid.TabIndex = 3;
            this.theGrid.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.theGrid_PropertyValueChanged);
            // 
            // btnCreateFuzzySet
            // 
            this.btnCreateFuzzySet.BackColor = System.Drawing.Color.LightCyan;
            this.btnCreateFuzzySet.FlatAppearance.BorderColor = System.Drawing.Color.PaleTurquoise;
            this.btnCreateFuzzySet.FlatAppearance.BorderSize = 2;
            this.btnCreateFuzzySet.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnCreateFuzzySet.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnCreateFuzzySet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateFuzzySet.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnCreateFuzzySet.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCreateFuzzySet.Location = new System.Drawing.Point(30, 101);
            this.btnCreateFuzzySet.Margin = new System.Windows.Forms.Padding(0);
            this.btnCreateFuzzySet.Name = "btnCreateFuzzySet";
            this.btnCreateFuzzySet.Size = new System.Drawing.Size(185, 46);
            this.btnCreateFuzzySet.TabIndex = 4;
            this.btnCreateFuzzySet.Text = "Add Fuzzy Set";
            this.btnCreateFuzzySet.UseVisualStyleBackColor = false;
            this.btnCreateFuzzySet.Click += new System.EventHandler(this.btnCreateFuzzySet_Click);
            // 
            // comboFuzzySet
            // 
            this.comboFuzzySet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboFuzzySet.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comboFuzzySet.FormattingEnabled = true;
            this.comboFuzzySet.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.comboFuzzySet.Items.AddRange(new object[] {
            "Triangular Fuzzy Set",
            "Bell Fuzzy Set",
            "Gaussian Fuzzy Set",
            "Sigmoidal Fuzzy Set",
            "LR Fuzzy Set",
            "Pi Fuzzy Set",
            "S Fuzzy Set",
            "Trapezoidal Fuzzy Set",
            "tsGaussian Fuzzy Set",
            "tsPi Fuzzy Set",
            "Z Fuzzy Set",
            "Singleton Fuzzy Set",
            "StepUp Fuzzy Set",
            "StepDown Fuzzy Set"});
            this.comboFuzzySet.Location = new System.Drawing.Point(30, 62);
            this.comboFuzzySet.Name = "comboFuzzySet";
            this.comboFuzzySet.Size = new System.Drawing.Size(330, 33);
            this.comboFuzzySet.TabIndex = 5;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.LightCyan;
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.PaleTurquoise;
            this.btnDelete.FlatAppearance.BorderSize = 2;
            this.btnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnDelete.Location = new System.Drawing.Point(47, 32);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(99, 102);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // tabCharts
            // 
            this.tabCharts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCharts.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabCharts.Location = new System.Drawing.Point(0, 0);
            this.tabCharts.Name = "tabCharts";
            this.tabCharts.SelectedIndex = 0;
            this.tabCharts.Size = new System.Drawing.Size(582, 585);
            this.tabCharts.TabIndex = 7;
            // 
            // txtSelectFuzzySet
            // 
            this.txtSelectFuzzySet.AutoSize = true;
            this.txtSelectFuzzySet.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtSelectFuzzySet.Location = new System.Drawing.Point(25, 28);
            this.txtSelectFuzzySet.Name = "txtSelectFuzzySet";
            this.txtSelectFuzzySet.Size = new System.Drawing.Size(174, 25);
            this.txtSelectFuzzySet.TabIndex = 8;
            this.txtSelectFuzzySet.Text = "Type of Fuzzy Set";
            // 
            // btnCreateOperatedFS
            // 
            this.btnCreateOperatedFS.BackColor = System.Drawing.Color.LightCyan;
            this.btnCreateOperatedFS.FlatAppearance.BorderColor = System.Drawing.Color.PaleTurquoise;
            this.btnCreateOperatedFS.FlatAppearance.BorderSize = 2;
            this.btnCreateOperatedFS.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnCreateOperatedFS.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnCreateOperatedFS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateOperatedFS.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnCreateOperatedFS.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCreateOperatedFS.Location = new System.Drawing.Point(29, 102);
            this.btnCreateOperatedFS.Name = "btnCreateOperatedFS";
            this.btnCreateOperatedFS.Size = new System.Drawing.Size(258, 42);
            this.btnCreateOperatedFS.TabIndex = 9;
            this.btnCreateOperatedFS.Text = "Add Operated Fuzzy Set";
            this.btnCreateOperatedFS.UseVisualStyleBackColor = false;
            this.btnCreateOperatedFS.Click += new System.EventHandler(this.btnCreateOperatedFS_Click);
            // 
            // cbxUnaryOperator
            // 
            this.cbxUnaryOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxUnaryOperator.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbxUnaryOperator.FormattingEnabled = true;
            this.cbxUnaryOperator.Items.AddRange(new object[] {
            "Negate",
            "Value-Cut",
            "More / Less( DIL )",
            "Very  ( CON )",
            "Extremely",
            "INT",
            "DIM",
            "DIL",
            "COM",
            "Seguno\'s complement",
            "Yager\'s complement"});
            this.cbxUnaryOperator.Location = new System.Drawing.Point(29, 63);
            this.cbxUnaryOperator.Name = "cbxUnaryOperator";
            this.cbxUnaryOperator.Size = new System.Drawing.Size(258, 33);
            this.cbxUnaryOperator.TabIndex = 10;
            // 
            // txtUnaryOperator
            // 
            this.txtUnaryOperator.AutoSize = true;
            this.txtUnaryOperator.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtUnaryOperator.Location = new System.Drawing.Point(24, 28);
            this.txtUnaryOperator.Name = "txtUnaryOperator";
            this.txtUnaryOperator.Size = new System.Drawing.Size(163, 25);
            this.txtUnaryOperator.TabIndex = 11;
            this.txtUnaryOperator.Text = "Unary Operator";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 42);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.AliceBlue;
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.AliceBlue;
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(1584, 911);
            this.splitContainer1.SplitterDistance = 439;
            this.splitContainer1.TabIndex = 14;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BackColor = System.Drawing.Color.AliceBlue;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.Color.AliceBlue;
            this.splitContainer2.Panel1.Controls.Add(this.txtSystem);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            this.splitContainer2.Panel1.Controls.Add(this.theTree);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.Color.AliceBlue;
            this.splitContainer2.Panel2.Controls.Add(this.tabEdit);
            this.splitContainer2.Panel2.Controls.Add(this.txtEditor);
            this.splitContainer2.Size = new System.Drawing.Size(439, 911);
            this.splitContainer2.SplitterDistance = 322;
            this.splitContainer2.TabIndex = 0;
            // 
            // rSugeno
            // 
            this.rSugeno.AutoSize = true;
            this.rSugeno.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rSugeno.Location = new System.Drawing.Point(123, 26);
            this.rSugeno.Name = "rSugeno";
            this.rSugeno.Size = new System.Drawing.Size(95, 28);
            this.rSugeno.TabIndex = 29;
            this.rSugeno.TabStop = true;
            this.rSugeno.Text = "Sugeno";
            this.rSugeno.UseVisualStyleBackColor = true;
            this.rSugeno.CheckedChanged += new System.EventHandler(this.rSystem_CheckedChanged);
            // 
            // rTsukamoto
            // 
            this.rTsukamoto.AutoSize = true;
            this.rTsukamoto.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rTsukamoto.Location = new System.Drawing.Point(223, 26);
            this.rTsukamoto.Name = "rTsukamoto";
            this.rTsukamoto.Size = new System.Drawing.Size(125, 28);
            this.rTsukamoto.TabIndex = 28;
            this.rTsukamoto.TabStop = true;
            this.rTsukamoto.Text = "Tsukamoto";
            this.rTsukamoto.UseVisualStyleBackColor = true;
            this.rTsukamoto.CheckedChanged += new System.EventHandler(this.rSystem_CheckedChanged);
            // 
            // rMamdani
            // 
            this.rMamdani.AutoSize = true;
            this.rMamdani.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rMamdani.Location = new System.Drawing.Point(6, 26);
            this.rMamdani.Name = "rMamdani";
            this.rMamdani.Size = new System.Drawing.Size(111, 28);
            this.rMamdani.TabIndex = 27;
            this.rMamdani.TabStop = true;
            this.rMamdani.Text = "Mamdani";
            this.rMamdani.UseVisualStyleBackColor = true;
            this.rMamdani.CheckedChanged += new System.EventHandler(this.rSystem_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(12, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "Fuzzy Sets";
            // 
            // tabEdit
            // 
            this.tabEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabEdit.Controls.Add(this.tabPage9);
            this.tabEdit.Controls.Add(this.tabPage10);
            this.tabEdit.Font = new System.Drawing.Font("微軟正黑體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabEdit.Location = new System.Drawing.Point(12, 45);
            this.tabEdit.Name = "tabEdit";
            this.tabEdit.SelectedIndex = 0;
            this.tabEdit.Size = new System.Drawing.Size(414, 537);
            this.tabEdit.TabIndex = 5;
            // 
            // tabPage9
            // 
            this.tabPage9.Controls.Add(this.theGrid);
            this.tabPage9.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabPage9.Location = new System.Drawing.Point(4, 32);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage9.Size = new System.Drawing.Size(406, 501);
            this.tabPage9.TabIndex = 0;
            this.tabPage9.Text = "Universe/ FuzzySet";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // tabPage10
            // 
            this.tabPage10.Controls.Add(this.ppgSystem);
            this.tabPage10.Location = new System.Drawing.Point(4, 32);
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage10.Size = new System.Drawing.Size(406, 501);
            this.tabPage10.TabIndex = 1;
            this.tabPage10.Text = "System";
            this.tabPage10.UseVisualStyleBackColor = true;
            // 
            // ppgSystem
            // 
            this.ppgSystem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ppgSystem.Location = new System.Drawing.Point(3, 3);
            this.ppgSystem.Name = "ppgSystem";
            this.ppgSystem.Size = new System.Drawing.Size(400, 495);
            this.ppgSystem.TabIndex = 0;
            // 
            // txtEditor
            // 
            this.txtEditor.AutoSize = true;
            this.txtEditor.Font = new System.Drawing.Font("微軟正黑體", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtEditor.Location = new System.Drawing.Point(12, 18);
            this.txtEditor.Name = "txtEditor";
            this.txtEditor.Size = new System.Drawing.Size(279, 24);
            this.txtEditor.TabIndex = 4;
            this.txtEditor.Text = "Universe and Fuzzy Set Editor";
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.BackColor = System.Drawing.Color.AliceBlue;
            this.splitContainer3.Panel1.Controls.Add(this.tabSelect);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.BackColor = System.Drawing.Color.AliceBlue;
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer3.Size = new System.Drawing.Size(1141, 911);
            this.splitContainer3.SplitterDistance = 322;
            this.splitContainer3.TabIndex = 23;
            // 
            // tabSelect
            // 
            this.tabSelect.Controls.Add(this.tpFS);
            this.tabSelect.Controls.Add(this.tpIfThen);
            this.tabSelect.Controls.Add(this.tpOutput);
            this.tabSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabSelect.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabSelect.ItemSize = new System.Drawing.Size(100, 30);
            this.tabSelect.Location = new System.Drawing.Point(0, 0);
            this.tabSelect.Margin = new System.Windows.Forms.Padding(0);
            this.tabSelect.Name = "tabSelect";
            this.tabSelect.SelectedIndex = 0;
            this.tabSelect.Size = new System.Drawing.Size(1141, 322);
            this.tabSelect.TabIndex = 22;
            this.tabSelect.SelectedIndexChanged += new System.EventHandler(this.tabSelect_SelectedIndexChanged);
            this.tabSelect.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tabSelect_MouseMove);
            // 
            // tpFS
            // 
            this.tpFS.BackColor = System.Drawing.Color.Transparent;
            this.tpFS.Controls.Add(this.tabFunction);
            this.tpFS.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tpFS.Location = new System.Drawing.Point(4, 34);
            this.tpFS.Name = "tpFS";
            this.tpFS.Padding = new System.Windows.Forms.Padding(3);
            this.tpFS.Size = new System.Drawing.Size(1133, 284);
            this.tpFS.TabIndex = 0;
            this.tpFS.Text = "Fuzzy Sets                            ";
            // 
            // tabFunction
            // 
            this.tabFunction.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabFunction.Controls.Add(this.tabPage1);
            this.tabFunction.Controls.Add(this.tabPage2);
            this.tabFunction.Controls.Add(this.tabPage3);
            this.tabFunction.Controls.Add(this.tabPage4);
            this.tabFunction.Controls.Add(this.tabPage5);
            this.tabFunction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabFunction.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabFunction.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabFunction.ItemSize = new System.Drawing.Size(50, 200);
            this.tabFunction.Location = new System.Drawing.Point(3, 3);
            this.tabFunction.Margin = new System.Windows.Forms.Padding(1);
            this.tabFunction.Multiline = true;
            this.tabFunction.Name = "tabFunction";
            this.tabFunction.Padding = new System.Drawing.Point(0, 0);
            this.tabFunction.SelectedIndex = 0;
            this.tabFunction.Size = new System.Drawing.Size(1127, 278);
            this.tabFunction.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabFunction.TabIndex = 17;
            this.tabFunction.Click += new System.EventHandler(this.tabFunction_Click);
            this.tabFunction.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tabFunction_MouseMove);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnCreateUniverse);
            this.tabPage1.ForeColor = System.Drawing.Color.Crimson;
            this.tabPage1.Location = new System.Drawing.Point(204, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(919, 270);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Add Universe";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.comboFuzzySet);
            this.tabPage2.Controls.Add(this.btnCreateFuzzySet);
            this.tabPage2.Controls.Add(this.txtSelectFuzzySet);
            this.tabPage2.Location = new System.Drawing.Point(204, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(919, 274);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Add Fuzzy Set";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnCreateOperatedFS);
            this.tabPage3.Controls.Add(this.cbxUnaryOperator);
            this.tabPage3.Controls.Add(this.txtUnaryOperator);
            this.tabPage3.Location = new System.Drawing.Point(204, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(919, 274);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Add Unary Operate";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label4);
            this.tabPage4.Controls.Add(this.label3);
            this.tabPage4.Controls.Add(this.label2);
            this.tabPage4.Controls.Add(this.cbRight);
            this.tabPage4.Controls.Add(this.checkBi);
            this.tabPage4.Controls.Add(this.txtBinaryOperator);
            this.tabPage4.Controls.Add(this.btnCreateBiOperatedFS);
            this.tabPage4.Controls.Add(this.leftFS);
            this.tabPage4.Controls.Add(this.rightFS);
            this.tabPage4.Location = new System.Drawing.Point(204, 4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(919, 274);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Add Binary Operate";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Window;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(693, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 19);
            this.label4.TabIndex = 23;
            this.label4.Text = "Right FS";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Window;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(13, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 19);
            this.label3.TabIndex = 22;
            this.label3.Text = "Left FS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Yellow;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(693, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(207, 19);
            this.label2.TabIndex = 21;
            this.label2.Text = "Select another FS to operate.";
            // 
            // cbRight
            // 
            this.cbRight.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRight.FormattingEnabled = true;
            this.cbRight.Location = new System.Drawing.Point(699, 70);
            this.cbRight.Name = "cbRight";
            this.cbRight.Size = new System.Drawing.Size(201, 30);
            this.cbRight.TabIndex = 20;
            this.cbRight.SelectionChangeCommitted += new System.EventHandler(this.cbRight_SelectionChangeCommitted);
            // 
            // checkBi
            // 
            this.checkBi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkBi.CheckOnClick = true;
            this.checkBi.ColumnWidth = 200;
            this.checkBi.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.checkBi.FormattingEnabled = true;
            this.checkBi.Items.AddRange(new object[] {
            "Intersection(Min T-norm)",
            "Algebraic product",
            "Bounded product",
            "Drastic product",
            "Union(Max S-norm)",
            "Algebraic sum S-norm",
            "Bounded sum S-norm",
            "Drastic sum S-norm"});
            this.checkBi.Location = new System.Drawing.Point(218, 46);
            this.checkBi.MultiColumn = true;
            this.checkBi.Name = "checkBi";
            this.checkBi.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.checkBi.Size = new System.Drawing.Size(421, 88);
            this.checkBi.TabIndex = 19;
            this.checkBi.SelectedIndexChanged += new System.EventHandler(this.checkBi_SelectedIndexChanged);
            // 
            // txtBinaryOperator
            // 
            this.txtBinaryOperator.AutoSize = true;
            this.txtBinaryOperator.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtBinaryOperator.Location = new System.Drawing.Point(12, 13);
            this.txtBinaryOperator.Name = "txtBinaryOperator";
            this.txtBinaryOperator.Size = new System.Drawing.Size(167, 25);
            this.txtBinaryOperator.TabIndex = 14;
            this.txtBinaryOperator.Text = "Binary Operator";
            // 
            // btnCreateBiOperatedFS
            // 
            this.btnCreateBiOperatedFS.BackColor = System.Drawing.Color.LightCyan;
            this.btnCreateBiOperatedFS.FlatAppearance.BorderColor = System.Drawing.Color.PaleTurquoise;
            this.btnCreateBiOperatedFS.FlatAppearance.BorderSize = 2;
            this.btnCreateBiOperatedFS.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnCreateBiOperatedFS.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnCreateBiOperatedFS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateBiOperatedFS.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnCreateBiOperatedFS.Location = new System.Drawing.Point(291, 178);
            this.btnCreateBiOperatedFS.Name = "btnCreateBiOperatedFS";
            this.btnCreateBiOperatedFS.Size = new System.Drawing.Size(258, 48);
            this.btnCreateBiOperatedFS.TabIndex = 16;
            this.btnCreateBiOperatedFS.Text = "Add Operated Fuzzy Set";
            this.btnCreateBiOperatedFS.UseVisualStyleBackColor = false;
            this.btnCreateBiOperatedFS.Click += new System.EventHandler(this.btnCreateBiOperatedFS_Click);
            // 
            // leftFS
            // 
            this.leftFS.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.leftFS.Location = new System.Drawing.Point(12, 75);
            this.leftFS.Name = "leftFS";
            this.leftFS.Size = new System.Drawing.Size(200, 30);
            this.leftFS.TabIndex = 12;
            this.leftFS.Text = "leftFS";
            this.leftFS.Click += new System.EventHandler(this.leftFS_Click);
            // 
            // rightFS
            // 
            this.rightFS.AutoSize = true;
            this.rightFS.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rightFS.Location = new System.Drawing.Point(692, 75);
            this.rightFS.Name = "rightFS";
            this.rightFS.Size = new System.Drawing.Size(78, 25);
            this.rightFS.TabIndex = 13;
            this.rightFS.Text = "rightFS";
            this.rightFS.Visible = false;
            this.rightFS.Click += new System.EventHandler(this.rightFS_Click);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.btnDelete);
            this.tabPage5.Location = new System.Drawing.Point(204, 4);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(919, 274);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Delete";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tpIfThen
            // 
            this.tpIfThen.Controls.Add(this.resultFS);
            this.tpIfThen.Controls.Add(this.btnTest);
            this.tpIfThen.Controls.Add(this.rScale);
            this.tpIfThen.Controls.Add(this.label7);
            this.tpIfThen.Controls.Add(this.label6);
            this.tpIfThen.Controls.Add(this.rCut);
            this.tpIfThen.Controls.Add(this.DeleteTip);
            this.tpIfThen.Controls.Add(this.RuleTip);
            this.tpIfThen.Controls.Add(this.dgvRules);
            this.tpIfThen.Controls.Add(this.btnInference);
            this.tpIfThen.Controls.Add(this.btnAddRule);
            this.tpIfThen.Controls.Add(this.dgvConditions);
            this.tpIfThen.Font = new System.Drawing.Font("微軟正黑體", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tpIfThen.Location = new System.Drawing.Point(4, 34);
            this.tpIfThen.Name = "tpIfThen";
            this.tpIfThen.Padding = new System.Windows.Forms.Padding(3);
            this.tpIfThen.Size = new System.Drawing.Size(1133, 284);
            this.tpIfThen.TabIndex = 1;
            this.tpIfThen.Text = "If-Then Rules                  ";
            this.tpIfThen.UseVisualStyleBackColor = true;
            // 
            // resultFS
            // 
            this.resultFS.AutoSize = true;
            this.resultFS.Location = new System.Drawing.Point(6, 184);
            this.resultFS.Name = "resultFS";
            this.resultFS.Size = new System.Drawing.Size(112, 24);
            this.resultFS.TabIndex = 31;
            this.resultFS.Text = "resultingFS";
            this.resultFS.Visible = false;
            // 
            // btnTest
            // 
            this.btnTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTest.BackColor = System.Drawing.Color.LightCyan;
            this.btnTest.FlatAppearance.BorderColor = System.Drawing.Color.PaleTurquoise;
            this.btnTest.FlatAppearance.BorderSize = 2;
            this.btnTest.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnTest.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTest.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnTest.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnTest.Location = new System.Drawing.Point(10, 229);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(123, 34);
            this.btnTest.TabIndex = 30;
            this.btnTest.Text = "Insert car rules";
            this.btnTest.UseVisualStyleBackColor = false;
            this.btnTest.Visible = false;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // rScale
            // 
            this.rScale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rScale.AutoSize = true;
            this.rScale.Location = new System.Drawing.Point(1048, 131);
            this.rScale.Name = "rScale";
            this.rScale.Size = new System.Drawing.Size(79, 28);
            this.rScale.TabIndex = 29;
            this.rScale.TabStop = true;
            this.rScale.Text = "Scale";
            this.rScale.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 135);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 24);
            this.label7.TabIndex = 28;
            this.label7.Text = "Condition";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 24);
            this.label6.TabIndex = 27;
            this.label6.Text = "Rules";
            // 
            // rCut
            // 
            this.rCut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rCut.AutoSize = true;
            this.rCut.Checked = true;
            this.rCut.Location = new System.Drawing.Point(979, 131);
            this.rCut.Name = "rCut";
            this.rCut.Size = new System.Drawing.Size(63, 28);
            this.rCut.TabIndex = 26;
            this.rCut.TabStop = true;
            this.rCut.Text = "Cut";
            this.rCut.UseVisualStyleBackColor = true;
            this.rCut.CheckedChanged += new System.EventHandler(this.rCut_CheckedChanged);
            // 
            // DeleteTip
            // 
            this.DeleteTip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DeleteTip.AutoSize = true;
            this.DeleteTip.BackColor = System.Drawing.Color.Yellow;
            this.DeleteTip.Font = new System.Drawing.Font("微軟正黑體 Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.DeleteTip.Location = new System.Drawing.Point(152, 239);
            this.DeleteTip.Name = "DeleteTip";
            this.DeleteTip.Size = new System.Drawing.Size(287, 19);
            this.DeleteTip.TabIndex = 25;
            this.DeleteTip.Text = "刪除列: 在表格中按右鍵即可刪除選擇的列";
            // 
            // RuleTip
            // 
            this.RuleTip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RuleTip.AutoSize = true;
            this.RuleTip.BackColor = System.Drawing.Color.Yellow;
            this.RuleTip.Font = new System.Drawing.Font("微軟正黑體 Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.RuleTip.Location = new System.Drawing.Point(152, 213);
            this.RuleTip.Name = "RuleTip";
            this.RuleTip.Size = new System.Drawing.Size(314, 19);
            this.RuleTip.TabIndex = 24;
            this.RuleTip.Text = "Create at least 1 input and 1 output Fuzzy set.";
            // 
            // dgvRules
            // 
            this.dgvRules.AllowUserToAddRows = false;
            this.dgvRules.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRules.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvRules.BackgroundColor = System.Drawing.Color.Lavender;
            this.dgvRules.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle29.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle29.Font = new System.Drawing.Font("微軟正黑體", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle29.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle29.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle29.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle29.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRules.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle29;
            this.dgvRules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle30.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle30.Font = new System.Drawing.Font("微軟正黑體", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle30.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle30.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle30.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle30.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRules.DefaultCellStyle = dataGridViewCellStyle30;
            this.dgvRules.Location = new System.Drawing.Point(280, 6);
            this.dgvRules.Name = "dgvRules";
            this.dgvRules.ReadOnly = true;
            this.dgvRules.RowHeadersWidth = 50;
            this.dgvRules.RowTemplate.Height = 27;
            this.dgvRules.Size = new System.Drawing.Size(633, 79);
            this.dgvRules.TabIndex = 23;
            this.dgvRules.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRules_CellValueChanged);
            this.dgvRules.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgv_MouseDown);
            // 
            // btnInference
            // 
            this.btnInference.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInference.BackColor = System.Drawing.Color.LightCyan;
            this.btnInference.FlatAppearance.BorderColor = System.Drawing.Color.PaleTurquoise;
            this.btnInference.FlatAppearance.BorderSize = 2;
            this.btnInference.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnInference.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnInference.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInference.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnInference.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnInference.Location = new System.Drawing.Point(967, 160);
            this.btnInference.Name = "btnInference";
            this.btnInference.Size = new System.Drawing.Size(158, 68);
            this.btnInference.TabIndex = 20;
            this.btnInference.Text = "Inferece";
            this.btnInference.UseVisualStyleBackColor = false;
            this.btnInference.Click += new System.EventHandler(this.btnInference_Click);
            // 
            // btnAddRule
            // 
            this.btnAddRule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddRule.BackColor = System.Drawing.Color.LightCyan;
            this.btnAddRule.FlatAppearance.BorderColor = System.Drawing.Color.PaleTurquoise;
            this.btnAddRule.FlatAppearance.BorderSize = 2;
            this.btnAddRule.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnAddRule.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnAddRule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddRule.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnAddRule.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAddRule.Location = new System.Drawing.Point(967, 26);
            this.btnAddRule.Name = "btnAddRule";
            this.btnAddRule.Size = new System.Drawing.Size(158, 77);
            this.btnAddRule.TabIndex = 19;
            this.btnAddRule.Text = "Add Rules";
            this.btnAddRule.UseVisualStyleBackColor = false;
            this.btnAddRule.Click += new System.EventHandler(this.btnAddRule_Click);
            // 
            // dgvConditions
            // 
            this.dgvConditions.AllowUserToAddRows = false;
            this.dgvConditions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvConditions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvConditions.BackgroundColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle31.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle31.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle31.Font = new System.Drawing.Font("微軟正黑體", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle31.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle31.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle31.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle31.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvConditions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle31;
            this.dgvConditions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle32.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle32.Font = new System.Drawing.Font("微軟正黑體", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle32.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle32.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle32.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle32.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvConditions.DefaultCellStyle = dataGridViewCellStyle32;
            this.dgvConditions.Location = new System.Drawing.Point(280, 131);
            this.dgvConditions.Name = "dgvConditions";
            this.dgvConditions.ReadOnly = true;
            this.dgvConditions.RowHeadersWidth = 50;
            this.dgvConditions.RowTemplate.Height = 27;
            this.dgvConditions.Size = new System.Drawing.Size(633, 79);
            this.dgvConditions.TabIndex = 21;
            this.dgvConditions.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvConditions_CellValueChanged);
            this.dgvConditions.Click += new System.EventHandler(this.dgvConditions_Click);
            // 
            // tpOutput
            // 
            this.tpOutput.Controls.Add(this.clbEquation);
            this.tpOutput.Controls.Add(this.label5);
            this.tpOutput.Controls.Add(this.btnAddEquation);
            this.tpOutput.Location = new System.Drawing.Point(4, 34);
            this.tpOutput.Name = "tpOutput";
            this.tpOutput.Size = new System.Drawing.Size(1133, 284);
            this.tpOutput.TabIndex = 2;
            this.tpOutput.Text = "Output Equations";
            this.tpOutput.UseVisualStyleBackColor = true;
            // 
            // clbEquation
            // 
            this.clbEquation.CheckOnClick = true;
            this.clbEquation.FormattingEnabled = true;
            this.clbEquation.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.clbEquation.Items.AddRange(new object[] {
            "1.1: Y=0.1X+6.4",
            "1.2: Y=0.5X+4",
            "1.3: Y=X-2",
            "2.1: Z=-X+Y+1",
            "2.2: Z=-Y+3",
            "2.3: Z=-X+3",
            "2.4: Z=X+Y+2"});
            this.clbEquation.Location = new System.Drawing.Point(91, 66);
            this.clbEquation.Name = "clbEquation";
            this.clbEquation.Size = new System.Drawing.Size(385, 179);
            this.clbEquation.TabIndex = 19;
            this.clbEquation.SelectedIndexChanged += new System.EventHandler(this.clbEquation_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(51, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(154, 22);
            this.label5.TabIndex = 18;
            this.label5.Text = "Sugeno equation";
            // 
            // btnAddEquation
            // 
            this.btnAddEquation.BackColor = System.Drawing.Color.LightCyan;
            this.btnAddEquation.FlatAppearance.BorderColor = System.Drawing.Color.PaleTurquoise;
            this.btnAddEquation.FlatAppearance.BorderSize = 2;
            this.btnAddEquation.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnAddEquation.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnAddEquation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddEquation.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnAddEquation.Location = new System.Drawing.Point(620, 180);
            this.btnAddEquation.Name = "btnAddEquation";
            this.btnAddEquation.Size = new System.Drawing.Size(258, 48);
            this.btnAddEquation.TabIndex = 17;
            this.btnAddEquation.Text = "Add Equation";
            this.btnAddEquation.UseVisualStyleBackColor = false;
            this.btnAddEquation.Click += new System.EventHandler(this.btnAddEquation_Click);
            // 
            // splitContainer4
            // 
            this.splitContainer4.BackColor = System.Drawing.Color.AliceBlue;
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.tabCharts);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.splitContainer5);
            this.splitContainer4.Size = new System.Drawing.Size(1141, 585);
            this.splitContainer4.SplitterDistance = 582;
            this.splitContainer4.TabIndex = 10;
            // 
            // splitContainer5
            // 
            this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer5.Location = new System.Drawing.Point(0, 0);
            this.splitContainer5.Name = "splitContainer5";
            this.splitContainer5.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.Controls.Add(this.InferenceChart);
            this.splitContainer5.Panel1.Controls.Add(this.teeChart);
            this.splitContainer5.Panel1.Controls.Add(this.chartController1);
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.BackColor = System.Drawing.Color.AliceBlue;
            this.splitContainer5.Panel2.Controls.Add(this.rCOA);
            this.splitContainer5.Panel2.Controls.Add(this.btnCrispInCrispOutInferencing);
            this.splitContainer5.Panel2.Controls.Add(this.rLOM);
            this.splitContainer5.Panel2.Controls.Add(this.rBOA);
            this.splitContainer5.Panel2.Controls.Add(this.rMOM);
            this.splitContainer5.Panel2.Controls.Add(this.rSOM);
            this.splitContainer5.Size = new System.Drawing.Size(555, 585);
            this.splitContainer5.SplitterDistance = 499;
            this.splitContainer5.TabIndex = 18;
            // 
            // InferenceChart
            // 
            chartArea8.AxisX.ArrowStyle = System.Windows.Forms.DataVisualization.Charting.AxisArrowStyle.Triangle;
            chartArea8.AxisY.ArrowStyle = System.Windows.Forms.DataVisualization.Charting.AxisArrowStyle.Triangle;
            chartArea8.Name = "InferenceChartArea";
            this.InferenceChart.ChartAreas.Add(chartArea8);
            this.InferenceChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend8.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend8.Name = "lg";
            this.InferenceChart.Legends.Add(legend8);
            this.InferenceChart.Location = new System.Drawing.Point(0, 25);
            this.InferenceChart.Name = "InferenceChart";
            series8.ChartArea = "InferenceChartArea";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series8.Legend = "lg";
            series8.Name = "input-output";
            this.InferenceChart.Series.Add(series8);
            this.InferenceChart.Size = new System.Drawing.Size(555, 474);
            this.InferenceChart.TabIndex = 12;
            this.InferenceChart.Text = "InferenceChart";
            // 
            // teeChart
            // 
            // 
            // 
            // 
            this.teeChart.Aspect.Chart3DPercent = 100;
            this.teeChart.Aspect.Elevation = 312;
            this.teeChart.Aspect.ElevationFloat = 312D;
            this.teeChart.Aspect.HorizOffset = -2;
            this.teeChart.Aspect.HorizOffsetFloat = -2D;
            this.teeChart.Aspect.Orthogonal = false;
            this.teeChart.Aspect.Perspective = 71;
            this.teeChart.Aspect.Rotation = 321;
            this.teeChart.Aspect.RotationFloat = 321D;
            this.teeChart.Aspect.VertOffset = -1;
            this.teeChart.Aspect.VertOffsetFloat = -1D;
            this.teeChart.Aspect.Zoom = 64;
            this.teeChart.Aspect.ZoomFloat = 64D;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.teeChart.Axes.Bottom.Title.Caption = "Temperature";
            this.teeChart.Axes.Bottom.Title.Lines = new string[] {
        "Temperature"};
            // 
            // 
            // 
            this.teeChart.Axes.Depth.LabelsAsSeriesTitles = true;
            // 
            // 
            // 
            this.teeChart.Axes.Depth.Ticks.Length = 1;
            // 
            // 
            // 
            this.teeChart.Axes.Depth.Title.Caption = "Pressure";
            this.teeChart.Axes.Depth.Title.Lines = new string[] {
        "Pressure"};
            // 
            // 
            // 
            this.teeChart.Axes.DepthTop.LabelsAsSeriesTitles = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.teeChart.Axes.Left.Title.Caption = "Force(z)";
            this.teeChart.Axes.Left.Title.Lines = new string[] {
        "Force(z)"};
            this.teeChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.teeChart.Location = new System.Drawing.Point(0, 25);
            this.teeChart.Name = "teeChart";
            // 
            // 
            // 
            this.teeChart.Panel.MarginBottom = 3D;
            this.teeChart.Panel.MarginTop = 3D;
            this.teeChart.Series.Add(this.surface);
            this.teeChart.Size = new System.Drawing.Size(555, 474);
            this.teeChart.TabIndex = 11;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.teeChart.Walls.Left.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(224)))));
            // 
            // 
            // 
            this.teeChart.Walls.Left.Brush.Gradient.Transparency = 10;
            // 
            // 
            // 
            // 
            // 
            // 
            this.teeChart.Walls.Left.Shadow.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            // 
            // 
            // 
            this.teeChart.Walls.Left.Shadow.Brush.Gradient.Transparency = 10;
            // 
            // surface
            // 
            // 
            // 
            // 
            this.surface.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(102)))), ((int)(((byte)(163)))));
            this.surface.Color = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(102)))), ((int)(((byte)(163)))));
            this.surface.ColorEach = false;
            this.surface.PaletteMin = 0D;
            this.surface.PaletteStep = 0D;
            this.surface.PaletteStyle = Steema.TeeChart.Styles.PaletteStyles.Pale;
            this.surface.Title = "ResponseSurface";
            // 
            // 
            // 
            this.surface.XValues.DataMember = "X";
            // 
            // 
            // 
            this.surface.YValues.DataMember = "Y";
            // 
            // 
            // 
            this.surface.ZValues.DataMember = "Z";
            // 
            // chartController1
            // 
            this.chartController1.ButtonSize = Steema.TeeChart.ControllerButtonSize.x16;
            this.chartController1.Chart = this.teeChart;
            this.chartController1.LabelValues = true;
            this.chartController1.Location = new System.Drawing.Point(0, 0);
            this.chartController1.Name = "chartController1";
            this.chartController1.Size = new System.Drawing.Size(555, 25);
            this.chartController1.TabIndex = 10;
            this.chartController1.Text = "chartController1";
            // 
            // rCOA
            // 
            this.rCOA.AutoSize = true;
            this.rCOA.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rCOA.Location = new System.Drawing.Point(12, 16);
            this.rCOA.Name = "rCOA";
            this.rCOA.Size = new System.Drawing.Size(68, 26);
            this.rCOA.TabIndex = 13;
            this.rCOA.TabStop = true;
            this.rCOA.Text = "COA";
            this.rCOA.UseVisualStyleBackColor = true;
            // 
            // btnCrispInCrispOutInferencing
            // 
            this.btnCrispInCrispOutInferencing.BackColor = System.Drawing.Color.LightCyan;
            this.btnCrispInCrispOutInferencing.FlatAppearance.BorderColor = System.Drawing.Color.PaleTurquoise;
            this.btnCrispInCrispOutInferencing.FlatAppearance.BorderSize = 2;
            this.btnCrispInCrispOutInferencing.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnCrispInCrispOutInferencing.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnCrispInCrispOutInferencing.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrispInCrispOutInferencing.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnCrispInCrispOutInferencing.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCrispInCrispOutInferencing.Location = new System.Drawing.Point(12, 39);
            this.btnCrispInCrispOutInferencing.Name = "btnCrispInCrispOutInferencing";
            this.btnCrispInCrispOutInferencing.Size = new System.Drawing.Size(310, 36);
            this.btnCrispInCrispOutInferencing.TabIndex = 12;
            this.btnCrispInCrispOutInferencing.Text = "inference all crisp inputs";
            this.btnCrispInCrispOutInferencing.UseVisualStyleBackColor = false;
            this.btnCrispInCrispOutInferencing.Click += new System.EventHandler(this.btnCrispInCrispOutInferencing_Click);
            // 
            // rLOM
            // 
            this.rLOM.AutoSize = true;
            this.rLOM.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rLOM.Location = new System.Drawing.Point(319, 16);
            this.rLOM.Name = "rLOM";
            this.rLOM.Size = new System.Drawing.Size(70, 26);
            this.rLOM.TabIndex = 17;
            this.rLOM.TabStop = true;
            this.rLOM.Text = "LOM";
            this.rLOM.UseVisualStyleBackColor = true;
            // 
            // rBOA
            // 
            this.rBOA.AutoSize = true;
            this.rBOA.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rBOA.Location = new System.Drawing.Point(86, 16);
            this.rBOA.Name = "rBOA";
            this.rBOA.Size = new System.Drawing.Size(67, 26);
            this.rBOA.TabIndex = 14;
            this.rBOA.TabStop = true;
            this.rBOA.Text = "BOA";
            this.rBOA.UseVisualStyleBackColor = true;
            // 
            // rMOM
            // 
            this.rMOM.AutoSize = true;
            this.rMOM.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rMOM.Location = new System.Drawing.Point(236, 16);
            this.rMOM.Name = "rMOM";
            this.rMOM.Size = new System.Drawing.Size(77, 26);
            this.rMOM.TabIndex = 16;
            this.rMOM.TabStop = true;
            this.rMOM.Text = "MOM";
            this.rMOM.UseVisualStyleBackColor = true;
            // 
            // rSOM
            // 
            this.rSOM.AutoSize = true;
            this.rSOM.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rSOM.Location = new System.Drawing.Point(159, 16);
            this.rSOM.Name = "rSOM";
            this.rSOM.Size = new System.Drawing.Size(71, 26);
            this.rSOM.TabIndex = 15;
            this.rSOM.TabStop = true;
            this.rSOM.Text = "SOM";
            this.rSOM.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.MintCream;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(35, 35);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.btnSaveFile});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1584, 42);
            this.toolStrip1.TabIndex = 15;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(135, 39);
            this.toolStripButton1.Text = "Open File";
            this.toolStripButton1.Click += new System.EventHandler(this.btnOpenFile);
            // 
            // btnSaveFile
            // 
            this.btnSaveFile.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnSaveFile.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveFile.Image")));
            this.btnSaveFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveFile.Name = "btnSaveFile";
            this.btnSaveFile.Size = new System.Drawing.Size(127, 39);
            this.btnSaveFile.Text = "Save File";
            this.btnSaveFile.Click += new System.EventHandler(this.btnSaveFile_Click);
            // 
            // dlgOpen
            // 
            this.dlgOpen.DefaultExt = "txt";
            // 
            // dlgSave
            // 
            this.dlgSave.DefaultExt = "txt";
            // 
            // txtSystem
            // 
            this.txtSystem.BackColor = System.Drawing.Color.AliceBlue;
            this.txtSystem.Controls.Add(this.rMamdani);
            this.txtSystem.Controls.Add(this.rSugeno);
            this.txtSystem.Controls.Add(this.rTsukamoto);
            this.txtSystem.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSystem.Font = new System.Drawing.Font("微軟正黑體", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtSystem.Location = new System.Drawing.Point(0, 0);
            this.txtSystem.Name = "txtSystem";
            this.txtSystem.Size = new System.Drawing.Size(439, 54);
            this.txtSystem.TabIndex = 31;
            this.txtSystem.TabStop = false;
            this.txtSystem.Text = "Fuzzy Inference System";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1584, 953);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fuzzy Set Creater";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tabEdit.ResumeLayout(false);
            this.tabPage9.ResumeLayout(false);
            this.tabPage10.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.tabSelect.ResumeLayout(false);
            this.tpFS.ResumeLayout(false);
            this.tabFunction.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tpIfThen.ResumeLayout(false);
            this.tpIfThen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRules)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConditions)).EndInit();
            this.tpOutput.ResumeLayout(false);
            this.tpOutput.PerformLayout();
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel1.PerformLayout();
            this.splitContainer5.Panel2.ResumeLayout(false);
            this.splitContainer5.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
            this.splitContainer5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.InferenceChart)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.txtSystem.ResumeLayout(false);
            this.txtSystem.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreateUniverse;
        private System.Windows.Forms.TreeView theTree;
        private System.Windows.Forms.PropertyGrid theGrid;
        private System.Windows.Forms.Button btnCreateFuzzySet;
        private System.Windows.Forms.ComboBox comboFuzzySet;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TabControl tabCharts;
        private System.Windows.Forms.Label txtSelectFuzzySet;
        private System.Windows.Forms.Button btnCreateOperatedFS;
        private System.Windows.Forms.ComboBox cbxUnaryOperator;
        private System.Windows.Forms.Label txtUnaryOperator;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label rightFS;
        private System.Windows.Forms.Label leftFS;
        private System.Windows.Forms.Label txtBinaryOperator;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Button btnCreateBiOperatedFS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txtEditor;
        private System.Windows.Forms.TabControl tabFunction;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.CheckedListBox checkBi;
        private System.Windows.Forms.ComboBox cbRight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvConditions;
        private System.Windows.Forms.Button btnInference;
        private System.Windows.Forms.Button btnAddRule;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton btnSaveFile;
        private System.Windows.Forms.TabControl tabSelect;
        private System.Windows.Forms.TabPage tpFS;
        private System.Windows.Forms.TabPage tpIfThen;
        private System.Windows.Forms.DataGridView dgvRules;
        private System.Windows.Forms.Label RuleTip;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Label DeleteTip;
        private System.Windows.Forms.TabPage tpOutput;
        private System.Windows.Forms.Button btnAddEquation;
        private System.Windows.Forms.RadioButton rCut;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rSugeno;
        private System.Windows.Forms.RadioButton rTsukamoto;
        private System.Windows.Forms.RadioButton rMamdani;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private Steema.TeeChart.TChart teeChart;
        private Steema.TeeChart.Styles.Surface surface;
        private Steema.TeeChart.ChartController chartController1;
        private System.Windows.Forms.Button btnCrispInCrispOutInferencing;
        private System.Windows.Forms.RadioButton rCOA;
        private System.Windows.Forms.RadioButton rLOM;
        private System.Windows.Forms.RadioButton rMOM;
        private System.Windows.Forms.RadioButton rSOM;
        private System.Windows.Forms.RadioButton rBOA;
        private System.Windows.Forms.CheckedListBox clbEquation;
        private System.Windows.Forms.TabControl tabEdit;
        private System.Windows.Forms.TabPage tabPage9;
        private System.Windows.Forms.TabPage tabPage10;
        private System.Windows.Forms.PropertyGrid ppgSystem;
        private System.Windows.Forms.OpenFileDialog dlgOpen;
        private System.Windows.Forms.SaveFileDialog dlgSave;
        private System.Windows.Forms.RadioButton rScale;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private System.Windows.Forms.DataVisualization.Charting.Chart InferenceChart;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Label resultFS;
        private System.Windows.Forms.GroupBox txtSystem;
    }
}

