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
            this.finishButton = new System.Windows.Forms.Button();
            this.formPanel = new System.Windows.Forms.Panel();
            this.contentSplitContainer = new System.Windows.Forms.SplitContainer();
            this.descriptionTextBox = new System.Windows.Forms.RichTextBox();
            this.answersPanel = new System.Windows.Forms.Panel();
            this.answersLabel = new System.Windows.Forms.Label();
            this.infoPanel = new System.Windows.Forms.TableLayoutPanel();
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
            // finishButton
            // 
            this.finishButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.finishButton.ForeColor = System.Drawing.Color.Maroon;
            this.finishButton.Location = new System.Drawing.Point(509, 3);
            this.finishButton.Name = "finishButton";
            this.finishButton.Size = new System.Drawing.Size(248, 34);
            this.finishButton.TabIndex = 1;
            this.finishButton.Text = "Завершить тестирование";
            this.finishButton.UseVisualStyleBackColor = true;
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
            this.descriptionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.descriptionTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.descriptionTextBox.Location = new System.Drawing.Point(0, 0);
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.ReadOnly = true;
            this.descriptionTextBox.Size = new System.Drawing.Size(760, 186);
            this.descriptionTextBox.TabIndex = 0;
            this.descriptionTextBox.Text = "";
            // 
            // answersPanel
            // 
            this.answersPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.answersPanel.Location = new System.Drawing.Point(0, 23);
            this.answersPanel.Name = "answersPanel";
            this.answersPanel.Size = new System.Drawing.Size(760, 244);
            this.answersPanel.TabIndex = 1;
            // 
            // answersLabel
            // 
            this.answersLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.answersLabel.Location = new System.Drawing.Point(0, 0);
            this.answersLabel.Name = "answersLabel";
            this.answersLabel.Size = new System.Drawing.Size(760, 23);
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
            this.timerLabel.Location = new System.Drawing.Point(256, 0);
            this.timerLabel.Name = "timerLabel";
            this.timerLabel.Size = new System.Drawing.Size(247, 40);
            this.timerLabel.TabIndex = 3;
            this.timerLabel.Text = "Прошло: 00:00:00";
            this.timerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.nextButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nextButton.Location = new System.Drawing.Point(509, 3);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(248, 34);
            this.nextButton.TabIndex = 0;
            this.nextButton.Text = "Следующий вопрос";
            this.nextButton.UseVisualStyleBackColor = true;
            // 
            // prevButton
            // 
            this.prevButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prevButton.Location = new System.Drawing.Point(256, 3);
            this.prevButton.Name = "prevButton";
            this.prevButton.Size = new System.Drawing.Size(247, 34);
            this.prevButton.TabIndex = 1;
            this.prevButton.Text = "Предыдущий вопрос";
            this.prevButton.UseVisualStyleBackColor = true;
            // 
            // QuestionForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.formPanel);
            this.DoubleBuffered = true;
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