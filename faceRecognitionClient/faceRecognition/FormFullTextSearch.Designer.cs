namespace faceRecognition
{
    partial class FormFullTextSearch
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
            this.formContent = new System.Windows.Forms.TableLayoutPanel();
            this.searchingResults = new System.Windows.Forms.DataGridView();
            this.toolsPanel = new System.Windows.Forms.TableLayoutPanel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearchInfo = new System.Windows.Forms.TextBox();
            this.formContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchingResults)).BeginInit();
            this.toolsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // formContent
            // 
            this.formContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.formContent.ColumnCount = 2;
            this.formContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.formContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.formContent.Controls.Add(this.searchingResults, 0, 0);
            this.formContent.Controls.Add(this.toolsPanel, 1, 0);
            this.formContent.Location = new System.Drawing.Point(12, 12);
            this.formContent.Name = "formContent";
            this.formContent.RowCount = 1;
            this.formContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.formContent.Size = new System.Drawing.Size(646, 209);
            this.formContent.TabIndex = 0;
            // 
            // searchingResults
            // 
            this.searchingResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchingResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.searchingResults.Location = new System.Drawing.Point(3, 3);
            this.searchingResults.Name = "searchingResults";
            this.searchingResults.Size = new System.Drawing.Size(317, 203);
            this.searchingResults.TabIndex = 0;
            // 
            // toolsPanel
            // 
            this.toolsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toolsPanel.ColumnCount = 2;
            this.toolsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.toolsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.toolsPanel.Controls.Add(this.btnSearch, 1, 0);
            this.toolsPanel.Controls.Add(this.txtSearchInfo, 0, 0);
            this.toolsPanel.Location = new System.Drawing.Point(326, 3);
            this.toolsPanel.Name = "toolsPanel";
            this.toolsPanel.RowCount = 1;
            this.toolsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.toolsPanel.Size = new System.Drawing.Size(317, 203);
            this.toolsPanel.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.ImageKey = "(none)";
            this.btnSearch.Location = new System.Drawing.Point(222, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(92, 28);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Искать";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearchInfo
            // 
            this.txtSearchInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchInfo.Location = new System.Drawing.Point(3, 3);
            this.txtSearchInfo.Name = "txtSearchInfo";
            this.txtSearchInfo.Size = new System.Drawing.Size(211, 20);
            this.txtSearchInfo.TabIndex = 1;
            // 
            // FormFullTextSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 233);
            this.Controls.Add(this.formContent);
            this.MinimumSize = new System.Drawing.Size(500, 200);
            this.Name = "FormFullTextSearch";
            this.Text = "Поиск";
            this.Load += new System.EventHandler(this.FormFullTextSearch_Load);
            this.formContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.searchingResults)).EndInit();
            this.toolsPanel.ResumeLayout(false);
            this.toolsPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel formContent;
        private System.Windows.Forms.DataGridView searchingResults;
        private System.Windows.Forms.TableLayoutPanel toolsPanel;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearchInfo;

    }
}