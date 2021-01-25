
using System.Windows.Forms;

namespace CrudClassGenerator
{
    public static class Language
    {
        private static bool mLangTr = true;
        public static bool LangTr { get { return mLangTr; } set { mLangTr = value; } }
    }

    public class Message
    {
        private static bool LangTr { get { return Language.LangTr; } }

        #region [Messages]

        public static string ProjectPathSaved { get { return LangTr ? MsgsTr.ProjectPathSaved : MsgsEn.ProjectPathSaved; } }
        public static string DefConnStrSaved { get { return LangTr ? MsgsTr.DefConnStrSaved : MsgsEn.DefConnStrSaved; } }
        public static string DefDbTypeSaved { get { return LangTr ? MsgsTr.DefDbTypeSaved : MsgsEn.DefDbTypeSaved; } }
        public static string DbConnOk { get { return LangTr ? MsgsTr.DbConnOk : MsgsEn.DbConnOk; } }
        public static string NoTableForThisSchema { get { return LangTr ? MsgsTr.NoTableForThisSchema : MsgsEn.NoTableForThisSchema; } }
        public static string NoSchemaSelected { get { return LangTr ? MsgsTr.NoSchemaSelected : MsgsEn.NoSchemaSelected; } }
        public static string MandatorySchemaAndTable { get { return LangTr ? MsgsTr.MandatorySchemaAndTable : MsgsEn.MandatorySchemaAndTable; } }
        public static string DuplicateServiceContractForClass { get { return LangTr ? MsgsTr.DuplicateServiceContractForClass : MsgsEn.DuplicateServiceContractForClass; } }
        public static string DuplicateServiceContractForContract { get { return LangTr ? MsgsTr.DuplicateServiceContractForContract : MsgsEn.DuplicateServiceContractForContract; } }
        public static string MultiGenerationMsg { get { return LangTr ? MsgsTr.MultiGenerationMsg : MsgsEn.MultiGenerationMsg; } }
        public static string NoTableSelected { get { return LangTr ? MsgsTr.NoTableSelected : MsgsEn.NoTableSelected; } }
        public static string ProcessOk { get { return LangTr ? MsgsTr.ProcessOk : MsgsEn.ProcessOk; } }
        public static string ProcessOkBut { get { return LangTr ? MsgsTr.ProcessOkBut : MsgsEn.ProcessOkBut; } }
        public static string ChooseOne { get { return LangTr ? MsgsTr.ChooseOne : MsgsEn.ChooseOne; } }
        public static string AskForOverwrite { get { return LangTr ? MsgsTr.AskForOverwrite : MsgsEn.AskForOverwrite; } }
        public static string NoAppConfigFile { get { return LangTr ? MsgsTr.NoAppConfigFile : MsgsEn.NoAppConfigFile; } }
        public static string MandatoryProjectPath { get { return LangTr ? MsgsTr.MandatoryProjectPath : MsgsEn.MandatoryProjectPath; } }
        public static string MandatoryClassName { get { return LangTr ? MsgsTr.MandatoryClassName : MsgsEn.MandatoryClassName; } }
        public static string MandatoryBSNamespace { get { return LangTr ? MsgsTr.MandatoryBSNamespace : MsgsEn.MandatoryBSNamespace; } }
        public static string MandatoryInterfaceNamespace { get { return LangTr ? MsgsTr.MandatoryInterfaceNamespace : MsgsEn.MandatoryInterfaceNamespace; } }
        public static string ChooseTable { get { return LangTr ? MsgsTr.ChooseTable : MsgsEn.ChooseTable; } }
        public static string ChooseSchema { get { return LangTr ? MsgsTr.ChooseSchema : MsgsEn.ChooseSchema; } }
        public static string MandatoryConStr { get { return LangTr ? MsgsTr.MandatoryConStr : MsgsEn.MandatoryConStr; } }
        public static string NoPKField { get { return LangTr ? MsgsTr.NoPKField : MsgsEn.NoPKField; } }
        public static string AlreadyExistInAppConfig { get { return LangTr ? MsgsTr.AlreadyExistInAppConfig : MsgsEn.AlreadyExistInAppConfig; } }
        public static string NoAnyResult { get { return LangTr ? MsgsTr.NoAnyResult : MsgsEn.NoAnyResult; } }
        public static string CreationSucceeded { get { return LangTr ? MsgsTr.CreationSucceeded : MsgsEn.CreationSucceeded; } }
        public static string TriggersWouldBeCreated { get { return LangTr ? MsgsTr.TriggersWouldBeCreated : MsgsEn.TriggersWouldBeCreated; } }
        public static string InheritanceClassNameSaved { get { return LangTr ? MsgsTr.InheritanceClassNameSaved : MsgsEn.InheritanceClassNameSaved; } }
        public static string LogTableNameSaved { get { return LangTr ? MsgsTr.LogTableNameSaved : MsgsEn.LogTableNameSaved; } }
        public static string NoDbConnString { get { return LangTr ? MsgsTr.NoDbConnString : MsgsEn.NoDbConnString; } }
        public static string LookupTablePrefixSaved { get { return LangTr ? MsgsTr.LookupTablePrefixSaved : MsgsEn.LookupTablePrefixSaved; } }
        public static string SchemasLoaded { get { return LangTr ? MsgsTr.SchemasLoaded : MsgsEn.SchemasLoaded; } }
        public static string TablesLoaded { get { return LangTr ? MsgsTr.TablesLoaded : MsgsEn.TablesLoaded; } }
        public static string SearchChrCount { get { return LangTr ? MsgsTr.SearchChrCount : MsgsEn.SearchChrCount; } }
        public static string SelectSchemaFirst { get { return LangTr ? MsgsTr.SelectSchemaFirst : MsgsEn.SelectSchemaFirst; } }
        public static string SettingsSaved { get { return LangTr ? MsgsTr.SettingsSaved : MsgsEn.SettingsSaved; } }
        public static string MandatoryTypeNamespace { get { return LangTr ? MsgsTr.MandatoryTypeNamespace : MsgsEn.MandatoryTypeNamespace; } }
        public static string UnknownDbType { get { return LangTr ? MsgsTr.UnknownDbType : MsgsEn.UnknownDbType; } }
        public static string TDSGenerationApprovalMsg { get { return LangTr ? MsgsTr.TDSGenerationApprovalMsg : MsgsEn.TDSGenerationApprovalMsg; } }
        public static string UnauthorizedAccessException { get { return LangTr ? MsgsTr.UnauthorizedAccessException : MsgsEn.UnauthorizedAccessException; } }
        public static string TableIsEmpty { get { return LangTr ? MsgsTr.TableIsEmpty : MsgsEn.TableIsEmpty; } }
        public static string ColumnTypeShouldBeNumeric { get { return LangTr ? MsgsTr.ColumnTypeShouldBeNumeric : MsgsEn.ColumnTypeShouldBeNumeric; } }
        public static string NoRecordsInTable { get { return LangTr ? MsgsTr.NoRecordsInTable : MsgsEn.NoRecordsInTable; } }
        public static string NoEnumNamaOrValue { get { return LangTr ? MsgsTr.NoEnumNamaOrValue : MsgsEn.NoEnumNamaOrValue; } }
        public static string NoEnumDescription { get { return LangTr ? MsgsTr.NoEnumDescription : MsgsEn.NoEnumDescription; } }
        public static string NoColumnTypeName { get { return LangTr ? MsgsTr.NoColumnTypeName : MsgsEn.NoColumnTypeName; } }
        public static string MultyTableSelectionForbidden { get { return LangTr ? MsgsTr.MultyTableSelectionForbidden : MsgsEn.MultyTableSelectionForbidden; } }
        public static string ResetOk { get { return LangTr ? MsgsTr.ResetOk : MsgsEn.ResetOk; } }
        
        public static void MsgCreationSucceeded(string pObjectName)
        {
            string msg = string.Format("{0} {1}", pObjectName, CreationSucceeded);
            MessageBox.Show(msg, "CCG", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static string MsgGeneral(string pMsg1, string pMsg2)
        {
            return LangTr ? MsgsTr.MsgGeneral(pMsg1, pMsg2) : MsgsEn.MsgGeneral(pMsg1, pMsg2);
        }

        #endregion
        
        private class MsgsTr
        {
            public const string ProjectPathSaved = "Proje dizini kaydedildi.";
            public const string DefConnStrSaved = "Seçili veritabanı tipi için ConnectionString değeri kaydedildi.";
            public const string DefDbTypeSaved = "Database tipi Kaydedildi.";
            public const string DbConnOk = "Veritabanı bağlantısı yapıldı.";
            public const string NoTableForThisSchema = "Seçilen şemaya ait hiç tablo bulunamadı!";
            public const string NoSchemaSelected = "Lütfen bir 'Şema' seçiniz!";
            public const string MandatorySchemaAndTable = "Şema ve Tablo alanları boş bırakılamaz !";
            public const string DuplicateServiceContractForClass = "Mükerrer 'ServiceContract' niteliği (attribute) oluşmaması için 'Generate BS and Interface Classes' seçeneğindeki işaret kaldırılmalıdır.";
            public const string DuplicateServiceContractForContract = "Mükerrer 'ServiceContract' niteliği (attribute) oluşmaması için 'Add Service Contract' seçeneğindeki işaret kaldırılmalıdır.";
            public const string MultiGenerationMsg = "Bu işlem sırasında, sınıf (class) isimleri otomatik olarak verilecek ve var olan dosyaların üzerine yazılacaktır! İşleme devam etmek istiyor musunuz?";
            public const string NoTableSelected = "Lütfen en az bir adet tablo seçiniz!";
            public const string ProcessOk = "İşlem başarıyla tamamlandı.";
            public const string ProcessOkBut = "İşlemler tamamlandı. Ama en az bir işlemde hata oluştu ! Lütfen tablo isimlerinizi, kolon isimlerinizi, kolon özelliklerini ve diğer girdilerinizi kontrol ediniz.";
            public const string ChooseOne = "Seçeneklerden en az birisi seçilmelidir !";
            public const string AskForOverwrite = "Verilen dizinde [{0}] isminde bir sınıf (class) zaten var ! Üzerine yazılsın mı ?";
            public const string NoAppConfigFile = "app.config dosyası belirtilen dizinde bulunamadı ve bu nedenle 'EndPoint' kontrolü yapılamıyor! Gene de devam etmek istiyor musunuz?";
            public const string MandatoryProjectPath = "'Project Path' alanı boş bırakılamaz !";
            public const string MandatoryClassName = "'Class Name' alanı boş bırakılamaz !";
            public const string MandatoryBSNamespace = "'BS Namespace' alanı boş bırakılamaz !";
            public const string MandatoryInterfaceNamespace = "'Interface Namespace' alanı boş bırakılamaz !";
            public const string ChooseTable = "Bir tablo seçiniz !";
            public const string ChooseSchema = "Bir şema seçiniz !";
            public const string MandatoryConStr = "ConnectionString giriniz !";
            public const string NoPKField = "Seçilen tabloda 'Primary Key' alanı bulunamadı ! Lütfen bir 'Primary Key' tanımlayınız.";
            public const string AlreadyExistInAppConfig = "Bu isimde bir sınıf (class)' ait bir EndPoint, app.config dosyası içinde zaten var ! Lütfen kontrol edin ve gerekirse oluşturacağınız sınıf (class) adını değiştirin. Gene de devam etmek istiyor musunuz?";
            public const string NoAnyResult = "için herhangi bir sonuç bulunamadı !";
            public const string CreationSucceeded = "başarıyla oluşturuldu.";
            public const string TriggersWouldBeCreated = "Seçilen tablolar için 'trigger' dosyaları oluşturulacaktır. Devam etmek istiyor musunuz?";
            public const string InheritanceClassNameSaved = "Miras alınacak sınıf adı (Inheritance Class Name) kaydedildi.";
            public const string LogTableNameSaved = "LOG Tablo adı kaydedildi.";
            public const string NoDbConnString = "ConnectionString bulunamadı ! Bu nedenle veritabanı bağlantısı gerçekleştirilemedi.\r\n\r\nUygulama açıldığında, öncelikle ConnectionString ayarını yapınız.";
            public const string LookupTablePrefixSaved = "Tanım tablosu ön eki (Lookup Table Prefix) kaydedildi.";
            public const string SchemasLoaded = "Bağlı veritabanı altındaki ŞEMA'lar yüklendi. Seçmek istediğiniz şemanın ilk bir kaç harfini yazmanız yeterli.";
            public const string TablesLoaded = "Seçili Schema altındaki TABLO'lar yüklendi. Seçmek istediğiniz tablonun ilk bir kaç harfini yazmanız yeterli.";
            public const string SearchChrCount = "- En az {0} karakter giriniz ...";
            public const string SelectSchemaFirst = "- Önce Şema seçiniz ...";
            public const string SettingsSaved = "Ayarlar kaydedildi.";
            public const string MandatoryTypeNamespace = "'Type Namespace' alanı boş bırakılamaz!";
            public const string UnknownDbType = "Bilinmeyen veritabanı tipi!";
            public const string TDSGenerationApprovalMsg = "Seçilen tablolar için TypedDataSet sınıfları oluşturulacak ve var olanların üzerine yazılacaktır. Onaylıyor musunuz?";
            public const string UnauthorizedAccessException = "Yetkisiz erişim hatası! [{0}] dizinindeki dosyanın üzerine yazılamadı! Dosyanın salt-okunur olup olmadığını kontrol edin.";
            public const string TableIsEmpty = "Seçilen tablo birden fazla kolon içermelidir!";
            public const string ColumnTypeShouldBeNumeric = "Value Field kolon tipi [tinyint, smallint, int, bigint] olabilir!";
            public const string NoRecordsInTable = "Seçilen tabloda kayıt bulunamadı!";
            public const string NoEnumNamaOrValue = "'Enum Name' ve 'Enum Value' alanları boş bırakılamaz!";
            public const string NoEnumDescription = "'Create Enum With Description' seçeneği işaretli durumdayken 'Enum Description' alanı boş bırakılamaz.";
            public const string NoColumnTypeName = "İlgili kolona ait 'Kolon Tip Adı' bilgisi alınamadı! İlgili tablodaki kolonlarınızı kontrol edin.";
            public const string MultyTableSelectionForbidden = "Enumeration sınıfı (class) oluştururken birden fazla tablo seçilemez!";
            public const string ResetOk = "Namespace ve Class isimleri resetlendi.";

            public static string MsgGeneral(string pMsg1, string pMsg2)
            {
                return string.Format("{0} {1}", pMsg1, pMsg2);
            }
        }

        private class MsgsEn
        {
            public const string ProjectPathSaved = "Project Path was saved.";
            public const string DefConnStrSaved = "ConnectionString was saved for selected database type.";
            public const string DefDbTypeSaved = "Database type was saved.";
            public const string DbConnOk = "Database connection was created.";
            public const string NoTableForThisSchema = "No tables were found for selected schema!";
            public const string NoSchemaSelected = "Please select a schema!";
            public const string MandatorySchemaAndTable = "Schema and table fields can not be empty !";
            public const string DuplicateServiceContractForClass = "To prevent repeated 'ServiceContract' attribute, 'Generate BS and Interface Classes' option shoul be unchecked.";
            public const string DuplicateServiceContractForContract = "To prevent repeated 'ServiceContract' attribute, 'Add Service Contract' option shoul be unchecked.";
            public const string MultiGenerationMsg = "During this process, class names will be generated automaticly and overwrite existing files! Do you want continue?";
            public const string NoTableSelected = "Please select at least one table!";
            public const string ProcessOk = "The operation completed successfully!";
            public const string ProcessOkBut = "Operations completed. But at least one operation failed! Please check your table names, column names, column properties and inputs.";
            public const string ChooseOne = "At least one of the options must be selected!";
            public const string AskForOverwrite = "There is already a class with the name of [{0}] under the given path! Overwrite it?";
            public const string NoAppConfigFile = "app.config file could not be found in the given directory. Therefore EndPoint control failed! Do you want to continue anyway?";
            public const string MandatoryProjectPath = "'Project Path' field can not be blank!";
            public const string MandatoryClassName = "'Class Name' field can not be blank!";
            public const string MandatoryBSNamespace = "'BS Namespace' field can not be blank!";
            public const string MandatoryInterfaceNamespace = "'Interface Namespace' field can not be blank!";
            public const string ChooseTable = "Select a table!";
            public const string ChooseSchema = "Select a schema!";
            public const string MandatoryConStr = "Write Connection String!";
            public const string NoPKField = "PrimaryKey could not be found in the selected table! Please define a Primary Key.";
            public const string AlreadyExistInAppConfig = "Already exist an EndPoint for this class name in the app.config file! Please check and if necessary change class name. Do you want to continue anyway?";
            public const string NoAnyResult = "There is no any result for !";
            public const string CreationSucceeded = "Successfully created.";
            public const string TriggersWouldBeCreated = "Trigger files will be created for selected tables. Do you want to continue?";
            public const string InheritanceClassNameSaved = "Inheritance Class Name was saved.";
            public const string LogTableNameSaved = "LOG Table name was saved.";
            public const string NoDbConnString = "ConnectionString could not be found! Therefore database connection could not be established.\r\n\r\nWhen application was opened, first, you should set Connection String.";
            public const string LookupTablePrefixSaved = "Lookup Table Prefix was saved.";
            public const string SchemasLoaded = "Schemas were loaded. You can simply type the first few letters of the schema you want to select.";
            public const string TablesLoaded = "Tables were loaded. You can simply type the first few letters of the table you want to select.";
            public const string SearchChrCount = "- Enter at least {0} character ...";
            public const string SelectSchemaFirst = "- Select schema first ...";
            public const string SettingsSaved = "Settings saved.";
            public const string MandatoryTypeNamespace = "'Type Namespace' field can not be blank!";
            public const string UnknownDbType = "Unknown Database type !";
            public const string TDSGenerationApprovalMsg = "TypedDataSet classes will be generated for selected tables and overwrite them. Do you want to continue?";
            public const string UnauthorizedAccessException = "Unauthorized Access Exception! [{0}] cannot be overwritten. Check whether file is readonly.";
            public const string TableIsEmpty = "Selected table should be include more then one columns!";
            public const string ColumnTypeShouldBeNumeric = "Value Field column type should be [tinyint, smallint, int, bigint]!";
            public const string NoRecordsInTable = "There is no any record in selected table!";
            public const string NoEnumNamaOrValue = "'Enum Name' and 'Enum Value' fields can not be empty!";
            public const string NoEnumDescription = "When 'Create Enum With Description' option is checked, 'Enum Description' field can not be empty.";
            public const string NoColumnTypeName = "'Column Type Name' information can not be found for related column! Check columns in related table.";
            public const string MultyTableSelectionForbidden = "While creating Enumeration class, more then one table cannot be selected!";
            public const string ResetOk = "Namespace and Class names reseted.";

            public static string MsgGeneral(string pMsg1, string pMsg2)
            {
                return string.Format("{0} {1}", pMsg2, pMsg1);
            }
        }
    }

}
