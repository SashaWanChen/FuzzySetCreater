using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.IO;
using System.Runtime.ExceptionServices;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml;

namespace FuzzySetCreater
{
    public partial class MainForm : Form
    {    
        object parentUniverse = null;
        object prevFS = null;
        TreeView treeViewWithToolTips;
        List<TabPage> tb = new List<TabPage>();
        TreeNode lastSelectedNode = null;
        int firstOutput = 0, firstInputFS = 0, firstOutputFS = 0;
        bool IsCut = true;
        public MainForm()
        {
            InitializeComponent();
            comboFuzzySet.SelectedIndex = 2;
            cbxUnaryOperator.SelectedIndex = 1;

            btnCreateFuzzySet.Enabled = false;
            btnCreateOperatedFS.Enabled = false;
            btnCreateBiOperatedFS.Enabled = false;
            btnAddRule.Enabled = false;
            btnInference.Enabled = false;
            btnAddEquation.Enabled = false;
            btnCrispInCrispOutInferencing.Enabled = false;

            tabFunction.DrawItem += new DrawItemEventHandler(tabFunction_DrawItem);
            tb.Add(tabPage1);
            tb.Add(tabPage2);
            tb.Add(tabPage3);
            tb.Add(tabPage4);
            tb.Add(tabPage5);
            checkBi.Visible = false;
            rMamdani.Checked = true;

            WindowState = FormWindowState.Maximized;
            rCOA.Checked = true;
            
        }
        public void btnCreateUniverse_Click(object sender, EventArgs e)
        {
            Universe uObj;
            //Add a chart 
            Chart aChart = new Chart();
            uObj = new Universe(aChart);
            //uObj.Title = "XXXX";// set

            //Add a tab
            TabPage aTag = new TabPage(uObj.Title);
            if (firstOutput != 0) tabCharts.TabPages.Insert(dgvRules.Columns.Count - 1,aTag);
            else tabCharts.TabPages.Add(aTag);

            //add the chart to the tab
            aChart.Dock = DockStyle.Fill;
            aTag.Controls.Add(aChart);
            aChart.Visible = true;

            //Add a node to treeview
            TreeNode aNode = new TreeNode(uObj.Title);//get

            //Add tooltips
            treeViewWithToolTips = new TreeView();
            aNode.ToolTipText = uObj.Title;
            treeViewWithToolTips.Nodes.Add(new TreeNode(uObj.Title));
            treeViewWithToolTips.ShowNodeToolTips = true;
            this.Controls.Add(treeViewWithToolTips);

            aNode.Tag = uObj;
            if(theTree.SelectedNode.Text == "Output")
            {
                // add columns to two data grid views
                DataGridViewTextBoxColumn output = new DataGridViewTextBoxColumn();
                output.HeaderText = uObj.Title;
                //output.Name = uObj.Title;
                //dgvRules.Columns.Add(uObj.Title, uObj.Title);
                dgvRules.Columns.Insert(dgvRules.Columns.Count, output );
                firstOutput++;
            }
            else
            {
                // add columns to two data grid views
                if (firstOutput != 0)
                {
                    DataGridViewTextBoxColumn input = new DataGridViewTextBoxColumn();
                    input.HeaderText = uObj.Title;
                    //input.Name = uObj.Title;
                    //dgvRules.Columns.Add(uObj.Title, uObj.Title);
                    dgvRules.Columns.Insert(dgvRules.Columns.Count-1, input);
                }
                else dgvRules.Columns.Add(uObj.Title, uObj.Title);
                dgvConditions.Columns.Add(uObj.Title, uObj.Title);
            }

            if(theTree.SelectedNode.Tag is Universe)
            {
                 theTree.SelectedNode.Parent.Nodes.Add(aNode);
            }
            else if(theTree.SelectedNode.Tag is FuzzySet)
            {
                theTree.SelectedNode.Parent.Parent.Nodes.Add(aNode);
            }
            else
            {
                theTree.SelectedNode.Nodes.Add(aNode);
            }
            aNode.Checked = true;
            theTree.SelectedNode = aNode;
            theTree.SelectedNode.Checked = true;
            theTree.Focus();
            if (dgvConditions.Rows.Count < 1 && theTree.Nodes[0].GetNodeCount(true) >0) dgvConditions.Rows.Add();
        }
        private void chart_MouseClick(object sender, EventArgs e)
        {
            if (theTree.SelectedNode.Tag is FuzzySet && ((FuzzySet)theTree.SelectedNode.Tag).ShowSeries == true)
                ((FuzzySet)theTree.SelectedNode.Tag).ShowSeries = false;
            else if (theTree.SelectedNode.Tag is FuzzySet && ((FuzzySet)theTree.SelectedNode.Tag).ShowSeries == false)
                ((FuzzySet)theTree.SelectedNode.Tag).ShowSeries = true;
            else return;
        }
        private void chart_MouseDoubleClick(object sender, EventArgs e)
        {
            if (theTree.SelectedNode.Tag is FuzzySet)
            {
                ((FuzzySet)theTree.SelectedNode.Tag).ShowSeries = true;
                ((FuzzySet)theTree.SelectedNode.Tag).UnSelectSeries();
            }
        }
        private void theTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            theGrid.SelectedObject = theTree.SelectedNode.Tag;
            //keep selected node focus 
            e.Node.BackColor = SystemColors.Highlight;
            e.Node.ForeColor = SystemColors.HighlightText;
            //no node situation
            if (lastSelectedNode != null)
            {
                // Deselect old node
                lastSelectedNode.BackColor = SystemColors.Window;
                lastSelectedNode.ForeColor = SystemColors.WindowText;
            }
            lastSelectedNode = e.Node;

            if(theTree.SelectedNode == theTree.Nodes[1].FirstNode)
                btnAddEquation.Enabled = true;
            else btnAddEquation.Enabled = false;
            if (theTree.SelectedNode.Tag is Universe) 
            { 
                btnCreateFuzzySet.Enabled = true;
                tabFunction.TabPages.Clear();
                if (theTree.SelectedNode.Parent.Text == "Output" && firstOutput > 0 && !rSugeno.Checked)
                {
                    
                    tabFunction.TabPages.Add(tb[1]);
                    tabFunction.TabPages.Add(tb[4]);
                    tabFunction.SelectTab(0);
                    tabCharts.SelectTab(dgvRules.Columns.Count-1);
                }
                else if (theTree.SelectedNode.Parent.Text == "Output" && firstOutput > 0 && rSugeno.Checked)
                {

                    //tabFunction.TabPages.Add(tb[1]);
                    tabFunction.TabPages.Add(tb[4]);
                    tabFunction.SelectTab(0);
                    tabCharts.SelectTab(dgvRules.Columns.Count - 1);
                }
                else
                {
                    tabFunction.TabPages.Add(tb[0]);
                    tabFunction.TabPages.Add(tb[1]);
                    tabFunction.TabPages.Add(tb[4]);
                    tabFunction.SelectTab(1);
                    tabCharts.SelectTab(theTree.SelectedNode.Index);
                }
            } 
            else if(theTree.SelectedNode.Tag is FuzzySet | theTree.SelectedNode.Tag is int)
            {
                btnCreateFuzzySet.Enabled = false;
                btnCreateOperatedFS.Enabled = true;
                if (theTree.SelectedNode.Tag is FuzzySet)
                {
                    if(prevFS!= null && ((FuzzySet)prevFS).ShowSeries == true) ((FuzzySet)prevFS).UnSelectSeries();
                    if(((FuzzySet)theTree.SelectedNode.Tag).ShowSeries == true)
                        ((FuzzySet)theTree.SelectedNode.Tag).SelectSeries();
                    prevFS = theTree.SelectedNode.Tag;
                }
                tabFunction.TabPages.Clear();
                if (theTree.SelectedNode.Parent.Parent.Text == "Output" && firstOutput > 0)
                {                 
                    tabCharts.SelectTab(dgvRules.Columns.Count-1);
                }
                else
                {
                    tabFunction.TabPages.Add(tb[0]);
                    tabCharts.SelectTab(theTree.SelectedNode.Parent.Index);
                }
                tabFunction.TabPages.Add(tb[2]);
                tabFunction.TabPages.Add(tb[3]);
                tabFunction.TabPages.Add(tb[4]);
                tabFunction.SelectTab(1);
                leftFS_Click(sender, e);
                cbRight.Items.Clear();
                //add FSs which in the same universe to combobox
                foreach (TreeNode child in theTree.SelectedNode.Parent.Nodes)
                {
                    cbRight.Items.Add(child.Text);
                }
                // add FS to the cell of rule and inference
                //inference
                if (dgvRules.CurrentCell == null && tabSelect.SelectedIndex == 1)
                {
                    DataGridViewCell theCell;
                    if (dgvConditions.CurrentCell == null)
                    {
                        theCell = dgvConditions.Rows[0].Cells[0];
                        dgvConditions.CurrentCell = theCell;
                    }
                    else
                        theCell = dgvConditions.Rows[dgvConditions.CurrentCell.RowIndex].Cells[dgvConditions.CurrentCell.ColumnIndex];

                    if (theCell.OwningColumn.HeaderText == theTree.SelectedNode.Parent.Text)
                    {
                        theCell.Value = theTree.SelectedNode.Tag;
                    }
                    else
                    {
                        const string caption = "Error";
                        MessageBox.Show($"Select the FS within {theCell.OwningColumn.HeaderText}", caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }

                //rule
                if (dgvRules.CurrentCell != null && tabSelect.SelectedIndex == 1)
                {
                    DataGridViewCell theCell = dgvRules.Rows[dgvRules.CurrentCell.RowIndex].Cells[dgvRules.CurrentCell.ColumnIndex];

                    if (theCell.OwningColumn.HeaderText == theTree.SelectedNode.Parent.Text)
                    {
                        if (rTsukamoto.Checked && (dgvRules.CurrentCell.ColumnIndex == dgvRules.Columns.Count-1))
                        {
                            if(!((FuzzySet)theTree.SelectedNode.Tag).IsMonotonic)
                                MessageBox.Show("Select a Monotonic Fuzzy set as output.");

                        }
                        theCell.Value = theTree.SelectedNode.Tag;
                        //open when two universe .SelectTab
                        btnCrispInCrispOutInferencing.Enabled = true;
                        
                    }
                    else
                    {
                        const string caption = "Error";
                        MessageBox.Show($"Select the FS within {theCell.OwningColumn.HeaderText}", caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                
            }
            else
            {
                if (theTree.SelectedNode.Text == "Output" && firstOutput > 0)
                {
                    tabFunction.TabPages.Clear();
                }
                else
                { 
                    tabFunction.TabPages.Clear();
                    tabFunction.TabPages.Add(tb[0]);
                }
            }

        }
        private void btnCreateFuzzySet_Click(object sender, EventArgs e)
        {
            FuzzySet aFS = null;
            Universe selectU;

            if (theTree.SelectedNode.Tag is Universe & comboFuzzySet.SelectedIndex != -1)
            {
                //obj cast universe
                selectU = (Universe)theTree.SelectedNode.Tag;

                if (theTree.SelectedNode.Parent.Text != "Output") 
                {
                    tabCharts.SelectTab(theTree.SelectedNode.Index);

                }
                else
                {
                    firstOutputFS++;
                }
                // add a subnode to selected node
                TreeNode cNode = new TreeNode();

                theTree.SelectedNode.Nodes.Add(cNode);

                switch (comboFuzzySet.SelectedIndex)
                {
                    case 0: // Triangular
                        aFS = new TriangularFuzzySet(selectU);
                        //name the node
                        cNode.Text = aFS.Title;
                        //connect tag and node
                        cNode.Tag = aFS;
                        aFS.ShowSeries = true;
                        break;
                    case 1: // Bell
                        aFS = new BellFuzzySet(selectU);
                        //name the node
                        cNode.Text = aFS.Title;
                        //connect tag and node
                        cNode.Tag = aFS;
                        aFS.ShowSeries = true;
                        break;
                    case 2: // Gaussian
                        aFS = new GaussianFuzzySet(selectU);
                        //name the node
                        cNode.Text = aFS.Title;
                        //connect tag and node
                        cNode.Tag = aFS;
                        aFS.ShowSeries = true;
                        break;
                    case 3: // Sigmoidal
                        aFS = new SigmoidalFuzzySet(selectU);
                        //name the node
                        cNode.Text = aFS.Title;
                        //connect tag and node
                        cNode.Tag = aFS;
                        aFS.ShowSeries = true;
                        break;
                    case 4: // LRFuzzySet
                        aFS = new LRFuzzySet(selectU);
                        //name the node
                        cNode.Text = aFS.Title;
                        //connect tag and node
                        cNode.Tag = aFS;
                        aFS.ShowSeries = true;
                        break;
                    case 5: // PiFuzzySet
                        aFS = new PiFuzzySet(selectU);
                        //name the node
                        cNode.Text = aFS.Title;
                        //connect tag and node
                        cNode.Tag = aFS;
                        aFS.ShowSeries = true;
                        break;
                    case 6: // SFuzzySet
                        aFS = new SFuzzySet(selectU);
                        //name the node
                        cNode.Text = aFS.Title;
                        //connect tag and node
                        cNode.Tag = aFS;
                        aFS.ShowSeries = true;
                        break;
                    case 7: // TrapezoidalFuzzySet
                        aFS = new TrapezoidalFuzzySet(selectU);
                        //name the node
                        cNode.Text = aFS.Title;
                        //connect tag and node
                        cNode.Tag = aFS;
                        aFS.ShowSeries = true;
                        break;
                    case 8: // tsGaussianFuzzySet
                        aFS = new tsGaussianFuzzySet(selectU);
                        //name the node
                        cNode.Text = aFS.Title;
                        //connect tag and node
                        cNode.Tag = aFS;
                        aFS.ShowSeries = true;
                        break;
                    case 9: // tsPiFuzzySet
                        aFS = new tsPiFuzzySet(selectU);
                        //name the node
                        cNode.Text = aFS.Title;
                        //connect tag and node
                        cNode.Tag = aFS;
                        aFS.ShowSeries = true;
                        break;
                    case 10: // ZFuzzySet
                        aFS = new ZFuzzySet(selectU);
                        //name the node
                        cNode.Text = aFS.Title;
                        //connect tag and node
                        cNode.Tag = aFS;
                        aFS.ShowSeries = true;
                        break;
                    case 11: // SingletonFuzzySet
                        aFS = new SingletonFuzzySet(selectU);
                        //name the node
                        cNode.Text = aFS.Title;
                        //connect tag and node
                        cNode.Tag = aFS;
                        aFS.ShowSeries = true;
                        break;
                    case 12: // StepUpFuzzySet
                        aFS = new StepUpFuzzySet(selectU);
                        //name the node
                        cNode.Text = aFS.Title;
                        //connect tag and node
                        cNode.Tag = aFS;
                        aFS.ShowSeries = true;
                        break;
                    case 13: // StepDownFuzzySet
                        aFS = new StepDownFuzzySet(selectU);
                        //name the node
                        cNode.Text = aFS.Title;
                        //connect tag and node
                        cNode.Tag = aFS;
                        aFS.ShowSeries = true;
                        break;
                }

                //Add tooltips
                treeViewWithToolTips = new TreeView();
                cNode.ToolTipText = aFS.Title;
                treeViewWithToolTips.Nodes.Add(new TreeNode(aFS.Title));
                treeViewWithToolTips.ShowNodeToolTips = true;
                this.Controls.Add(treeViewWithToolTips);

                cNode.Checked = true;

                theTree.ExpandAll();
                //theTree.SelectedNode = cNode;
                theTree.Focus();
            }
            else if (comboFuzzySet.SelectedIndex == -1)
            {
                MessageBox.Show("Select an fuzzy set first!");
            }
            else
            {
                MessageBox.Show("Select an universe first!");
            }

            if (theTree.SelectedNode.Parent.Text != "Output")
            {
                firstInputFS = 0;
                foreach (TreeNode child in theTree.SelectedNode.Parent.Nodes)
                {
                    int c = child.Nodes.Count;
                    if (c > 0) firstInputFS++;
                }
            }
            if ((firstInputFS + firstOutputFS) == dgvRules.Columns.Count & firstOutputFS != 0)
            {
                RuleTip.Visible = false;
                btnAddRule.Enabled = true;
                //btnInference.Enabled = true;
            }
        }
        private void theGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            GridItem gi = e.ChangedItem;
            object ov = e.OldValue;


            if (theTree.SelectedNode.Tag is Universe)
            {
                theTree.SelectedNode.Text = ((Universe)theTree.SelectedNode.Tag).Title;
            }
            else if (theTree.SelectedNode.Tag is FuzzySet)
            {
                theTree.SelectedNode.Text = ((FuzzySet)theTree.SelectedNode.Tag).Title;
                if(((FuzzySet)theTree.SelectedNode.Tag).ShowSeries == true)
                {
                    ((FuzzySet)theTree.SelectedNode.Tag).ShowSeries = false;
                    ((FuzzySet)theTree.SelectedNode.Tag).ShowSeries = true;
                }
                
                theGrid.Refresh();
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (theTree.SelectedNode.Tag is Universe)
            {
                if (theTree.SelectedNode.Parent.Text == "Output")
                {
                    firstOutput--;
                    dgvRules.Columns.RemoveAt(tabCharts.SelectedIndex);
                }
                else
                {
                    dgvRules.Columns.RemoveAt(tabCharts.SelectedIndex);
                    dgvConditions.Columns.RemoveAt(tabCharts.SelectedIndex);
                }
                tabCharts.TabPages.RemoveAt(tabCharts.SelectedIndex);
                theTree.SelectedNode.Text = ((Universe)theTree.SelectedNode.Tag).Title;
                theGrid.SelectedObject = null;
                theTree.SelectedNode.Remove();
            }
            else if (theTree.SelectedNode.Tag is FuzzySet)
            {
                ((FuzzySet)theTree.SelectedNode.Tag).ShowSeries = false;
                theGrid.SelectedObject = null;
                theTree.SelectedNode.Remove();
            }
        }
        private void btnCreateOperatedFS_Click(object sender, EventArgs e)
        {
            if (theTree.SelectedNode.Tag is FuzzySet & cbxUnaryOperator.SelectedIndex != -1)
            {
                FuzzySet fs = (FuzzySet)theTree.SelectedNode.Tag;
                UnaryFSOperator op;
                FuzzySet newFs = null;

                switch(cbxUnaryOperator.SelectedIndex)
                {
                    case 0:
                        newFs = !fs;
                        //op = new NegateOperator();
                        break;
                    case 1: //value - cut
                        newFs = -fs;
                        //op = new ValueCutOperator();
                            break;
                    case 2: //Dilation
                        op = new DilationOperator();
                        newFs = new UnaryOperatedFuzzySet(fs, op);
                        break;
                    case 3: //Concertration
                        op = new ConcertrationOperator();
                        newFs = new UnaryOperatedFuzzySet(fs, op);
                        break;
                    case 4: //Extremely 
                        op = new ExtremelyOperator();
                        newFs = new UnaryOperatedFuzzySet(fs, op);
                        break;
                    case 5: //IntensificationOperator
                        op = new IntensificationOperator();
                        newFs = new UnaryOperatedFuzzySet(fs, op);
                        break;
                    case 6: // Diminisher
                        op = new DiminisherOperator();
                        newFs = new UnaryOperatedFuzzySet(fs, op);
                        break;
                    case 7: //Dilation
                        op = new DilationOperator();
                        newFs = new UnaryOperatedFuzzySet(fs, op);
                        break;
                    case 8: //Concertration
                        op = new ConcertrationOperator();
                        newFs = new UnaryOperatedFuzzySet(fs, op);
                        break;
                    case 9: //Dilation
                        op = new SugenoOperator();
                        newFs = new UnaryOperatedFuzzySet(fs, op);
                        break;
                    case 10: //Concertration
                        op = new YagerOperator();
                        newFs = new UnaryOperatedFuzzySet(fs, op);
                        break;
                }
                // newFs = new UnaryOperatedFuzzySet(fs, op);
                // add a subnode to selected node
                TreeNode cNode = new TreeNode(newFs.Title);
                //connect tag and node
                cNode.Tag = newFs;
                //Fs to universe
                theTree.SelectedNode.Parent.Nodes.Add(cNode);

                //Add tooltips
                treeViewWithToolTips = new TreeView();
                cNode.ToolTipText = newFs.Title;
                treeViewWithToolTips.Nodes.Add(new TreeNode(newFs.Title));
                treeViewWithToolTips.ShowNodeToolTips = true;
                this.Controls.Add(treeViewWithToolTips);

                newFs.ShowSeries = true;
                theTree.ExpandAll();
                theTree.SelectedNode = theTree.SelectedNode.Parent;
                theTree.Focus();
             }
            else return;
        }
        private void leftFS_Click(object sender, EventArgs e)
        {
            if(theTree.SelectedNode.Tag is FuzzySet)
            {
                leftFS.Tag = theTree.SelectedNode.Tag;
                leftFS.Text = theTree.SelectedNode.Text;
                parentUniverse = theTree.SelectedNode.Parent.Tag;
                if (theTree.SelectedNode.Parent.Tag == parentUniverse && rightFS.Text != "rightFS")
                {
                    //btnCreateBiOperatedFS.Enabled = true;
                    checkBi.Visible = true;
                }
                else
                {
                    parentUniverse = theTree.SelectedNode.Parent.Tag;
                }
            }
            else
            {
                leftFS.Tag = null;
                leftFS.Text = "Click to set Left FS";
            }
        }
        private void rightFS_Click(object sender, EventArgs e)
        {
            if (theTree.SelectedNode.Tag is FuzzySet )
            {
                rightFS.Tag = theTree.SelectedNode.Tag;
                rightFS.Text = theTree.SelectedNode.Text;
                if (theTree.SelectedNode.Parent.Tag == parentUniverse && leftFS.Text != "leftFS")
                {
                    //btnCreateBiOperatedFS.Enabled = true;
                    checkBi.Visible = true;
                }
                else
                { 
                    parentUniverse = theTree.SelectedNode.Parent.Tag;
                }     
            }
            else
            {
                rightFS.Tag = null;
                rightFS.Text = "Click to set Right FS";
            }
        }
        private void btnCreateBiOperatedFS_Click(object sender, EventArgs e)
        {
            foreach (int indexChecked in checkBi.CheckedIndices)
            { 
                FuzzySet Lfs = (FuzzySet)leftFS.Tag;
                FuzzySet Rfs = (FuzzySet)rightFS.Tag;
                BinaryFSOperator op;
                FuzzySet newFs = null;
                if (true)
                {
                    switch (indexChecked)
                    {
                        case 0: //intersection, Minimum T-norm, and
                            newFs = Lfs & Rfs;
                            break;
                        case 1: // Algebraic product
                            op = new Tap();
                            newFs = new BinaryOperatedFuzzySet(Lfs, Rfs, op);
                            break;
                        case 2: // Bounded product
                            op = new Tbp();
                            newFs = new BinaryOperatedFuzzySet(Lfs, Rfs, op);
                            break;
                        case 3: // Drastic product
                            op = new Tdp();
                            newFs = new BinaryOperatedFuzzySet(Lfs, Rfs, op);
                            break;
                        case 4: // union , Maximum S-norm, or
                            newFs = Lfs | Rfs;
                            break;
                        case 5: // Algebraic sum S-norm
                            op = new Sas();
                            newFs = new BinaryOperatedFuzzySet(Lfs, Rfs, op);
                            break;
                        case 6: // Bounded sum S-norm
                            op = new Sbs();
                            newFs = new BinaryOperatedFuzzySet(Lfs, Rfs, op);
                            break;
                        case 7: // Drastic sum S-norm
                            op = new Sds();
                            newFs = new BinaryOperatedFuzzySet(Lfs, Rfs, op);
                            break;
                    }
                    TreeNode cNode = new TreeNode(newFs.Title);
                    //connect tag and node
                    cNode.Tag = newFs;
                    //Fs to universe
                    theTree.SelectedNode.Parent.Nodes.Add(cNode);

                    //Add tooltips
                    treeViewWithToolTips = new TreeView();
                    cNode.ToolTipText = newFs.Title;
                    treeViewWithToolTips.Nodes.Add(new TreeNode(newFs.Title));
                    treeViewWithToolTips.ShowNodeToolTips = true;
                    this.Controls.Add(treeViewWithToolTips);

                    newFs.ShowSeries = true;
                    //theTree.ExpandAll();
                    theTree.SelectedNode = cNode;
                    theTree.SelectedNode.Checked = true;
                    theTree.Focus();
                }
            }
        }
        private void tabFunction_DrawItem(object sender, DrawItemEventArgs e)
        {
                Graphics g = e.Graphics;
                Brush _textBrush;

                // Get the item from the collection.
                TabPage _tabPage = tabFunction.TabPages[e.Index];

                // Get the real bounds for the tab rectangle.
                Rectangle _tabBounds = tabFunction.GetTabRect(e.Index);
                //_tabPage.BorderStyle = NonEventAttribute;
                if (e.State == DrawItemState.Selected)
                {

                    // Draw a different background color, and don't paint a focus rectangle.
                    _textBrush = new SolidBrush(Color.Black);
                    g.FillRectangle(Brushes.AliceBlue, e.Bounds);
                }
                else
                {
                    _textBrush = new System.Drawing.SolidBrush(e.ForeColor);
                    e.DrawBackground();
                }


                // Draw string. Center the text.
                StringFormat _stringFlags = new StringFormat();
                _stringFlags.Alignment = StringAlignment.Center;
                _stringFlags.LineAlignment = StringAlignment.Center;
               g.DrawString(_tabPage.Text, e.Font, _textBrush, _tabBounds, new StringFormat(_stringFlags));
        }
        private void tabFunction_Click(object sender, EventArgs e)
        {
            if (tabFunction.SelectedIndex == 0)
            {
                 btnCreateUniverse.PerformClick();
            }
            else if (theTree.SelectedNode.Tag is Universe && tabFunction.SelectedIndex == 2)
            {
                 btnDelete.PerformClick();
            }
            else if (theTree.SelectedNode.Tag is FuzzySet)
            {
                if (tabFunction.SelectedIndex == 3) btnDelete.PerformClick();
            }
            else return;
            
        }
        private void checkBi_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnCreateBiOperatedFS.Enabled = true;
        }
        private void cbRight_SelectionChangeCommitted(object sender, EventArgs e)
        {
            foreach (TreeNode child in theTree.SelectedNode.Parent.Nodes)
            {
                if (cbRight.SelectedItem.ToString() == child.Text)
                {
                    rightFS.Tag = child.Tag;
                    rightFS.Text = child.Text;
                    checkBi.Visible = true;
                }
                    
            }
        }
        private void btnAddRule_Click(object sender, EventArgs e)
        {
            dgvRules.Rows.Add();
            this.dgvRules.CurrentCell = dgvRules.Rows[dgvRules.Rows.Count-1].Cells[0];
        }
        private void btnInference_Click(object sender, EventArgs e)
        {
            //check cells are all fulled
            bool lack = false;
            for (int c = 0; c < dgvRules.Columns.Count; c++)
            {
                for (int r = 0; r < dgvRules.Rows.Count; r++)
                {
                    if (dgvRules.Rows[r].Cells[c].Value == null)
                    {
                        lack = true;
                    }
                }
            }
            if (lack == true) 
            {
                MessageBox.Show("Fill out all rule cells.");
                return;
            }
            
            tabCharts.SelectTab(dgvRules.Columns.Count - 1);
            if (rMamdani.Checked)
            {
                // create if-then rules
                FuzzySet output;
                IfThenFuzzyRule[] allRules = new IfThenFuzzyRule[dgvRules.Rows.Count];
                for (int r = 0; r < dgvRules.Rows.Count; r++)
                {
                    FuzzySet[] inputs = new FuzzySet[dgvRules.Columns.Count - 1];
                    for (int c = 0; c < dgvRules.Columns.Count - 1; c++)
                    {
                        inputs[c] = (FuzzySet)dgvRules.Rows[r].Cells[c].Value;
                    }
                    //find output col
                    output = (FuzzySet)dgvRules.Rows[r].Cells[dgvRules.Columns.Count - 1].Value;
                    allRules[r] = new IfThenFuzzyRule(inputs, output);
                }
                //conditions
                FuzzySet[] conditions = new FuzzySet[dgvConditions.Columns.Count];
                //set contents of conditions
                for (int r = 0; r < dgvConditions.Rows.Count; r++)
                {
                    for (int c = 0; c < dgvConditions.Columns.Count; c++)
                    {
                        conditions[c] = (FuzzySet)dgvConditions.Rows[r].Cells[c].Value;
                    }
                }
                FuzzySet resultingFS = null;
                foreach (IfThenFuzzyRule rule in allRules)
                {
                    if (resultingFS == null)
                    {
                        resultingFS = rule.FuzzyInFuzzyOutInferenceing(conditions, IsCut);
                    }
                    else //or 之前的rules
                        resultingFS = resultingFS | rule.FuzzyInFuzzyOutInferenceing(conditions, IsCut);
                }
                //show the final fs
                resultFS.Tag = resultingFS;
                resultingFS.ShowSeriesArea = true;
                resultingFS.ShowSeries = true;

            }
            else if (rTsukamoto.Checked)
            {
                //Create If-Then rules
                FuzzySet output;// output
                IfThenFuzzyRule[] allRules = new IfThenFuzzyRule[dgvRules.Rows.Count];
                for (int r = 0; r < dgvRules.Rows.Count; r++)
                {
                    FuzzySet[] inputs = new FuzzySet[dgvRules.Columns.Count - 1];
                    for (int c = 0; c < dgvRules.Columns.Count - 1; c++)
                    {
                        inputs[c] = (FuzzySet)dgvRules.Rows[r].Cells[c].Value;
                    }
                    //find output col
                    output = (FuzzySet)dgvRules.Rows[r].Cells[dgvRules.Columns.Count - 1].Value;
                    if (!output.IsMonotonic)
                    {
                        MessageBox.Show("Select a Monotonic Fuzzy set as output.");

                    }
                    //output.IsMonotonic = true;
                    allRules[r] = new IfThenFuzzyRule(inputs, output);
                }
                //conditions
                FuzzySet[] conditions = new FuzzySet[dgvConditions.Columns.Count];
                //set contents of conditions
                for (int r = 0; r < dgvConditions.Rows.Count; r++)
                {
                    for (int c = 0; c < dgvConditions.Columns.Count; c++)
                    {
                        conditions[c] = (FuzzySet)dgvConditions.Rows[r].Cells[c].Value;
                    }
                }
                double weightedSum = 0.0;
                double wSum = 0.0;
                foreach (IfThenFuzzyRule ifr in allRules)
                {
                    weightedSum = weightedSum + ifr.FuzzyInCrispOutInferencing(conditions);
                    wSum = wSum + ifr.FiringStrength;
                }
                MessageBox.Show($"Weighted Average: {weightedSum / wSum}"+"\n" +$"Weighted Sum:{weightedSum}");
            }
            else //sugeno
            {
                // create if-then rules
                int equationId;// output
                SugenoIfThenRule[] allRules = new SugenoIfThenRule[dgvRules.Rows.Count];
                for (int r = 0; r < dgvRules.Rows.Count; r++)
                {
                    FuzzySet[] inputs = new FuzzySet[dgvRules.Columns.Count - 1];
                    for (int c = 0; c < dgvRules.Columns.Count - 1; c++)
                    {
                        inputs[c] = (FuzzySet)dgvRules.Rows[r].Cells[c].Value;
                    }
                    //find output col
                    equationId = (int)dgvRules.Rows[r].Cells[dgvRules.Columns.Count - 1].Value;// # of equation
                    allRules[r] = new SugenoIfThenRule(inputs, equationId);
                }
                //conditions
                FuzzySet[] conditions = new FuzzySet[dgvConditions.Columns.Count];
                //set contents of conditions
                for (int r = 0; r < dgvConditions.Rows.Count; r++)
                {
                    for (int c = 0; c < dgvConditions.Columns.Count; c++)
                    {
                        conditions[c] = (FuzzySet)dgvConditions.Rows[r].Cells[c].Value;
                    }
                }

                double weightedSum = 0.0;
                double wSum = 0.0;
                foreach (SugenoIfThenRule ifr in allRules)
                {
                    weightedSum = weightedSum + ifr.FuzzyInCrispOutInferenceing(conditions, IsCut);
                    wSum = wSum + ifr.FiringStrength;
                }
                MessageBox.Show($"Weighted Average: {weightedSum / wSum}" + "\n" + $"Weighted Sum:{weightedSum}");

            }
        }
        private void tabFunction_MouseMove(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < tabFunction.TabCount; i++)
            {
                if (tabFunction.GetTabRect(i).Contains(e.X, e.Y))
                {
                    tabFunction.SelectedIndex = i;
                }
            }
        }
        private void tabSelect_MouseMove(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < tabSelect.TabCount; i++)
            {
                if (tabSelect.GetTabRect(i).Contains(e.X, e.Y))
                {
                    tabSelect.SelectedIndex = i;
                }
            }
        }
        private void dgv_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;

            DataGridView dgv = sender as DataGridView;
            ShowMenu(dgv, e);
        }
        private void theTree_MouseDown(object sender, MouseEventArgs e)
        {
            TreeViewHitTestInfo info = theTree.HitTest(e.X, e.Y);

            // Ensure that the user actually clicked on a node 
            if ((info.Node != null) && (info.Node == theTree.SelectedNode))
            {
                theTree.SelectedNode = null;
                theTree.SelectedNode = info.Node;
            }
        }
        private void dgvRules_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {   
            dgvRules.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = false;
            if (e.ColumnIndex < dgvRules.Columns.Count -1)
            {
                dgvRules.Rows[e.RowIndex].Cells[(int)e.ColumnIndex + 1].Selected = true;
                this.dgvRules.CurrentCell = dgvRules.Rows[e.RowIndex].Cells[(int)e.ColumnIndex + 1];
            }

        }
        private void dgvConditions_Click(object sender, EventArgs e)
        {
            dgvRules.CurrentCell = null;
        }
        private void theTree_AfterCheck(object sender, TreeViewEventArgs e)
        {
            
            if (theTree.SelectedNode.Tag is FuzzySet )
            {
                for(int i = 0; i< theTree.SelectedNode.Parent.Nodes.Count; i++)
                {
                    if (theTree.SelectedNode.Parent.Nodes[i].Checked)
                    {
                        if (((FuzzySet)theTree.SelectedNode.Parent.Nodes[i].Tag).ShowSeries == false)
                            ((FuzzySet)theTree.SelectedNode.Parent.Nodes[i].Tag).ShowSeries = true;
                    }
                    else
                    {
                        if (((FuzzySet)theTree.SelectedNode.Parent.Nodes[i].Tag).ShowSeries == true)
                            ((FuzzySet)theTree.SelectedNode.Parent.Nodes[i].Tag).ShowSeries = false;  
                    }
                }
            }
            else if(theTree.SelectedNode.Tag is Universe && theTree.SelectedNode.Nodes.Count>0)
            {
                for (int i = 0; i < theTree.SelectedNode.Nodes.Count; i++)
                {
                    if (theTree.SelectedNode.Nodes[i].Checked && theTree.SelectedNode.Nodes[i].Tag is FuzzySet)
                    {
                        if (((FuzzySet)theTree.SelectedNode.Nodes[i].Tag).ShowSeries == false)
                            ((FuzzySet)theTree.SelectedNode.Nodes[i].Tag).ShowSeries = true;

                        //((FuzzySet)node.Tag).UnSelectSeries();
                    }
                    else
                    {
                        if (((FuzzySet)theTree.SelectedNode.Nodes[i].Tag).ShowSeries == true && theTree.SelectedNode.Nodes[i].Tag is FuzzySet)
                            ((FuzzySet)theTree.SelectedNode.Nodes[i].Tag).ShowSeries = false;
                    }
                }
            }
            else
            {
                return;
            }
        }
        private void btnCrispInCrispOutInferencing_Click(object sender, EventArgs e)
        {
            //check cells are all fulled
            bool lack = false;
            for (int c = 0; c < dgvRules.Columns.Count; c++)
            {
                for (int r = 0; r < dgvRules.Rows.Count; r++)
                {
                    if (dgvRules.Rows[r].Cells[c].Value == null)
                    {
                        lack = true;
                    }
                }
            }
            if (lack == true)
            {
                MessageBox.Show("Fill out all rule cells.");
                return;
            }

            if(dgvRules.Rows.Count == 0)
            {
                MessageBox.Show("Add at least one rule.");
            }
            //open when two universe .SelectTab
            if (theTree.Nodes[0].GetNodeCount(false) == 2) 
            {
                teeChart.Visible = true;
                InferenceChart.Visible = false;

                Universe u1 = (Universe)theTree.Nodes[0].FirstNode.Tag;
                Universe u2 = (Universe)theTree.Nodes[0].LastNode.Tag;

                double dx = (u1.Maximum - u1.Minimum) / (u1.Resolution - 1);
                double dz = (u2.Maximum - u2.Minimum) / (u2.Resolution - 1);
                double[] conditions = new double[2];

                surface.NumXValues = 100;
                surface.NumZValues = 80;
                surface.IrregularGrid = true;
                surface.Clear();
                Random color = new Random();


                mySystem.IsCut = IsCut;
                mySystem.ConstructSystem(dgvRules);

                for (double x = u1.Minimum; x < u1.Maximum; x = x + dx)
                {
                    for (double z = u2.Minimum; z < u2.Maximum; z = z + dz)
                    {
                        conditions[0] = x;
                        conditions[1] = z;
                        double y = mySystem.CrispInCrispOutInferencing(conditions, GetDefuzzification());
                        surface.Add(x, y, z, Color.FromArgb(80));
                    }
                }
            }
            else if(theTree.Nodes[0].GetNodeCount(false) == 1) 
            {
                teeChart.Visible = false;
                InferenceChart.Visible = true;
                Universe u = (Universe)theTree.Nodes[0].FirstNode.Tag;
                Universe outputU = (Universe)theTree.Nodes[1].FirstNode.Tag;

                mySystem.IsCut = IsCut;
                mySystem.ConstructSystem(dgvRules);

                InferenceChart.Series[0].Points.Clear();

                string s = $"Crisp";
                InferenceChart.ChartAreas[0].AxisX.Title = u.Title;
                InferenceChart.ChartAreas[0].AxisY.Title = outputU.Title;
                InferenceChart.ChartAreas[0].AxisX.Enabled = AxisEnabled.True;
                InferenceChart.ChartAreas[0].AxisY.Enabled = AxisEnabled.True;
                InferenceChart.Legends[0].Title = $"{u.Title} - {outputU.Title}";

                double dx1 = (u.Maximum - u.Minimum) / (u.Resolution - 1);
                double[] condition = new double[1]; 
                for (double x = u.Minimum; x < u.Maximum; x = x + dx1)
                {
                    condition[0] = x;
                    double y = mySystem.CrispInCrispOutInferencing(condition, GetDefuzzification());
                    InferenceChart.Series[0].BorderWidth = 3;
                    InferenceChart.Series[0].Points.AddXY(x, y);
                }
            }
            else 
            {
                  MessageBox.Show("Too many Universe.");   
            }          
        }
        IFuzzyInferencing mySystem;
        private void rSystem_CheckedChanged(object sender, EventArgs e)
        {
            if (rMamdani.Checked)
            {
                mySystem = new MamdaniFuzzySystem();
                // remove all output FuzzySet from dgv rules
                if (theTree.Nodes[1].FirstNode != null)
                {
                    while (theTree.Nodes[1].FirstNode.FirstNode != null && theTree.Nodes[1].FirstNode.FirstNode.Tag.GetType().Name != "Int32")
                    {
                        if(theTree.Nodes[1].FirstNode.FirstNode.Tag.GetType().Name != "Int32")
                            ((FuzzySet)theTree.Nodes[1].FirstNode.LastNode.Tag).ShowSeries = false;
                        theTree.Nodes[1].FirstNode.LastNode.Remove();
                    }
                    theTree.SelectedNode = theTree.Nodes[1];
                    theTree.SelectedNode = theTree.Nodes[1].FirstNode;
                    
                    if(dgvRules.Columns[dgvRules.ColumnCount - 1].HeaderText == theTree.Nodes[1].FirstNode.Text)
                    {
                        for(int i = 0; i < dgvRules.RowCount; i++)
                        {
                            dgvRules.Rows[i].Cells[dgvRules.ColumnCount - 1].Value = null;
                        }
                    }
                }
            }
            else if (rTsukamoto.Checked)
            {
                if (resultFS.Tag != null)
                    ((FuzzySet)resultFS.Tag).ShowSeries = false;
                mySystem = new TsukamotoFuzzySystem();
                // remove all output FuzzySet
                if (theTree.Nodes[1].FirstNode != null)
                {
                    while (theTree.Nodes[1].FirstNode.FirstNode != null)
                    {
                        if(theTree.Nodes[1].FirstNode.FirstNode.Tag.GetType().Name != "Int32")
                            ((FuzzySet)theTree.Nodes[1].FirstNode.LastNode.Tag).ShowSeries = false;
                        theTree.Nodes[1].FirstNode.LastNode.Remove();
                    }
                    theTree.SelectedNode = theTree.Nodes[1];
                    theTree.SelectedNode = theTree.Nodes[1].FirstNode;
                    if (dgvRules.Columns[dgvRules.ColumnCount - 1].HeaderText == theTree.Nodes[1].FirstNode.Text)
                    {
                        for (int i = 0; i < dgvRules.RowCount; i++)
                        {
                            dgvRules.Rows[i].Cells[dgvRules.ColumnCount - 1].Value = null;
                        }
                    }
                }
            }
            else //sugeno
            { 
                if(resultFS.Tag!= null)
                    ((FuzzySet)resultFS.Tag).ShowSeries = false;
                mySystem = new SugenoFuzzySystem();
                // remove all output FuzzySet
                if (theTree.Nodes[1].FirstNode != null)
                {
                    while(theTree.Nodes[1].FirstNode.FirstNode!= null)
                    {
                        ((FuzzySet)theTree.Nodes[1].FirstNode.LastNode.Tag).ShowSeries = false;
                        theTree.Nodes[1].FirstNode.LastNode.Remove();
                    }
                    theTree.SelectedNode = theTree.Nodes[1];
                    theTree.SelectedNode = theTree.Nodes[1].FirstNode;
                    if (dgvRules.Columns[dgvRules.ColumnCount - 1].HeaderText == theTree.Nodes[1].FirstNode.Text)
                    {
                        for (int i = 0; i < dgvRules.RowCount; i++)
                        {
                            dgvRules.Rows[i].Cells[dgvRules.ColumnCount - 1].Value = null;
                        }
                    }
                }
                
            } 
            ppgSystem.SelectedObject = mySystem;
            
        }
        
        private void clbEquation_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < clbEquation.Items.Count; i++)
            {
                if (clbEquation.SelectedIndex != i)
                    clbEquation.SetItemChecked(i, false);
            }
        }
        private DefuzzificationType GetDefuzzification()
        {
            
            if (rCOA.Checked)
                return DefuzzificationType.COA;
            else if (rBOA.Checked)
                return DefuzzificationType.BOA;
            else if (rSOM.Checked)
                return DefuzzificationType.SOM;
            else if (rMOM.Checked)
                return DefuzzificationType.MOM;
            else
                return DefuzzificationType.LOM;
        }
        private void rCut_CheckedChanged(object sender, EventArgs e)
        {
            if (rCut.Checked)
            {
                IsCut = true;
            }
            if (rScale.Checked)
            {
                IsCut = false;
            }
        }
        private void btnAddEquation_Click(object sender, EventArgs e)
        {
            if (theTree.Nodes[0].GetNodeCount(false) == 1)
            {
                TreeNode cNode = new TreeNode();
                //name the node
                cNode.Text = clbEquation.SelectedItem.ToString();
                cNode.Tag = clbEquation.SelectedIndex;                
                theTree.SelectedNode.Nodes.Add(cNode);

                firstOutputFS++;

                btnAddRule.Enabled = true;
                RuleTip.Visible = false;


                theTree.ExpandAll();
            }
            else if (theTree.Nodes[0].GetNodeCount(false) == 2)
            {
                TreeNode cNode = new TreeNode();
                //name the node
                cNode.Text = clbEquation.SelectedItem.ToString();
                cNode.Tag = clbEquation.SelectedIndex;
                theTree.SelectedNode.Nodes.Add(cNode);
                firstOutputFS++;

                btnAddRule.Enabled = true;
                RuleTip.Visible = false;


                theTree.ExpandAll();
            }
            else { }

        }
        private void btnOpenFile(object sender, EventArgs e)
        {

            firstOutput = 0;
            tabSelect.SelectTab(0);
            if (dlgOpen.ShowDialog() != DialogResult.OK) return;
            //string str;
            string[] items;
            StreamReader sr = new StreamReader(dlgOpen.FileName);
            items = sr.ReadLine().Split(':');
            switch (items[1])
            {
                case "Mamdani":
                    rMamdani.Checked = true;
                    break;
                case "Sugeno":
                    rSugeno.Checked = true;
                    break;
                default:
                    rTsukamoto.Checked = true;
                    break;
            }
            theTree.Nodes[0].Nodes.Clear();
            theTree.Nodes[1].Nodes.Clear();
            tabCharts.TabPages.Clear();
            surface.Clear();

            items = sr.ReadLine().Split(':');
            int numInputUniverse = Convert.ToInt32(items[1]);
            int numFSs;
            TreeNode fsNode;
            FuzzySet fs = null;
            TreeNode univNode;
            Universe univ;
            Chart theChart;//Add a chart 
            TabPage theTag;
            Dictionary<int, FuzzySet> codeVsFS = new Dictionary<int, FuzzySet>();
            int hash;
            for (int i = 0; i < numInputUniverse; i++)
            {
                univNode = new TreeNode();

                theChart = new Chart();//Add a chart
                univ = new Universe(theChart);
                univNode.Tag = univ;
                univ.ReadFile(sr);

                theTag = new TabPage(univ.Title);
                tabCharts.TabPages.Add(theTag);

                theChart.Dock = DockStyle.Fill;
                theTag.Controls.Add(theChart);
                theChart.Visible = true;

                univNode.Text = univ.Title;
                theTree.Nodes[0].Nodes.Add(univNode);

                //deal with  included FSs
                items = sr.ReadLine().Split(':');
                numFSs = Convert.ToInt32(items[1]);
                for (int j = 0; j < numFSs; j++)
                {
                    fsNode = new TreeNode();
                    items = sr.ReadLine().Split(':');
                    switch (items[1])
                    {
                        case "TriangularFuzzySet": // Triangular
                            fs = new TriangularFuzzySet(univ);

                            fs.ShowSeries = true;
                            items = sr.ReadLine().Split(':');
                            hash = Convert.ToInt32(items[1]);
                            codeVsFS.Add(hash, fs);
                            //let fs read its data
                            fs.ReadFile(sr);
                            //name the node
                            fsNode.Text = fs.Title;
                            //connect tag and node
                            fsNode.Tag = fs;
                            break;
                        case "BellFuzzySet": // Bell
                            fs = new BellFuzzySet(univ);
                            fs.ShowSeries = true;
                            items = sr.ReadLine().Split(':');
                            hash = Convert.ToInt32(items[1]);
                            codeVsFS.Add(hash, fs);
                            //let fs read its data
                            fs.ReadFile(sr);
                            //name the node
                            fsNode.Text = fs.Title;
                            //connect tag and node
                            fsNode.Tag = fs;
                            break;
                        case "GaussianFuzzySet": // Gaussian
                            fs = new GaussianFuzzySet(univ);
                            fs.ShowSeries = true;
                            items = sr.ReadLine().Split(':');
                            hash = Convert.ToInt32(items[1]);
                            codeVsFS.Add(hash, fs);
                            //let fs read its data
                            fs.ReadFile(sr);
                            //name the node
                            fsNode.Text = fs.Title;
                            //connect tag and node
                            fsNode.Tag = fs;
                            break;
                        case "SigmoidalFuzzySet": // Sigmoidal
                            fs = new SigmoidalFuzzySet(univ);
                            fs.ShowSeries = true;
                            items = sr.ReadLine().Split(':');
                            hash = Convert.ToInt32(items[1]);
                            codeVsFS.Add(hash, fs);
                            //let fs read its data
                            fs.ReadFile(sr);
                            //name the node
                            fsNode.Text = fs.Title;
                            //connect tag and node
                            fsNode.Tag = fs;
                            break;
                        case "LRFuzzySet": // LRFuzzySet
                            fs = new LRFuzzySet(univ);
                            fs.ShowSeries = true;
                            items = sr.ReadLine().Split(':');
                            hash = Convert.ToInt32(items[1]);
                            codeVsFS.Add(hash, fs);
                            //let fs read its data
                            fs.ReadFile(sr);
                            //name the node
                            fsNode.Text = fs.Title;
                            //connect tag and node
                            fsNode.Tag = fs;
                            break;
                        case "PiFuzzySet": // PiFuzzySet
                            fs = new PiFuzzySet(univ);
                            fs.ShowSeries = true;
                            items = sr.ReadLine().Split(':');
                            hash = Convert.ToInt32(items[1]);
                            codeVsFS.Add(hash, fs);
                            //let fs read its data
                            fs.ReadFile(sr);
                            //name the node
                            fsNode.Text = fs.Title;
                            //connect tag and node
                            fsNode.Tag = fs;
                            break;
                        case "SFuzzySet": // SFuzzySet
                            fs = new SFuzzySet(univ);
                            fs.ShowSeries = true;
                            items = sr.ReadLine().Split(':');
                            hash = Convert.ToInt32(items[1]);
                            codeVsFS.Add(hash, fs);
                            //let fs read its data
                            fs.ReadFile(sr);
                            //name the node
                            fsNode.Text = fs.Title;
                            //connect tag and node
                            fsNode.Tag = fs;
                            break;
                        case "TrapezoidalFuzzySet": // TrapezoidalFuzzySet
                            fs = new TrapezoidalFuzzySet(univ);
                            fs.ShowSeries = true;
                            items = sr.ReadLine().Split(':');
                            hash = Convert.ToInt32(items[1]);
                            codeVsFS.Add(hash, fs);
                            //let fs read its data
                            fs.ReadFile(sr);
                            //name the node
                            fsNode.Text = fs.Title;
                            //connect tag and node
                            fsNode.Tag = fs;
                            break;
                        case "tsGaussianFuzzySet": // tsGaussianFuzzySet
                            fs = new tsGaussianFuzzySet(univ);
                            fs.ShowSeries = true;
                            items = sr.ReadLine().Split(':');
                            hash = Convert.ToInt32(items[1]);
                            codeVsFS.Add(hash, fs);
                            //let fs read its data
                            fs.ReadFile(sr);
                            //name the node
                            fsNode.Text = fs.Title;
                            //connect tag and node
                            fsNode.Tag = fs;
                            break;
                        case "tsPiFuzzySet": // tsPiFuzzySet
                            fs = new tsPiFuzzySet(univ);
                            fs.ShowSeries = true;
                            items = sr.ReadLine().Split(':');
                            hash = Convert.ToInt32(items[1]);
                            codeVsFS.Add(hash, fs);
                            //let fs read its data
                            fs.ReadFile(sr);
                            //name the node
                            fsNode.Text = fs.Title;
                            //connect tag and node
                            fsNode.Tag = fs;
                            break;
                        case "ZFuzzySet": // ZFuzzySet
                            fs = new ZFuzzySet(univ);
                            fs.ShowSeries = true;
                            items = sr.ReadLine().Split(':');
                            hash = Convert.ToInt32(items[1]);
                            codeVsFS.Add(hash, fs);
                            //let fs read its data
                            fs.ReadFile(sr);
                            //name the node
                            fsNode.Text = fs.Title;
                            //connect tag and node
                            fsNode.Tag = fs;
                            break;
                        case "SingletonFuzzySet": // SingletonFuzzySet
                            fs = new SingletonFuzzySet(univ);
                            items = sr.ReadLine().Split(':');
                            hash = Convert.ToInt32(items[1]);
                            codeVsFS.Add(hash, fs);
                            //let fs read its data
                            fs.ReadFile(sr);
                            break;
                        case "StepUpFuzzySet": // StepUpFuzzySet
                            fs = new StepUpFuzzySet(univ);
                            fs.ShowSeries = true;
                            items = sr.ReadLine().Split(':');
                            hash = Convert.ToInt32(items[1]);
                            codeVsFS.Add(hash, fs);
                            //let fs read its data
                            fs.ReadFile(sr);
                            //name the node
                            fsNode.Text = fs.Title;
                            //connect tag and node
                            fsNode.Tag = fs;
                            break;
                        case "StepDownFuzzySet": // StepDownFuzzySet
                            fs = new StepDownFuzzySet(univ);
                            fs.ShowSeries = true;
                            items = sr.ReadLine().Split(':');
                            hash = Convert.ToInt32(items[1]);
                            codeVsFS.Add(hash, fs);
                            //let fs read its data
                            fs.ReadFile(sr);
                            //name the node
                            fsNode.Text = fs.Title;
                            //connect tag and node
                            fsNode.Tag = fs;
                            break;
                        case "UnaryOperatedFuzzySet":
                            FuzzySet target;
                            UnaryFSOperator op = null;
                            items = sr.ReadLine().Split(':');
                            switch (items[1])
                            {
                                case "ValueCutOperator":
                                    op = new ValueCutOperator();
                                    break;
                                case "NegateOperator":
                                    op = new NegateOperator();
                                    break;
                            }
                            op.ReadFile(sr);
                            //get hash code of target FS
                            items = sr.ReadLine().Split(':');
                            int hashCode = Convert.ToInt32(items[1]);
                            target = codeVsFS[hashCode];
                            fs = new UnaryOperatedFuzzySet(target, op);
                            fs.ShowSeries = true;
                            items = sr.ReadLine().Split(':');
                            hash = Convert.ToInt32(items[1]);
                            codeVsFS.Add(hash, fs);
                            //let fs read its data
                            fs.ReadFile(sr);
                            fsNode.Text = fs.Title;
                            fsNode.Tag = fs;
                            break;
                    }
                    univNode.Nodes.Add(fsNode);
                }
            }
            univNode = new TreeNode();
            theChart = new Chart();//Add a chart
            univ = new Universe(theChart);
            items = sr.ReadLine().Split(':');
            //int numOutputUniverse = Convert.ToInt32(items[1]);
            univNode.Tag = univ;
            univ.ReadFile(sr);

            theTag = new TabPage(univ.Title);
            if (firstOutput != 0) tabCharts.TabPages.Insert(dgvRules.Columns.Count - 1, theTag);
            else tabCharts.TabPages.Add(theTag);

            theChart.Dock = DockStyle.Fill;
            theTag.Controls.Add(theChart);
            theChart.Visible = true;

            univNode.Text = univ.Title;
            theTree.Nodes[1].Nodes.Add(univNode);
            firstOutput++;

            //deal with  included FSs
            items = sr.ReadLine().Split(':');
            numFSs = Convert.ToInt32(items[1]);
            for (int j = 0; j < numFSs; j++)
            {

                fsNode = new TreeNode();
                items = sr.ReadLine().Split(':');
                switch (items[1])
                {
                    case "TriangularFuzzySet": // Triangular
                        fs = new TriangularFuzzySet(univ);
                        break;
                    case "BellFuzzySet": // Bell
                        fs = new BellFuzzySet(univ);
                        break;
                    case "GaussianFuzzySet": // Gaussian
                        fs = new GaussianFuzzySet(univ);
                        break;
                    case "SigmoidalFuzzySet": // Sigmoidal
                        fs = new SigmoidalFuzzySet(univ);
                        break;
                    case "LRFuzzySet": // LRFuzzySet
                        fs = new LRFuzzySet(univ);
                        break;
                    case "PiFuzzySet": // PiFuzzySet
                        fs = new PiFuzzySet(univ);
                        break;
                    case "SFuzzySet": // SFuzzySet
                        fs = new SFuzzySet(univ);
                        break;
                    case "TrapezoidalFuzzySet": // TrapezoidalFuzzySet
                        fs = new TrapezoidalFuzzySet(univ);
                        break;
                    case "tsGaussianFuzzySet": // tsGaussianFuzzySet
                        fs = new tsGaussianFuzzySet(univ);
                        break;
                    case "tsPiFuzzySet": // tsPiFuzzySet
                        fs = new tsPiFuzzySet(univ);
                        break;
                    case "ZFuzzySet": // ZFuzzySet
                        fs = new ZFuzzySet(univ);
                        break;
                    case "SingletonFuzzySet": // SingletonFuzzySet
                        fs = new SingletonFuzzySet(univ);
                        break;
                    case "StepUpFuzzySet":
                        fs = new StepUpFuzzySet(univ);
                        break;
                    case "StepDownFuzzySet":
                        fs = new StepDownFuzzySet(univ);
                        break;
                    default:
                        break;

                }
                if (items[1] == "SugenoEquition" )
                {                  
                    firstOutputFS++;
                    items = sr.ReadLine().Split(':');
                    hash = Convert.ToInt32(items[1]);
                    items = sr.ReadLine().Split(':');
                    fsNode.Text = $"{items[1]}:{items[2]}";
                    fsNode.Tag = clbEquation.FindString(items[1]);
                    int num;
                    items = sr.ReadLine().Split(':');
                    num = Convert.ToInt32(items[1]);
                }
                else
                {
                    fs.ShowSeries = true;
                    items = sr.ReadLine().Split(':');
                    hash = Convert.ToInt32(items[1]);
                    codeVsFS.Add(hash, fs);
                    //let fs read its data
                    fs.ReadFile(sr);
                    //name the node
                    fsNode.Text = fs.Title;
                    //connect tag and node
                    fsNode.Tag = fs;
                    firstInputFS++;
                }
                univNode.Nodes.Add(fsNode);
            }
            //Read in Rules
            // role datagridview
            this.dgvRules.Rows.Clear();
            this.dgvRules.Columns.Clear();
            this.dgvConditions.Rows.Clear();
            this.dgvConditions.Columns.Clear();
            //foreach (TreeNode tn in theTree.Nodes[0].Nodes)
            //  this.dgvRules.Columns.Add(tn.Text, tn.Text);
            //this.dgvRules.Columns.Add(theTree.Nodes[1].Nodes[0].Text, theTree.Nodes[1].Nodes[0].Text);
            int rows, cols;
            items = sr.ReadLine().Split(':');
            rows = Convert.ToInt32(items[1]);
            items = sr.ReadLine().Split(':');
            cols = Convert.ToInt32(items[1]);
            for (int c = 0; c < cols-1; c++)
            {
                dgvRules.Columns.Add(theTree.Nodes[0].Nodes[c].Text, theTree.Nodes[0].Nodes[c].Text);
                dgvConditions.Columns.Add(theTree.Nodes[0].Nodes[c].Text, theTree.Nodes[0].Nodes[c].Text);
            }
            dgvRules.Columns.Add(theTree.Nodes[1].Nodes[0].Text, theTree.Nodes[1].Nodes[0].Text);
            int code;
            for (int r = 0; r < rows; r++)
            {
                dgvRules.Rows.Add();
                for (int c = 0; c < cols; c++)
                {
                    items = sr.ReadLine().Split(':');// get fuzzy set hash
                    if (items[0] == "FuzzySetHash")
                    {
                        code = Convert.ToInt32(items[1]);
                        dgvRules.Rows[r].Cells[c].Value = codeVsFS[code];
                    }
                    else
                    {
                        dgvRules.Rows[r].Cells[c].Value = Convert.ToInt32(items[1]);
                    }

                }
            }
            if (dgvConditions.Rows.Count < 1 && theTree.Nodes[0].GetNodeCount(true) > 0) dgvConditions.Rows.Add();
            
            if (!sr.EndOfStream)
            {
                for (int c = 0; c < cols - 1; c++)
                {
                    items = sr.ReadLine().Split(':');// get fuzzy set hash
                    if (items[0] == "FuzzySetHash")
                    {
                        code = Convert.ToInt32(items[1]);
                        dgvConditions.Rows[0].Cells[c].Value = codeVsFS[code];
                    }
                    else
                    {
                        dgvConditions.Rows[0].Cells[c].Value = Convert.ToInt32(items[1]);
                    }

                }
            }
            else
            {
                btnInference.Enabled = false;
            }

            theTree.ExpandAll();
            //renew points on the chart

            foreach (TreeNode child in theTree.Nodes)//in/out
            {
                foreach (TreeNode grandchild in child.Nodes)//universe
                {
                    grandchild.Checked = true;
                    theTree.SelectedNode = grandchild.FirstNode;//select first FS
                    grandchild.FirstNode.Checked = false;
                    foreach (TreeNode grandgrandchild in grandchild.Nodes)//fuzzy
                    {
                        grandgrandchild.Checked = true;
                    }
                }
            }
            btnCrispInCrispOutInferencing.Enabled = true;
            btnAddRule.Enabled = true;
            dgvRules.CurrentCell = null;
            sr.Close();
            //dgvRules.ColumnAdded -= dgvRules_ColumnAdded;
            //dgvRules.ColumnAdded + dgvRules_ColumnAdded;
        }
        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            DialogResult ans = dlgSave.ShowDialog();
            if (ans != DialogResult.OK) return;
            StreamWriter sw = new StreamWriter(dlgSave.FileName);
            if (rMamdani.Checked) sw.WriteLine("Model:Mamdani");
            else if (rTsukamoto.Checked) sw.WriteLine("Model:Tsukamoto");
            else sw.WriteLine("Model:Sugeno");
            //traverse treeview
            int numUniverse = theTree.Nodes[0].Nodes.Count;//input universes
            sw.WriteLine($"NumberOfInputUniverses:{numUniverse}");
            TreeNode univNode;
            Universe univ;

            int numFSs;
            TreeNode fsNode;
            FuzzySet fs;
            int eqId;
            for (int i = 0; i < numUniverse; i++)
            {

                univNode = theTree.Nodes[0].Nodes[i];
                univ = (Universe)univNode.Tag;
                univ.SaveFile(sw);

                // report included fuzzy set
                numFSs = univNode.Nodes.Count;
                sw.WriteLine($"NumberOfFSs: {numFSs}");
                for (int j = 0; j < numFSs; j++)
                {
                    fsNode = univNode.Nodes[j];
                    fs = (FuzzySet)fsNode.Tag;
                    fs.SaveFile(sw);
                }
            }
            //output universes
            sw.WriteLine("NumberOfOutputUniverses:1");
            univNode = theTree.Nodes[1].Nodes[0];
            univ = (Universe)univNode.Tag;
            univ.SaveFile(sw);

            // report included fuzzy set
            numFSs = univNode.Nodes.Count;
            sw.WriteLine($"NumberOfFSs: {numFSs}");
            for (int j = 0; j < numFSs; j++)
            {
                fsNode = univNode.Nodes[j];
                if (fsNode.Tag is int)
                {
                    eqId = (int)fsNode.Tag;
                    sw.WriteLine($"FuzzySetType:SugenoEquition");
                    sw.WriteLine($"OriginHashCode:{eqId.GetHashCode()}");
                    sw.WriteLine($"EquationId:{clbEquation.Items[eqId].ToString()}");
                    sw.WriteLine($"NumberOfParameters:0");
                }
                else
                {
                    fs = (FuzzySet)fsNode.Tag;
                    fs.SaveFile(sw);
                }

            }
            // role datagridview
            sw.WriteLine($"NumberOfRows:{this.dgvRules.Rows.Count}");
            sw.WriteLine($"NumberOfCols:{this.dgvRules.Columns.Count}");
            foreach (DataGridViewRow dgvr in dgvRules.Rows)
            {
                foreach (DataGridViewCell dgvc in dgvr.Cells)
                {
                    if (dgvc.Value is FuzzySet)
                        sw.WriteLine($"FuzzySetHash:{dgvc.Value.GetHashCode()}");
                    else sw.WriteLine($"EquationID:{dgvc.Value}");
                }
            }
            // condition datagridview

            foreach (DataGridViewCell dgvc in dgvConditions.Rows[0].Cells)
            {
                sw.WriteLine($"FuzzySetHash:{dgvc.Value.GetHashCode()}");
            }
            
            sw.Close();

        }
        private void tabSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabSelect.SelectedIndex == 1)
            {
                dgvRules.CellValueChanged -= dgvRules_CellValueChanged;
                dgvConditions.CellValueChanged -= dgvConditions_CellValueChanged;
                for (int c = 0; c < dgvRules.Columns.Count-1; c++)
                {
                    dgvRules.Columns[c].HeaderText = theTree.Nodes[0].Nodes[c].Text;
                    //dgvConditions.Columns[c].HeaderText = theTree.Nodes[0].Nodes[c].Text;
                }
                if(theTree.Nodes[1].GetNodeCount(true)>0)dgvRules.Columns[dgvRules.Columns.Count-1].HeaderText = theTree.Nodes[1].FirstNode.Text;
                
                dgvRules.CellValueChanged += dgvRules_CellValueChanged;
                dgvConditions.CellValueChanged += dgvConditions_CellValueChanged;
            }
        }
        private void btnTest_Click(object sender, EventArgs e)
        {
            //0 EN, 1 LN, 2 MN, 3 SN ,4 ZE, 5 SP,6 MP,7 LP,8 EP
            int[,] data = { 
                {4,6,6,6,7,7,8},
                {2,4,4,6,6,6,7},
                {2,3,3,5,5,6,7},
                {1,2,3,4,5,6,7},
                {1,2,3,3,5,5,6},
                {0,1,2,2,3,5,6},
                {0,1,1,2,2,3,4}
            };
            int c = 0;
            for (int i = 0; i < 7; i++)//acceleration
            {
                for (int j = 0; j < 7; j++)//velocity
                {
                    dgvRules.Rows.Add();
                    dgvRules.Rows[c].Cells[0].Value = theTree.Nodes[0].Nodes[0].Nodes[j].Tag;//velocity
                    dgvRules.Rows[c].Cells[1].Value = theTree.Nodes[0].Nodes[1].Nodes[i].Tag;//acceleration
                    dgvRules.Rows[c].Cells[2].Value = theTree.Nodes[1].Nodes[0].Nodes[data[i,j]].Tag;
                    c++;
                }
            }
        }
        private void dgvConditions_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            dgvConditions.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = false;
            if (e.ColumnIndex < dgvConditions.Columns.Count-1)
            {
                dgvConditions.Rows[e.RowIndex].Cells[(int)e.ColumnIndex + 1].Selected = true;
                this.dgvConditions.CurrentCell = dgvConditions.Rows[e.RowIndex].Cells[(int)e.ColumnIndex + 1];
            }
            else
            {
                this.dgvConditions.CurrentCell = dgvConditions.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
            bool lack = false;

            for (int c = 0; c < dgvConditions.Columns.Count; c++)
            {
                for (int r = 0; r < dgvConditions.Rows.Count; r++)
                {
                    if (dgvConditions.Rows[r].Cells[c].Value == null)
                    {
                        lack = true;
                    }
                }
            }
            if (lack == true) btnInference.Enabled = false;
            else
            {
                btnInference.Enabled = true;
                dgvConditions.CurrentCell = null;
                //if(dgvRules.Rows.Count>0) dgvConditions.CurrentCell = dgvConditions.Rows[0].Cells[0];
            }
        }
        private void ShowMenu(DataGridView dgv, MouseEventArgs e)
        {
            if (dgv.CurrentRow == null) 
            {
                MessageBox.Show("Select a row first.");
                return;
            }
                
            int RowIndex = dgv.CurrentRow.Index;
            if (RowIndex < 0) return;

            ContextMenuStrip menu = new ContextMenuStrip();
            ToolStripMenuItem item = new ToolStripMenuItem("删除該筆資料");

            item.Click += (sender, ex) => dgv.Rows.RemoveAt(RowIndex);
            menu.Items.Add(item);

            menu.Show(dgv, new Point(e.X, e.Y));
        }

    }

}
