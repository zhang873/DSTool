namespace DSTool
{
    partial class ConfigForm
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
            this.tb_config = new System.Windows.Forms.TextBox();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_confirm = new System.Windows.Forms.Button();
            this.btn_use_template = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tb_config
            // 
            this.tb_config.Location = new System.Drawing.Point(29, 44);
            this.tb_config.Multiline = true;
            this.tb_config.Name = "tb_config";
            this.tb_config.Size = new System.Drawing.Size(316, 303);
            this.tb_config.TabIndex = 0;
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(270, 364);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 1;
            this.btn_cancel.Text = "关闭";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_confirm
            // 
            this.btn_confirm.Location = new System.Drawing.Point(189, 364);
            this.btn_confirm.Name = "btn_confirm";
            this.btn_confirm.Size = new System.Drawing.Size(75, 23);
            this.btn_confirm.TabIndex = 1;
            this.btn_confirm.Text = "更新";
            this.btn_confirm.UseVisualStyleBackColor = true;
            this.btn_confirm.Click += new System.EventHandler(this.btn_confirm_Click);
            // 
            // btn_use_template
            // 
            this.btn_use_template.Location = new System.Drawing.Point(270, 15);
            this.btn_use_template.Name = "btn_use_template";
            this.btn_use_template.Size = new System.Drawing.Size(75, 23);
            this.btn_use_template.TabIndex = 1;
            this.btn_use_template.Text = "使用模板";
            this.btn_use_template.UseVisualStyleBackColor = true;
            this.btn_use_template.Click += new System.EventHandler(this.btn_use_template_Click);
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 399);
            this.Controls.Add(this.btn_use_template);
            this.Controls.Add(this.btn_confirm);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.tb_config);
            this.Name = "ConfigForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "配置信息";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_config;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_confirm;
        private System.Windows.Forms.Button btn_use_template;
    }
}