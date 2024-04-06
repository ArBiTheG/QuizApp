namespace QuizApp.View
{
    partial class QuestionForm
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
            this.contentSplitContainer = new System.Windows.Forms.SplitContainer();
            this.descriptionTextBox = new System.Windows.Forms.RichTextBox();
            this.answersPanel = new System.Windows.Forms.Panel();
            this.answersLabel = new System.Windows.Forms.Label();
            this.infoPanel = new System.Windows.Forms.TableLayoutPanel();
            this.finishButton = new System.Windows.Forms.Button();
            this.numberLabel = new System.Windows.Forms.Label();
            this.timerLabel = new System.Windows.Forms.Label();
            this.handlePanel = new System.Windows.Forms.TableLayoutPanel();
            this.nextButton = new System.Windows.Forms.Button();
            this.prevButton = new System.Windows.Forms.Button();
            this.formPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contentSplitContainer)).BeginInit();
            this.contentSplitContainer.Panel1.SuspendLayout();
            this.contentSplitContainer.Panel2.SuspendLayout();
            this.contentSplitContainer.SuspendLayout();
            this.infoPanel.SuspendLayout();
            this.handlePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // formPanel
            // 
            this.formPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.formPanel.Controls.Add(this.contentSplitContainer);
            this.formPanel.Controls.Add(this.infoPanel);
            this.formPanel.Controls.Add(this.handlePanel);
            this.formPanel.Location = new System.Drawing.Point(12, 12);
            this.formPanel.Name = "formPanel";
            this.formPanel.Size = new System.Drawing.Size(760, 537);
            this.formPanel.TabIndex = 2;
            // 
            // contentSplitContainer
            // 
            this.contentSplitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.contentSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentSplitContainer.Location = new System.Drawing.Point(0, 40);
            this.contentSplitContainer.Name = "contentSplitContainer";
            this.contentSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // contentSplitContainer.Panel1
            // 
            this.contentSplitContainer.Panel1.Controls.Add(this.descriptionTextBox);
            // 
            // contentSplitContainer.Panel2
            // 
            this.contentSplitContainer.Panel2.Controls.Add(this.answersPanel);
            this.contentSplitContainer.Panel2.Controls.Add(this.answersLabel);
            this.contentSplitContainer.Size = new System.Drawing.Size(760, 457);
            this.contentSplitContainer.SplitterDistance = 186;
            this.contentSplitContainer.TabIndex = 4;
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.descriptionTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.descriptionTextBox.Location = new System.Drawing.Point(0, 0);
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.ReadOnly = true;
            this.descriptionTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.descriptionTextBox.Size = new System.Drawing.Size(758, 184);
            this.descriptionTextBox.TabIndex = 0;
            this.descriptionTextBox.Text = "";
            // 
            // answersPanel
            // 
            this.answersPanel.AutoScroll = true;
            this.answersPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.answersPanel.Location = new System.Drawing.Point(0, 23);
            this.answersPanel.Name = "answersPanel";
            this.answersPanel.Size = new System.Drawing.Size(758, 242);
            this.answersPanel.TabIndex = 1;
            // 
            // answersLabel
            // 
            this.answersLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.answersLabel.Location = new System.Drawing.Point(0, 0);
            this.answersLabel.Name = "answersLabel";
            this.answersLabel.Size = new System.Drawing.Size(758, 23);
            this.answersLabel.TabIndex = 0;
            this.answersLabel.Text = "Варианты ответа:";
            // 
            // infoPanel
            // 
            this.infoPanel.ColumnCount = 3;
            this.infoPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.infoPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.infoPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.infoPanel.Controls.Add(this.finishButton, 2, 0);
            this.infoPanel.Controls.Add(this.numberLabel, 0, 0);
            this.infoPanel.Controls.Add(this.timerLabel, 1, 0);
            this.infoPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.infoPanel.Location = new System.Drawing.Point(0, 0);
            this.infoPanel.Name = "infoPanel";
            this.infoPanel.RowCount = 1;
            this.infoPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.infoPanel.Size = new System.Drawing.Size(760, 40);
            this.infoPanel.TabIndex = 3;
            // 
            // finishButton
            // 
            this.finishButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.finishButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.finishButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.finishButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this.finishButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(199)))), ((int)(((byte)(199)))));
            this.finishButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.finishButton.ForeColor = System.Drawing.Color.Maroon;
            this.finishButton.Image = global::QuizApp.Properties.Resources.exit;
            this.finishButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.finishButton.Location = new System.Drawing.Point(509, 3);
            this.finishButton.Name = "finishButton";
            this.finishButton.Size = new System.Drawing.Size(248, 34);
            this.finishButton.TabIndex = 1;
            this.finishButton.Text = "Завершить тестирование";
            this.finishButton.UseVisualStyleBackColor = false;
            // 
            // numberLabel
            // 
            this.numberLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numberLabel.Location = new System.Drawing.Point(3, 0);
            this.numberLabel.Name = "numberLabel";
            this.numberLabel.Size = new System.Drawing.Size(247, 40);
            this.numberLabel.TabIndex = 2;
            this.numberLabel.Text = "Вопрос 1/9999";
            this.numberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timerLabel
            // 
            this.timerLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.timerLabel.Image = global::QuizApp.Properties.Resources.clock;
            this.timerLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.timerLabel.Location = new System.Drawing.Point(256, 0);
            this.timerLabel.Name = "timerLabel";
            this.timerLabel.Size = new System.Drawing.Size(247, 40);
            this.timerLabel.TabIndex = 3;
            this.timerLabel.Text = "Прошло: 00:00:00";
            this.timerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // handlePanel
            // 
            this.handlePanel.ColumnCount = 3;
            this.handlePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.handlePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.handlePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.handlePanel.Controls.Add(this.nextButton, 2, 0);
            this.handlePanel.Controls.Add(this.prevButton, 1, 0);
            this.handlePanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.handlePanel.Location = new System.Drawing.Point(0, 497);
            this.handlePanel.Name = "handlePanel";
            this.handlePanel.RowCount = 1;
            this.handlePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.handlePanel.Size = new System.Drawing.Size(760, 40);
            this.handlePanel.TabIndex = 2;
            // 
            // nextButton
            // 
            this.nextButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(223)))), ((int)(((byte)(255)))));
            this.nextButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nextButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(127)))), ((int)(((byte)(159)))));
            this.nextButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(175)))), ((int)(((byte)(207)))));
            this.nextButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(199)))), ((int)(((byte)(231)))));
            this.nextButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nextButton.Image = global::QuizApp.Properties.Resources.arrow_right;
            this.nextButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.nextButton.Location = new System.Drawing.Point(509, 3);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(248, 34);
            this.nextButton.TabIndex = 0;
            this.nextButton.Text = "Следующий вопрос";
            this.nextButton.UseVisualStyleBackColor = false;
            // 
            // prevButton
            // 
            this.prevButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(223)))), ((int)(((byte)(255)))));
            this.prevButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prevButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(127)))), ((int)(((byte)(159)))));
            this.prevButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(175)))), ((int)(((byte)(207)))));
            this.prevButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(199)))), ((int)(((byte)(231)))));
            this.prevButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.prevButton.Image = global::QuizApp.Properties.Resources.arrow_left;
            this.prevButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.prevButton.Location = new System.Drawing.Point(256, 3);
            this.prevButton.Name = "prevButton";
            this.prevButton.Size = new System.Drawing.Size(247, 34);
            this.prevButton.TabIndex = 1;
            this.prevButton.Text = "Предыдущий вопрос";
            this.prevButton.UseVisualStyleBackColor = false;
            this.prevButton.Visible = false;
            // 
            // QuestionForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.formPanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "QuestionForm";
            this.Text = "Тестирование";
            this.formPanel.ResumeLayout(false);
            this.contentSplitContainer.Panel1.ResumeLayout(false);
            this.contentSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.contentSplitContainer)).EndInit();
            this.contentSplitContainer.ResumeLayout(false);
            this.infoPanel.ResumeLayout(false);
            this.handlePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button finishButton;
        private System.Windows.Forms.Panel formPanel;
        private System.Windows.Forms.TableLayoutPanel infoPanel;
        private System.Windows.Forms.TableLayoutPanel handlePanel;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Button prevButton;
        private System.Windows.Forms.Label numberLabel;
        private System.Windows.Forms.Label timerLabel;
        private System.Windows.Forms.SplitContainer contentSplitContainer;
        private System.Windows.Forms.RichTextBox descriptionTextBox;
        private System.Windows.Forms.Panel answersPanel;
        private System.Windows.Forms.Label answersLabel;
    }
}