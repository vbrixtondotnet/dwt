namespace DWTTransport
{
    partial class StartForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartForm));
            this.ribbonMiniToolbar1 = new DevExpress.XtraBars.Ribbon.RibbonMiniToolbar(this.components);
            this.ribbonMiniToolbar2 = new DevExpress.XtraBars.Ribbon.RibbonMiniToolbar(this.components);
            this.companyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnDaybook = new DevExpress.XtraBars.BarButtonItem();
            this.btnCustomers = new DevExpress.XtraBars.BarButtonItem();
            this.btnDrivers = new DevExpress.XtraBars.BarButtonItem();
            this.btnInvoices = new DevExpress.XtraBars.BarButtonItem();
            this.btnWorkload = new DevExpress.XtraBars.BarButtonItem();
            this.btnPreferences = new DevExpress.XtraBars.BarButtonItem();
            this.btnLogout = new DevExpress.XtraBars.BarButtonItem();
            this.btnAdd = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.dateLabel = new DevExpress.XtraBars.BarStaticItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem7 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupAddBtn = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem8 = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.companyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.btnDaybook,
            this.btnCustomers,
            this.btnDrivers,
            this.btnInvoices,
            this.btnWorkload,
            this.btnPreferences,
            this.btnLogout,
            this.btnAdd,
            this.barButtonItem3,
            this.dateLabel,
            this.barButtonItem4,
            this.barButtonItem6,
            this.barButtonItem7,
            this.barButtonItem8});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 10;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowCategoryInCaption = false;
            this.ribbon.ShowToolbarCustomizeItem = false;
            this.ribbon.Size = new System.Drawing.Size(1219, 145);
            this.ribbon.Toolbar.ShowCustomizeItem = false;
            this.ribbon.Click += new System.EventHandler(this.ribbon_Click);
            // 
            // btnDaybook
            // 
            this.btnDaybook.Caption = "Daybook";
            this.btnDaybook.Glyph = global::DWTTransport.Properties.Resources.filled_box_48;
            this.btnDaybook.Id = 1;
            this.btnDaybook.Name = "btnDaybook";
            this.btnDaybook.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnDaybook.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnDaybook.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRawMaterialsList_ItemClick);
            // 
            // btnCustomers
            // 
            this.btnCustomers.Caption = "Customers";
            this.btnCustomers.Glyph = global::DWTTransport.Properties.Resources.user_menu_48;
            this.btnCustomers.Id = 5;
            this.btnCustomers.Name = "btnCustomers";
            this.btnCustomers.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnCustomers.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnCustomers.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnReceipts_ItemClick);
            // 
            // btnDrivers
            // 
            this.btnDrivers.Caption = "Drivers";
            this.btnDrivers.Glyph = global::DWTTransport.Properties.Resources.driver_24;
            this.btnDrivers.Id = 49;
            this.btnDrivers.Name = "btnDrivers";
            this.btnDrivers.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnDrivers.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnDrivers.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem3_ItemClick);
            // 
            // btnInvoices
            // 
            this.btnInvoices.Caption = "Invoices";
            this.btnInvoices.Glyph = global::DWTTransport.Properties.Resources.invoice_48;
            this.btnInvoices.Id = 50;
            this.btnInvoices.Name = "btnInvoices";
            this.btnInvoices.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnInvoices.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnInvoices_ItemClick);
            // 
            // btnWorkload
            // 
            this.btnWorkload.Caption = "Workload";
            this.btnWorkload.Glyph = global::DWTTransport.Properties.Resources.week_view_24;
            this.btnWorkload.Id = 51;
            this.btnWorkload.Name = "btnWorkload";
            this.btnWorkload.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnWorkload.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnWorkload_ItemClick);
            // 
            // btnPreferences
            // 
            this.btnPreferences.Caption = "Preferences";
            this.btnPreferences.Glyph = global::DWTTransport.Properties.Resources.settings_24;
            this.btnPreferences.Id = 52;
            this.btnPreferences.Name = "btnPreferences";
            this.btnPreferences.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnPreferences.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPreferences_ItemClick);
            // 
            // btnLogout
            // 
            this.btnLogout.Caption = "Log Out";
            this.btnLogout.Glyph = global::DWTTransport.Properties.Resources.cancel_24;
            this.btnLogout.Id = 53;
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnLogout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLogout_ItemClick);
            // 
            // btnAdd
            // 
            this.btnAdd.Caption = "Add Daybook";
            this.btnAdd.Glyph = global::DWTTransport.Properties.Resources.add_list_24;
            this.btnAdd.Id = 2;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAdd_ItemClick);
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "barButtonItem3";
            this.barButtonItem3.Id = 3;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // dateLabel
            // 
            this.dateLabel.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.dateLabel.Caption = "barStaticItem1";
            this.dateLabel.Id = 5;
            this.dateLabel.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.dateLabel.ItemAppearance.Normal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.dateLabel.ItemAppearance.Normal.Options.UseFont = true;
            this.dateLabel.ItemAppearance.Normal.Options.UseForeColor = true;
            this.dateLabel.ItemAppearance.Normal.Options.UseTextOptions = true;
            this.dateLabel.ItemAppearance.Normal.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.dateLabel.ItemAppearance.Normal.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.Caption;
            this.dateLabel.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "Users";
            this.barButtonItem4.Glyph = global::DWTTransport.Properties.Resources._1497886755_preferences_contact_list;
            this.barButtonItem4.Id = 6;
            this.barButtonItem4.Name = "barButtonItem4";
            this.barButtonItem4.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItem4.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItem4.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem4_ItemClick);
            // 
            // barButtonItem6
            // 
            this.barButtonItem6.Caption = "Journeys";
            this.barButtonItem6.Glyph = global::DWTTransport.Properties.Resources.building_48;
            this.barButtonItem6.Id = 7;
            this.barButtonItem6.Name = "barButtonItem6";
            this.barButtonItem6.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItem6.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItem6.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem6_ItemClick);
            // 
            // barButtonItem7
            // 
            this.barButtonItem7.Caption = "Trucks";
            this.barButtonItem7.Glyph = global::DWTTransport.Properties.Resources.interstate_truck_24;
            this.barButtonItem7.Id = 8;
            this.barButtonItem7.Name = "barButtonItem7";
            this.barButtonItem7.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu;
            this.barButtonItem7.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItem7.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem7_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroupAddBtn,
            this.ribbonPageGroup2});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Menu";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.AllowTextClipping = false;
            this.ribbonPageGroup1.ItemLinks.Add(this.btnDaybook);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnCustomers);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnDrivers);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnInvoices);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnWorkload);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem4);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem6);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnPreferences);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnLogout);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem7);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem8);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            // 
            // ribbonPageGroupAddBtn
            // 
            this.ribbonPageGroupAddBtn.ItemLinks.Add(this.btnAdd);
            this.ribbonPageGroupAddBtn.Name = "ribbonPageGroupAddBtn";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.dateLabel);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Date";
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2010 Blue";
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.MdiParent = this;
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Customers";
            this.barButtonItem1.Glyph = global::DWTTransport.Properties.Resources.invoice_48;
            this.barButtonItem1.Id = 5;
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItem1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Customers";
            this.barButtonItem2.Glyph = global::DWTTransport.Properties.Resources.invoice_48;
            this.barButtonItem2.Id = 5;
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItem2.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1082, 71);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.pictureBox1.Size = new System.Drawing.Size(129, 37);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "Users";
            this.barButtonItem5.Glyph = global::DWTTransport.Properties.Resources._1497886755_preferences_contact_list;
            this.barButtonItem5.Id = 6;
            this.barButtonItem5.Name = "barButtonItem5";
            this.barButtonItem5.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItem5.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItem8
            // 
            this.barButtonItem8.Caption = "Trailers";
            this.barButtonItem8.Glyph = global::DWTTransport.Properties.Resources.delivery_24;
            this.barButtonItem8.Id = 9;
            this.barButtonItem8.Name = "barButtonItem8";
            this.barButtonItem8.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu;
            this.barButtonItem8.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItem8.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem8_ItemClick);
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1219, 646);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ribbon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "StartForm";
            this.Ribbon = this.ribbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.StartForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.companyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        private System.Windows.Forms.BindingSource companyBindingSource;
        private DevExpress.XtraBars.Ribbon.RibbonMiniToolbar ribbonMiniToolbar1;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
        private DevExpress.XtraBars.Ribbon.RibbonMiniToolbar ribbonMiniToolbar2;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.BarButtonItem btnDaybook;
        private DevExpress.XtraBars.BarButtonItem btnCustomers;
        private DevExpress.XtraBars.BarButtonItem btnDrivers;
        private DevExpress.XtraBars.BarButtonItem btnInvoices;
        private DevExpress.XtraBars.BarButtonItem btnWorkload;
        private DevExpress.XtraBars.BarButtonItem btnPreferences;
        private DevExpress.XtraBars.BarButtonItem btnLogout;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem btnAdd;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupAddBtn;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevExpress.XtraBars.BarStaticItem dateLabel;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.BarButtonItem barButtonItem6;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraBars.BarButtonItem barButtonItem7;
        private DevExpress.XtraBars.BarButtonItem barButtonItem8;
    }
}