namespace ClothingSystem.GUI
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.TextBox txtSize;
        private System.Windows.Forms.TextBox txtColor;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.ListBox lstItems;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.Label lblPrice;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            txtName = new TextBox();
            txtType = new TextBox();
            txtSize = new TextBox();
            txtColor = new TextBox();
            txtPrice = new TextBox();
            lstItems = new ListBox();
            btnAdd = new Button();
            btnView = new Button();
            btnDelete = new Button();
            btnSearch = new Button();
            lblName = new Label();
            lblType = new Label();
            lblSize = new Label();
            lblColor = new Label();
            lblPrice = new Label();
            button1 = new Button();
            btnEmail = new Button();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.Font = new Font("Showcard Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtName.Location = new Point(236, 28);
            txtName.Name = "txtName";
            txtName.Size = new Size(248, 27);
            txtName.TabIndex = 0;
            txtName.TextChanged += txtName_TextChanged;
            // 
            // txtType
            // 
            txtType.Font = new Font("Showcard Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtType.Location = new Point(236, 61);
            txtType.Name = "txtType";
            txtType.Size = new Size(248, 31);
            txtType.TabIndex = 1;
            txtType.TextChanged += txtType_TextChanged;
            // 
            // txtSize
            // 
            txtSize.Font = new Font("Showcard Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSize.Location = new Point(236, 98);
            txtSize.Name = "txtSize";
            txtSize.Size = new Size(248, 31);
            txtSize.TabIndex = 2;
            // 
            // txtColor
            // 
            txtColor.Font = new Font("Showcard Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtColor.Location = new Point(236, 135);
            txtColor.Name = "txtColor";
            txtColor.Size = new Size(248, 31);
            txtColor.TabIndex = 3;
            // 
            // txtPrice
            // 
            txtPrice.Font = new Font("Showcard Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPrice.Location = new Point(236, 178);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(248, 31);
            txtPrice.TabIndex = 4;
            // 
            // lstItems
            // 
            lstItems.BackColor = Color.Wheat;
            lstItems.ItemHeight = 15;
            lstItems.Location = new Point(32, 265);
            lstItems.Name = "lstItems";
            lstItems.Size = new Size(427, 109);
            lstItems.TabIndex = 14;
            lstItems.SelectedIndexChanged += lstItems_SelectedIndexChanged;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.PeachPuff;
            btnAdd.Font = new Font("Stencil", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAdd.Location = new Point(12, 220);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(98, 39);
            btnAdd.TabIndex = 10;
            btnAdd.Text = "Add Item";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnView
            // 
            btnView.BackColor = Color.PeachPuff;
            btnView.Font = new Font("Stencil", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnView.Location = new Point(116, 220);
            btnView.Name = "btnView";
            btnView.Size = new Size(114, 39);
            btnView.TabIndex = 11;
            btnView.Text = "Display Item";
            btnView.UseVisualStyleBackColor = false;
            btnView.Click += btnView_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.PeachPuff;
            btnDelete.Font = new Font("Stencil", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDelete.Location = new Point(236, 220);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(106, 39);
            btnDelete.TabIndex = 12;
            btnDelete.Text = "Remove Item";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.PeachPuff;
            btnSearch.Font = new Font("Stencil", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSearch.Location = new Point(348, 220);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(122, 39);
            btnSearch.TabIndex = 13;
            btnSearch.Text = "Search by Type";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // lblName
            // 
            lblName.BackColor = Color.Transparent;
            lblName.Font = new Font("Gill Sans Ultra Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblName.ForeColor = SystemColors.ControlText;
            lblName.Location = new Point(12, 28);
            lblName.Name = "lblName";
            lblName.Size = new Size(200, 27);
            lblName.TabIndex = 5;
            lblName.Text = "CustomerName";
            lblName.TextAlign = ContentAlignment.TopRight;
            lblName.Click += lblName_Click;
            // 
            // lblType
            // 
            lblType.BackColor = Color.Transparent;
            lblType.Font = new Font("Gill Sans Ultra Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblType.ForeColor = Color.Black;
            lblType.Location = new Point(12, 61);
            lblType.Name = "lblType";
            lblType.Size = new Size(199, 31);
            lblType.TabIndex = 6;
            lblType.Text = "Clothing Type";
            lblType.TextAlign = ContentAlignment.TopRight;
            // 
            // lblSize
            // 
            lblSize.BackColor = Color.Transparent;
            lblSize.Font = new Font("Gill Sans Ultra Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSize.Location = new Point(12, 98);
            lblSize.Name = "lblSize";
            lblSize.Size = new Size(200, 31);
            lblSize.TabIndex = 7;
            lblSize.Text = "Clothing Size";
            lblSize.TextAlign = ContentAlignment.TopRight;
            // 
            // lblColor
            // 
            lblColor.BackColor = Color.Transparent;
            lblColor.Font = new Font("Gill Sans Ultra Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblColor.Location = new Point(12, 141);
            lblColor.Name = "lblColor";
            lblColor.Size = new Size(199, 31);
            lblColor.TabIndex = 8;
            lblColor.Text = "Clothing Color";
            lblColor.TextAlign = ContentAlignment.TopRight;
            lblColor.Click += lblColor_Click;
            // 
            // lblPrice
            // 
            lblPrice.BackColor = Color.Transparent;
            lblPrice.Font = new Font("Gill Sans Ultra Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPrice.Location = new Point(12, 178);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(199, 31);
            lblPrice.TabIndex = 9;
            lblPrice.Text = "Ask Price Owner";
            lblPrice.TextAlign = ContentAlignment.TopRight;
            lblPrice.Click += lblPrice_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.PeachPuff;
            button1.Font = new Font("Broadway", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(359, 391);
            button1.Name = "button1";
            button1.Size = new Size(129, 36);
            button1.TabIndex = 15;
            button1.Text = "Exit";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // btnEmail
            // 
            btnEmail.BackColor = Color.PeachPuff;
            btnEmail.Font = new Font("Stencil", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEmail.Location = new Point(12, 388);
            btnEmail.Name = "btnEmail";
            btnEmail.Size = new Size(98, 39);
            btnEmail.TabIndex = 16;
            btnEmail.Text = "Send Email";
            btnEmail.UseVisualStyleBackColor = false;
            btnEmail.Click += btnEmail_Click;
            // 
            // Form1
            // 
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(500, 430);
            Controls.Add(btnEmail);
            Controls.Add(button1);
            Controls.Add(txtName);
            Controls.Add(txtType);
            Controls.Add(txtSize);
            Controls.Add(txtColor);
            Controls.Add(txtPrice);
            Controls.Add(lblName);
            Controls.Add(lblType);
            Controls.Add(lblSize);
            Controls.Add(lblColor);
            Controls.Add(lblPrice);
            Controls.Add(btnAdd);
            Controls.Add(btnView);
            Controls.Add(btnDelete);
            Controls.Add(btnSearch);
            Controls.Add(lstItems);
            Name = "Form1";
            Text = "Clothing Store System";
            ResumeLayout(false);
            PerformLayout();
        }
        private Button button1;
        private Button btnEmail;
    }
}
