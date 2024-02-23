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
            this.descrQuizPanel = new System.Windows.Forms.Panel();
            this.maxQuestionsLabel = new System.Windows.Forms.Label();
            this.descrQuizLabel = new System.Windows.Forms.Label();
            this.authorQuizLabel = new System.Windows.Forms.Label();
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
            this.prevQuestionButton = new System.Windows.Forms.Button();
            this.infoQuizTable = new System.Windows.Forms.TableLayoutPanel();
            this.finishQuizButton = new System.Windows.Forms.Button();
            this.counterQuizLabel = new System.Windows.Forms.Label();
            this.resultPage = new System.Windows.Forms.TabPage();
            this.descrResultPanel = new System.Windows.Forms.Panel();
            this.descrResultLabel = new System.Windows.Forms.Label();
            this.titleResultLabel = new System.Windows.Forms.Label();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainTabControl.SuspendLayout();
            this.preparePage.SuspendLayout();
            this.descrQuizPanel.SuspendLayout();
            this.handlePrepareTable.SuspendLayout();
            this.quizPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quizSplitContainer)).BeginInit();
            this.quizSplitContainer.Panel1.SuspendLayout();
            this.quizSplitContainer.Panel2.SuspendLayout();
            this.quizSplitContainer.SuspendLayout();
            this.handleQuizTable.SuspendLayout();
            this.infoQuizTable.SuspendLayout();
            this.resultPage.SuspendLayout();
            this.descrResultPanel.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTabControl
            // 
            this.MainTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.MainTabControl.Controls.Add(this.preparePage);
            this.MainTabControl.Controls.Add(this.quizPage);
            this.MainTabControl.Controls.Add(this.resultPage);
            this.MainTabControl.Location = new System.Drawing.Point(12, 27);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(776, 509);
            this.MainTabControl.TabIndex = 0;
            // 
            // preparePage
            // 
            this.preparePage.Controls.Add(this.descrQuizPanel);
            this.preparePage.Controls.Add(this.titleQuizLabel);
            this.preparePage.Controls.Add(this.handlePrepareTable);
            this.preparePage.Location = new System.Drawing.Point(4, 27);
            this.preparePage.Name = "preparePage";
            this.preparePage.Padding = new System.Windows.Forms.Padding(3);
            this.preparePage.Size = new System.Drawing.Size(768, 506);
            this.preparePage.TabIndex = 0;
            this.preparePage.Text = "Вступление";
            this.preparePage.UseVisualStyleBackColor = true;
            // 
            // descrQuizPanel
            // 
            this.descrQuizPanel.Controls.Add(this.maxQuestionsLabel);
            this.descrQuizPanel.Controls.Add(this.descrQuizLabel);
            this.descrQuizPanel.Controls.Add(this.authorQuizLabel);
            this.descrQuizPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.descrQuizPanel.Location = new System.Drawing.Point(3, 51);
            this.descrQuizPanel.Name = "descrQuizPanel";
            this.descrQuizPanel.Padding = new System.Windows.Forms.Padding(8);
            this.descrQuizPanel.Size = new System.Drawing.Size(762, 404);
            this.descrQuizPanel.TabIndex = 5;
            // 
            // maxQuestionsLabel
            // 
            this.maxQuestionsLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.maxQuestionsLabel.Location = new System.Drawing.Point(8, 360);
            this.maxQuestionsLabel.Name = "maxQuestionsLabel";
            this.maxQuestionsLabel.Size = new System.Drawing.Size(746, 18);
            this.maxQuestionsLabel.TabIndex = 3;
            this.maxQuestionsLabel.Text = "Всего вопросов: 0";
            // 
            // descrQuizLabel
            // 
            this.descrQuizLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.descrQuizLabel.Location = new System.Drawing.Point(8, 8);
            this.descrQuizLabel.Name = "descrQuizLabel";
            this.descrQuizLabel.Size = new System.Drawing.Size(746, 370);
            this.descrQuizLabel.TabIndex = 2;
            this.descrQuizLabel.Text = "Описание тестирования";
            // 
            // authorQuizLabel
            // 
            this.authorQuizLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.authorQuizLabel.Location = new System.Drawing.Point(8, 378);
            this.authorQuizLabel.Name = "authorQuizLabel";
            this.authorQuizLabel.Size = new System.Drawing.Size(746, 18);
            this.authorQuizLabel.TabIndex = 4;
            this.authorQuizLabel.Text = "Автор тестирования: Неизвестный";
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
            this.handlePrepareTable.Location = new System.Drawing.Point(3, 455);
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
            this.quizPage.Location = new System.Drawing.Point(4, 22);
            this.quizPage.Name = "quizPage";
            this.quizPage.Padding = new System.Windows.Forms.Padding(3);
            this.quizPage.Size = new System.Drawing.Size(768, 511);
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
            this.quizSplitContainer.Panel1.Padding = new System.Windows.Forms.Padding(8);
            this.quizSplitContainer.Panel1MinSize = 128;
            // 
            // quizSplitContainer.Panel2
            // 
            this.quizSplitContainer.Panel2.Controls.Add(this.answerPanel);
            this.quizSplitContainer.Panel2.Controls.Add(this.answerLabel);
            this.quizSplitContainer.Panel2.Padding = new System.Windows.Forms.Padding(8);
            this.quizSplitContainer.Panel2MinSize = 128;
            this.quizSplitContainer.Size = new System.Drawing.Size(762, 433);
            this.quizSplitContainer.SplitterDistance = 238;
            this.quizSplitContainer.TabIndex = 2;
            // 
            // descrQuestionLabel
            // 
            this.descrQuestionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.descrQuestionLabel.Location = new System.Drawing.Point(8, 8);
            this.descrQuestionLabel.Name = "descrQuestionLabel";
            this.descrQuestionLabel.Size = new System.Drawing.Size(744, 220);
            this.descrQuestionLabel.TabIndex = 1;
            this.descrQuestionLabel.Text = "Описание вопроса";
            // 
            // answerPanel
            // 
            this.answerPanel.AutoScroll = true;
            this.answerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.answerPanel.Location = new System.Drawing.Point(8, 26);
            this.answerPanel.Margin = new System.Windows.Forms.Padding(4);
            this.answerPanel.Name = "answerPanel";
            this.answerPanel.Size = new System.Drawing.Size(744, 155);
            this.answerPanel.TabIndex = 1;
            // 
            // answerLabel
            // 
            this.answerLabel.AutoSize = true;
            this.answerLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.answerLabel.Location = new System.Drawing.Point(8, 8);
            this.answerLabel.Name = "answerLabel";
            this.answerLabel.Size = new System.Drawing.Size(131, 18);
            this.answerLabel.TabIndex = 0;
            this.answerLabel.Text = "Варианты ответа:";
            // 
            // handleQuizTable
            // 
            this.handleQuizTable.ColumnCount = 3;
            this.handleQuizTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.handleQuizTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.handleQuizTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.handleQuizTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.handleQuizTable.Controls.Add(this.nextQuestionButton, 2, 0);
            this.handleQuizTable.Controls.Add(this.prevQuestionButton, 1, 0);
            this.handleQuizTable.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.handleQuizTable.Location = new System.Drawing.Point(3, 472);
            this.handleQuizTable.Name = "handleQuizTable";
            this.handleQuizTable.RowCount = 1;
            this.handleQuizTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.handleQuizTable.Size = new System.Drawing.Size(762, 36);
            this.handleQuizTable.TabIndex = 1;
            // 
            // nextQuestionButton
            // 
            this.nextQuestionButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nextQuestionButton.Location = new System.Drawing.Point(511, 3);
            this.nextQuestionButton.Name = "nextQuestionButton";
            this.nextQuestionButton.Size = new System.Drawing.Size(248, 30);
            this.nextQuestionButton.TabIndex = 1;
            this.nextQuestionButton.Text = "Следующий вопрос";
            this.nextQuestionButton.UseVisualStyleBackColor = true;
            // 
            // prevQuestionButton
            // 
            this.prevQuestionButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prevQuestionButton.Location = new System.Drawing.Point(257, 3);
            this.prevQuestionButton.Name = "prevQuestionButton";
            this.prevQuestionButton.Size = new System.Drawing.Size(248, 30);
            this.prevQuestionButton.TabIndex = 0;
            this.prevQuestionButton.Text = "Предыдущий вопрос";
            this.prevQuestionButton.UseVisualStyleBackColor = true;
            // 
            // infoQuizTable
            // 
            this.infoQuizTable.ColumnCount = 4;
            this.infoQuizTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.infoQuizTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.infoQuizTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.infoQuizTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.infoQuizTable.Controls.Add(this.finishQuizButton, 3, 0);
            this.infoQuizTable.Controls.Add(this.counterQuizLabel, 0, 0);
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
            this.finishQuizButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.finishQuizButton.ForeColor = System.Drawing.Color.Maroon;
            this.finishQuizButton.Location = new System.Drawing.Point(573, 3);
            this.finishQuizButton.Name = "finishQuizButton";
            this.finishQuizButton.Size = new System.Drawing.Size(186, 30);
            this.finishQuizButton.TabIndex = 1;
            this.finishQuizButton.Text = "Завершить тестирование";
            this.finishQuizButton.UseVisualStyleBackColor = true;
            // 
            // counterQuizLabel
            // 
            this.counterQuizLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.counterQuizLabel.Location = new System.Drawing.Point(3, 0);
            this.counterQuizLabel.Name = "counterQuizLabel";
            this.counterQuizLabel.Size = new System.Drawing.Size(184, 36);
            this.counterQuizLabel.TabIndex = 2;
            this.counterQuizLabel.Text = "Вопрос №1";
            this.counterQuizLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // resultPage
            // 
            this.resultPage.Controls.Add(this.descrResultPanel);
            this.resultPage.Controls.Add(this.titleResultLabel);
            this.resultPage.Location = new System.Drawing.Point(4, 27);
            this.resultPage.Name = "resultPage";
            this.resultPage.Padding = new System.Windows.Forms.Padding(3);
            this.resultPage.Size = new System.Drawing.Size(768, 478);
            this.resultPage.TabIndex = 2;
            this.resultPage.Text = "Результат";
            this.resultPage.UseVisualStyleBackColor = true;
            // 
            // descrResultPanel
            // 
            this.descrResultPanel.Controls.Add(this.descrResultLabel);
            this.descrResultPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.descrResultPanel.Location = new System.Drawing.Point(3, 51);
            this.descrResultPanel.Name = "descrResultPanel";
            this.descrResultPanel.Padding = new System.Windows.Forms.Padding(8);
            this.descrResultPanel.Size = new System.Drawing.Size(762, 424);
            this.descrResultPanel.TabIndex = 3;
            // 
            // descrResultLabel
            // 
            this.descrResultLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.descrResultLabel.Location = new System.Drawing.Point(8, 8);
            this.descrResultLabel.Name = "descrResultLabel";
            this.descrResultLabel.Size = new System.Drawing.Size(746, 408);
            this.descrResultLabel.TabIndex = 0;
            this.descrResultLabel.Text = "Описание результата тестирования";
            // 
            // titleResultLabel
            // 
            this.titleResultLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleResultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.titleResultLabel.Location = new System.Drawing.Point(3, 3);
            this.titleResultLabel.Name = "titleResultLabel";
            this.titleResultLabel.Size = new System.Drawing.Size(762, 48);
            this.titleResultLabel.TabIndex = 2;
            this.titleResultLabel.Text = "Результаты тестирования";
            this.titleResultLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 539);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(800, 22);
            this.statusStrip.TabIndex = 1;
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(45, 17);
            this.toolStripStatusLabel.Text = "Готово";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(800, 24);
            this.menuStrip.TabIndex = 2;
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.aboutToolStripMenuItem.Text = "О программе";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.fileToolStripMenuItem.Text = "Файл";
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.quitToolStripMenuItem.Text = "Выход";
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(800, 561);
            this.Controls.Add(this.MainTabControl);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.Text = "Тестирование";
            this.MainTabControl.ResumeLayout(false);
            this.preparePage.ResumeLayout(false);
            this.descrQuizPanel.ResumeLayout(false);
            this.handlePrepareTable.ResumeLayout(false);
            this.quizPage.ResumeLayout(false);
            this.quizSplitContainer.Panel1.ResumeLayout(false);
            this.quizSplitContainer.Panel2.ResumeLayout(false);
            this.quizSplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quizSplitContainer)).EndInit();
            this.quizSplitContainer.ResumeLayout(false);
            this.handleQuizTable.ResumeLayout(false);
            this.infoQuizTable.ResumeLayout(false);
            this.resultPage.ResumeLayout(false);
            this.descrResultPanel.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Button prevQuestionButton;
        private System.Windows.Forms.Button nextQuestionButton;
        private System.Windows.Forms.SplitContainer quizSplitContainer;
        private System.Windows.Forms.TableLayoutPanel infoQuizTable;
        private System.Windows.Forms.Button finishQuizButton;
        private System.Windows.Forms.Label descrQuestionLabel;
        private System.Windows.Forms.Panel answerPanel;
        private System.Windows.Forms.Label answerLabel;
        private System.Windows.Forms.Label counterQuizLabel;
        private System.Windows.Forms.Label maxQuestionsLabel;
        private System.Windows.Forms.Label authorQuizLabel;
        private System.Windows.Forms.Panel descrQuizPanel;
        private System.Windows.Forms.Panel descrResultPanel;
        private System.Windows.Forms.Label descrResultLabel;
        private System.Windows.Forms.Label titleResultLabel;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
    }
}