namespace TotallyRealApp.DebuggerVisualizer.SomeType
{
    partial class SomeTypeVisualizerForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtFoo = new System.Windows.Forms.TextBox();
            this.chkAllowEdit = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Foo:";
            // 
            // txtFoo
            // 
            this.txtFoo.Location = new System.Drawing.Point(57, 21);
            this.txtFoo.Name = "txtFoo";
            this.txtFoo.ReadOnly = true;
            this.txtFoo.Size = new System.Drawing.Size(205, 20);
            this.txtFoo.TabIndex = 1;
            this.txtFoo.TextChanged += new System.EventHandler(this.txtFoo_TextChanged);
            // 
            // chkAllowEdit
            // 
            this.chkAllowEdit.AutoSize = true;
            this.chkAllowEdit.Location = new System.Drawing.Point(57, 68);
            this.chkAllowEdit.Name = "chkAllowEdit";
            this.chkAllowEdit.Size = new System.Drawing.Size(72, 17);
            this.chkAllowEdit.TabIndex = 2;
            this.chkAllowEdit.Text = "Allow Edit";
            this.chkAllowEdit.UseVisualStyleBackColor = true;
            this.chkAllowEdit.CheckedChanged += new System.EventHandler(this.chkAllowEdit_CheckedChanged);
            // 
            // SomeTypeVisualizerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 119);
            this.Controls.Add(this.chkAllowEdit);
            this.Controls.Add(this.txtFoo);
            this.Controls.Add(this.label1);
            this.Name = "SomeTypeVisualizerForm";
            this.Text = "SomeTypeVisualizerForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFoo;
        private System.Windows.Forms.CheckBox chkAllowEdit;
    }
}