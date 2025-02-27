namespace Calculator_Windows;

partial class Form1
{
    private System.ComponentModel.IContainer components = null;
    private TextBox displayTextBox;
    private TableLayoutPanel buttonPanel;
    private Button[] numberButtons;
    private Button addButton;
    private Button subtractButton;
    private Button multiplyButton;
    private Button divideButton;
    private Button equalsButton;
    private Button clearButton;
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code>
    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(280, 380);
        this.Text = "计算器";
        this.MinimizeBox = false;
        this.MaximizeBox = false;
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.StartPosition = FormStartPosition.CenterScreen;

        displayTextBox = new TextBox
        {
            Dock = DockStyle.Top,
            Height = 50,
            Font = new Font("Arial", 24F),
            TextAlign = HorizontalAlignment.Right,
            ReadOnly = true,
            Margin = new Padding(5),
            Text = "0"
        };

        buttonPanel = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            RowCount = 4,
            ColumnCount = 4,
            Padding = new Padding(3),
            Margin = new Padding(3)
        };

        for (int i = 0; i < 4; i++)
        {
            buttonPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            buttonPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        }

        numberButtons = new Button[10];
        for (int i = 0; i < 10; i++)
        {
            numberButtons[i] = new Button
            {
                Text = i.ToString(),
                Dock = DockStyle.Fill,
                Font = new Font("Arial", 14F, FontStyle.Bold),
                Margin = new Padding(2),
                BackColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                UseVisualStyleBackColor = false
            };
        }

        addButton = CreateOperatorButton("+");
        subtractButton = CreateOperatorButton("-");
        multiplyButton = CreateOperatorButton("×");
        divideButton = CreateOperatorButton("÷");
        equalsButton = CreateOperatorButton("=");
        clearButton = CreateOperatorButton("C");

        equalsButton.BackColor = Color.LightSkyBlue;
        clearButton.BackColor = Color.LightPink;
        
        foreach (var btn in new[] { addButton, subtractButton, multiplyButton, divideButton })
        {
            btn.BackColor = Color.LightGray;
        }

        TableLayoutPanel mainPanel = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            RowCount = 2,
            ColumnCount = 1,
            Padding = new Padding(3)
        };

        mainPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
        mainPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

        mainPanel.Controls.Add(displayTextBox, 0, 0);
        mainPanel.Controls.Add(buttonPanel, 0, 1);

        this.Controls.Add(mainPanel);

        ArrangeButtons();
    }

    private Button CreateOperatorButton(string text)
    {
        return new Button
        {
            Text = text,
            Dock = DockStyle.Fill,
            Font = new Font("Arial", 14F, FontStyle.Bold),
            Margin = new Padding(2),
            FlatStyle = FlatStyle.Flat,
            UseVisualStyleBackColor = false
        };
    }

    private void ArrangeButtons()
    {
        buttonPanel.Controls.Add(numberButtons[7], 0, 0);
        buttonPanel.Controls.Add(numberButtons[8], 1, 0);
        buttonPanel.Controls.Add(numberButtons[9], 2, 0);
        buttonPanel.Controls.Add(divideButton, 3, 0);

        buttonPanel.Controls.Add(numberButtons[4], 0, 1);
        buttonPanel.Controls.Add(numberButtons[5], 1, 1);
        buttonPanel.Controls.Add(numberButtons[6], 2, 1);
        buttonPanel.Controls.Add(multiplyButton, 3, 1);

        buttonPanel.Controls.Add(numberButtons[1], 0, 2);
        buttonPanel.Controls.Add(numberButtons[2], 1, 2);
        buttonPanel.Controls.Add(numberButtons[3], 2, 2);
        buttonPanel.Controls.Add(subtractButton, 3, 2);

        buttonPanel.Controls.Add(numberButtons[0], 0, 3);
        buttonPanel.Controls.Add(clearButton, 1, 3);
        buttonPanel.Controls.Add(equalsButton, 2, 3);
        buttonPanel.Controls.Add(addButton, 3, 3);
    }

    #endregion
}
