namespace QuizApp.View
{
    partial class MainForm
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
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.preparePage = new System.Windows.Forms.TabPage();
            this.descrQuizLabel = new System.Windows.Forms.Label();
            this.titleQuizLabel = new System.Windows.Forms.Label();
            this.handlePrepareTable = new System.Windows.Forms.TableLayoutPanel();
            this.startQuizButton = new System.Windows.Forms.Button();
            this.quizPage = new System.Windows.Forms.TabPage();
            this.quizSplitContainer = new System.Windows.Forms.SplitContainer();
            this.descrQuestionLabel = new System.Windows.Forms.Label();
            this.answerPanel = new System.Windows.Forms.Panel();
            this.answerLabel = new System.Windows.Forms.Label();
            this.handleQuizTable = new System.Windows.Forms.TableLayoutPanel();
            this.nextQuestionButton = new System.Windows.Forms.Button();
            this.backQuestionButton = new System.Windows.Forms.Button();
            this.infoQuizTable = new System.Windows.Forms.TableLayoutPanel();
            this.finishQuizButton = new System.Windows.Forms.Button();
            this.quizCounterLabel = new System.Windows.Forms.Label();
            this.resultPage = new System.Windows.Forms.TabPage();
            this.MainTabControl.SuspendLayout();
            this.preparePage.SuspendLayout();
            this.handlePrepareTable.SuspendLayout();
            this.quizPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quizSplitContainer)).BeginInit();
            this.quizSplitContainer.Panel1.SuspendLayout();
            this.quizSplitContainer.Panel2.SuspendLayout();
            this.quizSplitContainer.SuspendLayout();
            this.handleQuizTable.SuspendLayout();
            this.infoQuizTable.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTabControl
            // 
            this.MainTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.MainTabControl.Controls.Add(this.preparePage);
            this.MainTabControl.Controls.Add(this.quizPage);
            this.MainTabControl.Controls.Add(this.resultPage);
            this.MainTabControl.Location = new System.Drawing.Point(12, 12);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(776, 537);
            this.MainTabControl.TabIndex = 0;
            // 
            // preparePage
            // 
            this.preparePage.Controls.Add(this.descrQuizLabel);
            this.preparePage.Controls.Add(this.titleQuizLabel);
            this.preparePage.Controls.Add(this.handlePrepareTable);
            this.preparePage.Location = new System.Drawing.Point(4, 29);
            this.preparePage.Name = "preparePage";
            this.preparePage.Padding = new System.Windows.Forms.Padding(3);
            this.preparePage.Size = new System.Drawing.Size(768, 504);
            this.preparePage.TabIndex = 0;
            this.preparePage.Text = "Вступление";
            this.preparePage.UseVisualStyleBackColor = true;
            // 
            // descrQuizLabel
            // 
            this.descrQuizLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.descrQuizLabel.Location = new System.Drawing.Point(3, 51);
            this.descrQuizLabel.Name = "descrQuizLabel";
            this.descrQuizLabel.Size = new System.Drawing.Size(762, 402);
            this.descrQuizLabel.TabIndex = 2;
            this.descrQuizLabel.Text = "Описание тестирования";
            // 
            // titleQuizLabel
            // 
            this.titleQuizLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleQuizLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.titleQuizLabel.Location = new System.Drawing.Point(3, 3);
            this.titleQuizLabel.Name = "titleQuizLabel";
            this.titleQuizLabel.Size = new System.Drawing.Size(762, 48);
            this.titleQuizLabel.TabIndex = 1;
            this.titleQuizLabel.Text = "Заголовок тестирования";
            this.titleQuizLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // handlePrepareTable
            // 
            this.handlePrepareTable.ColumnCount = 3;
            this.handlePrepareTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.handlePrepareTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.handlePrepareTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.handlePrepareTable.Controls.Add(this.startQuizButton, 1, 0);
            this.handlePrepareTable.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.handlePrepareTable.Location = new System.Drawing.Point(3, 453);
            this.handlePrepareTable.Name = "handlePrepareTable";
            this.handlePrepareTable.RowCount = 1;
            this.handlePrepareTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.handlePrepareTable.Size = new System.Drawing.Size(762, 48);
            this.handlePrepareTable.TabIndex = 0;
            // 
            // startQuizButton
            // 
            this.startQuizButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.startQuizButton.Location = new System.Drawing.Point(257, 3);
            this.startQuizButton.Name = "startQuizButton";
            this.startQuizButton.Size = new System.Drawing.Size(248, 42);
            this.startQuizButton.TabIndex = 0;
            this.startQuizButton.Text = "Перейти к тестированию";
            this.startQuizButton.UseVisualStyleBackColor = true;
            // 
            // quizPage
            // 
            this.quizPage.Controls.Add(this.quizSplitContainer);
            this.quizPage.Controls.Add(this.handleQuizTable);
            this.quizPage.Controls.Add(this.infoQuizTable);
            this.quizPage.Location = new System.Drawing.Point(4, 29);
            this.quizPage.Name = "quizPage";
            this.quizPage.Padding = new System.Windows.Forms.Padding(3);
            this.quizPage.Size = new System.Drawing.Size(768, 504);
            this.quizPage.TabIndex = 1;
            this.quizPage.Text = "Тестирование";
            this.quizPage.UseVisualStyleBackColor = true;
            // 
            // quizSplitContainer
            // 
            this.quizSplitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.quizSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.quizSplitContainer.Location = new System.Drawing.Point(3, 39);
            this.quizSplitContainer.Name = "quizSplitContainer";
            this.quizSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // quizSplitContainer.Panel1
            // 
            this.quizSplitContainer.Panel1.AutoScroll = true;
            this.quizSplitContainer.Panel1.Controls.Add(this.descrQuestionLabel);
            this.quizSplitContainer.Panel1MinSize = 128;
            // 
            // quizSplitContainer.Panel2
            // 
            this.quizSplitContainer.Panel2.Controls.Add(this.answerPanel);
            this.quizSplitContainer.Panel2.Controls.Add(this.answerLabel);
            this.quizSplitContainer.Panel2MinSize = 128;
            this.quizSplitContainer.Size = new System.Drawing.Size(762, 426);
            this.quizSplitContainer.SplitterDistance = 236;
            this.quizSplitContainer.TabIndex = 2;
            // 
            // descrQuestionLabel
            // 
            this.descrQuestionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.descrQuestionLabel.Location = new System.Drawing.Point(0, 0);
            this.descrQuestionLabel.Name = "descrQuestionLabel";
            this.descrQuestionLabel.Size = new System.Drawing.Size(760, 234);
            this.descrQuestionLabel.TabIndex = 1;
            this.descrQuestionLabel.Text = "Описание вопроса";
            // 
            // answerPanel
            // 
            this.answerPanel.AutoScroll = true;
            this.answerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.answerPanel.Location = new System.Drawing.Point(0, 20);
            this.answerPanel.Name = "answerPanel";
            this.answerPanel.Size = new System.Drawing.Size(760, 164);
            this.answerPanel.TabIndex = 1;
            // 
            // answerLabel
            // 
            this.answerLabel.AutoSize = true;
            this.answerLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.answerLabel.Location = new System.Drawing.Point(0, 0);
            this.answerLabel.Name = "answerLabel";
            this.answerLabel.Size = new System.Drawing.Size(147, 20);
            this.answerLabel.TabIndex = 0;
            this.answerLabel.Text = "Варианты ответа:";
            // 
            // handleQuizTable
            // 
            this.handleQuizTable.ColumnCount = 4;
            this.handleQuizTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.handleQuizTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.handleQuizTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.handleQuizTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.handleQuizTable.Controls.Add(this.nextQuestionButton, 3, 0);
            this.handleQuizTable.Controls.Add(this.backQuestionButton, 2, 0);
            this.handleQuizTable.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.handleQuizTable.Location = new System.Drawing.Point(3, 465);
            this.handleQuizTable.Name = "handleQuizTable";
            this.handleQuizTable.RowCount = 1;
            this.handleQuizTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.handleQuizTable.Size = new System.Drawing.Size(762, 36);
            this.handleQuizTable.TabIndex = 1;
            // 
            // nextQuestionButton
            // 
            this.nextQuestionButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nextQuestionButton.Location = new System.Drawing.Point(573, 3);
            this.nextQuestionButton.Name = "nextQuestionButton";
            this.nextQuestionButton.Size = new System.Drawing.Size(186, 30);
            this.nextQuestionButton.TabIndex = 1;
            this.nextQuestionButton.Text = "Следующий вопрос";
            this.nextQuestionButton.UseVisualStyleBackColor = true;
            // 
            // backQuestionButton
            // 
            this.backQuestionButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.backQuestionButton.Location = new System.Drawing.Point(383, 3);
            this.backQuestionButton.Name = "backQuestionButton";
            this.backQuestionButton.Size = new System.Drawing.Size(184, 30);
            this.backQuestionButton.TabIndex = 0;
            this.backQuestionButton.Text = "Предыдущий вопрос";
            this.backQuestionButton.UseVisualStyleBackColor = true;
            // 
            // infoQuizTable
            // 
            this.infoQuizTable.ColumnCount = 4;
            this.infoQuizTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.infoQuizTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.infoQuizTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.infoQuizTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.infoQuizTable.Controls.Add(this.finishQuizButton, 3, 0);
            this.infoQuizTable.Controls.Add(this.quizCounterLabel, 0, 0);
            this.infoQuizTable.Dock = System.Windows.Forms.DockStyle.Top;
            this.infoQuizTable.Location = new System.Drawing.Point(3, 3);
            this.infoQuizTable.Name = "infoQuizTable";
            this.infoQuizTable.RowCount = 1;
            this.infoQuizTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.infoQuizTable.Size = new System.Drawing.Size(762, 36);
            this.infoQuizTable.TabIndex = 3;
            // 
            // finishQuizButton
            // 
            this.finishQuizButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.finishQuizButton.Location = new System.Drawing.Point(573, 3);
            this.finishQuizButton.Name = "finishQuizButton";
            this.finishQuizButton.Size = new System.Drawing.Size(186, 30);
            this.finishQuizButton.TabIndex = 1;
            this.finishQuizButton.Text = "Завершить тестирование";
            this.finishQuizButton.UseVisualStyleBackColor = true;
            // 
            // quizCounterLabel
            // 
            this.quizCounterLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.quizCounterLabel.Location = new System.Drawing.Point(3, 0);
            this.quizCounterLabel.Name = "quizCounterLabel";
            this.quizCounterLabel.Size = new System.Drawing.Size(184, 36);
            this.quizCounterLabel.TabIndex = 2;
            this.quizCounterLabel.Text = "Вопрос №1";
            this.quizCounterLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // resultPage
            // 
            this.resultPage.Location = new System.Drawing.Point(4, 22);
            this.resultPage.Name = "resultPage";
            this.resultPage.Size = new System.Drawing.Size(768, 511);
            this.resultPage.TabIndex = 2;
            this.resultPage.Text = "Результат";
            this.resultPage.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(800, 561);
            this.Controls.Add(this.MainTabControl);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.Text = "Тестирование";
            this.MainTabControl.ResumeLayout(false);
            this.preparePage.ResumeLayout(false);
            this.handlePrepareTable.ResumeLayout(false);
            this.quizPage.ResumeLayout(false);
            this.quizSplitContainer.Panel1.ResumeLayout(false);
            this.quizSplitContainer.Panel2.ResumeLayout(false);
            this.quizSplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quizSplitContainer)).EndInit();
            this.quizSplitContainer.ResumeLayout(false);
            this.handleQuizTable.ResumeLayout(false);
            this.infoQuizTable.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl MainTabControl;
        private System.Windows.Forms.TabPage preparePage;
        private System.Windows.Forms.TabPage quizPage;
        private System.Windows.Forms.TabPage resultPage;
        private System.Windows.Forms.Label descrQuizLabel;
        private System.Windows.Forms.Label titleQuizLabel;
        private System.Windows.Forms.TableLayoutPanel handlePrepareTable;
        private System.Windows.Forms.Button startQuizButton;
        private System.Windows.Forms.TableLayoutPanel handleQuizTable;
        private System.Windows.Forms.Button backQuestionButton;
        private System.Windows.Forms.Button nextQuestionButton;
        private System.Windows.Forms.SplitContainer quizSplitContainer;
        private System.Windows.Forms.TableLayoutPanel infoQuizTable;
        private System.Windows.Forms.Button finishQuizButton;
        private System.Windows.Forms.Label descrQuestionLabel;
        private System.Windows.Forms.Panel answerPanel;
        private System.Windows.Forms.Label answerLabel;
        private System.Windows.Forms.Label quizCounterLabel;
    }
}