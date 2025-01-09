namespace Dofus_Hunt
{
	// Token: 0x02000003 RID: 3
	public partial class FormHome : global::DevExpress.XtraEditors.XtraForm
	{
		// Token: 0x06000045 RID: 69 RVA: 0x00002181 File Offset: 0x00000381
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000046 RID: 70 RVA: 0x00006330 File Offset: 0x00004530
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new global::System.Windows.Forms.DataGridViewCellStyle();
			global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new global::System.Windows.Forms.DataGridViewCellStyle();
			global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new global::System.Windows.Forms.DataGridViewCellStyle();
			global::System.ComponentModel.ComponentResourceManager resources = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Dofus_Hunt.FormHome));
			this.panelControl_Hunt_Init = new global::DevExpress.XtraEditors.PanelControl();
			this.progressPanel1 = new global::DevExpress.XtraWaitForm.ProgressPanel();
			this.pictureBox_Hunt_Init_Logo = new global::System.Windows.Forms.PictureBox();
			this.panelControl_Hunt_Config_Logiciel = new global::DevExpress.XtraEditors.PanelControl();
			this.checkEdit_Hunt_Config_Logiciel_UpdateDHU = new global::DevExpress.XtraEditors.CheckEdit();
			this.checkEdit_Hunt_Config_Logiciel_Notifications = new global::DevExpress.XtraEditors.CheckEdit();
			this.checkEdit_Hunt_Config_Logiciel_DeleteLog = new global::DevExpress.XtraEditors.CheckEdit();
			this.checkEdit_Hunt_Config_Logiciel_DeleteFile = new global::DevExpress.XtraEditors.CheckEdit();
			this.checkEdit_Hunt_Config_Logiciel_LogAvance = new global::DevExpress.XtraEditors.CheckEdit();
			this.checkEdit_Hunt_Config_Logiciel_Theme = new global::DevExpress.XtraEditors.CheckEdit();
			this.checkEdit_Hunt_Config_Logiciel_Ecran = new global::DevExpress.XtraEditors.CheckEdit();
			this.trackBarControl_Hunt_Config_Logiciel_Opacity = new global::DevExpress.XtraEditors.TrackBarControl();
			this.labelControl_Hunt_Config_Logiciel_Opacité = new global::DevExpress.XtraEditors.LabelControl();
			this.panelControl_Hunt_Notifications = new global::DevExpress.XtraEditors.PanelControl();
			this.simpleButton_Notify_Reinit = new global::DevExpress.XtraEditors.SimpleButton();
			this.simpleButton_Notify_Save = new global::DevExpress.XtraEditors.SimpleButton();
			this.xtraTabControl_Hunt_Config_Notifications = new global::DevExpress.XtraTab.XtraTabControl();
			this.xtraTabPage_Notifications_App = new global::DevExpress.XtraTab.XtraTabPage();
			this.textEdit_Notify_App_Restart = new global::DevExpress.XtraEditors.TextEdit();
			this.labelControl_Notify_App_Restart = new global::DevExpress.XtraEditors.LabelControl();
			this.textEdit_Notify_App_PbData = new global::DevExpress.XtraEditors.TextEdit();
			this.labelControl_Notify_App_PbData = new global::DevExpress.XtraEditors.LabelControl();
			this.textEdit_Notify_App_PbCo = new global::DevExpress.XtraEditors.TextEdit();
			this.labelControl_Notify_App_PbCo = new global::DevExpress.XtraEditors.LabelControl();
			this.textEdit_Notify_App_Update = new global::DevExpress.XtraEditors.TextEdit();
			this.labelControl_Notify_App_Uodate = new global::DevExpress.XtraEditors.LabelControl();
			this.xtraTabPage_Notifications_Hunt = new global::DevExpress.XtraTab.XtraTabPage();
			this.textEdit_Notify_Hunt_NoData = new global::DevExpress.XtraEditors.TextEdit();
			this.labelControl_Notify_Hunt_NoData = new global::DevExpress.XtraEditors.LabelControl();
			this.xtraTabPage_Notifications_Indice = new global::DevExpress.XtraTab.XtraTabPage();
			this.textEdit_Indices_CorrectIndice = new global::DevExpress.XtraEditors.TextEdit();
			this.labelControl_Indices_CorrectIndice = new global::DevExpress.XtraEditors.LabelControl();
			this.textEdit_Indices_Phorreur = new global::DevExpress.XtraEditors.TextEdit();
			this.labelControl_Indices_Phorreur = new global::DevExpress.XtraEditors.LabelControl();
			this.textEdit_Indices_IndiceKO = new global::DevExpress.XtraEditors.TextEdit();
			this.labelControl_Indices_IndiceKO = new global::DevExpress.XtraEditors.LabelControl();
			this.textEdit_Indices_IndiceOK = new global::DevExpress.XtraEditors.TextEdit();
			this.labelControl_Indices_IndiceOK = new global::DevExpress.XtraEditors.LabelControl();
			this.panelControl_Hunt_Indice = new global::DevExpress.XtraEditors.PanelControl();
			this.simpleButton_Hunt_Indice_Add = new global::DevExpress.XtraEditors.SimpleButton();
			this.textEdit_Hunt_Indice_Correct = new global::DevExpress.XtraEditors.TextEdit();
			this.labelControl_Hunt_Indice_Correct = new global::DevExpress.XtraEditors.LabelControl();
			this.textEdit_Hunt_Indice_Incorrect = new global::DevExpress.XtraEditors.TextEdit();
			this.labelControl_Hunt_Indice_Incorrect = new global::DevExpress.XtraEditors.LabelControl();
			this.dataGridView_Hunt_Indice_List = new global::System.Windows.Forms.DataGridView();
			this.Column_Incorrect = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column_Correct = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.accordionControl1 = new global::DevExpress.XtraBars.Navigation.AccordionControl();
			this.accordionControlElement_Menu_Hunt = new global::DevExpress.XtraBars.Navigation.AccordionControlElement();
			this.accordionControlElement_SubMenu_HuntAuto = new global::DevExpress.XtraBars.Navigation.AccordionControlElement();
			this.accordionControlElement_SubMenu_Hunt = new global::DevExpress.XtraBars.Navigation.AccordionControlElement();
			this.accordionControlElement_Menu_Config = new global::DevExpress.XtraBars.Navigation.AccordionControlElement();
			this.accordionControlElement_SubMenu_Config_Logiciel = new global::DevExpress.XtraBars.Navigation.AccordionControlElement();
			this.accordionControlElement_SubMenu_Config_HuntAuto = new global::DevExpress.XtraBars.Navigation.AccordionControlElement();
			this.accordionControlElement_SubMenu_Config_Indice = new global::DevExpress.XtraBars.Navigation.AccordionControlElement();
			this.accordionControlElement_SubMenu_Config_Notif = new global::DevExpress.XtraBars.Navigation.AccordionControlElement();
			this.accordionControlElement_SubMenu_Config_Update = new global::DevExpress.XtraBars.Navigation.AccordionControlElement();
			this.accordionControlElement_SubMenu_Config_Debug = new global::DevExpress.XtraBars.Navigation.AccordionControlElement();
			this.labelControl_Hunt_Version = new global::DevExpress.XtraEditors.LabelControl();
			this.panelControl_Hunt_Debug = new global::DevExpress.XtraEditors.PanelControl();
			this.simpleButton_Hunt_Debug_GetArrow = new global::DevExpress.XtraEditors.SimpleButton();
			this.simpleButton_Hunt_Debug_GetIndice = new global::DevExpress.XtraEditors.SimpleButton();
			this.simpleButton_Hunt_Debug_GetPosition = new global::DevExpress.XtraEditors.SimpleButton();
			this.simpleButton_Hunt_Debug_GetPositionIndice = new global::DevExpress.XtraEditors.SimpleButton();
			this.textEdit_Hunt_Debug_Indice = new global::DevExpress.XtraEditors.TextEdit();
			this.labelControl_Hunt_Debug_Indice = new global::DevExpress.XtraEditors.LabelControl();
			this.textEdit_Hunt_Debug_Dir = new global::DevExpress.XtraEditors.TextEdit();
			this.labelControl_Hunt_Debug_Dir = new global::DevExpress.XtraEditors.LabelControl();
			this.textEdit_Hunt_Debug_Y = new global::DevExpress.XtraEditors.TextEdit();
			this.labelControl_Hunt_Debug_Y = new global::DevExpress.XtraEditors.LabelControl();
			this.textEdit_Hunt_Debug_X = new global::DevExpress.XtraEditors.TextEdit();
			this.labelControl_Hunt_Debug_X = new global::DevExpress.XtraEditors.LabelControl();
			this.simpleButton_Hunt_Debug_Capture = new global::DevExpress.XtraEditors.SimpleButton();
			this.simpleButton_Hunt_Debug_Token = new global::DevExpress.XtraEditors.SimpleButton();
			this.textEdit_Hunt_Debug_Token = new global::DevExpress.XtraEditors.TextEdit();
			this.labelControl_Hunt_Debug_Token = new global::DevExpress.XtraEditors.LabelControl();
			this.separatorControl1 = new global::DevExpress.XtraEditors.SeparatorControl();
			this.labelControl_Hunt_Debug = new global::DevExpress.XtraEditors.LabelControl();
			this.panelControl_Hunt_ConfigHuntAuto = new global::DevExpress.XtraEditors.PanelControl();
			this.xtraTabControl_Hunt_Config_HuntAuto = new global::DevExpress.XtraTab.XtraTabControl();
			this.xtraTabPage1 = new global::DevExpress.XtraTab.XtraTabPage();
			this.textEdit_Hunt_Config_Hunt_Indice_Detection = new global::DevExpress.XtraEditors.TextEdit();
			this.textEdit_Hunt_Config_Debug = new global::DevExpress.XtraEditors.TextEdit();
			this.checkEdit_Hunt_Config_Debug = new global::DevExpress.XtraEditors.CheckEdit();
			this.labelControl_Hunt_Config_Hunt_Indice_Detection = new global::DevExpress.XtraEditors.LabelControl();
			this.checkEdit_Hunt_Config_Offline = new global::DevExpress.XtraEditors.CheckEdit();
			this.checkEdit_Hunt_Config_UseGoogleVision = new global::DevExpress.XtraEditors.CheckEdit();
			this.xtraTabPage2 = new global::DevExpress.XtraTab.XtraTabPage();
			this.simpleButton_Hunt_Config_Hunt_Position_save = new global::DevExpress.XtraEditors.SimpleButton();
			this.textEdit_Hunt_Config_Hunt_Position_hauteurTexte = new global::DevExpress.XtraEditors.TextEdit();
			this.labelControl_Hunt_Config_Hunt_Position_hauteurTexte = new global::DevExpress.XtraEditors.LabelControl();
			this.textEdit_Hunt_Config_Hunt_Position_largeurTexte = new global::DevExpress.XtraEditors.TextEdit();
			this.labelControl_Hunt_Config_Hunt_Position_largeurTexte = new global::DevExpress.XtraEditors.LabelControl();
			this.textEdit_Hunt_Config_Hunt_Position_threshold = new global::DevExpress.XtraEditors.TextEdit();
			this.labelControl_Hunt_Config_Hunt_Position_threshold = new global::DevExpress.XtraEditors.LabelControl();
			this.textEdit_Hunt_Config_Hunt_Position_height = new global::DevExpress.XtraEditors.TextEdit();
			this.labelControl_Hunt_Config_Hunt_Position_height = new global::DevExpress.XtraEditors.LabelControl();
			this.textEdit_Hunt_Config_Hunt_Position_width = new global::DevExpress.XtraEditors.TextEdit();
			this.labelControl_Hunt_Config_Hunt_Position_width = new global::DevExpress.XtraEditors.LabelControl();
			this.textEdit_Hunt_Config_Hunt_Position_Y = new global::DevExpress.XtraEditors.TextEdit();
			this.labelControl_Hunt_Config_Hunt_Position_Y = new global::DevExpress.XtraEditors.LabelControl();
			this.textEdit_Hunt_Config_Hunt_Position_X = new global::DevExpress.XtraEditors.TextEdit();
			this.labelControl_Hunt_Config_Hunt_Position_X = new global::DevExpress.XtraEditors.LabelControl();
			this.xtraTabPage3 = new global::DevExpress.XtraTab.XtraTabPage();
			this.textEdit_Hunt_Config_Hunt_Indice_OCRCombat = new global::DevExpress.XtraEditors.TextEdit();
			this.labelControl_Hunt_Config_Hunt_Indice_OCRCombat = new global::DevExpress.XtraEditors.LabelControl();
			this.simpleButton_Hunt_Config_Hunt_Indice_Save = new global::DevExpress.XtraEditors.SimpleButton();
			this.textEdit_Hunt_Config_Hunt_Indice_OCRCocheCheck = new global::DevExpress.XtraEditors.TextEdit();
			this.labelControl_Hunt_Config_Hunt_Indice_OCRCocheChecked = new global::DevExpress.XtraEditors.LabelControl();
			this.textEdit_Hunt_Config_Hunt_Indice_OCRFleche = new global::DevExpress.XtraEditors.TextEdit();
			this.labelControl_Hunt_Config_Hunt_Indice_OCRFleche = new global::DevExpress.XtraEditors.LabelControl();
			this.textEdit_Hunt_Config_Hunt_Indice_HIndice = new global::DevExpress.XtraEditors.TextEdit();
			this.labelControl_Hunt_Config_Hunt_Indice_HIndice = new global::DevExpress.XtraEditors.LabelControl();
			this.textEdit_Hunt_Config_Hunt_Indice_LIndice = new global::DevExpress.XtraEditors.TextEdit();
			this.labelControl_Hunt_Config_Hunt_Indice_LCoche = new global::DevExpress.XtraEditors.LabelControl();
			this.textEdit_Hunt_Config_Hunt_Indice_OCRCoche = new global::DevExpress.XtraEditors.TextEdit();
			this.labelControl_Hunt_Config_Hunt_Indice_OCRCoche = new global::DevExpress.XtraEditors.LabelControl();
			this.textEdit_Hunt_Config_Hunt_Indice_HStart = new global::DevExpress.XtraEditors.TextEdit();
			this.labelControl_Hunt_Config_Hunt_Indice_HStart = new global::DevExpress.XtraEditors.LabelControl();
			this.textEdit_Hunt_Config_Hunt_Indice_LStart = new global::DevExpress.XtraEditors.TextEdit();
			this.labelControl_Hunt_Config_Hunt_Indice_LStart = new global::DevExpress.XtraEditors.LabelControl();
			this.textEdit_Hunt_Config_Hunt_Indice_OCRStart = new global::DevExpress.XtraEditors.TextEdit();
			this.labelControl_Hunt_Config_Hunt_Indice_OCRStart = new global::DevExpress.XtraEditors.LabelControl();
			this.xtraTabPage4 = new global::DevExpress.XtraTab.XtraTabPage();
			this.groupControl5 = new global::DevExpress.XtraEditors.GroupControl();
			this.pictureBox_Hunt_Config_Hunt_Template_Combat = new global::System.Windows.Forms.PictureBox();
			this.groupControl4 = new global::DevExpress.XtraEditors.GroupControl();
			this.pictureBox_Hunt_Config_Hunt_Template_Level = new global::System.Windows.Forms.PictureBox();
			this.groupControl3 = new global::DevExpress.XtraEditors.GroupControl();
			this.pictureBox_Hunt_Config_Hunt_Template_Start = new global::System.Windows.Forms.PictureBox();
			this.groupControl2 = new global::DevExpress.XtraEditors.GroupControl();
			this.pictureBox_Hunt_Config_Hunt_Template_Arrow_6 = new global::System.Windows.Forms.PictureBox();
			this.pictureBox_Hunt_Config_Hunt_Template_Arrow_4 = new global::System.Windows.Forms.PictureBox();
			this.pictureBox_Hunt_Config_Hunt_Template_Arrow_2 = new global::System.Windows.Forms.PictureBox();
			this.pictureBox_Hunt_Config_Hunt_Template_Arrow_0 = new global::System.Windows.Forms.PictureBox();
			this.groupControl1 = new global::DevExpress.XtraEditors.GroupControl();
			this.pictureBox_Hunt_Config_Hunt_Template_CocheChecked = new global::System.Windows.Forms.PictureBox();
			this.pictureBox_Hunt_Config_Hunt_Template_Coche = new global::System.Windows.Forms.PictureBox();
			this.panelControl_Hunt_Hunt = new global::DevExpress.XtraEditors.PanelControl();
			this.labelControl_Hunt_Map = new global::DevExpress.XtraEditors.LabelControl();
			this.checkEdit_Hunt_AutoTravel = new global::DevExpress.XtraEditors.CheckEdit();
			this.comboBoxEdit_Hunt_Indice = new global::DevExpress.XtraEditors.ComboBoxEdit();
			this.separatorControl4 = new global::DevExpress.XtraEditors.SeparatorControl();
			this.labelControl_Hunt_Indice = new global::DevExpress.XtraEditors.LabelControl();
			this.simpleButton_Hunt_2 = new global::DevExpress.XtraEditors.SimpleButton();
			this.simpleButton_Hunt_4 = new global::DevExpress.XtraEditors.SimpleButton();
			this.simpleButton_Hunt_0 = new global::DevExpress.XtraEditors.SimpleButton();
			this.simpleButton_Hunt_6 = new global::DevExpress.XtraEditors.SimpleButton();
			this.separatorControl3 = new global::DevExpress.XtraEditors.SeparatorControl();
			this.labelControl_Hunt_Dir = new global::DevExpress.XtraEditors.LabelControl();
			this.textEdit_Hunt_Y = new global::DevExpress.XtraEditors.TextEdit();
			this.labelControl_Hunt_Y = new global::DevExpress.XtraEditors.LabelControl();
			this.textEdit_Hunt_X = new global::DevExpress.XtraEditors.TextEdit();
			this.labelControl_Hunt_X = new global::DevExpress.XtraEditors.LabelControl();
			this.separatorControl2 = new global::DevExpress.XtraEditors.SeparatorControl();
			this.labelControl_Hunt_Pos = new global::DevExpress.XtraEditors.LabelControl();
			this.toastNotificationsManager = new global::DevExpress.XtraBars.ToastNotifications.ToastNotificationsManager(this.components);
			this.panelControl_Hunt_HuntAuto = new global::DevExpress.XtraEditors.PanelControl();
			this.checkEdit_Hunt_Auto_ModeReduit = new global::DevExpress.XtraEditors.CheckEdit();
			this.labelControl_HuntAuto_MapIndice = new global::DevExpress.XtraEditors.LabelControl();
			this.labelControl_HuntAuto_MapStart = new global::DevExpress.XtraEditors.LabelControl();
			this.checkEdit_HuntAuto_AutoTravel = new global::DevExpress.XtraEditors.CheckEdit();
			this.labelControl_HuntAuto_Direction = new global::DevExpress.XtraEditors.LabelControl();
			this.simpleButton_HuntAutoStop = new global::DevExpress.XtraEditors.SimpleButton();
			this.simpleButton_HuntAutoStart = new global::DevExpress.XtraEditors.SimpleButton();
			this.labelControl_HuntAuto_IndiceCor = new global::DevExpress.XtraEditors.LabelControl();
			this.labelControl_HuntAuto_Indice = new global::DevExpress.XtraEditors.LabelControl();
			this.panelControl_Home = new global::DevExpress.XtraEditors.PanelControl();
			this.pictureBox_Discord = new global::System.Windows.Forms.PictureBox();
			this.separatorControl5 = new global::DevExpress.XtraEditors.SeparatorControl();
			this.labelControl1 = new global::DevExpress.XtraEditors.LabelControl();
			((global::System.ComponentModel.ISupportInitialize)this.panelControl_Hunt_Init).BeginInit();
			this.panelControl_Hunt_Init.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox_Hunt_Init_Logo).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.panelControl_Hunt_Config_Logiciel).BeginInit();
			this.panelControl_Hunt_Config_Logiciel.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.checkEdit_Hunt_Config_Logiciel_UpdateDHU.Properties).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.checkEdit_Hunt_Config_Logiciel_Notifications.Properties).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.checkEdit_Hunt_Config_Logiciel_DeleteLog.Properties).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.checkEdit_Hunt_Config_Logiciel_DeleteFile.Properties).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.checkEdit_Hunt_Config_Logiciel_LogAvance.Properties).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.checkEdit_Hunt_Config_Logiciel_Theme.Properties).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.checkEdit_Hunt_Config_Logiciel_Ecran.Properties).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.trackBarControl_Hunt_Config_Logiciel_Opacity).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.trackBarControl_Hunt_Config_Logiciel_Opacity.Properties).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.panelControl_Hunt_Notifications).BeginInit();
			this.panelControl_Hunt_Notifications.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.xtraTabControl_Hunt_Config_Notifications).BeginInit();
			this.xtraTabControl_Hunt_Config_Notifications.SuspendLayout();
			this.xtraTabPage_Notifications_App.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_Notify_App_Restart.Properties).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_Notify_App_PbData.Properties).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_Notify_App_PbCo.Properties).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_Notify_App_Update.Properties).BeginInit();
			this.xtraTabPage_Notifications_Hunt.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_Notify_Hunt_NoData.Properties).BeginInit();
			this.xtraTabPage_Notifications_Indice.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_Indices_CorrectIndice.Properties).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_Indices_Phorreur.Properties).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_Indices_IndiceKO.Properties).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_Indices_IndiceOK.Properties).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.panelControl_Hunt_Indice).BeginInit();
			this.panelControl_Hunt_Indice.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_Hunt_Indice_Correct.Properties).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_Hunt_Indice_Incorrect.Properties).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.dataGridView_Hunt_Indice_List).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.accordionControl1).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.panelControl_Hunt_Debug).BeginInit();
			this.panelControl_Hunt_Debug.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_Hunt_Debug_Indice.Properties).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_Hunt_Debug_Dir.Properties).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_Hunt_Debug_Y.Properties).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_Hunt_Debug_X.Properties).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_Hunt_Debug_Token.Properties).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.separatorControl1).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.panelControl_Hunt_ConfigHuntAuto).BeginInit();
			this.panelControl_Hunt_ConfigHuntAuto.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.xtraTabControl_Hunt_Config_HuntAuto).BeginInit();
			this.xtraTabControl_Hunt_Config_HuntAuto.SuspendLayout();
			this.xtraTabPage1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_Hunt_Config_Hunt_Indice_Detection.Properties).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_Hunt_Config_Debug.Properties).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.checkEdit_Hunt_Config_Debug.Properties).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.checkEdit_Hunt_Config_Offline.Properties).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.checkEdit_Hunt_Config_UseGoogleVision.Properties).BeginInit();
			this.xtraTabPage2.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_Hunt_Config_Hunt_Position_hauteurTexte.Properties).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_Hunt_Config_Hunt_Position_largeurTexte.Properties).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_Hunt_Config_Hunt_Position_threshold.Properties).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_Hunt_Config_Hunt_Position_height.Properties).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_Hunt_Config_Hunt_Position_width.Properties).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_Hunt_Config_Hunt_Position_Y.Properties).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_Hunt_Config_Hunt_Position_X.Properties).BeginInit();
			this.xtraTabPage3.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_Hunt_Config_Hunt_Indice_OCRCombat.Properties).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_Hunt_Config_Hunt_Indice_OCRCocheCheck.Properties).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_Hunt_Config_Hunt_Indice_OCRFleche.Properties).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_Hunt_Config_Hunt_Indice_HIndice.Properties).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_Hunt_Config_Hunt_Indice_LIndice.Properties).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_Hunt_Config_Hunt_Indice_OCRCoche.Properties).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_Hunt_Config_Hunt_Indice_HStart.Properties).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_Hunt_Config_Hunt_Indice_LStart.Properties).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_Hunt_Config_Hunt_Indice_OCRStart.Properties).BeginInit();
			this.xtraTabPage4.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.groupControl5).BeginInit();
			this.groupControl5.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox_Hunt_Config_Hunt_Template_Combat).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.groupControl4).BeginInit();
			this.groupControl4.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox_Hunt_Config_Hunt_Template_Level).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.groupControl3).BeginInit();
			this.groupControl3.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox_Hunt_Config_Hunt_Template_Start).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.groupControl2).BeginInit();
			this.groupControl2.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox_Hunt_Config_Hunt_Template_Arrow_6).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox_Hunt_Config_Hunt_Template_Arrow_4).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox_Hunt_Config_Hunt_Template_Arrow_2).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox_Hunt_Config_Hunt_Template_Arrow_0).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.groupControl1).BeginInit();
			this.groupControl1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox_Hunt_Config_Hunt_Template_CocheChecked).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox_Hunt_Config_Hunt_Template_Coche).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.panelControl_Hunt_Hunt).BeginInit();
			this.panelControl_Hunt_Hunt.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.checkEdit_Hunt_AutoTravel.Properties).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.comboBoxEdit_Hunt_Indice.Properties).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.separatorControl4).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.separatorControl3).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_Hunt_Y.Properties).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_Hunt_X.Properties).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.separatorControl2).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.toastNotificationsManager).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.panelControl_Hunt_HuntAuto).BeginInit();
			this.panelControl_Hunt_HuntAuto.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.checkEdit_Hunt_Auto_ModeReduit.Properties).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.checkEdit_HuntAuto_AutoTravel.Properties).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.panelControl_Home).BeginInit();
			this.panelControl_Home.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox_Discord).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.separatorControl5).BeginInit();
			base.SuspendLayout();
			this.panelControl_Hunt_Init.Controls.Add(this.progressPanel1);
			this.panelControl_Hunt_Init.Controls.Add(this.pictureBox_Hunt_Init_Logo);
			this.panelControl_Hunt_Init.Location = new global::System.Drawing.Point(187, 11);
			this.panelControl_Hunt_Init.Name = "panelControl_Hunt_Init";
			this.panelControl_Hunt_Init.Size = new global::System.Drawing.Size(300, 300);
			this.panelControl_Hunt_Init.TabIndex = 6;
			this.progressPanel1.Appearance.BackColor = global::System.Drawing.Color.Transparent;
			this.progressPanel1.Appearance.Options.UseBackColor = true;
			this.progressPanel1.Caption = "Chargement";
			this.progressPanel1.Description = "Initialisation du logiciel ...";
			this.progressPanel1.Location = new global::System.Drawing.Point(55, 168);
			this.progressPanel1.Name = "progressPanel1";
			this.progressPanel1.Size = new global::System.Drawing.Size(190, 66);
			this.progressPanel1.TabIndex = 7;
			this.progressPanel1.Text = "progressPanel_Hunt_Init";
			this.progressPanel1.WaitAnimationType = global::DevExpress.Utils.Animation.WaitingAnimatorType.Line;
			this.pictureBox_Hunt_Init_Logo.Image = global::Dofus_Hunt.Properties.Resources.logo;
			this.pictureBox_Hunt_Init_Logo.Location = new global::System.Drawing.Point(100, 8);
			this.pictureBox_Hunt_Init_Logo.Name = "pictureBox_Hunt_Init_Logo";
			this.pictureBox_Hunt_Init_Logo.Size = new global::System.Drawing.Size(100, 100);
			this.pictureBox_Hunt_Init_Logo.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox_Hunt_Init_Logo.TabIndex = 8;
			this.pictureBox_Hunt_Init_Logo.TabStop = false;
			this.panelControl_Hunt_Config_Logiciel.Controls.Add(this.checkEdit_Hunt_Config_Logiciel_UpdateDHU);
			this.panelControl_Hunt_Config_Logiciel.Controls.Add(this.checkEdit_Hunt_Config_Logiciel_Notifications);
			this.panelControl_Hunt_Config_Logiciel.Controls.Add(this.checkEdit_Hunt_Config_Logiciel_DeleteLog);
			this.panelControl_Hunt_Config_Logiciel.Controls.Add(this.checkEdit_Hunt_Config_Logiciel_DeleteFile);
			this.panelControl_Hunt_Config_Logiciel.Controls.Add(this.checkEdit_Hunt_Config_Logiciel_LogAvance);
			this.panelControl_Hunt_Config_Logiciel.Controls.Add(this.checkEdit_Hunt_Config_Logiciel_Theme);
			this.panelControl_Hunt_Config_Logiciel.Controls.Add(this.checkEdit_Hunt_Config_Logiciel_Ecran);
			this.panelControl_Hunt_Config_Logiciel.Controls.Add(this.trackBarControl_Hunt_Config_Logiciel_Opacity);
			this.panelControl_Hunt_Config_Logiciel.Controls.Add(this.labelControl_Hunt_Config_Logiciel_Opacité);
			this.panelControl_Hunt_Config_Logiciel.Location = new global::System.Drawing.Point(187, 11);
			this.panelControl_Hunt_Config_Logiciel.Name = "panelControl_Hunt_Config_Logiciel";
			this.panelControl_Hunt_Config_Logiciel.Size = new global::System.Drawing.Size(300, 300);
			this.panelControl_Hunt_Config_Logiciel.TabIndex = 8;
			this.panelControl_Hunt_Config_Logiciel.Visible = false;
			this.checkEdit_Hunt_Config_Logiciel_UpdateDHU.Location = new global::System.Drawing.Point(5, 213);
			this.checkEdit_Hunt_Config_Logiciel_UpdateDHU.Name = "checkEdit_Hunt_Config_Logiciel_UpdateDHU";
			this.checkEdit_Hunt_Config_Logiciel_UpdateDHU.Properties.Caption = "Mettre à jour automatiquement Dofus Hunt Update";
			this.checkEdit_Hunt_Config_Logiciel_UpdateDHU.Size = new global::System.Drawing.Size(275, 19);
			this.checkEdit_Hunt_Config_Logiciel_UpdateDHU.TabIndex = 9;
			this.checkEdit_Hunt_Config_Logiciel_UpdateDHU.CheckedChanged += new global::System.EventHandler(this.checkEdit_Hunt_Config_Logiciel_UpdateDHU_CheckedChanged);
			this.checkEdit_Hunt_Config_Logiciel_Notifications.Location = new global::System.Drawing.Point(5, 188);
			this.checkEdit_Hunt_Config_Logiciel_Notifications.Name = "checkEdit_Hunt_Config_Logiciel_Notifications";
			this.checkEdit_Hunt_Config_Logiciel_Notifications.Properties.Caption = "Autoriser les notifications d'application";
			this.checkEdit_Hunt_Config_Logiciel_Notifications.Size = new global::System.Drawing.Size(210, 19);
			this.checkEdit_Hunt_Config_Logiciel_Notifications.TabIndex = 8;
			this.checkEdit_Hunt_Config_Logiciel_Notifications.CheckedChanged += new global::System.EventHandler(this.checkEdit_Hunt_Config_Logiciel_Notifications_CheckedChanged);
			this.checkEdit_Hunt_Config_Logiciel_DeleteLog.Location = new global::System.Drawing.Point(5, 163);
			this.checkEdit_Hunt_Config_Logiciel_DeleteLog.Name = "checkEdit_Hunt_Config_Logiciel_DeleteLog";
			this.checkEdit_Hunt_Config_Logiciel_DeleteLog.Properties.Caption = "Supprimer les logs au bout de 3 jours";
			this.checkEdit_Hunt_Config_Logiciel_DeleteLog.Size = new global::System.Drawing.Size(202, 19);
			this.checkEdit_Hunt_Config_Logiciel_DeleteLog.TabIndex = 7;
			this.checkEdit_Hunt_Config_Logiciel_DeleteLog.CheckedChanged += new global::System.EventHandler(this.checkEdit_Hunt_Config_Logiciel_DeleteLog_CheckedChanged);
			this.checkEdit_Hunt_Config_Logiciel_DeleteFile.Location = new global::System.Drawing.Point(5, 138);
			this.checkEdit_Hunt_Config_Logiciel_DeleteFile.Name = "checkEdit_Hunt_Config_Logiciel_DeleteFile";
			this.checkEdit_Hunt_Config_Logiciel_DeleteFile.Properties.Caption = "Supprimer les fichiers de traitement";
			this.checkEdit_Hunt_Config_Logiciel_DeleteFile.Size = new global::System.Drawing.Size(193, 19);
			this.checkEdit_Hunt_Config_Logiciel_DeleteFile.TabIndex = 6;
			this.checkEdit_Hunt_Config_Logiciel_DeleteFile.CheckedChanged += new global::System.EventHandler(this.checkEdit_Hunt_Config_Logiciel_DeleteFile_CheckedChanged);
			this.checkEdit_Hunt_Config_Logiciel_LogAvance.Location = new global::System.Drawing.Point(5, 113);
			this.checkEdit_Hunt_Config_Logiciel_LogAvance.Name = "checkEdit_Hunt_Config_Logiciel_LogAvance";
			this.checkEdit_Hunt_Config_Logiciel_LogAvance.Properties.Caption = "Log avancés";
			this.checkEdit_Hunt_Config_Logiciel_LogAvance.Size = new global::System.Drawing.Size(80, 19);
			this.checkEdit_Hunt_Config_Logiciel_LogAvance.TabIndex = 5;
			this.checkEdit_Hunt_Config_Logiciel_LogAvance.CheckedChanged += new global::System.EventHandler(this.checkEdit_Hunt_Config_Logiciel_LogAvance_CheckedChanged);
			this.checkEdit_Hunt_Config_Logiciel_Theme.Location = new global::System.Drawing.Point(5, 88);
			this.checkEdit_Hunt_Config_Logiciel_Theme.Name = "checkEdit_Hunt_Config_Logiciel_Theme";
			this.checkEdit_Hunt_Config_Logiciel_Theme.Properties.Caption = "Thème Sombre";
			this.checkEdit_Hunt_Config_Logiciel_Theme.Size = new global::System.Drawing.Size(95, 19);
			this.checkEdit_Hunt_Config_Logiciel_Theme.TabIndex = 4;
			this.checkEdit_Hunt_Config_Logiciel_Theme.CheckedChanged += new global::System.EventHandler(this.checkEdit_Hunt_Config_Logiciel_Theme_CheckedChanged);
			this.checkEdit_Hunt_Config_Logiciel_Ecran.Location = new global::System.Drawing.Point(5, 63);
			this.checkEdit_Hunt_Config_Logiciel_Ecran.Name = "checkEdit_Hunt_Config_Logiciel_Ecran";
			this.checkEdit_Hunt_Config_Logiciel_Ecran.Properties.Caption = "Toujours à l'écran";
			this.checkEdit_Hunt_Config_Logiciel_Ecran.Size = new global::System.Drawing.Size(110, 19);
			this.checkEdit_Hunt_Config_Logiciel_Ecran.TabIndex = 3;
			this.checkEdit_Hunt_Config_Logiciel_Ecran.CheckedChanged += new global::System.EventHandler(this.checkEdit_Hunt_Config_Logiciel_Ecran_CheckedChanged);
			this.trackBarControl_Hunt_Config_Logiciel_Opacity.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.trackBarControl_Hunt_Config_Logiciel_Opacity.EditValue = 100;
			this.trackBarControl_Hunt_Config_Logiciel_Opacity.Location = new global::System.Drawing.Point(5, 25);
			this.trackBarControl_Hunt_Config_Logiciel_Opacity.Name = "trackBarControl_Hunt_Config_Logiciel_Opacity";
			this.trackBarControl_Hunt_Config_Logiciel_Opacity.Properties.LabelAppearance.Options.UseTextOptions = true;
			this.trackBarControl_Hunt_Config_Logiciel_Opacity.Properties.LabelAppearance.TextOptions.HAlignment = global::DevExpress.Utils.HorzAlignment.Center;
			this.trackBarControl_Hunt_Config_Logiciel_Opacity.Properties.LargeChange = 1;
			this.trackBarControl_Hunt_Config_Logiciel_Opacity.Properties.Maximum = 100;
			this.trackBarControl_Hunt_Config_Logiciel_Opacity.Properties.TickStyle = global::System.Windows.Forms.TickStyle.None;
			this.trackBarControl_Hunt_Config_Logiciel_Opacity.Size = new global::System.Drawing.Size(275, 45);
			this.trackBarControl_Hunt_Config_Logiciel_Opacity.TabIndex = 2;
			this.trackBarControl_Hunt_Config_Logiciel_Opacity.Value = 100;
			this.trackBarControl_Hunt_Config_Logiciel_Opacity.Click += new global::System.EventHandler(this.trackBarControl_Hunt_Config_Logiciel_Opacity_Click);
			this.labelControl_Hunt_Config_Logiciel_Opacité.Location = new global::System.Drawing.Point(5, 5);
			this.labelControl_Hunt_Config_Logiciel_Opacité.Name = "labelControl_Hunt_Config_Logiciel_Opacité";
			this.labelControl_Hunt_Config_Logiciel_Opacité.Size = new global::System.Drawing.Size(117, 13);
			this.labelControl_Hunt_Config_Logiciel_Opacité.TabIndex = 0;
			this.labelControl_Hunt_Config_Logiciel_Opacité.Text = "Opacité de l'application :";
			this.panelControl_Hunt_Notifications.Controls.Add(this.simpleButton_Notify_Reinit);
			this.panelControl_Hunt_Notifications.Controls.Add(this.simpleButton_Notify_Save);
			this.panelControl_Hunt_Notifications.Controls.Add(this.xtraTabControl_Hunt_Config_Notifications);
			this.panelControl_Hunt_Notifications.Location = new global::System.Drawing.Point(187, 11);
			this.panelControl_Hunt_Notifications.Name = "panelControl_Hunt_Notifications";
			this.panelControl_Hunt_Notifications.Size = new global::System.Drawing.Size(300, 300);
			this.panelControl_Hunt_Notifications.TabIndex = 9;
			this.panelControl_Hunt_Notifications.Visible = false;
			this.simpleButton_Notify_Reinit.Location = new global::System.Drawing.Point(5, 272);
			this.simpleButton_Notify_Reinit.Name = "simpleButton_Notify_Reinit";
			this.simpleButton_Notify_Reinit.Size = new global::System.Drawing.Size(110, 23);
			this.simpleButton_Notify_Reinit.TabIndex = 2;
			this.simpleButton_Notify_Reinit.Text = "Réinitialiser";
			this.simpleButton_Notify_Reinit.Click += new global::System.EventHandler(this.simpleButton_Notify_Reinit_Click);
			this.simpleButton_Notify_Save.Location = new global::System.Drawing.Point(184, 272);
			this.simpleButton_Notify_Save.Name = "simpleButton_Notify_Save";
			this.simpleButton_Notify_Save.Size = new global::System.Drawing.Size(110, 23);
			this.simpleButton_Notify_Save.TabIndex = 1;
			this.simpleButton_Notify_Save.Text = "Sauvegarder";
			this.simpleButton_Notify_Save.Click += new global::System.EventHandler(this.simpleButton_Notify_Save_Click);
			this.xtraTabControl_Hunt_Config_Notifications.Location = new global::System.Drawing.Point(5, 5);
			this.xtraTabControl_Hunt_Config_Notifications.Name = "xtraTabControl_Hunt_Config_Notifications";
			this.xtraTabControl_Hunt_Config_Notifications.SelectedTabPage = this.xtraTabPage_Notifications_App;
			this.xtraTabControl_Hunt_Config_Notifications.Size = new global::System.Drawing.Size(290, 261);
			this.xtraTabControl_Hunt_Config_Notifications.TabIndex = 0;
			this.xtraTabControl_Hunt_Config_Notifications.TabPages.AddRange(new global::DevExpress.XtraTab.XtraTabPage[] { this.xtraTabPage_Notifications_App, this.xtraTabPage_Notifications_Hunt, this.xtraTabPage_Notifications_Indice });
			this.xtraTabPage_Notifications_App.Controls.Add(this.textEdit_Notify_App_Restart);
			this.xtraTabPage_Notifications_App.Controls.Add(this.labelControl_Notify_App_Restart);
			this.xtraTabPage_Notifications_App.Controls.Add(this.textEdit_Notify_App_PbData);
			this.xtraTabPage_Notifications_App.Controls.Add(this.labelControl_Notify_App_PbData);
			this.xtraTabPage_Notifications_App.Controls.Add(this.textEdit_Notify_App_PbCo);
			this.xtraTabPage_Notifications_App.Controls.Add(this.labelControl_Notify_App_PbCo);
			this.xtraTabPage_Notifications_App.Controls.Add(this.textEdit_Notify_App_Update);
			this.xtraTabPage_Notifications_App.Controls.Add(this.labelControl_Notify_App_Uodate);
			this.xtraTabPage_Notifications_App.Name = "xtraTabPage_Notifications_App";
			this.xtraTabPage_Notifications_App.Size = new global::System.Drawing.Size(288, 236);
			this.xtraTabPage_Notifications_App.Text = "Application";
			this.textEdit_Notify_App_Restart.Location = new global::System.Drawing.Point(11, 157);
			this.textEdit_Notify_App_Restart.Name = "textEdit_Notify_App_Restart";
			this.textEdit_Notify_App_Restart.Size = new global::System.Drawing.Size(267, 20);
			this.textEdit_Notify_App_Restart.TabIndex = 7;
			this.labelControl_Notify_App_Restart.Location = new global::System.Drawing.Point(11, 138);
			this.labelControl_Notify_App_Restart.Name = "labelControl_Notify_App_Restart";
			this.labelControl_Notify_App_Restart.Size = new global::System.Drawing.Size(126, 13);
			this.labelControl_Notify_App_Restart.TabIndex = 6;
			this.labelControl_Notify_App_Restart.Text = "Redémarrage nécessaire :";
			this.textEdit_Notify_App_PbData.Location = new global::System.Drawing.Point(11, 112);
			this.textEdit_Notify_App_PbData.Name = "textEdit_Notify_App_PbData";
			this.textEdit_Notify_App_PbData.Size = new global::System.Drawing.Size(267, 20);
			this.textEdit_Notify_App_PbData.TabIndex = 5;
			this.labelControl_Notify_App_PbData.Location = new global::System.Drawing.Point(11, 93);
			this.labelControl_Notify_App_PbData.Name = "labelControl_Notify_App_PbData";
			this.labelControl_Notify_App_PbData.Size = new global::System.Drawing.Size(194, 13);
			this.labelControl_Notify_App_PbData.TabIndex = 4;
			this.labelControl_Notify_App_PbData.Text = "Problème de récupération des données :";
			this.textEdit_Notify_App_PbCo.Location = new global::System.Drawing.Point(11, 67);
			this.textEdit_Notify_App_PbCo.Name = "textEdit_Notify_App_PbCo";
			this.textEdit_Notify_App_PbCo.Size = new global::System.Drawing.Size(267, 20);
			this.textEdit_Notify_App_PbCo.TabIndex = 3;
			this.labelControl_Notify_App_PbCo.Location = new global::System.Drawing.Point(11, 48);
			this.labelControl_Notify_App_PbCo.Name = "labelControl_Notify_App_PbCo";
			this.labelControl_Notify_App_PbCo.Size = new global::System.Drawing.Size(118, 13);
			this.labelControl_Notify_App_PbCo.TabIndex = 2;
			this.labelControl_Notify_App_PbCo.Text = "Problème de connexion :";
			this.textEdit_Notify_App_Update.Location = new global::System.Drawing.Point(11, 22);
			this.textEdit_Notify_App_Update.Name = "textEdit_Notify_App_Update";
			this.textEdit_Notify_App_Update.Size = new global::System.Drawing.Size(267, 20);
			this.textEdit_Notify_App_Update.TabIndex = 1;
			this.labelControl_Notify_App_Uodate.Location = new global::System.Drawing.Point(11, 3);
			this.labelControl_Notify_App_Uodate.Name = "labelControl_Notify_App_Uodate";
			this.labelControl_Notify_App_Uodate.Size = new global::System.Drawing.Size(109, 13);
			this.labelControl_Notify_App_Uodate.TabIndex = 0;
			this.labelControl_Notify_App_Uodate.Text = "Mise à jour disponible :";
			this.xtraTabPage_Notifications_Hunt.Controls.Add(this.textEdit_Notify_Hunt_NoData);
			this.xtraTabPage_Notifications_Hunt.Controls.Add(this.labelControl_Notify_Hunt_NoData);
			this.xtraTabPage_Notifications_Hunt.Name = "xtraTabPage_Notifications_Hunt";
			this.xtraTabPage_Notifications_Hunt.Size = new global::System.Drawing.Size(288, 236);
			this.xtraTabPage_Notifications_Hunt.Text = "Chasse au trésor";
			this.textEdit_Notify_Hunt_NoData.Location = new global::System.Drawing.Point(11, 22);
			this.textEdit_Notify_Hunt_NoData.Name = "textEdit_Notify_Hunt_NoData";
			this.textEdit_Notify_Hunt_NoData.Size = new global::System.Drawing.Size(267, 20);
			this.textEdit_Notify_Hunt_NoData.TabIndex = 3;
			this.labelControl_Notify_Hunt_NoData.Location = new global::System.Drawing.Point(11, 3);
			this.labelControl_Notify_Hunt_NoData.Name = "labelControl_Notify_Hunt_NoData";
			this.labelControl_Notify_Hunt_NoData.Size = new global::System.Drawing.Size(87, 13);
			this.labelControl_Notify_Hunt_NoData.TabIndex = 2;
			this.labelControl_Notify_Hunt_NoData.Text = "Aucune données :";
			this.xtraTabPage_Notifications_Indice.Controls.Add(this.textEdit_Indices_CorrectIndice);
			this.xtraTabPage_Notifications_Indice.Controls.Add(this.labelControl_Indices_CorrectIndice);
			this.xtraTabPage_Notifications_Indice.Controls.Add(this.textEdit_Indices_Phorreur);
			this.xtraTabPage_Notifications_Indice.Controls.Add(this.labelControl_Indices_Phorreur);
			this.xtraTabPage_Notifications_Indice.Controls.Add(this.textEdit_Indices_IndiceKO);
			this.xtraTabPage_Notifications_Indice.Controls.Add(this.labelControl_Indices_IndiceKO);
			this.xtraTabPage_Notifications_Indice.Controls.Add(this.textEdit_Indices_IndiceOK);
			this.xtraTabPage_Notifications_Indice.Controls.Add(this.labelControl_Indices_IndiceOK);
			this.xtraTabPage_Notifications_Indice.Name = "xtraTabPage_Notifications_Indice";
			this.xtraTabPage_Notifications_Indice.Size = new global::System.Drawing.Size(288, 236);
			this.xtraTabPage_Notifications_Indice.Text = "Indices";
			this.textEdit_Indices_CorrectIndice.Location = new global::System.Drawing.Point(11, 157);
			this.textEdit_Indices_CorrectIndice.Name = "textEdit_Indices_CorrectIndice";
			this.textEdit_Indices_CorrectIndice.Size = new global::System.Drawing.Size(267, 20);
			this.textEdit_Indices_CorrectIndice.TabIndex = 11;
			this.labelControl_Indices_CorrectIndice.Location = new global::System.Drawing.Point(11, 138);
			this.labelControl_Indices_CorrectIndice.Name = "labelControl_Indices_CorrectIndice";
			this.labelControl_Indices_CorrectIndice.Size = new global::System.Drawing.Size(95, 13);
			this.labelControl_Indices_CorrectIndice.TabIndex = 10;
			this.labelControl_Indices_CorrectIndice.Text = "Correction d'indice :";
			this.textEdit_Indices_Phorreur.Location = new global::System.Drawing.Point(11, 112);
			this.textEdit_Indices_Phorreur.Name = "textEdit_Indices_Phorreur";
			this.textEdit_Indices_Phorreur.Size = new global::System.Drawing.Size(267, 20);
			this.textEdit_Indices_Phorreur.TabIndex = 9;
			this.labelControl_Indices_Phorreur.Location = new global::System.Drawing.Point(11, 93);
			this.labelControl_Indices_Phorreur.Name = "labelControl_Indices_Phorreur";
			this.labelControl_Indices_Phorreur.Size = new global::System.Drawing.Size(49, 13);
			this.labelControl_Indices_Phorreur.TabIndex = 8;
			this.labelControl_Indices_Phorreur.Text = "Phorreur :";
			this.textEdit_Indices_IndiceKO.Location = new global::System.Drawing.Point(11, 67);
			this.textEdit_Indices_IndiceKO.Name = "textEdit_Indices_IndiceKO";
			this.textEdit_Indices_IndiceKO.Size = new global::System.Drawing.Size(267, 20);
			this.textEdit_Indices_IndiceKO.TabIndex = 7;
			this.labelControl_Indices_IndiceKO.Location = new global::System.Drawing.Point(11, 48);
			this.labelControl_Indices_IndiceKO.Name = "labelControl_Indices_IndiceKO";
			this.labelControl_Indices_IndiceKO.Size = new global::System.Drawing.Size(53, 13);
			this.labelControl_Indices_IndiceKO.TabIndex = 6;
			this.labelControl_Indices_IndiceKO.Text = "Indice KO :";
			this.textEdit_Indices_IndiceOK.Location = new global::System.Drawing.Point(11, 22);
			this.textEdit_Indices_IndiceOK.Name = "textEdit_Indices_IndiceOK";
			this.textEdit_Indices_IndiceOK.Size = new global::System.Drawing.Size(267, 20);
			this.textEdit_Indices_IndiceOK.TabIndex = 5;
			this.labelControl_Indices_IndiceOK.Location = new global::System.Drawing.Point(11, 3);
			this.labelControl_Indices_IndiceOK.Name = "labelControl_Indices_IndiceOK";
			this.labelControl_Indices_IndiceOK.Size = new global::System.Drawing.Size(53, 13);
			this.labelControl_Indices_IndiceOK.TabIndex = 4;
			this.labelControl_Indices_IndiceOK.Text = "Indice OK :";
			this.panelControl_Hunt_Indice.Controls.Add(this.simpleButton_Hunt_Indice_Add);
			this.panelControl_Hunt_Indice.Controls.Add(this.textEdit_Hunt_Indice_Correct);
			this.panelControl_Hunt_Indice.Controls.Add(this.labelControl_Hunt_Indice_Correct);
			this.panelControl_Hunt_Indice.Controls.Add(this.textEdit_Hunt_Indice_Incorrect);
			this.panelControl_Hunt_Indice.Controls.Add(this.labelControl_Hunt_Indice_Incorrect);
			this.panelControl_Hunt_Indice.Controls.Add(this.dataGridView_Hunt_Indice_List);
			this.panelControl_Hunt_Indice.Location = new global::System.Drawing.Point(187, 11);
			this.panelControl_Hunt_Indice.Name = "panelControl_Hunt_Indice";
			this.panelControl_Hunt_Indice.Size = new global::System.Drawing.Size(300, 300);
			this.panelControl_Hunt_Indice.TabIndex = 10;
			this.panelControl_Hunt_Indice.Visible = false;
			this.simpleButton_Hunt_Indice_Add.Location = new global::System.Drawing.Point(153, 271);
			this.simpleButton_Hunt_Indice_Add.Name = "simpleButton_Hunt_Indice_Add";
			this.simpleButton_Hunt_Indice_Add.Size = new global::System.Drawing.Size(132, 23);
			this.simpleButton_Hunt_Indice_Add.TabIndex = 5;
			this.simpleButton_Hunt_Indice_Add.Text = "Ajouter";
			this.simpleButton_Hunt_Indice_Add.Click += new global::System.EventHandler(this.simpleButton_Hunt_Indice_Add_Click);
			this.textEdit_Hunt_Indice_Correct.Location = new global::System.Drawing.Point(153, 246);
			this.textEdit_Hunt_Indice_Correct.Name = "textEdit_Hunt_Indice_Correct";
			this.textEdit_Hunt_Indice_Correct.Size = new global::System.Drawing.Size(132, 20);
			this.textEdit_Hunt_Indice_Correct.TabIndex = 4;
			this.labelControl_Hunt_Indice_Correct.Location = new global::System.Drawing.Point(153, 227);
			this.labelControl_Hunt_Indice_Correct.Name = "labelControl_Hunt_Indice_Correct";
			this.labelControl_Hunt_Indice_Correct.Size = new global::System.Drawing.Size(73, 13);
			this.labelControl_Hunt_Indice_Correct.TabIndex = 3;
			this.labelControl_Hunt_Indice_Correct.Text = "Indice correct :";
			this.textEdit_Hunt_Indice_Incorrect.Location = new global::System.Drawing.Point(15, 246);
			this.textEdit_Hunt_Indice_Incorrect.Name = "textEdit_Hunt_Indice_Incorrect";
			this.textEdit_Hunt_Indice_Incorrect.Size = new global::System.Drawing.Size(132, 20);
			this.textEdit_Hunt_Indice_Incorrect.TabIndex = 2;
			this.labelControl_Hunt_Indice_Incorrect.Location = new global::System.Drawing.Point(15, 227);
			this.labelControl_Hunt_Indice_Incorrect.Name = "labelControl_Hunt_Indice_Incorrect";
			this.labelControl_Hunt_Indice_Incorrect.Size = new global::System.Drawing.Size(81, 13);
			this.labelControl_Hunt_Indice_Incorrect.TabIndex = 1;
			this.labelControl_Hunt_Indice_Incorrect.Text = "Indice incorrect :";
			this.dataGridView_Hunt_Indice_List.ColumnHeadersHeightSizeMode = global::System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView_Hunt_Indice_List.Columns.AddRange(new global::System.Windows.Forms.DataGridViewColumn[] { this.Column_Incorrect, this.Column_Correct });
			dataGridViewCellStyle3.Alignment = global::System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = global::System.Drawing.SystemColors.Window;
			dataGridViewCellStyle3.Font = new global::System.Drawing.Font("Tahoma", 8.25f);
			dataGridViewCellStyle3.ForeColor = global::System.Drawing.Color.FromArgb(227, 227, 227);
			dataGridViewCellStyle3.SelectionBackColor = global::System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = global::System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = global::System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridView_Hunt_Indice_List.DefaultCellStyle = dataGridViewCellStyle3;
			this.dataGridView_Hunt_Indice_List.Location = new global::System.Drawing.Point(11, 8);
			this.dataGridView_Hunt_Indice_List.Name = "dataGridView_Hunt_Indice_List";
			this.dataGridView_Hunt_Indice_List.Size = new global::System.Drawing.Size(279, 213);
			this.dataGridView_Hunt_Indice_List.TabIndex = 0;
			dataGridViewCellStyle4.ForeColor = global::System.Drawing.Color.Black;
			this.Column_Incorrect.DefaultCellStyle = dataGridViewCellStyle4;
			this.Column_Incorrect.FillWeight = 118f;
			this.Column_Incorrect.HeaderText = "Indice incorrect";
			this.Column_Incorrect.Name = "Column_Incorrect";
			this.Column_Incorrect.ReadOnly = true;
			this.Column_Incorrect.Width = 118;
			dataGridViewCellStyle5.ForeColor = global::System.Drawing.Color.Black;
			this.Column_Correct.DefaultCellStyle = dataGridViewCellStyle5;
			this.Column_Correct.FillWeight = 118f;
			this.Column_Correct.HeaderText = "Indice correct";
			this.Column_Correct.Name = "Column_Correct";
			this.Column_Correct.ReadOnly = true;
			this.Column_Correct.Width = 118;
			this.accordionControl1.Elements.AddRange(new global::DevExpress.XtraBars.Navigation.AccordionControlElement[] { this.accordionControlElement_Menu_Hunt, this.accordionControlElement_Menu_Config });
			this.accordionControl1.Enabled = false;
			this.accordionControl1.Location = new global::System.Drawing.Point(12, 11);
			this.accordionControl1.Name = "accordionControl1";
			this.accordionControl1.ScrollBarMode = global::DevExpress.XtraBars.Navigation.ScrollBarMode.Hidden;
			this.accordionControl1.Size = new global::System.Drawing.Size(169, 300);
			this.accordionControl1.TabIndex = 14;
			this.accordionControlElement_Menu_Hunt.Elements.AddRange(new global::DevExpress.XtraBars.Navigation.AccordionControlElement[] { this.accordionControlElement_SubMenu_HuntAuto, this.accordionControlElement_SubMenu_Hunt });
			this.accordionControlElement_Menu_Hunt.Expanded = true;
			this.accordionControlElement_Menu_Hunt.Name = "accordionControlElement_Menu_Hunt";
			this.accordionControlElement_Menu_Hunt.Text = "Chasse au trésor";
			this.accordionControlElement_SubMenu_HuntAuto.Name = "accordionControlElement_SubMenu_HuntAuto";
			this.accordionControlElement_SubMenu_HuntAuto.Style = global::DevExpress.XtraBars.Navigation.ElementStyle.Item;
			this.accordionControlElement_SubMenu_HuntAuto.Text = "Automatique";
			this.accordionControlElement_SubMenu_HuntAuto.Click += new global::System.EventHandler(this.accordionControlElement_SubMenu_HuntAuto_Click);
			this.accordionControlElement_SubMenu_Hunt.Name = "accordionControlElement_SubMenu_Hunt";
			this.accordionControlElement_SubMenu_Hunt.Style = global::DevExpress.XtraBars.Navigation.ElementStyle.Item;
			this.accordionControlElement_SubMenu_Hunt.Text = "Manuel";
			this.accordionControlElement_SubMenu_Hunt.Click += new global::System.EventHandler(this.accordionControlElement_SubMenu_Hunt_Click);
			this.accordionControlElement_Menu_Config.Elements.AddRange(new global::DevExpress.XtraBars.Navigation.AccordionControlElement[] { this.accordionControlElement_SubMenu_Config_Logiciel, this.accordionControlElement_SubMenu_Config_HuntAuto, this.accordionControlElement_SubMenu_Config_Indice, this.accordionControlElement_SubMenu_Config_Notif, this.accordionControlElement_SubMenu_Config_Update, this.accordionControlElement_SubMenu_Config_Debug });
			this.accordionControlElement_Menu_Config.Expanded = true;
			this.accordionControlElement_Menu_Config.Name = "accordionControlElement_Menu_Config";
			this.accordionControlElement_Menu_Config.Text = "Configurations";
			this.accordionControlElement_SubMenu_Config_Logiciel.Name = "accordionControlElement_SubMenu_Config_Logiciel";
			this.accordionControlElement_SubMenu_Config_Logiciel.Style = global::DevExpress.XtraBars.Navigation.ElementStyle.Item;
			this.accordionControlElement_SubMenu_Config_Logiciel.Text = "Logiciel";
			this.accordionControlElement_SubMenu_Config_Logiciel.Click += new global::System.EventHandler(this.accordionControlElement_SubMenu_Config_Logiciel_Click);
			this.accordionControlElement_SubMenu_Config_HuntAuto.Name = "accordionControlElement_SubMenu_Config_HuntAuto";
			this.accordionControlElement_SubMenu_Config_HuntAuto.Style = global::DevExpress.XtraBars.Navigation.ElementStyle.Item;
			this.accordionControlElement_SubMenu_Config_HuntAuto.Text = "Chasse automatique";
			this.accordionControlElement_SubMenu_Config_HuntAuto.Click += new global::System.EventHandler(this.accordionControlElement_SubMenu_Config_HuntAuto_Click);
			this.accordionControlElement_SubMenu_Config_Indice.Name = "accordionControlElement_SubMenu_Config_Indice";
			this.accordionControlElement_SubMenu_Config_Indice.Style = global::DevExpress.XtraBars.Navigation.ElementStyle.Item;
			this.accordionControlElement_SubMenu_Config_Indice.Text = "Correction d'indice";
			this.accordionControlElement_SubMenu_Config_Indice.Click += new global::System.EventHandler(this.accordionControlElement_SubMenu_Config_Indice_Click);
			this.accordionControlElement_SubMenu_Config_Notif.Name = "accordionControlElement_SubMenu_Config_Notif";
			this.accordionControlElement_SubMenu_Config_Notif.Style = global::DevExpress.XtraBars.Navigation.ElementStyle.Item;
			this.accordionControlElement_SubMenu_Config_Notif.Text = "Notifications";
			this.accordionControlElement_SubMenu_Config_Notif.Click += new global::System.EventHandler(this.accordionControlElement_SubMenu_Config_Notif_Click);
			this.accordionControlElement_SubMenu_Config_Update.Name = "accordionControlElement_SubMenu_Config_Update";
			this.accordionControlElement_SubMenu_Config_Update.Style = global::DevExpress.XtraBars.Navigation.ElementStyle.Item;
			this.accordionControlElement_SubMenu_Config_Update.Text = "Mise à jour";
			this.accordionControlElement_SubMenu_Config_Update.Visible = false;
			this.accordionControlElement_SubMenu_Config_Update.Click += new global::System.EventHandler(this.accordionControlElement_SubMenu_Config_Update_Click);
			this.accordionControlElement_SubMenu_Config_Debug.HeaderTemplate.AddRange(new global::DevExpress.XtraBars.Navigation.HeaderElementInfo[]
			{
				new global::DevExpress.XtraBars.Navigation.HeaderElementInfo(global::DevExpress.XtraBars.Navigation.HeaderElementType.Text),
				new global::DevExpress.XtraBars.Navigation.HeaderElementInfo(global::DevExpress.XtraBars.Navigation.HeaderElementType.Image),
				new global::DevExpress.XtraBars.Navigation.HeaderElementInfo(global::DevExpress.XtraBars.Navigation.HeaderElementType.HeaderControl),
				new global::DevExpress.XtraBars.Navigation.HeaderElementInfo(global::DevExpress.XtraBars.Navigation.HeaderElementType.ContextButtons)
			});
			this.accordionControlElement_SubMenu_Config_Debug.Name = "accordionControlElement_SubMenu_Config_Debug";
			this.accordionControlElement_SubMenu_Config_Debug.Style = global::DevExpress.XtraBars.Navigation.ElementStyle.Item;
			this.accordionControlElement_SubMenu_Config_Debug.Text = "Debug";
			this.accordionControlElement_SubMenu_Config_Debug.Visible = false;
			this.accordionControlElement_SubMenu_Config_Debug.Click += new global::System.EventHandler(this.accordionControlElement_SubMenu_Config_Debug_Click);
			this.labelControl_Hunt_Version.Location = new global::System.Drawing.Point(115, 91);
			this.labelControl_Hunt_Version.Name = "labelControl_Hunt_Version";
			this.labelControl_Hunt_Version.Size = new global::System.Drawing.Size(71, 13);
			this.labelControl_Hunt_Version.TabIndex = 15;
			this.labelControl_Hunt_Version.Text = "Version : x.x.x";
			this.panelControl_Hunt_Debug.Controls.Add(this.simpleButton_Hunt_Debug_GetArrow);
			this.panelControl_Hunt_Debug.Controls.Add(this.simpleButton_Hunt_Debug_GetIndice);
			this.panelControl_Hunt_Debug.Controls.Add(this.simpleButton_Hunt_Debug_GetPosition);
			this.panelControl_Hunt_Debug.Controls.Add(this.simpleButton_Hunt_Debug_GetPositionIndice);
			this.panelControl_Hunt_Debug.Controls.Add(this.textEdit_Hunt_Debug_Indice);
			this.panelControl_Hunt_Debug.Controls.Add(this.labelControl_Hunt_Debug_Indice);
			this.panelControl_Hunt_Debug.Controls.Add(this.textEdit_Hunt_Debug_Dir);
			this.panelControl_Hunt_Debug.Controls.Add(this.labelControl_Hunt_Debug_Dir);
			this.panelControl_Hunt_Debug.Controls.Add(this.textEdit_Hunt_Debug_Y);
			this.panelControl_Hunt_Debug.Controls.Add(this.labelControl_Hunt_Debug_Y);
			this.panelControl_Hunt_Debug.Controls.Add(this.textEdit_Hunt_Debug_X);
			this.panelControl_Hunt_Debug.Controls.Add(this.labelControl_Hunt_Debug_X);
			this.panelControl_Hunt_Debug.Controls.Add(this.simpleButton_Hunt_Debug_Capture);
			this.panelControl_Hunt_Debug.Controls.Add(this.simpleButton_Hunt_Debug_Token);
			this.panelControl_Hunt_Debug.Controls.Add(this.textEdit_Hunt_Debug_Token);
			this.panelControl_Hunt_Debug.Controls.Add(this.labelControl_Hunt_Debug_Token);
			this.panelControl_Hunt_Debug.Controls.Add(this.separatorControl1);
			this.panelControl_Hunt_Debug.Controls.Add(this.labelControl_Hunt_Debug);
			this.panelControl_Hunt_Debug.Location = new global::System.Drawing.Point(187, 11);
			this.panelControl_Hunt_Debug.Name = "panelControl_Hunt_Debug";
			this.panelControl_Hunt_Debug.Size = new global::System.Drawing.Size(300, 300);
			this.panelControl_Hunt_Debug.TabIndex = 11;
			this.panelControl_Hunt_Debug.Visible = false;
			this.simpleButton_Hunt_Debug_GetArrow.Location = new global::System.Drawing.Point(9, 245);
			this.simpleButton_Hunt_Debug_GetArrow.Name = "simpleButton_Hunt_Debug_GetArrow";
			this.simpleButton_Hunt_Debug_GetArrow.Size = new global::System.Drawing.Size(282, 20);
			this.simpleButton_Hunt_Debug_GetArrow.TabIndex = 17;
			this.simpleButton_Hunt_Debug_GetArrow.Text = "Get Arrow Position";
			this.simpleButton_Hunt_Debug_GetArrow.Click += new global::System.EventHandler(this.simpleButton_Hunt_Debug_GetArrow_Click);
			this.simpleButton_Hunt_Debug_GetIndice.Location = new global::System.Drawing.Point(9, 219);
			this.simpleButton_Hunt_Debug_GetIndice.Name = "simpleButton_Hunt_Debug_GetIndice";
			this.simpleButton_Hunt_Debug_GetIndice.Size = new global::System.Drawing.Size(282, 20);
			this.simpleButton_Hunt_Debug_GetIndice.TabIndex = 16;
			this.simpleButton_Hunt_Debug_GetIndice.Text = "Get Indice";
			this.simpleButton_Hunt_Debug_GetIndice.Click += new global::System.EventHandler(this.simpleButton_Hunt_Debug_GetIndice_Click);
			this.simpleButton_Hunt_Debug_GetPosition.Location = new global::System.Drawing.Point(9, 193);
			this.simpleButton_Hunt_Debug_GetPosition.Name = "simpleButton_Hunt_Debug_GetPosition";
			this.simpleButton_Hunt_Debug_GetPosition.Size = new global::System.Drawing.Size(282, 20);
			this.simpleButton_Hunt_Debug_GetPosition.TabIndex = 15;
			this.simpleButton_Hunt_Debug_GetPosition.Text = "Get Position";
			this.simpleButton_Hunt_Debug_GetPosition.Click += new global::System.EventHandler(this.simpleButton_Hunt_Debug_GetPosition_Click);
			this.simpleButton_Hunt_Debug_GetPositionIndice.Location = new global::System.Drawing.Point(9, 167);
			this.simpleButton_Hunt_Debug_GetPositionIndice.Name = "simpleButton_Hunt_Debug_GetPositionIndice";
			this.simpleButton_Hunt_Debug_GetPositionIndice.Size = new global::System.Drawing.Size(282, 20);
			this.simpleButton_Hunt_Debug_GetPositionIndice.TabIndex = 14;
			this.simpleButton_Hunt_Debug_GetPositionIndice.Text = "Get Position Indice";
			this.simpleButton_Hunt_Debug_GetPositionIndice.Click += new global::System.EventHandler(this.simpleButton_Hunt_Debug_GetPositionIndice_Click);
			this.textEdit_Hunt_Debug_Indice.Location = new global::System.Drawing.Point(207, 141);
			this.textEdit_Hunt_Debug_Indice.Name = "textEdit_Hunt_Debug_Indice";
			this.textEdit_Hunt_Debug_Indice.Size = new global::System.Drawing.Size(84, 20);
			this.textEdit_Hunt_Debug_Indice.TabIndex = 13;
			this.labelControl_Hunt_Debug_Indice.Location = new global::System.Drawing.Point(165, 144);
			this.labelControl_Hunt_Debug_Indice.Name = "labelControl_Hunt_Debug_Indice";
			this.labelControl_Hunt_Debug_Indice.Size = new global::System.Drawing.Size(36, 13);
			this.labelControl_Hunt_Debug_Indice.TabIndex = 12;
			this.labelControl_Hunt_Debug_Indice.Text = "Indice :";
			this.textEdit_Hunt_Debug_Dir.Location = new global::System.Drawing.Point(139, 141);
			this.textEdit_Hunt_Debug_Dir.Name = "textEdit_Hunt_Debug_Dir";
			this.textEdit_Hunt_Debug_Dir.Size = new global::System.Drawing.Size(20, 20);
			this.textEdit_Hunt_Debug_Dir.TabIndex = 11;
			this.labelControl_Hunt_Debug_Dir.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.labelControl_Hunt_Debug_Dir.Location = new global::System.Drawing.Point(109, 144);
			this.labelControl_Hunt_Debug_Dir.Name = "labelControl_Hunt_Debug_Dir";
			this.labelControl_Hunt_Debug_Dir.Size = new global::System.Drawing.Size(24, 13);
			this.labelControl_Hunt_Debug_Dir.TabIndex = 10;
			this.labelControl_Hunt_Debug_Dir.Text = "Dir. :";
			this.labelControl_Hunt_Debug_Dir.ToolTip = "Haut : 6\r\nDroite : 0\r\nBas : 2\r\nGauche : 4";
			this.textEdit_Hunt_Debug_Y.Location = new global::System.Drawing.Point(78, 141);
			this.textEdit_Hunt_Debug_Y.Name = "textEdit_Hunt_Debug_Y";
			this.textEdit_Hunt_Debug_Y.Size = new global::System.Drawing.Size(25, 20);
			this.textEdit_Hunt_Debug_Y.TabIndex = 9;
			this.labelControl_Hunt_Debug_Y.Location = new global::System.Drawing.Point(59, 144);
			this.labelControl_Hunt_Debug_Y.Name = "labelControl_Hunt_Debug_Y";
			this.labelControl_Hunt_Debug_Y.Size = new global::System.Drawing.Size(13, 13);
			this.labelControl_Hunt_Debug_Y.TabIndex = 8;
			this.labelControl_Hunt_Debug_Y.Text = "Y :";
			this.textEdit_Hunt_Debug_X.Location = new global::System.Drawing.Point(28, 141);
			this.textEdit_Hunt_Debug_X.Name = "textEdit_Hunt_Debug_X";
			this.textEdit_Hunt_Debug_X.Size = new global::System.Drawing.Size(25, 20);
			this.textEdit_Hunt_Debug_X.TabIndex = 7;
			this.labelControl_Hunt_Debug_X.Location = new global::System.Drawing.Point(9, 146);
			this.labelControl_Hunt_Debug_X.Name = "labelControl_Hunt_Debug_X";
			this.labelControl_Hunt_Debug_X.Size = new global::System.Drawing.Size(13, 13);
			this.labelControl_Hunt_Debug_X.TabIndex = 6;
			this.labelControl_Hunt_Debug_X.Text = "X :";
			this.simpleButton_Hunt_Debug_Capture.Location = new global::System.Drawing.Point(9, 115);
			this.simpleButton_Hunt_Debug_Capture.Name = "simpleButton_Hunt_Debug_Capture";
			this.simpleButton_Hunt_Debug_Capture.Size = new global::System.Drawing.Size(282, 20);
			this.simpleButton_Hunt_Debug_Capture.TabIndex = 5;
			this.simpleButton_Hunt_Debug_Capture.Text = "Capture";
			this.simpleButton_Hunt_Debug_Capture.Click += new global::System.EventHandler(this.simpleButton_Hunt_Debug_Capture_Click);
			this.simpleButton_Hunt_Debug_Token.Location = new global::System.Drawing.Point(9, 89);
			this.simpleButton_Hunt_Debug_Token.Name = "simpleButton_Hunt_Debug_Token";
			this.simpleButton_Hunt_Debug_Token.Size = new global::System.Drawing.Size(282, 20);
			this.simpleButton_Hunt_Debug_Token.TabIndex = 4;
			this.simpleButton_Hunt_Debug_Token.Text = "Get Token";
			this.simpleButton_Hunt_Debug_Token.Click += new global::System.EventHandler(this.simpleButton_Hunt_Debug_Token_Click);
			this.textEdit_Hunt_Debug_Token.Location = new global::System.Drawing.Point(51, 63);
			this.textEdit_Hunt_Debug_Token.Name = "textEdit_Hunt_Debug_Token";
			this.textEdit_Hunt_Debug_Token.Size = new global::System.Drawing.Size(240, 20);
			this.textEdit_Hunt_Debug_Token.TabIndex = 3;
			this.labelControl_Hunt_Debug_Token.Location = new global::System.Drawing.Point(9, 66);
			this.labelControl_Hunt_Debug_Token.Name = "labelControl_Hunt_Debug_Token";
			this.labelControl_Hunt_Debug_Token.Size = new global::System.Drawing.Size(36, 13);
			this.labelControl_Hunt_Debug_Token.TabIndex = 2;
			this.labelControl_Hunt_Debug_Token.Text = "Token :";
			this.separatorControl1.Location = new global::System.Drawing.Point(55, 30);
			this.separatorControl1.Name = "separatorControl1";
			this.separatorControl1.Size = new global::System.Drawing.Size(190, 23);
			this.separatorControl1.TabIndex = 1;
			this.labelControl_Hunt_Debug.Appearance.Font = new global::System.Drawing.Font("Tahoma", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.labelControl_Hunt_Debug.Appearance.Options.UseFont = true;
			this.labelControl_Hunt_Debug.Location = new global::System.Drawing.Point(111, 8);
			this.labelControl_Hunt_Debug.Name = "labelControl_Hunt_Debug";
			this.labelControl_Hunt_Debug.Size = new global::System.Drawing.Size(79, 16);
			this.labelControl_Hunt_Debug.TabIndex = 0;
			this.labelControl_Hunt_Debug.Text = "Mode DEBUG";
			this.panelControl_Hunt_ConfigHuntAuto.Controls.Add(this.xtraTabControl_Hunt_Config_HuntAuto);
			this.panelControl_Hunt_ConfigHuntAuto.Location = new global::System.Drawing.Point(187, 11);
			this.panelControl_Hunt_ConfigHuntAuto.Name = "panelControl_Hunt_ConfigHuntAuto";
			this.panelControl_Hunt_ConfigHuntAuto.Size = new global::System.Drawing.Size(300, 300);
			this.panelControl_Hunt_ConfigHuntAuto.TabIndex = 16;
			this.panelControl_Hunt_ConfigHuntAuto.Visible = false;
			this.xtraTabControl_Hunt_Config_HuntAuto.Location = new global::System.Drawing.Point(5, 5);
			this.xtraTabControl_Hunt_Config_HuntAuto.Name = "xtraTabControl_Hunt_Config_HuntAuto";
			this.xtraTabControl_Hunt_Config_HuntAuto.SelectedTabPage = this.xtraTabPage1;
			this.xtraTabControl_Hunt_Config_HuntAuto.Size = new global::System.Drawing.Size(290, 289);
			this.xtraTabControl_Hunt_Config_HuntAuto.TabIndex = 0;
			this.xtraTabControl_Hunt_Config_HuntAuto.TabPages.AddRange(new global::DevExpress.XtraTab.XtraTabPage[] { this.xtraTabPage1, this.xtraTabPage2, this.xtraTabPage3, this.xtraTabPage4 });
			this.xtraTabPage1.Controls.Add(this.textEdit_Hunt_Config_Hunt_Indice_Detection);
			this.xtraTabPage1.Controls.Add(this.textEdit_Hunt_Config_Debug);
			this.xtraTabPage1.Controls.Add(this.checkEdit_Hunt_Config_Debug);
			this.xtraTabPage1.Controls.Add(this.labelControl_Hunt_Config_Hunt_Indice_Detection);
			this.xtraTabPage1.Controls.Add(this.checkEdit_Hunt_Config_Offline);
			this.xtraTabPage1.Controls.Add(this.checkEdit_Hunt_Config_UseGoogleVision);
			this.xtraTabPage1.Name = "xtraTabPage1";
			this.xtraTabPage1.Size = new global::System.Drawing.Size(288, 264);
			this.xtraTabPage1.Text = "Général";
			this.textEdit_Hunt_Config_Hunt_Indice_Detection.Location = new global::System.Drawing.Point(123, 55);
			this.textEdit_Hunt_Config_Hunt_Indice_Detection.Name = "textEdit_Hunt_Config_Hunt_Indice_Detection";
			this.textEdit_Hunt_Config_Hunt_Indice_Detection.Size = new global::System.Drawing.Size(84, 20);
			this.textEdit_Hunt_Config_Hunt_Indice_Detection.TabIndex = 18;
			this.textEdit_Hunt_Config_Debug.Location = new global::System.Drawing.Point(94, 239);
			this.textEdit_Hunt_Config_Debug.Name = "textEdit_Hunt_Config_Debug";
			this.textEdit_Hunt_Config_Debug.Properties.PasswordChar = '●';
			this.textEdit_Hunt_Config_Debug.Size = new global::System.Drawing.Size(75, 20);
			this.textEdit_Hunt_Config_Debug.TabIndex = 3;
			this.textEdit_Hunt_Config_Debug.EditValueChanged += new global::System.EventHandler(this.textEdit_Hunt_Config_Debug_EditValueChanged);
			this.checkEdit_Hunt_Config_Debug.Enabled = false;
			this.checkEdit_Hunt_Config_Debug.Location = new global::System.Drawing.Point(3, 239);
			this.checkEdit_Hunt_Config_Debug.Name = "checkEdit_Hunt_Config_Debug";
			this.checkEdit_Hunt_Config_Debug.Properties.Caption = "Mode Debug";
			this.checkEdit_Hunt_Config_Debug.Size = new global::System.Drawing.Size(85, 19);
			this.checkEdit_Hunt_Config_Debug.TabIndex = 2;
			this.checkEdit_Hunt_Config_Debug.CheckedChanged += new global::System.EventHandler(this.checkEdit_Hunt_Config_Debug_CheckedChanged);
			this.labelControl_Hunt_Config_Hunt_Indice_Detection.Location = new global::System.Drawing.Point(3, 56);
			this.labelControl_Hunt_Config_Hunt_Indice_Detection.Name = "labelControl_Hunt_Config_Hunt_Indice_Detection";
			this.labelControl_Hunt_Config_Hunt_Indice_Detection.Size = new global::System.Drawing.Size(114, 13);
			this.labelControl_Hunt_Config_Hunt_Indice_Detection.TabIndex = 17;
			this.labelControl_Hunt_Config_Hunt_Indice_Detection.Text = "Seuil de détection (%) :";
			this.labelControl_Hunt_Config_Hunt_Indice_Detection.ToolTip = "Correspond au seuil de correction automatique des indices";
			this.checkEdit_Hunt_Config_Offline.Location = new global::System.Drawing.Point(3, 28);
			this.checkEdit_Hunt_Config_Offline.Name = "checkEdit_Hunt_Config_Offline";
			this.checkEdit_Hunt_Config_Offline.Properties.Caption = "Mode \" Hors Ligne \"";
			this.checkEdit_Hunt_Config_Offline.Size = new global::System.Drawing.Size(118, 19);
			this.checkEdit_Hunt_Config_Offline.TabIndex = 1;
			this.checkEdit_Hunt_Config_Offline.CheckedChanged += new global::System.EventHandler(this.checkEdit_Hunt_Config_Offline_CheckedChanged);
			this.checkEdit_Hunt_Config_UseGoogleVision.Location = new global::System.Drawing.Point(3, 3);
			this.checkEdit_Hunt_Config_UseGoogleVision.Name = "checkEdit_Hunt_Config_UseGoogleVision";
			this.checkEdit_Hunt_Config_UseGoogleVision.Properties.Caption = "Utiliser Google Vision API";
			this.checkEdit_Hunt_Config_UseGoogleVision.Size = new global::System.Drawing.Size(143, 19);
			this.checkEdit_Hunt_Config_UseGoogleVision.TabIndex = 0;
			this.checkEdit_Hunt_Config_UseGoogleVision.CheckedChanged += new global::System.EventHandler(this.checkEdit_Hunt_Config_UseGoogleVision_CheckedChanged);
			this.xtraTabPage2.Controls.Add(this.simpleButton_Hunt_Config_Hunt_Position_save);
			this.xtraTabPage2.Controls.Add(this.textEdit_Hunt_Config_Hunt_Position_hauteurTexte);
			this.xtraTabPage2.Controls.Add(this.labelControl_Hunt_Config_Hunt_Position_hauteurTexte);
			this.xtraTabPage2.Controls.Add(this.textEdit_Hunt_Config_Hunt_Position_largeurTexte);
			this.xtraTabPage2.Controls.Add(this.labelControl_Hunt_Config_Hunt_Position_largeurTexte);
			this.xtraTabPage2.Controls.Add(this.textEdit_Hunt_Config_Hunt_Position_threshold);
			this.xtraTabPage2.Controls.Add(this.labelControl_Hunt_Config_Hunt_Position_threshold);
			this.xtraTabPage2.Controls.Add(this.textEdit_Hunt_Config_Hunt_Position_height);
			this.xtraTabPage2.Controls.Add(this.labelControl_Hunt_Config_Hunt_Position_height);
			this.xtraTabPage2.Controls.Add(this.textEdit_Hunt_Config_Hunt_Position_width);
			this.xtraTabPage2.Controls.Add(this.labelControl_Hunt_Config_Hunt_Position_width);
			this.xtraTabPage2.Controls.Add(this.textEdit_Hunt_Config_Hunt_Position_Y);
			this.xtraTabPage2.Controls.Add(this.labelControl_Hunt_Config_Hunt_Position_Y);
			this.xtraTabPage2.Controls.Add(this.textEdit_Hunt_Config_Hunt_Position_X);
			this.xtraTabPage2.Controls.Add(this.labelControl_Hunt_Config_Hunt_Position_X);
			this.xtraTabPage2.Name = "xtraTabPage2";
			this.xtraTabPage2.Size = new global::System.Drawing.Size(288, 264);
			this.xtraTabPage2.Text = "Position";
			this.simpleButton_Hunt_Config_Hunt_Position_save.Location = new global::System.Drawing.Point(175, 212);
			this.simpleButton_Hunt_Config_Hunt_Position_save.Name = "simpleButton_Hunt_Config_Hunt_Position_save";
			this.simpleButton_Hunt_Config_Hunt_Position_save.Size = new global::System.Drawing.Size(84, 23);
			this.simpleButton_Hunt_Config_Hunt_Position_save.TabIndex = 14;
			this.simpleButton_Hunt_Config_Hunt_Position_save.Text = "Sauvegarder";
			this.simpleButton_Hunt_Config_Hunt_Position_save.Click += new global::System.EventHandler(this.simpleButton_Hunt_Config_Hunt_Position_save_Click);
			this.textEdit_Hunt_Config_Hunt_Position_hauteurTexte.Location = new global::System.Drawing.Point(175, 160);
			this.textEdit_Hunt_Config_Hunt_Position_hauteurTexte.Name = "textEdit_Hunt_Config_Hunt_Position_hauteurTexte";
			this.textEdit_Hunt_Config_Hunt_Position_hauteurTexte.Size = new global::System.Drawing.Size(84, 20);
			this.textEdit_Hunt_Config_Hunt_Position_hauteurTexte.TabIndex = 13;
			this.labelControl_Hunt_Config_Hunt_Position_hauteurTexte.Location = new global::System.Drawing.Point(19, 189);
			this.labelControl_Hunt_Config_Hunt_Position_hauteurTexte.Name = "labelControl_Hunt_Config_Hunt_Position_hauteurTexte";
			this.labelControl_Hunt_Config_Hunt_Position_hauteurTexte.Size = new global::System.Drawing.Size(117, 13);
			this.labelControl_Hunt_Config_Hunt_Position_hauteurTexte.TabIndex = 12;
			this.labelControl_Hunt_Config_Hunt_Position_hauteurTexte.Text = "Largeur mise à l'échelle :";
			this.labelControl_Hunt_Config_Hunt_Position_hauteurTexte.ToolTip = "Correspond à la largeur de redimensionnement de l'image";
			this.textEdit_Hunt_Config_Hunt_Position_largeurTexte.Location = new global::System.Drawing.Point(175, 186);
			this.textEdit_Hunt_Config_Hunt_Position_largeurTexte.Name = "textEdit_Hunt_Config_Hunt_Position_largeurTexte";
			this.textEdit_Hunt_Config_Hunt_Position_largeurTexte.Size = new global::System.Drawing.Size(84, 20);
			this.textEdit_Hunt_Config_Hunt_Position_largeurTexte.TabIndex = 11;
			this.labelControl_Hunt_Config_Hunt_Position_largeurTexte.Location = new global::System.Drawing.Point(19, 163);
			this.labelControl_Hunt_Config_Hunt_Position_largeurTexte.Name = "labelControl_Hunt_Config_Hunt_Position_largeurTexte";
			this.labelControl_Hunt_Config_Hunt_Position_largeurTexte.Size = new global::System.Drawing.Size(119, 13);
			this.labelControl_Hunt_Config_Hunt_Position_largeurTexte.TabIndex = 10;
			this.labelControl_Hunt_Config_Hunt_Position_largeurTexte.Text = "Hauteur mise à l'échelle :";
			this.labelControl_Hunt_Config_Hunt_Position_largeurTexte.ToolTip = "Correspond à la hauteur de redimensionnement de l'image";
			this.textEdit_Hunt_Config_Hunt_Position_threshold.Location = new global::System.Drawing.Point(175, 134);
			this.textEdit_Hunt_Config_Hunt_Position_threshold.Name = "textEdit_Hunt_Config_Hunt_Position_threshold";
			this.textEdit_Hunt_Config_Hunt_Position_threshold.Size = new global::System.Drawing.Size(84, 20);
			this.textEdit_Hunt_Config_Hunt_Position_threshold.TabIndex = 9;
			this.labelControl_Hunt_Config_Hunt_Position_threshold.Location = new global::System.Drawing.Point(19, 137);
			this.labelControl_Hunt_Config_Hunt_Position_threshold.Name = "labelControl_Hunt_Config_Hunt_Position_threshold";
			this.labelControl_Hunt_Config_Hunt_Position_threshold.Size = new global::System.Drawing.Size(54, 13);
			this.labelControl_Hunt_Config_Hunt_Position_threshold.TabIndex = 8;
			this.labelControl_Hunt_Config_Hunt_Position_threshold.Text = "Seuil OCR :";
			this.labelControl_Hunt_Config_Hunt_Position_threshold.ToolTip = "Correspond au seuil de reconnaissance entre l'image et le template de recherche";
			this.textEdit_Hunt_Config_Hunt_Position_height.Location = new global::System.Drawing.Point(175, 108);
			this.textEdit_Hunt_Config_Hunt_Position_height.Name = "textEdit_Hunt_Config_Hunt_Position_height";
			this.textEdit_Hunt_Config_Hunt_Position_height.Size = new global::System.Drawing.Size(84, 20);
			this.textEdit_Hunt_Config_Hunt_Position_height.TabIndex = 7;
			this.labelControl_Hunt_Config_Hunt_Position_height.Location = new global::System.Drawing.Point(19, 111);
			this.labelControl_Hunt_Config_Hunt_Position_height.Name = "labelControl_Hunt_Config_Hunt_Position_height";
			this.labelControl_Hunt_Config_Hunt_Position_height.Size = new global::System.Drawing.Size(148, 13);
			this.labelControl_Hunt_Config_Hunt_Position_height.TabIndex = 6;
			this.labelControl_Hunt_Config_Hunt_Position_height.Text = "Largeur de la capture d'écran :";
			this.labelControl_Hunt_Config_Hunt_Position_height.ToolTip = "Correspond à la largeur de la capture d'écran pour analyse\r\n\r\n";
			this.textEdit_Hunt_Config_Hunt_Position_width.Location = new global::System.Drawing.Point(175, 82);
			this.textEdit_Hunt_Config_Hunt_Position_width.Name = "textEdit_Hunt_Config_Hunt_Position_width";
			this.textEdit_Hunt_Config_Hunt_Position_width.Size = new global::System.Drawing.Size(84, 20);
			this.textEdit_Hunt_Config_Hunt_Position_width.TabIndex = 5;
			this.labelControl_Hunt_Config_Hunt_Position_width.Location = new global::System.Drawing.Point(19, 85);
			this.labelControl_Hunt_Config_Hunt_Position_width.Name = "labelControl_Hunt_Config_Hunt_Position_width";
			this.labelControl_Hunt_Config_Hunt_Position_width.Size = new global::System.Drawing.Size(150, 13);
			this.labelControl_Hunt_Config_Hunt_Position_width.TabIndex = 4;
			this.labelControl_Hunt_Config_Hunt_Position_width.Text = "Hauteur de la capture d'écran :";
			this.labelControl_Hunt_Config_Hunt_Position_width.ToolTip = "Correspond à la hauteur de la capture d'écran pour analyse\r\n";
			this.textEdit_Hunt_Config_Hunt_Position_Y.Location = new global::System.Drawing.Point(175, 56);
			this.textEdit_Hunt_Config_Hunt_Position_Y.Name = "textEdit_Hunt_Config_Hunt_Position_Y";
			this.textEdit_Hunt_Config_Hunt_Position_Y.Size = new global::System.Drawing.Size(84, 20);
			this.textEdit_Hunt_Config_Hunt_Position_Y.TabIndex = 3;
			this.labelControl_Hunt_Config_Hunt_Position_Y.Location = new global::System.Drawing.Point(19, 59);
			this.labelControl_Hunt_Config_Hunt_Position_Y.Name = "labelControl_Hunt_Config_Hunt_Position_Y";
			this.labelControl_Hunt_Config_Hunt_Position_Y.Size = new global::System.Drawing.Size(133, 13);
			this.labelControl_Hunt_Config_Hunt_Position_Y.TabIndex = 2;
			this.labelControl_Hunt_Config_Hunt_Position_Y.Text = "Point Y de capture d'écran :";
			this.labelControl_Hunt_Config_Hunt_Position_Y.ToolTip = "Correspond au point Y de l'écran ou la capture d'écran commence";
			this.textEdit_Hunt_Config_Hunt_Position_X.Location = new global::System.Drawing.Point(175, 30);
			this.textEdit_Hunt_Config_Hunt_Position_X.Name = "textEdit_Hunt_Config_Hunt_Position_X";
			this.textEdit_Hunt_Config_Hunt_Position_X.Size = new global::System.Drawing.Size(84, 20);
			this.textEdit_Hunt_Config_Hunt_Position_X.TabIndex = 1;
			this.labelControl_Hunt_Config_Hunt_Position_X.Location = new global::System.Drawing.Point(19, 33);
			this.labelControl_Hunt_Config_Hunt_Position_X.Name = "labelControl_Hunt_Config_Hunt_Position_X";
			this.labelControl_Hunt_Config_Hunt_Position_X.Size = new global::System.Drawing.Size(133, 13);
			this.labelControl_Hunt_Config_Hunt_Position_X.TabIndex = 0;
			this.labelControl_Hunt_Config_Hunt_Position_X.Text = "Point X de capture d'écran :";
			this.labelControl_Hunt_Config_Hunt_Position_X.ToolTip = "Correspond au point X de l'écran ou la capture d'écran commence";
			this.xtraTabPage3.Controls.Add(this.textEdit_Hunt_Config_Hunt_Indice_OCRCombat);
			this.xtraTabPage3.Controls.Add(this.labelControl_Hunt_Config_Hunt_Indice_OCRCombat);
			this.xtraTabPage3.Controls.Add(this.simpleButton_Hunt_Config_Hunt_Indice_Save);
			this.xtraTabPage3.Controls.Add(this.textEdit_Hunt_Config_Hunt_Indice_OCRCocheCheck);
			this.xtraTabPage3.Controls.Add(this.labelControl_Hunt_Config_Hunt_Indice_OCRCocheChecked);
			this.xtraTabPage3.Controls.Add(this.textEdit_Hunt_Config_Hunt_Indice_OCRFleche);
			this.xtraTabPage3.Controls.Add(this.labelControl_Hunt_Config_Hunt_Indice_OCRFleche);
			this.xtraTabPage3.Controls.Add(this.textEdit_Hunt_Config_Hunt_Indice_HIndice);
			this.xtraTabPage3.Controls.Add(this.labelControl_Hunt_Config_Hunt_Indice_HIndice);
			this.xtraTabPage3.Controls.Add(this.textEdit_Hunt_Config_Hunt_Indice_LIndice);
			this.xtraTabPage3.Controls.Add(this.labelControl_Hunt_Config_Hunt_Indice_LCoche);
			this.xtraTabPage3.Controls.Add(this.textEdit_Hunt_Config_Hunt_Indice_OCRCoche);
			this.xtraTabPage3.Controls.Add(this.labelControl_Hunt_Config_Hunt_Indice_OCRCoche);
			this.xtraTabPage3.Controls.Add(this.textEdit_Hunt_Config_Hunt_Indice_HStart);
			this.xtraTabPage3.Controls.Add(this.labelControl_Hunt_Config_Hunt_Indice_HStart);
			this.xtraTabPage3.Controls.Add(this.textEdit_Hunt_Config_Hunt_Indice_LStart);
			this.xtraTabPage3.Controls.Add(this.labelControl_Hunt_Config_Hunt_Indice_LStart);
			this.xtraTabPage3.Controls.Add(this.textEdit_Hunt_Config_Hunt_Indice_OCRStart);
			this.xtraTabPage3.Controls.Add(this.labelControl_Hunt_Config_Hunt_Indice_OCRStart);
			this.xtraTabPage3.Name = "xtraTabPage3";
			this.xtraTabPage3.Size = new global::System.Drawing.Size(288, 264);
			this.xtraTabPage3.Text = "Indice";
			this.textEdit_Hunt_Config_Hunt_Indice_OCRCombat.Location = new global::System.Drawing.Point(180, 214);
			this.textEdit_Hunt_Config_Hunt_Indice_OCRCombat.Name = "textEdit_Hunt_Config_Hunt_Indice_OCRCombat";
			this.textEdit_Hunt_Config_Hunt_Indice_OCRCombat.Size = new global::System.Drawing.Size(84, 20);
			this.textEdit_Hunt_Config_Hunt_Indice_OCRCombat.TabIndex = 20;
			this.labelControl_Hunt_Config_Hunt_Indice_OCRCombat.Location = new global::System.Drawing.Point(24, 217);
			this.labelControl_Hunt_Config_Hunt_Indice_OCRCombat.Name = "labelControl_Hunt_Config_Hunt_Indice_OCRCombat";
			this.labelControl_Hunt_Config_Hunt_Indice_OCRCombat.Size = new global::System.Drawing.Size(92, 13);
			this.labelControl_Hunt_Config_Hunt_Indice_OCRCombat.TabIndex = 19;
			this.labelControl_Hunt_Config_Hunt_Indice_OCRCombat.Text = "Seuil OCR combat :";
			this.labelControl_Hunt_Config_Hunt_Indice_OCRCombat.ToolTip = "Correspond au seuil OCR du bouton de combat\r\n";
			this.simpleButton_Hunt_Config_Hunt_Indice_Save.Location = new global::System.Drawing.Point(180, 238);
			this.simpleButton_Hunt_Config_Hunt_Indice_Save.Name = "simpleButton_Hunt_Config_Hunt_Indice_Save";
			this.simpleButton_Hunt_Config_Hunt_Indice_Save.Size = new global::System.Drawing.Size(84, 23);
			this.simpleButton_Hunt_Config_Hunt_Indice_Save.TabIndex = 16;
			this.simpleButton_Hunt_Config_Hunt_Indice_Save.Text = "Sauvegarder";
			this.simpleButton_Hunt_Config_Hunt_Indice_Save.Click += new global::System.EventHandler(this.simpleButton_Hunt_Config_Hunt_Indice_Save_Click);
			this.textEdit_Hunt_Config_Hunt_Indice_OCRCocheCheck.Location = new global::System.Drawing.Point(180, 188);
			this.textEdit_Hunt_Config_Hunt_Indice_OCRCocheCheck.Name = "textEdit_Hunt_Config_Hunt_Indice_OCRCocheCheck";
			this.textEdit_Hunt_Config_Hunt_Indice_OCRCocheCheck.Size = new global::System.Drawing.Size(84, 20);
			this.textEdit_Hunt_Config_Hunt_Indice_OCRCocheCheck.TabIndex = 18;
			this.labelControl_Hunt_Config_Hunt_Indice_OCRCocheChecked.Location = new global::System.Drawing.Point(24, 191);
			this.labelControl_Hunt_Config_Hunt_Indice_OCRCocheChecked.Name = "labelControl_Hunt_Config_Hunt_Indice_OCRCocheChecked";
			this.labelControl_Hunt_Config_Hunt_Indice_OCRCocheChecked.Size = new global::System.Drawing.Size(122, 13);
			this.labelControl_Hunt_Config_Hunt_Indice_OCRCocheChecked.TabIndex = 17;
			this.labelControl_Hunt_Config_Hunt_Indice_OCRCocheChecked.Text = "Seuil OCR coche validée :";
			this.labelControl_Hunt_Config_Hunt_Indice_OCRCocheChecked.ToolTip = "Correspond au seuil OCR de la coche des indices validés";
			this.textEdit_Hunt_Config_Hunt_Indice_OCRFleche.Location = new global::System.Drawing.Point(180, 162);
			this.textEdit_Hunt_Config_Hunt_Indice_OCRFleche.Name = "textEdit_Hunt_Config_Hunt_Indice_OCRFleche";
			this.textEdit_Hunt_Config_Hunt_Indice_OCRFleche.Size = new global::System.Drawing.Size(84, 20);
			this.textEdit_Hunt_Config_Hunt_Indice_OCRFleche.TabIndex = 15;
			this.labelControl_Hunt_Config_Hunt_Indice_OCRFleche.Location = new global::System.Drawing.Point(24, 165);
			this.labelControl_Hunt_Config_Hunt_Indice_OCRFleche.Name = "labelControl_Hunt_Config_Hunt_Indice_OCRFleche";
			this.labelControl_Hunt_Config_Hunt_Indice_OCRFleche.Size = new global::System.Drawing.Size(112, 13);
			this.labelControl_Hunt_Config_Hunt_Indice_OCRFleche.TabIndex = 14;
			this.labelControl_Hunt_Config_Hunt_Indice_OCRFleche.Text = "Seuil OCR de la flèche :";
			this.labelControl_Hunt_Config_Hunt_Indice_OCRFleche.ToolTip = "Correspond au seuil OCR de la flèche pour détecter la direction\r\n";
			this.textEdit_Hunt_Config_Hunt_Indice_HIndice.Location = new global::System.Drawing.Point(180, 136);
			this.textEdit_Hunt_Config_Hunt_Indice_HIndice.Name = "textEdit_Hunt_Config_Hunt_Indice_HIndice";
			this.textEdit_Hunt_Config_Hunt_Indice_HIndice.Size = new global::System.Drawing.Size(84, 20);
			this.textEdit_Hunt_Config_Hunt_Indice_HIndice.TabIndex = 13;
			this.labelControl_Hunt_Config_Hunt_Indice_HIndice.Location = new global::System.Drawing.Point(24, 139);
			this.labelControl_Hunt_Config_Hunt_Indice_HIndice.Name = "labelControl_Hunt_Config_Hunt_Indice_HIndice";
			this.labelControl_Hunt_Config_Hunt_Indice_HIndice.Size = new global::System.Drawing.Size(146, 13);
			this.labelControl_Hunt_Config_Hunt_Indice_HIndice.TabIndex = 12;
			this.labelControl_Hunt_Config_Hunt_Indice_HIndice.Text = "Hauteur de la taille de l'indice :";
			this.labelControl_Hunt_Config_Hunt_Indice_HIndice.ToolTip = "Correspond à la hauteur de la capture d'écran de l'indice en cours\r\n";
			this.textEdit_Hunt_Config_Hunt_Indice_LIndice.Location = new global::System.Drawing.Point(180, 110);
			this.textEdit_Hunt_Config_Hunt_Indice_LIndice.Name = "textEdit_Hunt_Config_Hunt_Indice_LIndice";
			this.textEdit_Hunt_Config_Hunt_Indice_LIndice.Size = new global::System.Drawing.Size(84, 20);
			this.textEdit_Hunt_Config_Hunt_Indice_LIndice.TabIndex = 11;
			this.labelControl_Hunt_Config_Hunt_Indice_LCoche.Location = new global::System.Drawing.Point(24, 113);
			this.labelControl_Hunt_Config_Hunt_Indice_LCoche.Name = "labelControl_Hunt_Config_Hunt_Indice_LCoche";
			this.labelControl_Hunt_Config_Hunt_Indice_LCoche.Size = new global::System.Drawing.Size(133, 13);
			this.labelControl_Hunt_Config_Hunt_Indice_LCoche.TabIndex = 10;
			this.labelControl_Hunt_Config_Hunt_Indice_LCoche.Text = "Largeur de taille de l'indice :";
			this.labelControl_Hunt_Config_Hunt_Indice_LCoche.ToolTip = "Correspond à la largeur de la capture d'écran de l'indice en cours";
			this.textEdit_Hunt_Config_Hunt_Indice_OCRCoche.Location = new global::System.Drawing.Point(180, 84);
			this.textEdit_Hunt_Config_Hunt_Indice_OCRCoche.Name = "textEdit_Hunt_Config_Hunt_Indice_OCRCoche";
			this.textEdit_Hunt_Config_Hunt_Indice_OCRCoche.Size = new global::System.Drawing.Size(84, 20);
			this.textEdit_Hunt_Config_Hunt_Indice_OCRCoche.TabIndex = 9;
			this.labelControl_Hunt_Config_Hunt_Indice_OCRCoche.Location = new global::System.Drawing.Point(24, 87);
			this.labelControl_Hunt_Config_Hunt_Indice_OCRCoche.Name = "labelControl_Hunt_Config_Hunt_Indice_OCRCoche";
			this.labelControl_Hunt_Config_Hunt_Indice_OCRCoche.Size = new global::System.Drawing.Size(111, 13);
			this.labelControl_Hunt_Config_Hunt_Indice_OCRCoche.TabIndex = 8;
			this.labelControl_Hunt_Config_Hunt_Indice_OCRCoche.Text = "Seuil OCR de la coche :";
			this.labelControl_Hunt_Config_Hunt_Indice_OCRCoche.ToolTip = "Correspond au seuil OCR de la coche pour détecter l'indice en cours";
			this.textEdit_Hunt_Config_Hunt_Indice_HStart.Location = new global::System.Drawing.Point(180, 58);
			this.textEdit_Hunt_Config_Hunt_Indice_HStart.Name = "textEdit_Hunt_Config_Hunt_Indice_HStart";
			this.textEdit_Hunt_Config_Hunt_Indice_HStart.Size = new global::System.Drawing.Size(84, 20);
			this.textEdit_Hunt_Config_Hunt_Indice_HStart.TabIndex = 7;
			this.labelControl_Hunt_Config_Hunt_Indice_HStart.Location = new global::System.Drawing.Point(24, 61);
			this.labelControl_Hunt_Config_Hunt_Indice_HStart.Name = "labelControl_Hunt_Config_Hunt_Indice_HStart";
			this.labelControl_Hunt_Config_Hunt_Indice_HStart.Size = new global::System.Drawing.Size(136, 13);
			this.labelControl_Hunt_Config_Hunt_Indice_HStart.TabIndex = 6;
			this.labelControl_Hunt_Config_Hunt_Indice_HStart.Text = "Hauteur de taille du départ :";
			this.labelControl_Hunt_Config_Hunt_Indice_HStart.ToolTip = "Correspond à la hauteur de la capture d'écran de la zone de départ";
			this.textEdit_Hunt_Config_Hunt_Indice_LStart.Location = new global::System.Drawing.Point(180, 32);
			this.textEdit_Hunt_Config_Hunt_Indice_LStart.Name = "textEdit_Hunt_Config_Hunt_Indice_LStart";
			this.textEdit_Hunt_Config_Hunt_Indice_LStart.Size = new global::System.Drawing.Size(84, 20);
			this.textEdit_Hunt_Config_Hunt_Indice_LStart.TabIndex = 5;
			this.labelControl_Hunt_Config_Hunt_Indice_LStart.Location = new global::System.Drawing.Point(24, 35);
			this.labelControl_Hunt_Config_Hunt_Indice_LStart.Name = "labelControl_Hunt_Config_Hunt_Indice_LStart";
			this.labelControl_Hunt_Config_Hunt_Indice_LStart.Size = new global::System.Drawing.Size(134, 13);
			this.labelControl_Hunt_Config_Hunt_Indice_LStart.TabIndex = 4;
			this.labelControl_Hunt_Config_Hunt_Indice_LStart.Text = "Largeur de taille du départ :";
			this.labelControl_Hunt_Config_Hunt_Indice_LStart.ToolTip = "Correspond à la largeur de la capture d'écran de la zone de départ";
			this.textEdit_Hunt_Config_Hunt_Indice_OCRStart.Location = new global::System.Drawing.Point(180, 6);
			this.textEdit_Hunt_Config_Hunt_Indice_OCRStart.Name = "textEdit_Hunt_Config_Hunt_Indice_OCRStart";
			this.textEdit_Hunt_Config_Hunt_Indice_OCRStart.Size = new global::System.Drawing.Size(84, 20);
			this.textEdit_Hunt_Config_Hunt_Indice_OCRStart.TabIndex = 3;
			this.labelControl_Hunt_Config_Hunt_Indice_OCRStart.Location = new global::System.Drawing.Point(24, 9);
			this.labelControl_Hunt_Config_Hunt_Indice_OCRStart.Name = "labelControl_Hunt_Config_Hunt_Indice_OCRStart";
			this.labelControl_Hunt_Config_Hunt_Indice_OCRStart.Size = new global::System.Drawing.Size(104, 13);
			this.labelControl_Hunt_Config_Hunt_Indice_OCRStart.TabIndex = 2;
			this.labelControl_Hunt_Config_Hunt_Indice_OCRStart.Text = "Seuil OCR du départ :";
			this.labelControl_Hunt_Config_Hunt_Indice_OCRStart.ToolTip = "Correspond au seuil OCR de la zone de départ";
			this.xtraTabPage4.Controls.Add(this.groupControl5);
			this.xtraTabPage4.Controls.Add(this.groupControl4);
			this.xtraTabPage4.Controls.Add(this.groupControl3);
			this.xtraTabPage4.Controls.Add(this.groupControl2);
			this.xtraTabPage4.Controls.Add(this.groupControl1);
			this.xtraTabPage4.Name = "xtraTabPage4";
			this.xtraTabPage4.Size = new global::System.Drawing.Size(288, 264);
			this.xtraTabPage4.Text = "Template d'image";
			this.groupControl5.Controls.Add(this.pictureBox_Hunt_Config_Hunt_Template_Combat);
			this.groupControl5.Location = new global::System.Drawing.Point(131, 145);
			this.groupControl5.Name = "groupControl5";
			this.groupControl5.Size = new global::System.Drawing.Size(154, 65);
			this.groupControl5.TabIndex = 20;
			this.groupControl5.Text = "Combat";
			this.pictureBox_Hunt_Config_Hunt_Template_Combat.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pictureBox_Hunt_Config_Hunt_Template_Combat.Location = new global::System.Drawing.Point(42, 25);
			this.pictureBox_Hunt_Config_Hunt_Template_Combat.Name = "pictureBox_Hunt_Config_Hunt_Template_Combat";
			this.pictureBox_Hunt_Config_Hunt_Template_Combat.Size = new global::System.Drawing.Size(70, 30);
			this.pictureBox_Hunt_Config_Hunt_Template_Combat.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox_Hunt_Config_Hunt_Template_Combat.TabIndex = 11;
			this.pictureBox_Hunt_Config_Hunt_Template_Combat.TabStop = false;
			this.pictureBox_Hunt_Config_Hunt_Template_Combat.Click += new global::System.EventHandler(this.pictureBox_Hunt_Config_Hunt_Template_Combat_Click);
			this.groupControl4.Controls.Add(this.pictureBox_Hunt_Config_Hunt_Template_Level);
			this.groupControl4.Location = new global::System.Drawing.Point(131, 74);
			this.groupControl4.Name = "groupControl4";
			this.groupControl4.Size = new global::System.Drawing.Size(154, 65);
			this.groupControl4.TabIndex = 19;
			this.groupControl4.Text = "Niveau";
			this.pictureBox_Hunt_Config_Hunt_Template_Level.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pictureBox_Hunt_Config_Hunt_Template_Level.Location = new global::System.Drawing.Point(42, 25);
			this.pictureBox_Hunt_Config_Hunt_Template_Level.Name = "pictureBox_Hunt_Config_Hunt_Template_Level";
			this.pictureBox_Hunt_Config_Hunt_Template_Level.Size = new global::System.Drawing.Size(70, 30);
			this.pictureBox_Hunt_Config_Hunt_Template_Level.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox_Hunt_Config_Hunt_Template_Level.TabIndex = 11;
			this.pictureBox_Hunt_Config_Hunt_Template_Level.TabStop = false;
			this.pictureBox_Hunt_Config_Hunt_Template_Level.Click += new global::System.EventHandler(this.pictureBox_Hunt_Config_Hunt_Template_Level_Click);
			this.groupControl3.Controls.Add(this.pictureBox_Hunt_Config_Hunt_Template_Start);
			this.groupControl3.Location = new global::System.Drawing.Point(131, 3);
			this.groupControl3.Name = "groupControl3";
			this.groupControl3.Size = new global::System.Drawing.Size(154, 65);
			this.groupControl3.TabIndex = 18;
			this.groupControl3.Text = "Départ";
			this.pictureBox_Hunt_Config_Hunt_Template_Start.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pictureBox_Hunt_Config_Hunt_Template_Start.Location = new global::System.Drawing.Point(42, 25);
			this.pictureBox_Hunt_Config_Hunt_Template_Start.Name = "pictureBox_Hunt_Config_Hunt_Template_Start";
			this.pictureBox_Hunt_Config_Hunt_Template_Start.Size = new global::System.Drawing.Size(70, 30);
			this.pictureBox_Hunt_Config_Hunt_Template_Start.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox_Hunt_Config_Hunt_Template_Start.TabIndex = 4;
			this.pictureBox_Hunt_Config_Hunt_Template_Start.TabStop = false;
			this.pictureBox_Hunt_Config_Hunt_Template_Start.Click += new global::System.EventHandler(this.pictureBox_Hunt_Config_Hunt_Template_Start_Click);
			this.groupControl2.Controls.Add(this.pictureBox_Hunt_Config_Hunt_Template_Arrow_6);
			this.groupControl2.Controls.Add(this.pictureBox_Hunt_Config_Hunt_Template_Arrow_4);
			this.groupControl2.Controls.Add(this.pictureBox_Hunt_Config_Hunt_Template_Arrow_2);
			this.groupControl2.Controls.Add(this.pictureBox_Hunt_Config_Hunt_Template_Arrow_0);
			this.groupControl2.Location = new global::System.Drawing.Point(3, 74);
			this.groupControl2.Name = "groupControl2";
			this.groupControl2.Size = new global::System.Drawing.Size(122, 137);
			this.groupControl2.TabIndex = 18;
			this.groupControl2.Text = "Flèches";
			this.groupControl2.Paint += new global::System.Windows.Forms.PaintEventHandler(this.groupControl2_Paint);
			this.pictureBox_Hunt_Config_Hunt_Template_Arrow_6.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pictureBox_Hunt_Config_Hunt_Template_Arrow_6.Location = new global::System.Drawing.Point(46, 25);
			this.pictureBox_Hunt_Config_Hunt_Template_Arrow_6.Name = "pictureBox_Hunt_Config_Hunt_Template_Arrow_6";
			this.pictureBox_Hunt_Config_Hunt_Template_Arrow_6.Size = new global::System.Drawing.Size(30, 30);
			this.pictureBox_Hunt_Config_Hunt_Template_Arrow_6.TabIndex = 6;
			this.pictureBox_Hunt_Config_Hunt_Template_Arrow_6.TabStop = false;
			this.pictureBox_Hunt_Config_Hunt_Template_Arrow_6.Click += new global::System.EventHandler(this.pictureBox_Hunt_Config_Hunt_Template_Arrow_6_Click);
			this.pictureBox_Hunt_Config_Hunt_Template_Arrow_4.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pictureBox_Hunt_Config_Hunt_Template_Arrow_4.Location = new global::System.Drawing.Point(10, 61);
			this.pictureBox_Hunt_Config_Hunt_Template_Arrow_4.Name = "pictureBox_Hunt_Config_Hunt_Template_Arrow_4";
			this.pictureBox_Hunt_Config_Hunt_Template_Arrow_4.Size = new global::System.Drawing.Size(30, 30);
			this.pictureBox_Hunt_Config_Hunt_Template_Arrow_4.TabIndex = 9;
			this.pictureBox_Hunt_Config_Hunt_Template_Arrow_4.TabStop = false;
			this.pictureBox_Hunt_Config_Hunt_Template_Arrow_4.Click += new global::System.EventHandler(this.pictureBox_Hunt_Config_Hunt_Template_Arrow_4_Click);
			this.pictureBox_Hunt_Config_Hunt_Template_Arrow_2.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pictureBox_Hunt_Config_Hunt_Template_Arrow_2.Location = new global::System.Drawing.Point(46, 97);
			this.pictureBox_Hunt_Config_Hunt_Template_Arrow_2.Name = "pictureBox_Hunt_Config_Hunt_Template_Arrow_2";
			this.pictureBox_Hunt_Config_Hunt_Template_Arrow_2.Size = new global::System.Drawing.Size(30, 30);
			this.pictureBox_Hunt_Config_Hunt_Template_Arrow_2.TabIndex = 8;
			this.pictureBox_Hunt_Config_Hunt_Template_Arrow_2.TabStop = false;
			this.pictureBox_Hunt_Config_Hunt_Template_Arrow_2.Click += new global::System.EventHandler(this.pictureBox_Hunt_Config_Hunt_Template_Arrow_2_Click);
			this.pictureBox_Hunt_Config_Hunt_Template_Arrow_0.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pictureBox_Hunt_Config_Hunt_Template_Arrow_0.Location = new global::System.Drawing.Point(82, 61);
			this.pictureBox_Hunt_Config_Hunt_Template_Arrow_0.Name = "pictureBox_Hunt_Config_Hunt_Template_Arrow_0";
			this.pictureBox_Hunt_Config_Hunt_Template_Arrow_0.Size = new global::System.Drawing.Size(30, 30);
			this.pictureBox_Hunt_Config_Hunt_Template_Arrow_0.TabIndex = 7;
			this.pictureBox_Hunt_Config_Hunt_Template_Arrow_0.TabStop = false;
			this.pictureBox_Hunt_Config_Hunt_Template_Arrow_0.Click += new global::System.EventHandler(this.pictureBox_Hunt_Config_Hunt_Template_Arrow_0_Click);
			this.groupControl1.Controls.Add(this.pictureBox_Hunt_Config_Hunt_Template_CocheChecked);
			this.groupControl1.Controls.Add(this.pictureBox_Hunt_Config_Hunt_Template_Coche);
			this.groupControl1.Location = new global::System.Drawing.Point(3, 3);
			this.groupControl1.Name = "groupControl1";
			this.groupControl1.Size = new global::System.Drawing.Size(122, 65);
			this.groupControl1.TabIndex = 17;
			this.groupControl1.Text = "Coches";
			this.pictureBox_Hunt_Config_Hunt_Template_CocheChecked.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pictureBox_Hunt_Config_Hunt_Template_CocheChecked.Location = new global::System.Drawing.Point(64, 25);
			this.pictureBox_Hunt_Config_Hunt_Template_CocheChecked.Name = "pictureBox_Hunt_Config_Hunt_Template_CocheChecked";
			this.pictureBox_Hunt_Config_Hunt_Template_CocheChecked.Size = new global::System.Drawing.Size(30, 30);
			this.pictureBox_Hunt_Config_Hunt_Template_CocheChecked.TabIndex = 3;
			this.pictureBox_Hunt_Config_Hunt_Template_CocheChecked.TabStop = false;
			this.pictureBox_Hunt_Config_Hunt_Template_CocheChecked.Click += new global::System.EventHandler(this.pictureBox_Hunt_Config_Hunt_Template_CocheChecked_Click);
			this.pictureBox_Hunt_Config_Hunt_Template_Coche.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pictureBox_Hunt_Config_Hunt_Template_Coche.Location = new global::System.Drawing.Point(28, 25);
			this.pictureBox_Hunt_Config_Hunt_Template_Coche.Name = "pictureBox_Hunt_Config_Hunt_Template_Coche";
			this.pictureBox_Hunt_Config_Hunt_Template_Coche.Size = new global::System.Drawing.Size(30, 30);
			this.pictureBox_Hunt_Config_Hunt_Template_Coche.TabIndex = 2;
			this.pictureBox_Hunt_Config_Hunt_Template_Coche.TabStop = false;
			this.pictureBox_Hunt_Config_Hunt_Template_Coche.Click += new global::System.EventHandler(this.pictureBox_Hunt_Config_Hunt_Template_Coche_Click);
			this.panelControl_Hunt_Hunt.Controls.Add(this.labelControl_Hunt_Map);
			this.panelControl_Hunt_Hunt.Controls.Add(this.checkEdit_Hunt_AutoTravel);
			this.panelControl_Hunt_Hunt.Controls.Add(this.comboBoxEdit_Hunt_Indice);
			this.panelControl_Hunt_Hunt.Controls.Add(this.separatorControl4);
			this.panelControl_Hunt_Hunt.Controls.Add(this.labelControl_Hunt_Indice);
			this.panelControl_Hunt_Hunt.Controls.Add(this.simpleButton_Hunt_2);
			this.panelControl_Hunt_Hunt.Controls.Add(this.simpleButton_Hunt_4);
			this.panelControl_Hunt_Hunt.Controls.Add(this.simpleButton_Hunt_0);
			this.panelControl_Hunt_Hunt.Controls.Add(this.simpleButton_Hunt_6);
			this.panelControl_Hunt_Hunt.Controls.Add(this.separatorControl3);
			this.panelControl_Hunt_Hunt.Controls.Add(this.labelControl_Hunt_Dir);
			this.panelControl_Hunt_Hunt.Controls.Add(this.textEdit_Hunt_Y);
			this.panelControl_Hunt_Hunt.Controls.Add(this.labelControl_Hunt_Y);
			this.panelControl_Hunt_Hunt.Controls.Add(this.textEdit_Hunt_X);
			this.panelControl_Hunt_Hunt.Controls.Add(this.labelControl_Hunt_X);
			this.panelControl_Hunt_Hunt.Controls.Add(this.separatorControl2);
			this.panelControl_Hunt_Hunt.Controls.Add(this.labelControl_Hunt_Pos);
			this.panelControl_Hunt_Hunt.Location = new global::System.Drawing.Point(187, 11);
			this.panelControl_Hunt_Hunt.Name = "panelControl_Hunt_Hunt";
			this.panelControl_Hunt_Hunt.Size = new global::System.Drawing.Size(300, 300);
			this.panelControl_Hunt_Hunt.TabIndex = 10;
			this.panelControl_Hunt_Hunt.Visible = false;
			this.labelControl_Hunt_Map.Appearance.Font = new global::System.Drawing.Font("Tahoma", 9.75f, global::System.Drawing.FontStyle.Bold);
			this.labelControl_Hunt_Map.Appearance.Options.UseFont = true;
			this.labelControl_Hunt_Map.Location = new global::System.Drawing.Point(131, 251);
			this.labelControl_Hunt_Map.Name = "labelControl_Hunt_Map";
			this.labelControl_Hunt_Map.Size = new global::System.Drawing.Size(38, 16);
			this.labelControl_Hunt_Map.TabIndex = 17;
			this.labelControl_Hunt_Map.Text = "[X, Y]";
			this.checkEdit_Hunt_AutoTravel.EditValue = true;
			this.checkEdit_Hunt_AutoTravel.Location = new global::System.Drawing.Point(5, 273);
			this.checkEdit_Hunt_AutoTravel.Name = "checkEdit_Hunt_AutoTravel";
			this.checkEdit_Hunt_AutoTravel.Properties.Caption = "Copier la commande d'autopilote ";
			this.checkEdit_Hunt_AutoTravel.Size = new global::System.Drawing.Size(189, 19);
			this.checkEdit_Hunt_AutoTravel.TabIndex = 16;
			this.comboBoxEdit_Hunt_Indice.Location = new global::System.Drawing.Point(70, 224);
			this.comboBoxEdit_Hunt_Indice.Name = "comboBoxEdit_Hunt_Indice";
			this.comboBoxEdit_Hunt_Indice.Properties.Buttons.AddRange(new global::DevExpress.XtraEditors.Controls.EditorButton[]
			{
				new global::DevExpress.XtraEditors.Controls.EditorButton(global::DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
			});
			this.comboBoxEdit_Hunt_Indice.Size = new global::System.Drawing.Size(163, 20);
			this.comboBoxEdit_Hunt_Indice.TabIndex = 15;
			this.comboBoxEdit_Hunt_Indice.SelectedIndexChanged += new global::System.EventHandler(this.comboBoxEdit_Hunt_Indice_SelectedIndexChanged);
			this.separatorControl4.Location = new global::System.Drawing.Point(46, 200);
			this.separatorControl4.Name = "separatorControl4";
			this.separatorControl4.Size = new global::System.Drawing.Size(209, 18);
			this.separatorControl4.TabIndex = 14;
			this.labelControl_Hunt_Indice.Appearance.Font = new global::System.Drawing.Font("Tahoma", 9.75f, global::System.Drawing.FontStyle.Bold);
			this.labelControl_Hunt_Indice.Appearance.Options.UseFont = true;
			this.labelControl_Hunt_Indice.Location = new global::System.Drawing.Point(131, 178);
			this.labelControl_Hunt_Indice.Name = "labelControl_Hunt_Indice";
			this.labelControl_Hunt_Indice.Size = new global::System.Drawing.Size(39, 16);
			this.labelControl_Hunt_Indice.TabIndex = 13;
			this.labelControl_Hunt_Indice.Text = "Indice";
			this.simpleButton_Hunt_2.Location = new global::System.Drawing.Point(138, 147);
			this.simpleButton_Hunt_2.Name = "simpleButton_Hunt_2";
			this.simpleButton_Hunt_2.Size = new global::System.Drawing.Size(25, 25);
			this.simpleButton_Hunt_2.TabIndex = 12;
			this.simpleButton_Hunt_2.Text = "↓";
			this.simpleButton_Hunt_2.Click += new global::System.EventHandler(this.simpleButton_Hunt_2_Click);
			this.simpleButton_Hunt_4.Location = new global::System.Drawing.Point(107, 130);
			this.simpleButton_Hunt_4.Name = "simpleButton_Hunt_4";
			this.simpleButton_Hunt_4.Size = new global::System.Drawing.Size(25, 25);
			this.simpleButton_Hunt_4.TabIndex = 11;
			this.simpleButton_Hunt_4.Text = "←";
			this.simpleButton_Hunt_4.Click += new global::System.EventHandler(this.simpleButton_Hunt_4_Click);
			this.simpleButton_Hunt_0.Location = new global::System.Drawing.Point(169, 130);
			this.simpleButton_Hunt_0.Name = "simpleButton_Hunt_0";
			this.simpleButton_Hunt_0.Size = new global::System.Drawing.Size(25, 25);
			this.simpleButton_Hunt_0.TabIndex = 10;
			this.simpleButton_Hunt_0.Text = "→";
			this.simpleButton_Hunt_0.Click += new global::System.EventHandler(this.simpleButton_Hunt_0_Click);
			this.simpleButton_Hunt_6.Location = new global::System.Drawing.Point(138, 116);
			this.simpleButton_Hunt_6.Name = "simpleButton_Hunt_6";
			this.simpleButton_Hunt_6.Size = new global::System.Drawing.Size(25, 25);
			this.simpleButton_Hunt_6.TabIndex = 8;
			this.simpleButton_Hunt_6.Text = "↑";
			this.simpleButton_Hunt_6.Click += new global::System.EventHandler(this.simpleButton_Hunt_6_Click);
			this.separatorControl3.Location = new global::System.Drawing.Point(46, 92);
			this.separatorControl3.Name = "separatorControl3";
			this.separatorControl3.Size = new global::System.Drawing.Size(209, 18);
			this.separatorControl3.TabIndex = 7;
			this.labelControl_Hunt_Dir.Appearance.Font = new global::System.Drawing.Font("Tahoma", 9.75f, global::System.Drawing.FontStyle.Bold);
			this.labelControl_Hunt_Dir.Appearance.Options.UseFont = true;
			this.labelControl_Hunt_Dir.Location = new global::System.Drawing.Point(121, 75);
			this.labelControl_Hunt_Dir.Name = "labelControl_Hunt_Dir";
			this.labelControl_Hunt_Dir.Size = new global::System.Drawing.Size(58, 16);
			this.labelControl_Hunt_Dir.TabIndex = 6;
			this.labelControl_Hunt_Dir.Text = "Direction";
			this.textEdit_Hunt_Y.Location = new global::System.Drawing.Point(172, 49);
			this.textEdit_Hunt_Y.Name = "textEdit_Hunt_Y";
			this.textEdit_Hunt_Y.Size = new global::System.Drawing.Size(61, 20);
			this.textEdit_Hunt_Y.TabIndex = 5;
			this.labelControl_Hunt_Y.Location = new global::System.Drawing.Point(153, 54);
			this.labelControl_Hunt_Y.Name = "labelControl_Hunt_Y";
			this.labelControl_Hunt_Y.Size = new global::System.Drawing.Size(13, 13);
			this.labelControl_Hunt_Y.TabIndex = 4;
			this.labelControl_Hunt_Y.Text = "Y :";
			this.textEdit_Hunt_X.Location = new global::System.Drawing.Point(86, 49);
			this.textEdit_Hunt_X.Name = "textEdit_Hunt_X";
			this.textEdit_Hunt_X.Size = new global::System.Drawing.Size(61, 20);
			this.textEdit_Hunt_X.TabIndex = 3;
			this.labelControl_Hunt_X.Location = new global::System.Drawing.Point(67, 54);
			this.labelControl_Hunt_X.Name = "labelControl_Hunt_X";
			this.labelControl_Hunt_X.Size = new global::System.Drawing.Size(13, 13);
			this.labelControl_Hunt_X.TabIndex = 2;
			this.labelControl_Hunt_X.Text = "X :";
			this.separatorControl2.Location = new global::System.Drawing.Point(46, 25);
			this.separatorControl2.Name = "separatorControl2";
			this.separatorControl2.Size = new global::System.Drawing.Size(209, 18);
			this.separatorControl2.TabIndex = 1;
			this.labelControl_Hunt_Pos.Appearance.Font = new global::System.Drawing.Font("Tahoma", 9.75f, global::System.Drawing.FontStyle.Bold);
			this.labelControl_Hunt_Pos.Appearance.Options.UseFont = true;
			this.labelControl_Hunt_Pos.Location = new global::System.Drawing.Point(125, 8);
			this.labelControl_Hunt_Pos.Name = "labelControl_Hunt_Pos";
			this.labelControl_Hunt_Pos.Size = new global::System.Drawing.Size(51, 16);
			this.labelControl_Hunt_Pos.TabIndex = 0;
			this.labelControl_Hunt_Pos.Text = "Position";
			this.toastNotificationsManager.ApplicationId = "61b7e00e-4fdb-4329-8ce0-f06beaed2abe";
			this.panelControl_Hunt_HuntAuto.Controls.Add(this.checkEdit_Hunt_Auto_ModeReduit);
			this.panelControl_Hunt_HuntAuto.Controls.Add(this.labelControl_HuntAuto_MapIndice);
			this.panelControl_Hunt_HuntAuto.Controls.Add(this.labelControl_HuntAuto_MapStart);
			this.panelControl_Hunt_HuntAuto.Controls.Add(this.checkEdit_HuntAuto_AutoTravel);
			this.panelControl_Hunt_HuntAuto.Controls.Add(this.labelControl_HuntAuto_Direction);
			this.panelControl_Hunt_HuntAuto.Controls.Add(this.simpleButton_HuntAutoStop);
			this.panelControl_Hunt_HuntAuto.Controls.Add(this.simpleButton_HuntAutoStart);
			this.panelControl_Hunt_HuntAuto.Controls.Add(this.labelControl_HuntAuto_IndiceCor);
			this.panelControl_Hunt_HuntAuto.Controls.Add(this.labelControl_HuntAuto_Indice);
			this.panelControl_Hunt_HuntAuto.Location = new global::System.Drawing.Point(187, 11);
			this.panelControl_Hunt_HuntAuto.Name = "panelControl_Hunt_HuntAuto";
			this.panelControl_Hunt_HuntAuto.Size = new global::System.Drawing.Size(300, 300);
			this.panelControl_Hunt_HuntAuto.TabIndex = 18;
			this.panelControl_Hunt_HuntAuto.Visible = false;
			this.checkEdit_Hunt_Auto_ModeReduit.Location = new global::System.Drawing.Point(5, 251);
			this.checkEdit_Hunt_Auto_ModeReduit.Name = "checkEdit_Hunt_Auto_ModeReduit";
			this.checkEdit_Hunt_Auto_ModeReduit.Properties.Caption = "Mode réduit";
			this.checkEdit_Hunt_Auto_ModeReduit.Size = new global::System.Drawing.Size(80, 19);
			this.checkEdit_Hunt_Auto_ModeReduit.TabIndex = 23;
			this.checkEdit_Hunt_Auto_ModeReduit.CheckedChanged += new global::System.EventHandler(this.checkEdit_Hunt_Auto_ModeReduit_CheckedChanged);
			this.labelControl_HuntAuto_MapIndice.Location = new global::System.Drawing.Point(46, 224);
			this.labelControl_HuntAuto_MapIndice.Name = "labelControl_HuntAuto_MapIndice";
			this.labelControl_HuntAuto_MapIndice.Size = new global::System.Drawing.Size(76, 13);
			this.labelControl_HuntAuto_MapIndice.TabIndex = 22;
			this.labelControl_HuntAuto_MapIndice.Text = "Map de l'indice :";
			this.labelControl_HuntAuto_MapStart.Location = new global::System.Drawing.Point(46, 72);
			this.labelControl_HuntAuto_MapStart.Name = "labelControl_HuntAuto_MapStart";
			this.labelControl_HuntAuto_MapStart.Size = new global::System.Drawing.Size(77, 13);
			this.labelControl_HuntAuto_MapStart.TabIndex = 18;
			this.labelControl_HuntAuto_MapStart.Text = "Map de départ :";
			this.checkEdit_HuntAuto_AutoTravel.EditValue = true;
			this.checkEdit_HuntAuto_AutoTravel.Location = new global::System.Drawing.Point(5, 276);
			this.checkEdit_HuntAuto_AutoTravel.Name = "checkEdit_HuntAuto_AutoTravel";
			this.checkEdit_HuntAuto_AutoTravel.Properties.Caption = "Copier la commande d'autopilote ";
			this.checkEdit_HuntAuto_AutoTravel.Size = new global::System.Drawing.Size(181, 19);
			this.checkEdit_HuntAuto_AutoTravel.TabIndex = 17;
			this.labelControl_HuntAuto_Direction.Location = new global::System.Drawing.Point(46, 186);
			this.labelControl_HuntAuto_Direction.Name = "labelControl_HuntAuto_Direction";
			this.labelControl_HuntAuto_Direction.Size = new global::System.Drawing.Size(49, 13);
			this.labelControl_HuntAuto_Direction.TabIndex = 21;
			this.labelControl_HuntAuto_Direction.Text = "Direction :";
			this.simpleButton_HuntAutoStop.Enabled = false;
			this.simpleButton_HuntAutoStop.Location = new global::System.Drawing.Point(153, 24);
			this.simpleButton_HuntAutoStop.Name = "simpleButton_HuntAutoStop";
			this.simpleButton_HuntAutoStop.Size = new global::System.Drawing.Size(101, 23);
			this.simpleButton_HuntAutoStop.TabIndex = 1;
			this.simpleButton_HuntAutoStop.Text = "Arrêt";
			this.simpleButton_HuntAutoStop.Click += new global::System.EventHandler(this.simpleButton_HuntAutoStop_Click);
			this.simpleButton_HuntAutoStart.Location = new global::System.Drawing.Point(46, 24);
			this.simpleButton_HuntAutoStart.Name = "simpleButton_HuntAutoStart";
			this.simpleButton_HuntAutoStart.Size = new global::System.Drawing.Size(101, 23);
			this.simpleButton_HuntAutoStart.TabIndex = 0;
			this.simpleButton_HuntAutoStart.Text = "Lancement";
			this.simpleButton_HuntAutoStart.Click += new global::System.EventHandler(this.simpleButton_HuntAutoStart_Click);
			this.labelControl_HuntAuto_IndiceCor.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.labelControl_HuntAuto_IndiceCor.Location = new global::System.Drawing.Point(46, 148);
			this.labelControl_HuntAuto_IndiceCor.Name = "labelControl_HuntAuto_IndiceCor";
			this.labelControl_HuntAuto_IndiceCor.Size = new global::System.Drawing.Size(72, 13);
			this.labelControl_HuntAuto_IndiceCor.TabIndex = 20;
			this.labelControl_HuntAuto_IndiceCor.Text = "Indice corrigé :";
			this.labelControl_HuntAuto_IndiceCor.Visible = false;
			this.labelControl_HuntAuto_IndiceCor.Click += new global::System.EventHandler(this.labelControl_HuntAuto_IndiceCor_Click);
			this.labelControl_HuntAuto_Indice.Location = new global::System.Drawing.Point(46, 110);
			this.labelControl_HuntAuto_Indice.Name = "labelControl_HuntAuto_Indice";
			this.labelControl_HuntAuto_Indice.Size = new global::System.Drawing.Size(36, 13);
			this.labelControl_HuntAuto_Indice.TabIndex = 19;
			this.labelControl_HuntAuto_Indice.Text = "Indice :";
			this.panelControl_Home.Controls.Add(this.pictureBox_Discord);
			this.panelControl_Home.Controls.Add(this.separatorControl5);
			this.panelControl_Home.Controls.Add(this.labelControl1);
			this.panelControl_Home.Controls.Add(this.labelControl_Hunt_Version);
			this.panelControl_Home.Location = new global::System.Drawing.Point(187, 11);
			this.panelControl_Home.Name = "panelControl_Home";
			this.panelControl_Home.Size = new global::System.Drawing.Size(300, 300);
			this.panelControl_Home.TabIndex = 23;
			this.panelControl_Home.Visible = false;
			this.pictureBox_Discord.Image = global::Dofus_Hunt.Properties.Resources.discord_brands_solid__1_;
			this.pictureBox_Discord.Location = new global::System.Drawing.Point(130, 256);
			this.pictureBox_Discord.Name = "pictureBox_Discord";
			this.pictureBox_Discord.Size = new global::System.Drawing.Size(40, 30);
			this.pictureBox_Discord.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox_Discord.TabIndex = 16;
			this.pictureBox_Discord.TabStop = false;
			this.pictureBox_Discord.Click += new global::System.EventHandler(this.pictureBox_Discord_Click);
			this.separatorControl5.Location = new global::System.Drawing.Point(44, 59);
			this.separatorControl5.Name = "separatorControl5";
			this.separatorControl5.Size = new global::System.Drawing.Size(213, 26);
			this.separatorControl5.TabIndex = 1;
			this.labelControl1.Appearance.Font = new global::System.Drawing.Font("Tahoma", 15.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.labelControl1.Appearance.Options.UseFont = true;
			this.labelControl1.Location = new global::System.Drawing.Point(91, 27);
			this.labelControl1.Name = "labelControl1";
			this.labelControl1.Size = new global::System.Drawing.Size(118, 25);
			this.labelControl1.TabIndex = 0;
			this.labelControl1.Text = "Dofus Hunt";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(489, 321);
			base.Controls.Add(this.panelControl_Hunt_ConfigHuntAuto);
			base.Controls.Add(this.panelControl_Hunt_HuntAuto);
			base.Controls.Add(this.panelControl_Home);
			base.Controls.Add(this.panelControl_Hunt_Debug);
			base.Controls.Add(this.panelControl_Hunt_Hunt);
			base.Controls.Add(this.panelControl_Hunt_Notifications);
			base.Controls.Add(this.panelControl_Hunt_Config_Logiciel);
			base.Controls.Add(this.accordionControl1);
			base.Controls.Add(this.panelControl_Hunt_Indice);
			base.Controls.Add(this.panelControl_Hunt_Init);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.IconOptions.Icon = (global::System.Drawing.Icon)resources.GetObject("FormHome.IconOptions.Icon");
			base.MaximizeBox = false;
			base.Name = "FormHome";
			this.Text = "Dofus Hunt";
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.FormHome_FormClosing);
			base.Load += new global::System.EventHandler(this.FormHome_Load);
			((global::System.ComponentModel.ISupportInitialize)this.panelControl_Hunt_Init).EndInit();
			this.panelControl_Hunt_Init.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox_Hunt_Init_Logo).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.panelControl_Hunt_Config_Logiciel).EndInit();
			this.panelControl_Hunt_Config_Logiciel.ResumeLayout(false);
			this.panelControl_Hunt_Config_Logiciel.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.checkEdit_Hunt_Config_Logiciel_UpdateDHU.Properties).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.checkEdit_Hunt_Config_Logiciel_Notifications.Properties).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.checkEdit_Hunt_Config_Logiciel_DeleteLog.Properties).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.checkEdit_Hunt_Config_Logiciel_DeleteFile.Properties).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.checkEdit_Hunt_Config_Logiciel_LogAvance.Properties).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.checkEdit_Hunt_Config_Logiciel_Theme.Properties).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.checkEdit_Hunt_Config_Logiciel_Ecran.Properties).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.trackBarControl_Hunt_Config_Logiciel_Opacity.Properties).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.trackBarControl_Hunt_Config_Logiciel_Opacity).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.panelControl_Hunt_Notifications).EndInit();
			this.panelControl_Hunt_Notifications.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.xtraTabControl_Hunt_Config_Notifications).EndInit();
			this.xtraTabControl_Hunt_Config_Notifications.ResumeLayout(false);
			this.xtraTabPage_Notifications_App.ResumeLayout(false);
			this.xtraTabPage_Notifications_App.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_Notify_App_Restart.Properties).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_Notify_App_PbData.Properties).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_Notify_App_PbCo.Properties).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_Notify_App_Update.Properties).EndInit();
			this.xtraTabPage_Notifications_Hunt.ResumeLayout(false);
			this.xtraTabPage_Notifications_Hunt.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_Notify_Hunt_NoData.Properties).EndInit();
			this.xtraTabPage_Notifications_Indice.ResumeLayout(false);
			this.xtraTabPage_Notifications_Indice.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_Indices_CorrectIndice.Properties).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_Indices_Phorreur.Properties).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_Indices_IndiceKO.Properties).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_Indices_IndiceOK.Properties).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.panelControl_Hunt_Indice).EndInit();
			this.panelControl_Hunt_Indice.ResumeLayout(false);
			this.panelControl_Hunt_Indice.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_Hunt_Indice_Correct.Properties).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_Hunt_Indice_Incorrect.Properties).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.dataGridView_Hunt_Indice_List).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.accordionControl1).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.panelControl_Hunt_Debug).EndInit();
			this.panelControl_Hunt_Debug.ResumeLayout(false);
			this.panelControl_Hunt_Debug.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_Hunt_Debug_Indice.Properties).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_Hunt_Debug_Dir.Properties).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_Hunt_Debug_Y.Properties).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_Hunt_Debug_X.Properties).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_Hunt_Debug_Token.Properties).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.separatorControl1).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.panelControl_Hunt_ConfigHuntAuto).EndInit();
			this.panelControl_Hunt_ConfigHuntAuto.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.xtraTabControl_Hunt_Config_HuntAuto).EndInit();
			this.xtraTabControl_Hunt_Config_HuntAuto.ResumeLayout(false);
			this.xtraTabPage1.ResumeLayout(false);
			this.xtraTabPage1.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_Hunt_Config_Hunt_Indice_Detection.Properties).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_Hunt_Config_Debug.Properties).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.checkEdit_Hunt_Config_Debug.Properties).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.checkEdit_Hunt_Config_Offline.Properties).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.checkEdit_Hunt_Config_UseGoogleVision.Properties).EndInit();
			this.xtraTabPage2.ResumeLayout(false);
			this.xtraTabPage2.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_Hunt_Config_Hunt_Position_hauteurTexte.Properties).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_Hunt_Config_Hunt_Position_largeurTexte.Properties).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_Hunt_Config_Hunt_Position_threshold.Properties).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_Hunt_Config_Hunt_Position_height.Properties).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_Hunt_Config_Hunt_Position_width.Properties).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_Hunt_Config_Hunt_Position_Y.Properties).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_Hunt_Config_Hunt_Position_X.Properties).EndInit();
			this.xtraTabPage3.ResumeLayout(false);
			this.xtraTabPage3.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_Hunt_Config_Hunt_Indice_OCRCombat.Properties).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_Hunt_Config_Hunt_Indice_OCRCocheCheck.Properties).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_Hunt_Config_Hunt_Indice_OCRFleche.Properties).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_Hunt_Config_Hunt_Indice_HIndice.Properties).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_Hunt_Config_Hunt_Indice_LIndice.Properties).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_Hunt_Config_Hunt_Indice_OCRCoche.Properties).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_Hunt_Config_Hunt_Indice_HStart.Properties).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_Hunt_Config_Hunt_Indice_LStart.Properties).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_Hunt_Config_Hunt_Indice_OCRStart.Properties).EndInit();
			this.xtraTabPage4.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.groupControl5).EndInit();
			this.groupControl5.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox_Hunt_Config_Hunt_Template_Combat).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.groupControl4).EndInit();
			this.groupControl4.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox_Hunt_Config_Hunt_Template_Level).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.groupControl3).EndInit();
			this.groupControl3.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox_Hunt_Config_Hunt_Template_Start).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.groupControl2).EndInit();
			this.groupControl2.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox_Hunt_Config_Hunt_Template_Arrow_6).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox_Hunt_Config_Hunt_Template_Arrow_4).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox_Hunt_Config_Hunt_Template_Arrow_2).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox_Hunt_Config_Hunt_Template_Arrow_0).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.groupControl1).EndInit();
			this.groupControl1.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox_Hunt_Config_Hunt_Template_CocheChecked).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox_Hunt_Config_Hunt_Template_Coche).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.panelControl_Hunt_Hunt).EndInit();
			this.panelControl_Hunt_Hunt.ResumeLayout(false);
			this.panelControl_Hunt_Hunt.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.checkEdit_Hunt_AutoTravel.Properties).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.comboBoxEdit_Hunt_Indice.Properties).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.separatorControl4).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.separatorControl3).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_Hunt_Y.Properties).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.textEdit_Hunt_X.Properties).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.separatorControl2).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.toastNotificationsManager).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.panelControl_Hunt_HuntAuto).EndInit();
			this.panelControl_Hunt_HuntAuto.ResumeLayout(false);
			this.panelControl_Hunt_HuntAuto.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.checkEdit_Hunt_Auto_ModeReduit.Properties).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.checkEdit_HuntAuto_AutoTravel.Properties).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.panelControl_Home).EndInit();
			this.panelControl_Home.ResumeLayout(false);
			this.panelControl_Home.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox_Discord).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.separatorControl5).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x0400003B RID: 59
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400003C RID: 60
		private global::DevExpress.XtraEditors.PanelControl panelControl_Hunt_Init;

		// Token: 0x0400003D RID: 61
		private global::System.Windows.Forms.PictureBox pictureBox_Hunt_Init_Logo;

		// Token: 0x0400003E RID: 62
		private global::DevExpress.XtraWaitForm.ProgressPanel progressPanel1;

		// Token: 0x0400003F RID: 63
		private global::DevExpress.XtraEditors.PanelControl panelControl_Hunt_Config_Logiciel;

		// Token: 0x04000040 RID: 64
		private global::DevExpress.XtraEditors.CheckEdit checkEdit_Hunt_Config_Logiciel_LogAvance;

		// Token: 0x04000041 RID: 65
		private global::DevExpress.XtraEditors.CheckEdit checkEdit_Hunt_Config_Logiciel_Theme;

		// Token: 0x04000042 RID: 66
		private global::DevExpress.XtraEditors.CheckEdit checkEdit_Hunt_Config_Logiciel_Ecran;

		// Token: 0x04000043 RID: 67
		private global::DevExpress.XtraEditors.TrackBarControl trackBarControl_Hunt_Config_Logiciel_Opacity;

		// Token: 0x04000044 RID: 68
		private global::DevExpress.XtraEditors.LabelControl labelControl_Hunt_Config_Logiciel_Opacité;

		// Token: 0x04000045 RID: 69
		private global::DevExpress.XtraEditors.CheckEdit checkEdit_Hunt_Config_Logiciel_Notifications;

		// Token: 0x04000046 RID: 70
		private global::DevExpress.XtraEditors.CheckEdit checkEdit_Hunt_Config_Logiciel_DeleteLog;

		// Token: 0x04000047 RID: 71
		private global::DevExpress.XtraEditors.CheckEdit checkEdit_Hunt_Config_Logiciel_DeleteFile;

		// Token: 0x04000048 RID: 72
		private global::DevExpress.XtraEditors.PanelControl panelControl_Hunt_Notifications;

		// Token: 0x04000049 RID: 73
		private global::DevExpress.XtraTab.XtraTabControl xtraTabControl_Hunt_Config_Notifications;

		// Token: 0x0400004A RID: 74
		private global::DevExpress.XtraTab.XtraTabPage xtraTabPage_Notifications_App;

		// Token: 0x0400004B RID: 75
		private global::DevExpress.XtraEditors.TextEdit textEdit_Notify_App_Update;

		// Token: 0x0400004C RID: 76
		private global::DevExpress.XtraEditors.LabelControl labelControl_Notify_App_Uodate;

		// Token: 0x0400004D RID: 77
		private global::DevExpress.XtraTab.XtraTabPage xtraTabPage_Notifications_Hunt;

		// Token: 0x0400004E RID: 78
		private global::DevExpress.XtraEditors.TextEdit textEdit_Notify_App_PbData;

		// Token: 0x0400004F RID: 79
		private global::DevExpress.XtraEditors.LabelControl labelControl_Notify_App_PbData;

		// Token: 0x04000050 RID: 80
		private global::DevExpress.XtraEditors.TextEdit textEdit_Notify_App_PbCo;

		// Token: 0x04000051 RID: 81
		private global::DevExpress.XtraEditors.LabelControl labelControl_Notify_App_PbCo;

		// Token: 0x04000052 RID: 82
		private global::DevExpress.XtraEditors.SimpleButton simpleButton_Notify_Reinit;

		// Token: 0x04000053 RID: 83
		private global::DevExpress.XtraEditors.SimpleButton simpleButton_Notify_Save;

		// Token: 0x04000054 RID: 84
		private global::DevExpress.XtraEditors.TextEdit textEdit_Notify_App_Restart;

		// Token: 0x04000055 RID: 85
		private global::DevExpress.XtraEditors.LabelControl labelControl_Notify_App_Restart;

		// Token: 0x04000056 RID: 86
		private global::DevExpress.XtraEditors.TextEdit textEdit_Hunt_Config_Hunt_Position_hauteurTexte;

		// Token: 0x04000057 RID: 87
		private global::DevExpress.XtraEditors.LabelControl labelControl_Hunt_Pos;

		// Token: 0x04000058 RID: 88
		private global::DevExpress.XtraEditors.TextEdit textEdit_Notify_Hunt_NoData;

		// Token: 0x04000059 RID: 89
		private global::DevExpress.XtraEditors.LabelControl labelControl_Notify_Hunt_NoData;

		// Token: 0x0400005A RID: 90
		private global::DevExpress.XtraTab.XtraTabPage xtraTabPage_Notifications_Indice;

		// Token: 0x0400005B RID: 91
		private global::DevExpress.XtraEditors.LabelControl labelControl_Indices_IndiceOK;

		// Token: 0x0400005C RID: 92
		private global::DevExpress.XtraEditors.CheckEdit checkEdit_Hunt_Config_Logiciel_UpdateDHU;

		// Token: 0x0400005D RID: 93
		private global::DevExpress.XtraEditors.TextEdit textEdit_Indices_IndiceOK;

		// Token: 0x0400005E RID: 94
		private global::DevExpress.XtraEditors.TextEdit textEdit_Indices_IndiceKO;

		// Token: 0x0400005F RID: 95
		private global::DevExpress.XtraEditors.LabelControl labelControl_Indices_IndiceKO;

		// Token: 0x04000060 RID: 96
		private global::DevExpress.XtraEditors.TextEdit textEdit_Indices_CorrectIndice;

		// Token: 0x04000061 RID: 97
		private global::DevExpress.XtraEditors.LabelControl labelControl_Indices_CorrectIndice;

		// Token: 0x04000062 RID: 98
		private global::DevExpress.XtraEditors.TextEdit textEdit_Indices_Phorreur;

		// Token: 0x04000063 RID: 99
		private global::DevExpress.XtraEditors.LabelControl labelControl_Indices_Phorreur;

		// Token: 0x04000064 RID: 100
		private global::DevExpress.XtraEditors.PanelControl panelControl_Hunt_Indice;

		// Token: 0x04000065 RID: 101
		private global::DevExpress.XtraBars.Navigation.AccordionControl accordionControl1;

		// Token: 0x04000066 RID: 102
		private global::DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement_Menu_Hunt;

		// Token: 0x04000067 RID: 103
		private global::DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement_SubMenu_HuntAuto;

		// Token: 0x04000068 RID: 104
		private global::DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement_SubMenu_Hunt;

		// Token: 0x04000069 RID: 105
		private global::DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement_Menu_Config;

		// Token: 0x0400006A RID: 106
		private global::DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement_SubMenu_Config_Logiciel;

		// Token: 0x0400006B RID: 107
		private global::DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement_SubMenu_Config_HuntAuto;

		// Token: 0x0400006C RID: 108
		private global::DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement_SubMenu_Config_Indice;

		// Token: 0x0400006D RID: 109
		private global::DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement_SubMenu_Config_Update;

		// Token: 0x0400006E RID: 110
		private global::DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement_SubMenu_Config_Debug;

		// Token: 0x0400006F RID: 111
		private global::DevExpress.XtraEditors.LabelControl labelControl_Hunt_Version;

		// Token: 0x04000070 RID: 112
		private global::DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement_SubMenu_Config_Notif;

		// Token: 0x04000071 RID: 113
		private global::System.Windows.Forms.DataGridView dataGridView_Hunt_Indice_List;

		// Token: 0x04000072 RID: 114
		private global::DevExpress.XtraEditors.SimpleButton simpleButton_Hunt_Indice_Add;

		// Token: 0x04000073 RID: 115
		private global::DevExpress.XtraEditors.TextEdit textEdit_Hunt_Indice_Correct;

		// Token: 0x04000074 RID: 116
		private global::DevExpress.XtraEditors.LabelControl labelControl_Hunt_Indice_Correct;

		// Token: 0x04000075 RID: 117
		private global::DevExpress.XtraEditors.TextEdit textEdit_Hunt_Indice_Incorrect;

		// Token: 0x04000076 RID: 118
		private global::DevExpress.XtraEditors.LabelControl labelControl_Hunt_Indice_Incorrect;

		// Token: 0x04000077 RID: 119
		private global::System.Windows.Forms.DataGridViewTextBoxColumn Column_Incorrect;

		// Token: 0x04000078 RID: 120
		private global::System.Windows.Forms.DataGridViewTextBoxColumn Column_Correct;

		// Token: 0x04000079 RID: 121
		private global::DevExpress.XtraEditors.PanelControl panelControl_Hunt_Debug;

		// Token: 0x0400007A RID: 122
		private global::DevExpress.XtraEditors.SimpleButton simpleButton_Hunt_Debug_Token;

		// Token: 0x0400007B RID: 123
		private global::DevExpress.XtraEditors.TextEdit textEdit_Hunt_Debug_Token;

		// Token: 0x0400007C RID: 124
		private global::DevExpress.XtraEditors.LabelControl labelControl_Hunt_Debug_Token;

		// Token: 0x0400007D RID: 125
		private global::DevExpress.XtraEditors.SeparatorControl separatorControl1;

		// Token: 0x0400007E RID: 126
		private global::DevExpress.XtraEditors.LabelControl labelControl_Hunt_Debug;

		// Token: 0x0400007F RID: 127
		private global::DevExpress.XtraEditors.SimpleButton simpleButton_Hunt_Debug_Capture;

		// Token: 0x04000080 RID: 128
		private global::DevExpress.XtraEditors.TextEdit textEdit_Hunt_Debug_Dir;

		// Token: 0x04000081 RID: 129
		private global::DevExpress.XtraEditors.LabelControl labelControl_Hunt_Debug_Dir;

		// Token: 0x04000082 RID: 130
		private global::DevExpress.XtraEditors.TextEdit textEdit_Hunt_Debug_Y;

		// Token: 0x04000083 RID: 131
		private global::DevExpress.XtraEditors.LabelControl labelControl_Hunt_Debug_Y;

		// Token: 0x04000084 RID: 132
		private global::DevExpress.XtraEditors.TextEdit textEdit_Hunt_Debug_X;

		// Token: 0x04000085 RID: 133
		private global::DevExpress.XtraEditors.LabelControl labelControl_Hunt_Debug_X;

		// Token: 0x04000086 RID: 134
		private global::DevExpress.XtraEditors.SimpleButton simpleButton_Hunt_Debug_GetPositionIndice;

		// Token: 0x04000087 RID: 135
		private global::DevExpress.XtraEditors.TextEdit textEdit_Hunt_Debug_Indice;

		// Token: 0x04000088 RID: 136
		private global::DevExpress.XtraEditors.LabelControl labelControl_Hunt_Debug_Indice;

		// Token: 0x04000089 RID: 137
		private global::DevExpress.XtraEditors.SimpleButton simpleButton_Hunt_Debug_GetPosition;

		// Token: 0x0400008A RID: 138
		private global::DevExpress.XtraEditors.PanelControl panelControl_Hunt_ConfigHuntAuto;

		// Token: 0x0400008B RID: 139
		private global::DevExpress.XtraTab.XtraTabControl xtraTabControl_Hunt_Config_HuntAuto;

		// Token: 0x0400008C RID: 140
		private global::DevExpress.XtraTab.XtraTabPage xtraTabPage1;

		// Token: 0x0400008D RID: 141
		private global::DevExpress.XtraEditors.CheckEdit checkEdit_Hunt_Config_Offline;

		// Token: 0x0400008E RID: 142
		private global::DevExpress.XtraEditors.CheckEdit checkEdit_Hunt_Config_UseGoogleVision;

		// Token: 0x0400008F RID: 143
		private global::DevExpress.XtraTab.XtraTabPage xtraTabPage2;

		// Token: 0x04000090 RID: 144
		private global::DevExpress.XtraEditors.TextEdit textEdit_Hunt_Config_Debug;

		// Token: 0x04000091 RID: 145
		private global::DevExpress.XtraEditors.CheckEdit checkEdit_Hunt_Config_Debug;

		// Token: 0x04000092 RID: 146
		private global::DevExpress.XtraEditors.TextEdit textEdit_Hunt_Config_Hunt_Position_threshold;

		// Token: 0x04000093 RID: 147
		private global::DevExpress.XtraEditors.LabelControl labelControl_Hunt_Config_Hunt_Position_threshold;

		// Token: 0x04000094 RID: 148
		private global::DevExpress.XtraEditors.TextEdit textEdit_Hunt_Config_Hunt_Position_height;

		// Token: 0x04000095 RID: 149
		private global::DevExpress.XtraEditors.LabelControl labelControl_Hunt_Config_Hunt_Position_height;

		// Token: 0x04000096 RID: 150
		private global::DevExpress.XtraEditors.TextEdit textEdit_Hunt_Config_Hunt_Position_width;

		// Token: 0x04000097 RID: 151
		private global::DevExpress.XtraEditors.LabelControl labelControl_Hunt_Config_Hunt_Position_width;

		// Token: 0x04000098 RID: 152
		private global::DevExpress.XtraEditors.TextEdit textEdit_Hunt_Config_Hunt_Position_Y;

		// Token: 0x04000099 RID: 153
		private global::DevExpress.XtraEditors.LabelControl labelControl_Hunt_Config_Hunt_Position_Y;

		// Token: 0x0400009A RID: 154
		private global::DevExpress.XtraEditors.TextEdit textEdit_Hunt_Config_Hunt_Position_X;

		// Token: 0x0400009B RID: 155
		private global::DevExpress.XtraEditors.LabelControl labelControl_Hunt_Config_Hunt_Position_X;

		// Token: 0x0400009C RID: 156
		private global::DevExpress.XtraEditors.SimpleButton simpleButton_Hunt_Config_Hunt_Position_save;

		// Token: 0x0400009D RID: 157
		private global::DevExpress.XtraEditors.LabelControl labelControl_Hunt_Config_Hunt_Position_hauteurTexte;

		// Token: 0x0400009E RID: 158
		private global::DevExpress.XtraEditors.TextEdit textEdit_Hunt_Config_Hunt_Position_largeurTexte;

		// Token: 0x0400009F RID: 159
		private global::DevExpress.XtraEditors.LabelControl labelControl_Hunt_Config_Hunt_Position_largeurTexte;

		// Token: 0x040000A0 RID: 160
		private global::DevExpress.XtraEditors.SimpleButton simpleButton_Hunt_Debug_GetIndice;

		// Token: 0x040000A1 RID: 161
		private global::DevExpress.XtraEditors.SimpleButton simpleButton_Hunt_Debug_GetArrow;

		// Token: 0x040000A2 RID: 162
		private global::DevExpress.XtraTab.XtraTabPage xtraTabPage3;

		// Token: 0x040000A3 RID: 163
		private global::DevExpress.XtraEditors.SimpleButton simpleButton_Hunt_Config_Hunt_Indice_Save;

		// Token: 0x040000A4 RID: 164
		private global::DevExpress.XtraEditors.TextEdit textEdit_Hunt_Config_Hunt_Indice_OCRFleche;

		// Token: 0x040000A5 RID: 165
		private global::DevExpress.XtraEditors.LabelControl labelControl_Hunt_Config_Hunt_Indice_OCRFleche;

		// Token: 0x040000A6 RID: 166
		private global::DevExpress.XtraEditors.TextEdit textEdit_Hunt_Config_Hunt_Indice_HIndice;

		// Token: 0x040000A7 RID: 167
		private global::DevExpress.XtraEditors.LabelControl labelControl_Hunt_Config_Hunt_Indice_HIndice;

		// Token: 0x040000A8 RID: 168
		private global::DevExpress.XtraEditors.TextEdit textEdit_Hunt_Config_Hunt_Indice_LIndice;

		// Token: 0x040000A9 RID: 169
		private global::DevExpress.XtraEditors.LabelControl labelControl_Hunt_Config_Hunt_Indice_LCoche;

		// Token: 0x040000AA RID: 170
		private global::DevExpress.XtraEditors.TextEdit textEdit_Hunt_Config_Hunt_Indice_OCRCoche;

		// Token: 0x040000AB RID: 171
		private global::DevExpress.XtraEditors.LabelControl labelControl_Hunt_Config_Hunt_Indice_OCRCoche;

		// Token: 0x040000AC RID: 172
		private global::DevExpress.XtraEditors.TextEdit textEdit_Hunt_Config_Hunt_Indice_HStart;

		// Token: 0x040000AD RID: 173
		private global::DevExpress.XtraEditors.LabelControl labelControl_Hunt_Config_Hunt_Indice_HStart;

		// Token: 0x040000AE RID: 174
		private global::DevExpress.XtraEditors.TextEdit textEdit_Hunt_Config_Hunt_Indice_LStart;

		// Token: 0x040000AF RID: 175
		private global::DevExpress.XtraEditors.LabelControl labelControl_Hunt_Config_Hunt_Indice_LStart;

		// Token: 0x040000B0 RID: 176
		private global::DevExpress.XtraEditors.TextEdit textEdit_Hunt_Config_Hunt_Indice_OCRStart;

		// Token: 0x040000B1 RID: 177
		private global::DevExpress.XtraEditors.LabelControl labelControl_Hunt_Config_Hunt_Indice_OCRStart;

		// Token: 0x040000B2 RID: 178
		private global::DevExpress.XtraTab.XtraTabPage xtraTabPage4;

		// Token: 0x040000B3 RID: 179
		private global::System.Windows.Forms.PictureBox pictureBox_Hunt_Config_Hunt_Template_Coche;

		// Token: 0x040000B4 RID: 180
		private global::System.Windows.Forms.PictureBox pictureBox_Hunt_Config_Hunt_Template_Level;

		// Token: 0x040000B5 RID: 181
		private global::System.Windows.Forms.PictureBox pictureBox_Hunt_Config_Hunt_Template_Arrow_4;

		// Token: 0x040000B6 RID: 182
		private global::System.Windows.Forms.PictureBox pictureBox_Hunt_Config_Hunt_Template_Arrow_2;

		// Token: 0x040000B7 RID: 183
		private global::System.Windows.Forms.PictureBox pictureBox_Hunt_Config_Hunt_Template_Arrow_0;

		// Token: 0x040000B8 RID: 184
		private global::System.Windows.Forms.PictureBox pictureBox_Hunt_Config_Hunt_Template_Arrow_6;

		// Token: 0x040000B9 RID: 185
		private global::System.Windows.Forms.PictureBox pictureBox_Hunt_Config_Hunt_Template_Start;

		// Token: 0x040000BA RID: 186
		private global::DevExpress.XtraEditors.GroupControl groupControl2;

		// Token: 0x040000BB RID: 187
		private global::DevExpress.XtraEditors.GroupControl groupControl1;

		// Token: 0x040000BC RID: 188
		private global::DevExpress.XtraEditors.GroupControl groupControl4;

		// Token: 0x040000BD RID: 189
		private global::DevExpress.XtraEditors.GroupControl groupControl3;

		// Token: 0x040000BE RID: 190
		private global::DevExpress.XtraEditors.PanelControl panelControl_Hunt_Hunt;

		// Token: 0x040000BF RID: 191
		private global::DevExpress.XtraEditors.SeparatorControl separatorControl2;

		// Token: 0x040000C0 RID: 192
		private global::DevExpress.XtraEditors.TextEdit textEdit_Hunt_Y;

		// Token: 0x040000C1 RID: 193
		private global::DevExpress.XtraEditors.LabelControl labelControl_Hunt_Y;

		// Token: 0x040000C2 RID: 194
		private global::DevExpress.XtraEditors.TextEdit textEdit_Hunt_X;

		// Token: 0x040000C3 RID: 195
		private global::DevExpress.XtraEditors.LabelControl labelControl_Hunt_X;

		// Token: 0x040000C4 RID: 196
		private global::DevExpress.XtraEditors.SimpleButton simpleButton_Hunt_2;

		// Token: 0x040000C5 RID: 197
		private global::DevExpress.XtraEditors.SimpleButton simpleButton_Hunt_4;

		// Token: 0x040000C6 RID: 198
		private global::DevExpress.XtraEditors.SimpleButton simpleButton_Hunt_0;

		// Token: 0x040000C7 RID: 199
		private global::DevExpress.XtraEditors.SimpleButton simpleButton_Hunt_6;

		// Token: 0x040000C8 RID: 200
		private global::DevExpress.XtraEditors.SeparatorControl separatorControl3;

		// Token: 0x040000C9 RID: 201
		private global::DevExpress.XtraEditors.LabelControl labelControl_Hunt_Dir;

		// Token: 0x040000CA RID: 202
		private global::DevExpress.XtraEditors.CheckEdit checkEdit_Hunt_AutoTravel;

		// Token: 0x040000CB RID: 203
		private global::DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_Hunt_Indice;

		// Token: 0x040000CC RID: 204
		private global::DevExpress.XtraEditors.SeparatorControl separatorControl4;

		// Token: 0x040000CD RID: 205
		private global::DevExpress.XtraEditors.LabelControl labelControl_Hunt_Indice;

		// Token: 0x040000CE RID: 206
		private global::DevExpress.XtraEditors.LabelControl labelControl_Hunt_Map;

		// Token: 0x040000CF RID: 207
		private global::DevExpress.XtraBars.ToastNotifications.ToastNotificationsManager toastNotificationsManager;

		// Token: 0x040000D0 RID: 208
		private global::DevExpress.XtraEditors.PanelControl panelControl_Hunt_HuntAuto;

		// Token: 0x040000D1 RID: 209
		private global::DevExpress.XtraEditors.SimpleButton simpleButton_HuntAutoStart;

		// Token: 0x040000D2 RID: 210
		private global::DevExpress.XtraEditors.SimpleButton simpleButton_HuntAutoStop;

		// Token: 0x040000D3 RID: 211
		private global::DevExpress.XtraEditors.LabelControl labelControl_HuntAuto_MapIndice;

		// Token: 0x040000D4 RID: 212
		private global::DevExpress.XtraEditors.LabelControl labelControl_HuntAuto_Direction;

		// Token: 0x040000D5 RID: 213
		private global::DevExpress.XtraEditors.LabelControl labelControl_HuntAuto_IndiceCor;

		// Token: 0x040000D6 RID: 214
		private global::DevExpress.XtraEditors.LabelControl labelControl_HuntAuto_Indice;

		// Token: 0x040000D7 RID: 215
		private global::DevExpress.XtraEditors.LabelControl labelControl_HuntAuto_MapStart;

		// Token: 0x040000D8 RID: 216
		private global::DevExpress.XtraEditors.CheckEdit checkEdit_HuntAuto_AutoTravel;

		// Token: 0x040000D9 RID: 217
		private global::DevExpress.XtraEditors.TextEdit textEdit_Hunt_Config_Hunt_Indice_Detection;

		// Token: 0x040000DA RID: 218
		private global::DevExpress.XtraEditors.LabelControl labelControl_Hunt_Config_Hunt_Indice_Detection;

		// Token: 0x040000DB RID: 219
		private global::DevExpress.XtraEditors.PanelControl panelControl_Home;

		// Token: 0x040000DC RID: 220
		private global::System.Windows.Forms.PictureBox pictureBox_Discord;

		// Token: 0x040000DD RID: 221
		private global::DevExpress.XtraEditors.SeparatorControl separatorControl5;

		// Token: 0x040000DE RID: 222
		private global::DevExpress.XtraEditors.LabelControl labelControl1;

		// Token: 0x040000DF RID: 223
		private global::DevExpress.XtraEditors.CheckEdit checkEdit_Hunt_Auto_ModeReduit;

		// Token: 0x040000E0 RID: 224
		private global::DevExpress.XtraEditors.GroupControl groupControl5;

		// Token: 0x040000E1 RID: 225
		private global::System.Windows.Forms.PictureBox pictureBox_Hunt_Config_Hunt_Template_Combat;

		// Token: 0x040000E2 RID: 226
		private global::System.Windows.Forms.PictureBox pictureBox_Hunt_Config_Hunt_Template_CocheChecked;

		// Token: 0x040000E3 RID: 227
		private global::DevExpress.XtraEditors.TextEdit textEdit_Hunt_Config_Hunt_Indice_OCRCombat;

		// Token: 0x040000E4 RID: 228
		private global::DevExpress.XtraEditors.LabelControl labelControl_Hunt_Config_Hunt_Indice_OCRCombat;

		// Token: 0x040000E5 RID: 229
		private global::DevExpress.XtraEditors.TextEdit textEdit_Hunt_Config_Hunt_Indice_OCRCocheCheck;

		// Token: 0x040000E6 RID: 230
		private global::DevExpress.XtraEditors.LabelControl labelControl_Hunt_Config_Hunt_Indice_OCRCocheChecked;
	}
}
