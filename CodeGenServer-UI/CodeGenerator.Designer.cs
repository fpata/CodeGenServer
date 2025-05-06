namespace CodeGenServer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            grpConnectionParams = new GroupBox();
            cbDBType = new ComboBox();
            blDBType = new Label();
            lblTables = new Label();
            cbTables = new ComboBox();
            btnConnect = new Button();
            txtConnectionString = new TextBox();
            lblConnectionString = new Label();
            grpConnections = new GroupBox();
            tbSchemaCode = new TabControl();
            tbTableDetails = new TabPage();
            dgvTablesSchema = new DataGridView();
            tbColumns = new TabPage();
            dgvColumnsSchema = new DataGridView();
            tbTypeScript = new TabPage();
            txtTypeScriptCode = new TextBox();
            tbCSharp_Poco = new TabPage();
            txtCSharp_Poco = new TextBox();
            tbCSharpEFMapping = new TabPage();
            txtCSharpEFMapping = new TextBox();
            tbCSharpDAL = new TabPage();
            txtCSharpDAL = new TextBox();
            tbCSharpDBContext = new TabPage();
            txtCSharpDBContext = new TextBox();
            tbHTML = new TabPage();
            txtHTML = new TextBox();
            tbHTMLBootStrap = new TabPage();
            txtHTMLBootStrap = new TextBox();
            tbHTMLMaterial = new TabPage();
            txtHTMLMaterial = new TextBox();
            grpConnectionParams.SuspendLayout();
            grpConnections.SuspendLayout();
            tbSchemaCode.SuspendLayout();
            tbTableDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTablesSchema).BeginInit();
            tbColumns.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvColumnsSchema).BeginInit();
            tbTypeScript.SuspendLayout();
            tbCSharp_Poco.SuspendLayout();
            tbCSharpEFMapping.SuspendLayout();
            tbCSharpDAL.SuspendLayout();
            tbCSharpDBContext.SuspendLayout();
            tbHTML.SuspendLayout();
            tbHTMLBootStrap.SuspendLayout();
            tbHTMLMaterial.SuspendLayout();
            SuspendLayout();
            // 
            // grpConnectionParams
            // 
            grpConnectionParams.Controls.Add(cbDBType);
            grpConnectionParams.Controls.Add(blDBType);
            grpConnectionParams.Controls.Add(lblTables);
            grpConnectionParams.Controls.Add(cbTables);
            grpConnectionParams.Controls.Add(btnConnect);
            grpConnectionParams.Controls.Add(txtConnectionString);
            grpConnectionParams.Controls.Add(lblConnectionString);
            grpConnectionParams.Location = new Point(11, 10);
            grpConnectionParams.Name = "grpConnectionParams";
            grpConnectionParams.Size = new Size(966, 166);
            grpConnectionParams.TabIndex = 0;
            grpConnectionParams.TabStop = false;
            // 
            // cbDBType
            // 
            cbDBType.FormattingEnabled = true;
            cbDBType.Items.AddRange(new object[] { "SQLite", "SqlServer", "MySQL", "Oracle" });
            cbDBType.Location = new Point(118, 23);
            cbDBType.Name = "cbDBType";
            cbDBType.Size = new Size(837, 23);
            cbDBType.TabIndex = 6;
            // 
            // blDBType
            // 
            blDBType.AutoSize = true;
            blDBType.Location = new Point(24, 24);
            blDBType.Name = "blDBType";
            blDBType.Size = new Size(49, 15);
            blDBType.TabIndex = 5;
            blDBType.Text = "DB Type";
            // 
            // lblTables
            // 
            lblTables.AutoSize = true;
            lblTables.Location = new Point(63, 124);
            lblTables.Name = "lblTables";
            lblTables.Size = new Size(39, 15);
            lblTables.TabIndex = 4;
            lblTables.Text = "Tables";
            // 
            // cbTables
            // 
            cbTables.FormattingEnabled = true;
            cbTables.Location = new Point(117, 121);
            cbTables.Name = "cbTables";
            cbTables.Size = new Size(838, 23);
            cbTables.TabIndex = 3;
            cbTables.SelectedIndexChanged += cbTables_SelectedIndexChanged;
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(118, 90);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(837, 23);
            btnConnect.TabIndex = 2;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // txtConnectionString
            // 
            txtConnectionString.Location = new Point(117, 59);
            txtConnectionString.Name = "txtConnectionString";
            txtConnectionString.Size = new Size(838, 23);
            txtConnectionString.TabIndex = 1;
            // 
            // lblConnectionString
            // 
            lblConnectionString.AutoSize = true;
            lblConnectionString.Location = new Point(8, 62);
            lblConnectionString.Name = "lblConnectionString";
            lblConnectionString.Size = new Size(103, 15);
            lblConnectionString.TabIndex = 0;
            lblConnectionString.Text = "Connection String";
            // 
            // grpConnections
            // 
            grpConnections.Controls.Add(tbSchemaCode);
            grpConnections.Location = new Point(12, 167);
            grpConnections.Name = "grpConnections";
            grpConnections.Size = new Size(966, 359);
            grpConnections.TabIndex = 1;
            grpConnections.TabStop = false;
            // 
            // tbSchemaCode
            // 
            tbSchemaCode.Controls.Add(tbTableDetails);
            tbSchemaCode.Controls.Add(tbColumns);
            tbSchemaCode.Controls.Add(tbTypeScript);
            tbSchemaCode.Controls.Add(tbCSharp_Poco);
            tbSchemaCode.Controls.Add(tbCSharpEFMapping);
            tbSchemaCode.Controls.Add(tbCSharpDAL);
            tbSchemaCode.Controls.Add(tbCSharpDBContext);
            tbSchemaCode.Controls.Add(tbHTML);
            tbSchemaCode.Controls.Add(tbHTMLBootStrap);
            tbSchemaCode.Controls.Add(tbHTMLMaterial);
            tbSchemaCode.Dock = DockStyle.Top;
            tbSchemaCode.ImeMode = ImeMode.NoControl;
            tbSchemaCode.Location = new Point(3, 19);
            tbSchemaCode.Name = "tbSchemaCode";
            tbSchemaCode.SelectedIndex = 0;
            tbSchemaCode.Size = new Size(960, 327);
            tbSchemaCode.TabIndex = 0;
            tbSchemaCode.SelectedIndexChanged += tbSchemaCode_SelectedIndexChanged;
            // 
            // tbTableDetails
            // 
            tbTableDetails.Controls.Add(dgvTablesSchema);
            tbTableDetails.Location = new Point(4, 24);
            tbTableDetails.Name = "tbTableDetails";
            tbTableDetails.Padding = new Padding(3);
            tbTableDetails.Size = new Size(952, 299);
            tbTableDetails.TabIndex = 0;
            tbTableDetails.Text = "Tables";
            tbTableDetails.UseVisualStyleBackColor = true;
            // 
            // dgvTablesSchema
            // 
            dgvTablesSchema.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTablesSchema.Location = new Point(7, 10);
            dgvTablesSchema.Name = "dgvTablesSchema";
            dgvTablesSchema.Size = new Size(923, 283);
            dgvTablesSchema.TabIndex = 0;
            // 
            // tbColumns
            // 
            tbColumns.Controls.Add(dgvColumnsSchema);
            tbColumns.Location = new Point(4, 24);
            tbColumns.Name = "tbColumns";
            tbColumns.Padding = new Padding(3);
            tbColumns.Size = new Size(936, 299);
            tbColumns.TabIndex = 1;
            tbColumns.Text = "Columns";
            tbColumns.UseVisualStyleBackColor = true;
            tbColumns.Click += tbColumns_Click;
            // 
            // dgvColumnsSchema
            // 
            dgvColumnsSchema.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvColumnsSchema.Location = new Point(5, 5);
            dgvColumnsSchema.Name = "dgvColumnsSchema";
            dgvColumnsSchema.Size = new Size(925, 288);
            dgvColumnsSchema.TabIndex = 0;
            // 
            // tbTypeScript
            // 
            tbTypeScript.Controls.Add(txtTypeScriptCode);
            tbTypeScript.Location = new Point(4, 24);
            tbTypeScript.Name = "tbTypeScript";
            tbTypeScript.Size = new Size(936, 299);
            tbTypeScript.TabIndex = 2;
            tbTypeScript.Text = "TypeScript";
            tbTypeScript.UseVisualStyleBackColor = true;
            tbTypeScript.Click += tbTypeScript_Click;
            // 
            // txtTypeScriptCode
            // 
            txtTypeScriptCode.Location = new Point(9, 8);
            txtTypeScriptCode.Multiline = true;
            txtTypeScriptCode.Name = "txtTypeScriptCode";
            txtTypeScriptCode.Size = new Size(916, 281);
            txtTypeScriptCode.TabIndex = 0;
            // 
            // tbCSharp_Poco
            // 
            tbCSharp_Poco.Controls.Add(txtCSharp_Poco);
            tbCSharp_Poco.Location = new Point(4, 24);
            tbCSharp_Poco.Name = "tbCSharp_Poco";
            tbCSharp_Poco.Size = new Size(936, 299);
            tbCSharp_Poco.TabIndex = 3;
            tbCSharp_Poco.Text = "CSharp-POCO";
            tbCSharp_Poco.UseVisualStyleBackColor = true;
            tbCSharp_Poco.Click += tbCSharp_Poco_Click;
            // 
            // txtCSharp_Poco
            // 
            txtCSharp_Poco.Location = new Point(5, 4);
            txtCSharp_Poco.Multiline = true;
            txtCSharp_Poco.Name = "txtCSharp_Poco";
            txtCSharp_Poco.Size = new Size(928, 277);
            txtCSharp_Poco.TabIndex = 0;
            // 
            // tbCSharpEFMapping
            // 
            tbCSharpEFMapping.Controls.Add(txtCSharpEFMapping);
            tbCSharpEFMapping.Location = new Point(4, 24);
            tbCSharpEFMapping.Name = "tbCSharpEFMapping";
            tbCSharpEFMapping.Size = new Size(936, 299);
            tbCSharpEFMapping.TabIndex = 4;
            tbCSharpEFMapping.Text = "CSharp-EFMapping";
            tbCSharpEFMapping.UseVisualStyleBackColor = true;
            tbCSharpEFMapping.Click += tbCSharpEFMapping_Click;
            // 
            // txtCSharpEFMapping
            // 
            txtCSharpEFMapping.Location = new Point(6, 2);
            txtCSharpEFMapping.Multiline = true;
            txtCSharpEFMapping.Name = "txtCSharpEFMapping";
            txtCSharpEFMapping.Size = new Size(927, 294);
            txtCSharpEFMapping.TabIndex = 0;
            // 
            // tbCSharpDAL
            // 
            tbCSharpDAL.Controls.Add(txtCSharpDAL);
            tbCSharpDAL.Location = new Point(4, 24);
            tbCSharpDAL.Name = "tbCSharpDAL";
            tbCSharpDAL.Size = new Size(936, 299);
            tbCSharpDAL.TabIndex = 5;
            tbCSharpDAL.Text = "CSharp-DAL";
            tbCSharpDAL.UseVisualStyleBackColor = true;
            tbCSharpDAL.Click += tbCSharpDAL_Click;
            // 
            // txtCSharpDAL
            // 
            txtCSharpDAL.Location = new Point(5, 5);
            txtCSharpDAL.Multiline = true;
            txtCSharpDAL.Name = "txtCSharpDAL";
            txtCSharpDAL.Size = new Size(928, 291);
            txtCSharpDAL.TabIndex = 0;
            // 
            // tbCSharpDBContext
            // 
            tbCSharpDBContext.Controls.Add(txtCSharpDBContext);
            tbCSharpDBContext.Location = new Point(4, 24);
            tbCSharpDBContext.Name = "tbCSharpDBContext";
            tbCSharpDBContext.Size = new Size(936, 299);
            tbCSharpDBContext.TabIndex = 6;
            tbCSharpDBContext.Text = "CSharp DBContext";
            tbCSharpDBContext.UseVisualStyleBackColor = true;
            tbCSharpDBContext.Click += tbCSharpDBContext_Click;
            // 
            // txtCSharpDBContext
            // 
            txtCSharpDBContext.Location = new Point(5, 4);
            txtCSharpDBContext.Multiline = true;
            txtCSharpDBContext.Name = "txtCSharpDBContext";
            txtCSharpDBContext.Size = new Size(928, 292);
            txtCSharpDBContext.TabIndex = 0;
            // 
            // tbHTML
            // 
            tbHTML.Controls.Add(txtHTML);
            tbHTML.Location = new Point(4, 24);
            tbHTML.Name = "tbHTML";
            tbHTML.Size = new Size(936, 299);
            tbHTML.TabIndex = 7;
            tbHTML.Text = "HTML";
            tbHTML.UseVisualStyleBackColor = true;
            tbHTML.Click += tbHTML_Click;
            // 
            // txtHTML
            // 
            txtHTML.Location = new Point(9, 7);
            txtHTML.Multiline = true;
            txtHTML.Name = "txtHTML";
            txtHTML.Size = new Size(924, 289);
            txtHTML.TabIndex = 0;
            // 
            // tbHTMLBootStrap
            // 
            tbHTMLBootStrap.Controls.Add(txtHTMLBootStrap);
            tbHTMLBootStrap.Location = new Point(4, 24);
            tbHTMLBootStrap.Name = "tbHTMLBootStrap";
            tbHTMLBootStrap.Size = new Size(936, 299);
            tbHTMLBootStrap.TabIndex = 8;
            tbHTMLBootStrap.Text = "HTML-BootStrap";
            tbHTMLBootStrap.UseVisualStyleBackColor = true;
            tbHTMLBootStrap.Click += tbHTMLBootStrap_Click;
            // 
            // txtHTMLBootStrap
            // 
            txtHTMLBootStrap.Location = new Point(3, 1);
            txtHTMLBootStrap.Multiline = true;
            txtHTMLBootStrap.Name = "txtHTMLBootStrap";
            txtHTMLBootStrap.Size = new Size(921, 295);
            txtHTMLBootStrap.TabIndex = 0;
            // 
            // tbHTMLMaterial
            // 
            tbHTMLMaterial.Controls.Add(txtHTMLMaterial);
            tbHTMLMaterial.Location = new Point(4, 24);
            tbHTMLMaterial.Name = "tbHTMLMaterial";
            tbHTMLMaterial.Size = new Size(936, 299);
            tbHTMLMaterial.TabIndex = 9;
            tbHTMLMaterial.Text = "HTML-Material";
            tbHTMLMaterial.UseVisualStyleBackColor = true;
            tbHTMLMaterial.Click += tbHTMLMaterial_Click;
            // 
            // txtHTMLMaterial
            // 
            txtHTMLMaterial.Location = new Point(2, 8);
            txtHTMLMaterial.Multiline = true;
            txtHTMLMaterial.Name = "txtHTMLMaterial";
            txtHTMLMaterial.Size = new Size(931, 288);
            txtHTMLMaterial.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(989, 530);
            Controls.Add(grpConnections);
            Controls.Add(grpConnectionParams);
            Name = "Form1";
            Text = "Code Generator";
            grpConnectionParams.ResumeLayout(false);
            grpConnectionParams.PerformLayout();
            grpConnections.ResumeLayout(false);
            tbSchemaCode.ResumeLayout(false);
            tbTableDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTablesSchema).EndInit();
            tbColumns.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvColumnsSchema).EndInit();
            tbTypeScript.ResumeLayout(false);
            tbTypeScript.PerformLayout();
            tbCSharp_Poco.ResumeLayout(false);
            tbCSharp_Poco.PerformLayout();
            tbCSharpEFMapping.ResumeLayout(false);
            tbCSharpEFMapping.PerformLayout();
            tbCSharpDAL.ResumeLayout(false);
            tbCSharpDAL.PerformLayout();
            tbCSharpDBContext.ResumeLayout(false);
            tbCSharpDBContext.PerformLayout();
            tbHTML.ResumeLayout(false);
            tbHTML.PerformLayout();
            tbHTMLBootStrap.ResumeLayout(false);
            tbHTMLBootStrap.PerformLayout();
            tbHTMLMaterial.ResumeLayout(false);
            tbHTMLMaterial.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpConnectionParams;
        private Label lblTables;
        private ComboBox cbTables;
        private Button btnConnect;
        private TextBox txtConnectionString;
        private Label lblConnectionString;
        private GroupBox grpConnections;
        private TabControl tbSchemaCode;
        private TabPage tbTableDetails;
        private TabPage tbColumns;
        private TabPage tbTypeScript;
        private TabPage tbCSharp_Poco;
        private DataGridView dgvTablesSchema;
        private DataGridView dgvColumnsSchema;
        private TextBox txtTypeScriptCode;
        private TextBox txtCSharp_Poco;
        private ComboBox cbDBType;
        private Label blDBType;
        private TabPage tbCSharpEFMapping;
        private TextBox txtCSharpEFMapping;
        private TabPage tbCSharpDAL;
        private TextBox txtCSharpDAL;
        private TabPage tbCSharpDBContext;
        private TextBox txtCSharpDBContext;
        private TabPage tbHTML;
        private TextBox txtHTML;
        private TabPage tbHTMLBootStrap;
        private TextBox txtHTMLBootStrap;
        private TabPage tbHTMLMaterial;
        private TextBox txtHTMLMaterial;
    }
}
