<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.PNLMenu = New System.Windows.Forms.Panel()
        Me.CMDMasteries = New System.Windows.Forms.Button()
        Me.CMDSettings = New System.Windows.Forms.Button()
        Me.CMDAchievements = New System.Windows.Forms.Button()
        Me.CMDShop = New System.Windows.Forms.Button()
        Me.CMDTheArena = New System.Windows.Forms.Button()
        Me.CMDFountain = New System.Windows.Forms.Button()
        Me.CMDCharacter = New System.Windows.Forms.Button()
        Me.CMDResetSave = New System.Windows.Forms.Button()
        Me.CMDSave = New System.Windows.Forms.Button()
        Me.CMDConsole = New System.Windows.Forms.Button()
        Me.PNLCharacter = New System.Windows.Forms.Panel()
        Me.GRBEquipment = New System.Windows.Forms.GroupBox()
        Me.CMDUnequipOffhand = New System.Windows.Forms.Button()
        Me.CMDUnequipMainhand = New System.Windows.Forms.Button()
        Me.CMDUnequipBoots = New System.Windows.Forms.Button()
        Me.CMDUnequipLegs = New System.Windows.Forms.Button()
        Me.CMDUnequipChest = New System.Windows.Forms.Button()
        Me.CMDUnequipShoulders = New System.Windows.Forms.Button()
        Me.CMDUnequipHead = New System.Windows.Forms.Button()
        Me.TXTOffHand = New System.Windows.Forms.TextBox()
        Me.TXTMainHand = New System.Windows.Forms.TextBox()
        Me.TXTBoots = New System.Windows.Forms.TextBox()
        Me.TXTLegs = New System.Windows.Forms.TextBox()
        Me.TXTChest = New System.Windows.Forms.TextBox()
        Me.TXTShoulders = New System.Windows.Forms.TextBox()
        Me.TXTHead = New System.Windows.Forms.TextBox()
        Me.LBLmnuOffhand = New System.Windows.Forms.Label()
        Me.LBLmnuMainhand = New System.Windows.Forms.Label()
        Me.LBLmnuBoots = New System.Windows.Forms.Label()
        Me.LBLmnuLegs = New System.Windows.Forms.Label()
        Me.LBLmnuChest = New System.Windows.Forms.Label()
        Me.LBLmnuShoulders = New System.Windows.Forms.Label()
        Me.LBLmnuHead = New System.Windows.Forms.Label()
        Me.LBLmnuEquipment = New System.Windows.Forms.Label()
        Me.GRBCharacterInfo = New System.Windows.Forms.GroupBox()
        Me.music_player = New AxWMPLib.AxWindowsMediaPlayer()
        Me.LBLDiv2 = New System.Windows.Forms.Label()
        Me.LBLMaxMP = New System.Windows.Forms.Label()
        Me.LBLCurrentMP = New System.Windows.Forms.Label()
        Me.LBLmnuManaPoints = New System.Windows.Forms.Label()
        Me.LBLExperience = New System.Windows.Forms.Label()
        Me.LBLmnuExperience = New System.Windows.Forms.Label()
        Me.LBLDiv = New System.Windows.Forms.Label()
        Me.LBLMaxHP = New System.Windows.Forms.Label()
        Me.LBLCurrentHP = New System.Windows.Forms.Label()
        Me.LBLmnuHitPoints = New System.Windows.Forms.Label()
        Me.LBLAge = New System.Windows.Forms.Label()
        Me.LBLmnuAge = New System.Windows.Forms.Label()
        Me.LBLGender = New System.Windows.Forms.Label()
        Me.LBLmnuGender = New System.Windows.Forms.Label()
        Me.PCBAvatar = New System.Windows.Forms.PictureBox()
        Me.LBLLevel = New System.Windows.Forms.Label()
        Me.LBLAlignment = New System.Windows.Forms.Label()
        Me.LBLRace = New System.Windows.Forms.Label()
        Me.LBLCharacterName = New System.Windows.Forms.Label()
        Me.LBLmnuAlignment = New System.Windows.Forms.Label()
        Me.LBLmnuRace = New System.Windows.Forms.Label()
        Me.LBLmnuLevel = New System.Windows.Forms.Label()
        Me.LBLmnuCharacterName = New System.Windows.Forms.Label()
        Me.GRBAttributes = New System.Windows.Forms.GroupBox()
        Me.LBLCritChance = New System.Windows.Forms.Label()
        Me.LBLmnuCritChance = New System.Windows.Forms.Label()
        Me.LBLHitChance = New System.Windows.Forms.Label()
        Me.LBLmnuHitChance = New System.Windows.Forms.Label()
        Me.LBLUnspentAttributePoints = New System.Windows.Forms.Label()
        Me.LBLmnuUnspentAttributePoints = New System.Windows.Forms.Label()
        Me.CMDAddWisdom = New System.Windows.Forms.Button()
        Me.CMDAddIntelligence = New System.Windows.Forms.Button()
        Me.CMDAddCharisma = New System.Windows.Forms.Button()
        Me.CMDAddConstitution = New System.Windows.Forms.Button()
        Me.CMDAddDexterity = New System.Windows.Forms.Button()
        Me.CMDAddStrength = New System.Windows.Forms.Button()
        Me.CMDSubtractWisdom = New System.Windows.Forms.Button()
        Me.CMDSubtractIntelligence = New System.Windows.Forms.Button()
        Me.CMDSubtractCharisma = New System.Windows.Forms.Button()
        Me.CMDSubtractConstitution = New System.Windows.Forms.Button()
        Me.CMDSubtractDexterity = New System.Windows.Forms.Button()
        Me.CMDSubtractStrength = New System.Windows.Forms.Button()
        Me.LBLDamage = New System.Windows.Forms.Label()
        Me.LBLmnuDamage = New System.Windows.Forms.Label()
        Me.LBLarmorclass = New System.Windows.Forms.Label()
        Me.LBLmnuArmorClass = New System.Windows.Forms.Label()
        Me.LBLmnuAttribbute = New System.Windows.Forms.Label()
        Me.LBLmnuModifier = New System.Windows.Forms.Label()
        Me.LBLmnuPoints = New System.Windows.Forms.Label()
        Me.LBLCharismaMod = New System.Windows.Forms.Label()
        Me.LBLWisdomMod = New System.Windows.Forms.Label()
        Me.LBLIntelligenceMod = New System.Windows.Forms.Label()
        Me.LBLConstitutionMod = New System.Windows.Forms.Label()
        Me.LBLDexterityMod = New System.Windows.Forms.Label()
        Me.LBLStrengthMod = New System.Windows.Forms.Label()
        Me.LBLCharisma = New System.Windows.Forms.Label()
        Me.LBLWisdom = New System.Windows.Forms.Label()
        Me.LBLIntelligence = New System.Windows.Forms.Label()
        Me.LBLConstitution = New System.Windows.Forms.Label()
        Me.LBLDexterity = New System.Windows.Forms.Label()
        Me.LBLStrength = New System.Windows.Forms.Label()
        Me.LBLmnuDexterity = New System.Windows.Forms.Label()
        Me.LBLmnuConstitution = New System.Windows.Forms.Label()
        Me.LBLmnuIntelligence = New System.Windows.Forms.Label()
        Me.LBLmnuWisdom = New System.Windows.Forms.Label()
        Me.LBLmnuCharisma = New System.Windows.Forms.Label()
        Me.LBLmnuStrength = New System.Windows.Forms.Label()
        Me.GRBInventory = New System.Windows.Forms.GroupBox()
        Me.GRBItemInfo = New System.Windows.Forms.GroupBox()
        Me.LBLEquipmentExtraMana = New System.Windows.Forms.Label()
        Me.LBLEquipmentExtraHealth = New System.Windows.Forms.Label()
        Me.LBLEquipmentType = New System.Windows.Forms.Label()
        Me.PCBSelecteditem = New System.Windows.Forms.PictureBox()
        Me.PCBmnuEquipmentValue = New System.Windows.Forms.PictureBox()
        Me.LBLEquipmentValue = New System.Windows.Forms.Label()
        Me.LBLEquipmentDamage = New System.Windows.Forms.Label()
        Me.LBLmnuEquipmentDamage = New System.Windows.Forms.Label()
        Me.LBLEquipmentDescription = New System.Windows.Forms.Label()
        Me.LBLEquipmentAC = New System.Windows.Forms.Label()
        Me.LBLmnuEquipmentAC = New System.Windows.Forms.Label()
        Me.PCBGold = New System.Windows.Forms.PictureBox()
        Me.CMDTrash = New System.Windows.Forms.Button()
        Me.LBLGold = New System.Windows.Forms.Label()
        Me.CMDEquip = New System.Windows.Forms.Button()
        Me.LSBInventory = New System.Windows.Forms.ListBox()
        Me.LBLmnuInventory = New System.Windows.Forms.Label()
        Me.PNLFountain = New System.Windows.Forms.Panel()
        Me.LBLfountainMnuGold = New System.Windows.Forms.Label()
        Me.NMCGoldDonation = New System.Windows.Forms.NumericUpDown()
        Me.LBLfountainMnuGoldQuestion = New System.Windows.Forms.Label()
        Me.PCBWishingWell = New System.Windows.Forms.PictureBox()
        Me.PNLTheArena = New System.Windows.Forms.Panel()
        Me.CHBHideCombatLog = New System.Windows.Forms.CheckBox()
        Me.LBLSkillDescription = New System.Windows.Forms.Label()
        Me.GRBFoe4 = New System.Windows.Forms.GroupBox()
        Me.LBLArenaFoe4Name = New System.Windows.Forms.Label()
        Me.PGBFoe4HP = New System.Windows.Forms.ProgressBar()
        Me.PCBArenaFoe4Avatar = New System.Windows.Forms.PictureBox()
        Me.LBLArenaMnuFoe4HP = New System.Windows.Forms.Label()
        Me.LBLArenaFoe4CurrentHP = New System.Windows.Forms.Label()
        Me.LBLArenaDiv6 = New System.Windows.Forms.Label()
        Me.LBLArenaFoe4MaxHP = New System.Windows.Forms.Label()
        Me.LBLArenaFoe4Border = New System.Windows.Forms.Label()
        Me.GRBFoe3 = New System.Windows.Forms.GroupBox()
        Me.LBLArenaFoe3Name = New System.Windows.Forms.Label()
        Me.PGBFoe3HP = New System.Windows.Forms.ProgressBar()
        Me.PCBArenaFoe3Avatar = New System.Windows.Forms.PictureBox()
        Me.LBLArenaMnuFoe3HP = New System.Windows.Forms.Label()
        Me.LBLArenaFoe3CurrentHP = New System.Windows.Forms.Label()
        Me.LBLArenaDiv5 = New System.Windows.Forms.Label()
        Me.LBLArenaFoe3MaxHP = New System.Windows.Forms.Label()
        Me.LBLArenaFoe3Border = New System.Windows.Forms.Label()
        Me.GRBFoe2 = New System.Windows.Forms.GroupBox()
        Me.LBLArenaFoe2Name = New System.Windows.Forms.Label()
        Me.PGBFoe2HP = New System.Windows.Forms.ProgressBar()
        Me.PCBArenaFoe2Avatar = New System.Windows.Forms.PictureBox()
        Me.LBLArenaMnuFoe2HP = New System.Windows.Forms.Label()
        Me.LBLArenaFoe2CurrentHP = New System.Windows.Forms.Label()
        Me.LBLArenaDiv4 = New System.Windows.Forms.Label()
        Me.LBLArenaFoe2MaxHP = New System.Windows.Forms.Label()
        Me.LBLArenaFoe2Border = New System.Windows.Forms.Label()
        Me.GRBGeneralSkills = New System.Windows.Forms.GroupBox()
        Me.CMDUseItem = New System.Windows.Forms.Button()
        Me.CMDBlock = New System.Windows.Forms.Button()
        Me.CMDFlee = New System.Windows.Forms.Button()
        Me.LBLTurnCounter = New System.Windows.Forms.Label()
        Me.GRBNylathriaSkills = New System.Windows.Forms.GroupBox()
        Me.CMDNylathriaSkill5 = New System.Windows.Forms.Button()
        Me.CMDNylathriaSkill4 = New System.Windows.Forms.Button()
        Me.CMDNylathriaSkill3 = New System.Windows.Forms.Button()
        Me.CMDNylathriaSkill2 = New System.Windows.Forms.Button()
        Me.CMDNylathriaSkill1 = New System.Windows.Forms.Button()
        Me.GRBNardinaSkills = New System.Windows.Forms.GroupBox()
        Me.CMDNardinaSkill5 = New System.Windows.Forms.Button()
        Me.CMDNardinaSkill4 = New System.Windows.Forms.Button()
        Me.CMDNardinaSkill3 = New System.Windows.Forms.Button()
        Me.CMDNardinaSkill2 = New System.Windows.Forms.Button()
        Me.CMDNardinaSkill1 = New System.Windows.Forms.Button()
        Me.GRBMakyrSkills = New System.Windows.Forms.GroupBox()
        Me.CMDMakyrSkill5 = New System.Windows.Forms.Button()
        Me.CMDMakyrSkill4 = New System.Windows.Forms.Button()
        Me.CMDMakyrSkill3 = New System.Windows.Forms.Button()
        Me.CMDMakyrSkill2 = New System.Windows.Forms.Button()
        Me.CMDMakyrSkill1 = New System.Windows.Forms.Button()
        Me.GRBSagraxesSkills = New System.Windows.Forms.GroupBox()
        Me.CMDSagraxesSkill5 = New System.Windows.Forms.Button()
        Me.CMDSagraxesSkill4 = New System.Windows.Forms.Button()
        Me.CMDSagraxesSkill3 = New System.Windows.Forms.Button()
        Me.CMDSagraxesSkill2 = New System.Windows.Forms.Button()
        Me.CMDSagraxesSkill1 = New System.Windows.Forms.Button()
        Me.GRBFoe1 = New System.Windows.Forms.GroupBox()
        Me.LBLArenaFoe1Name = New System.Windows.Forms.Label()
        Me.PGBFoe1HP = New System.Windows.Forms.ProgressBar()
        Me.PCBArenaFoe1Avatar = New System.Windows.Forms.PictureBox()
        Me.LBLArenaMnuFoe1HP = New System.Windows.Forms.Label()
        Me.LBLArenaFoe1CurrentHP = New System.Windows.Forms.Label()
        Me.LBLArenaDiv3 = New System.Windows.Forms.Label()
        Me.LBLArenaFoe1MaxHP = New System.Windows.Forms.Label()
        Me.LBLArenaFoe1Border = New System.Windows.Forms.Label()
        Me.PGBPlayerHP = New System.Windows.Forms.ProgressBar()
        Me.PGBPlayerMP = New System.Windows.Forms.ProgressBar()
        Me.LBLArenaDiv2 = New System.Windows.Forms.Label()
        Me.LBLArenaMaxMP = New System.Windows.Forms.Label()
        Me.LBLArenaCurrentMP = New System.Windows.Forms.Label()
        Me.LBLArenaMnuMP = New System.Windows.Forms.Label()
        Me.LBLArenaDiv = New System.Windows.Forms.Label()
        Me.LBLArenaMaxHP = New System.Windows.Forms.Label()
        Me.LBLArenaCurrentHP = New System.Windows.Forms.Label()
        Me.LBLArenaMnuHP = New System.Windows.Forms.Label()
        Me.LBLArenaLevel = New System.Windows.Forms.Label()
        Me.LBLArenaCharacterName = New System.Windows.Forms.Label()
        Me.LBLArenaMnuLevel = New System.Windows.Forms.Label()
        Me.GRBFoe5 = New System.Windows.Forms.GroupBox()
        Me.LBLArenaFoe5Name = New System.Windows.Forms.Label()
        Me.PGBFoe5HP = New System.Windows.Forms.ProgressBar()
        Me.PCBArenaFoe5Avatar = New System.Windows.Forms.PictureBox()
        Me.LBLArenaMnuFoe5HP = New System.Windows.Forms.Label()
        Me.LBLArenaFoe5CurrentHP = New System.Windows.Forms.Label()
        Me.LBLArenaDiv7 = New System.Windows.Forms.Label()
        Me.LBLArenaFoe5MaxHP = New System.Windows.Forms.Label()
        Me.LBLArenaFoe5Border = New System.Windows.Forms.Label()
        Me.GRBAlyshaSkills = New System.Windows.Forms.GroupBox()
        Me.CMDAlyshaSkill5 = New System.Windows.Forms.Button()
        Me.CMDAlyshaSkill4 = New System.Windows.Forms.Button()
        Me.CMDAlyshaSkill3 = New System.Windows.Forms.Button()
        Me.CMDAlyshaSkill2 = New System.Windows.Forms.Button()
        Me.CMDAlyshaSkill1 = New System.Windows.Forms.Button()
        Me.PCBArenaAvatar = New System.Windows.Forms.PictureBox()
        Me.TXTCombatLog = New System.Windows.Forms.RichTextBox()
        Me.PNLShop = New System.Windows.Forms.Panel()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.GRBShopItemInfo = New System.Windows.Forms.GroupBox()
        Me.LBLShopItemExtraMana = New System.Windows.Forms.Label()
        Me.LBLShopItemExtraHealth = New System.Windows.Forms.Label()
        Me.PCBShopItemIcon = New System.Windows.Forms.PictureBox()
        Me.PCBmnuGoldItemValue = New System.Windows.Forms.PictureBox()
        Me.LBLShopItemValue = New System.Windows.Forms.Label()
        Me.LBLShopItemDamage = New System.Windows.Forms.Label()
        Me.LBLmnuShopItemDamage = New System.Windows.Forms.Label()
        Me.LBLShopItemDescription = New System.Windows.Forms.Label()
        Me.LBLShopItemAC = New System.Windows.Forms.Label()
        Me.LBLmnuShopItemAC = New System.Windows.Forms.Label()
        Me.LBLShopItemType = New System.Windows.Forms.Label()
        Me.CMDSell = New System.Windows.Forms.Button()
        Me.LSBShopSell = New System.Windows.Forms.ListBox()
        Me.LBLShopGold = New System.Windows.Forms.Label()
        Me.CMDBuy = New System.Windows.Forms.Button()
        Me.LSBShopBuy = New System.Windows.Forms.ListBox()
        Me.PNLSettings = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CMDMuteSfx = New System.Windows.Forms.Button()
        Me.CMDMuteMusic = New System.Windows.Forms.Button()
        Me.LBLVolume = New System.Windows.Forms.Label()
        Me.TCBMusicVolume = New System.Windows.Forms.TrackBar()
        Me.PNLMasteries = New System.Windows.Forms.Panel()
        Me.LBLMasteryDescription = New System.Windows.Forms.Label()
        Me.LBLMasteryTitle = New System.Windows.Forms.Label()
        Me.PCBMasteryTier_6_1 = New System.Windows.Forms.PictureBox()
        Me.PCBMasteryTier_5_2 = New System.Windows.Forms.PictureBox()
        Me.PCBMasteryTier_5_1 = New System.Windows.Forms.PictureBox()
        Me.PCBMasteryTier_4_2 = New System.Windows.Forms.PictureBox()
        Me.PCBMasteryTier_4_1 = New System.Windows.Forms.PictureBox()
        Me.PCBMasteryTier_3_3 = New System.Windows.Forms.PictureBox()
        Me.PCBMasteryTier_3_2 = New System.Windows.Forms.PictureBox()
        Me.PCBMasteryTier_3_1 = New System.Windows.Forms.PictureBox()
        Me.PCBMasteryTier_2_2 = New System.Windows.Forms.PictureBox()
        Me.PCBMasteryTier_2_1 = New System.Windows.Forms.PictureBox()
        Me.PCBMasteryTier_1_3 = New System.Windows.Forms.PictureBox()
        Me.PCBMasteryTier_1_2 = New System.Windows.Forms.PictureBox()
        Me.PCBMasteryTier_1_1 = New System.Windows.Forms.PictureBox()
        Me.LBLMastery11MaxScore = New System.Windows.Forms.Label()
        Me.LBLMastery12MaxScore = New System.Windows.Forms.Label()
        Me.LBLMastery13MaxScore = New System.Windows.Forms.Label()
        Me.LBLMastery21MaxScore = New System.Windows.Forms.Label()
        Me.LBLMastery22MaxScore = New System.Windows.Forms.Label()
        Me.LBLMastery31MaxScore = New System.Windows.Forms.Label()
        Me.LBLMastery32MaxScore = New System.Windows.Forms.Label()
        Me.LBLMastery33MaxScore = New System.Windows.Forms.Label()
        Me.LBLMastery41MaxScore = New System.Windows.Forms.Label()
        Me.LBLMastery42MaxScore = New System.Windows.Forms.Label()
        Me.LBLMastery51MaxScore = New System.Windows.Forms.Label()
        Me.LBLMastery52MaxScore = New System.Windows.Forms.Label()
        Me.LBLMastery61MaxScore = New System.Windows.Forms.Label()
        Me.LBLMastery11Score = New System.Windows.Forms.Label()
        Me.LBLMastery12Score = New System.Windows.Forms.Label()
        Me.LBLMastery13Score = New System.Windows.Forms.Label()
        Me.LBLMastery21Score = New System.Windows.Forms.Label()
        Me.LBLMastery22Score = New System.Windows.Forms.Label()
        Me.LBLMastery31Score = New System.Windows.Forms.Label()
        Me.LBLMastery32Score = New System.Windows.Forms.Label()
        Me.LBLMastery33Score = New System.Windows.Forms.Label()
        Me.LBLMastery41Score = New System.Windows.Forms.Label()
        Me.LBLMastery42Score = New System.Windows.Forms.Label()
        Me.LBLMastery51Score = New System.Windows.Forms.Label()
        Me.LBLMastery52Score = New System.Windows.Forms.Label()
        Me.LBLMastery61Score = New System.Windows.Forms.Label()
        Me.TimerRegen = New System.Windows.Forms.Timer(Me.components)
        Me.LBLEquipmentExtraHitChance = New System.Windows.Forms.Label()
        Me.LBLEquipmentExtraCritChance = New System.Windows.Forms.Label()
        Me.PNLMenu.SuspendLayout()
        Me.PNLCharacter.SuspendLayout()
        Me.GRBEquipment.SuspendLayout()
        Me.GRBCharacterInfo.SuspendLayout()
        CType(Me.music_player, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PCBAvatar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GRBAttributes.SuspendLayout()
        Me.GRBInventory.SuspendLayout()
        Me.GRBItemInfo.SuspendLayout()
        CType(Me.PCBSelecteditem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PCBmnuEquipmentValue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PCBGold, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PNLFountain.SuspendLayout()
        CType(Me.NMCGoldDonation, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PCBWishingWell, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PNLTheArena.SuspendLayout()
        Me.GRBFoe4.SuspendLayout()
        CType(Me.PCBArenaFoe4Avatar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GRBFoe3.SuspendLayout()
        CType(Me.PCBArenaFoe3Avatar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GRBFoe2.SuspendLayout()
        CType(Me.PCBArenaFoe2Avatar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GRBGeneralSkills.SuspendLayout()
        Me.GRBNylathriaSkills.SuspendLayout()
        Me.GRBNardinaSkills.SuspendLayout()
        Me.GRBMakyrSkills.SuspendLayout()
        Me.GRBSagraxesSkills.SuspendLayout()
        Me.GRBFoe1.SuspendLayout()
        CType(Me.PCBArenaFoe1Avatar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GRBFoe5.SuspendLayout()
        CType(Me.PCBArenaFoe5Avatar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GRBAlyshaSkills.SuspendLayout()
        CType(Me.PCBArenaAvatar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PNLShop.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GRBShopItemInfo.SuspendLayout()
        CType(Me.PCBShopItemIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PCBmnuGoldItemValue, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PNLSettings.SuspendLayout()
        CType(Me.TCBMusicVolume, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PNLMasteries.SuspendLayout()
        CType(Me.PCBMasteryTier_6_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PCBMasteryTier_5_2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PCBMasteryTier_5_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PCBMasteryTier_4_2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PCBMasteryTier_4_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PCBMasteryTier_3_3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PCBMasteryTier_3_2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PCBMasteryTier_3_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PCBMasteryTier_2_2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PCBMasteryTier_2_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PCBMasteryTier_1_3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PCBMasteryTier_1_2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PCBMasteryTier_1_1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PNLMenu
        '
        Me.PNLMenu.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PNLMenu.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.PNLMenu.Controls.Add(Me.CMDMasteries)
        Me.PNLMenu.Controls.Add(Me.CMDSettings)
        Me.PNLMenu.Controls.Add(Me.CMDAchievements)
        Me.PNLMenu.Controls.Add(Me.CMDShop)
        Me.PNLMenu.Controls.Add(Me.CMDTheArena)
        Me.PNLMenu.Controls.Add(Me.CMDFountain)
        Me.PNLMenu.Controls.Add(Me.CMDCharacter)
        Me.PNLMenu.Location = New System.Drawing.Point(0, 0)
        Me.PNLMenu.Name = "PNLMenu"
        Me.PNLMenu.Size = New System.Drawing.Size(987, 42)
        Me.PNLMenu.TabIndex = 0
        '
        'CMDMasteries
        '
        Me.CMDMasteries.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.CMDMasteries.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDMasteries.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDMasteries.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDMasteries.ForeColor = System.Drawing.Color.White
        Me.CMDMasteries.Location = New System.Drawing.Point(109, 3)
        Me.CMDMasteries.Name = "CMDMasteries"
        Me.CMDMasteries.Size = New System.Drawing.Size(100, 35)
        Me.CMDMasteries.TabIndex = 9
        Me.CMDMasteries.Text = "MASTERIES"
        Me.CMDMasteries.UseVisualStyleBackColor = False
        '
        'CMDSettings
        '
        Me.CMDSettings.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CMDSettings.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.CMDSettings.BackgroundImage = CType(resources.GetObject("CMDSettings.BackgroundImage"), System.Drawing.Image)
        Me.CMDSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.CMDSettings.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDSettings.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDSettings.ForeColor = System.Drawing.Color.White
        Me.CMDSettings.Location = New System.Drawing.Point(937, 3)
        Me.CMDSettings.Name = "CMDSettings"
        Me.CMDSettings.Size = New System.Drawing.Size(35, 35)
        Me.CMDSettings.TabIndex = 8
        Me.CMDSettings.UseVisualStyleBackColor = False
        '
        'CMDAchievements
        '
        Me.CMDAchievements.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.CMDAchievements.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDAchievements.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDAchievements.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDAchievements.ForeColor = System.Drawing.Color.White
        Me.CMDAchievements.Location = New System.Drawing.Point(533, 3)
        Me.CMDAchievements.Name = "CMDAchievements"
        Me.CMDAchievements.Size = New System.Drawing.Size(100, 35)
        Me.CMDAchievements.TabIndex = 7
        Me.CMDAchievements.Text = "ACHIEVEMENTS"
        Me.CMDAchievements.UseVisualStyleBackColor = False
        '
        'CMDShop
        '
        Me.CMDShop.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.CMDShop.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDShop.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDShop.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDShop.ForeColor = System.Drawing.Color.White
        Me.CMDShop.Location = New System.Drawing.Point(427, 3)
        Me.CMDShop.Name = "CMDShop"
        Me.CMDShop.Size = New System.Drawing.Size(100, 35)
        Me.CMDShop.TabIndex = 6
        Me.CMDShop.Text = "SHOP"
        Me.CMDShop.UseVisualStyleBackColor = False
        '
        'CMDTheArena
        '
        Me.CMDTheArena.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.CMDTheArena.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDTheArena.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDTheArena.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDTheArena.ForeColor = System.Drawing.Color.White
        Me.CMDTheArena.Location = New System.Drawing.Point(321, 3)
        Me.CMDTheArena.Name = "CMDTheArena"
        Me.CMDTheArena.Size = New System.Drawing.Size(100, 35)
        Me.CMDTheArena.TabIndex = 5
        Me.CMDTheArena.Text = "THE ARENA"
        Me.CMDTheArena.UseVisualStyleBackColor = False
        '
        'CMDFountain
        '
        Me.CMDFountain.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.CMDFountain.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDFountain.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDFountain.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDFountain.ForeColor = System.Drawing.Color.White
        Me.CMDFountain.Location = New System.Drawing.Point(215, 3)
        Me.CMDFountain.Name = "CMDFountain"
        Me.CMDFountain.Size = New System.Drawing.Size(100, 35)
        Me.CMDFountain.TabIndex = 2
        Me.CMDFountain.Text = "FOUNTAIN"
        Me.CMDFountain.UseVisualStyleBackColor = False
        '
        'CMDCharacter
        '
        Me.CMDCharacter.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.CMDCharacter.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDCharacter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDCharacter.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDCharacter.ForeColor = System.Drawing.Color.White
        Me.CMDCharacter.Location = New System.Drawing.Point(3, 3)
        Me.CMDCharacter.Name = "CMDCharacter"
        Me.CMDCharacter.Size = New System.Drawing.Size(100, 35)
        Me.CMDCharacter.TabIndex = 0
        Me.CMDCharacter.Text = "CHARACTER"
        Me.CMDCharacter.UseVisualStyleBackColor = False
        '
        'CMDResetSave
        '
        Me.CMDResetSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CMDResetSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.CMDResetSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDResetSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDResetSave.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDResetSave.ForeColor = System.Drawing.Color.White
        Me.CMDResetSave.Location = New System.Drawing.Point(6, 174)
        Me.CMDResetSave.Name = "CMDResetSave"
        Me.CMDResetSave.Size = New System.Drawing.Size(100, 35)
        Me.CMDResetSave.TabIndex = 4
        Me.CMDResetSave.Text = "RESET ALL"
        Me.CMDResetSave.UseVisualStyleBackColor = False
        '
        'CMDSave
        '
        Me.CMDSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CMDSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.CMDSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDSave.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDSave.ForeColor = System.Drawing.Color.White
        Me.CMDSave.Location = New System.Drawing.Point(6, 92)
        Me.CMDSave.Name = "CMDSave"
        Me.CMDSave.Size = New System.Drawing.Size(100, 35)
        Me.CMDSave.TabIndex = 3
        Me.CMDSave.Text = "SAVE"
        Me.CMDSave.UseVisualStyleBackColor = False
        '
        'CMDConsole
        '
        Me.CMDConsole.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CMDConsole.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.CMDConsole.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDConsole.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDConsole.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDConsole.ForeColor = System.Drawing.Color.White
        Me.CMDConsole.Location = New System.Drawing.Point(6, 133)
        Me.CMDConsole.Name = "CMDConsole"
        Me.CMDConsole.Size = New System.Drawing.Size(100, 35)
        Me.CMDConsole.TabIndex = 1
        Me.CMDConsole.Text = "CONSOLE"
        Me.CMDConsole.UseVisualStyleBackColor = False
        '
        'PNLCharacter
        '
        Me.PNLCharacter.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PNLCharacter.AutoScroll = True
        Me.PNLCharacter.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.PNLCharacter.Controls.Add(Me.GRBEquipment)
        Me.PNLCharacter.Controls.Add(Me.GRBCharacterInfo)
        Me.PNLCharacter.Controls.Add(Me.GRBAttributes)
        Me.PNLCharacter.Controls.Add(Me.GRBInventory)
        Me.PNLCharacter.Location = New System.Drawing.Point(12, 45)
        Me.PNLCharacter.Name = "PNLCharacter"
        Me.PNLCharacter.Size = New System.Drawing.Size(960, 575)
        Me.PNLCharacter.TabIndex = 1
        '
        'GRBEquipment
        '
        Me.GRBEquipment.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GRBEquipment.Controls.Add(Me.CMDUnequipOffhand)
        Me.GRBEquipment.Controls.Add(Me.CMDUnequipMainhand)
        Me.GRBEquipment.Controls.Add(Me.CMDUnequipBoots)
        Me.GRBEquipment.Controls.Add(Me.CMDUnequipLegs)
        Me.GRBEquipment.Controls.Add(Me.CMDUnequipChest)
        Me.GRBEquipment.Controls.Add(Me.CMDUnequipShoulders)
        Me.GRBEquipment.Controls.Add(Me.CMDUnequipHead)
        Me.GRBEquipment.Controls.Add(Me.TXTOffHand)
        Me.GRBEquipment.Controls.Add(Me.TXTMainHand)
        Me.GRBEquipment.Controls.Add(Me.TXTBoots)
        Me.GRBEquipment.Controls.Add(Me.TXTLegs)
        Me.GRBEquipment.Controls.Add(Me.TXTChest)
        Me.GRBEquipment.Controls.Add(Me.TXTShoulders)
        Me.GRBEquipment.Controls.Add(Me.TXTHead)
        Me.GRBEquipment.Controls.Add(Me.LBLmnuOffhand)
        Me.GRBEquipment.Controls.Add(Me.LBLmnuMainhand)
        Me.GRBEquipment.Controls.Add(Me.LBLmnuBoots)
        Me.GRBEquipment.Controls.Add(Me.LBLmnuLegs)
        Me.GRBEquipment.Controls.Add(Me.LBLmnuChest)
        Me.GRBEquipment.Controls.Add(Me.LBLmnuShoulders)
        Me.GRBEquipment.Controls.Add(Me.LBLmnuHead)
        Me.GRBEquipment.Controls.Add(Me.LBLmnuEquipment)
        Me.GRBEquipment.Location = New System.Drawing.Point(3, 395)
        Me.GRBEquipment.Name = "GRBEquipment"
        Me.GRBEquipment.Size = New System.Drawing.Size(937, 243)
        Me.GRBEquipment.TabIndex = 23
        Me.GRBEquipment.TabStop = False
        '
        'CMDUnequipOffhand
        '
        Me.CMDUnequipOffhand.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CMDUnequipOffhand.BackColor = System.Drawing.Color.Maroon
        Me.CMDUnequipOffhand.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDUnequipOffhand.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDUnequipOffhand.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDUnequipOffhand.ForeColor = System.Drawing.Color.White
        Me.CMDUnequipOffhand.Location = New System.Drawing.Point(480, 206)
        Me.CMDUnequipOffhand.Name = "CMDUnequipOffhand"
        Me.CMDUnequipOffhand.Size = New System.Drawing.Size(22, 22)
        Me.CMDUnequipOffhand.TabIndex = 43
        Me.CMDUnequipOffhand.Text = "-"
        Me.CMDUnequipOffhand.UseVisualStyleBackColor = False
        '
        'CMDUnequipMainhand
        '
        Me.CMDUnequipMainhand.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CMDUnequipMainhand.BackColor = System.Drawing.Color.Maroon
        Me.CMDUnequipMainhand.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDUnequipMainhand.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDUnequipMainhand.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDUnequipMainhand.ForeColor = System.Drawing.Color.White
        Me.CMDUnequipMainhand.Location = New System.Drawing.Point(480, 178)
        Me.CMDUnequipMainhand.Name = "CMDUnequipMainhand"
        Me.CMDUnequipMainhand.Size = New System.Drawing.Size(22, 22)
        Me.CMDUnequipMainhand.TabIndex = 42
        Me.CMDUnequipMainhand.Text = "-"
        Me.CMDUnequipMainhand.UseVisualStyleBackColor = False
        '
        'CMDUnequipBoots
        '
        Me.CMDUnequipBoots.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CMDUnequipBoots.BackColor = System.Drawing.Color.Maroon
        Me.CMDUnequipBoots.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDUnequipBoots.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDUnequipBoots.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDUnequipBoots.ForeColor = System.Drawing.Color.White
        Me.CMDUnequipBoots.Location = New System.Drawing.Point(480, 150)
        Me.CMDUnequipBoots.Name = "CMDUnequipBoots"
        Me.CMDUnequipBoots.Size = New System.Drawing.Size(22, 22)
        Me.CMDUnequipBoots.TabIndex = 41
        Me.CMDUnequipBoots.Text = "-"
        Me.CMDUnequipBoots.UseVisualStyleBackColor = False
        '
        'CMDUnequipLegs
        '
        Me.CMDUnequipLegs.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CMDUnequipLegs.BackColor = System.Drawing.Color.Maroon
        Me.CMDUnequipLegs.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDUnequipLegs.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDUnequipLegs.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDUnequipLegs.ForeColor = System.Drawing.Color.White
        Me.CMDUnequipLegs.Location = New System.Drawing.Point(480, 122)
        Me.CMDUnequipLegs.Name = "CMDUnequipLegs"
        Me.CMDUnequipLegs.Size = New System.Drawing.Size(22, 22)
        Me.CMDUnequipLegs.TabIndex = 40
        Me.CMDUnequipLegs.Text = "-"
        Me.CMDUnequipLegs.UseVisualStyleBackColor = False
        '
        'CMDUnequipChest
        '
        Me.CMDUnequipChest.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CMDUnequipChest.BackColor = System.Drawing.Color.Maroon
        Me.CMDUnequipChest.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDUnequipChest.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDUnequipChest.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDUnequipChest.ForeColor = System.Drawing.Color.White
        Me.CMDUnequipChest.Location = New System.Drawing.Point(480, 94)
        Me.CMDUnequipChest.Name = "CMDUnequipChest"
        Me.CMDUnequipChest.Size = New System.Drawing.Size(22, 22)
        Me.CMDUnequipChest.TabIndex = 39
        Me.CMDUnequipChest.Text = "-"
        Me.CMDUnequipChest.UseVisualStyleBackColor = False
        '
        'CMDUnequipShoulders
        '
        Me.CMDUnequipShoulders.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CMDUnequipShoulders.BackColor = System.Drawing.Color.Maroon
        Me.CMDUnequipShoulders.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDUnequipShoulders.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDUnequipShoulders.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDUnequipShoulders.ForeColor = System.Drawing.Color.White
        Me.CMDUnequipShoulders.Location = New System.Drawing.Point(480, 66)
        Me.CMDUnequipShoulders.Name = "CMDUnequipShoulders"
        Me.CMDUnequipShoulders.Size = New System.Drawing.Size(22, 22)
        Me.CMDUnequipShoulders.TabIndex = 38
        Me.CMDUnequipShoulders.Text = "-"
        Me.CMDUnequipShoulders.UseVisualStyleBackColor = False
        '
        'CMDUnequipHead
        '
        Me.CMDUnequipHead.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CMDUnequipHead.BackColor = System.Drawing.Color.Maroon
        Me.CMDUnequipHead.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDUnequipHead.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDUnequipHead.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDUnequipHead.ForeColor = System.Drawing.Color.White
        Me.CMDUnequipHead.Location = New System.Drawing.Point(480, 38)
        Me.CMDUnequipHead.Name = "CMDUnequipHead"
        Me.CMDUnequipHead.Size = New System.Drawing.Size(22, 22)
        Me.CMDUnequipHead.TabIndex = 37
        Me.CMDUnequipHead.Text = "-"
        Me.CMDUnequipHead.UseVisualStyleBackColor = False
        '
        'TXTOffHand
        '
        Me.TXTOffHand.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TXTOffHand.BackColor = System.Drawing.Color.Maroon
        Me.TXTOffHand.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TXTOffHand.Cursor = System.Windows.Forms.Cursors.Hand
        Me.TXTOffHand.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTOffHand.ForeColor = System.Drawing.Color.White
        Me.TXTOffHand.Location = New System.Drawing.Point(145, 206)
        Me.TXTOffHand.Name = "TXTOffHand"
        Me.TXTOffHand.ReadOnly = True
        Me.TXTOffHand.Size = New System.Drawing.Size(329, 23)
        Me.TXTOffHand.TabIndex = 36
        '
        'TXTMainHand
        '
        Me.TXTMainHand.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TXTMainHand.BackColor = System.Drawing.Color.Maroon
        Me.TXTMainHand.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TXTMainHand.Cursor = System.Windows.Forms.Cursors.Hand
        Me.TXTMainHand.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTMainHand.ForeColor = System.Drawing.Color.White
        Me.TXTMainHand.Location = New System.Drawing.Point(145, 178)
        Me.TXTMainHand.Name = "TXTMainHand"
        Me.TXTMainHand.ReadOnly = True
        Me.TXTMainHand.Size = New System.Drawing.Size(329, 23)
        Me.TXTMainHand.TabIndex = 35
        '
        'TXTBoots
        '
        Me.TXTBoots.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TXTBoots.BackColor = System.Drawing.Color.Maroon
        Me.TXTBoots.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TXTBoots.Cursor = System.Windows.Forms.Cursors.Hand
        Me.TXTBoots.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTBoots.ForeColor = System.Drawing.Color.White
        Me.TXTBoots.Location = New System.Drawing.Point(145, 150)
        Me.TXTBoots.Name = "TXTBoots"
        Me.TXTBoots.ReadOnly = True
        Me.TXTBoots.Size = New System.Drawing.Size(329, 23)
        Me.TXTBoots.TabIndex = 34
        '
        'TXTLegs
        '
        Me.TXTLegs.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TXTLegs.BackColor = System.Drawing.Color.Maroon
        Me.TXTLegs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TXTLegs.Cursor = System.Windows.Forms.Cursors.Hand
        Me.TXTLegs.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTLegs.ForeColor = System.Drawing.Color.White
        Me.TXTLegs.Location = New System.Drawing.Point(145, 122)
        Me.TXTLegs.Name = "TXTLegs"
        Me.TXTLegs.ReadOnly = True
        Me.TXTLegs.Size = New System.Drawing.Size(329, 23)
        Me.TXTLegs.TabIndex = 33
        '
        'TXTChest
        '
        Me.TXTChest.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TXTChest.BackColor = System.Drawing.Color.Maroon
        Me.TXTChest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TXTChest.Cursor = System.Windows.Forms.Cursors.Hand
        Me.TXTChest.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTChest.ForeColor = System.Drawing.Color.White
        Me.TXTChest.Location = New System.Drawing.Point(145, 94)
        Me.TXTChest.Name = "TXTChest"
        Me.TXTChest.ReadOnly = True
        Me.TXTChest.Size = New System.Drawing.Size(329, 23)
        Me.TXTChest.TabIndex = 32
        '
        'TXTShoulders
        '
        Me.TXTShoulders.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TXTShoulders.BackColor = System.Drawing.Color.Maroon
        Me.TXTShoulders.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TXTShoulders.Cursor = System.Windows.Forms.Cursors.Hand
        Me.TXTShoulders.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTShoulders.ForeColor = System.Drawing.Color.White
        Me.TXTShoulders.Location = New System.Drawing.Point(145, 66)
        Me.TXTShoulders.Name = "TXTShoulders"
        Me.TXTShoulders.ReadOnly = True
        Me.TXTShoulders.Size = New System.Drawing.Size(329, 23)
        Me.TXTShoulders.TabIndex = 31
        '
        'TXTHead
        '
        Me.TXTHead.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TXTHead.BackColor = System.Drawing.Color.Maroon
        Me.TXTHead.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TXTHead.Cursor = System.Windows.Forms.Cursors.Hand
        Me.TXTHead.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTHead.ForeColor = System.Drawing.Color.White
        Me.TXTHead.Location = New System.Drawing.Point(145, 38)
        Me.TXTHead.Name = "TXTHead"
        Me.TXTHead.ReadOnly = True
        Me.TXTHead.Size = New System.Drawing.Size(329, 23)
        Me.TXTHead.TabIndex = 30
        '
        'LBLmnuOffhand
        '
        Me.LBLmnuOffhand.AutoSize = True
        Me.LBLmnuOffhand.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLmnuOffhand.ForeColor = System.Drawing.Color.White
        Me.LBLmnuOffhand.Location = New System.Drawing.Point(6, 208)
        Me.LBLmnuOffhand.Name = "LBLmnuOffhand"
        Me.LBLmnuOffhand.Size = New System.Drawing.Size(74, 16)
        Me.LBLmnuOffhand.TabIndex = 29
        Me.LBLmnuOffhand.Text = "OFF HAND"
        '
        'LBLmnuMainhand
        '
        Me.LBLmnuMainhand.AutoSize = True
        Me.LBLmnuMainhand.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLmnuMainhand.ForeColor = System.Drawing.Color.White
        Me.LBLmnuMainhand.Location = New System.Drawing.Point(6, 180)
        Me.LBLmnuMainhand.Name = "LBLmnuMainhand"
        Me.LBLmnuMainhand.Size = New System.Drawing.Size(81, 16)
        Me.LBLmnuMainhand.TabIndex = 28
        Me.LBLmnuMainhand.Text = "MAIN HAND"
        '
        'LBLmnuBoots
        '
        Me.LBLmnuBoots.AutoSize = True
        Me.LBLmnuBoots.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLmnuBoots.ForeColor = System.Drawing.Color.White
        Me.LBLmnuBoots.Location = New System.Drawing.Point(6, 152)
        Me.LBLmnuBoots.Name = "LBLmnuBoots"
        Me.LBLmnuBoots.Size = New System.Drawing.Size(54, 16)
        Me.LBLmnuBoots.TabIndex = 27
        Me.LBLmnuBoots.Text = "BOOTS"
        '
        'LBLmnuLegs
        '
        Me.LBLmnuLegs.AutoSize = True
        Me.LBLmnuLegs.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLmnuLegs.ForeColor = System.Drawing.Color.White
        Me.LBLmnuLegs.Location = New System.Drawing.Point(6, 124)
        Me.LBLmnuLegs.Name = "LBLmnuLegs"
        Me.LBLmnuLegs.Size = New System.Drawing.Size(43, 16)
        Me.LBLmnuLegs.TabIndex = 26
        Me.LBLmnuLegs.Text = "LEGS"
        '
        'LBLmnuChest
        '
        Me.LBLmnuChest.AutoSize = True
        Me.LBLmnuChest.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLmnuChest.ForeColor = System.Drawing.Color.White
        Me.LBLmnuChest.Location = New System.Drawing.Point(6, 96)
        Me.LBLmnuChest.Name = "LBLmnuChest"
        Me.LBLmnuChest.Size = New System.Drawing.Size(51, 16)
        Me.LBLmnuChest.TabIndex = 25
        Me.LBLmnuChest.Text = "CHEST"
        '
        'LBLmnuShoulders
        '
        Me.LBLmnuShoulders.AutoSize = True
        Me.LBLmnuShoulders.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLmnuShoulders.ForeColor = System.Drawing.Color.White
        Me.LBLmnuShoulders.Location = New System.Drawing.Point(6, 68)
        Me.LBLmnuShoulders.Name = "LBLmnuShoulders"
        Me.LBLmnuShoulders.Size = New System.Drawing.Size(88, 16)
        Me.LBLmnuShoulders.TabIndex = 24
        Me.LBLmnuShoulders.Text = "SHOULDERS"
        '
        'LBLmnuHead
        '
        Me.LBLmnuHead.AutoSize = True
        Me.LBLmnuHead.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLmnuHead.ForeColor = System.Drawing.Color.White
        Me.LBLmnuHead.Location = New System.Drawing.Point(6, 40)
        Me.LBLmnuHead.Name = "LBLmnuHead"
        Me.LBLmnuHead.Size = New System.Drawing.Size(43, 16)
        Me.LBLmnuHead.TabIndex = 23
        Me.LBLmnuHead.Text = "HEAD"
        '
        'LBLmnuEquipment
        '
        Me.LBLmnuEquipment.AutoSize = True
        Me.LBLmnuEquipment.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLmnuEquipment.ForeColor = System.Drawing.Color.White
        Me.LBLmnuEquipment.Location = New System.Drawing.Point(6, 16)
        Me.LBLmnuEquipment.Name = "LBLmnuEquipment"
        Me.LBLmnuEquipment.Size = New System.Drawing.Size(84, 16)
        Me.LBLmnuEquipment.TabIndex = 22
        Me.LBLmnuEquipment.Text = "EQUIPMENT"
        '
        'GRBCharacterInfo
        '
        Me.GRBCharacterInfo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GRBCharacterInfo.Controls.Add(Me.music_player)
        Me.GRBCharacterInfo.Controls.Add(Me.LBLDiv2)
        Me.GRBCharacterInfo.Controls.Add(Me.LBLMaxMP)
        Me.GRBCharacterInfo.Controls.Add(Me.LBLCurrentMP)
        Me.GRBCharacterInfo.Controls.Add(Me.LBLmnuManaPoints)
        Me.GRBCharacterInfo.Controls.Add(Me.LBLExperience)
        Me.GRBCharacterInfo.Controls.Add(Me.LBLmnuExperience)
        Me.GRBCharacterInfo.Controls.Add(Me.LBLDiv)
        Me.GRBCharacterInfo.Controls.Add(Me.LBLMaxHP)
        Me.GRBCharacterInfo.Controls.Add(Me.LBLCurrentHP)
        Me.GRBCharacterInfo.Controls.Add(Me.LBLmnuHitPoints)
        Me.GRBCharacterInfo.Controls.Add(Me.LBLAge)
        Me.GRBCharacterInfo.Controls.Add(Me.LBLmnuAge)
        Me.GRBCharacterInfo.Controls.Add(Me.LBLGender)
        Me.GRBCharacterInfo.Controls.Add(Me.LBLmnuGender)
        Me.GRBCharacterInfo.Controls.Add(Me.PCBAvatar)
        Me.GRBCharacterInfo.Controls.Add(Me.LBLLevel)
        Me.GRBCharacterInfo.Controls.Add(Me.LBLAlignment)
        Me.GRBCharacterInfo.Controls.Add(Me.LBLRace)
        Me.GRBCharacterInfo.Controls.Add(Me.LBLCharacterName)
        Me.GRBCharacterInfo.Controls.Add(Me.LBLmnuAlignment)
        Me.GRBCharacterInfo.Controls.Add(Me.LBLmnuRace)
        Me.GRBCharacterInfo.Controls.Add(Me.LBLmnuLevel)
        Me.GRBCharacterInfo.Controls.Add(Me.LBLmnuCharacterName)
        Me.GRBCharacterInfo.Cursor = System.Windows.Forms.Cursors.Default
        Me.GRBCharacterInfo.Location = New System.Drawing.Point(3, 3)
        Me.GRBCharacterInfo.Name = "GRBCharacterInfo"
        Me.GRBCharacterInfo.Size = New System.Drawing.Size(937, 187)
        Me.GRBCharacterInfo.TabIndex = 0
        Me.GRBCharacterInfo.TabStop = False
        '
        'music_player
        '
        Me.music_player.Enabled = True
        Me.music_player.Location = New System.Drawing.Point(728, 117)
        Me.music_player.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.music_player.Name = "music_player"
        Me.music_player.OcxState = CType(resources.GetObject("music_player.OcxState"), System.Windows.Forms.AxHost.State)
        Me.music_player.Size = New System.Drawing.Size(98, 49)
        Me.music_player.TabIndex = 23
        Me.music_player.Visible = False
        '
        'LBLDiv2
        '
        Me.LBLDiv2.AutoSize = True
        Me.LBLDiv2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLDiv2.ForeColor = System.Drawing.Color.White
        Me.LBLDiv2.Location = New System.Drawing.Point(362, 155)
        Me.LBLDiv2.Name = "LBLDiv2"
        Me.LBLDiv2.Size = New System.Drawing.Size(12, 16)
        Me.LBLDiv2.TabIndex = 22
        Me.LBLDiv2.Text = "/"
        '
        'LBLMaxMP
        '
        Me.LBLMaxMP.AutoSize = True
        Me.LBLMaxMP.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLMaxMP.ForeColor = System.Drawing.Color.White
        Me.LBLMaxMP.Location = New System.Drawing.Point(380, 155)
        Me.LBLMaxMP.Name = "LBLMaxMP"
        Me.LBLMaxMP.Size = New System.Drawing.Size(29, 16)
        Me.LBLMaxMP.TabIndex = 21
        Me.LBLMaxMP.Text = "100"
        '
        'LBLCurrentMP
        '
        Me.LBLCurrentMP.AutoSize = True
        Me.LBLCurrentMP.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLCurrentMP.ForeColor = System.Drawing.Color.White
        Me.LBLCurrentMP.Location = New System.Drawing.Point(328, 155)
        Me.LBLCurrentMP.Name = "LBLCurrentMP"
        Me.LBLCurrentMP.Size = New System.Drawing.Size(29, 16)
        Me.LBLCurrentMP.TabIndex = 20
        Me.LBLCurrentMP.Text = "100"
        '
        'LBLmnuManaPoints
        '
        Me.LBLmnuManaPoints.AutoSize = True
        Me.LBLmnuManaPoints.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLmnuManaPoints.ForeColor = System.Drawing.Color.White
        Me.LBLmnuManaPoints.Location = New System.Drawing.Point(181, 155)
        Me.LBLmnuManaPoints.Name = "LBLmnuManaPoints"
        Me.LBLmnuManaPoints.Size = New System.Drawing.Size(99, 16)
        Me.LBLmnuManaPoints.TabIndex = 19
        Me.LBLmnuManaPoints.Text = "MANA POINTS"
        '
        'LBLExperience
        '
        Me.LBLExperience.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LBLExperience.AutoSize = True
        Me.LBLExperience.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLExperience.ForeColor = System.Drawing.Color.White
        Me.LBLExperience.Location = New System.Drawing.Point(899, 27)
        Me.LBLExperience.Name = "LBLExperience"
        Me.LBLExperience.Size = New System.Drawing.Size(15, 16)
        Me.LBLExperience.TabIndex = 18
        Me.LBLExperience.Text = "0"
        '
        'LBLmnuExperience
        '
        Me.LBLmnuExperience.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LBLmnuExperience.AutoSize = True
        Me.LBLmnuExperience.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLmnuExperience.ForeColor = System.Drawing.Color.White
        Me.LBLmnuExperience.Location = New System.Drawing.Point(752, 27)
        Me.LBLmnuExperience.Name = "LBLmnuExperience"
        Me.LBLmnuExperience.Size = New System.Drawing.Size(89, 16)
        Me.LBLmnuExperience.TabIndex = 17
        Me.LBLmnuExperience.Text = "EXPERIENCE"
        '
        'LBLDiv
        '
        Me.LBLDiv.AutoSize = True
        Me.LBLDiv.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLDiv.ForeColor = System.Drawing.Color.White
        Me.LBLDiv.Location = New System.Drawing.Point(362, 137)
        Me.LBLDiv.Name = "LBLDiv"
        Me.LBLDiv.Size = New System.Drawing.Size(12, 16)
        Me.LBLDiv.TabIndex = 16
        Me.LBLDiv.Text = "/"
        '
        'LBLMaxHP
        '
        Me.LBLMaxHP.AutoSize = True
        Me.LBLMaxHP.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLMaxHP.ForeColor = System.Drawing.Color.White
        Me.LBLMaxHP.Location = New System.Drawing.Point(380, 137)
        Me.LBLMaxHP.Name = "LBLMaxHP"
        Me.LBLMaxHP.Size = New System.Drawing.Size(29, 16)
        Me.LBLMaxHP.TabIndex = 15
        Me.LBLMaxHP.Text = "100"
        '
        'LBLCurrentHP
        '
        Me.LBLCurrentHP.AutoSize = True
        Me.LBLCurrentHP.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLCurrentHP.ForeColor = System.Drawing.Color.White
        Me.LBLCurrentHP.Location = New System.Drawing.Point(328, 137)
        Me.LBLCurrentHP.Name = "LBLCurrentHP"
        Me.LBLCurrentHP.Size = New System.Drawing.Size(29, 16)
        Me.LBLCurrentHP.TabIndex = 14
        Me.LBLCurrentHP.Text = "100"
        '
        'LBLmnuHitPoints
        '
        Me.LBLmnuHitPoints.AutoSize = True
        Me.LBLmnuHitPoints.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLmnuHitPoints.ForeColor = System.Drawing.Color.White
        Me.LBLmnuHitPoints.Location = New System.Drawing.Point(181, 137)
        Me.LBLmnuHitPoints.Name = "LBLmnuHitPoints"
        Me.LBLmnuHitPoints.Size = New System.Drawing.Size(82, 16)
        Me.LBLmnuHitPoints.TabIndex = 13
        Me.LBLmnuHitPoints.Text = "HIT POINTS"
        '
        'LBLAge
        '
        Me.LBLAge.AutoSize = True
        Me.LBLAge.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLAge.ForeColor = System.Drawing.Color.White
        Me.LBLAge.Location = New System.Drawing.Point(328, 80)
        Me.LBLAge.Name = "LBLAge"
        Me.LBLAge.Size = New System.Drawing.Size(22, 16)
        Me.LBLAge.TabIndex = 12
        Me.LBLAge.Text = "27"
        '
        'LBLmnuAge
        '
        Me.LBLmnuAge.AutoSize = True
        Me.LBLmnuAge.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLmnuAge.ForeColor = System.Drawing.Color.White
        Me.LBLmnuAge.Location = New System.Drawing.Point(181, 80)
        Me.LBLmnuAge.Name = "LBLmnuAge"
        Me.LBLmnuAge.Size = New System.Drawing.Size(35, 16)
        Me.LBLmnuAge.TabIndex = 11
        Me.LBLmnuAge.Text = "AGE"
        '
        'LBLGender
        '
        Me.LBLGender.AutoSize = True
        Me.LBLGender.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLGender.ForeColor = System.Drawing.Color.White
        Me.LBLGender.Location = New System.Drawing.Point(328, 64)
        Me.LBLGender.Name = "LBLGender"
        Me.LBLGender.Size = New System.Drawing.Size(51, 16)
        Me.LBLGender.TabIndex = 10
        Me.LBLGender.Text = "Female"
        '
        'LBLmnuGender
        '
        Me.LBLmnuGender.AutoSize = True
        Me.LBLmnuGender.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLmnuGender.ForeColor = System.Drawing.Color.White
        Me.LBLmnuGender.Location = New System.Drawing.Point(181, 64)
        Me.LBLmnuGender.Name = "LBLmnuGender"
        Me.LBLmnuGender.Size = New System.Drawing.Size(61, 16)
        Me.LBLmnuGender.TabIndex = 9
        Me.LBLmnuGender.Text = "GENDER"
        '
        'PCBAvatar
        '
        Me.PCBAvatar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PCBAvatar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PCBAvatar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PCBAvatar.Location = New System.Drawing.Point(5, 11)
        Me.PCBAvatar.Name = "PCBAvatar"
        Me.PCBAvatar.Size = New System.Drawing.Size(170, 170)
        Me.PCBAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PCBAvatar.TabIndex = 8
        Me.PCBAvatar.TabStop = False
        '
        'LBLLevel
        '
        Me.LBLLevel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LBLLevel.AutoSize = True
        Me.LBLLevel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLLevel.ForeColor = System.Drawing.Color.White
        Me.LBLLevel.Location = New System.Drawing.Point(899, 11)
        Me.LBLLevel.Name = "LBLLevel"
        Me.LBLLevel.Size = New System.Drawing.Size(15, 16)
        Me.LBLLevel.TabIndex = 7
        Me.LBLLevel.Text = "1"
        '
        'LBLAlignment
        '
        Me.LBLAlignment.AutoSize = True
        Me.LBLAlignment.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLAlignment.ForeColor = System.Drawing.Color.White
        Me.LBLAlignment.Location = New System.Drawing.Point(328, 48)
        Me.LBLAlignment.Name = "LBLAlignment"
        Me.LBLAlignment.Size = New System.Drawing.Size(97, 16)
        Me.LBLAlignment.TabIndex = 6
        Me.LBLAlignment.Text = "Chaotic Neutral"
        '
        'LBLRace
        '
        Me.LBLRace.AutoSize = True
        Me.LBLRace.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLRace.ForeColor = System.Drawing.Color.White
        Me.LBLRace.Location = New System.Drawing.Point(328, 32)
        Me.LBLRace.Name = "LBLRace"
        Me.LBLRace.Size = New System.Drawing.Size(49, 16)
        Me.LBLRace.TabIndex = 5
        Me.LBLRace.Text = "Human"
        '
        'LBLCharacterName
        '
        Me.LBLCharacterName.AutoSize = True
        Me.LBLCharacterName.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLCharacterName.ForeColor = System.Drawing.Color.White
        Me.LBLCharacterName.Location = New System.Drawing.Point(328, 16)
        Me.LBLCharacterName.Name = "LBLCharacterName"
        Me.LBLCharacterName.Size = New System.Drawing.Size(48, 16)
        Me.LBLCharacterName.TabIndex = 4
        Me.LBLCharacterName.Text = "Alysha"
        '
        'LBLmnuAlignment
        '
        Me.LBLmnuAlignment.AutoSize = True
        Me.LBLmnuAlignment.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLmnuAlignment.ForeColor = System.Drawing.Color.White
        Me.LBLmnuAlignment.Location = New System.Drawing.Point(181, 48)
        Me.LBLmnuAlignment.Name = "LBLmnuAlignment"
        Me.LBLmnuAlignment.Size = New System.Drawing.Size(84, 16)
        Me.LBLmnuAlignment.TabIndex = 3
        Me.LBLmnuAlignment.Text = "ALIGNMENT"
        '
        'LBLmnuRace
        '
        Me.LBLmnuRace.AutoSize = True
        Me.LBLmnuRace.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLmnuRace.ForeColor = System.Drawing.Color.White
        Me.LBLmnuRace.Location = New System.Drawing.Point(181, 32)
        Me.LBLmnuRace.Name = "LBLmnuRace"
        Me.LBLmnuRace.Size = New System.Drawing.Size(43, 16)
        Me.LBLmnuRace.TabIndex = 2
        Me.LBLmnuRace.Text = "RACE"
        '
        'LBLmnuLevel
        '
        Me.LBLmnuLevel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LBLmnuLevel.AutoSize = True
        Me.LBLmnuLevel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLmnuLevel.ForeColor = System.Drawing.Color.White
        Me.LBLmnuLevel.Location = New System.Drawing.Point(752, 11)
        Me.LBLmnuLevel.Name = "LBLmnuLevel"
        Me.LBLmnuLevel.Size = New System.Drawing.Size(49, 16)
        Me.LBLmnuLevel.TabIndex = 1
        Me.LBLmnuLevel.Text = "LEVEL"
        '
        'LBLmnuCharacterName
        '
        Me.LBLmnuCharacterName.AutoSize = True
        Me.LBLmnuCharacterName.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLmnuCharacterName.ForeColor = System.Drawing.Color.White
        Me.LBLmnuCharacterName.Location = New System.Drawing.Point(181, 16)
        Me.LBLmnuCharacterName.Name = "LBLmnuCharacterName"
        Me.LBLmnuCharacterName.Size = New System.Drawing.Size(128, 16)
        Me.LBLmnuCharacterName.TabIndex = 0
        Me.LBLmnuCharacterName.Text = "CHARACTER NAME"
        '
        'GRBAttributes
        '
        Me.GRBAttributes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GRBAttributes.Controls.Add(Me.LBLCritChance)
        Me.GRBAttributes.Controls.Add(Me.LBLmnuCritChance)
        Me.GRBAttributes.Controls.Add(Me.LBLHitChance)
        Me.GRBAttributes.Controls.Add(Me.LBLmnuHitChance)
        Me.GRBAttributes.Controls.Add(Me.LBLUnspentAttributePoints)
        Me.GRBAttributes.Controls.Add(Me.LBLmnuUnspentAttributePoints)
        Me.GRBAttributes.Controls.Add(Me.CMDAddWisdom)
        Me.GRBAttributes.Controls.Add(Me.CMDAddIntelligence)
        Me.GRBAttributes.Controls.Add(Me.CMDAddCharisma)
        Me.GRBAttributes.Controls.Add(Me.CMDAddConstitution)
        Me.GRBAttributes.Controls.Add(Me.CMDAddDexterity)
        Me.GRBAttributes.Controls.Add(Me.CMDAddStrength)
        Me.GRBAttributes.Controls.Add(Me.CMDSubtractWisdom)
        Me.GRBAttributes.Controls.Add(Me.CMDSubtractIntelligence)
        Me.GRBAttributes.Controls.Add(Me.CMDSubtractCharisma)
        Me.GRBAttributes.Controls.Add(Me.CMDSubtractConstitution)
        Me.GRBAttributes.Controls.Add(Me.CMDSubtractDexterity)
        Me.GRBAttributes.Controls.Add(Me.CMDSubtractStrength)
        Me.GRBAttributes.Controls.Add(Me.LBLDamage)
        Me.GRBAttributes.Controls.Add(Me.LBLmnuDamage)
        Me.GRBAttributes.Controls.Add(Me.LBLarmorclass)
        Me.GRBAttributes.Controls.Add(Me.LBLmnuArmorClass)
        Me.GRBAttributes.Controls.Add(Me.LBLmnuAttribbute)
        Me.GRBAttributes.Controls.Add(Me.LBLmnuModifier)
        Me.GRBAttributes.Controls.Add(Me.LBLmnuPoints)
        Me.GRBAttributes.Controls.Add(Me.LBLCharismaMod)
        Me.GRBAttributes.Controls.Add(Me.LBLWisdomMod)
        Me.GRBAttributes.Controls.Add(Me.LBLIntelligenceMod)
        Me.GRBAttributes.Controls.Add(Me.LBLConstitutionMod)
        Me.GRBAttributes.Controls.Add(Me.LBLDexterityMod)
        Me.GRBAttributes.Controls.Add(Me.LBLStrengthMod)
        Me.GRBAttributes.Controls.Add(Me.LBLCharisma)
        Me.GRBAttributes.Controls.Add(Me.LBLWisdom)
        Me.GRBAttributes.Controls.Add(Me.LBLIntelligence)
        Me.GRBAttributes.Controls.Add(Me.LBLConstitution)
        Me.GRBAttributes.Controls.Add(Me.LBLDexterity)
        Me.GRBAttributes.Controls.Add(Me.LBLStrength)
        Me.GRBAttributes.Controls.Add(Me.LBLmnuDexterity)
        Me.GRBAttributes.Controls.Add(Me.LBLmnuConstitution)
        Me.GRBAttributes.Controls.Add(Me.LBLmnuIntelligence)
        Me.GRBAttributes.Controls.Add(Me.LBLmnuWisdom)
        Me.GRBAttributes.Controls.Add(Me.LBLmnuCharisma)
        Me.GRBAttributes.Controls.Add(Me.LBLmnuStrength)
        Me.GRBAttributes.Location = New System.Drawing.Point(3, 190)
        Me.GRBAttributes.Name = "GRBAttributes"
        Me.GRBAttributes.Size = New System.Drawing.Size(937, 204)
        Me.GRBAttributes.TabIndex = 8
        Me.GRBAttributes.TabStop = False
        '
        'LBLCritChance
        '
        Me.LBLCritChance.AutoSize = True
        Me.LBLCritChance.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLCritChance.ForeColor = System.Drawing.Color.White
        Me.LBLCritChance.Location = New System.Drawing.Point(452, 97)
        Me.LBLCritChance.Name = "LBLCritChance"
        Me.LBLCritChance.Size = New System.Drawing.Size(27, 16)
        Me.LBLCritChance.TabIndex = 54
        Me.LBLCritChance.Text = "0%"
        '
        'LBLmnuCritChance
        '
        Me.LBLmnuCritChance.AutoSize = True
        Me.LBLmnuCritChance.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLmnuCritChance.ForeColor = System.Drawing.Color.White
        Me.LBLmnuCritChance.Location = New System.Drawing.Point(305, 97)
        Me.LBLmnuCritChance.Name = "LBLmnuCritChance"
        Me.LBLmnuCritChance.Size = New System.Drawing.Size(95, 16)
        Me.LBLmnuCritChance.TabIndex = 53
        Me.LBLmnuCritChance.Text = "CRIT CHANCE"
        '
        'LBLHitChance
        '
        Me.LBLHitChance.AutoSize = True
        Me.LBLHitChance.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLHitChance.ForeColor = System.Drawing.Color.White
        Me.LBLHitChance.Location = New System.Drawing.Point(452, 78)
        Me.LBLHitChance.Name = "LBLHitChance"
        Me.LBLHitChance.Size = New System.Drawing.Size(27, 16)
        Me.LBLHitChance.TabIndex = 52
        Me.LBLHitChance.Text = "0%"
        '
        'LBLmnuHitChance
        '
        Me.LBLmnuHitChance.AutoSize = True
        Me.LBLmnuHitChance.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLmnuHitChance.ForeColor = System.Drawing.Color.White
        Me.LBLmnuHitChance.Location = New System.Drawing.Point(305, 79)
        Me.LBLmnuHitChance.Name = "LBLmnuHitChance"
        Me.LBLmnuHitChance.Size = New System.Drawing.Size(86, 16)
        Me.LBLmnuHitChance.TabIndex = 51
        Me.LBLmnuHitChance.Text = "HIT CHANCE"
        '
        'LBLUnspentAttributePoints
        '
        Me.LBLUnspentAttributePoints.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LBLUnspentAttributePoints.AutoSize = True
        Me.LBLUnspentAttributePoints.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLUnspentAttributePoints.ForeColor = System.Drawing.Color.White
        Me.LBLUnspentAttributePoints.Location = New System.Drawing.Point(712, 16)
        Me.LBLUnspentAttributePoints.Name = "LBLUnspentAttributePoints"
        Me.LBLUnspentAttributePoints.Size = New System.Drawing.Size(15, 16)
        Me.LBLUnspentAttributePoints.TabIndex = 50
        Me.LBLUnspentAttributePoints.Text = "0"
        '
        'LBLmnuUnspentAttributePoints
        '
        Me.LBLmnuUnspentAttributePoints.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LBLmnuUnspentAttributePoints.AutoSize = True
        Me.LBLmnuUnspentAttributePoints.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLmnuUnspentAttributePoints.ForeColor = System.Drawing.Color.White
        Me.LBLmnuUnspentAttributePoints.Location = New System.Drawing.Point(733, 16)
        Me.LBLmnuUnspentAttributePoints.Name = "LBLmnuUnspentAttributePoints"
        Me.LBLmnuUnspentAttributePoints.Size = New System.Drawing.Size(197, 16)
        Me.LBLmnuUnspentAttributePoints.TabIndex = 49
        Me.LBLmnuUnspentAttributePoints.Text = "UNSPENT ATTRIBUTE POINTS"
        '
        'CMDAddWisdom
        '
        Me.CMDAddWisdom.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.CMDAddWisdom.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDAddWisdom.Enabled = False
        Me.CMDAddWisdom.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDAddWisdom.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDAddWisdom.ForeColor = System.Drawing.Color.White
        Me.CMDAddWisdom.Location = New System.Drawing.Point(178, 116)
        Me.CMDAddWisdom.Name = "CMDAddWisdom"
        Me.CMDAddWisdom.Size = New System.Drawing.Size(15, 15)
        Me.CMDAddWisdom.TabIndex = 48
        Me.CMDAddWisdom.Text = "+"
        Me.CMDAddWisdom.UseVisualStyleBackColor = False
        '
        'CMDAddIntelligence
        '
        Me.CMDAddIntelligence.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.CMDAddIntelligence.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDAddIntelligence.Enabled = False
        Me.CMDAddIntelligence.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDAddIntelligence.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDAddIntelligence.ForeColor = System.Drawing.Color.White
        Me.CMDAddIntelligence.Location = New System.Drawing.Point(178, 98)
        Me.CMDAddIntelligence.Name = "CMDAddIntelligence"
        Me.CMDAddIntelligence.Size = New System.Drawing.Size(15, 15)
        Me.CMDAddIntelligence.TabIndex = 46
        Me.CMDAddIntelligence.Text = "+"
        Me.CMDAddIntelligence.UseVisualStyleBackColor = False
        '
        'CMDAddCharisma
        '
        Me.CMDAddCharisma.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.CMDAddCharisma.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDAddCharisma.Enabled = False
        Me.CMDAddCharisma.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDAddCharisma.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDAddCharisma.ForeColor = System.Drawing.Color.White
        Me.CMDAddCharisma.Location = New System.Drawing.Point(178, 134)
        Me.CMDAddCharisma.Name = "CMDAddCharisma"
        Me.CMDAddCharisma.Size = New System.Drawing.Size(15, 15)
        Me.CMDAddCharisma.TabIndex = 47
        Me.CMDAddCharisma.Text = "+"
        Me.CMDAddCharisma.UseVisualStyleBackColor = False
        '
        'CMDAddConstitution
        '
        Me.CMDAddConstitution.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.CMDAddConstitution.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDAddConstitution.Enabled = False
        Me.CMDAddConstitution.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDAddConstitution.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDAddConstitution.ForeColor = System.Drawing.Color.White
        Me.CMDAddConstitution.Location = New System.Drawing.Point(178, 79)
        Me.CMDAddConstitution.Name = "CMDAddConstitution"
        Me.CMDAddConstitution.Size = New System.Drawing.Size(15, 15)
        Me.CMDAddConstitution.TabIndex = 45
        Me.CMDAddConstitution.Text = "+"
        Me.CMDAddConstitution.UseVisualStyleBackColor = False
        '
        'CMDAddDexterity
        '
        Me.CMDAddDexterity.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.CMDAddDexterity.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDAddDexterity.Enabled = False
        Me.CMDAddDexterity.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDAddDexterity.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDAddDexterity.ForeColor = System.Drawing.Color.White
        Me.CMDAddDexterity.Location = New System.Drawing.Point(178, 61)
        Me.CMDAddDexterity.Name = "CMDAddDexterity"
        Me.CMDAddDexterity.Size = New System.Drawing.Size(15, 15)
        Me.CMDAddDexterity.TabIndex = 44
        Me.CMDAddDexterity.Text = "+"
        Me.CMDAddDexterity.UseVisualStyleBackColor = False
        '
        'CMDAddStrength
        '
        Me.CMDAddStrength.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.CMDAddStrength.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDAddStrength.Enabled = False
        Me.CMDAddStrength.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDAddStrength.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDAddStrength.ForeColor = System.Drawing.Color.White
        Me.CMDAddStrength.Location = New System.Drawing.Point(178, 43)
        Me.CMDAddStrength.Name = "CMDAddStrength"
        Me.CMDAddStrength.Size = New System.Drawing.Size(15, 15)
        Me.CMDAddStrength.TabIndex = 43
        Me.CMDAddStrength.Text = "+"
        Me.CMDAddStrength.UseVisualStyleBackColor = False
        '
        'CMDSubtractWisdom
        '
        Me.CMDSubtractWisdom.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.CMDSubtractWisdom.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDSubtractWisdom.Enabled = False
        Me.CMDSubtractWisdom.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDSubtractWisdom.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDSubtractWisdom.ForeColor = System.Drawing.Color.White
        Me.CMDSubtractWisdom.Location = New System.Drawing.Point(135, 116)
        Me.CMDSubtractWisdom.Name = "CMDSubtractWisdom"
        Me.CMDSubtractWisdom.Size = New System.Drawing.Size(15, 15)
        Me.CMDSubtractWisdom.TabIndex = 42
        Me.CMDSubtractWisdom.Text = "-"
        Me.CMDSubtractWisdom.UseVisualStyleBackColor = False
        '
        'CMDSubtractIntelligence
        '
        Me.CMDSubtractIntelligence.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.CMDSubtractIntelligence.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDSubtractIntelligence.Enabled = False
        Me.CMDSubtractIntelligence.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDSubtractIntelligence.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDSubtractIntelligence.ForeColor = System.Drawing.Color.White
        Me.CMDSubtractIntelligence.Location = New System.Drawing.Point(135, 98)
        Me.CMDSubtractIntelligence.Name = "CMDSubtractIntelligence"
        Me.CMDSubtractIntelligence.Size = New System.Drawing.Size(15, 15)
        Me.CMDSubtractIntelligence.TabIndex = 41
        Me.CMDSubtractIntelligence.Text = "-"
        Me.CMDSubtractIntelligence.UseVisualStyleBackColor = False
        '
        'CMDSubtractCharisma
        '
        Me.CMDSubtractCharisma.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.CMDSubtractCharisma.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDSubtractCharisma.Enabled = False
        Me.CMDSubtractCharisma.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDSubtractCharisma.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDSubtractCharisma.ForeColor = System.Drawing.Color.White
        Me.CMDSubtractCharisma.Location = New System.Drawing.Point(135, 134)
        Me.CMDSubtractCharisma.Name = "CMDSubtractCharisma"
        Me.CMDSubtractCharisma.Size = New System.Drawing.Size(15, 15)
        Me.CMDSubtractCharisma.TabIndex = 41
        Me.CMDSubtractCharisma.Text = "-"
        Me.CMDSubtractCharisma.UseVisualStyleBackColor = False
        '
        'CMDSubtractConstitution
        '
        Me.CMDSubtractConstitution.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.CMDSubtractConstitution.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDSubtractConstitution.Enabled = False
        Me.CMDSubtractConstitution.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDSubtractConstitution.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDSubtractConstitution.ForeColor = System.Drawing.Color.White
        Me.CMDSubtractConstitution.Location = New System.Drawing.Point(135, 79)
        Me.CMDSubtractConstitution.Name = "CMDSubtractConstitution"
        Me.CMDSubtractConstitution.Size = New System.Drawing.Size(15, 15)
        Me.CMDSubtractConstitution.TabIndex = 40
        Me.CMDSubtractConstitution.Text = "-"
        Me.CMDSubtractConstitution.UseVisualStyleBackColor = False
        '
        'CMDSubtractDexterity
        '
        Me.CMDSubtractDexterity.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.CMDSubtractDexterity.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDSubtractDexterity.Enabled = False
        Me.CMDSubtractDexterity.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDSubtractDexterity.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDSubtractDexterity.ForeColor = System.Drawing.Color.White
        Me.CMDSubtractDexterity.Location = New System.Drawing.Point(135, 61)
        Me.CMDSubtractDexterity.Name = "CMDSubtractDexterity"
        Me.CMDSubtractDexterity.Size = New System.Drawing.Size(15, 15)
        Me.CMDSubtractDexterity.TabIndex = 39
        Me.CMDSubtractDexterity.Text = "-"
        Me.CMDSubtractDexterity.UseVisualStyleBackColor = False
        '
        'CMDSubtractStrength
        '
        Me.CMDSubtractStrength.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.CMDSubtractStrength.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDSubtractStrength.Enabled = False
        Me.CMDSubtractStrength.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDSubtractStrength.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDSubtractStrength.ForeColor = System.Drawing.Color.White
        Me.CMDSubtractStrength.Location = New System.Drawing.Point(135, 43)
        Me.CMDSubtractStrength.Name = "CMDSubtractStrength"
        Me.CMDSubtractStrength.Size = New System.Drawing.Size(15, 15)
        Me.CMDSubtractStrength.TabIndex = 38
        Me.CMDSubtractStrength.Text = "-"
        Me.CMDSubtractStrength.UseVisualStyleBackColor = False
        '
        'LBLDamage
        '
        Me.LBLDamage.AutoSize = True
        Me.LBLDamage.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLDamage.ForeColor = System.Drawing.Color.White
        Me.LBLDamage.Location = New System.Drawing.Point(452, 61)
        Me.LBLDamage.Name = "LBLDamage"
        Me.LBLDamage.Size = New System.Drawing.Size(15, 16)
        Me.LBLDamage.TabIndex = 26
        Me.LBLDamage.Text = "0"
        '
        'LBLmnuDamage
        '
        Me.LBLmnuDamage.AutoSize = True
        Me.LBLmnuDamage.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLmnuDamage.ForeColor = System.Drawing.Color.White
        Me.LBLmnuDamage.Location = New System.Drawing.Point(305, 61)
        Me.LBLmnuDamage.Name = "LBLmnuDamage"
        Me.LBLmnuDamage.Size = New System.Drawing.Size(64, 16)
        Me.LBLmnuDamage.TabIndex = 25
        Me.LBLmnuDamage.Text = "DAMAGE"
        '
        'LBLarmorclass
        '
        Me.LBLarmorclass.AutoSize = True
        Me.LBLarmorclass.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLarmorclass.ForeColor = System.Drawing.Color.White
        Me.LBLarmorclass.Location = New System.Drawing.Point(452, 42)
        Me.LBLarmorclass.Name = "LBLarmorclass"
        Me.LBLarmorclass.Size = New System.Drawing.Size(22, 16)
        Me.LBLarmorclass.TabIndex = 24
        Me.LBLarmorclass.Text = "10"
        '
        'LBLmnuArmorClass
        '
        Me.LBLmnuArmorClass.AutoSize = True
        Me.LBLmnuArmorClass.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLmnuArmorClass.ForeColor = System.Drawing.Color.White
        Me.LBLmnuArmorClass.Location = New System.Drawing.Point(305, 43)
        Me.LBLmnuArmorClass.Name = "LBLmnuArmorClass"
        Me.LBLmnuArmorClass.Size = New System.Drawing.Size(104, 16)
        Me.LBLmnuArmorClass.TabIndex = 23
        Me.LBLmnuArmorClass.Text = "ARMOR CLASS"
        '
        'LBLmnuAttribbute
        '
        Me.LBLmnuAttribbute.AutoSize = True
        Me.LBLmnuAttribbute.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLmnuAttribbute.ForeColor = System.Drawing.Color.White
        Me.LBLmnuAttribbute.Location = New System.Drawing.Point(6, 16)
        Me.LBLmnuAttribbute.Name = "LBLmnuAttribbute"
        Me.LBLmnuAttribbute.Size = New System.Drawing.Size(79, 16)
        Me.LBLmnuAttribbute.TabIndex = 22
        Me.LBLmnuAttribbute.Text = "ATTRIBUTE"
        '
        'LBLmnuModifier
        '
        Me.LBLmnuModifier.AutoSize = True
        Me.LBLmnuModifier.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLmnuModifier.ForeColor = System.Drawing.Color.White
        Me.LBLmnuModifier.Location = New System.Drawing.Point(202, 16)
        Me.LBLmnuModifier.Name = "LBLmnuModifier"
        Me.LBLmnuModifier.Size = New System.Drawing.Size(71, 16)
        Me.LBLmnuModifier.TabIndex = 21
        Me.LBLmnuModifier.Text = "MODIFIER"
        '
        'LBLmnuPoints
        '
        Me.LBLmnuPoints.AutoSize = True
        Me.LBLmnuPoints.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLmnuPoints.ForeColor = System.Drawing.Color.White
        Me.LBLmnuPoints.Location = New System.Drawing.Point(132, 16)
        Me.LBLmnuPoints.Name = "LBLmnuPoints"
        Me.LBLmnuPoints.Size = New System.Drawing.Size(57, 16)
        Me.LBLmnuPoints.TabIndex = 20
        Me.LBLmnuPoints.Text = "POINTS"
        '
        'LBLCharismaMod
        '
        Me.LBLCharismaMod.AutoSize = True
        Me.LBLCharismaMod.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLCharismaMod.ForeColor = System.Drawing.Color.White
        Me.LBLCharismaMod.Location = New System.Drawing.Point(230, 133)
        Me.LBLCharismaMod.Name = "LBLCharismaMod"
        Me.LBLCharismaMod.Size = New System.Drawing.Size(15, 16)
        Me.LBLCharismaMod.TabIndex = 19
        Me.LBLCharismaMod.Text = "1"
        '
        'LBLWisdomMod
        '
        Me.LBLWisdomMod.AutoSize = True
        Me.LBLWisdomMod.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLWisdomMod.ForeColor = System.Drawing.Color.White
        Me.LBLWisdomMod.Location = New System.Drawing.Point(230, 115)
        Me.LBLWisdomMod.Name = "LBLWisdomMod"
        Me.LBLWisdomMod.Size = New System.Drawing.Size(15, 16)
        Me.LBLWisdomMod.TabIndex = 18
        Me.LBLWisdomMod.Text = "1"
        '
        'LBLIntelligenceMod
        '
        Me.LBLIntelligenceMod.AutoSize = True
        Me.LBLIntelligenceMod.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLIntelligenceMod.ForeColor = System.Drawing.Color.White
        Me.LBLIntelligenceMod.Location = New System.Drawing.Point(230, 97)
        Me.LBLIntelligenceMod.Name = "LBLIntelligenceMod"
        Me.LBLIntelligenceMod.Size = New System.Drawing.Size(15, 16)
        Me.LBLIntelligenceMod.TabIndex = 17
        Me.LBLIntelligenceMod.Text = "1"
        '
        'LBLConstitutionMod
        '
        Me.LBLConstitutionMod.AutoSize = True
        Me.LBLConstitutionMod.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLConstitutionMod.ForeColor = System.Drawing.Color.White
        Me.LBLConstitutionMod.Location = New System.Drawing.Point(230, 78)
        Me.LBLConstitutionMod.Name = "LBLConstitutionMod"
        Me.LBLConstitutionMod.Size = New System.Drawing.Size(15, 16)
        Me.LBLConstitutionMod.TabIndex = 16
        Me.LBLConstitutionMod.Text = "1"
        '
        'LBLDexterityMod
        '
        Me.LBLDexterityMod.AutoSize = True
        Me.LBLDexterityMod.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLDexterityMod.ForeColor = System.Drawing.Color.White
        Me.LBLDexterityMod.Location = New System.Drawing.Point(230, 60)
        Me.LBLDexterityMod.Name = "LBLDexterityMod"
        Me.LBLDexterityMod.Size = New System.Drawing.Size(15, 16)
        Me.LBLDexterityMod.TabIndex = 15
        Me.LBLDexterityMod.Text = "1"
        '
        'LBLStrengthMod
        '
        Me.LBLStrengthMod.AutoSize = True
        Me.LBLStrengthMod.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLStrengthMod.ForeColor = System.Drawing.Color.White
        Me.LBLStrengthMod.Location = New System.Drawing.Point(230, 42)
        Me.LBLStrengthMod.Name = "LBLStrengthMod"
        Me.LBLStrengthMod.Size = New System.Drawing.Size(15, 16)
        Me.LBLStrengthMod.TabIndex = 14
        Me.LBLStrengthMod.Text = "1"
        '
        'LBLCharisma
        '
        Me.LBLCharisma.AutoSize = True
        Me.LBLCharisma.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLCharisma.ForeColor = System.Drawing.Color.White
        Me.LBLCharisma.Location = New System.Drawing.Point(153, 133)
        Me.LBLCharisma.Name = "LBLCharisma"
        Me.LBLCharisma.Size = New System.Drawing.Size(22, 16)
        Me.LBLCharisma.TabIndex = 13
        Me.LBLCharisma.Text = "12"
        '
        'LBLWisdom
        '
        Me.LBLWisdom.AutoSize = True
        Me.LBLWisdom.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLWisdom.ForeColor = System.Drawing.Color.White
        Me.LBLWisdom.Location = New System.Drawing.Point(153, 115)
        Me.LBLWisdom.Name = "LBLWisdom"
        Me.LBLWisdom.Size = New System.Drawing.Size(22, 16)
        Me.LBLWisdom.TabIndex = 12
        Me.LBLWisdom.Text = "12"
        '
        'LBLIntelligence
        '
        Me.LBLIntelligence.AutoSize = True
        Me.LBLIntelligence.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLIntelligence.ForeColor = System.Drawing.Color.White
        Me.LBLIntelligence.Location = New System.Drawing.Point(153, 97)
        Me.LBLIntelligence.Name = "LBLIntelligence"
        Me.LBLIntelligence.Size = New System.Drawing.Size(22, 16)
        Me.LBLIntelligence.TabIndex = 11
        Me.LBLIntelligence.Text = "12"
        '
        'LBLConstitution
        '
        Me.LBLConstitution.AutoSize = True
        Me.LBLConstitution.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLConstitution.ForeColor = System.Drawing.Color.White
        Me.LBLConstitution.Location = New System.Drawing.Point(153, 78)
        Me.LBLConstitution.Name = "LBLConstitution"
        Me.LBLConstitution.Size = New System.Drawing.Size(22, 16)
        Me.LBLConstitution.TabIndex = 10
        Me.LBLConstitution.Text = "12"
        '
        'LBLDexterity
        '
        Me.LBLDexterity.AutoSize = True
        Me.LBLDexterity.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLDexterity.ForeColor = System.Drawing.Color.White
        Me.LBLDexterity.Location = New System.Drawing.Point(153, 60)
        Me.LBLDexterity.Name = "LBLDexterity"
        Me.LBLDexterity.Size = New System.Drawing.Size(22, 16)
        Me.LBLDexterity.TabIndex = 9
        Me.LBLDexterity.Text = "12"
        '
        'LBLStrength
        '
        Me.LBLStrength.AutoSize = True
        Me.LBLStrength.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLStrength.ForeColor = System.Drawing.Color.White
        Me.LBLStrength.Location = New System.Drawing.Point(153, 42)
        Me.LBLStrength.Name = "LBLStrength"
        Me.LBLStrength.Size = New System.Drawing.Size(22, 16)
        Me.LBLStrength.TabIndex = 8
        Me.LBLStrength.Text = "12"
        '
        'LBLmnuDexterity
        '
        Me.LBLmnuDexterity.AutoSize = True
        Me.LBLmnuDexterity.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLmnuDexterity.ForeColor = System.Drawing.Color.White
        Me.LBLmnuDexterity.Location = New System.Drawing.Point(6, 61)
        Me.LBLmnuDexterity.Name = "LBLmnuDexterity"
        Me.LBLmnuDexterity.Size = New System.Drawing.Size(79, 16)
        Me.LBLmnuDexterity.TabIndex = 6
        Me.LBLmnuDexterity.Text = "DEXTERITY"
        '
        'LBLmnuConstitution
        '
        Me.LBLmnuConstitution.AutoSize = True
        Me.LBLmnuConstitution.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLmnuConstitution.ForeColor = System.Drawing.Color.White
        Me.LBLmnuConstitution.Location = New System.Drawing.Point(6, 79)
        Me.LBLmnuConstitution.Name = "LBLmnuConstitution"
        Me.LBLmnuConstitution.Size = New System.Drawing.Size(105, 16)
        Me.LBLmnuConstitution.TabIndex = 5
        Me.LBLmnuConstitution.Text = "CONSTITUTION"
        '
        'LBLmnuIntelligence
        '
        Me.LBLmnuIntelligence.AutoSize = True
        Me.LBLmnuIntelligence.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLmnuIntelligence.ForeColor = System.Drawing.Color.White
        Me.LBLmnuIntelligence.Location = New System.Drawing.Point(6, 97)
        Me.LBLmnuIntelligence.Name = "LBLmnuIntelligence"
        Me.LBLmnuIntelligence.Size = New System.Drawing.Size(101, 16)
        Me.LBLmnuIntelligence.TabIndex = 4
        Me.LBLmnuIntelligence.Text = "INTELLIGENCE"
        '
        'LBLmnuWisdom
        '
        Me.LBLmnuWisdom.AutoSize = True
        Me.LBLmnuWisdom.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLmnuWisdom.ForeColor = System.Drawing.Color.White
        Me.LBLmnuWisdom.Location = New System.Drawing.Point(6, 115)
        Me.LBLmnuWisdom.Name = "LBLmnuWisdom"
        Me.LBLmnuWisdom.Size = New System.Drawing.Size(64, 16)
        Me.LBLmnuWisdom.TabIndex = 3
        Me.LBLmnuWisdom.Text = "WISDOM"
        '
        'LBLmnuCharisma
        '
        Me.LBLmnuCharisma.AutoSize = True
        Me.LBLmnuCharisma.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLmnuCharisma.ForeColor = System.Drawing.Color.White
        Me.LBLmnuCharisma.Location = New System.Drawing.Point(6, 133)
        Me.LBLmnuCharisma.Name = "LBLmnuCharisma"
        Me.LBLmnuCharisma.Size = New System.Drawing.Size(77, 16)
        Me.LBLmnuCharisma.TabIndex = 2
        Me.LBLmnuCharisma.Text = "CHARISMA"
        '
        'LBLmnuStrength
        '
        Me.LBLmnuStrength.AutoSize = True
        Me.LBLmnuStrength.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLmnuStrength.ForeColor = System.Drawing.Color.White
        Me.LBLmnuStrength.Location = New System.Drawing.Point(6, 43)
        Me.LBLmnuStrength.Name = "LBLmnuStrength"
        Me.LBLmnuStrength.Size = New System.Drawing.Size(78, 16)
        Me.LBLmnuStrength.TabIndex = 1
        Me.LBLmnuStrength.Text = "STRENGTH"
        '
        'GRBInventory
        '
        Me.GRBInventory.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GRBInventory.Controls.Add(Me.GRBItemInfo)
        Me.GRBInventory.Controls.Add(Me.PCBGold)
        Me.GRBInventory.Controls.Add(Me.CMDTrash)
        Me.GRBInventory.Controls.Add(Me.LBLGold)
        Me.GRBInventory.Controls.Add(Me.CMDEquip)
        Me.GRBInventory.Controls.Add(Me.LBLmnuInventory)
        Me.GRBInventory.Controls.Add(Me.LSBInventory)
        Me.GRBInventory.Location = New System.Drawing.Point(3, 639)
        Me.GRBInventory.Name = "GRBInventory"
        Me.GRBInventory.Size = New System.Drawing.Size(937, 373)
        Me.GRBInventory.TabIndex = 24
        Me.GRBInventory.TabStop = False
        '
        'GRBItemInfo
        '
        Me.GRBItemInfo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GRBItemInfo.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GRBItemInfo.Controls.Add(Me.LBLEquipmentExtraCritChance)
        Me.GRBItemInfo.Controls.Add(Me.LBLEquipmentExtraHitChance)
        Me.GRBItemInfo.Controls.Add(Me.LBLEquipmentExtraMana)
        Me.GRBItemInfo.Controls.Add(Me.LBLEquipmentExtraHealth)
        Me.GRBItemInfo.Controls.Add(Me.LBLEquipmentType)
        Me.GRBItemInfo.Controls.Add(Me.PCBSelecteditem)
        Me.GRBItemInfo.Controls.Add(Me.PCBmnuEquipmentValue)
        Me.GRBItemInfo.Controls.Add(Me.LBLEquipmentValue)
        Me.GRBItemInfo.Controls.Add(Me.LBLEquipmentDamage)
        Me.GRBItemInfo.Controls.Add(Me.LBLmnuEquipmentDamage)
        Me.GRBItemInfo.Controls.Add(Me.LBLEquipmentDescription)
        Me.GRBItemInfo.Controls.Add(Me.LBLEquipmentAC)
        Me.GRBItemInfo.Controls.Add(Me.LBLmnuEquipmentAC)
        Me.GRBItemInfo.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRBItemInfo.ForeColor = System.Drawing.Color.White
        Me.GRBItemInfo.Location = New System.Drawing.Point(688, 46)
        Me.GRBItemInfo.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GRBItemInfo.Name = "GRBItemInfo"
        Me.GRBItemInfo.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GRBItemInfo.Size = New System.Drawing.Size(236, 291)
        Me.GRBItemInfo.TabIndex = 56
        Me.GRBItemInfo.TabStop = False
        Me.GRBItemInfo.Text = "GRBItemInfo"
        Me.GRBItemInfo.Visible = False
        '
        'LBLEquipmentExtraMana
        '
        Me.LBLEquipmentExtraMana.AutoSize = True
        Me.LBLEquipmentExtraMana.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLEquipmentExtraMana.ForeColor = System.Drawing.Color.Green
        Me.LBLEquipmentExtraMana.Location = New System.Drawing.Point(7, 123)
        Me.LBLEquipmentExtraMana.Name = "LBLEquipmentExtraMana"
        Me.LBLEquipmentExtraMana.Size = New System.Drawing.Size(17, 18)
        Me.LBLEquipmentExtraMana.TabIndex = 59
        Me.LBLEquipmentExtraMana.Text = "0"
        '
        'LBLEquipmentExtraHealth
        '
        Me.LBLEquipmentExtraHealth.AutoSize = True
        Me.LBLEquipmentExtraHealth.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLEquipmentExtraHealth.ForeColor = System.Drawing.Color.Green
        Me.LBLEquipmentExtraHealth.Location = New System.Drawing.Point(7, 95)
        Me.LBLEquipmentExtraHealth.Name = "LBLEquipmentExtraHealth"
        Me.LBLEquipmentExtraHealth.Size = New System.Drawing.Size(17, 18)
        Me.LBLEquipmentExtraHealth.TabIndex = 58
        Me.LBLEquipmentExtraHealth.Text = "0"
        '
        'LBLEquipmentType
        '
        Me.LBLEquipmentType.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLEquipmentType.ForeColor = System.Drawing.Color.White
        Me.LBLEquipmentType.Location = New System.Drawing.Point(86, 80)
        Me.LBLEquipmentType.Name = "LBLEquipmentType"
        Me.LBLEquipmentType.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.LBLEquipmentType.Size = New System.Drawing.Size(142, 19)
        Me.LBLEquipmentType.TabIndex = 43
        Me.LBLEquipmentType.Text = "0"
        '
        'PCBSelecteditem
        '
        Me.PCBSelecteditem.Location = New System.Drawing.Point(170, 18)
        Me.PCBSelecteditem.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.PCBSelecteditem.Name = "PCBSelecteditem"
        Me.PCBSelecteditem.Size = New System.Drawing.Size(56, 61)
        Me.PCBSelecteditem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PCBSelecteditem.TabIndex = 54
        Me.PCBSelecteditem.TabStop = False
        '
        'PCBmnuEquipmentValue
        '
        Me.PCBmnuEquipmentValue.Image = CType(resources.GetObject("PCBmnuEquipmentValue.Image"), System.Drawing.Image)
        Me.PCBmnuEquipmentValue.Location = New System.Drawing.Point(8, 266)
        Me.PCBmnuEquipmentValue.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.PCBmnuEquipmentValue.Name = "PCBmnuEquipmentValue"
        Me.PCBmnuEquipmentValue.Size = New System.Drawing.Size(15, 16)
        Me.PCBmnuEquipmentValue.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PCBmnuEquipmentValue.TabIndex = 55
        Me.PCBmnuEquipmentValue.TabStop = False
        '
        'LBLEquipmentValue
        '
        Me.LBLEquipmentValue.AutoSize = True
        Me.LBLEquipmentValue.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLEquipmentValue.ForeColor = System.Drawing.Color.White
        Me.LBLEquipmentValue.Location = New System.Drawing.Point(28, 266)
        Me.LBLEquipmentValue.Name = "LBLEquipmentValue"
        Me.LBLEquipmentValue.Size = New System.Drawing.Size(16, 16)
        Me.LBLEquipmentValue.TabIndex = 53
        Me.LBLEquipmentValue.Text = "0"
        '
        'LBLEquipmentDamage
        '
        Me.LBLEquipmentDamage.AutoSize = True
        Me.LBLEquipmentDamage.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLEquipmentDamage.ForeColor = System.Drawing.Color.White
        Me.LBLEquipmentDamage.Location = New System.Drawing.Point(85, 65)
        Me.LBLEquipmentDamage.Name = "LBLEquipmentDamage"
        Me.LBLEquipmentDamage.Size = New System.Drawing.Size(17, 18)
        Me.LBLEquipmentDamage.TabIndex = 51
        Me.LBLEquipmentDamage.Text = "0"
        '
        'LBLmnuEquipmentDamage
        '
        Me.LBLmnuEquipmentDamage.AutoSize = True
        Me.LBLmnuEquipmentDamage.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLmnuEquipmentDamage.ForeColor = System.Drawing.Color.White
        Me.LBLmnuEquipmentDamage.Location = New System.Drawing.Point(6, 65)
        Me.LBLmnuEquipmentDamage.Name = "LBLmnuEquipmentDamage"
        Me.LBLmnuEquipmentDamage.Size = New System.Drawing.Size(72, 19)
        Me.LBLmnuEquipmentDamage.TabIndex = 50
        Me.LBLmnuEquipmentDamage.Text = "Damage"
        '
        'LBLEquipmentDescription
        '
        Me.LBLEquipmentDescription.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLEquipmentDescription.ForeColor = System.Drawing.Color.Coral
        Me.LBLEquipmentDescription.Location = New System.Drawing.Point(7, 209)
        Me.LBLEquipmentDescription.Name = "LBLEquipmentDescription"
        Me.LBLEquipmentDescription.Size = New System.Drawing.Size(225, 50)
        Me.LBLEquipmentDescription.TabIndex = 45
        Me.LBLEquipmentDescription.Text = "0"
        '
        'LBLEquipmentAC
        '
        Me.LBLEquipmentAC.AutoSize = True
        Me.LBLEquipmentAC.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLEquipmentAC.ForeColor = System.Drawing.Color.White
        Me.LBLEquipmentAC.Location = New System.Drawing.Point(85, 41)
        Me.LBLEquipmentAC.Name = "LBLEquipmentAC"
        Me.LBLEquipmentAC.Size = New System.Drawing.Size(17, 18)
        Me.LBLEquipmentAC.TabIndex = 49
        Me.LBLEquipmentAC.Text = "0"
        '
        'LBLmnuEquipmentAC
        '
        Me.LBLmnuEquipmentAC.AutoSize = True
        Me.LBLmnuEquipmentAC.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLmnuEquipmentAC.ForeColor = System.Drawing.Color.White
        Me.LBLmnuEquipmentAC.Location = New System.Drawing.Point(6, 41)
        Me.LBLmnuEquipmentAC.Name = "LBLmnuEquipmentAC"
        Me.LBLmnuEquipmentAC.Size = New System.Drawing.Size(32, 19)
        Me.LBLmnuEquipmentAC.TabIndex = 48
        Me.LBLmnuEquipmentAC.Text = "AC"
        '
        'PCBGold
        '
        Me.PCBGold.Image = CType(resources.GetObject("PCBGold.Image"), System.Drawing.Image)
        Me.PCBGold.Location = New System.Drawing.Point(9, 338)
        Me.PCBGold.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.PCBGold.Name = "PCBGold"
        Me.PCBGold.Size = New System.Drawing.Size(30, 32)
        Me.PCBGold.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PCBGold.TabIndex = 28
        Me.PCBGold.TabStop = False
        '
        'CMDTrash
        '
        Me.CMDTrash.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CMDTrash.BackColor = System.Drawing.Color.Maroon
        Me.CMDTrash.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDTrash.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDTrash.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDTrash.ForeColor = System.Drawing.Color.White
        Me.CMDTrash.Location = New System.Drawing.Point(431, 10)
        Me.CMDTrash.Name = "CMDTrash"
        Me.CMDTrash.Size = New System.Drawing.Size(123, 33)
        Me.CMDTrash.TabIndex = 27
        Me.CMDTrash.Text = "TRASH"
        Me.CMDTrash.UseVisualStyleBackColor = False
        '
        'LBLGold
        '
        Me.LBLGold.AutoSize = True
        Me.LBLGold.Font = New System.Drawing.Font("Arial", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLGold.ForeColor = System.Drawing.Color.White
        Me.LBLGold.Location = New System.Drawing.Point(38, 338)
        Me.LBLGold.Name = "LBLGold"
        Me.LBLGold.Size = New System.Drawing.Size(30, 32)
        Me.LBLGold.TabIndex = 26
        Me.LBLGold.Text = "0"
        '
        'CMDEquip
        '
        Me.CMDEquip.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CMDEquip.BackColor = System.Drawing.Color.Maroon
        Me.CMDEquip.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDEquip.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDEquip.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDEquip.ForeColor = System.Drawing.Color.White
        Me.CMDEquip.Location = New System.Drawing.Point(560, 10)
        Me.CMDEquip.Name = "CMDEquip"
        Me.CMDEquip.Size = New System.Drawing.Size(123, 33)
        Me.CMDEquip.TabIndex = 24
        Me.CMDEquip.Text = "EQUIP"
        Me.CMDEquip.UseVisualStyleBackColor = False
        '
        'LSBInventory
        '
        Me.LSBInventory.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LSBInventory.BackColor = System.Drawing.Color.Maroon
        Me.LSBInventory.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LSBInventory.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LSBInventory.ForeColor = System.Drawing.Color.White
        Me.LSBInventory.FormattingEnabled = True
        Me.LSBInventory.ItemHeight = 18
        Me.LSBInventory.Location = New System.Drawing.Point(9, 45)
        Me.LSBInventory.Name = "LSBInventory"
        Me.LSBInventory.Size = New System.Drawing.Size(675, 292)
        Me.LSBInventory.TabIndex = 23
        '
        'LBLmnuInventory
        '
        Me.LBLmnuInventory.AutoSize = True
        Me.LBLmnuInventory.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLmnuInventory.ForeColor = System.Drawing.Color.White
        Me.LBLmnuInventory.Location = New System.Drawing.Point(6, 16)
        Me.LBLmnuInventory.Name = "LBLmnuInventory"
        Me.LBLmnuInventory.Size = New System.Drawing.Size(82, 16)
        Me.LBLmnuInventory.TabIndex = 22
        Me.LBLmnuInventory.Text = "INVENTORY"
        '
        'PNLFountain
        '
        Me.PNLFountain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PNLFountain.AutoScroll = True
        Me.PNLFountain.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.PNLFountain.Controls.Add(Me.LBLfountainMnuGold)
        Me.PNLFountain.Controls.Add(Me.NMCGoldDonation)
        Me.PNLFountain.Controls.Add(Me.LBLfountainMnuGoldQuestion)
        Me.PNLFountain.Controls.Add(Me.PCBWishingWell)
        Me.PNLFountain.Location = New System.Drawing.Point(12, 45)
        Me.PNLFountain.Name = "PNLFountain"
        Me.PNLFountain.Size = New System.Drawing.Size(960, 575)
        Me.PNLFountain.TabIndex = 2
        Me.PNLFountain.Visible = False
        '
        'LBLfountainMnuGold
        '
        Me.LBLfountainMnuGold.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.LBLfountainMnuGold.AutoSize = True
        Me.LBLfountainMnuGold.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLfountainMnuGold.ForeColor = System.Drawing.Color.White
        Me.LBLfountainMnuGold.Location = New System.Drawing.Point(550, 102)
        Me.LBLfountainMnuGold.Name = "LBLfountainMnuGold"
        Me.LBLfountainMnuGold.Size = New System.Drawing.Size(43, 19)
        Me.LBLfountainMnuGold.TabIndex = 12
        Me.LBLfountainMnuGold.Text = "gold"
        '
        'NMCGoldDonation
        '
        Me.NMCGoldDonation.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.NMCGoldDonation.BackColor = System.Drawing.Color.Maroon
        Me.NMCGoldDonation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NMCGoldDonation.Font = New System.Drawing.Font("Arial", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NMCGoldDonation.ForeColor = System.Drawing.Color.White
        Me.NMCGoldDonation.Location = New System.Drawing.Point(445, 98)
        Me.NMCGoldDonation.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.NMCGoldDonation.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.NMCGoldDonation.Name = "NMCGoldDonation"
        Me.NMCGoldDonation.Size = New System.Drawing.Size(89, 29)
        Me.NMCGoldDonation.TabIndex = 11
        Me.NMCGoldDonation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LBLfountainMnuGoldQuestion
        '
        Me.LBLfountainMnuGoldQuestion.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.LBLfountainMnuGoldQuestion.AutoSize = True
        Me.LBLfountainMnuGoldQuestion.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLfountainMnuGoldQuestion.ForeColor = System.Drawing.Color.White
        Me.LBLfountainMnuGoldQuestion.Location = New System.Drawing.Point(332, 67)
        Me.LBLfountainMnuGoldQuestion.Name = "LBLfountainMnuGoldQuestion"
        Me.LBLfountainMnuGoldQuestion.Size = New System.Drawing.Size(321, 19)
        Me.LBLfountainMnuGoldQuestion.TabIndex = 10
        Me.LBLfountainMnuGoldQuestion.Text = "How much gold do you wish to throw in?"
        '
        'PCBWishingWell
        '
        Me.PCBWishingWell.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PCBWishingWell.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PCBWishingWell.Image = CType(resources.GetObject("PCBWishingWell.Image"), System.Drawing.Image)
        Me.PCBWishingWell.Location = New System.Drawing.Point(332, 133)
        Me.PCBWishingWell.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.PCBWishingWell.Name = "PCBWishingWell"
        Me.PCBWishingWell.Size = New System.Drawing.Size(327, 427)
        Me.PCBWishingWell.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PCBWishingWell.TabIndex = 0
        Me.PCBWishingWell.TabStop = False
        '
        'PNLTheArena
        '
        Me.PNLTheArena.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PNLTheArena.AutoScroll = True
        Me.PNLTheArena.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.PNLTheArena.Controls.Add(Me.CHBHideCombatLog)
        Me.PNLTheArena.Controls.Add(Me.LBLSkillDescription)
        Me.PNLTheArena.Controls.Add(Me.GRBFoe4)
        Me.PNLTheArena.Controls.Add(Me.GRBFoe3)
        Me.PNLTheArena.Controls.Add(Me.GRBFoe2)
        Me.PNLTheArena.Controls.Add(Me.GRBGeneralSkills)
        Me.PNLTheArena.Controls.Add(Me.LBLTurnCounter)
        Me.PNLTheArena.Controls.Add(Me.GRBNylathriaSkills)
        Me.PNLTheArena.Controls.Add(Me.GRBNardinaSkills)
        Me.PNLTheArena.Controls.Add(Me.GRBMakyrSkills)
        Me.PNLTheArena.Controls.Add(Me.GRBSagraxesSkills)
        Me.PNLTheArena.Controls.Add(Me.GRBFoe1)
        Me.PNLTheArena.Controls.Add(Me.PGBPlayerHP)
        Me.PNLTheArena.Controls.Add(Me.PGBPlayerMP)
        Me.PNLTheArena.Controls.Add(Me.LBLArenaDiv2)
        Me.PNLTheArena.Controls.Add(Me.LBLArenaMaxMP)
        Me.PNLTheArena.Controls.Add(Me.LBLArenaCurrentMP)
        Me.PNLTheArena.Controls.Add(Me.LBLArenaMnuMP)
        Me.PNLTheArena.Controls.Add(Me.LBLArenaDiv)
        Me.PNLTheArena.Controls.Add(Me.LBLArenaMaxHP)
        Me.PNLTheArena.Controls.Add(Me.LBLArenaCurrentHP)
        Me.PNLTheArena.Controls.Add(Me.LBLArenaMnuHP)
        Me.PNLTheArena.Controls.Add(Me.LBLArenaLevel)
        Me.PNLTheArena.Controls.Add(Me.LBLArenaCharacterName)
        Me.PNLTheArena.Controls.Add(Me.LBLArenaMnuLevel)
        Me.PNLTheArena.Controls.Add(Me.GRBFoe5)
        Me.PNLTheArena.Controls.Add(Me.GRBAlyshaSkills)
        Me.PNLTheArena.Controls.Add(Me.PCBArenaAvatar)
        Me.PNLTheArena.Controls.Add(Me.TXTCombatLog)
        Me.PNLTheArena.Location = New System.Drawing.Point(12, 45)
        Me.PNLTheArena.Name = "PNLTheArena"
        Me.PNLTheArena.Size = New System.Drawing.Size(960, 575)
        Me.PNLTheArena.TabIndex = 13
        Me.PNLTheArena.Visible = False
        '
        'CHBHideCombatLog
        '
        Me.CHBHideCombatLog.AutoSize = True
        Me.CHBHideCombatLog.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CHBHideCombatLog.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHBHideCombatLog.ForeColor = System.Drawing.Color.White
        Me.CHBHideCombatLog.Location = New System.Drawing.Point(351, 545)
        Me.CHBHideCombatLog.Name = "CHBHideCombatLog"
        Me.CHBHideCombatLog.Size = New System.Drawing.Size(107, 18)
        Me.CHBHideCombatLog.TabIndex = 60
        Me.CHBHideCombatLog.Text = "Hide Combat Log"
        Me.CHBHideCombatLog.UseVisualStyleBackColor = True
        '
        'LBLSkillDescription
        '
        Me.LBLSkillDescription.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLSkillDescription.ForeColor = System.Drawing.Color.White
        Me.LBLSkillDescription.Location = New System.Drawing.Point(6, 335)
        Me.LBLSkillDescription.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LBLSkillDescription.Name = "LBLSkillDescription"
        Me.LBLSkillDescription.Size = New System.Drawing.Size(332, 225)
        Me.LBLSkillDescription.TabIndex = 58
        Me.LBLSkillDescription.Text = "skill_description"
        '
        'GRBFoe4
        '
        Me.GRBFoe4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GRBFoe4.Controls.Add(Me.LBLArenaFoe4Name)
        Me.GRBFoe4.Controls.Add(Me.PGBFoe4HP)
        Me.GRBFoe4.Controls.Add(Me.PCBArenaFoe4Avatar)
        Me.GRBFoe4.Controls.Add(Me.LBLArenaMnuFoe4HP)
        Me.GRBFoe4.Controls.Add(Me.LBLArenaFoe4CurrentHP)
        Me.GRBFoe4.Controls.Add(Me.LBLArenaDiv6)
        Me.GRBFoe4.Controls.Add(Me.LBLArenaFoe4MaxHP)
        Me.GRBFoe4.Controls.Add(Me.LBLArenaFoe4Border)
        Me.GRBFoe4.Location = New System.Drawing.Point(664, 333)
        Me.GRBFoe4.Name = "GRBFoe4"
        Me.GRBFoe4.Size = New System.Drawing.Size(296, 115)
        Me.GRBFoe4.TabIndex = 51
        Me.GRBFoe4.TabStop = False
        Me.GRBFoe4.Visible = False
        '
        'LBLArenaFoe4Name
        '
        Me.LBLArenaFoe4Name.AutoSize = True
        Me.LBLArenaFoe4Name.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLArenaFoe4Name.ForeColor = System.Drawing.Color.White
        Me.LBLArenaFoe4Name.Location = New System.Drawing.Point(5, 13)
        Me.LBLArenaFoe4Name.Name = "LBLArenaFoe4Name"
        Me.LBLArenaFoe4Name.Size = New System.Drawing.Size(123, 19)
        Me.LBLArenaFoe4Name.TabIndex = 37
        Me.LBLArenaFoe4Name.Text = "creature_name"
        '
        'PGBFoe4HP
        '
        Me.PGBFoe4HP.ForeColor = System.Drawing.Color.SpringGreen
        Me.PGBFoe4HP.Location = New System.Drawing.Point(9, 53)
        Me.PGBFoe4HP.Name = "PGBFoe4HP"
        Me.PGBFoe4HP.Size = New System.Drawing.Size(178, 23)
        Me.PGBFoe4HP.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.PGBFoe4HP.TabIndex = 45
        '
        'PCBArenaFoe4Avatar
        '
        Me.PCBArenaFoe4Avatar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PCBArenaFoe4Avatar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PCBArenaFoe4Avatar.Location = New System.Drawing.Point(195, 14)
        Me.PCBArenaFoe4Avatar.Name = "PCBArenaFoe4Avatar"
        Me.PCBArenaFoe4Avatar.Size = New System.Drawing.Size(90, 90)
        Me.PCBArenaFoe4Avatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PCBArenaFoe4Avatar.TabIndex = 1
        Me.PCBArenaFoe4Avatar.TabStop = False
        '
        'LBLArenaMnuFoe4HP
        '
        Me.LBLArenaMnuFoe4HP.AutoSize = True
        Me.LBLArenaMnuFoe4HP.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLArenaMnuFoe4HP.ForeColor = System.Drawing.Color.White
        Me.LBLArenaMnuFoe4HP.Location = New System.Drawing.Point(6, 37)
        Me.LBLArenaMnuFoe4HP.Name = "LBLArenaMnuFoe4HP"
        Me.LBLArenaMnuFoe4HP.Size = New System.Drawing.Size(26, 16)
        Me.LBLArenaMnuFoe4HP.TabIndex = 39
        Me.LBLArenaMnuFoe4HP.Text = "HP"
        '
        'LBLArenaFoe4CurrentHP
        '
        Me.LBLArenaFoe4CurrentHP.AutoSize = True
        Me.LBLArenaFoe4CurrentHP.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLArenaFoe4CurrentHP.ForeColor = System.Drawing.Color.White
        Me.LBLArenaFoe4CurrentHP.Location = New System.Drawing.Point(106, 37)
        Me.LBLArenaFoe4CurrentHP.Name = "LBLArenaFoe4CurrentHP"
        Me.LBLArenaFoe4CurrentHP.Size = New System.Drawing.Size(15, 16)
        Me.LBLArenaFoe4CurrentHP.TabIndex = 40
        Me.LBLArenaFoe4CurrentHP.Text = "0"
        '
        'LBLArenaDiv6
        '
        Me.LBLArenaDiv6.AutoSize = True
        Me.LBLArenaDiv6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLArenaDiv6.ForeColor = System.Drawing.Color.White
        Me.LBLArenaDiv6.Location = New System.Drawing.Point(140, 37)
        Me.LBLArenaDiv6.Name = "LBLArenaDiv6"
        Me.LBLArenaDiv6.Size = New System.Drawing.Size(12, 16)
        Me.LBLArenaDiv6.TabIndex = 42
        Me.LBLArenaDiv6.Text = "/"
        '
        'LBLArenaFoe4MaxHP
        '
        Me.LBLArenaFoe4MaxHP.AutoSize = True
        Me.LBLArenaFoe4MaxHP.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLArenaFoe4MaxHP.ForeColor = System.Drawing.Color.White
        Me.LBLArenaFoe4MaxHP.Location = New System.Drawing.Point(158, 37)
        Me.LBLArenaFoe4MaxHP.Name = "LBLArenaFoe4MaxHP"
        Me.LBLArenaFoe4MaxHP.Size = New System.Drawing.Size(29, 16)
        Me.LBLArenaFoe4MaxHP.TabIndex = 41
        Me.LBLArenaFoe4MaxHP.Text = "100"
        '
        'LBLArenaFoe4Border
        '
        Me.LBLArenaFoe4Border.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LBLArenaFoe4Border.ForeColor = System.Drawing.Color.White
        Me.LBLArenaFoe4Border.Location = New System.Drawing.Point(190, 10)
        Me.LBLArenaFoe4Border.Name = "LBLArenaFoe4Border"
        Me.LBLArenaFoe4Border.Size = New System.Drawing.Size(99, 99)
        Me.LBLArenaFoe4Border.TabIndex = 47
        '
        'GRBFoe3
        '
        Me.GRBFoe3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GRBFoe3.Controls.Add(Me.LBLArenaFoe3Name)
        Me.GRBFoe3.Controls.Add(Me.PGBFoe3HP)
        Me.GRBFoe3.Controls.Add(Me.PCBArenaFoe3Avatar)
        Me.GRBFoe3.Controls.Add(Me.LBLArenaMnuFoe3HP)
        Me.GRBFoe3.Controls.Add(Me.LBLArenaFoe3CurrentHP)
        Me.GRBFoe3.Controls.Add(Me.LBLArenaDiv5)
        Me.GRBFoe3.Controls.Add(Me.LBLArenaFoe3MaxHP)
        Me.GRBFoe3.Controls.Add(Me.LBLArenaFoe3Border)
        Me.GRBFoe3.Location = New System.Drawing.Point(664, 223)
        Me.GRBFoe3.Name = "GRBFoe3"
        Me.GRBFoe3.Size = New System.Drawing.Size(296, 115)
        Me.GRBFoe3.TabIndex = 50
        Me.GRBFoe3.TabStop = False
        Me.GRBFoe3.Visible = False
        '
        'LBLArenaFoe3Name
        '
        Me.LBLArenaFoe3Name.AutoSize = True
        Me.LBLArenaFoe3Name.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLArenaFoe3Name.ForeColor = System.Drawing.Color.White
        Me.LBLArenaFoe3Name.Location = New System.Drawing.Point(5, 13)
        Me.LBLArenaFoe3Name.Name = "LBLArenaFoe3Name"
        Me.LBLArenaFoe3Name.Size = New System.Drawing.Size(123, 19)
        Me.LBLArenaFoe3Name.TabIndex = 37
        Me.LBLArenaFoe3Name.Text = "creature_name"
        '
        'PGBFoe3HP
        '
        Me.PGBFoe3HP.ForeColor = System.Drawing.Color.SpringGreen
        Me.PGBFoe3HP.Location = New System.Drawing.Point(9, 53)
        Me.PGBFoe3HP.Name = "PGBFoe3HP"
        Me.PGBFoe3HP.Size = New System.Drawing.Size(178, 23)
        Me.PGBFoe3HP.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.PGBFoe3HP.TabIndex = 45
        '
        'PCBArenaFoe3Avatar
        '
        Me.PCBArenaFoe3Avatar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PCBArenaFoe3Avatar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PCBArenaFoe3Avatar.Location = New System.Drawing.Point(195, 14)
        Me.PCBArenaFoe3Avatar.Name = "PCBArenaFoe3Avatar"
        Me.PCBArenaFoe3Avatar.Size = New System.Drawing.Size(90, 90)
        Me.PCBArenaFoe3Avatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PCBArenaFoe3Avatar.TabIndex = 1
        Me.PCBArenaFoe3Avatar.TabStop = False
        '
        'LBLArenaMnuFoe3HP
        '
        Me.LBLArenaMnuFoe3HP.AutoSize = True
        Me.LBLArenaMnuFoe3HP.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLArenaMnuFoe3HP.ForeColor = System.Drawing.Color.White
        Me.LBLArenaMnuFoe3HP.Location = New System.Drawing.Point(6, 37)
        Me.LBLArenaMnuFoe3HP.Name = "LBLArenaMnuFoe3HP"
        Me.LBLArenaMnuFoe3HP.Size = New System.Drawing.Size(26, 16)
        Me.LBLArenaMnuFoe3HP.TabIndex = 39
        Me.LBLArenaMnuFoe3HP.Text = "HP"
        '
        'LBLArenaFoe3CurrentHP
        '
        Me.LBLArenaFoe3CurrentHP.AutoSize = True
        Me.LBLArenaFoe3CurrentHP.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLArenaFoe3CurrentHP.ForeColor = System.Drawing.Color.White
        Me.LBLArenaFoe3CurrentHP.Location = New System.Drawing.Point(106, 37)
        Me.LBLArenaFoe3CurrentHP.Name = "LBLArenaFoe3CurrentHP"
        Me.LBLArenaFoe3CurrentHP.Size = New System.Drawing.Size(15, 16)
        Me.LBLArenaFoe3CurrentHP.TabIndex = 40
        Me.LBLArenaFoe3CurrentHP.Text = "0"
        '
        'LBLArenaDiv5
        '
        Me.LBLArenaDiv5.AutoSize = True
        Me.LBLArenaDiv5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLArenaDiv5.ForeColor = System.Drawing.Color.White
        Me.LBLArenaDiv5.Location = New System.Drawing.Point(140, 37)
        Me.LBLArenaDiv5.Name = "LBLArenaDiv5"
        Me.LBLArenaDiv5.Size = New System.Drawing.Size(12, 16)
        Me.LBLArenaDiv5.TabIndex = 42
        Me.LBLArenaDiv5.Text = "/"
        '
        'LBLArenaFoe3MaxHP
        '
        Me.LBLArenaFoe3MaxHP.AutoSize = True
        Me.LBLArenaFoe3MaxHP.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLArenaFoe3MaxHP.ForeColor = System.Drawing.Color.White
        Me.LBLArenaFoe3MaxHP.Location = New System.Drawing.Point(158, 37)
        Me.LBLArenaFoe3MaxHP.Name = "LBLArenaFoe3MaxHP"
        Me.LBLArenaFoe3MaxHP.Size = New System.Drawing.Size(29, 16)
        Me.LBLArenaFoe3MaxHP.TabIndex = 41
        Me.LBLArenaFoe3MaxHP.Text = "100"
        '
        'LBLArenaFoe3Border
        '
        Me.LBLArenaFoe3Border.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LBLArenaFoe3Border.ForeColor = System.Drawing.Color.White
        Me.LBLArenaFoe3Border.Location = New System.Drawing.Point(190, 10)
        Me.LBLArenaFoe3Border.Name = "LBLArenaFoe3Border"
        Me.LBLArenaFoe3Border.Size = New System.Drawing.Size(99, 99)
        Me.LBLArenaFoe3Border.TabIndex = 47
        '
        'GRBFoe2
        '
        Me.GRBFoe2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GRBFoe2.Controls.Add(Me.LBLArenaFoe2Name)
        Me.GRBFoe2.Controls.Add(Me.PGBFoe2HP)
        Me.GRBFoe2.Controls.Add(Me.PCBArenaFoe2Avatar)
        Me.GRBFoe2.Controls.Add(Me.LBLArenaMnuFoe2HP)
        Me.GRBFoe2.Controls.Add(Me.LBLArenaFoe2CurrentHP)
        Me.GRBFoe2.Controls.Add(Me.LBLArenaDiv4)
        Me.GRBFoe2.Controls.Add(Me.LBLArenaFoe2MaxHP)
        Me.GRBFoe2.Controls.Add(Me.LBLArenaFoe2Border)
        Me.GRBFoe2.Location = New System.Drawing.Point(664, 113)
        Me.GRBFoe2.Name = "GRBFoe2"
        Me.GRBFoe2.Size = New System.Drawing.Size(296, 115)
        Me.GRBFoe2.TabIndex = 49
        Me.GRBFoe2.TabStop = False
        Me.GRBFoe2.Visible = False
        '
        'LBLArenaFoe2Name
        '
        Me.LBLArenaFoe2Name.AutoSize = True
        Me.LBLArenaFoe2Name.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLArenaFoe2Name.ForeColor = System.Drawing.Color.White
        Me.LBLArenaFoe2Name.Location = New System.Drawing.Point(5, 13)
        Me.LBLArenaFoe2Name.Name = "LBLArenaFoe2Name"
        Me.LBLArenaFoe2Name.Size = New System.Drawing.Size(123, 19)
        Me.LBLArenaFoe2Name.TabIndex = 37
        Me.LBLArenaFoe2Name.Text = "creature_name"
        '
        'PGBFoe2HP
        '
        Me.PGBFoe2HP.ForeColor = System.Drawing.Color.SpringGreen
        Me.PGBFoe2HP.Location = New System.Drawing.Point(9, 53)
        Me.PGBFoe2HP.Name = "PGBFoe2HP"
        Me.PGBFoe2HP.Size = New System.Drawing.Size(178, 23)
        Me.PGBFoe2HP.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.PGBFoe2HP.TabIndex = 45
        '
        'PCBArenaFoe2Avatar
        '
        Me.PCBArenaFoe2Avatar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PCBArenaFoe2Avatar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PCBArenaFoe2Avatar.Location = New System.Drawing.Point(195, 14)
        Me.PCBArenaFoe2Avatar.Name = "PCBArenaFoe2Avatar"
        Me.PCBArenaFoe2Avatar.Size = New System.Drawing.Size(90, 90)
        Me.PCBArenaFoe2Avatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PCBArenaFoe2Avatar.TabIndex = 1
        Me.PCBArenaFoe2Avatar.TabStop = False
        '
        'LBLArenaMnuFoe2HP
        '
        Me.LBLArenaMnuFoe2HP.AutoSize = True
        Me.LBLArenaMnuFoe2HP.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLArenaMnuFoe2HP.ForeColor = System.Drawing.Color.White
        Me.LBLArenaMnuFoe2HP.Location = New System.Drawing.Point(6, 37)
        Me.LBLArenaMnuFoe2HP.Name = "LBLArenaMnuFoe2HP"
        Me.LBLArenaMnuFoe2HP.Size = New System.Drawing.Size(26, 16)
        Me.LBLArenaMnuFoe2HP.TabIndex = 39
        Me.LBLArenaMnuFoe2HP.Text = "HP"
        '
        'LBLArenaFoe2CurrentHP
        '
        Me.LBLArenaFoe2CurrentHP.AutoSize = True
        Me.LBLArenaFoe2CurrentHP.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLArenaFoe2CurrentHP.ForeColor = System.Drawing.Color.White
        Me.LBLArenaFoe2CurrentHP.Location = New System.Drawing.Point(106, 37)
        Me.LBLArenaFoe2CurrentHP.Name = "LBLArenaFoe2CurrentHP"
        Me.LBLArenaFoe2CurrentHP.Size = New System.Drawing.Size(15, 16)
        Me.LBLArenaFoe2CurrentHP.TabIndex = 40
        Me.LBLArenaFoe2CurrentHP.Text = "0"
        '
        'LBLArenaDiv4
        '
        Me.LBLArenaDiv4.AutoSize = True
        Me.LBLArenaDiv4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLArenaDiv4.ForeColor = System.Drawing.Color.White
        Me.LBLArenaDiv4.Location = New System.Drawing.Point(140, 37)
        Me.LBLArenaDiv4.Name = "LBLArenaDiv4"
        Me.LBLArenaDiv4.Size = New System.Drawing.Size(12, 16)
        Me.LBLArenaDiv4.TabIndex = 42
        Me.LBLArenaDiv4.Text = "/"
        '
        'LBLArenaFoe2MaxHP
        '
        Me.LBLArenaFoe2MaxHP.AutoSize = True
        Me.LBLArenaFoe2MaxHP.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLArenaFoe2MaxHP.ForeColor = System.Drawing.Color.White
        Me.LBLArenaFoe2MaxHP.Location = New System.Drawing.Point(158, 37)
        Me.LBLArenaFoe2MaxHP.Name = "LBLArenaFoe2MaxHP"
        Me.LBLArenaFoe2MaxHP.Size = New System.Drawing.Size(29, 16)
        Me.LBLArenaFoe2MaxHP.TabIndex = 41
        Me.LBLArenaFoe2MaxHP.Text = "100"
        '
        'LBLArenaFoe2Border
        '
        Me.LBLArenaFoe2Border.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LBLArenaFoe2Border.ForeColor = System.Drawing.Color.White
        Me.LBLArenaFoe2Border.Location = New System.Drawing.Point(190, 10)
        Me.LBLArenaFoe2Border.Name = "LBLArenaFoe2Border"
        Me.LBLArenaFoe2Border.Size = New System.Drawing.Size(99, 99)
        Me.LBLArenaFoe2Border.TabIndex = 47
        '
        'GRBGeneralSkills
        '
        Me.GRBGeneralSkills.Controls.Add(Me.CMDUseItem)
        Me.GRBGeneralSkills.Controls.Add(Me.CMDBlock)
        Me.GRBGeneralSkills.Controls.Add(Me.CMDFlee)
        Me.GRBGeneralSkills.Location = New System.Drawing.Point(5, 244)
        Me.GRBGeneralSkills.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GRBGeneralSkills.Name = "GRBGeneralSkills"
        Me.GRBGeneralSkills.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GRBGeneralSkills.Size = New System.Drawing.Size(333, 73)
        Me.GRBGeneralSkills.TabIndex = 58
        Me.GRBGeneralSkills.TabStop = False
        '
        'CMDUseItem
        '
        Me.CMDUseItem.BackColor = System.Drawing.Color.White
        Me.CMDUseItem.BackgroundImage = CType(resources.GetObject("CMDUseItem.BackgroundImage"), System.Drawing.Image)
        Me.CMDUseItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CMDUseItem.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDUseItem.FlatAppearance.BorderSize = 0
        Me.CMDUseItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDUseItem.Font = New System.Drawing.Font("Arial", 28.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDUseItem.ForeColor = System.Drawing.Color.Red
        Me.CMDUseItem.Location = New System.Drawing.Point(141, 14)
        Me.CMDUseItem.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.CMDUseItem.Name = "CMDUseItem"
        Me.CMDUseItem.Size = New System.Drawing.Size(50, 50)
        Me.CMDUseItem.TabIndex = 62
        Me.CMDUseItem.UseVisualStyleBackColor = False
        '
        'CMDBlock
        '
        Me.CMDBlock.BackColor = System.Drawing.Color.White
        Me.CMDBlock.BackgroundImage = CType(resources.GetObject("CMDBlock.BackgroundImage"), System.Drawing.Image)
        Me.CMDBlock.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CMDBlock.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDBlock.FlatAppearance.BorderSize = 0
        Me.CMDBlock.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDBlock.Font = New System.Drawing.Font("Arial", 28.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDBlock.ForeColor = System.Drawing.Color.Red
        Me.CMDBlock.Location = New System.Drawing.Point(77, 14)
        Me.CMDBlock.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.CMDBlock.Name = "CMDBlock"
        Me.CMDBlock.Size = New System.Drawing.Size(50, 50)
        Me.CMDBlock.TabIndex = 61
        Me.CMDBlock.UseVisualStyleBackColor = False
        '
        'CMDFlee
        '
        Me.CMDFlee.BackColor = System.Drawing.Color.White
        Me.CMDFlee.BackgroundImage = CType(resources.GetObject("CMDFlee.BackgroundImage"), System.Drawing.Image)
        Me.CMDFlee.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CMDFlee.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDFlee.FlatAppearance.BorderSize = 0
        Me.CMDFlee.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDFlee.Font = New System.Drawing.Font("Arial", 28.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDFlee.ForeColor = System.Drawing.Color.Red
        Me.CMDFlee.Location = New System.Drawing.Point(14, 14)
        Me.CMDFlee.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.CMDFlee.Name = "CMDFlee"
        Me.CMDFlee.Size = New System.Drawing.Size(50, 50)
        Me.CMDFlee.TabIndex = 60
        Me.CMDFlee.UseVisualStyleBackColor = False
        '
        'LBLTurnCounter
        '
        Me.LBLTurnCounter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LBLTurnCounter.AutoSize = True
        Me.LBLTurnCounter.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLTurnCounter.ForeColor = System.Drawing.Color.White
        Me.LBLTurnCounter.Location = New System.Drawing.Point(424, 8)
        Me.LBLTurnCounter.Name = "LBLTurnCounter"
        Me.LBLTurnCounter.Size = New System.Drawing.Size(129, 19)
        Me.LBLTurnCounter.TabIndex = 59
        Me.LBLTurnCounter.Text = "Turn Counter: 0"
        '
        'GRBNylathriaSkills
        '
        Me.GRBNylathriaSkills.Controls.Add(Me.CMDNylathriaSkill5)
        Me.GRBNylathriaSkills.Controls.Add(Me.CMDNylathriaSkill4)
        Me.GRBNylathriaSkills.Controls.Add(Me.CMDNylathriaSkill3)
        Me.GRBNylathriaSkills.Controls.Add(Me.CMDNylathriaSkill2)
        Me.GRBNylathriaSkills.Controls.Add(Me.CMDNylathriaSkill1)
        Me.GRBNylathriaSkills.Location = New System.Drawing.Point(363, 223)
        Me.GRBNylathriaSkills.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GRBNylathriaSkills.Name = "GRBNylathriaSkills"
        Me.GRBNylathriaSkills.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GRBNylathriaSkills.Size = New System.Drawing.Size(333, 73)
        Me.GRBNylathriaSkills.TabIndex = 57
        Me.GRBNylathriaSkills.TabStop = False
        Me.GRBNylathriaSkills.Visible = False
        '
        'CMDNylathriaSkill5
        '
        Me.CMDNylathriaSkill5.BackColor = System.Drawing.Color.White
        Me.CMDNylathriaSkill5.BackgroundImage = CType(resources.GetObject("CMDNylathriaSkill5.BackgroundImage"), System.Drawing.Image)
        Me.CMDNylathriaSkill5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CMDNylathriaSkill5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDNylathriaSkill5.FlatAppearance.BorderSize = 0
        Me.CMDNylathriaSkill5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDNylathriaSkill5.Font = New System.Drawing.Font("Arial", 28.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDNylathriaSkill5.ForeColor = System.Drawing.Color.Red
        Me.CMDNylathriaSkill5.Location = New System.Drawing.Point(271, 13)
        Me.CMDNylathriaSkill5.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.CMDNylathriaSkill5.Name = "CMDNylathriaSkill5"
        Me.CMDNylathriaSkill5.Size = New System.Drawing.Size(48, 52)
        Me.CMDNylathriaSkill5.TabIndex = 56
        Me.CMDNylathriaSkill5.UseVisualStyleBackColor = False
        '
        'CMDNylathriaSkill4
        '
        Me.CMDNylathriaSkill4.BackColor = System.Drawing.Color.White
        Me.CMDNylathriaSkill4.BackgroundImage = CType(resources.GetObject("CMDNylathriaSkill4.BackgroundImage"), System.Drawing.Image)
        Me.CMDNylathriaSkill4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CMDNylathriaSkill4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDNylathriaSkill4.FlatAppearance.BorderSize = 0
        Me.CMDNylathriaSkill4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDNylathriaSkill4.Font = New System.Drawing.Font("Arial", 28.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDNylathriaSkill4.ForeColor = System.Drawing.Color.Red
        Me.CMDNylathriaSkill4.Location = New System.Drawing.Point(206, 13)
        Me.CMDNylathriaSkill4.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.CMDNylathriaSkill4.Name = "CMDNylathriaSkill4"
        Me.CMDNylathriaSkill4.Size = New System.Drawing.Size(48, 52)
        Me.CMDNylathriaSkill4.TabIndex = 55
        Me.CMDNylathriaSkill4.UseVisualStyleBackColor = False
        '
        'CMDNylathriaSkill3
        '
        Me.CMDNylathriaSkill3.BackColor = System.Drawing.Color.White
        Me.CMDNylathriaSkill3.BackgroundImage = CType(resources.GetObject("CMDNylathriaSkill3.BackgroundImage"), System.Drawing.Image)
        Me.CMDNylathriaSkill3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CMDNylathriaSkill3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDNylathriaSkill3.FlatAppearance.BorderSize = 0
        Me.CMDNylathriaSkill3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDNylathriaSkill3.Font = New System.Drawing.Font("Arial", 28.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDNylathriaSkill3.ForeColor = System.Drawing.Color.Red
        Me.CMDNylathriaSkill3.Location = New System.Drawing.Point(142, 13)
        Me.CMDNylathriaSkill3.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.CMDNylathriaSkill3.Name = "CMDNylathriaSkill3"
        Me.CMDNylathriaSkill3.Size = New System.Drawing.Size(48, 52)
        Me.CMDNylathriaSkill3.TabIndex = 54
        Me.CMDNylathriaSkill3.UseVisualStyleBackColor = False
        '
        'CMDNylathriaSkill2
        '
        Me.CMDNylathriaSkill2.BackColor = System.Drawing.Color.White
        Me.CMDNylathriaSkill2.BackgroundImage = CType(resources.GetObject("CMDNylathriaSkill2.BackgroundImage"), System.Drawing.Image)
        Me.CMDNylathriaSkill2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CMDNylathriaSkill2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDNylathriaSkill2.FlatAppearance.BorderSize = 0
        Me.CMDNylathriaSkill2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDNylathriaSkill2.Font = New System.Drawing.Font("Arial", 28.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDNylathriaSkill2.ForeColor = System.Drawing.Color.Red
        Me.CMDNylathriaSkill2.Location = New System.Drawing.Point(77, 13)
        Me.CMDNylathriaSkill2.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.CMDNylathriaSkill2.Name = "CMDNylathriaSkill2"
        Me.CMDNylathriaSkill2.Size = New System.Drawing.Size(48, 52)
        Me.CMDNylathriaSkill2.TabIndex = 53
        Me.CMDNylathriaSkill2.UseVisualStyleBackColor = False
        '
        'CMDNylathriaSkill1
        '
        Me.CMDNylathriaSkill1.BackColor = System.Drawing.Color.White
        Me.CMDNylathriaSkill1.BackgroundImage = CType(resources.GetObject("CMDNylathriaSkill1.BackgroundImage"), System.Drawing.Image)
        Me.CMDNylathriaSkill1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CMDNylathriaSkill1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDNylathriaSkill1.FlatAppearance.BorderSize = 0
        Me.CMDNylathriaSkill1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDNylathriaSkill1.Font = New System.Drawing.Font("Arial", 28.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDNylathriaSkill1.ForeColor = System.Drawing.Color.Red
        Me.CMDNylathriaSkill1.Location = New System.Drawing.Point(14, 14)
        Me.CMDNylathriaSkill1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.CMDNylathriaSkill1.Name = "CMDNylathriaSkill1"
        Me.CMDNylathriaSkill1.Size = New System.Drawing.Size(48, 52)
        Me.CMDNylathriaSkill1.TabIndex = 52
        Me.CMDNylathriaSkill1.UseVisualStyleBackColor = False
        '
        'GRBNardinaSkills
        '
        Me.GRBNardinaSkills.Controls.Add(Me.CMDNardinaSkill5)
        Me.GRBNardinaSkills.Controls.Add(Me.CMDNardinaSkill4)
        Me.GRBNardinaSkills.Controls.Add(Me.CMDNardinaSkill3)
        Me.GRBNardinaSkills.Controls.Add(Me.CMDNardinaSkill2)
        Me.GRBNardinaSkills.Controls.Add(Me.CMDNardinaSkill1)
        Me.GRBNardinaSkills.Location = New System.Drawing.Point(363, 133)
        Me.GRBNardinaSkills.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GRBNardinaSkills.Name = "GRBNardinaSkills"
        Me.GRBNardinaSkills.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GRBNardinaSkills.Size = New System.Drawing.Size(333, 73)
        Me.GRBNardinaSkills.TabIndex = 57
        Me.GRBNardinaSkills.TabStop = False
        Me.GRBNardinaSkills.Visible = False
        '
        'CMDNardinaSkill5
        '
        Me.CMDNardinaSkill5.BackColor = System.Drawing.Color.White
        Me.CMDNardinaSkill5.BackgroundImage = CType(resources.GetObject("CMDNardinaSkill5.BackgroundImage"), System.Drawing.Image)
        Me.CMDNardinaSkill5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CMDNardinaSkill5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDNardinaSkill5.FlatAppearance.BorderSize = 0
        Me.CMDNardinaSkill5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDNardinaSkill5.Font = New System.Drawing.Font("Arial", 28.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDNardinaSkill5.ForeColor = System.Drawing.Color.Red
        Me.CMDNardinaSkill5.Location = New System.Drawing.Point(271, 13)
        Me.CMDNardinaSkill5.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.CMDNardinaSkill5.Name = "CMDNardinaSkill5"
        Me.CMDNardinaSkill5.Size = New System.Drawing.Size(48, 52)
        Me.CMDNardinaSkill5.TabIndex = 56
        Me.CMDNardinaSkill5.UseVisualStyleBackColor = False
        '
        'CMDNardinaSkill4
        '
        Me.CMDNardinaSkill4.BackColor = System.Drawing.Color.White
        Me.CMDNardinaSkill4.BackgroundImage = CType(resources.GetObject("CMDNardinaSkill4.BackgroundImage"), System.Drawing.Image)
        Me.CMDNardinaSkill4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CMDNardinaSkill4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDNardinaSkill4.FlatAppearance.BorderSize = 0
        Me.CMDNardinaSkill4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDNardinaSkill4.Font = New System.Drawing.Font("Arial", 28.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDNardinaSkill4.ForeColor = System.Drawing.Color.Red
        Me.CMDNardinaSkill4.Location = New System.Drawing.Point(206, 13)
        Me.CMDNardinaSkill4.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.CMDNardinaSkill4.Name = "CMDNardinaSkill4"
        Me.CMDNardinaSkill4.Size = New System.Drawing.Size(48, 52)
        Me.CMDNardinaSkill4.TabIndex = 55
        Me.CMDNardinaSkill4.UseVisualStyleBackColor = False
        '
        'CMDNardinaSkill3
        '
        Me.CMDNardinaSkill3.BackColor = System.Drawing.Color.White
        Me.CMDNardinaSkill3.BackgroundImage = CType(resources.GetObject("CMDNardinaSkill3.BackgroundImage"), System.Drawing.Image)
        Me.CMDNardinaSkill3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CMDNardinaSkill3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDNardinaSkill3.FlatAppearance.BorderSize = 0
        Me.CMDNardinaSkill3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDNardinaSkill3.Font = New System.Drawing.Font("Arial", 28.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDNardinaSkill3.ForeColor = System.Drawing.Color.Red
        Me.CMDNardinaSkill3.Location = New System.Drawing.Point(142, 13)
        Me.CMDNardinaSkill3.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.CMDNardinaSkill3.Name = "CMDNardinaSkill3"
        Me.CMDNardinaSkill3.Size = New System.Drawing.Size(48, 52)
        Me.CMDNardinaSkill3.TabIndex = 54
        Me.CMDNardinaSkill3.UseVisualStyleBackColor = False
        '
        'CMDNardinaSkill2
        '
        Me.CMDNardinaSkill2.BackColor = System.Drawing.Color.White
        Me.CMDNardinaSkill2.BackgroundImage = CType(resources.GetObject("CMDNardinaSkill2.BackgroundImage"), System.Drawing.Image)
        Me.CMDNardinaSkill2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CMDNardinaSkill2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDNardinaSkill2.FlatAppearance.BorderSize = 0
        Me.CMDNardinaSkill2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDNardinaSkill2.Font = New System.Drawing.Font("Arial", 28.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDNardinaSkill2.ForeColor = System.Drawing.Color.Red
        Me.CMDNardinaSkill2.Location = New System.Drawing.Point(77, 13)
        Me.CMDNardinaSkill2.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.CMDNardinaSkill2.Name = "CMDNardinaSkill2"
        Me.CMDNardinaSkill2.Size = New System.Drawing.Size(48, 52)
        Me.CMDNardinaSkill2.TabIndex = 53
        Me.CMDNardinaSkill2.UseVisualStyleBackColor = False
        '
        'CMDNardinaSkill1
        '
        Me.CMDNardinaSkill1.BackColor = System.Drawing.Color.White
        Me.CMDNardinaSkill1.BackgroundImage = CType(resources.GetObject("CMDNardinaSkill1.BackgroundImage"), System.Drawing.Image)
        Me.CMDNardinaSkill1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CMDNardinaSkill1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDNardinaSkill1.FlatAppearance.BorderSize = 0
        Me.CMDNardinaSkill1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDNardinaSkill1.Font = New System.Drawing.Font("Arial", 28.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDNardinaSkill1.ForeColor = System.Drawing.Color.Red
        Me.CMDNardinaSkill1.Location = New System.Drawing.Point(14, 14)
        Me.CMDNardinaSkill1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.CMDNardinaSkill1.Name = "CMDNardinaSkill1"
        Me.CMDNardinaSkill1.Size = New System.Drawing.Size(48, 52)
        Me.CMDNardinaSkill1.TabIndex = 52
        Me.CMDNardinaSkill1.UseVisualStyleBackColor = False
        '
        'GRBMakyrSkills
        '
        Me.GRBMakyrSkills.Controls.Add(Me.CMDMakyrSkill5)
        Me.GRBMakyrSkills.Controls.Add(Me.CMDMakyrSkill4)
        Me.GRBMakyrSkills.Controls.Add(Me.CMDMakyrSkill3)
        Me.GRBMakyrSkills.Controls.Add(Me.CMDMakyrSkill2)
        Me.GRBMakyrSkills.Controls.Add(Me.CMDMakyrSkill1)
        Me.GRBMakyrSkills.Location = New System.Drawing.Point(368, 316)
        Me.GRBMakyrSkills.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GRBMakyrSkills.Name = "GRBMakyrSkills"
        Me.GRBMakyrSkills.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GRBMakyrSkills.Size = New System.Drawing.Size(333, 73)
        Me.GRBMakyrSkills.TabIndex = 57
        Me.GRBMakyrSkills.TabStop = False
        Me.GRBMakyrSkills.Visible = False
        '
        'CMDMakyrSkill5
        '
        Me.CMDMakyrSkill5.BackColor = System.Drawing.Color.White
        Me.CMDMakyrSkill5.BackgroundImage = CType(resources.GetObject("CMDMakyrSkill5.BackgroundImage"), System.Drawing.Image)
        Me.CMDMakyrSkill5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CMDMakyrSkill5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDMakyrSkill5.FlatAppearance.BorderSize = 0
        Me.CMDMakyrSkill5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDMakyrSkill5.Font = New System.Drawing.Font("Arial", 28.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDMakyrSkill5.ForeColor = System.Drawing.Color.Red
        Me.CMDMakyrSkill5.Location = New System.Drawing.Point(271, 13)
        Me.CMDMakyrSkill5.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.CMDMakyrSkill5.Name = "CMDMakyrSkill5"
        Me.CMDMakyrSkill5.Size = New System.Drawing.Size(48, 52)
        Me.CMDMakyrSkill5.TabIndex = 56
        Me.CMDMakyrSkill5.UseVisualStyleBackColor = False
        '
        'CMDMakyrSkill4
        '
        Me.CMDMakyrSkill4.BackColor = System.Drawing.Color.White
        Me.CMDMakyrSkill4.BackgroundImage = CType(resources.GetObject("CMDMakyrSkill4.BackgroundImage"), System.Drawing.Image)
        Me.CMDMakyrSkill4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CMDMakyrSkill4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDMakyrSkill4.FlatAppearance.BorderSize = 0
        Me.CMDMakyrSkill4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDMakyrSkill4.Font = New System.Drawing.Font("Arial", 28.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDMakyrSkill4.ForeColor = System.Drawing.Color.Red
        Me.CMDMakyrSkill4.Location = New System.Drawing.Point(206, 13)
        Me.CMDMakyrSkill4.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.CMDMakyrSkill4.Name = "CMDMakyrSkill4"
        Me.CMDMakyrSkill4.Size = New System.Drawing.Size(48, 52)
        Me.CMDMakyrSkill4.TabIndex = 55
        Me.CMDMakyrSkill4.UseVisualStyleBackColor = False
        '
        'CMDMakyrSkill3
        '
        Me.CMDMakyrSkill3.BackColor = System.Drawing.Color.White
        Me.CMDMakyrSkill3.BackgroundImage = CType(resources.GetObject("CMDMakyrSkill3.BackgroundImage"), System.Drawing.Image)
        Me.CMDMakyrSkill3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CMDMakyrSkill3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDMakyrSkill3.FlatAppearance.BorderSize = 0
        Me.CMDMakyrSkill3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDMakyrSkill3.Font = New System.Drawing.Font("Arial", 28.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDMakyrSkill3.ForeColor = System.Drawing.Color.Red
        Me.CMDMakyrSkill3.Location = New System.Drawing.Point(142, 13)
        Me.CMDMakyrSkill3.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.CMDMakyrSkill3.Name = "CMDMakyrSkill3"
        Me.CMDMakyrSkill3.Size = New System.Drawing.Size(48, 52)
        Me.CMDMakyrSkill3.TabIndex = 54
        Me.CMDMakyrSkill3.UseVisualStyleBackColor = False
        '
        'CMDMakyrSkill2
        '
        Me.CMDMakyrSkill2.BackColor = System.Drawing.Color.White
        Me.CMDMakyrSkill2.BackgroundImage = CType(resources.GetObject("CMDMakyrSkill2.BackgroundImage"), System.Drawing.Image)
        Me.CMDMakyrSkill2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CMDMakyrSkill2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDMakyrSkill2.FlatAppearance.BorderSize = 0
        Me.CMDMakyrSkill2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDMakyrSkill2.Font = New System.Drawing.Font("Arial", 28.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDMakyrSkill2.ForeColor = System.Drawing.Color.Red
        Me.CMDMakyrSkill2.Location = New System.Drawing.Point(77, 13)
        Me.CMDMakyrSkill2.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.CMDMakyrSkill2.Name = "CMDMakyrSkill2"
        Me.CMDMakyrSkill2.Size = New System.Drawing.Size(48, 52)
        Me.CMDMakyrSkill2.TabIndex = 53
        Me.CMDMakyrSkill2.UseVisualStyleBackColor = False
        '
        'CMDMakyrSkill1
        '
        Me.CMDMakyrSkill1.BackColor = System.Drawing.Color.White
        Me.CMDMakyrSkill1.BackgroundImage = CType(resources.GetObject("CMDMakyrSkill1.BackgroundImage"), System.Drawing.Image)
        Me.CMDMakyrSkill1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CMDMakyrSkill1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDMakyrSkill1.FlatAppearance.BorderSize = 0
        Me.CMDMakyrSkill1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDMakyrSkill1.Font = New System.Drawing.Font("Arial", 28.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDMakyrSkill1.ForeColor = System.Drawing.Color.Red
        Me.CMDMakyrSkill1.Location = New System.Drawing.Point(14, 14)
        Me.CMDMakyrSkill1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.CMDMakyrSkill1.Name = "CMDMakyrSkill1"
        Me.CMDMakyrSkill1.Size = New System.Drawing.Size(48, 52)
        Me.CMDMakyrSkill1.TabIndex = 52
        Me.CMDMakyrSkill1.UseVisualStyleBackColor = False
        '
        'GRBSagraxesSkills
        '
        Me.GRBSagraxesSkills.Controls.Add(Me.CMDSagraxesSkill5)
        Me.GRBSagraxesSkills.Controls.Add(Me.CMDSagraxesSkill4)
        Me.GRBSagraxesSkills.Controls.Add(Me.CMDSagraxesSkill3)
        Me.GRBSagraxesSkills.Controls.Add(Me.CMDSagraxesSkill2)
        Me.GRBSagraxesSkills.Controls.Add(Me.CMDSagraxesSkill1)
        Me.GRBSagraxesSkills.Location = New System.Drawing.Point(5, 166)
        Me.GRBSagraxesSkills.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GRBSagraxesSkills.Name = "GRBSagraxesSkills"
        Me.GRBSagraxesSkills.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GRBSagraxesSkills.Size = New System.Drawing.Size(333, 73)
        Me.GRBSagraxesSkills.TabIndex = 53
        Me.GRBSagraxesSkills.TabStop = False
        Me.GRBSagraxesSkills.Visible = False
        '
        'CMDSagraxesSkill5
        '
        Me.CMDSagraxesSkill5.BackColor = System.Drawing.Color.Black
        Me.CMDSagraxesSkill5.BackgroundImage = CType(resources.GetObject("CMDSagraxesSkill5.BackgroundImage"), System.Drawing.Image)
        Me.CMDSagraxesSkill5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CMDSagraxesSkill5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDSagraxesSkill5.FlatAppearance.BorderSize = 0
        Me.CMDSagraxesSkill5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDSagraxesSkill5.Font = New System.Drawing.Font("Arial", 28.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDSagraxesSkill5.ForeColor = System.Drawing.Color.Red
        Me.CMDSagraxesSkill5.Location = New System.Drawing.Point(271, 14)
        Me.CMDSagraxesSkill5.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.CMDSagraxesSkill5.Name = "CMDSagraxesSkill5"
        Me.CMDSagraxesSkill5.Size = New System.Drawing.Size(50, 50)
        Me.CMDSagraxesSkill5.TabIndex = 56
        Me.CMDSagraxesSkill5.UseVisualStyleBackColor = False
        '
        'CMDSagraxesSkill4
        '
        Me.CMDSagraxesSkill4.BackColor = System.Drawing.Color.Black
        Me.CMDSagraxesSkill4.BackgroundImage = CType(resources.GetObject("CMDSagraxesSkill4.BackgroundImage"), System.Drawing.Image)
        Me.CMDSagraxesSkill4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CMDSagraxesSkill4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDSagraxesSkill4.FlatAppearance.BorderSize = 0
        Me.CMDSagraxesSkill4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDSagraxesSkill4.Font = New System.Drawing.Font("Arial", 28.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDSagraxesSkill4.ForeColor = System.Drawing.Color.Red
        Me.CMDSagraxesSkill4.Location = New System.Drawing.Point(206, 14)
        Me.CMDSagraxesSkill4.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.CMDSagraxesSkill4.Name = "CMDSagraxesSkill4"
        Me.CMDSagraxesSkill4.Size = New System.Drawing.Size(50, 50)
        Me.CMDSagraxesSkill4.TabIndex = 55
        Me.CMDSagraxesSkill4.UseVisualStyleBackColor = False
        '
        'CMDSagraxesSkill3
        '
        Me.CMDSagraxesSkill3.BackColor = System.Drawing.Color.Black
        Me.CMDSagraxesSkill3.BackgroundImage = CType(resources.GetObject("CMDSagraxesSkill3.BackgroundImage"), System.Drawing.Image)
        Me.CMDSagraxesSkill3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CMDSagraxesSkill3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDSagraxesSkill3.FlatAppearance.BorderSize = 0
        Me.CMDSagraxesSkill3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDSagraxesSkill3.Font = New System.Drawing.Font("Arial", 28.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDSagraxesSkill3.ForeColor = System.Drawing.Color.Red
        Me.CMDSagraxesSkill3.Location = New System.Drawing.Point(142, 14)
        Me.CMDSagraxesSkill3.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.CMDSagraxesSkill3.Name = "CMDSagraxesSkill3"
        Me.CMDSagraxesSkill3.Size = New System.Drawing.Size(50, 50)
        Me.CMDSagraxesSkill3.TabIndex = 54
        Me.CMDSagraxesSkill3.UseVisualStyleBackColor = False
        '
        'CMDSagraxesSkill2
        '
        Me.CMDSagraxesSkill2.BackColor = System.Drawing.Color.Black
        Me.CMDSagraxesSkill2.BackgroundImage = CType(resources.GetObject("CMDSagraxesSkill2.BackgroundImage"), System.Drawing.Image)
        Me.CMDSagraxesSkill2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CMDSagraxesSkill2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDSagraxesSkill2.FlatAppearance.BorderSize = 0
        Me.CMDSagraxesSkill2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDSagraxesSkill2.Font = New System.Drawing.Font("Arial", 28.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDSagraxesSkill2.ForeColor = System.Drawing.Color.Red
        Me.CMDSagraxesSkill2.Location = New System.Drawing.Point(77, 14)
        Me.CMDSagraxesSkill2.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.CMDSagraxesSkill2.Name = "CMDSagraxesSkill2"
        Me.CMDSagraxesSkill2.Size = New System.Drawing.Size(50, 50)
        Me.CMDSagraxesSkill2.TabIndex = 53
        Me.CMDSagraxesSkill2.UseVisualStyleBackColor = False
        '
        'CMDSagraxesSkill1
        '
        Me.CMDSagraxesSkill1.BackColor = System.Drawing.Color.Black
        Me.CMDSagraxesSkill1.BackgroundImage = CType(resources.GetObject("CMDSagraxesSkill1.BackgroundImage"), System.Drawing.Image)
        Me.CMDSagraxesSkill1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CMDSagraxesSkill1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDSagraxesSkill1.FlatAppearance.BorderSize = 0
        Me.CMDSagraxesSkill1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDSagraxesSkill1.Font = New System.Drawing.Font("Arial", 28.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDSagraxesSkill1.ForeColor = System.Drawing.Color.Red
        Me.CMDSagraxesSkill1.Location = New System.Drawing.Point(14, 14)
        Me.CMDSagraxesSkill1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.CMDSagraxesSkill1.Name = "CMDSagraxesSkill1"
        Me.CMDSagraxesSkill1.Size = New System.Drawing.Size(50, 50)
        Me.CMDSagraxesSkill1.TabIndex = 52
        Me.CMDSagraxesSkill1.UseVisualStyleBackColor = False
        '
        'GRBFoe1
        '
        Me.GRBFoe1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GRBFoe1.Controls.Add(Me.LBLArenaFoe1Name)
        Me.GRBFoe1.Controls.Add(Me.PGBFoe1HP)
        Me.GRBFoe1.Controls.Add(Me.PCBArenaFoe1Avatar)
        Me.GRBFoe1.Controls.Add(Me.LBLArenaMnuFoe1HP)
        Me.GRBFoe1.Controls.Add(Me.LBLArenaFoe1CurrentHP)
        Me.GRBFoe1.Controls.Add(Me.LBLArenaDiv3)
        Me.GRBFoe1.Controls.Add(Me.LBLArenaFoe1MaxHP)
        Me.GRBFoe1.Controls.Add(Me.LBLArenaFoe1Border)
        Me.GRBFoe1.Location = New System.Drawing.Point(664, 3)
        Me.GRBFoe1.Name = "GRBFoe1"
        Me.GRBFoe1.Size = New System.Drawing.Size(296, 115)
        Me.GRBFoe1.TabIndex = 48
        Me.GRBFoe1.TabStop = False
        Me.GRBFoe1.Visible = False
        '
        'LBLArenaFoe1Name
        '
        Me.LBLArenaFoe1Name.AutoSize = True
        Me.LBLArenaFoe1Name.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLArenaFoe1Name.ForeColor = System.Drawing.Color.White
        Me.LBLArenaFoe1Name.Location = New System.Drawing.Point(5, 13)
        Me.LBLArenaFoe1Name.Name = "LBLArenaFoe1Name"
        Me.LBLArenaFoe1Name.Size = New System.Drawing.Size(123, 19)
        Me.LBLArenaFoe1Name.TabIndex = 37
        Me.LBLArenaFoe1Name.Text = "creature_name"
        '
        'PGBFoe1HP
        '
        Me.PGBFoe1HP.ForeColor = System.Drawing.Color.SpringGreen
        Me.PGBFoe1HP.Location = New System.Drawing.Point(9, 53)
        Me.PGBFoe1HP.Name = "PGBFoe1HP"
        Me.PGBFoe1HP.Size = New System.Drawing.Size(178, 23)
        Me.PGBFoe1HP.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.PGBFoe1HP.TabIndex = 45
        '
        'PCBArenaFoe1Avatar
        '
        Me.PCBArenaFoe1Avatar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PCBArenaFoe1Avatar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PCBArenaFoe1Avatar.Location = New System.Drawing.Point(195, 14)
        Me.PCBArenaFoe1Avatar.Name = "PCBArenaFoe1Avatar"
        Me.PCBArenaFoe1Avatar.Size = New System.Drawing.Size(90, 90)
        Me.PCBArenaFoe1Avatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PCBArenaFoe1Avatar.TabIndex = 1
        Me.PCBArenaFoe1Avatar.TabStop = False
        '
        'LBLArenaMnuFoe1HP
        '
        Me.LBLArenaMnuFoe1HP.AutoSize = True
        Me.LBLArenaMnuFoe1HP.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLArenaMnuFoe1HP.ForeColor = System.Drawing.Color.White
        Me.LBLArenaMnuFoe1HP.Location = New System.Drawing.Point(6, 37)
        Me.LBLArenaMnuFoe1HP.Name = "LBLArenaMnuFoe1HP"
        Me.LBLArenaMnuFoe1HP.Size = New System.Drawing.Size(26, 16)
        Me.LBLArenaMnuFoe1HP.TabIndex = 39
        Me.LBLArenaMnuFoe1HP.Text = "HP"
        '
        'LBLArenaFoe1CurrentHP
        '
        Me.LBLArenaFoe1CurrentHP.AutoSize = True
        Me.LBLArenaFoe1CurrentHP.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLArenaFoe1CurrentHP.ForeColor = System.Drawing.Color.White
        Me.LBLArenaFoe1CurrentHP.Location = New System.Drawing.Point(106, 37)
        Me.LBLArenaFoe1CurrentHP.Name = "LBLArenaFoe1CurrentHP"
        Me.LBLArenaFoe1CurrentHP.Size = New System.Drawing.Size(15, 16)
        Me.LBLArenaFoe1CurrentHP.TabIndex = 40
        Me.LBLArenaFoe1CurrentHP.Text = "0"
        '
        'LBLArenaDiv3
        '
        Me.LBLArenaDiv3.AutoSize = True
        Me.LBLArenaDiv3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLArenaDiv3.ForeColor = System.Drawing.Color.White
        Me.LBLArenaDiv3.Location = New System.Drawing.Point(140, 37)
        Me.LBLArenaDiv3.Name = "LBLArenaDiv3"
        Me.LBLArenaDiv3.Size = New System.Drawing.Size(12, 16)
        Me.LBLArenaDiv3.TabIndex = 42
        Me.LBLArenaDiv3.Text = "/"
        '
        'LBLArenaFoe1MaxHP
        '
        Me.LBLArenaFoe1MaxHP.AutoSize = True
        Me.LBLArenaFoe1MaxHP.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLArenaFoe1MaxHP.ForeColor = System.Drawing.Color.White
        Me.LBLArenaFoe1MaxHP.Location = New System.Drawing.Point(158, 37)
        Me.LBLArenaFoe1MaxHP.Name = "LBLArenaFoe1MaxHP"
        Me.LBLArenaFoe1MaxHP.Size = New System.Drawing.Size(29, 16)
        Me.LBLArenaFoe1MaxHP.TabIndex = 41
        Me.LBLArenaFoe1MaxHP.Text = "100"
        '
        'LBLArenaFoe1Border
        '
        Me.LBLArenaFoe1Border.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LBLArenaFoe1Border.ForeColor = System.Drawing.Color.White
        Me.LBLArenaFoe1Border.Location = New System.Drawing.Point(190, 10)
        Me.LBLArenaFoe1Border.Name = "LBLArenaFoe1Border"
        Me.LBLArenaFoe1Border.Size = New System.Drawing.Size(99, 99)
        Me.LBLArenaFoe1Border.TabIndex = 47
        '
        'PGBPlayerHP
        '
        Me.PGBPlayerHP.ForeColor = System.Drawing.Color.SpringGreen
        Me.PGBPlayerHP.Location = New System.Drawing.Point(160, 43)
        Me.PGBPlayerHP.Name = "PGBPlayerHP"
        Me.PGBPlayerHP.Size = New System.Drawing.Size(178, 23)
        Me.PGBPlayerHP.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.PGBPlayerHP.TabIndex = 44
        '
        'PGBPlayerMP
        '
        Me.PGBPlayerMP.ForeColor = System.Drawing.Color.Blue
        Me.PGBPlayerMP.Location = New System.Drawing.Point(159, 86)
        Me.PGBPlayerMP.Name = "PGBPlayerMP"
        Me.PGBPlayerMP.Size = New System.Drawing.Size(179, 23)
        Me.PGBPlayerMP.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.PGBPlayerMP.TabIndex = 43
        '
        'LBLArenaDiv2
        '
        Me.LBLArenaDiv2.AutoSize = True
        Me.LBLArenaDiv2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLArenaDiv2.ForeColor = System.Drawing.Color.White
        Me.LBLArenaDiv2.Location = New System.Drawing.Point(291, 70)
        Me.LBLArenaDiv2.Name = "LBLArenaDiv2"
        Me.LBLArenaDiv2.Size = New System.Drawing.Size(12, 16)
        Me.LBLArenaDiv2.TabIndex = 35
        Me.LBLArenaDiv2.Text = "/"
        '
        'LBLArenaMaxMP
        '
        Me.LBLArenaMaxMP.AutoSize = True
        Me.LBLArenaMaxMP.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLArenaMaxMP.ForeColor = System.Drawing.Color.White
        Me.LBLArenaMaxMP.Location = New System.Drawing.Point(309, 70)
        Me.LBLArenaMaxMP.Name = "LBLArenaMaxMP"
        Me.LBLArenaMaxMP.Size = New System.Drawing.Size(29, 16)
        Me.LBLArenaMaxMP.TabIndex = 34
        Me.LBLArenaMaxMP.Text = "100"
        '
        'LBLArenaCurrentMP
        '
        Me.LBLArenaCurrentMP.AutoSize = True
        Me.LBLArenaCurrentMP.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLArenaCurrentMP.ForeColor = System.Drawing.Color.White
        Me.LBLArenaCurrentMP.Location = New System.Drawing.Point(257, 70)
        Me.LBLArenaCurrentMP.Name = "LBLArenaCurrentMP"
        Me.LBLArenaCurrentMP.Size = New System.Drawing.Size(29, 16)
        Me.LBLArenaCurrentMP.TabIndex = 33
        Me.LBLArenaCurrentMP.Text = "100"
        '
        'LBLArenaMnuMP
        '
        Me.LBLArenaMnuMP.AutoSize = True
        Me.LBLArenaMnuMP.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLArenaMnuMP.ForeColor = System.Drawing.Color.White
        Me.LBLArenaMnuMP.Location = New System.Drawing.Point(157, 71)
        Me.LBLArenaMnuMP.Name = "LBLArenaMnuMP"
        Me.LBLArenaMnuMP.Size = New System.Drawing.Size(28, 16)
        Me.LBLArenaMnuMP.TabIndex = 32
        Me.LBLArenaMnuMP.Text = "MP"
        '
        'LBLArenaDiv
        '
        Me.LBLArenaDiv.AutoSize = True
        Me.LBLArenaDiv.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLArenaDiv.ForeColor = System.Drawing.Color.White
        Me.LBLArenaDiv.Location = New System.Drawing.Point(291, 27)
        Me.LBLArenaDiv.Name = "LBLArenaDiv"
        Me.LBLArenaDiv.Size = New System.Drawing.Size(12, 16)
        Me.LBLArenaDiv.TabIndex = 29
        Me.LBLArenaDiv.Text = "/"
        '
        'LBLArenaMaxHP
        '
        Me.LBLArenaMaxHP.AutoSize = True
        Me.LBLArenaMaxHP.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLArenaMaxHP.ForeColor = System.Drawing.Color.White
        Me.LBLArenaMaxHP.Location = New System.Drawing.Point(309, 27)
        Me.LBLArenaMaxHP.Name = "LBLArenaMaxHP"
        Me.LBLArenaMaxHP.Size = New System.Drawing.Size(29, 16)
        Me.LBLArenaMaxHP.TabIndex = 28
        Me.LBLArenaMaxHP.Text = "100"
        '
        'LBLArenaCurrentHP
        '
        Me.LBLArenaCurrentHP.AutoSize = True
        Me.LBLArenaCurrentHP.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLArenaCurrentHP.ForeColor = System.Drawing.Color.White
        Me.LBLArenaCurrentHP.Location = New System.Drawing.Point(257, 27)
        Me.LBLArenaCurrentHP.Name = "LBLArenaCurrentHP"
        Me.LBLArenaCurrentHP.Size = New System.Drawing.Size(29, 16)
        Me.LBLArenaCurrentHP.TabIndex = 27
        Me.LBLArenaCurrentHP.Text = "100"
        '
        'LBLArenaMnuHP
        '
        Me.LBLArenaMnuHP.AutoSize = True
        Me.LBLArenaMnuHP.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLArenaMnuHP.ForeColor = System.Drawing.Color.White
        Me.LBLArenaMnuHP.Location = New System.Drawing.Point(157, 28)
        Me.LBLArenaMnuHP.Name = "LBLArenaMnuHP"
        Me.LBLArenaMnuHP.Size = New System.Drawing.Size(26, 16)
        Me.LBLArenaMnuHP.TabIndex = 26
        Me.LBLArenaMnuHP.Text = "HP"
        '
        'LBLArenaLevel
        '
        Me.LBLArenaLevel.AutoSize = True
        Me.LBLArenaLevel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLArenaLevel.ForeColor = System.Drawing.Color.White
        Me.LBLArenaLevel.Location = New System.Drawing.Point(303, 138)
        Me.LBLArenaLevel.Name = "LBLArenaLevel"
        Me.LBLArenaLevel.Size = New System.Drawing.Size(15, 16)
        Me.LBLArenaLevel.TabIndex = 25
        Me.LBLArenaLevel.Text = "1"
        '
        'LBLArenaCharacterName
        '
        Me.LBLArenaCharacterName.AutoSize = True
        Me.LBLArenaCharacterName.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLArenaCharacterName.ForeColor = System.Drawing.Color.White
        Me.LBLArenaCharacterName.Location = New System.Drawing.Point(156, 5)
        Me.LBLArenaCharacterName.Name = "LBLArenaCharacterName"
        Me.LBLArenaCharacterName.Size = New System.Drawing.Size(61, 19)
        Me.LBLArenaCharacterName.TabIndex = 24
        Me.LBLArenaCharacterName.Text = "Alysha"
        '
        'LBLArenaMnuLevel
        '
        Me.LBLArenaMnuLevel.AutoSize = True
        Me.LBLArenaMnuLevel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLArenaMnuLevel.ForeColor = System.Drawing.Color.White
        Me.LBLArenaMnuLevel.Location = New System.Drawing.Point(157, 138)
        Me.LBLArenaMnuLevel.Name = "LBLArenaMnuLevel"
        Me.LBLArenaMnuLevel.Size = New System.Drawing.Size(49, 16)
        Me.LBLArenaMnuLevel.TabIndex = 23
        Me.LBLArenaMnuLevel.Text = "LEVEL"
        '
        'GRBFoe5
        '
        Me.GRBFoe5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GRBFoe5.Controls.Add(Me.LBLArenaFoe5Name)
        Me.GRBFoe5.Controls.Add(Me.PGBFoe5HP)
        Me.GRBFoe5.Controls.Add(Me.PCBArenaFoe5Avatar)
        Me.GRBFoe5.Controls.Add(Me.LBLArenaMnuFoe5HP)
        Me.GRBFoe5.Controls.Add(Me.LBLArenaFoe5CurrentHP)
        Me.GRBFoe5.Controls.Add(Me.LBLArenaDiv7)
        Me.GRBFoe5.Controls.Add(Me.LBLArenaFoe5MaxHP)
        Me.GRBFoe5.Controls.Add(Me.LBLArenaFoe5Border)
        Me.GRBFoe5.Location = New System.Drawing.Point(664, 443)
        Me.GRBFoe5.Name = "GRBFoe5"
        Me.GRBFoe5.Size = New System.Drawing.Size(296, 115)
        Me.GRBFoe5.TabIndex = 49
        Me.GRBFoe5.TabStop = False
        Me.GRBFoe5.Visible = False
        '
        'LBLArenaFoe5Name
        '
        Me.LBLArenaFoe5Name.AutoSize = True
        Me.LBLArenaFoe5Name.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLArenaFoe5Name.ForeColor = System.Drawing.Color.White
        Me.LBLArenaFoe5Name.Location = New System.Drawing.Point(5, 13)
        Me.LBLArenaFoe5Name.Name = "LBLArenaFoe5Name"
        Me.LBLArenaFoe5Name.Size = New System.Drawing.Size(123, 19)
        Me.LBLArenaFoe5Name.TabIndex = 37
        Me.LBLArenaFoe5Name.Text = "creature_name"
        '
        'PGBFoe5HP
        '
        Me.PGBFoe5HP.ForeColor = System.Drawing.Color.SpringGreen
        Me.PGBFoe5HP.Location = New System.Drawing.Point(9, 53)
        Me.PGBFoe5HP.Name = "PGBFoe5HP"
        Me.PGBFoe5HP.Size = New System.Drawing.Size(178, 23)
        Me.PGBFoe5HP.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.PGBFoe5HP.TabIndex = 45
        '
        'PCBArenaFoe5Avatar
        '
        Me.PCBArenaFoe5Avatar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PCBArenaFoe5Avatar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PCBArenaFoe5Avatar.Location = New System.Drawing.Point(195, 14)
        Me.PCBArenaFoe5Avatar.Name = "PCBArenaFoe5Avatar"
        Me.PCBArenaFoe5Avatar.Size = New System.Drawing.Size(90, 90)
        Me.PCBArenaFoe5Avatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PCBArenaFoe5Avatar.TabIndex = 1
        Me.PCBArenaFoe5Avatar.TabStop = False
        '
        'LBLArenaMnuFoe5HP
        '
        Me.LBLArenaMnuFoe5HP.AutoSize = True
        Me.LBLArenaMnuFoe5HP.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLArenaMnuFoe5HP.ForeColor = System.Drawing.Color.White
        Me.LBLArenaMnuFoe5HP.Location = New System.Drawing.Point(6, 37)
        Me.LBLArenaMnuFoe5HP.Name = "LBLArenaMnuFoe5HP"
        Me.LBLArenaMnuFoe5HP.Size = New System.Drawing.Size(26, 16)
        Me.LBLArenaMnuFoe5HP.TabIndex = 39
        Me.LBLArenaMnuFoe5HP.Text = "HP"
        '
        'LBLArenaFoe5CurrentHP
        '
        Me.LBLArenaFoe5CurrentHP.AutoSize = True
        Me.LBLArenaFoe5CurrentHP.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLArenaFoe5CurrentHP.ForeColor = System.Drawing.Color.White
        Me.LBLArenaFoe5CurrentHP.Location = New System.Drawing.Point(106, 37)
        Me.LBLArenaFoe5CurrentHP.Name = "LBLArenaFoe5CurrentHP"
        Me.LBLArenaFoe5CurrentHP.Size = New System.Drawing.Size(15, 16)
        Me.LBLArenaFoe5CurrentHP.TabIndex = 40
        Me.LBLArenaFoe5CurrentHP.Text = "0"
        '
        'LBLArenaDiv7
        '
        Me.LBLArenaDiv7.AutoSize = True
        Me.LBLArenaDiv7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLArenaDiv7.ForeColor = System.Drawing.Color.White
        Me.LBLArenaDiv7.Location = New System.Drawing.Point(140, 37)
        Me.LBLArenaDiv7.Name = "LBLArenaDiv7"
        Me.LBLArenaDiv7.Size = New System.Drawing.Size(12, 16)
        Me.LBLArenaDiv7.TabIndex = 42
        Me.LBLArenaDiv7.Text = "/"
        '
        'LBLArenaFoe5MaxHP
        '
        Me.LBLArenaFoe5MaxHP.AutoSize = True
        Me.LBLArenaFoe5MaxHP.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLArenaFoe5MaxHP.ForeColor = System.Drawing.Color.White
        Me.LBLArenaFoe5MaxHP.Location = New System.Drawing.Point(158, 37)
        Me.LBLArenaFoe5MaxHP.Name = "LBLArenaFoe5MaxHP"
        Me.LBLArenaFoe5MaxHP.Size = New System.Drawing.Size(29, 16)
        Me.LBLArenaFoe5MaxHP.TabIndex = 41
        Me.LBLArenaFoe5MaxHP.Text = "100"
        '
        'LBLArenaFoe5Border
        '
        Me.LBLArenaFoe5Border.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LBLArenaFoe5Border.ForeColor = System.Drawing.Color.White
        Me.LBLArenaFoe5Border.Location = New System.Drawing.Point(190, 10)
        Me.LBLArenaFoe5Border.Name = "LBLArenaFoe5Border"
        Me.LBLArenaFoe5Border.Size = New System.Drawing.Size(99, 99)
        Me.LBLArenaFoe5Border.TabIndex = 47
        '
        'GRBAlyshaSkills
        '
        Me.GRBAlyshaSkills.Controls.Add(Me.CMDAlyshaSkill5)
        Me.GRBAlyshaSkills.Controls.Add(Me.CMDAlyshaSkill4)
        Me.GRBAlyshaSkills.Controls.Add(Me.CMDAlyshaSkill3)
        Me.GRBAlyshaSkills.Controls.Add(Me.CMDAlyshaSkill2)
        Me.GRBAlyshaSkills.Controls.Add(Me.CMDAlyshaSkill1)
        Me.GRBAlyshaSkills.Location = New System.Drawing.Point(363, 48)
        Me.GRBAlyshaSkills.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GRBAlyshaSkills.Name = "GRBAlyshaSkills"
        Me.GRBAlyshaSkills.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GRBAlyshaSkills.Size = New System.Drawing.Size(333, 73)
        Me.GRBAlyshaSkills.TabIndex = 54
        Me.GRBAlyshaSkills.TabStop = False
        Me.GRBAlyshaSkills.Visible = False
        '
        'CMDAlyshaSkill5
        '
        Me.CMDAlyshaSkill5.BackColor = System.Drawing.Color.White
        Me.CMDAlyshaSkill5.BackgroundImage = CType(resources.GetObject("CMDAlyshaSkill5.BackgroundImage"), System.Drawing.Image)
        Me.CMDAlyshaSkill5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CMDAlyshaSkill5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDAlyshaSkill5.FlatAppearance.BorderSize = 0
        Me.CMDAlyshaSkill5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDAlyshaSkill5.Font = New System.Drawing.Font("Arial", 28.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDAlyshaSkill5.ForeColor = System.Drawing.Color.Red
        Me.CMDAlyshaSkill5.Location = New System.Drawing.Point(271, 13)
        Me.CMDAlyshaSkill5.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.CMDAlyshaSkill5.Name = "CMDAlyshaSkill5"
        Me.CMDAlyshaSkill5.Size = New System.Drawing.Size(48, 52)
        Me.CMDAlyshaSkill5.TabIndex = 56
        Me.CMDAlyshaSkill5.UseVisualStyleBackColor = False
        '
        'CMDAlyshaSkill4
        '
        Me.CMDAlyshaSkill4.BackColor = System.Drawing.Color.White
        Me.CMDAlyshaSkill4.BackgroundImage = CType(resources.GetObject("CMDAlyshaSkill4.BackgroundImage"), System.Drawing.Image)
        Me.CMDAlyshaSkill4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CMDAlyshaSkill4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDAlyshaSkill4.FlatAppearance.BorderSize = 0
        Me.CMDAlyshaSkill4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDAlyshaSkill4.Font = New System.Drawing.Font("Arial", 28.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDAlyshaSkill4.ForeColor = System.Drawing.Color.Red
        Me.CMDAlyshaSkill4.Location = New System.Drawing.Point(206, 13)
        Me.CMDAlyshaSkill4.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.CMDAlyshaSkill4.Name = "CMDAlyshaSkill4"
        Me.CMDAlyshaSkill4.Size = New System.Drawing.Size(48, 52)
        Me.CMDAlyshaSkill4.TabIndex = 55
        Me.CMDAlyshaSkill4.UseVisualStyleBackColor = False
        '
        'CMDAlyshaSkill3
        '
        Me.CMDAlyshaSkill3.BackColor = System.Drawing.Color.White
        Me.CMDAlyshaSkill3.BackgroundImage = CType(resources.GetObject("CMDAlyshaSkill3.BackgroundImage"), System.Drawing.Image)
        Me.CMDAlyshaSkill3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CMDAlyshaSkill3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDAlyshaSkill3.FlatAppearance.BorderSize = 0
        Me.CMDAlyshaSkill3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDAlyshaSkill3.Font = New System.Drawing.Font("Arial", 28.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDAlyshaSkill3.ForeColor = System.Drawing.Color.Red
        Me.CMDAlyshaSkill3.Location = New System.Drawing.Point(142, 13)
        Me.CMDAlyshaSkill3.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.CMDAlyshaSkill3.Name = "CMDAlyshaSkill3"
        Me.CMDAlyshaSkill3.Size = New System.Drawing.Size(48, 52)
        Me.CMDAlyshaSkill3.TabIndex = 54
        Me.CMDAlyshaSkill3.UseVisualStyleBackColor = False
        '
        'CMDAlyshaSkill2
        '
        Me.CMDAlyshaSkill2.BackColor = System.Drawing.Color.White
        Me.CMDAlyshaSkill2.BackgroundImage = CType(resources.GetObject("CMDAlyshaSkill2.BackgroundImage"), System.Drawing.Image)
        Me.CMDAlyshaSkill2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CMDAlyshaSkill2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDAlyshaSkill2.FlatAppearance.BorderSize = 0
        Me.CMDAlyshaSkill2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDAlyshaSkill2.Font = New System.Drawing.Font("Arial", 28.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDAlyshaSkill2.ForeColor = System.Drawing.Color.Red
        Me.CMDAlyshaSkill2.Location = New System.Drawing.Point(77, 13)
        Me.CMDAlyshaSkill2.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.CMDAlyshaSkill2.Name = "CMDAlyshaSkill2"
        Me.CMDAlyshaSkill2.Size = New System.Drawing.Size(48, 52)
        Me.CMDAlyshaSkill2.TabIndex = 53
        Me.CMDAlyshaSkill2.UseVisualStyleBackColor = False
        '
        'CMDAlyshaSkill1
        '
        Me.CMDAlyshaSkill1.BackColor = System.Drawing.Color.White
        Me.CMDAlyshaSkill1.BackgroundImage = CType(resources.GetObject("CMDAlyshaSkill1.BackgroundImage"), System.Drawing.Image)
        Me.CMDAlyshaSkill1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CMDAlyshaSkill1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDAlyshaSkill1.FlatAppearance.BorderSize = 0
        Me.CMDAlyshaSkill1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDAlyshaSkill1.Font = New System.Drawing.Font("Arial", 28.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDAlyshaSkill1.ForeColor = System.Drawing.Color.Red
        Me.CMDAlyshaSkill1.Location = New System.Drawing.Point(14, 13)
        Me.CMDAlyshaSkill1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.CMDAlyshaSkill1.Name = "CMDAlyshaSkill1"
        Me.CMDAlyshaSkill1.Size = New System.Drawing.Size(48, 52)
        Me.CMDAlyshaSkill1.TabIndex = 52
        Me.CMDAlyshaSkill1.UseVisualStyleBackColor = False
        '
        'PCBArenaAvatar
        '
        Me.PCBArenaAvatar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PCBArenaAvatar.Location = New System.Drawing.Point(5, 5)
        Me.PCBArenaAvatar.Name = "PCBArenaAvatar"
        Me.PCBArenaAvatar.Size = New System.Drawing.Size(150, 150)
        Me.PCBArenaAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PCBArenaAvatar.TabIndex = 0
        Me.PCBArenaAvatar.TabStop = False
        '
        'TXTCombatLog
        '
        Me.TXTCombatLog.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TXTCombatLog.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TXTCombatLog.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCombatLog.ForeColor = System.Drawing.Color.White
        Me.TXTCombatLog.Location = New System.Drawing.Point(351, 35)
        Me.TXTCombatLog.Name = "TXTCombatLog"
        Me.TXTCombatLog.ReadOnly = True
        Me.TXTCombatLog.Size = New System.Drawing.Size(303, 504)
        Me.TXTCombatLog.TabIndex = 46
        Me.TXTCombatLog.Text = ""
        '
        'PNLShop
        '
        Me.PNLShop.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PNLShop.AutoScroll = True
        Me.PNLShop.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.PNLShop.Controls.Add(Me.PictureBox2)
        Me.PNLShop.Controls.Add(Me.GRBShopItemInfo)
        Me.PNLShop.Controls.Add(Me.CMDSell)
        Me.PNLShop.Controls.Add(Me.LSBShopSell)
        Me.PNLShop.Controls.Add(Me.LBLShopGold)
        Me.PNLShop.Controls.Add(Me.CMDBuy)
        Me.PNLShop.Controls.Add(Me.LSBShopBuy)
        Me.PNLShop.Location = New System.Drawing.Point(12, 45)
        Me.PNLShop.Name = "PNLShop"
        Me.PNLShop.Size = New System.Drawing.Size(960, 575)
        Me.PNLShop.TabIndex = 13
        Me.PNLShop.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(20, 338)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(30, 32)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 59
        Me.PictureBox2.TabStop = False
        '
        'GRBShopItemInfo
        '
        Me.GRBShopItemInfo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GRBShopItemInfo.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GRBShopItemInfo.Controls.Add(Me.LBLShopItemExtraMana)
        Me.GRBShopItemInfo.Controls.Add(Me.LBLShopItemExtraHealth)
        Me.GRBShopItemInfo.Controls.Add(Me.PCBShopItemIcon)
        Me.GRBShopItemInfo.Controls.Add(Me.PCBmnuGoldItemValue)
        Me.GRBShopItemInfo.Controls.Add(Me.LBLShopItemValue)
        Me.GRBShopItemInfo.Controls.Add(Me.LBLShopItemDamage)
        Me.GRBShopItemInfo.Controls.Add(Me.LBLmnuShopItemDamage)
        Me.GRBShopItemInfo.Controls.Add(Me.LBLShopItemDescription)
        Me.GRBShopItemInfo.Controls.Add(Me.LBLShopItemAC)
        Me.GRBShopItemInfo.Controls.Add(Me.LBLmnuShopItemAC)
        Me.GRBShopItemInfo.Controls.Add(Me.LBLShopItemType)
        Me.GRBShopItemInfo.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRBShopItemInfo.ForeColor = System.Drawing.Color.White
        Me.GRBShopItemInfo.Location = New System.Drawing.Point(706, 10)
        Me.GRBShopItemInfo.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GRBShopItemInfo.Name = "GRBShopItemInfo"
        Me.GRBShopItemInfo.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GRBShopItemInfo.Size = New System.Drawing.Size(236, 240)
        Me.GRBShopItemInfo.TabIndex = 57
        Me.GRBShopItemInfo.TabStop = False
        Me.GRBShopItemInfo.Text = "GRBShopItemInfo"
        Me.GRBShopItemInfo.Visible = False
        '
        'LBLShopItemExtraMana
        '
        Me.LBLShopItemExtraMana.AutoSize = True
        Me.LBLShopItemExtraMana.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLShopItemExtraMana.ForeColor = System.Drawing.Color.Green
        Me.LBLShopItemExtraMana.Location = New System.Drawing.Point(5, 124)
        Me.LBLShopItemExtraMana.Name = "LBLShopItemExtraMana"
        Me.LBLShopItemExtraMana.Size = New System.Drawing.Size(17, 18)
        Me.LBLShopItemExtraMana.TabIndex = 57
        Me.LBLShopItemExtraMana.Text = "0"
        '
        'LBLShopItemExtraHealth
        '
        Me.LBLShopItemExtraHealth.AutoSize = True
        Me.LBLShopItemExtraHealth.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLShopItemExtraHealth.ForeColor = System.Drawing.Color.Green
        Me.LBLShopItemExtraHealth.Location = New System.Drawing.Point(5, 96)
        Me.LBLShopItemExtraHealth.Name = "LBLShopItemExtraHealth"
        Me.LBLShopItemExtraHealth.Size = New System.Drawing.Size(17, 18)
        Me.LBLShopItemExtraHealth.TabIndex = 56
        Me.LBLShopItemExtraHealth.Text = "0"
        '
        'PCBShopItemIcon
        '
        Me.PCBShopItemIcon.Location = New System.Drawing.Point(170, 18)
        Me.PCBShopItemIcon.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.PCBShopItemIcon.Name = "PCBShopItemIcon"
        Me.PCBShopItemIcon.Size = New System.Drawing.Size(56, 61)
        Me.PCBShopItemIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PCBShopItemIcon.TabIndex = 54
        Me.PCBShopItemIcon.TabStop = False
        '
        'PCBmnuGoldItemValue
        '
        Me.PCBmnuGoldItemValue.Image = CType(resources.GetObject("PCBmnuGoldItemValue.Image"), System.Drawing.Image)
        Me.PCBmnuGoldItemValue.Location = New System.Drawing.Point(7, 215)
        Me.PCBmnuGoldItemValue.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.PCBmnuGoldItemValue.Name = "PCBmnuGoldItemValue"
        Me.PCBmnuGoldItemValue.Size = New System.Drawing.Size(15, 16)
        Me.PCBmnuGoldItemValue.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PCBmnuGoldItemValue.TabIndex = 55
        Me.PCBmnuGoldItemValue.TabStop = False
        '
        'LBLShopItemValue
        '
        Me.LBLShopItemValue.AutoSize = True
        Me.LBLShopItemValue.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLShopItemValue.ForeColor = System.Drawing.Color.White
        Me.LBLShopItemValue.Location = New System.Drawing.Point(27, 215)
        Me.LBLShopItemValue.Name = "LBLShopItemValue"
        Me.LBLShopItemValue.Size = New System.Drawing.Size(16, 16)
        Me.LBLShopItemValue.TabIndex = 53
        Me.LBLShopItemValue.Text = "0"
        '
        'LBLShopItemDamage
        '
        Me.LBLShopItemDamage.AutoSize = True
        Me.LBLShopItemDamage.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLShopItemDamage.ForeColor = System.Drawing.Color.White
        Me.LBLShopItemDamage.Location = New System.Drawing.Point(82, 68)
        Me.LBLShopItemDamage.Name = "LBLShopItemDamage"
        Me.LBLShopItemDamage.Size = New System.Drawing.Size(17, 18)
        Me.LBLShopItemDamage.TabIndex = 51
        Me.LBLShopItemDamage.Text = "0"
        '
        'LBLmnuShopItemDamage
        '
        Me.LBLmnuShopItemDamage.AutoSize = True
        Me.LBLmnuShopItemDamage.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLmnuShopItemDamage.ForeColor = System.Drawing.Color.White
        Me.LBLmnuShopItemDamage.Location = New System.Drawing.Point(4, 68)
        Me.LBLmnuShopItemDamage.Name = "LBLmnuShopItemDamage"
        Me.LBLmnuShopItemDamage.Size = New System.Drawing.Size(72, 19)
        Me.LBLmnuShopItemDamage.TabIndex = 50
        Me.LBLmnuShopItemDamage.Text = "Damage"
        '
        'LBLShopItemDescription
        '
        Me.LBLShopItemDescription.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLShopItemDescription.ForeColor = System.Drawing.Color.Coral
        Me.LBLShopItemDescription.Location = New System.Drawing.Point(5, 156)
        Me.LBLShopItemDescription.Name = "LBLShopItemDescription"
        Me.LBLShopItemDescription.Size = New System.Drawing.Size(225, 47)
        Me.LBLShopItemDescription.TabIndex = 45
        Me.LBLShopItemDescription.Text = "0"
        '
        'LBLShopItemAC
        '
        Me.LBLShopItemAC.AutoSize = True
        Me.LBLShopItemAC.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLShopItemAC.ForeColor = System.Drawing.Color.White
        Me.LBLShopItemAC.Location = New System.Drawing.Point(82, 43)
        Me.LBLShopItemAC.Name = "LBLShopItemAC"
        Me.LBLShopItemAC.Size = New System.Drawing.Size(17, 18)
        Me.LBLShopItemAC.TabIndex = 49
        Me.LBLShopItemAC.Text = "0"
        '
        'LBLmnuShopItemAC
        '
        Me.LBLmnuShopItemAC.AutoSize = True
        Me.LBLmnuShopItemAC.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLmnuShopItemAC.ForeColor = System.Drawing.Color.White
        Me.LBLmnuShopItemAC.Location = New System.Drawing.Point(4, 43)
        Me.LBLmnuShopItemAC.Name = "LBLmnuShopItemAC"
        Me.LBLmnuShopItemAC.Size = New System.Drawing.Size(32, 19)
        Me.LBLmnuShopItemAC.TabIndex = 48
        Me.LBLmnuShopItemAC.Text = "AC"
        '
        'LBLShopItemType
        '
        Me.LBLShopItemType.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLShopItemType.ForeColor = System.Drawing.Color.White
        Me.LBLShopItemType.Location = New System.Drawing.Point(119, 80)
        Me.LBLShopItemType.Name = "LBLShopItemType"
        Me.LBLShopItemType.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.LBLShopItemType.Size = New System.Drawing.Size(100, 19)
        Me.LBLShopItemType.TabIndex = 43
        Me.LBLShopItemType.Text = "0"
        '
        'CMDSell
        '
        Me.CMDSell.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CMDSell.BackColor = System.Drawing.Color.Maroon
        Me.CMDSell.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDSell.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDSell.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDSell.ForeColor = System.Drawing.Color.White
        Me.CMDSell.Location = New System.Drawing.Point(579, 318)
        Me.CMDSell.Name = "CMDSell"
        Me.CMDSell.Size = New System.Drawing.Size(123, 49)
        Me.CMDSell.TabIndex = 43
        Me.CMDSell.Text = "Sell"
        Me.CMDSell.UseVisualStyleBackColor = False
        '
        'LSBShopSell
        '
        Me.LSBShopSell.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LSBShopSell.BackColor = System.Drawing.Color.Maroon
        Me.LSBShopSell.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LSBShopSell.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LSBShopSell.ForeColor = System.Drawing.Color.White
        Me.LSBShopSell.FormattingEnabled = True
        Me.LSBShopSell.ItemHeight = 18
        Me.LSBShopSell.Location = New System.Drawing.Point(20, 373)
        Me.LSBShopSell.Name = "LSBShopSell"
        Me.LSBShopSell.Size = New System.Drawing.Size(684, 220)
        Me.LSBShopSell.TabIndex = 42
        '
        'LBLShopGold
        '
        Me.LBLShopGold.AutoSize = True
        Me.LBLShopGold.Font = New System.Drawing.Font("Arial", 19.8!, System.Drawing.FontStyle.Bold)
        Me.LBLShopGold.ForeColor = System.Drawing.Color.White
        Me.LBLShopGold.Location = New System.Drawing.Point(53, 340)
        Me.LBLShopGold.Name = "LBLShopGold"
        Me.LBLShopGold.Size = New System.Drawing.Size(30, 32)
        Me.LBLShopGold.TabIndex = 41
        Me.LBLShopGold.Text = "0"
        '
        'CMDBuy
        '
        Me.CMDBuy.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CMDBuy.BackColor = System.Drawing.Color.Maroon
        Me.CMDBuy.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDBuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDBuy.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDBuy.ForeColor = System.Drawing.Color.White
        Me.CMDBuy.Location = New System.Drawing.Point(579, 254)
        Me.CMDBuy.Name = "CMDBuy"
        Me.CMDBuy.Size = New System.Drawing.Size(123, 49)
        Me.CMDBuy.TabIndex = 27
        Me.CMDBuy.Text = "Buy"
        Me.CMDBuy.UseVisualStyleBackColor = False
        '
        'LSBShopBuy
        '
        Me.LSBShopBuy.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LSBShopBuy.BackColor = System.Drawing.Color.Maroon
        Me.LSBShopBuy.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LSBShopBuy.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LSBShopBuy.ForeColor = System.Drawing.Color.White
        Me.LSBShopBuy.FormattingEnabled = True
        Me.LSBShopBuy.ItemHeight = 18
        Me.LSBShopBuy.Location = New System.Drawing.Point(18, 10)
        Me.LSBShopBuy.Name = "LSBShopBuy"
        Me.LSBShopBuy.Size = New System.Drawing.Size(684, 220)
        Me.LSBShopBuy.TabIndex = 23
        '
        'PNLSettings
        '
        Me.PNLSettings.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PNLSettings.Controls.Add(Me.Label1)
        Me.PNLSettings.Controls.Add(Me.CMDMuteSfx)
        Me.PNLSettings.Controls.Add(Me.CMDMuteMusic)
        Me.PNLSettings.Controls.Add(Me.LBLVolume)
        Me.PNLSettings.Controls.Add(Me.CMDSave)
        Me.PNLSettings.Controls.Add(Me.CMDResetSave)
        Me.PNLSettings.Controls.Add(Me.TCBMusicVolume)
        Me.PNLSettings.Controls.Add(Me.CMDConsole)
        Me.PNLSettings.Location = New System.Drawing.Point(783, 40)
        Me.PNLSettings.Name = "PNLSettings"
        Me.PNLSettings.Size = New System.Drawing.Size(200, 218)
        Me.PNLSettings.TabIndex = 9
        Me.PNLSettings.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(32, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 16)
        Me.Label1.TabIndex = 46
        Me.Label1.Text = "Mute SFX"
        '
        'CMDMuteSfx
        '
        Me.CMDMuteSfx.BackColor = System.Drawing.Color.FromArgb(CType(CType(122, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.CMDMuteSfx.BackgroundImage = CType(resources.GetObject("CMDMuteSfx.BackgroundImage"), System.Drawing.Image)
        Me.CMDMuteSfx.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.CMDMuteSfx.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDMuteSfx.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDMuteSfx.Font = New System.Drawing.Font("Symbol", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.CMDMuteSfx.ForeColor = System.Drawing.Color.White
        Me.CMDMuteSfx.Location = New System.Drawing.Point(6, 54)
        Me.CMDMuteSfx.Name = "CMDMuteSfx"
        Me.CMDMuteSfx.Size = New System.Drawing.Size(20, 20)
        Me.CMDMuteSfx.TabIndex = 45
        Me.CMDMuteSfx.UseVisualStyleBackColor = False
        '
        'CMDMuteMusic
        '
        Me.CMDMuteMusic.BackColor = System.Drawing.Color.FromArgb(CType(CType(122, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.CMDMuteMusic.BackgroundImage = CType(resources.GetObject("CMDMuteMusic.BackgroundImage"), System.Drawing.Image)
        Me.CMDMuteMusic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.CMDMuteMusic.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDMuteMusic.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDMuteMusic.Font = New System.Drawing.Font("Symbol", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.CMDMuteMusic.ForeColor = System.Drawing.Color.White
        Me.CMDMuteMusic.Location = New System.Drawing.Point(6, 20)
        Me.CMDMuteMusic.Name = "CMDMuteMusic"
        Me.CMDMuteMusic.Size = New System.Drawing.Size(20, 20)
        Me.CMDMuteMusic.TabIndex = 44
        Me.CMDMuteMusic.UseVisualStyleBackColor = False
        '
        'LBLVolume
        '
        Me.LBLVolume.AutoSize = True
        Me.LBLVolume.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLVolume.ForeColor = System.Drawing.Color.White
        Me.LBLVolume.Location = New System.Drawing.Point(24, 3)
        Me.LBLVolume.Name = "LBLVolume"
        Me.LBLVolume.Size = New System.Drawing.Size(112, 16)
        Me.LBLVolume.TabIndex = 42
        Me.LBLVolume.Text = "Music Volume: 20"
        '
        'TCBMusicVolume
        '
        Me.TCBMusicVolume.Cursor = System.Windows.Forms.Cursors.SizeWE
        Me.TCBMusicVolume.LargeChange = 1
        Me.TCBMusicVolume.Location = New System.Drawing.Point(24, 20)
        Me.TCBMusicVolume.Maximum = 100
        Me.TCBMusicVolume.Name = "TCBMusicVolume"
        Me.TCBMusicVolume.Size = New System.Drawing.Size(169, 45)
        Me.TCBMusicVolume.TabIndex = 43
        Me.TCBMusicVolume.TickFrequency = 0
        Me.TCBMusicVolume.Value = 20
        '
        'PNLMasteries
        '
        Me.PNLMasteries.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PNLMasteries.AutoScroll = True
        Me.PNLMasteries.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.PNLMasteries.Controls.Add(Me.LBLMasteryDescription)
        Me.PNLMasteries.Controls.Add(Me.LBLMasteryTitle)
        Me.PNLMasteries.Controls.Add(Me.PCBMasteryTier_6_1)
        Me.PNLMasteries.Controls.Add(Me.PCBMasteryTier_5_2)
        Me.PNLMasteries.Controls.Add(Me.PCBMasteryTier_5_1)
        Me.PNLMasteries.Controls.Add(Me.PCBMasteryTier_4_2)
        Me.PNLMasteries.Controls.Add(Me.PCBMasteryTier_4_1)
        Me.PNLMasteries.Controls.Add(Me.PCBMasteryTier_3_3)
        Me.PNLMasteries.Controls.Add(Me.PCBMasteryTier_3_2)
        Me.PNLMasteries.Controls.Add(Me.PCBMasteryTier_3_1)
        Me.PNLMasteries.Controls.Add(Me.PCBMasteryTier_2_2)
        Me.PNLMasteries.Controls.Add(Me.PCBMasteryTier_2_1)
        Me.PNLMasteries.Controls.Add(Me.PCBMasteryTier_1_3)
        Me.PNLMasteries.Controls.Add(Me.PCBMasteryTier_1_2)
        Me.PNLMasteries.Controls.Add(Me.PCBMasteryTier_1_1)
        Me.PNLMasteries.Controls.Add(Me.LBLMastery11MaxScore)
        Me.PNLMasteries.Controls.Add(Me.LBLMastery12MaxScore)
        Me.PNLMasteries.Controls.Add(Me.LBLMastery13MaxScore)
        Me.PNLMasteries.Controls.Add(Me.LBLMastery21MaxScore)
        Me.PNLMasteries.Controls.Add(Me.LBLMastery22MaxScore)
        Me.PNLMasteries.Controls.Add(Me.LBLMastery31MaxScore)
        Me.PNLMasteries.Controls.Add(Me.LBLMastery32MaxScore)
        Me.PNLMasteries.Controls.Add(Me.LBLMastery33MaxScore)
        Me.PNLMasteries.Controls.Add(Me.LBLMastery41MaxScore)
        Me.PNLMasteries.Controls.Add(Me.LBLMastery42MaxScore)
        Me.PNLMasteries.Controls.Add(Me.LBLMastery51MaxScore)
        Me.PNLMasteries.Controls.Add(Me.LBLMastery52MaxScore)
        Me.PNLMasteries.Controls.Add(Me.LBLMastery61MaxScore)
        Me.PNLMasteries.Controls.Add(Me.LBLMastery11Score)
        Me.PNLMasteries.Controls.Add(Me.LBLMastery12Score)
        Me.PNLMasteries.Controls.Add(Me.LBLMastery13Score)
        Me.PNLMasteries.Controls.Add(Me.LBLMastery21Score)
        Me.PNLMasteries.Controls.Add(Me.LBLMastery22Score)
        Me.PNLMasteries.Controls.Add(Me.LBLMastery31Score)
        Me.PNLMasteries.Controls.Add(Me.LBLMastery32Score)
        Me.PNLMasteries.Controls.Add(Me.LBLMastery33Score)
        Me.PNLMasteries.Controls.Add(Me.LBLMastery41Score)
        Me.PNLMasteries.Controls.Add(Me.LBLMastery42Score)
        Me.PNLMasteries.Controls.Add(Me.LBLMastery51Score)
        Me.PNLMasteries.Controls.Add(Me.LBLMastery52Score)
        Me.PNLMasteries.Controls.Add(Me.LBLMastery61Score)
        Me.PNLMasteries.Location = New System.Drawing.Point(12, 45)
        Me.PNLMasteries.Name = "PNLMasteries"
        Me.PNLMasteries.Size = New System.Drawing.Size(960, 575)
        Me.PNLMasteries.TabIndex = 14
        Me.PNLMasteries.Visible = False
        '
        'LBLMasteryDescription
        '
        Me.LBLMasteryDescription.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLMasteryDescription.ForeColor = System.Drawing.Color.White
        Me.LBLMasteryDescription.Location = New System.Drawing.Point(44, 56)
        Me.LBLMasteryDescription.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LBLMasteryDescription.Name = "LBLMasteryDescription"
        Me.LBLMasteryDescription.Size = New System.Drawing.Size(262, 99)
        Me.LBLMasteryDescription.TabIndex = 70
        Me.LBLMasteryDescription.Text = "Mastery Description"
        '
        'LBLMasteryTitle
        '
        Me.LBLMasteryTitle.Font = New System.Drawing.Font("Arial", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLMasteryTitle.ForeColor = System.Drawing.Color.White
        Me.LBLMasteryTitle.Location = New System.Drawing.Point(42, 32)
        Me.LBLMasteryTitle.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LBLMasteryTitle.Name = "LBLMasteryTitle"
        Me.LBLMasteryTitle.Size = New System.Drawing.Size(260, 24)
        Me.LBLMasteryTitle.TabIndex = 69
        Me.LBLMasteryTitle.Text = "Mastery Title"
        '
        'PCBMasteryTier_6_1
        '
        Me.PCBMasteryTier_6_1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.PCBMasteryTier_6_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PCBMasteryTier_6_1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PCBMasteryTier_6_1.Enabled = False
        Me.PCBMasteryTier_6_1.Image = CType(resources.GetObject("PCBMasteryTier_6_1.Image"), System.Drawing.Image)
        Me.PCBMasteryTier_6_1.Location = New System.Drawing.Point(455, 430)
        Me.PCBMasteryTier_6_1.Name = "PCBMasteryTier_6_1"
        Me.PCBMasteryTier_6_1.Size = New System.Drawing.Size(50, 50)
        Me.PCBMasteryTier_6_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PCBMasteryTier_6_1.TabIndex = 12
        Me.PCBMasteryTier_6_1.TabStop = False
        '
        'PCBMasteryTier_5_2
        '
        Me.PCBMasteryTier_5_2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.PCBMasteryTier_5_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PCBMasteryTier_5_2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PCBMasteryTier_5_2.Enabled = False
        Me.PCBMasteryTier_5_2.Image = CType(resources.GetObject("PCBMasteryTier_5_2.Image"), System.Drawing.Image)
        Me.PCBMasteryTier_5_2.Location = New System.Drawing.Point(505, 350)
        Me.PCBMasteryTier_5_2.Name = "PCBMasteryTier_5_2"
        Me.PCBMasteryTier_5_2.Size = New System.Drawing.Size(50, 50)
        Me.PCBMasteryTier_5_2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PCBMasteryTier_5_2.TabIndex = 11
        Me.PCBMasteryTier_5_2.TabStop = False
        '
        'PCBMasteryTier_5_1
        '
        Me.PCBMasteryTier_5_1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.PCBMasteryTier_5_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PCBMasteryTier_5_1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PCBMasteryTier_5_1.Enabled = False
        Me.PCBMasteryTier_5_1.Image = CType(resources.GetObject("PCBMasteryTier_5_1.Image"), System.Drawing.Image)
        Me.PCBMasteryTier_5_1.Location = New System.Drawing.Point(405, 350)
        Me.PCBMasteryTier_5_1.Name = "PCBMasteryTier_5_1"
        Me.PCBMasteryTier_5_1.Size = New System.Drawing.Size(50, 50)
        Me.PCBMasteryTier_5_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PCBMasteryTier_5_1.TabIndex = 10
        Me.PCBMasteryTier_5_1.TabStop = False
        '
        'PCBMasteryTier_4_2
        '
        Me.PCBMasteryTier_4_2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.PCBMasteryTier_4_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PCBMasteryTier_4_2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PCBMasteryTier_4_2.Enabled = False
        Me.PCBMasteryTier_4_2.Image = CType(resources.GetObject("PCBMasteryTier_4_2.Image"), System.Drawing.Image)
        Me.PCBMasteryTier_4_2.Location = New System.Drawing.Point(505, 270)
        Me.PCBMasteryTier_4_2.Name = "PCBMasteryTier_4_2"
        Me.PCBMasteryTier_4_2.Size = New System.Drawing.Size(50, 50)
        Me.PCBMasteryTier_4_2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PCBMasteryTier_4_2.TabIndex = 9
        Me.PCBMasteryTier_4_2.TabStop = False
        '
        'PCBMasteryTier_4_1
        '
        Me.PCBMasteryTier_4_1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.PCBMasteryTier_4_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PCBMasteryTier_4_1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PCBMasteryTier_4_1.Enabled = False
        Me.PCBMasteryTier_4_1.Image = CType(resources.GetObject("PCBMasteryTier_4_1.Image"), System.Drawing.Image)
        Me.PCBMasteryTier_4_1.Location = New System.Drawing.Point(405, 270)
        Me.PCBMasteryTier_4_1.Name = "PCBMasteryTier_4_1"
        Me.PCBMasteryTier_4_1.Size = New System.Drawing.Size(50, 50)
        Me.PCBMasteryTier_4_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PCBMasteryTier_4_1.TabIndex = 8
        Me.PCBMasteryTier_4_1.TabStop = False
        '
        'PCBMasteryTier_3_3
        '
        Me.PCBMasteryTier_3_3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.PCBMasteryTier_3_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PCBMasteryTier_3_3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PCBMasteryTier_3_3.Enabled = False
        Me.PCBMasteryTier_3_3.Image = CType(resources.GetObject("PCBMasteryTier_3_3.Image"), System.Drawing.Image)
        Me.PCBMasteryTier_3_3.Location = New System.Drawing.Point(555, 190)
        Me.PCBMasteryTier_3_3.Name = "PCBMasteryTier_3_3"
        Me.PCBMasteryTier_3_3.Size = New System.Drawing.Size(50, 50)
        Me.PCBMasteryTier_3_3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PCBMasteryTier_3_3.TabIndex = 7
        Me.PCBMasteryTier_3_3.TabStop = False
        '
        'PCBMasteryTier_3_2
        '
        Me.PCBMasteryTier_3_2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.PCBMasteryTier_3_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PCBMasteryTier_3_2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PCBMasteryTier_3_2.Enabled = False
        Me.PCBMasteryTier_3_2.Image = CType(resources.GetObject("PCBMasteryTier_3_2.Image"), System.Drawing.Image)
        Me.PCBMasteryTier_3_2.Location = New System.Drawing.Point(455, 190)
        Me.PCBMasteryTier_3_2.Name = "PCBMasteryTier_3_2"
        Me.PCBMasteryTier_3_2.Size = New System.Drawing.Size(50, 50)
        Me.PCBMasteryTier_3_2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PCBMasteryTier_3_2.TabIndex = 6
        Me.PCBMasteryTier_3_2.TabStop = False
        '
        'PCBMasteryTier_3_1
        '
        Me.PCBMasteryTier_3_1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.PCBMasteryTier_3_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PCBMasteryTier_3_1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PCBMasteryTier_3_1.Enabled = False
        Me.PCBMasteryTier_3_1.Image = CType(resources.GetObject("PCBMasteryTier_3_1.Image"), System.Drawing.Image)
        Me.PCBMasteryTier_3_1.Location = New System.Drawing.Point(355, 190)
        Me.PCBMasteryTier_3_1.Name = "PCBMasteryTier_3_1"
        Me.PCBMasteryTier_3_1.Size = New System.Drawing.Size(50, 50)
        Me.PCBMasteryTier_3_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PCBMasteryTier_3_1.TabIndex = 5
        Me.PCBMasteryTier_3_1.TabStop = False
        '
        'PCBMasteryTier_2_2
        '
        Me.PCBMasteryTier_2_2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.PCBMasteryTier_2_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PCBMasteryTier_2_2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PCBMasteryTier_2_2.Enabled = False
        Me.PCBMasteryTier_2_2.Image = CType(resources.GetObject("PCBMasteryTier_2_2.Image"), System.Drawing.Image)
        Me.PCBMasteryTier_2_2.Location = New System.Drawing.Point(505, 110)
        Me.PCBMasteryTier_2_2.Name = "PCBMasteryTier_2_2"
        Me.PCBMasteryTier_2_2.Size = New System.Drawing.Size(50, 50)
        Me.PCBMasteryTier_2_2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PCBMasteryTier_2_2.TabIndex = 4
        Me.PCBMasteryTier_2_2.TabStop = False
        '
        'PCBMasteryTier_2_1
        '
        Me.PCBMasteryTier_2_1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.PCBMasteryTier_2_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PCBMasteryTier_2_1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PCBMasteryTier_2_1.Enabled = False
        Me.PCBMasteryTier_2_1.Image = CType(resources.GetObject("PCBMasteryTier_2_1.Image"), System.Drawing.Image)
        Me.PCBMasteryTier_2_1.Location = New System.Drawing.Point(405, 110)
        Me.PCBMasteryTier_2_1.Name = "PCBMasteryTier_2_1"
        Me.PCBMasteryTier_2_1.Size = New System.Drawing.Size(50, 50)
        Me.PCBMasteryTier_2_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PCBMasteryTier_2_1.TabIndex = 3
        Me.PCBMasteryTier_2_1.TabStop = False
        '
        'PCBMasteryTier_1_3
        '
        Me.PCBMasteryTier_1_3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.PCBMasteryTier_1_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PCBMasteryTier_1_3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PCBMasteryTier_1_3.Image = CType(resources.GetObject("PCBMasteryTier_1_3.Image"), System.Drawing.Image)
        Me.PCBMasteryTier_1_3.Location = New System.Drawing.Point(555, 30)
        Me.PCBMasteryTier_1_3.Name = "PCBMasteryTier_1_3"
        Me.PCBMasteryTier_1_3.Size = New System.Drawing.Size(50, 50)
        Me.PCBMasteryTier_1_3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PCBMasteryTier_1_3.TabIndex = 2
        Me.PCBMasteryTier_1_3.TabStop = False
        '
        'PCBMasteryTier_1_2
        '
        Me.PCBMasteryTier_1_2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.PCBMasteryTier_1_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PCBMasteryTier_1_2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PCBMasteryTier_1_2.Image = CType(resources.GetObject("PCBMasteryTier_1_2.Image"), System.Drawing.Image)
        Me.PCBMasteryTier_1_2.Location = New System.Drawing.Point(455, 30)
        Me.PCBMasteryTier_1_2.Name = "PCBMasteryTier_1_2"
        Me.PCBMasteryTier_1_2.Size = New System.Drawing.Size(50, 50)
        Me.PCBMasteryTier_1_2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PCBMasteryTier_1_2.TabIndex = 1
        Me.PCBMasteryTier_1_2.TabStop = False
        '
        'PCBMasteryTier_1_1
        '
        Me.PCBMasteryTier_1_1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.PCBMasteryTier_1_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PCBMasteryTier_1_1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PCBMasteryTier_1_1.Image = CType(resources.GetObject("PCBMasteryTier_1_1.Image"), System.Drawing.Image)
        Me.PCBMasteryTier_1_1.Location = New System.Drawing.Point(355, 30)
        Me.PCBMasteryTier_1_1.Name = "PCBMasteryTier_1_1"
        Me.PCBMasteryTier_1_1.Size = New System.Drawing.Size(50, 50)
        Me.PCBMasteryTier_1_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PCBMasteryTier_1_1.TabIndex = 0
        Me.PCBMasteryTier_1_1.TabStop = False
        '
        'LBLMastery11MaxScore
        '
        Me.LBLMastery11MaxScore.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LBLMastery11MaxScore.AutoSize = True
        Me.LBLMastery11MaxScore.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLMastery11MaxScore.ForeColor = System.Drawing.Color.White
        Me.LBLMastery11MaxScore.Location = New System.Drawing.Point(376, 80)
        Me.LBLMastery11MaxScore.Name = "LBLMastery11MaxScore"
        Me.LBLMastery11MaxScore.Size = New System.Drawing.Size(19, 16)
        Me.LBLMastery11MaxScore.TabIndex = 56
        Me.LBLMastery11MaxScore.Text = "/9"
        '
        'LBLMastery12MaxScore
        '
        Me.LBLMastery12MaxScore.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LBLMastery12MaxScore.AutoSize = True
        Me.LBLMastery12MaxScore.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLMastery12MaxScore.ForeColor = System.Drawing.Color.White
        Me.LBLMastery12MaxScore.Location = New System.Drawing.Point(477, 80)
        Me.LBLMastery12MaxScore.Name = "LBLMastery12MaxScore"
        Me.LBLMastery12MaxScore.Size = New System.Drawing.Size(19, 16)
        Me.LBLMastery12MaxScore.TabIndex = 57
        Me.LBLMastery12MaxScore.Text = "/5"
        '
        'LBLMastery13MaxScore
        '
        Me.LBLMastery13MaxScore.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LBLMastery13MaxScore.AutoSize = True
        Me.LBLMastery13MaxScore.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLMastery13MaxScore.ForeColor = System.Drawing.Color.White
        Me.LBLMastery13MaxScore.Location = New System.Drawing.Point(578, 80)
        Me.LBLMastery13MaxScore.Name = "LBLMastery13MaxScore"
        Me.LBLMastery13MaxScore.Size = New System.Drawing.Size(19, 16)
        Me.LBLMastery13MaxScore.TabIndex = 58
        Me.LBLMastery13MaxScore.Text = "/5"
        '
        'LBLMastery21MaxScore
        '
        Me.LBLMastery21MaxScore.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LBLMastery21MaxScore.AutoSize = True
        Me.LBLMastery21MaxScore.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLMastery21MaxScore.ForeColor = System.Drawing.Color.White
        Me.LBLMastery21MaxScore.Location = New System.Drawing.Point(426, 158)
        Me.LBLMastery21MaxScore.Name = "LBLMastery21MaxScore"
        Me.LBLMastery21MaxScore.Size = New System.Drawing.Size(19, 16)
        Me.LBLMastery21MaxScore.TabIndex = 59
        Me.LBLMastery21MaxScore.Text = "/3"
        '
        'LBLMastery22MaxScore
        '
        Me.LBLMastery22MaxScore.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LBLMastery22MaxScore.AutoSize = True
        Me.LBLMastery22MaxScore.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLMastery22MaxScore.ForeColor = System.Drawing.Color.White
        Me.LBLMastery22MaxScore.Location = New System.Drawing.Point(526, 158)
        Me.LBLMastery22MaxScore.Name = "LBLMastery22MaxScore"
        Me.LBLMastery22MaxScore.Size = New System.Drawing.Size(19, 16)
        Me.LBLMastery22MaxScore.TabIndex = 60
        Me.LBLMastery22MaxScore.Text = "/5"
        '
        'LBLMastery31MaxScore
        '
        Me.LBLMastery31MaxScore.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LBLMastery31MaxScore.AutoSize = True
        Me.LBLMastery31MaxScore.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLMastery31MaxScore.ForeColor = System.Drawing.Color.White
        Me.LBLMastery31MaxScore.Location = New System.Drawing.Point(376, 240)
        Me.LBLMastery31MaxScore.Name = "LBLMastery31MaxScore"
        Me.LBLMastery31MaxScore.Size = New System.Drawing.Size(19, 16)
        Me.LBLMastery31MaxScore.TabIndex = 61
        Me.LBLMastery31MaxScore.Text = "/3"
        '
        'LBLMastery32MaxScore
        '
        Me.LBLMastery32MaxScore.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LBLMastery32MaxScore.AutoSize = True
        Me.LBLMastery32MaxScore.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLMastery32MaxScore.ForeColor = System.Drawing.Color.White
        Me.LBLMastery32MaxScore.Location = New System.Drawing.Point(477, 240)
        Me.LBLMastery32MaxScore.Name = "LBLMastery32MaxScore"
        Me.LBLMastery32MaxScore.Size = New System.Drawing.Size(19, 16)
        Me.LBLMastery32MaxScore.TabIndex = 62
        Me.LBLMastery32MaxScore.Text = "/3"
        '
        'LBLMastery33MaxScore
        '
        Me.LBLMastery33MaxScore.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LBLMastery33MaxScore.AutoSize = True
        Me.LBLMastery33MaxScore.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLMastery33MaxScore.ForeColor = System.Drawing.Color.White
        Me.LBLMastery33MaxScore.Location = New System.Drawing.Point(577, 240)
        Me.LBLMastery33MaxScore.Name = "LBLMastery33MaxScore"
        Me.LBLMastery33MaxScore.Size = New System.Drawing.Size(19, 16)
        Me.LBLMastery33MaxScore.TabIndex = 63
        Me.LBLMastery33MaxScore.Text = "/3"
        '
        'LBLMastery41MaxScore
        '
        Me.LBLMastery41MaxScore.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LBLMastery41MaxScore.AutoSize = True
        Me.LBLMastery41MaxScore.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLMastery41MaxScore.ForeColor = System.Drawing.Color.White
        Me.LBLMastery41MaxScore.Location = New System.Drawing.Point(425, 318)
        Me.LBLMastery41MaxScore.Name = "LBLMastery41MaxScore"
        Me.LBLMastery41MaxScore.Size = New System.Drawing.Size(19, 16)
        Me.LBLMastery41MaxScore.TabIndex = 64
        Me.LBLMastery41MaxScore.Text = "/3"
        '
        'LBLMastery42MaxScore
        '
        Me.LBLMastery42MaxScore.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LBLMastery42MaxScore.AutoSize = True
        Me.LBLMastery42MaxScore.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLMastery42MaxScore.ForeColor = System.Drawing.Color.White
        Me.LBLMastery42MaxScore.Location = New System.Drawing.Point(527, 318)
        Me.LBLMastery42MaxScore.Name = "LBLMastery42MaxScore"
        Me.LBLMastery42MaxScore.Size = New System.Drawing.Size(19, 16)
        Me.LBLMastery42MaxScore.TabIndex = 65
        Me.LBLMastery42MaxScore.Text = "/3"
        '
        'LBLMastery51MaxScore
        '
        Me.LBLMastery51MaxScore.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LBLMastery51MaxScore.AutoSize = True
        Me.LBLMastery51MaxScore.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLMastery51MaxScore.ForeColor = System.Drawing.Color.White
        Me.LBLMastery51MaxScore.Location = New System.Drawing.Point(427, 399)
        Me.LBLMastery51MaxScore.Name = "LBLMastery51MaxScore"
        Me.LBLMastery51MaxScore.Size = New System.Drawing.Size(19, 16)
        Me.LBLMastery51MaxScore.TabIndex = 66
        Me.LBLMastery51MaxScore.Text = "/5"
        '
        'LBLMastery52MaxScore
        '
        Me.LBLMastery52MaxScore.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LBLMastery52MaxScore.AutoSize = True
        Me.LBLMastery52MaxScore.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLMastery52MaxScore.ForeColor = System.Drawing.Color.White
        Me.LBLMastery52MaxScore.Location = New System.Drawing.Point(527, 399)
        Me.LBLMastery52MaxScore.Name = "LBLMastery52MaxScore"
        Me.LBLMastery52MaxScore.Size = New System.Drawing.Size(19, 16)
        Me.LBLMastery52MaxScore.TabIndex = 67
        Me.LBLMastery52MaxScore.Text = "/2"
        '
        'LBLMastery61MaxScore
        '
        Me.LBLMastery61MaxScore.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LBLMastery61MaxScore.AutoSize = True
        Me.LBLMastery61MaxScore.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLMastery61MaxScore.ForeColor = System.Drawing.Color.White
        Me.LBLMastery61MaxScore.Location = New System.Drawing.Point(477, 479)
        Me.LBLMastery61MaxScore.Name = "LBLMastery61MaxScore"
        Me.LBLMastery61MaxScore.Size = New System.Drawing.Size(19, 16)
        Me.LBLMastery61MaxScore.TabIndex = 68
        Me.LBLMastery61MaxScore.Text = "/5"
        '
        'LBLMastery11Score
        '
        Me.LBLMastery11Score.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LBLMastery11Score.AutoSize = True
        Me.LBLMastery11Score.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLMastery11Score.ForeColor = System.Drawing.Color.White
        Me.LBLMastery11Score.Location = New System.Drawing.Point(367, 80)
        Me.LBLMastery11Score.Name = "LBLMastery11Score"
        Me.LBLMastery11Score.Size = New System.Drawing.Size(15, 16)
        Me.LBLMastery11Score.TabIndex = 43
        Me.LBLMastery11Score.Text = "0"
        '
        'LBLMastery12Score
        '
        Me.LBLMastery12Score.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LBLMastery12Score.AutoSize = True
        Me.LBLMastery12Score.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLMastery12Score.ForeColor = System.Drawing.Color.White
        Me.LBLMastery12Score.Location = New System.Drawing.Point(467, 80)
        Me.LBLMastery12Score.Name = "LBLMastery12Score"
        Me.LBLMastery12Score.Size = New System.Drawing.Size(15, 16)
        Me.LBLMastery12Score.TabIndex = 44
        Me.LBLMastery12Score.Text = "0"
        '
        'LBLMastery13Score
        '
        Me.LBLMastery13Score.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LBLMastery13Score.AutoSize = True
        Me.LBLMastery13Score.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLMastery13Score.ForeColor = System.Drawing.Color.White
        Me.LBLMastery13Score.Location = New System.Drawing.Point(568, 80)
        Me.LBLMastery13Score.Name = "LBLMastery13Score"
        Me.LBLMastery13Score.Size = New System.Drawing.Size(15, 16)
        Me.LBLMastery13Score.TabIndex = 45
        Me.LBLMastery13Score.Text = "0"
        '
        'LBLMastery21Score
        '
        Me.LBLMastery21Score.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LBLMastery21Score.AutoSize = True
        Me.LBLMastery21Score.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLMastery21Score.ForeColor = System.Drawing.Color.White
        Me.LBLMastery21Score.Location = New System.Drawing.Point(417, 158)
        Me.LBLMastery21Score.Name = "LBLMastery21Score"
        Me.LBLMastery21Score.Size = New System.Drawing.Size(15, 16)
        Me.LBLMastery21Score.TabIndex = 46
        Me.LBLMastery21Score.Text = "0"
        '
        'LBLMastery22Score
        '
        Me.LBLMastery22Score.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LBLMastery22Score.AutoSize = True
        Me.LBLMastery22Score.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLMastery22Score.ForeColor = System.Drawing.Color.White
        Me.LBLMastery22Score.Location = New System.Drawing.Point(516, 158)
        Me.LBLMastery22Score.Name = "LBLMastery22Score"
        Me.LBLMastery22Score.Size = New System.Drawing.Size(15, 16)
        Me.LBLMastery22Score.TabIndex = 47
        Me.LBLMastery22Score.Text = "0"
        '
        'LBLMastery31Score
        '
        Me.LBLMastery31Score.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LBLMastery31Score.AutoSize = True
        Me.LBLMastery31Score.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLMastery31Score.ForeColor = System.Drawing.Color.White
        Me.LBLMastery31Score.Location = New System.Drawing.Point(367, 240)
        Me.LBLMastery31Score.Name = "LBLMastery31Score"
        Me.LBLMastery31Score.Size = New System.Drawing.Size(15, 16)
        Me.LBLMastery31Score.TabIndex = 48
        Me.LBLMastery31Score.Text = "0"
        '
        'LBLMastery32Score
        '
        Me.LBLMastery32Score.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LBLMastery32Score.AutoSize = True
        Me.LBLMastery32Score.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLMastery32Score.ForeColor = System.Drawing.Color.White
        Me.LBLMastery32Score.Location = New System.Drawing.Point(467, 240)
        Me.LBLMastery32Score.Name = "LBLMastery32Score"
        Me.LBLMastery32Score.Size = New System.Drawing.Size(15, 16)
        Me.LBLMastery32Score.TabIndex = 49
        Me.LBLMastery32Score.Text = "0"
        '
        'LBLMastery33Score
        '
        Me.LBLMastery33Score.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LBLMastery33Score.AutoSize = True
        Me.LBLMastery33Score.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLMastery33Score.ForeColor = System.Drawing.Color.White
        Me.LBLMastery33Score.Location = New System.Drawing.Point(567, 240)
        Me.LBLMastery33Score.Name = "LBLMastery33Score"
        Me.LBLMastery33Score.Size = New System.Drawing.Size(15, 16)
        Me.LBLMastery33Score.TabIndex = 50
        Me.LBLMastery33Score.Text = "0"
        '
        'LBLMastery41Score
        '
        Me.LBLMastery41Score.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LBLMastery41Score.AutoSize = True
        Me.LBLMastery41Score.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLMastery41Score.ForeColor = System.Drawing.Color.White
        Me.LBLMastery41Score.Location = New System.Drawing.Point(416, 318)
        Me.LBLMastery41Score.Name = "LBLMastery41Score"
        Me.LBLMastery41Score.Size = New System.Drawing.Size(15, 16)
        Me.LBLMastery41Score.TabIndex = 51
        Me.LBLMastery41Score.Text = "0"
        '
        'LBLMastery42Score
        '
        Me.LBLMastery42Score.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LBLMastery42Score.AutoSize = True
        Me.LBLMastery42Score.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLMastery42Score.ForeColor = System.Drawing.Color.White
        Me.LBLMastery42Score.Location = New System.Drawing.Point(518, 318)
        Me.LBLMastery42Score.Name = "LBLMastery42Score"
        Me.LBLMastery42Score.Size = New System.Drawing.Size(15, 16)
        Me.LBLMastery42Score.TabIndex = 52
        Me.LBLMastery42Score.Text = "0"
        '
        'LBLMastery51Score
        '
        Me.LBLMastery51Score.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LBLMastery51Score.AutoSize = True
        Me.LBLMastery51Score.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLMastery51Score.ForeColor = System.Drawing.Color.White
        Me.LBLMastery51Score.Location = New System.Drawing.Point(417, 399)
        Me.LBLMastery51Score.Name = "LBLMastery51Score"
        Me.LBLMastery51Score.Size = New System.Drawing.Size(15, 16)
        Me.LBLMastery51Score.TabIndex = 53
        Me.LBLMastery51Score.Text = "0"
        '
        'LBLMastery52Score
        '
        Me.LBLMastery52Score.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LBLMastery52Score.AutoSize = True
        Me.LBLMastery52Score.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLMastery52Score.ForeColor = System.Drawing.Color.White
        Me.LBLMastery52Score.Location = New System.Drawing.Point(518, 399)
        Me.LBLMastery52Score.Name = "LBLMastery52Score"
        Me.LBLMastery52Score.Size = New System.Drawing.Size(15, 16)
        Me.LBLMastery52Score.TabIndex = 54
        Me.LBLMastery52Score.Text = "0"
        '
        'LBLMastery61Score
        '
        Me.LBLMastery61Score.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LBLMastery61Score.AutoSize = True
        Me.LBLMastery61Score.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLMastery61Score.ForeColor = System.Drawing.Color.White
        Me.LBLMastery61Score.Location = New System.Drawing.Point(467, 479)
        Me.LBLMastery61Score.Name = "LBLMastery61Score"
        Me.LBLMastery61Score.Size = New System.Drawing.Size(15, 16)
        Me.LBLMastery61Score.TabIndex = 55
        Me.LBLMastery61Score.Text = "0"
        '
        'TimerRegen
        '
        Me.TimerRegen.Interval = 60000
        '
        'LBLEquipmentExtraHitChance
        '
        Me.LBLEquipmentExtraHitChance.AutoSize = True
        Me.LBLEquipmentExtraHitChance.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLEquipmentExtraHitChance.ForeColor = System.Drawing.Color.Green
        Me.LBLEquipmentExtraHitChance.Location = New System.Drawing.Point(7, 151)
        Me.LBLEquipmentExtraHitChance.Name = "LBLEquipmentExtraHitChance"
        Me.LBLEquipmentExtraHitChance.Size = New System.Drawing.Size(17, 18)
        Me.LBLEquipmentExtraHitChance.TabIndex = 60
        Me.LBLEquipmentExtraHitChance.Text = "0"
        '
        'LBLEquipmentExtraCritChance
        '
        Me.LBLEquipmentExtraCritChance.AutoSize = True
        Me.LBLEquipmentExtraCritChance.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLEquipmentExtraCritChance.ForeColor = System.Drawing.Color.Green
        Me.LBLEquipmentExtraCritChance.Location = New System.Drawing.Point(7, 179)
        Me.LBLEquipmentExtraCritChance.Name = "LBLEquipmentExtraCritChance"
        Me.LBLEquipmentExtraCritChance.Size = New System.Drawing.Size(17, 18)
        Me.LBLEquipmentExtraCritChance.TabIndex = 61
        Me.LBLEquipmentExtraCritChance.Text = "0"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(984, 627)
        Me.Controls.Add(Me.PNLSettings)
        Me.Controls.Add(Me.PNLMenu)
        Me.Controls.Add(Me.PNLCharacter)
        Me.Controls.Add(Me.PNLTheArena)
        Me.Controls.Add(Me.PNLShop)
        Me.Controls.Add(Me.PNLMasteries)
        Me.Controls.Add(Me.PNLFountain)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(998, 664)
        Me.Name = "Form1"
        Me.Text = "Final Thrust"
        Me.PNLMenu.ResumeLayout(False)
        Me.PNLCharacter.ResumeLayout(False)
        Me.GRBEquipment.ResumeLayout(False)
        Me.GRBEquipment.PerformLayout()
        Me.GRBCharacterInfo.ResumeLayout(False)
        Me.GRBCharacterInfo.PerformLayout()
        CType(Me.music_player, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PCBAvatar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GRBAttributes.ResumeLayout(False)
        Me.GRBAttributes.PerformLayout()
        Me.GRBInventory.ResumeLayout(False)
        Me.GRBInventory.PerformLayout()
        Me.GRBItemInfo.ResumeLayout(False)
        Me.GRBItemInfo.PerformLayout()
        CType(Me.PCBSelecteditem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PCBmnuEquipmentValue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PCBGold, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PNLFountain.ResumeLayout(False)
        Me.PNLFountain.PerformLayout()
        CType(Me.NMCGoldDonation, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PCBWishingWell, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PNLTheArena.ResumeLayout(False)
        Me.PNLTheArena.PerformLayout()
        Me.GRBFoe4.ResumeLayout(False)
        Me.GRBFoe4.PerformLayout()
        CType(Me.PCBArenaFoe4Avatar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GRBFoe3.ResumeLayout(False)
        Me.GRBFoe3.PerformLayout()
        CType(Me.PCBArenaFoe3Avatar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GRBFoe2.ResumeLayout(False)
        Me.GRBFoe2.PerformLayout()
        CType(Me.PCBArenaFoe2Avatar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GRBGeneralSkills.ResumeLayout(False)
        Me.GRBNylathriaSkills.ResumeLayout(False)
        Me.GRBNardinaSkills.ResumeLayout(False)
        Me.GRBMakyrSkills.ResumeLayout(False)
        Me.GRBSagraxesSkills.ResumeLayout(False)
        Me.GRBFoe1.ResumeLayout(False)
        Me.GRBFoe1.PerformLayout()
        CType(Me.PCBArenaFoe1Avatar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GRBFoe5.ResumeLayout(False)
        Me.GRBFoe5.PerformLayout()
        CType(Me.PCBArenaFoe5Avatar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GRBAlyshaSkills.ResumeLayout(False)
        CType(Me.PCBArenaAvatar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PNLShop.ResumeLayout(False)
        Me.PNLShop.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GRBShopItemInfo.ResumeLayout(False)
        Me.GRBShopItemInfo.PerformLayout()
        CType(Me.PCBShopItemIcon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PCBmnuGoldItemValue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PNLSettings.ResumeLayout(False)
        Me.PNLSettings.PerformLayout()
        CType(Me.TCBMusicVolume, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PNLMasteries.ResumeLayout(False)
        Me.PNLMasteries.PerformLayout()
        CType(Me.PCBMasteryTier_6_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PCBMasteryTier_5_2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PCBMasteryTier_5_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PCBMasteryTier_4_2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PCBMasteryTier_4_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PCBMasteryTier_3_3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PCBMasteryTier_3_2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PCBMasteryTier_3_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PCBMasteryTier_2_2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PCBMasteryTier_2_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PCBMasteryTier_1_3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PCBMasteryTier_1_2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PCBMasteryTier_1_1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PNLMenu As Panel
    Friend WithEvents CMDCharacter As Button
    Friend WithEvents PNLCharacter As Panel
    Friend WithEvents GRBAttributes As GroupBox
    Friend WithEvents LBLCharismaMod As Label
    Friend WithEvents LBLWisdomMod As Label
    Friend WithEvents LBLIntelligenceMod As Label
    Friend WithEvents LBLConstitutionMod As Label
    Friend WithEvents LBLDexterityMod As Label
    Friend WithEvents LBLStrengthMod As Label
    Friend WithEvents LBLCharisma As Label
    Friend WithEvents LBLWisdom As Label
    Friend WithEvents LBLIntelligence As Label
    Friend WithEvents LBLConstitution As Label
    Friend WithEvents LBLDexterity As Label
    Friend WithEvents LBLStrength As Label
    Friend WithEvents LBLmnuDexterity As Label
    Friend WithEvents LBLmnuConstitution As Label
    Friend WithEvents LBLmnuIntelligence As Label
    Friend WithEvents LBLmnuWisdom As Label
    Friend WithEvents LBLmnuCharisma As Label
    Friend WithEvents LBLmnuStrength As Label
    Friend WithEvents GRBCharacterInfo As GroupBox
    Friend WithEvents LBLLevel As Label
    Friend WithEvents LBLAlignment As Label
    Friend WithEvents LBLRace As Label
    Friend WithEvents LBLCharacterName As Label
    Friend WithEvents LBLmnuAlignment As Label
    Friend WithEvents LBLmnuRace As Label
    Friend WithEvents LBLmnuLevel As Label
    Friend WithEvents LBLmnuCharacterName As Label
    Friend WithEvents GRBEquipment As GroupBox
    Friend WithEvents TXTOffHand As TextBox
    Friend WithEvents TXTMainHand As TextBox
    Friend WithEvents TXTBoots As TextBox
    Friend WithEvents TXTLegs As TextBox
    Friend WithEvents TXTChest As TextBox
    Friend WithEvents TXTShoulders As TextBox
    Friend WithEvents TXTHead As TextBox
    Friend WithEvents LBLmnuOffhand As Label
    Friend WithEvents LBLmnuMainhand As Label
    Friend WithEvents LBLmnuBoots As Label
    Friend WithEvents LBLmnuLegs As Label
    Friend WithEvents LBLmnuChest As Label
    Friend WithEvents LBLmnuShoulders As Label
    Friend WithEvents LBLmnuHead As Label
    Friend WithEvents LBLmnuEquipment As Label
    Friend WithEvents LBLmnuAttribbute As Label
    Friend WithEvents LBLmnuModifier As Label
    Friend WithEvents LBLmnuPoints As Label
    Friend WithEvents PCBAvatar As PictureBox
    Friend WithEvents GRBInventory As GroupBox
    Friend WithEvents LSBInventory As ListBox
    Friend WithEvents LBLmnuInventory As Label
    Friend WithEvents LBLarmorclass As Label
    Friend WithEvents LBLmnuArmorClass As Label
    Friend WithEvents LBLDiv As Label
    Friend WithEvents LBLMaxHP As Label
    Friend WithEvents LBLCurrentHP As Label
    Friend WithEvents LBLmnuHitPoints As Label
    Friend WithEvents LBLAge As Label
    Friend WithEvents LBLmnuAge As Label
    Friend WithEvents LBLGender As Label
    Friend WithEvents LBLmnuGender As Label
    Friend WithEvents CMDConsole As Button
    Friend WithEvents CMDEquip As Button
    Friend WithEvents CMDUnequipOffhand As Button
    Friend WithEvents CMDUnequipMainhand As Button
    Friend WithEvents CMDUnequipBoots As Button
    Friend WithEvents CMDUnequipLegs As Button
    Friend WithEvents CMDUnequipChest As Button
    Friend WithEvents CMDUnequipShoulders As Button
    Friend WithEvents CMDUnequipHead As Button
    Friend WithEvents CMDFountain As Button
    Friend WithEvents PNLFountain As Panel
    Friend WithEvents NMCGoldDonation As NumericUpDown
    Friend WithEvents LBLfountainMnuGoldQuestion As Label
    Friend WithEvents PCBWishingWell As PictureBox
    Friend WithEvents LBLfountainMnuGold As Label
    Friend WithEvents LBLGold As Label
    Friend WithEvents LBLDamage As Label
    Friend WithEvents LBLmnuDamage As Label
    Friend WithEvents CMDSave As Button
    Friend WithEvents LBLExperience As Label
    Friend WithEvents LBLmnuExperience As Label
    Friend WithEvents CMDTrash As Button
    Friend WithEvents CMDResetSave As Button
    Friend WithEvents CMDAddWisdom As Button
    Friend WithEvents CMDAddIntelligence As Button
    Friend WithEvents CMDAddCharisma As Button
    Friend WithEvents CMDAddConstitution As Button
    Friend WithEvents CMDAddDexterity As Button
    Friend WithEvents CMDAddStrength As Button
    Friend WithEvents CMDSubtractWisdom As Button
    Friend WithEvents CMDSubtractIntelligence As Button
    Friend WithEvents CMDSubtractCharisma As Button
    Friend WithEvents CMDSubtractConstitution As Button
    Friend WithEvents CMDSubtractDexterity As Button
    Friend WithEvents CMDSubtractStrength As Button
    Friend WithEvents LBLUnspentAttributePoints As Label
    Friend WithEvents LBLmnuUnspentAttributePoints As Label
    Friend WithEvents LBLDiv2 As Label
    Friend WithEvents LBLMaxMP As Label
    Friend WithEvents LBLCurrentMP As Label
    Friend WithEvents LBLmnuManaPoints As Label
    Friend WithEvents CMDTheArena As Button
    Friend WithEvents PNLTheArena As Panel
    Friend WithEvents PCBArenaAvatar As PictureBox
    Friend WithEvents PCBArenaFoe1Avatar As PictureBox
    Friend WithEvents LBLArenaDiv2 As Label
    Friend WithEvents LBLArenaMaxMP As Label
    Friend WithEvents LBLArenaCurrentMP As Label
    Friend WithEvents LBLArenaMnuMP As Label
    Friend WithEvents LBLArenaDiv As Label
    Friend WithEvents LBLArenaMaxHP As Label
    Friend WithEvents LBLArenaCurrentHP As Label
    Friend WithEvents LBLArenaMnuHP As Label
    Friend WithEvents LBLArenaLevel As Label
    Friend WithEvents LBLArenaCharacterName As Label
    Friend WithEvents LBLArenaMnuLevel As Label
    Friend WithEvents LBLArenaDiv3 As Label
    Friend WithEvents LBLArenaFoe1MaxHP As Label
    Friend WithEvents LBLArenaFoe1CurrentHP As Label
    Friend WithEvents LBLArenaMnuFoe1HP As Label
    Friend WithEvents LBLArenaFoe1Name As Label
    Friend WithEvents PGBPlayerMP As ProgressBar
    Friend WithEvents PGBFoe1HP As ProgressBar
    Friend WithEvents PGBPlayerHP As ProgressBar
    Friend WithEvents TXTCombatLog As RichTextBox
    Friend WithEvents LBLCritChance As Label
    Friend WithEvents LBLmnuCritChance As Label
    Friend WithEvents LBLHitChance As Label
    Friend WithEvents LBLmnuHitChance As Label
    Friend WithEvents LBLArenaFoe1Border As Label
    Friend WithEvents GRBFoe1 As GroupBox
    Friend WithEvents GRBFoe2 As GroupBox
    Friend WithEvents LBLArenaFoe2Name As Label
    Friend WithEvents PGBFoe2HP As ProgressBar
    Friend WithEvents PCBArenaFoe2Avatar As PictureBox
    Friend WithEvents LBLArenaMnuFoe2HP As Label
    Friend WithEvents LBLArenaFoe2CurrentHP As Label
    Friend WithEvents LBLArenaDiv4 As Label
    Friend WithEvents LBLArenaFoe2MaxHP As Label
    Friend WithEvents LBLArenaFoe2Border As Label
    Friend WithEvents GRBFoe3 As GroupBox
    Friend WithEvents LBLArenaFoe3Name As Label
    Friend WithEvents PGBFoe3HP As ProgressBar
    Friend WithEvents PCBArenaFoe3Avatar As PictureBox
    Friend WithEvents LBLArenaMnuFoe3HP As Label
    Friend WithEvents LBLArenaFoe3CurrentHP As Label
    Friend WithEvents LBLArenaDiv5 As Label
    Friend WithEvents LBLArenaFoe3MaxHP As Label
    Friend WithEvents LBLArenaFoe3Border As Label
    Friend WithEvents GRBFoe4 As GroupBox
    Friend WithEvents LBLArenaFoe4Name As Label
    Friend WithEvents PGBFoe4HP As ProgressBar
    Friend WithEvents PCBArenaFoe4Avatar As PictureBox
    Friend WithEvents LBLArenaMnuFoe4HP As Label
    Friend WithEvents LBLArenaFoe4CurrentHP As Label
    Friend WithEvents LBLArenaDiv6 As Label
    Friend WithEvents LBLArenaFoe4MaxHP As Label
    Friend WithEvents LBLArenaFoe4Border As Label
    Friend WithEvents GRBFoe5 As GroupBox
    Friend WithEvents LBLArenaFoe5Name As Label
    Friend WithEvents PGBFoe5HP As ProgressBar
    Friend WithEvents PCBArenaFoe5Avatar As PictureBox
    Friend WithEvents LBLArenaMnuFoe5HP As Label
    Friend WithEvents LBLArenaFoe5CurrentHP As Label
    Friend WithEvents LBLArenaDiv7 As Label
    Friend WithEvents LBLArenaFoe5MaxHP As Label
    Friend WithEvents LBLArenaFoe5Border As Label
    Friend WithEvents GRBNylathriaSkills As GroupBox
    Friend WithEvents CMDNylathriaSkill5 As Button
    Friend WithEvents CMDNylathriaSkill4 As Button
    Friend WithEvents CMDNylathriaSkill3 As Button
    Friend WithEvents CMDNylathriaSkill2 As Button
    Friend WithEvents CMDNylathriaSkill1 As Button
    Friend WithEvents GRBNardinaSkills As GroupBox
    Friend WithEvents CMDNardinaSkill5 As Button
    Friend WithEvents CMDNardinaSkill4 As Button
    Friend WithEvents CMDNardinaSkill3 As Button
    Friend WithEvents CMDNardinaSkill2 As Button
    Friend WithEvents CMDNardinaSkill1 As Button
    Friend WithEvents GRBMakyrSkills As GroupBox
    Friend WithEvents CMDMakyrSkill5 As Button
    Friend WithEvents CMDMakyrSkill4 As Button
    Friend WithEvents CMDMakyrSkill3 As Button
    Friend WithEvents CMDMakyrSkill2 As Button
    Friend WithEvents CMDMakyrSkill1 As Button
    Friend WithEvents GRBSagraxesSkills As GroupBox
    Friend WithEvents CMDSagraxesSkill5 As Button
    Friend WithEvents CMDSagraxesSkill4 As Button
    Friend WithEvents CMDSagraxesSkill3 As Button
    Friend WithEvents CMDSagraxesSkill2 As Button
    Friend WithEvents CMDSagraxesSkill1 As Button
    Friend WithEvents LBLSkillDescription As Label
    Friend WithEvents LBLTurnCounter As Label
    Friend WithEvents CMDFlee As Button
    Friend WithEvents GRBAlyshaSkills As GroupBox
    Friend WithEvents CMDAlyshaSkill5 As Button
    Friend WithEvents CMDAlyshaSkill4 As Button
    Friend WithEvents CMDAlyshaSkill3 As Button
    Friend WithEvents CMDAlyshaSkill2 As Button
    Friend WithEvents CMDAlyshaSkill1 As Button
    Friend WithEvents GRBGeneralSkills As GroupBox
    Friend WithEvents CMDBlock As Button
    Friend WithEvents CMDShop As Button
    Friend WithEvents PNLShop As Panel
    Friend WithEvents CMDBuy As Button
    Friend WithEvents LSBShopBuy As ListBox
    Friend WithEvents LBLShopGold As Label
    Friend WithEvents CMDSell As Button
    Friend WithEvents LSBShopSell As ListBox
    Friend WithEvents CMDAchievements As Button
    Friend WithEvents CHBHideCombatLog As CheckBox
    Friend WithEvents PCBGold As PictureBox
    Friend WithEvents PCBSelecteditem As PictureBox
    Friend WithEvents LBLEquipmentValue As Label
    Friend WithEvents LBLEquipmentDamage As Label
    Friend WithEvents LBLmnuEquipmentDamage As Label
    Friend WithEvents LBLEquipmentAC As Label
    Friend WithEvents LBLmnuEquipmentAC As Label
    Friend WithEvents LBLEquipmentDescription As Label
    Friend WithEvents LBLEquipmentType As Label
    Friend WithEvents PCBmnuEquipmentValue As PictureBox
    Friend WithEvents GRBItemInfo As GroupBox
    Friend WithEvents GRBShopItemInfo As GroupBox
    Friend WithEvents PCBShopItemIcon As PictureBox
    Friend WithEvents PCBmnuGoldItemValue As PictureBox
    Friend WithEvents LBLShopItemValue As Label
    Friend WithEvents LBLShopItemType As Label
    Friend WithEvents LBLShopItemDamage As Label
    Friend WithEvents LBLmnuShopItemDamage As Label
    Friend WithEvents LBLShopItemDescription As Label
    Friend WithEvents LBLShopItemAC As Label
    Friend WithEvents LBLmnuShopItemAC As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents music_player As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents CMDSettings As Button
    Friend WithEvents PNLSettings As Panel
    Friend WithEvents CMDMuteMusic As Button
    Friend WithEvents LBLVolume As Label
    Friend WithEvents TCBMusicVolume As TrackBar
    Friend WithEvents CMDMuteSfx As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents CMDUseItem As Button
    Friend WithEvents LBLEquipmentExtraMana As Label
    Friend WithEvents LBLEquipmentExtraHealth As Label
    Friend WithEvents LBLShopItemExtraMana As Label
    Friend WithEvents LBLShopItemExtraHealth As Label
    Friend WithEvents CMDMasteries As Button
    Friend WithEvents PNLMasteries As Panel
    Friend WithEvents PCBMasteryTier_2_2 As PictureBox
    Friend WithEvents PCBMasteryTier_2_1 As PictureBox
    Friend WithEvents PCBMasteryTier_1_3 As PictureBox
    Friend WithEvents PCBMasteryTier_1_2 As PictureBox
    Friend WithEvents PCBMasteryTier_1_1 As PictureBox
    Friend WithEvents PCBMasteryTier_6_1 As PictureBox
    Friend WithEvents PCBMasteryTier_5_2 As PictureBox
    Friend WithEvents PCBMasteryTier_5_1 As PictureBox
    Friend WithEvents PCBMasteryTier_4_2 As PictureBox
    Friend WithEvents PCBMasteryTier_4_1 As PictureBox
    Friend WithEvents PCBMasteryTier_3_3 As PictureBox
    Friend WithEvents PCBMasteryTier_3_2 As PictureBox
    Friend WithEvents PCBMasteryTier_3_1 As PictureBox
    Friend WithEvents LBLMastery11Score As Label
    Friend WithEvents LBLMastery12Score As Label
    Friend WithEvents LBLMastery13Score As Label
    Friend WithEvents LBLMastery21Score As Label
    Friend WithEvents LBLMastery22Score As Label
    Friend WithEvents LBLMastery31Score As Label
    Friend WithEvents LBLMastery32Score As Label
    Friend WithEvents LBLMastery33Score As Label
    Friend WithEvents LBLMastery41Score As Label
    Friend WithEvents LBLMastery42Score As Label
    Friend WithEvents LBLMastery51Score As Label
    Friend WithEvents LBLMastery52Score As Label
    Friend WithEvents LBLMastery61Score As Label
    Friend WithEvents LBLMastery11MaxScore As Label
    Friend WithEvents LBLMastery12MaxScore As Label
    Friend WithEvents LBLMastery13MaxScore As Label
    Friend WithEvents LBLMastery21MaxScore As Label
    Friend WithEvents LBLMastery22MaxScore As Label
    Friend WithEvents LBLMastery31MaxScore As Label
    Friend WithEvents LBLMastery32MaxScore As Label
    Friend WithEvents LBLMastery33MaxScore As Label
    Friend WithEvents LBLMastery41MaxScore As Label
    Friend WithEvents LBLMastery42MaxScore As Label
    Friend WithEvents LBLMastery51MaxScore As Label
    Friend WithEvents LBLMastery52MaxScore As Label
    Friend WithEvents LBLMastery61MaxScore As Label
    Friend WithEvents LBLMasteryDescription As Label
    Friend WithEvents LBLMasteryTitle As Label
    Friend WithEvents TimerRegen As Timer
    Friend WithEvents LBLEquipmentExtraCritChance As Label
    Friend WithEvents LBLEquipmentExtraHitChance As Label
End Class
