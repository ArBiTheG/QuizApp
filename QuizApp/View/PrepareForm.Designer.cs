namespace QuizApp.View
{
    partial class PrepareForm
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
            this.formPanel = new System.Windows.Forms.Panel();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.descriptionTextBox = new System.Windows.Forms.RichTextBox();
            this.timerLabel = new System.Windows.Forms.Label();
            this.countLabel = new System.Windows.Forms.Label();
            this.authorLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.handlePanel = new System.Windows.Forms.TableLayoutPanel();
            this.startButton = new System.Windows.Forms.Button();
            this.formPanel.SuspendLayout();
            this.contentPanel.SuspendLayout();
            this.handlePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // formPanel
            // 
            this.formPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.formPanel.Controls.Add(this.contentPanel);
            this.formPanel.Controls.Add(this.titleLabel);
            this.formPanel.Controls.Add(this.handlePanel);
            this.formPanel.Location = new System.Drawing.Point(12, 12);
            this.formPanel.Name = "formPanel";
            this.formPanel.Size = new System.Drawing.Size(760, 537);
            this.formPanel.TabIndex = 0;
            // 
            // contentPanel
            // 
            this.contentPanel.Controls.Add(this.descriptionTextBox);
            this.contentPanel.Controls.Add(this.timerLabel);
            this.contentPanel.Controls.Add(this.countLabel);
            this.contentPanel.Controls.Add(this.authorLabel);
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(0, 56);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(760, 441);
            this.contentPanel.TabIndex = 3;
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.descriptionTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.descriptionTextBox.Location = new System.Drawing.Point(0, 0);
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.ReadOnly = true;
            this.descriptionTextBox.Size = new System.Drawing.Size(760, 372);
            this.descriptionTextBox.TabIndex = 3;
            this.descriptionTextBox.Text = "";
            // 
            // timerLabel
            // 
            this.timerLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.timerLabel.Location = new System.Drawing.Point(0, 372);
            this.timerLabel.Name = "timerLabel";
            this.timerLabel.Size = new System.Drawing.Size(760, 23);
            this.timerLabel.TabIndex = 2;
            this.timerLabel.Text = "Время";
            // 
            // countLabel
            // 
            this.countLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.countLabel.Location = new System.Drawing.Point(0, 395);
            this.countLabel.Name = "countLabel";
            this.countLabel.Size = new System.Drawing.Size(760, 23);
            this.countLabel.TabIndex = 1;
            this.countLabel.Text = "Колличество вопросов";
            // 
            // authorLabel
            // 
            this.authorLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.authorLabel.Location = new System.Drawing.Point(0, 418);
            this.authorLabel.Name = "authorLabel";
            this.authorLabel.Size = new System.Drawing.Size(760, 23);
            this.authorLabel.TabIndex = 0;
            this.authorLabel.Text = "Автор";
            // 
            // titleLabel
            // 
            this.titleLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.titleLabel.Location = new System.Drawing.Point(0, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(760, 56);
            this.titleLabel.TabIndex = 2;
            this.titleLabel.Text = "Заголовок";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // handlePanel
            // 
            this.handlePanel.ColumnCount = 3;
            this.handlePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.handlePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.handlePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.handlePanel.Controls.Add(this.startButton, 1, 0);
            this.handlePanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.handlePanel.Location = new System.Drawing.Point(0, 497);
            this.handlePanel.Name = "handlePanel";
            this.handlePanel.RowCount = 1;
            this.handlePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.handlePanel.Size = new System.Drawing.Size(760, 40);
            this.handlePanel.TabIndex = 1;
            // 
            // startButton
            // 
            this.startButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.startButton.Location = new System.Drawing.Point(256, 3);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(247, 34);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Начать тестирование";
            this.startButton.UseVisualStyleBackColor = true;
            // 
            // PrepareForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.formPanel);
            this.Name = "PrepareForm";
            this.Text = "Подготовка к тестированию";
            this.formPanel.ResumeLayout(false);
            this.contentPanel.ResumeLayout(false);
            this.handlePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel formPanel;
        private System.Windows.Forms.TableLayoutPanel handlePanel;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.RichTextBox descriptionTextBox;
        private System.Windows.Forms.Label timerLabel;
        private System.Windows.Forms.Label countLabel;
        private System.Windows.Forms.Label authorLabel;
    }
}