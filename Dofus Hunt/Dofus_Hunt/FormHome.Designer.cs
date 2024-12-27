namespace Dofus_Hunt
{
	// Token: 0x0200000C RID: 12
	public partial class FormHome : global::DevExpress.XtraEditors.XtraForm
	{
		// Token: 0x0600006B RID: 107 RVA: 0x0000238F File Offset: 0x0000058F
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600006C RID: 108 RVA: 0x000072F8 File Offset: 0x000054F8
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager resources = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Dofus_Hunt.FormHome));
			this.pictureBox_autoHunt = new global::System.Windows.Forms.PictureBox();
			this.pictureBox_hunt = new global::System.Windows.Forms.PictureBox();
			this.pictureBox_update = new global::System.Windows.Forms.PictureBox();
			this.pictureBox_config = new global::System.Windows.Forms.PictureBox();
			this.pictureBox_skin = new global::System.Windows.Forms.PictureBox();
			this.panelControl_config = new global::DevExpress.XtraEditors.PanelControl();
			this.labelControl14 = new global::DevExpress.XtraEditors.LabelControl();
			this.groupControl1 = new global::DevExpress.XtraEditors.GroupControl();
			this.simpleButton_changeIndice = new global::DevExpress.XtraEditors.SimpleButton();
			this.labelControl3 = new global::DevExpress.XtraEditors.LabelControl();
			this.textEdit_indiceok = new global::DevExpress.XtraEditors.TextEdit();
			this.textEdit_detectedindice = new global::DevExpress.XtraEditors.TextEdit();
			this.labelControl2 = new global::DevExpress.XtraEditors.LabelControl();
			this.textEdit_ConfigSeuil = new global::DevExpress.XtraEditors.TextEdit();
			this.textEdit_passdebug = new global::DevExpress.XtraEditors.TextEdit();
			this.checkEdit_debug = new global::DevExpress.XtraEditors.CheckEdit();
			this.checkEdit_AdvancedLogs = new global::DevExpress.XtraEditors.CheckEdit();
			this.checkEdit_alwaysonscreen = new global::DevExpress.XtraEditors.CheckEdit();
			this.trackBarControl_opacity = new global::DevExpress.XtraEditors.TrackBarControl();
			this.labelControl1 = new global::DevExpress.XtraEditors.LabelControl();
			this.toastNotificationsManager = new global::DevExpress.XtraBars.ToastNotifications.ToastNotificationsManager(this.components);
			this.labelControl_HToken = new global::DevExpress.XtraEditors.LabelControl();
			this.textEdit_token = new global::DevExpress.XtraEditors.TextEdit();
			this.panelControl_debug = new global::DevExpress.XtraEditors.PanelControl();
			this.simpleButton_Arrow = new global::DevExpress.XtraEditors.SimpleButton();
			this.simpleButton_GetIndice = new global::DevExpress.XtraEditors.SimpleButton();
			this.simpleButton_GetPosition = new global::DevExpress.XtraEditors.SimpleButton();
			this.simpleButton_Capture = new global::DevExpress.XtraEditors.SimpleButton();
			this.simpleButtonGetPositionIndice = new global::DevExpress.XtraEditors.SimpleButton();
			this.textEdit_debugIndice = new global::DevExpress.XtraEditors.TextEdit();
			this.labelControl8 = new global::DevExpress.XtraEditors.LabelControl();
			this.textEdit_debugDirection = new global::DevExpress.XtraEditors.TextEdit();
			this.labelControl7 = new global::DevExpress.XtraEditors.LabelControl();
			this.textEdit_debugY = new global::DevExpress.XtraEditors.TextEdit();
			this.labelControl6 = new global::DevExpress.XtraEditors.LabelControl();
			this.textEdit_debugX = new global::DevExpress.XtraEditors.TextEdit();
			this.labelControl5 = new global::DevExpress.XtraEditors.LabelControl();
			this.simpleButton_GetToken = new global::DevExpress.XtraEditors.SimpleButton();
			this.labelControl4 = new global::DevExpress.XtraEditors.LabelControl();
			this.panelControl_huntauto = new global::DevExpress.XtraEditors.PanelControl();
			this.labelControl_huntAutoMInd = new global::DevExpress.XtraEditors.LabelControl();
			this.labelControl_huntAutoDir = new global::DevExpress.XtraEditors.LabelControl();
			this.labelControl_huntAutoIndiceCor = new global::DevExpress.XtraEditors.LabelControl();
			this.labelControl_huntAutoIndice = new global::DevExpress.XtraEditors.LabelControl();
			this.checkEdit_huntAutoTravel = new global::DevExpress.XtraEditors.CheckEdit();
			this.labelControl_huntAutoStart = new global::DevExpress.XtraEditors.LabelControl();
			this.simpleButton_stopHunt = new global::DevExpress.XtraEditors.SimpleButton();
			this.simpleButton_startHunt = new global::DevExpress.XtraEditors.SimpleButton();
			this.labelControl_version = new global::DevExpress.XtraEditors.LabelControl();
			this.panelControl_init = new global::DevExpress.XtraEditors.PanelControl();
			this.progressPanel1 = new global::DevExpress.XtraWaitForm.ProgressPanel();
			this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
			this.panelControl_hunt = new global::DevExpress.XtraEditors.PanelControl();
			this.labelControl_huntresultat = new global::DevExpress.XtraEditors.LabelControl();
			this.checkEdit_hunt = new global::DevExpress.XtraEditors.CheckEdit();
			this.comboBoxEdit_huntindice = new global::DevExpress.XtraEditors.ComboBoxEdit();
			this.labelControl13 = new global::DevExpress.XtraEditors.LabelControl();
			this.simpleButton_hunt0 = new global::DevExpress.XtraEditors.SimpleButton();
			this.simpleButton_hunt4 = new global::DevExpress.XtraEditors.SimpleButton();
			this.simpleButton_hunt2 = new global::DevExpress.XtraEditors.SimpleButton();
			this.simpleButton_hunt6 = new global::DevExpress.XtraEditors.SimpleButton();
			this.labelControl12 = new global::DevExpress.XtraEditors.LabelControl();
			this.textEdit_huntY = new global::DevExpress.XtraEditors.TextEdit();
			this.labelControl11 = new global::DevExpress.XtraEditors.LabelControl();
			this.textEdit_huntX = new global::DevExpress.XtraEditors.TextEdit();
			this.labelControl10 = new global::DevExpress.XtraEditors.LabelControl();
			this.labelControl9 = new global::DevExpress.XtraEditors.LabelControl();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox_autoHunt).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox_hunt).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox_update).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox_config).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox_skin).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.panelControl_config).BeginInit();
			this.panelControl_config.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.groupControl1).BeginInit();
			this.groupControl1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_indiceok.Properties).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_detectedindice.Properties).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_ConfigSeuil.Properties).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_passdebug.Properties).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.checkEdit_debug.Properties).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.checkEdit_AdvancedLogs.Properties).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.checkEdit_alwaysonscreen.Properties).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.trackBarControl_opacity).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.trackBarControl_opacity.Properties).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.toastNotificationsManager).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_token.Properties).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.panelControl_debug).BeginInit();
			this.panelControl_debug.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_debugIndice.Properties).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_debugDirection.Properties).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_debugY.Properties).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_debugX.Properties).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.panelControl_huntauto).BeginInit();
			this.panelControl_huntauto.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.checkEdit_huntAutoTravel.Properties).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.panelControl_init).BeginInit();
			this.panelControl_init.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.panelControl_hunt).BeginInit();
			this.panelControl_hunt.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.checkEdit_hunt.Properties).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.comboBoxEdit_huntindice.Properties).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_huntY.Properties).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_huntX.Properties).BeginInit();
			base.SuspendLayout();
			this.pictureBox_autoHunt.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pictureBox_autoHunt.Image = global::Dofus_Hunt.Properties.Resources.ico_huntauto_dark;
			this.pictureBox_autoHunt.Location = new global::System.Drawing.Point(12, 12);
			this.pictureBox_autoHunt.Name = "pictureBox_autoHunt";
			this.pictureBox_autoHunt.Size = new global::System.Drawing.Size(20, 20);
			this.pictureBox_autoHunt.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox_autoHunt.TabIndex = 0;
			this.pictureBox_autoHunt.TabStop = false;
			this.pictureBox_autoHunt.Visible = false;
			this.pictureBox_autoHunt.WaitOnLoad = true;
			this.pictureBox_autoHunt.Click += new global::System.EventHandler(this.pictureBox_autoHunt_Click);
			this.pictureBox_hunt.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pictureBox_hunt.Image = global::Dofus_Hunt.Properties.Resources.ico_hunt_dark;
			this.pictureBox_hunt.Location = new global::System.Drawing.Point(38, 12);
			this.pictureBox_hunt.Name = "pictureBox_hunt";
			this.pictureBox_hunt.Size = new global::System.Drawing.Size(20, 20);
			this.pictureBox_hunt.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox_hunt.TabIndex = 1;
			this.pictureBox_hunt.TabStop = false;
			this.pictureBox_hunt.Visible = false;
			this.pictureBox_hunt.Click += new global::System.EventHandler(this.pictureBox_hunt_Click);
			this.pictureBox_update.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pictureBox_update.Image = global::Dofus_Hunt.Properties.Resources.ico_maj_dark;
			this.pictureBox_update.Location = new global::System.Drawing.Point(207, 12);
			this.pictureBox_update.Name = "pictureBox_update";
			this.pictureBox_update.Size = new global::System.Drawing.Size(20, 20);
			this.pictureBox_update.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox_update.TabIndex = 2;
			this.pictureBox_update.TabStop = false;
			this.pictureBox_update.Visible = false;
			this.pictureBox_update.Click += new global::System.EventHandler(this.pictureBox_update_Click);
			this.pictureBox_config.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pictureBox_config.Image = global::Dofus_Hunt.Properties.Resources.ico_config_dark;
			this.pictureBox_config.Location = new global::System.Drawing.Point(233, 12);
			this.pictureBox_config.Name = "pictureBox_config";
			this.pictureBox_config.Size = new global::System.Drawing.Size(20, 20);
			this.pictureBox_config.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox_config.TabIndex = 3;
			this.pictureBox_config.TabStop = false;
			this.pictureBox_config.Visible = false;
			this.pictureBox_config.Click += new global::System.EventHandler(this.pictureBox_config_Click);
			this.pictureBox_skin.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pictureBox_skin.Image = global::Dofus_Hunt.Properties.Resources.ico_skin_dark;
			this.pictureBox_skin.Location = new global::System.Drawing.Point(259, 12);
			this.pictureBox_skin.Name = "pictureBox_skin";
			this.pictureBox_skin.Size = new global::System.Drawing.Size(20, 20);
			this.pictureBox_skin.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox_skin.TabIndex = 4;
			this.pictureBox_skin.TabStop = false;
			this.pictureBox_skin.Visible = false;
			this.pictureBox_skin.Click += new global::System.EventHandler(this.pictureBox_skin_Click);
			this.panelControl_config.Controls.Add(this.labelControl14);
			this.panelControl_config.Controls.Add(this.groupControl1);
			this.panelControl_config.Controls.Add(this.textEdit_ConfigSeuil);
			this.panelControl_config.Controls.Add(this.textEdit_passdebug);
			this.panelControl_config.Controls.Add(this.checkEdit_debug);
			this.panelControl_config.Controls.Add(this.checkEdit_AdvancedLogs);
			this.panelControl_config.Controls.Add(this.checkEdit_alwaysonscreen);
			this.panelControl_config.Controls.Add(this.trackBarControl_opacity);
			this.panelControl_config.Controls.Add(this.labelControl1);
			this.panelControl_config.Location = new global::System.Drawing.Point(12, 38);
			this.panelControl_config.Name = "panelControl_config";
			this.panelControl_config.Size = new global::System.Drawing.Size(267, 243);
			this.panelControl_config.TabIndex = 5;
			this.panelControl_config.Visible = false;
			this.labelControl14.Location = new global::System.Drawing.Point(5, 102);
			this.labelControl14.Name = "labelControl14";
			this.labelControl14.Size = new global::System.Drawing.Size(114, 13);
			this.labelControl14.TabIndex = 7;
			this.labelControl14.Text = "Seuil de détection (%) :";
			this.groupControl1.Controls.Add(this.simpleButton_changeIndice);
			this.groupControl1.Controls.Add(this.labelControl3);
			this.groupControl1.Controls.Add(this.textEdit_indiceok);
			this.groupControl1.Controls.Add(this.textEdit_detectedindice);
			this.groupControl1.Controls.Add(this.labelControl2);
			this.groupControl1.Location = new global::System.Drawing.Point(5, 134);
			this.groupControl1.Name = "groupControl1";
			this.groupControl1.Size = new global::System.Drawing.Size(257, 78);
			this.groupControl1.TabIndex = 6;
			this.groupControl1.Text = "Correction d'indice";
			this.simpleButton_changeIndice.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.simpleButton_changeIndice.ImageOptions.Image = (global::System.Drawing.Image)resources.GetObject("simpleButton_changeIndice.ImageOptions.Image");
			this.simpleButton_changeIndice.Location = new global::System.Drawing.Point(230, 48);
			this.simpleButton_changeIndice.Name = "simpleButton_changeIndice";
			this.simpleButton_changeIndice.Size = new global::System.Drawing.Size(23, 20);
			this.simpleButton_changeIndice.TabIndex = 11;
			this.simpleButton_changeIndice.Click += new global::System.EventHandler(this.simpleButton_changeIndice_Click);
			this.labelControl3.Location = new global::System.Drawing.Point(5, 51);
			this.labelControl3.Name = "labelControl3";
			this.labelControl3.Size = new global::System.Drawing.Size(72, 13);
			this.labelControl3.TabIndex = 10;
			this.labelControl3.Text = "Indice corrigé :";
			this.textEdit_indiceok.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.textEdit_indiceok.Location = new global::System.Drawing.Point(87, 48);
			this.textEdit_indiceok.Name = "textEdit_indiceok";
			this.textEdit_indiceok.Size = new global::System.Drawing.Size(140, 20);
			this.textEdit_indiceok.TabIndex = 9;
			this.textEdit_detectedindice.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.textEdit_detectedindice.Location = new global::System.Drawing.Point(87, 22);
			this.textEdit_detectedindice.Name = "textEdit_detectedindice";
			this.textEdit_detectedindice.Size = new global::System.Drawing.Size(140, 20);
			this.textEdit_detectedindice.TabIndex = 8;
			this.labelControl2.Location = new global::System.Drawing.Point(5, 25);
			this.labelControl2.Name = "labelControl2";
			this.labelControl2.Size = new global::System.Drawing.Size(76, 13);
			this.labelControl2.TabIndex = 7;
			this.labelControl2.Text = "Indice détecté :";
			this.textEdit_ConfigSeuil.Location = new global::System.Drawing.Point(125, 99);
			this.textEdit_ConfigSeuil.Name = "textEdit_ConfigSeuil";
			this.textEdit_ConfigSeuil.Size = new global::System.Drawing.Size(52, 20);
			this.textEdit_ConfigSeuil.TabIndex = 8;
			this.textEdit_passdebug.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.textEdit_passdebug.Location = new global::System.Drawing.Point(91, 218);
			this.textEdit_passdebug.Name = "textEdit_passdebug";
			this.textEdit_passdebug.Properties.PasswordChar = '●';
			this.textEdit_passdebug.Properties.UseSystemPasswordChar = true;
			this.textEdit_passdebug.Size = new global::System.Drawing.Size(74, 20);
			this.textEdit_passdebug.TabIndex = 5;
			this.textEdit_passdebug.EditValueChanged += new global::System.EventHandler(this.textEdit_passdebug_EditValueChanged);
			this.checkEdit_debug.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.checkEdit_debug.Enabled = false;
			this.checkEdit_debug.Location = new global::System.Drawing.Point(5, 219);
			this.checkEdit_debug.Name = "checkEdit_debug";
			this.checkEdit_debug.Properties.Caption = "Mode debug";
			this.checkEdit_debug.Size = new global::System.Drawing.Size(80, 19);
			this.checkEdit_debug.TabIndex = 4;
			this.checkEdit_debug.CheckedChanged += new global::System.EventHandler(this.checkEdit_debug_CheckedChanged);
			this.checkEdit_debug.Click += new global::System.EventHandler(this.checkEdit_debug_Click);
			this.checkEdit_AdvancedLogs.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.checkEdit_AdvancedLogs.Location = new global::System.Drawing.Point(5, 75);
			this.checkEdit_AdvancedLogs.Name = "checkEdit_AdvancedLogs";
			this.checkEdit_AdvancedLogs.Properties.Caption = "Log avancés";
			this.checkEdit_AdvancedLogs.Size = new global::System.Drawing.Size(88, 19);
			this.checkEdit_AdvancedLogs.TabIndex = 3;
			this.checkEdit_AdvancedLogs.CheckedChanged += new global::System.EventHandler(this.checkEdit_AdvancedLogs_CheckedChanged);
			this.checkEdit_alwaysonscreen.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.checkEdit_alwaysonscreen.Location = new global::System.Drawing.Point(5, 50);
			this.checkEdit_alwaysonscreen.Name = "checkEdit_alwaysonscreen";
			this.checkEdit_alwaysonscreen.Properties.Caption = "Toujours à l'écran";
			this.checkEdit_alwaysonscreen.Size = new global::System.Drawing.Size(114, 19);
			this.checkEdit_alwaysonscreen.TabIndex = 2;
			this.checkEdit_alwaysonscreen.CheckedChanged += new global::System.EventHandler(this.checkEdit_alwaysonscreen_CheckedChanged);
			this.trackBarControl_opacity.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.trackBarControl_opacity.EditValue = 100;
			this.trackBarControl_opacity.Location = new global::System.Drawing.Point(5, 24);
			this.trackBarControl_opacity.Name = "trackBarControl_opacity";
			this.trackBarControl_opacity.Properties.LabelAppearance.Options.UseTextOptions = true;
			this.trackBarControl_opacity.Properties.LabelAppearance.TextOptions.HAlignment = global::DevExpress.Utils.HorzAlignment.Center;
			this.trackBarControl_opacity.Properties.LargeChange = 1;
			this.trackBarControl_opacity.Properties.Maximum = 100;
			this.trackBarControl_opacity.Properties.TickStyle = global::System.Windows.Forms.TickStyle.None;
			this.trackBarControl_opacity.Size = new global::System.Drawing.Size(257, 45);
			this.trackBarControl_opacity.TabIndex = 1;
			this.trackBarControl_opacity.Value = 100;
			this.trackBarControl_opacity.EditValueChanged += new global::System.EventHandler(this.trackBarControl_opacity_EditValueChanged);
			this.labelControl1.Location = new global::System.Drawing.Point(5, 5);
			this.labelControl1.Name = "labelControl1";
			this.labelControl1.Size = new global::System.Drawing.Size(117, 13);
			this.labelControl1.TabIndex = 0;
			this.labelControl1.Text = "Opacité de l'application :";
			this.toastNotificationsManager.ApplicationId = "b7971120-a792-4162-97e6-b7bf89481714";
			this.toastNotificationsManager.ApplicationName = "Dofus Hunt";
			this.labelControl_HToken.Location = new global::System.Drawing.Point(132, 287);
			this.labelControl_HToken.Name = "labelControl_HToken";
			this.labelControl_HToken.Size = new global::System.Drawing.Size(81, 13);
			this.labelControl_HToken.TabIndex = 6;
			this.labelControl_HToken.Text = "Heure du token :";
			this.textEdit_token.Location = new global::System.Drawing.Point(47, 5);
			this.textEdit_token.Name = "textEdit_token";
			this.textEdit_token.Size = new global::System.Drawing.Size(272, 20);
			this.textEdit_token.TabIndex = 7;
			this.panelControl_debug.Controls.Add(this.simpleButton_Arrow);
			this.panelControl_debug.Controls.Add(this.simpleButton_GetIndice);
			this.panelControl_debug.Controls.Add(this.simpleButton_GetPosition);
			this.panelControl_debug.Controls.Add(this.simpleButton_Capture);
			this.panelControl_debug.Controls.Add(this.simpleButtonGetPositionIndice);
			this.panelControl_debug.Controls.Add(this.textEdit_debugIndice);
			this.panelControl_debug.Controls.Add(this.labelControl8);
			this.panelControl_debug.Controls.Add(this.textEdit_debugDirection);
			this.panelControl_debug.Controls.Add(this.labelControl7);
			this.panelControl_debug.Controls.Add(this.textEdit_debugY);
			this.panelControl_debug.Controls.Add(this.labelControl6);
			this.panelControl_debug.Controls.Add(this.textEdit_debugX);
			this.panelControl_debug.Controls.Add(this.labelControl5);
			this.panelControl_debug.Controls.Add(this.simpleButton_GetToken);
			this.panelControl_debug.Controls.Add(this.labelControl4);
			this.panelControl_debug.Controls.Add(this.textEdit_token);
			this.panelControl_debug.Location = new global::System.Drawing.Point(300, 38);
			this.panelControl_debug.Name = "panelControl_debug";
			this.panelControl_debug.Size = new global::System.Drawing.Size(324, 243);
			this.panelControl_debug.TabIndex = 7;
			this.panelControl_debug.Visible = false;
			this.simpleButton_Arrow.Location = new global::System.Drawing.Point(5, 200);
			this.simpleButton_Arrow.Name = "simpleButton_Arrow";
			this.simpleButton_Arrow.Size = new global::System.Drawing.Size(314, 23);
			this.simpleButton_Arrow.TabIndex = 22;
			this.simpleButton_Arrow.Text = "Get Position Arrow";
			this.simpleButton_Arrow.Click += new global::System.EventHandler(this.simpleButton_Arrow_Click);
			this.simpleButton_GetIndice.Location = new global::System.Drawing.Point(5, 171);
			this.simpleButton_GetIndice.Name = "simpleButton_GetIndice";
			this.simpleButton_GetIndice.Size = new global::System.Drawing.Size(314, 23);
			this.simpleButton_GetIndice.TabIndex = 21;
			this.simpleButton_GetIndice.Text = "Get Indice";
			this.simpleButton_GetIndice.Click += new global::System.EventHandler(this.simpleButton_GetIndice_Click);
			this.simpleButton_GetPosition.Location = new global::System.Drawing.Point(5, 142);
			this.simpleButton_GetPosition.Name = "simpleButton_GetPosition";
			this.simpleButton_GetPosition.Size = new global::System.Drawing.Size(314, 23);
			this.simpleButton_GetPosition.TabIndex = 20;
			this.simpleButton_GetPosition.Text = "Get Position";
			this.simpleButton_GetPosition.Click += new global::System.EventHandler(this.simpleButton_GetPosition_Click);
			this.simpleButton_Capture.Location = new global::System.Drawing.Point(5, 113);
			this.simpleButton_Capture.Name = "simpleButton_Capture";
			this.simpleButton_Capture.Size = new global::System.Drawing.Size(314, 23);
			this.simpleButton_Capture.TabIndex = 19;
			this.simpleButton_Capture.Text = "Capture";
			this.simpleButton_Capture.Click += new global::System.EventHandler(this.simpleButton_Capture_Click);
			this.simpleButtonGetPositionIndice.Location = new global::System.Drawing.Point(5, 84);
			this.simpleButtonGetPositionIndice.Name = "simpleButtonGetPositionIndice";
			this.simpleButtonGetPositionIndice.Size = new global::System.Drawing.Size(314, 23);
			this.simpleButtonGetPositionIndice.TabIndex = 18;
			this.simpleButtonGetPositionIndice.Text = "Get Position Indice";
			this.simpleButtonGetPositionIndice.Click += new global::System.EventHandler(this.simpleButtonGetPositionIndice_Click);
			this.textEdit_debugIndice.Location = new global::System.Drawing.Point(220, 58);
			this.textEdit_debugIndice.Name = "textEdit_debugIndice";
			this.textEdit_debugIndice.Size = new global::System.Drawing.Size(99, 20);
			this.textEdit_debugIndice.TabIndex = 17;
			this.labelControl8.Location = new global::System.Drawing.Point(178, 61);
			this.labelControl8.Name = "labelControl8";
			this.labelControl8.Size = new global::System.Drawing.Size(36, 13);
			this.labelControl8.TabIndex = 16;
			this.labelControl8.Text = "Indice :";
			this.textEdit_debugDirection.Location = new global::System.Drawing.Point(143, 58);
			this.textEdit_debugDirection.Name = "textEdit_debugDirection";
			this.textEdit_debugDirection.Size = new global::System.Drawing.Size(29, 20);
			this.textEdit_debugDirection.TabIndex = 15;
			this.labelControl7.Location = new global::System.Drawing.Point(113, 61);
			this.labelControl7.Name = "labelControl7";
			this.labelControl7.Size = new global::System.Drawing.Size(24, 13);
			this.labelControl7.TabIndex = 14;
			this.labelControl7.Text = "Dir. :";
			this.labelControl7.ToolTip = "Haut : 6\r\nDroite : 0\r\nBas : 2\r\nGauche : 4";
			this.textEdit_debugY.Location = new global::System.Drawing.Point(78, 58);
			this.textEdit_debugY.Name = "textEdit_debugY";
			this.textEdit_debugY.Size = new global::System.Drawing.Size(29, 20);
			this.textEdit_debugY.TabIndex = 13;
			this.labelControl6.Location = new global::System.Drawing.Point(59, 61);
			this.labelControl6.Name = "labelControl6";
			this.labelControl6.Size = new global::System.Drawing.Size(13, 13);
			this.labelControl6.TabIndex = 12;
			this.labelControl6.Text = "Y :";
			this.textEdit_debugX.Location = new global::System.Drawing.Point(24, 58);
			this.textEdit_debugX.Name = "textEdit_debugX";
			this.textEdit_debugX.Size = new global::System.Drawing.Size(29, 20);
			this.textEdit_debugX.TabIndex = 11;
			this.labelControl5.Location = new global::System.Drawing.Point(5, 61);
			this.labelControl5.Name = "labelControl5";
			this.labelControl5.Size = new global::System.Drawing.Size(13, 13);
			this.labelControl5.TabIndex = 10;
			this.labelControl5.Text = "X :";
			this.simpleButton_GetToken.Location = new global::System.Drawing.Point(5, 29);
			this.simpleButton_GetToken.Name = "simpleButton_GetToken";
			this.simpleButton_GetToken.Size = new global::System.Drawing.Size(314, 23);
			this.simpleButton_GetToken.TabIndex = 9;
			this.simpleButton_GetToken.Text = "Get Token";
			this.simpleButton_GetToken.Click += new global::System.EventHandler(this.simpleButton_GetToken_Click);
			this.labelControl4.Location = new global::System.Drawing.Point(5, 8);
			this.labelControl4.Name = "labelControl4";
			this.labelControl4.Size = new global::System.Drawing.Size(36, 13);
			this.labelControl4.TabIndex = 8;
			this.labelControl4.Text = "Token :";
			this.panelControl_huntauto.Controls.Add(this.labelControl_huntAutoMInd);
			this.panelControl_huntauto.Controls.Add(this.labelControl_huntAutoDir);
			this.panelControl_huntauto.Controls.Add(this.labelControl_huntAutoIndiceCor);
			this.panelControl_huntauto.Controls.Add(this.labelControl_huntAutoIndice);
			this.panelControl_huntauto.Controls.Add(this.checkEdit_huntAutoTravel);
			this.panelControl_huntauto.Controls.Add(this.labelControl_huntAutoStart);
			this.panelControl_huntauto.Controls.Add(this.simpleButton_stopHunt);
			this.panelControl_huntauto.Controls.Add(this.simpleButton_startHunt);
			this.panelControl_huntauto.Location = new global::System.Drawing.Point(12, 38);
			this.panelControl_huntauto.Name = "panelControl_huntauto";
			this.panelControl_huntauto.Size = new global::System.Drawing.Size(267, 243);
			this.panelControl_huntauto.TabIndex = 13;
			this.panelControl_huntauto.Visible = false;
			this.labelControl_huntAutoMInd.Location = new global::System.Drawing.Point(23, 124);
			this.labelControl_huntAutoMInd.Name = "labelControl_huntAutoMInd";
			this.labelControl_huntAutoMInd.Size = new global::System.Drawing.Size(76, 13);
			this.labelControl_huntAutoMInd.TabIndex = 7;
			this.labelControl_huntAutoMInd.Text = "Map de l'indice :";
			this.labelControl_huntAutoDir.Location = new global::System.Drawing.Point(23, 105);
			this.labelControl_huntAutoDir.Name = "labelControl_huntAutoDir";
			this.labelControl_huntAutoDir.Size = new global::System.Drawing.Size(49, 13);
			this.labelControl_huntAutoDir.TabIndex = 6;
			this.labelControl_huntAutoDir.Text = "Direction :";
			this.labelControl_huntAutoIndiceCor.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.labelControl_huntAutoIndiceCor.Location = new global::System.Drawing.Point(23, 86);
			this.labelControl_huntAutoIndiceCor.Name = "labelControl_huntAutoIndiceCor";
			this.labelControl_huntAutoIndiceCor.Size = new global::System.Drawing.Size(72, 13);
			this.labelControl_huntAutoIndiceCor.TabIndex = 5;
			this.labelControl_huntAutoIndiceCor.Text = "Indice corrigé :";
			this.labelControl_huntAutoIndiceCor.ToolTip = "Clic sur l'indice pour ajouter la correction";
			this.labelControl_huntAutoIndiceCor.Click += new global::System.EventHandler(this.labelControl_huntAutoIndiceCor_Click);
			this.labelControl_huntAutoIndice.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.labelControl_huntAutoIndice.Location = new global::System.Drawing.Point(23, 67);
			this.labelControl_huntAutoIndice.Name = "labelControl_huntAutoIndice";
			this.labelControl_huntAutoIndice.Size = new global::System.Drawing.Size(36, 13);
			this.labelControl_huntAutoIndice.TabIndex = 4;
			this.labelControl_huntAutoIndice.Text = "Indice :";
			this.labelControl_huntAutoIndice.Click += new global::System.EventHandler(this.labelControl_huntAutoIndice_Click);
			this.checkEdit_huntAutoTravel.EditValue = true;
			this.checkEdit_huntAutoTravel.Location = new global::System.Drawing.Point(5, 219);
			this.checkEdit_huntAutoTravel.Name = "checkEdit_huntAutoTravel";
			this.checkEdit_huntAutoTravel.Properties.Caption = "Copier la commande d'autopilote";
			this.checkEdit_huntAutoTravel.Size = new global::System.Drawing.Size(178, 19);
			this.checkEdit_huntAutoTravel.TabIndex = 3;
			this.labelControl_huntAutoStart.Location = new global::System.Drawing.Point(23, 48);
			this.labelControl_huntAutoStart.Name = "labelControl_huntAutoStart";
			this.labelControl_huntAutoStart.Size = new global::System.Drawing.Size(77, 13);
			this.labelControl_huntAutoStart.TabIndex = 2;
			this.labelControl_huntAutoStart.Text = "Map de départ :";
			this.simpleButton_stopHunt.Enabled = false;
			this.simpleButton_stopHunt.Location = new global::System.Drawing.Point(136, 19);
			this.simpleButton_stopHunt.Name = "simpleButton_stopHunt";
			this.simpleButton_stopHunt.Size = new global::System.Drawing.Size(107, 23);
			this.simpleButton_stopHunt.TabIndex = 1;
			this.simpleButton_stopHunt.Text = "Arrêt";
			this.simpleButton_stopHunt.Click += new global::System.EventHandler(this.simpleButton_stopHunt_Click);
			this.simpleButton_startHunt.Location = new global::System.Drawing.Point(23, 19);
			this.simpleButton_startHunt.Name = "simpleButton_startHunt";
			this.simpleButton_startHunt.Size = new global::System.Drawing.Size(107, 23);
			this.simpleButton_startHunt.TabIndex = 0;
			this.simpleButton_startHunt.Text = "Lancement";
			this.simpleButton_startHunt.Click += new global::System.EventHandler(this.simpleButton_startHunt_Click);
			this.labelControl_version.Location = new global::System.Drawing.Point(12, 287);
			this.labelControl_version.Name = "labelControl_version";
			this.labelControl_version.Size = new global::System.Drawing.Size(42, 13);
			this.labelControl_version.TabIndex = 12;
			this.labelControl_version.Text = "Version :";
			this.panelControl_init.Controls.Add(this.progressPanel1);
			this.panelControl_init.Controls.Add(this.pictureBox1);
			this.panelControl_init.Location = new global::System.Drawing.Point(12, 38);
			this.panelControl_init.Name = "panelControl_init";
			this.panelControl_init.Size = new global::System.Drawing.Size(267, 243);
			this.panelControl_init.TabIndex = 7;
			this.progressPanel1.Appearance.BackColor = global::System.Drawing.Color.Transparent;
			this.progressPanel1.Appearance.Options.UseBackColor = true;
			this.progressPanel1.Caption = "Chargement";
			this.progressPanel1.Description = "Initialisation du logiciel ...";
			this.progressPanel1.Location = new global::System.Drawing.Point(38, 144);
			this.progressPanel1.Name = "progressPanel1";
			this.progressPanel1.Size = new global::System.Drawing.Size(190, 66);
			this.progressPanel1.TabIndex = 1;
			this.progressPanel1.Text = "progressPanel1";
			this.progressPanel1.WaitAnimationType = global::DevExpress.Utils.Animation.WaitingAnimatorType.Line;
			this.pictureBox1.Image = global::Dofus_Hunt.Properties.Resources._54ee5425_005f_4c80_b417_3018c0c05f2e;
			this.pictureBox1.Location = new global::System.Drawing.Point(83, 19);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new global::System.Drawing.Size(100, 100);
			this.pictureBox1.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			this.panelControl_hunt.Controls.Add(this.labelControl_huntresultat);
			this.panelControl_hunt.Controls.Add(this.checkEdit_hunt);
			this.panelControl_hunt.Controls.Add(this.comboBoxEdit_huntindice);
			this.panelControl_hunt.Controls.Add(this.labelControl13);
			this.panelControl_hunt.Controls.Add(this.simpleButton_hunt0);
			this.panelControl_hunt.Controls.Add(this.simpleButton_hunt4);
			this.panelControl_hunt.Controls.Add(this.simpleButton_hunt2);
			this.panelControl_hunt.Controls.Add(this.simpleButton_hunt6);
			this.panelControl_hunt.Controls.Add(this.labelControl12);
			this.panelControl_hunt.Controls.Add(this.textEdit_huntY);
			this.panelControl_hunt.Controls.Add(this.labelControl11);
			this.panelControl_hunt.Controls.Add(this.textEdit_huntX);
			this.panelControl_hunt.Controls.Add(this.labelControl10);
			this.panelControl_hunt.Controls.Add(this.labelControl9);
			this.panelControl_hunt.Location = new global::System.Drawing.Point(12, 38);
			this.panelControl_hunt.Name = "panelControl_hunt";
			this.panelControl_hunt.Size = new global::System.Drawing.Size(267, 243);
			this.panelControl_hunt.TabIndex = 8;
			this.panelControl_hunt.Visible = false;
			this.labelControl_huntresultat.Appearance.Font = new global::System.Drawing.Font("Tahoma", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.labelControl_huntresultat.Appearance.Options.UseFont = true;
			this.labelControl_huntresultat.Location = new global::System.Drawing.Point(115, 196);
			this.labelControl_huntresultat.Name = "labelControl_huntresultat";
			this.labelControl_huntresultat.Size = new global::System.Drawing.Size(37, 16);
			this.labelControl_huntresultat.TabIndex = 26;
			this.labelControl_huntresultat.Text = "XXXX";
			this.checkEdit_hunt.Location = new global::System.Drawing.Point(5, 219);
			this.checkEdit_hunt.Name = "checkEdit_hunt";
			this.checkEdit_hunt.Properties.Caption = "Copier la commande d'autopilote ";
			this.checkEdit_hunt.Size = new global::System.Drawing.Size(178, 19);
			this.checkEdit_hunt.TabIndex = 25;
			this.comboBoxEdit_huntindice.Location = new global::System.Drawing.Point(49, 169);
			this.comboBoxEdit_huntindice.Name = "comboBoxEdit_huntindice";
			this.comboBoxEdit_huntindice.Properties.Buttons.AddRange(new global::DevExpress.XtraEditors.Controls.EditorButton[]
			{
				new global::DevExpress.XtraEditors.Controls.EditorButton(global::DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
			});
			this.comboBoxEdit_huntindice.Size = new global::System.Drawing.Size(168, 20);
			this.comboBoxEdit_huntindice.TabIndex = 24;
			this.comboBoxEdit_huntindice.SelectedIndexChanged += new global::System.EventHandler(this.comboBoxEdit_huntindice_SelectedIndexChanged);
			this.labelControl13.Appearance.Font = new global::System.Drawing.Font("Tahoma", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.labelControl13.Appearance.Options.UseFont = true;
			this.labelControl13.Location = new global::System.Drawing.Point(109, 147);
			this.labelControl13.Name = "labelControl13";
			this.labelControl13.Size = new global::System.Drawing.Size(48, 16);
			this.labelControl13.TabIndex = 23;
			this.labelControl13.Text = "Indice :";
			this.simpleButton_hunt0.Appearance.Font = new global::System.Drawing.Font("Tahoma", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.simpleButton_hunt0.Appearance.Options.UseFont = true;
			this.simpleButton_hunt0.Location = new global::System.Drawing.Point(152, 101);
			this.simpleButton_hunt0.Name = "simpleButton_hunt0";
			this.simpleButton_hunt0.Size = new global::System.Drawing.Size(25, 25);
			this.simpleButton_hunt0.TabIndex = 22;
			this.simpleButton_hunt0.Text = "→";
			this.simpleButton_hunt0.Click += new global::System.EventHandler(this.simpleButton_hunt0_Click);
			this.simpleButton_hunt4.Appearance.Font = new global::System.Drawing.Font("Tahoma", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.simpleButton_hunt4.Appearance.Options.UseFont = true;
			this.simpleButton_hunt4.Location = new global::System.Drawing.Point(90, 101);
			this.simpleButton_hunt4.Name = "simpleButton_hunt4";
			this.simpleButton_hunt4.Size = new global::System.Drawing.Size(25, 25);
			this.simpleButton_hunt4.TabIndex = 21;
			this.simpleButton_hunt4.Text = "←";
			this.simpleButton_hunt4.Click += new global::System.EventHandler(this.simpleButton_hunt4_Click);
			this.simpleButton_hunt2.Appearance.Font = new global::System.Drawing.Font("Tahoma", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.simpleButton_hunt2.Appearance.Options.UseFont = true;
			this.simpleButton_hunt2.Location = new global::System.Drawing.Point(121, 116);
			this.simpleButton_hunt2.Name = "simpleButton_hunt2";
			this.simpleButton_hunt2.Size = new global::System.Drawing.Size(25, 25);
			this.simpleButton_hunt2.TabIndex = 20;
			this.simpleButton_hunt2.Text = "↓";
			this.simpleButton_hunt2.Click += new global::System.EventHandler(this.simpleButton_hunt2_Click);
			this.simpleButton_hunt6.Appearance.Font = new global::System.Drawing.Font("Tahoma", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.simpleButton_hunt6.Appearance.Options.UseFont = true;
			this.simpleButton_hunt6.Location = new global::System.Drawing.Point(121, 85);
			this.simpleButton_hunt6.Name = "simpleButton_hunt6";
			this.simpleButton_hunt6.Size = new global::System.Drawing.Size(25, 25);
			this.simpleButton_hunt6.TabIndex = 19;
			this.simpleButton_hunt6.Text = "↑";
			this.simpleButton_hunt6.Click += new global::System.EventHandler(this.simpleButton_hunt6_Click);
			this.labelControl12.Appearance.Font = new global::System.Drawing.Font("Tahoma", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.labelControl12.Appearance.Options.UseFont = true;
			this.labelControl12.Location = new global::System.Drawing.Point(100, 63);
			this.labelControl12.Name = "labelControl12";
			this.labelControl12.Size = new global::System.Drawing.Size(67, 16);
			this.labelControl12.TabIndex = 18;
			this.labelControl12.Text = "Direction :";
			this.textEdit_huntY.Location = new global::System.Drawing.Point(160, 32);
			this.textEdit_huntY.Name = "textEdit_huntY";
			this.textEdit_huntY.Size = new global::System.Drawing.Size(62, 20);
			this.textEdit_huntY.TabIndex = 17;
			this.labelControl11.Location = new global::System.Drawing.Point(141, 35);
			this.labelControl11.Name = "labelControl11";
			this.labelControl11.Size = new global::System.Drawing.Size(13, 13);
			this.labelControl11.TabIndex = 16;
			this.labelControl11.Text = "Y :";
			this.textEdit_huntX.Location = new global::System.Drawing.Point(64, 32);
			this.textEdit_huntX.Name = "textEdit_huntX";
			this.textEdit_huntX.Size = new global::System.Drawing.Size(62, 20);
			this.textEdit_huntX.TabIndex = 15;
			this.labelControl10.Location = new global::System.Drawing.Point(45, 35);
			this.labelControl10.Name = "labelControl10";
			this.labelControl10.Size = new global::System.Drawing.Size(13, 13);
			this.labelControl10.TabIndex = 14;
			this.labelControl10.Text = "X :";
			this.labelControl9.Appearance.Font = new global::System.Drawing.Font("Tahoma", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.labelControl9.Appearance.Options.UseFont = true;
			this.labelControl9.Location = new global::System.Drawing.Point(103, 7);
			this.labelControl9.Name = "labelControl9";
			this.labelControl9.Size = new global::System.Drawing.Size(60, 16);
			this.labelControl9.TabIndex = 13;
			this.labelControl9.Text = "Position :";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(288, 309);
			base.Controls.Add(this.panelControl_config);
			base.Controls.Add(this.panelControl_huntauto);
			base.Controls.Add(this.panelControl_hunt);
			base.Controls.Add(this.panelControl_init);
			base.Controls.Add(this.labelControl_version);
			base.Controls.Add(this.panelControl_debug);
			base.Controls.Add(this.labelControl_HToken);
			base.Controls.Add(this.pictureBox_skin);
			base.Controls.Add(this.pictureBox_config);
			base.Controls.Add(this.pictureBox_update);
			base.Controls.Add(this.pictureBox_hunt);
			base.Controls.Add(this.pictureBox_autoHunt);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.IconOptions.Icon = (global::System.Drawing.Icon)resources.GetObject("FormHome.IconOptions.Icon");
			base.MaximizeBox = false;
			base.Name = "FormHome";
			this.Text = "Dofus Hunt";
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.FormHome_FormClosing);
			base.Load += new global::System.EventHandler(this.FormHome_Load);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox_autoHunt).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox_hunt).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox_update).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox_config).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox_skin).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.panelControl_config).EndInit();
			this.panelControl_config.ResumeLayout(false);
			this.panelControl_config.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.groupControl1).EndInit();
			this.groupControl1.ResumeLayout(false);
			this.groupControl1.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_indiceok.Properties).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_detectedindice.Properties).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_ConfigSeuil.Properties).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_passdebug.Properties).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.checkEdit_debug.Properties).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.checkEdit_AdvancedLogs.Properties).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.checkEdit_alwaysonscreen.Properties).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.trackBarControl_opacity.Properties).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.trackBarControl_opacity).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.toastNotificationsManager).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_token.Properties).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.panelControl_debug).EndInit();
			this.panelControl_debug.ResumeLayout(false);
			this.panelControl_debug.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_debugIndice.Properties).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_debugDirection.Properties).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_debugY.Properties).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_debugX.Properties).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.panelControl_huntauto).EndInit();
			this.panelControl_huntauto.ResumeLayout(false);
			this.panelControl_huntauto.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.checkEdit_huntAutoTravel.Properties).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.panelControl_init).EndInit();
			this.panelControl_init.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.panelControl_hunt).EndInit();
			this.panelControl_hunt.ResumeLayout(false);
			this.panelControl_hunt.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.checkEdit_hunt.Properties).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.comboBoxEdit_huntindice.Properties).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_huntY.Properties).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_huntX.Properties).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000035 RID: 53
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000036 RID: 54
		private global::System.Windows.Forms.PictureBox pictureBox_autoHunt;

		// Token: 0x04000037 RID: 55
		private global::System.Windows.Forms.PictureBox pictureBox_hunt;

		// Token: 0x04000038 RID: 56
		private global::System.Windows.Forms.PictureBox pictureBox_update;

		// Token: 0x04000039 RID: 57
		private global::System.Windows.Forms.PictureBox pictureBox_config;

		// Token: 0x0400003A RID: 58
		private global::System.Windows.Forms.PictureBox pictureBox_skin;

		// Token: 0x0400003B RID: 59
		private global::DevExpress.XtraEditors.PanelControl panelControl_config;

		// Token: 0x0400003C RID: 60
		private global::DevExpress.XtraEditors.LabelControl labelControl1;

		// Token: 0x0400003D RID: 61
		private global::DevExpress.XtraEditors.TrackBarControl trackBarControl_opacity;

		// Token: 0x0400003E RID: 62
		private global::DevExpress.XtraEditors.CheckEdit checkEdit_alwaysonscreen;

		// Token: 0x0400003F RID: 63
		private global::DevExpress.XtraEditors.TextEdit textEdit_passdebug;

		// Token: 0x04000040 RID: 64
		private global::DevExpress.XtraEditors.CheckEdit checkEdit_debug;

		// Token: 0x04000041 RID: 65
		private global::DevExpress.XtraEditors.CheckEdit checkEdit_AdvancedLogs;

		// Token: 0x04000042 RID: 66
		private global::DevExpress.XtraEditors.GroupControl groupControl1;

		// Token: 0x04000043 RID: 67
		private global::DevExpress.XtraEditors.LabelControl labelControl3;

		// Token: 0x04000044 RID: 68
		private global::DevExpress.XtraEditors.TextEdit textEdit_indiceok;

		// Token: 0x04000045 RID: 69
		private global::DevExpress.XtraEditors.TextEdit textEdit_detectedindice;

		// Token: 0x04000046 RID: 70
		private global::DevExpress.XtraEditors.LabelControl labelControl2;

		// Token: 0x04000047 RID: 71
		private global::DevExpress.XtraEditors.SimpleButton simpleButton_changeIndice;

		// Token: 0x04000048 RID: 72
		private global::DevExpress.XtraBars.ToastNotifications.ToastNotificationsManager toastNotificationsManager;

		// Token: 0x04000049 RID: 73
		private global::DevExpress.XtraEditors.LabelControl labelControl_HToken;

		// Token: 0x0400004A RID: 74
		private global::DevExpress.XtraEditors.TextEdit textEdit_token;

		// Token: 0x0400004B RID: 75
		private global::DevExpress.XtraEditors.PanelControl panelControl_debug;

		// Token: 0x0400004C RID: 76
		private global::DevExpress.XtraEditors.SimpleButton simpleButton_Arrow;

		// Token: 0x0400004D RID: 77
		private global::DevExpress.XtraEditors.SimpleButton simpleButton_GetIndice;

		// Token: 0x0400004E RID: 78
		private global::DevExpress.XtraEditors.SimpleButton simpleButton_GetPosition;

		// Token: 0x0400004F RID: 79
		private global::DevExpress.XtraEditors.SimpleButton simpleButton_Capture;

		// Token: 0x04000050 RID: 80
		private global::DevExpress.XtraEditors.SimpleButton simpleButtonGetPositionIndice;

		// Token: 0x04000051 RID: 81
		private global::DevExpress.XtraEditors.TextEdit textEdit_debugIndice;

		// Token: 0x04000052 RID: 82
		private global::DevExpress.XtraEditors.LabelControl labelControl8;

		// Token: 0x04000053 RID: 83
		private global::DevExpress.XtraEditors.TextEdit textEdit_debugDirection;

		// Token: 0x04000054 RID: 84
		private global::DevExpress.XtraEditors.LabelControl labelControl7;

		// Token: 0x04000055 RID: 85
		private global::DevExpress.XtraEditors.TextEdit textEdit_debugY;

		// Token: 0x04000056 RID: 86
		private global::DevExpress.XtraEditors.LabelControl labelControl6;

		// Token: 0x04000057 RID: 87
		private global::DevExpress.XtraEditors.TextEdit textEdit_debugX;

		// Token: 0x04000058 RID: 88
		private global::DevExpress.XtraEditors.LabelControl labelControl5;

		// Token: 0x04000059 RID: 89
		private global::DevExpress.XtraEditors.SimpleButton simpleButton_GetToken;

		// Token: 0x0400005A RID: 90
		private global::DevExpress.XtraEditors.LabelControl labelControl4;

		// Token: 0x0400005B RID: 91
		private global::DevExpress.XtraEditors.LabelControl labelControl_version;

		// Token: 0x0400005C RID: 92
		private global::DevExpress.XtraEditors.PanelControl panelControl_init;

		// Token: 0x0400005D RID: 93
		private global::DevExpress.XtraWaitForm.ProgressPanel progressPanel1;

		// Token: 0x0400005E RID: 94
		private global::System.Windows.Forms.PictureBox pictureBox1;

		// Token: 0x0400005F RID: 95
		private global::DevExpress.XtraEditors.PanelControl panelControl_hunt;

		// Token: 0x04000060 RID: 96
		private global::DevExpress.XtraEditors.TextEdit textEdit_huntY;

		// Token: 0x04000061 RID: 97
		private global::DevExpress.XtraEditors.LabelControl labelControl11;

		// Token: 0x04000062 RID: 98
		private global::DevExpress.XtraEditors.TextEdit textEdit_huntX;

		// Token: 0x04000063 RID: 99
		private global::DevExpress.XtraEditors.LabelControl labelControl10;

		// Token: 0x04000064 RID: 100
		private global::DevExpress.XtraEditors.LabelControl labelControl9;

		// Token: 0x04000065 RID: 101
		private global::DevExpress.XtraEditors.SimpleButton simpleButton_hunt6;

		// Token: 0x04000066 RID: 102
		private global::DevExpress.XtraEditors.LabelControl labelControl12;

		// Token: 0x04000067 RID: 103
		private global::DevExpress.XtraEditors.SimpleButton simpleButton_hunt2;

		// Token: 0x04000068 RID: 104
		private global::DevExpress.XtraEditors.SimpleButton simpleButton_hunt0;

		// Token: 0x04000069 RID: 105
		private global::DevExpress.XtraEditors.SimpleButton simpleButton_hunt4;

		// Token: 0x0400006A RID: 106
		private global::DevExpress.XtraEditors.LabelControl labelControl_huntresultat;

		// Token: 0x0400006B RID: 107
		private global::DevExpress.XtraEditors.CheckEdit checkEdit_hunt;

		// Token: 0x0400006C RID: 108
		private global::DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_huntindice;

		// Token: 0x0400006D RID: 109
		private global::DevExpress.XtraEditors.LabelControl labelControl13;

		// Token: 0x0400006E RID: 110
		private global::DevExpress.XtraEditors.PanelControl panelControl_huntauto;

		// Token: 0x0400006F RID: 111
		private global::DevExpress.XtraEditors.SimpleButton simpleButton_stopHunt;

		// Token: 0x04000070 RID: 112
		private global::DevExpress.XtraEditors.SimpleButton simpleButton_startHunt;

		// Token: 0x04000071 RID: 113
		private global::DevExpress.XtraEditors.CheckEdit checkEdit_huntAutoTravel;

		// Token: 0x04000072 RID: 114
		private global::DevExpress.XtraEditors.LabelControl labelControl_huntAutoStart;

		// Token: 0x04000073 RID: 115
		private global::DevExpress.XtraEditors.LabelControl labelControl_huntAutoMInd;

		// Token: 0x04000074 RID: 116
		private global::DevExpress.XtraEditors.LabelControl labelControl_huntAutoDir;

		// Token: 0x04000075 RID: 117
		private global::DevExpress.XtraEditors.LabelControl labelControl_huntAutoIndiceCor;

		// Token: 0x04000076 RID: 118
		private global::DevExpress.XtraEditors.LabelControl labelControl_huntAutoIndice;

		// Token: 0x04000077 RID: 119
		private global::DevExpress.XtraEditors.LabelControl labelControl14;

		// Token: 0x04000078 RID: 120
		private global::DevExpress.XtraEditors.TextEdit textEdit_ConfigSeuil;
	}
}
