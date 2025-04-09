using System;
using System.Diagnostics;
using System.Runtime.InteropServices.ObjectiveC;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace OrderManagement_Win;

public partial class Form1 : Form
{
    private OrderService orderService;
    private DataGridView dataGridView;
    private TextBox txtId;
    private TextBox txtCustomer;
    private TextBox txtAmount;
    private DateTimePicker dtpOrderDate;
    private Button btnAdd;
    private Button btnDelete;
    private Button btnUpdate;
    private Button btnQuery;
    private void InitializeControls(){
        this.Text = "订单管理系统";
        this.Size = new System.Drawing.Size(800, 600);
        this.MinimumSize = new System.Drawing.Size(600, 400);
        dataGridView = new DataGridView{
            Location = new System.Drawing.Point(20, 20),
            Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom,
            Size = new System.Drawing.Size(this.ClientSize.Width - 40, (int)(this.ClientSize.Height * 0.6)),
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
            AllowUserToAddRows = false,
            AllowUserToDeleteRows = false,
            ReadOnly = true,
            RowHeadersVisible = false
        };
        dataGridView.Columns.Clear();
        dataGridView.Columns.Add(new DataGridViewTextBoxColumn {Name = "Id", HeaderText = "订单ID"});
        dataGridView.Columns.Add(new DataGridViewTextBoxColumn {Name = "Customer", HeaderText = "客户名"});
        dataGridView.Columns.Add(new DataGridViewTextBoxColumn {Name = "Amount", HeaderText = "金额"});
        dataGridView.Columns.Add(new DataGridViewTextBoxColumn {Name = "OrderDate", HeaderText = "日期"});
        dataGridView.Columns["Id"].FillWeight = 15;
        dataGridView.Columns["Customer"].FillWeight = 30;
        dataGridView.Columns["Amount"].FillWeight = 20;
        dataGridView.Columns["OrderDate"].FillWeight = 35;
        dataGridView.Columns["Id"].MinimumWidth = 150;
        dataGridView.Columns["Customer"].MinimumWidth = 200;
        dataGridView.Columns["Amount"].MinimumWidth = 180;
        dataGridView.Columns["OrderDate"].MinimumWidth = 230;
        dataGridView.Columns["OrderDate"].DefaultCellStyle.Format = "yyyy/MM/dd";
        this.Controls.Add(dataGridView);
        int yOffset = dataGridView.Bottom + 20;
        int xLabel = 20;
        int xInput = 100;
        int inputWidth = 200;
        int labelWidth = 80;
        var lblId = new Label{
            Text = "订单ID:", 
            Location = new System.Drawing.Point(xLabel, yOffset + 5),
            Size = new System.Drawing.Size(labelWidth, 20),
            Anchor = AnchorStyles.Left | AnchorStyles.Top
        };
        txtId = new TextBox{
            Location = new System.Drawing.Point(xInput, yOffset),
            Size = new System.Drawing.Size(inputWidth, 20),
            Anchor = AnchorStyles.Left | AnchorStyles.Top    
        };
        this.Controls.Add(lblId);
        this.Controls.Add(txtId);
        yOffset += 30;
        var lblCustomer = new Label{
            Text = "客户名:",
            Location = new System.Drawing.Point(xLabel, yOffset + 5),
            Size = new System.Drawing.Size(labelWidth, 20),
            Anchor = AnchorStyles.Left | AnchorStyles.Top
        };
        txtCustomer = new TextBox{
            Location = new System.Drawing.Point(xInput, yOffset),
            Size = new System.Drawing.Size(inputWidth, 20),
            Anchor = AnchorStyles.Left | AnchorStyles.Top
        };
        this.Controls.Add(lblCustomer);
        this.Controls.Add(txtCustomer);
        yOffset += 30;
        var lblAmount = new Label{
            Text = "金额:",
            Location = new System.Drawing.Point(xLabel, yOffset + 5),
            Size = new System.Drawing.Size(labelWidth, 20),
            Anchor = AnchorStyles.Left | AnchorStyles.Top
        };
        txtAmount = new TextBox{
            Location = new System.Drawing.Point(xInput, yOffset),
            Size = new System.Drawing.Size(inputWidth, 20),
            Anchor = AnchorStyles.Left | AnchorStyles.Top
        };
        this.Controls.Add(lblAmount);
        this.Controls.Add(txtAmount);
        yOffset += 30;
        var lblOrderDate = new Label{
            Text = "日期:",
            Location = new System.Drawing.Point(xLabel, yOffset + 5),
            Size = new System.Drawing.Size(labelWidth, 20),
            Anchor = AnchorStyles.Left | AnchorStyles.Top
        };
        dtpOrderDate = new DateTimePicker{
            Location = new System.Drawing.Point(xInput, yOffset),
            Size = new System.Drawing.Size(inputWidth, 20),
            Anchor = AnchorStyles.Left | AnchorStyles.Top,
            Format = DateTimePickerFormat.Custom,
            CustomFormat = "yyyy/MM/dd"
        };
        this.Controls.Add(lblOrderDate);
        this.Controls.Add(dtpOrderDate);
        yOffset += 40;
        int buttonWidth = 120;
        int buttonHeight = 30;
        int buttonSpacing = 20;
        int buttonX = (this.ClientSize.Width - (4 * buttonWidth + 3 * buttonSpacing)) / 2;
        btnAdd = new Button{
            Text = "添加",
            Location = new System.Drawing.Point(buttonX, yOffset),
            Size = new System.Drawing.Size(buttonWidth, buttonHeight),
            Anchor = AnchorStyles.Top
        };
        buttonX += buttonWidth + buttonSpacing;
        btnDelete = new Button{
            Text = "删除",
            Location = new System.Drawing.Point(buttonX,yOffset),
            Size = new System.Drawing.Size(buttonWidth, buttonHeight),
            Anchor = AnchorStyles.Top
        };
        buttonX += buttonWidth + buttonSpacing;
        btnUpdate = new Button{
            Text = "更新",
            Location = new System.Drawing.Point(buttonX, yOffset),
            Size = new System.Drawing.Size(buttonWidth, buttonHeight),
            Anchor = AnchorStyles.Top
        };
        buttonX += buttonWidth + buttonSpacing;
        btnQuery = new Button{
            Text = "查询",
            Location = new System.Drawing.Point(buttonX, yOffset),
            Size = new System.Drawing.Size(buttonWidth, buttonHeight),
            Anchor = AnchorStyles.Top
        };
        btnAdd.Click += BtnAdd_Click;   
        btnDelete.Click += BtnDelete_Click;
        btnUpdate.Click += BtnUpdate_Click;
        btnQuery.Click += BtnQuery_Click;
        this.Controls.Add(btnAdd);
        this.Controls.Add(btnDelete);
        this.Controls.Add(btnUpdate);
        this.Controls.Add(btnQuery);
        this.Resize += (s, e) => {
            dataGridView.Size = new System.Drawing.Size(this.ClientSize.Width - 40, (int)(this.ClientSize.Height * 0.6));
            buttonX = (this.ClientSize.Width - (4 * buttonWidth + 3 * buttonSpacing)) / 2;
            btnAdd.Location = new System.Drawing.Point(buttonX, btnAdd.Location.Y);
            buttonX += buttonWidth + buttonSpacing;
            btnDelete.Location = new System.Drawing.Point(buttonX, btnDelete.Location.Y);
            buttonX += buttonWidth + buttonSpacing;
            btnUpdate.Location = new System.Drawing.Point(buttonX, btnUpdate.Location.Y);
            buttonX += buttonWidth + buttonSpacing;
            btnQuery.Location = new System.Drawing.Point(buttonX, btnQuery.Location.Y);
        };
    }
    private void RefreshDataGridView(){
        dataGridView.DataSource = null;
        dataGridView.DataSource = orderService.GetAllOrders();
        if(dataGridView.Columns.Count > 0){
            dataGridView.Columns["Id"].DataPropertyName = "Id";
            dataGridView.Columns["Customer"].DataPropertyName = "Customer";
            dataGridView.Columns["Amount"].DataPropertyName = "Amount";
            dataGridView.Columns["OrderDate"].DataPropertyName = "OrderDate";
        }
    }
    private void BtnAdd_Click(object sender, EventArgs e){
        try{
            int id = int.Parse(txtId.Text);
            string customer = txtCustomer.Text;
            double amount = double.Parse(txtAmount.Text);
            DateTime orderDate = dtpOrderDate.Value;
            var order = new Order(id, customer, amount, orderDate);
            orderService.AddOrder(order);
            RefreshDataGridView();
            MessageBox.Show("成功添加!");
        }
        catch(Exception ex){
            MessageBox.Show($"添加失败:{ex.Message}");
        }
    }
    private void BtnDelete_Click(object sender, EventArgs e){
        try{
            int id = int.Parse(txtId.Text);
            orderService.DeleteOrder(id);
            RefreshDataGridView();
            MessageBox.Show("成功删除!");
        }
        catch(Exception ex){
            MessageBox.Show($"删除失败:{ex.Message}");
        }
    }
    private void BtnUpdate_Click(object sender, EventArgs e){
        try{
            int id = int.Parse(txtId.Text);
            string customer = txtCustomer.Text;
            double amount = double.Parse(txtAmount.Text);
            DateTime orderDate = dtpOrderDate.Value;
            var updateOrder = new Order(id, customer, amount, orderDate);
            orderService.UpdateOrder(updateOrder);
            RefreshDataGridView();
            MessageBox.Show("成功更新!");
        }
        catch(Exception ex){
            MessageBox.Show($"更新失败:{ex.Message}");
        }
    }
    private void BtnQuery_Click(object sender, EventArgs e){
        try{
            int id = int.Parse(txtId.Text);
            var order = orderService.GetOrderById(id);
            if(order != null){
                txtCustomer.Text = order.Customer;
                txtAmount.Text = order.Amount.ToString();
                dtpOrderDate.Value = order.OrderDate;
                MessageBox.Show("成功查询!");
            }else{
                MessageBox.Show("订单不存在!");
            }
        }
        catch(Exception ex){
            MessageBox.Show($"查询失败:{ex.Message}");
        }
    }
    public Form1()
    {
        InitializeComponent();
        orderService = new OrderService();
        InitializeControls();
        RefreshDataGridView();
    }
}
