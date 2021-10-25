
namespace CrudClassGenerator
{
    public class Tooltips
    {
        public class TooltipTr
        {
            public const string ToolTipTitle = "Bilgi";
            public const string checkBoxSelectMultyTables = "Aynı anda birden fazla tabloya ait sınıf üretmek için bu seçeneği işaretleyin \r\nve açılan listeden tabloları seçin.";
            public const string buttonConnectToDb = "Veritabanına bağlan ve Şemaları yükle.";
            public const string buttonGetTables = "Seçilen şema altındaki tüm tabloları yükle.";
            public const string buttonCreateStrings = "EndPoint ve Cache yapılandırma cümlelerini oluştur.";
            public const string buttonCleanCacheItemWeb = "Temizle";
            public const string buttonCleanCacheItemServer = "Temizle";
            public const string buttonCleanEndPoint = "Temizle";
            public const string textBoxInheritanceClassNameForCC = "CC sınıfını başka bir sınıfdan türetmek istiyorsanız, \r\nburaya o sınıfın adını yazınız. Örneğin: CCGDalBase";
            public const string buttonProjectPath = "Proje dizini seç.";

            public const string textBoxProjectPath = "Class Library veya WCF projenizin olduğu dizin.";
            public const string textBoxClassName = "Parametre Sınıf Adı";
            public const string textBoxInterfaceClassName = "Interface Sınıf Adı";
            public const string textBoxCrudClassName = "Crud Class (CC) Sınıf Adı";

            public const string checkBoxCrudCC = "Bu seçenek işaretlendiğinde, CRUD işlemleri (CC) sınıfı üretilir.";
            public const string checkBoxCrudInterface = "Bu seçenek işaretlendiğinde, Interface sınıfı üretilir.";

            public const string checkBoxPrmClassInInterfaceFile = "Bu seçenek işaretlendiğinde, parametre sınıfları, Interface sınıfı ile aynı dosyaya yazılır.";
            public const string checkBoxPrmClassInCCFile = "Bu seçenek işaretlendiğinde, parametre sınıfları, CRUD işlemleri (CC) sınıfı ile aynı dosyaya yazılır.";
            public const string checkBoxPrmClassSeparate = "Bu seçenek işaretlendiğinde, parametre sınıfları ayrı bir dosyaya yazılır.";
            public const string checkBoxTemplateCc = "Bu seçenek işaretlendiğinde, şablon bir CC sınıfı \"partial\" olarak ayrıca üretilir.";
            public const string checkBoxTemplateInterface = "Bu seçenek işaretlendiğinde, bir Interface sınıfı \"partial\" olarak ayrıca üretilir.";

            public const string radioButtonUseInterfacePath = "Parametre sınıfını Interface dizinine yazmak için bu seçeneği işaretleyin.";
            public const string radioButtonUseCCPath = "Parametre sınıfını Crud Class dizinine yazmak için bu seçeneği işaretleyin.";

            public const string checkBoxTypedDs = "Bu seçenek işaretlendiğinde, oluşturulan CRUD sınıfına; \r\n\"SelectAsTypedDataSet\" ve \"InsertOrUpdate\" methodu eklenir.";
            public const string checkBoxAddNoLock = "Select cümlelerine \"WITH(NOLOCK)\" eklemek için bu seçeneği işaretleyin.";
            public const string checkBoxAddServiceContract = "Üretilen Interface üzerinde bir EndPoint oluşturmak ve böylece, \r\nservis erişimi sağlamak için \"ServiceContract\" niteliği (attribute) eklenmelidir.";
            public const string checkBoxPrmClass = "Parametre sınıfını, CRUD Interface sınıfı ile aynı \r\n'cs' dosyasına yazmak için bu seçeneği işaretleyin.";
            public const string linkLabelGenerateTrigger = "Ekleme ve güncelleme işlemlerine ait log'lamaları bir trigger aracılığı ile yapmak isterseniz, \r\nBu butona tıklayarak gerekli trigger betik (script) dosyasını üretebilirsiniz.";
            public const string checkBoxCustomNamesapce = "Bu seçenek işaretlendiğinde, verilen \"Subpath\" adı, \"namespace\" adı olarak kullanılır. \r\nBu seçenek işaretli olmadığında \"namespace\" otomatik olarak oluşturulur.";
            public const string textBoxFullTableNameForLog = "Varsayılan log tablosu yerine başka bir tablo kullanılacak ise, \r\nbu alana o tablonun tam adı \"VeritabanıAdı.ŞemaAdı.TabloAdı\" şeklinde yazılır.";
            public const string textBoxInheritanceClassNameForPrm = "Parametre sınıfı başka bir sınıftan türetilecek ise, \r\ntüretileceği sınıfın adı buraya yazılır.";
            public const string checkBoxCreateOnlySelect = "Crud sınıfı içinde sadece \"select\" metotları bulunacak ise, bu seçeneği işaretleyin. \r\nBu durumda; sınıf içinde, ekleme, güncelleme ve silme metotları bulunmayacaktır.";
            public const string buttonGetSchemas = "Bağlanılan veritabanında tanımlı tüm şemaları yükle.";
            public const string checkBoxPkIsIdentity = "Birincil anahtar (PK (Primary Key)), \"Identity\" olarak belirlenmiş ise bu seçeneği işaretleyin.";
            public const string textBoxLookupPrefix = "Tanım tablolarının bulunacağı Şema için, ön-ek kullanılacak ise (tavsiye edilir) buraya yazınız. \r\nÖnerilen Ön-Ek'ler: TT_ ; LT_ ; PRM_" +
                                                        "\r\n\r\nNOT: \"Select\" cümlesine tanım tablolarını eklemek (join) için kullanılır. Boş bırakılması durumunda," +
                                                        "\r\n\"JoinWithLookupTables\" özelliği kullanılamayacaktır.";

            public const string rdbOracle = "Veritabanı tipini ORACLE yapmak için bu seçeneği işaretleyiniz.";
            public const string rdbMsSql = "Veritabanı tipini MS_SQL yapmak için bu seçeneği işaretleyiniz.";
            public const string linkLabelSetNmSpsClassNames = "Namespace ve Class adlarını otomatik olarak belirlemek için tıklayın." +
                                                        "\r\n\r\nNOT: Bir tablo adı seçildiğinde, namespace ve class adları otomatik olarak belirlenir." +
                                                        "\r\nAma bu isimler elle değiştirilir ve bu değişiklikten geri dönülmek istenirse, bu buton kullanılabirlir.";
            public const string pictureBoxNoConnection = "Veritabanı bağlantı hatası!";
            public const string pictureBoxConnectionOk = "Veritabanına bağlantı yapıldı.";
            public const string buttonSaveConnStr = "Seçili veritabanı tipine ait ConnectionString değerini kaydet.";
            public const string linkLabelLoadColumns = "Seçilen tablonun kolonlarını yükle.";

            public const string textBoxDataSetSuffix = "Oluşturulacak DataSet adının sonuna eklenecek son-ek.";
            public const string textBoxAttributesNamespace = "Oluşturulacak DataSet içinde yeralacak nitelik (Attribute) bilgilerinin yazılacağı dizin, aynı zamanda namespace.";
            public const string comboBoxTextField = "Enum adının alınacağı kolon ismi.";
            public const string comboBoxValueField = "Enum değerinin alınacağı kolon ismi.";
            public const string comboBoxDescription = "Enum açıklamasının alınacağı kolon ismi.";
            public const string checkBoxUseEnumNameWithoutChange = "Bu seçenek işaretlendiğinde, Enum isimleri, ilgili kolonda yazıldığı şekilde oluşturulur.";
            public const string checkBoxSeparateEnumName = "Bu seçenek işaretlendiğinde, enum isimleri, kelimeler arasına alt-çizgi konularak oluşturulur.";
            public const string checkBoxWithDescription = "Bu seçenek işaretlendiğinde, Enum isimlerinin üzerine açıklama eklenir.";
            public const string checkBoxCreateConstantsOnly = "Bu seçenek işaretlendiğinde, Enum oluşturmadan sadece sabit değerler içeren 'struct' oluşturulur.";
            public const string checkBoxUseDbScript = "Bu seçenek işaretlendiğinde, Enum bilgileri için, seçilen tablo değil, açılan alana yazılan veritabanı sorgusu baz alınır.";
            public const string textBoxEnumPrefix = "Oluşturulacak Enum isminin başına eklenecek ön-ek.";
            public const string textBoxEnumSuffix = "Oluşturulacak Enum isminin sonuna eklenecek son-ek.";
            public const string checkBoxAutoSetClassName = "Bu seçenek işaretli olduğunda, sınıf (Class) ismi, tablo ismine göre otomatik olarak oluşturulur.\r\nDiğer durumda, tablo ismi olduğu gibi, sınıf ismi olarak kullanılır.";
            public const string checkBoxCreateOnlySelectAsClass = "Crud sınıfı içinde sadece 'SelectAs[Class]List' metodu bulunacak ise, bu seçeneği işaretleyin. Bu özellik, Stored Procedure'den gelen DataTable tipindeki verinin Class tipinde geri döndürülebilmesinin yeterli olduğu durumda kullanılır.";

            public const string textBoxInterfaceSubPath1 = "Interface projesinin bulunduğu klasör ve \r\nInterface sınıflarının yer alacağı alt klasörden oluşan alt dizin.";
            public const string textBoxCcSubPath1 = "Crud-Class projesinin bulunduğu klasör ve \r\nüretilen (generated) sınıfların yer alacağı alt klasörden oluşan alt dizin.";
            public const string textBoxTypeSubPath1 = "Enumeration ve Typed-Dataset nesneleri içeren Types projesinin bulunduğu klasör ve \r\nilgili sınıfların yer alacağı alt klasörden oluşan alt dizin.";

            public const string textBoxInterfaceSubPath2= "Veritabanındaki her bir şema (schema) için üretilen alt klasör.";
            public const string textBoxCcSubPath2 = "Veritabanındaki her bir şema (schema) için üretilen alt klasör.";
            public const string textBoxTypeSubPath2 = "Veritabanındaki her bir şema (schema) için üretilen alt klasör.";

            public const string textBoxConnectionStringName = "Veri tabanı bağlantı cümlesi adı.\r\n\r\nConfig dosyasında veya registry'de birden fazla bağlantı cümlesi farklı isimlerle tutulabilir ve\r\nüretilen her bir sınıfın hangi bağlantı cümlesini kullanacağı bu parametre ile belirtilir.";
        }

        public class TooltipEn
        {
            public const string ToolTipTitle = "Information";
            public const string checkBoxSelectMultyTables = "To generate classes for more then one tables at a time \r\ncheck this option and select tables.";
            public const string buttonConnectToDb = "Connect To DataBase and load Schemas";
            public const string buttonGetTables = "Load all tables under selected schema";
            public const string buttonCreateStrings = "Create EndPoint and Cache Items";
            public const string buttonCleanCacheItemWeb = "Clean";
            public const string buttonCleanCacheItemServer = "Clean";
            public const string buttonCleanEndPoint = "Clean";
            public const string textBoxInheritanceClassNameForCC = "If you want to Inherit CC class from any base or other class,\r\nwrite here a class name. Forex: CCGDalBase";
            public const string buttonProjectPath = "Browse project path";

            public const string textBoxProjectPath = "Class Library or WCF project directory.";
            public const string textBoxClassName = "Parameter Class Name";
            public const string textBoxInterfaceClassName = "Interface Class Name";
            public const string textBoxCrudClassName = "Crud Class (CC) Name";

            public const string checkBoxCrudCC = "If you check this property, CRUD process (CC) class is generated.";
            public const string checkBoxCrudInterface = "If you check this property, Interface class is generated.";

            public const string checkBoxPrmClassInInterfaceFile = "If you check this property, parameter classes are written in same file with Interface class.";
            public const string checkBoxPrmClassInCCFile = "If you check this property, parameter classes are written in same file with CRUD process (CC) class.";
            public const string checkBoxPrmClassSeparate = "If you check this property, parameter classes are written in separate file.";
            public const string checkBoxTemplateCc = "If you check this property, a template CC class is generated as \"partial\".";
            public const string checkBoxTemplateInterface = "If you check this property, a template Interface class is generated as \"partial\"..";

            public const string radioButtonUseInterfacePath = "Check this option to write the parameter class to the Interface directory.";
            public const string radioButtonUseCCPath = "Check this option to write the parameter class to the Crud Class directory.";

            public const string checkBoxTypedDs = "If you check this property \"SelectAsTypedDataSet\" and \r\n\"InsertOrUpdate\" methods are added.";
            public const string checkBoxAddNoLock = "To Add \"WITH(NOLOCK)\" for Select Caluses check this property";
            public const string checkBoxAddServiceContract = "To Create an EndPoint on generated Interface, \r\nyou should add \"ServiceContract\" attribute.";
            public const string checkBoxPrmClass = "To generate parameter class inside CRUD Interface, check this option";
            public const string linkLabelGenerateTrigger = "If you want to log Insert and Update process via trigger\r\ninstead of code, you can generate necessary trigger script\r\nfile for each table by clicking this button.";
            public const string checkBoxCustomNamesapce = "If checked: written \"Subpath\" is used as \"namespace\".\r\nIf not checked: \"namespace\" is computed automaticaly.";
            public const string textBoxFullTableNameForLog = "If you will use nondefault log table, \r\nwrite full name of new log table here with combination of \"DataBase.Schema.Table\".";
            public const string textBoxInheritanceClassNameForPrm = "If you want to Inherit parameter class from any base or other class,\r\nwrite here that class name.";
            public const string checkBoxCreateOnlySelect = "To create only select methods in Crud classes, check this option.\r\nIn this case; Insert, Save, Update and Delete methods will nor be created.";
            public const string checkBoxCreateOnlySelectAsClass = "To create only 'SelectAs[Class]List' method in Crud classes, check this option.\r\nUse this option if only you need to return DataTable type data as class type.";

            public const string buttonGetSchemas = "Load all schemas which are defined under connected database";
            public const string checkBoxPkIsIdentity = "If PK (Primary Key) was setted as identity then, check;\r\nOtherwise uncheck this option.";
            public const string textBoxLookupPrefix = "If you use a prefix for Schema of lookup tables (recomended), \r\nthen write here that prefix. Recomended prefixes: TT_; LT_; PRM_\r\n" +
                                                        "\r\n\r\nNOTE: This field is used to join look-up tables into \"select\" clause. If this field leaved empty," +
                                                        "\r\n\"JoinWithLookupTables\" property can not be used.";

            public const string rdbOracle = "To set database type as ORACLE, check this option.";
            public const string rdbMsSql = "To set database type as MS SQL, check this option.";
            public const string linkLabelSetNmSpsClassNames = "To set Namespace and Class names automaticly according to selected table, click this button." +
                                                        "\r\n\r\nNOTE: When a table name was selected, namespace and class names are set automatically," +
                                                        "but if these names were changed manually and if you want to undo these changes, you can use this button.";
            public const string pictureBoxNoConnection = "Database connection failed!";
            public const string pictureBoxConnectionOk = "Connected to database.";
            public const string buttonSaveConnStr = "Save ConnectionString for selected database type.";
            public const string linkLabelLoadColumns = "Load selected table columns.";

            public const string textBoxDataSetSuffix = "Suffix to add cretaed DataSet";
            public const string textBoxAttributesNamespace = "Path, at the same time namespace where atrributes will take place in created DataSet.";
            public const string comboBoxTextField = "Column name, the name of the Enum is taken from there";
            public const string comboBoxValueField = "Column name, the value of the Enum is taken from there.";
            public const string comboBoxDescription = "Column name, the description of the Enum is taken from there.";
            public const string checkBoxUseEnumNameWithoutChange = "If this option is checked, Enum names are created as written in related column.";
            public const string checkBoxAddUnderscoreBetweenWords = "If this option is checked, Enum names are created by adding underscore between words.";
            public const string checkBoxEnumWithDescription = "If this option is checked, description is added onto Enum names.";
            public const string checkBoxCreateOnlyConstants = "If this option is checked, only 'struct' is created which includes constants.";
            public const string checkBoxUseDbScript = "If this option is checked, Enum informations are taken from database query.";
            public const string textBoxEnumPrefix = "Suffix to add cretaed Enum.";
            public const string textBoxEnumSuffix = "Prefix to add cretaed Enum.";
            public const string checkBoxAutoSetClassName = "While this option is checked, class name is generated automatically based on table name.\r\nOtherwise, table name is used as class name.";

            public const string textBoxInterfaceSubPath1 = "Sub directory containing Interface project and \r\nsub folder of Interface classes.";
            public const string textBoxCcSubPath1 = "Sub directory containing Crud-Class project and \r\nsub folder of generated classes.";
            public const string textBoxTypeSubPath1 = "Sub directory containing Types project which includes Enumeration and Typed-Dataset objects and \r\nsub folder of related classes.";

            public const string textBoxInterfaceSubPath2 = "Sub folder which is generated for each schema on database.";
            public const string textBoxCcSubPath2 = "Sub folder which is generated for each schema on database.";
            public const string textBoxTypeSubPath2 = "Sub folder which is generated for each schema on database.";

            public const string textBoxConnectionStringName = "Connection string name.\r\n\r\n.Multiple connection strings in the configuration file or in the registry can be stored with different names, and\r\nconnection string set by this parameter for each generated class.";
        }
    }

    partial class FormMain
    {
        public void SetTooltips()
        {
            bool langTr = Language.LangTr;

            this.toolTipMain.ToolTipTitle = langTr ? Tooltips.TooltipTr.ToolTipTitle : Tooltips.TooltipEn.ToolTipTitle;

            this.toolTipMain.SetToolTip(checkBoxSelectMultyTables, langTr ? Tooltips.TooltipTr.checkBoxSelectMultyTables : Tooltips.TooltipEn.checkBoxSelectMultyTables);
            this.toolTipMain.SetToolTip(buttonConnectToDb, langTr ? Tooltips.TooltipTr.buttonConnectToDb : Tooltips.TooltipEn.buttonConnectToDb);
            this.toolTipMain.SetToolTip(buttonGetTables, langTr ? Tooltips.TooltipTr.buttonGetTables : Tooltips.TooltipEn.buttonGetTables);
            this.toolTipMain.SetToolTip(buttonCreateStrings, langTr ? Tooltips.TooltipTr.buttonCreateStrings : Tooltips.TooltipEn.buttonCreateStrings);
            this.toolTipMain.SetToolTip(buttonCleanCacheItemWeb, langTr ? Tooltips.TooltipTr.buttonCleanCacheItemWeb : Tooltips.TooltipEn.buttonCleanCacheItemWeb);
            this.toolTipMain.SetToolTip(buttonCleanCacheItemServer, langTr ? Tooltips.TooltipTr.buttonCleanCacheItemServer : Tooltips.TooltipEn.buttonCleanCacheItemServer);
            this.toolTipMain.SetToolTip(buttonCleanEndPoint, langTr ? Tooltips.TooltipTr.buttonCleanEndPoint : Tooltips.TooltipEn.buttonCleanEndPoint);
            this.toolTipMain.SetToolTip(textBoxInheritanceClassNameForCC, langTr ? Tooltips.TooltipTr.textBoxInheritanceClassNameForCC : Tooltips.TooltipEn.textBoxInheritanceClassNameForCC);
            this.toolTipMain.SetToolTip(buttonProjectPath, langTr ? Tooltips.TooltipTr.buttonProjectPath : Tooltips.TooltipEn.buttonProjectPath);
            this.toolTipMain.SetToolTip(checkBoxTypedDs, langTr ? Tooltips.TooltipTr.checkBoxTypedDs : Tooltips.TooltipEn.checkBoxTypedDs);
            this.toolTipMain.SetToolTip(checkBoxAddNoLock, langTr ? Tooltips.TooltipTr.checkBoxAddNoLock : Tooltips.TooltipEn.checkBoxAddNoLock);
            this.toolTipMain.SetToolTip(checkBoxAddServiceContract, langTr ? Tooltips.TooltipTr.checkBoxAddServiceContract : Tooltips.TooltipEn.checkBoxAddServiceContract);
            this.toolTipMain.SetToolTip(checkBoxPrmClassInInterfaceFile, langTr ? Tooltips.TooltipTr.checkBoxPrmClass : Tooltips.TooltipEn.checkBoxPrmClass);
            this.toolTipMain.SetToolTip(linkLabelGenerateTrigger, langTr ? Tooltips.TooltipTr.linkLabelGenerateTrigger : Tooltips.TooltipEn.linkLabelGenerateTrigger);
            this.toolTipMain.SetToolTip(checkBoxAutoSetNamesapce, langTr ? Tooltips.TooltipTr.checkBoxCustomNamesapce : Tooltips.TooltipEn.checkBoxCustomNamesapce);
            this.toolTipMain.SetToolTip(textBoxFullTableNameForLog, langTr ? Tooltips.TooltipTr.textBoxFullTableNameForLog : Tooltips.TooltipEn.textBoxFullTableNameForLog);
            this.toolTipMain.SetToolTip(textBoxInheritanceClassNameForPrm, langTr ? Tooltips.TooltipTr.textBoxInheritanceClassNameForPrm : Tooltips.TooltipEn.textBoxInheritanceClassNameForPrm);

            this.toolTipMain.SetToolTip(checkBoxCreateOnlySelect, langTr ? Tooltips.TooltipTr.checkBoxCreateOnlySelect : Tooltips.TooltipEn.checkBoxCreateOnlySelect);
            this.toolTipMain.SetToolTip(buttonGetSchemas, langTr ? Tooltips.TooltipTr.buttonGetSchemas : Tooltips.TooltipEn.buttonGetSchemas);
            this.toolTipMain.SetToolTip(checkBoxPkIsIdentity, langTr ? Tooltips.TooltipTr.checkBoxPkIsIdentity : Tooltips.TooltipEn.checkBoxPkIsIdentity);
            this.toolTipMain.SetToolTip(textBoxLookupPrefix, langTr ? Tooltips.TooltipTr.textBoxLookupPrefix : Tooltips.TooltipEn.textBoxLookupPrefix);
            this.toolTipMain.SetToolTip(rdbOracle, langTr ? Tooltips.TooltipTr.rdbOracle : Tooltips.TooltipEn.rdbOracle);
            this.toolTipMain.SetToolTip(rdbMsSql, langTr ? Tooltips.TooltipTr.rdbMsSql : Tooltips.TooltipEn.rdbMsSql);
            this.toolTipMain.SetToolTip(linkLabelSetNmSpsClassNames, langTr ? Tooltips.TooltipTr.linkLabelSetNmSpsClassNames : Tooltips.TooltipEn.linkLabelSetNmSpsClassNames);
            this.toolTipMain.SetToolTip(pictureBoxNoConnection, langTr ? Tooltips.TooltipTr.pictureBoxNoConnection : Tooltips.TooltipEn.pictureBoxNoConnection);
            this.toolTipMain.SetToolTip(pictureBoxConnectionOk, langTr ? Tooltips.TooltipTr.pictureBoxConnectionOk : Tooltips.TooltipEn.pictureBoxConnectionOk);
            this.toolTipMain.SetToolTip(buttonSaveConnStr, langTr ? Tooltips.TooltipTr.buttonSaveConnStr : Tooltips.TooltipEn.buttonSaveConnStr);
            this.toolTipMain.SetToolTip(linkLabelLoadColumns, langTr ? Tooltips.TooltipTr.linkLabelLoadColumns : Tooltips.TooltipEn.linkLabelLoadColumns);

            this.toolTipMain.SetToolTip(textBoxDataSetSuffix, langTr ? Tooltips.TooltipTr.textBoxDataSetSuffix : Tooltips.TooltipEn.textBoxDataSetSuffix);
            this.toolTipMain.SetToolTip(textBoxAttributesNamespace, langTr ? Tooltips.TooltipTr.textBoxAttributesNamespace : Tooltips.TooltipEn.textBoxAttributesNamespace);
            this.toolTipMain.SetToolTip(comboBoxTextField, langTr ? Tooltips.TooltipTr.comboBoxTextField : Tooltips.TooltipEn.comboBoxTextField);
            this.toolTipMain.SetToolTip(comboBoxValueField, langTr ? Tooltips.TooltipTr.comboBoxValueField : Tooltips.TooltipEn.comboBoxValueField);
            this.toolTipMain.SetToolTip(comboBoxDescription, langTr ? Tooltips.TooltipTr.comboBoxDescription : Tooltips.TooltipEn.comboBoxDescription);
            this.toolTipMain.SetToolTip(checkBoxUseEnumNameWithoutChange, langTr ? Tooltips.TooltipTr.checkBoxUseEnumNameWithoutChange : Tooltips.TooltipEn.checkBoxUseEnumNameWithoutChange);
            this.toolTipMain.SetToolTip(checkBoxAddUnderscoreBetweenWords, langTr ? Tooltips.TooltipTr.checkBoxSeparateEnumName : Tooltips.TooltipEn.checkBoxAddUnderscoreBetweenWords);
            this.toolTipMain.SetToolTip(checkBoxEnumWithDescription, langTr ? Tooltips.TooltipTr.checkBoxWithDescription : Tooltips.TooltipEn.checkBoxEnumWithDescription);
            this.toolTipMain.SetToolTip(checkBoxCreateOnlyConstants, langTr ? Tooltips.TooltipTr.checkBoxCreateConstantsOnly : Tooltips.TooltipEn.checkBoxCreateOnlyConstants);
            this.toolTipMain.SetToolTip(checkBoxUseDbScript, langTr ? Tooltips.TooltipTr.checkBoxUseDbScript : Tooltips.TooltipEn.checkBoxUseDbScript);
            this.toolTipMain.SetToolTip(textBoxEnumPrefix, langTr ? Tooltips.TooltipTr.textBoxEnumPrefix : Tooltips.TooltipEn.textBoxEnumPrefix);
            this.toolTipMain.SetToolTip(textBoxEnumSuffix, langTr ? Tooltips.TooltipTr.textBoxEnumSuffix : Tooltips.TooltipEn.textBoxEnumSuffix);

            this.toolTipMain.SetToolTip(textBoxProjectPath, langTr ? Tooltips.TooltipTr.textBoxProjectPath : Tooltips.TooltipEn.textBoxProjectPath);
            this.toolTipMain.SetToolTip(textBoxClassName, langTr ? Tooltips.TooltipTr.textBoxClassName : Tooltips.TooltipEn.textBoxClassName);
            this.toolTipMain.SetToolTip(textBoxInterfaceClassName, langTr ? Tooltips.TooltipTr.textBoxInterfaceClassName : Tooltips.TooltipEn.textBoxInterfaceClassName);
            this.toolTipMain.SetToolTip(textBoxCrudClassName, langTr ? Tooltips.TooltipTr.textBoxCrudClassName : Tooltips.TooltipEn.textBoxCrudClassName);
            this.toolTipMain.SetToolTip(checkBoxCrudCC, langTr ? Tooltips.TooltipTr.checkBoxCrudCC : Tooltips.TooltipEn.checkBoxCrudCC);
            this.toolTipMain.SetToolTip(checkBoxCrudInterface, langTr ? Tooltips.TooltipTr.checkBoxCrudInterface : Tooltips.TooltipEn.checkBoxCrudInterface);
            this.toolTipMain.SetToolTip(checkBoxPrmClassInInterfaceFile, langTr ? Tooltips.TooltipTr.checkBoxPrmClassInInterfaceFile : Tooltips.TooltipEn.checkBoxPrmClassInInterfaceFile);
            this.toolTipMain.SetToolTip(checkBoxPrmClassInCCFile, langTr ? Tooltips.TooltipTr.checkBoxPrmClassInCCFile : Tooltips.TooltipEn.checkBoxPrmClassInCCFile);
            this.toolTipMain.SetToolTip(checkBoxPrmClassSeparate, langTr ? Tooltips.TooltipTr.checkBoxPrmClassSeparate : Tooltips.TooltipEn.checkBoxPrmClassSeparate);
            this.toolTipMain.SetToolTip(checkBoxTemplateCc, langTr ? Tooltips.TooltipTr.checkBoxTemplateCc : Tooltips.TooltipEn.checkBoxTemplateCc);
            this.toolTipMain.SetToolTip(checkBoxTemplateInterface, langTr ? Tooltips.TooltipTr.checkBoxTemplateInterface : Tooltips.TooltipEn.checkBoxTemplateInterface);
            this.toolTipMain.SetToolTip(checkBoxAutoSetClassName, langTr ? Tooltips.TooltipTr.checkBoxAutoSetClassName : Tooltips.TooltipEn.checkBoxAutoSetClassName);

            this.toolTipMain.SetToolTip(radioButtonUseInterfacePath, langTr ? Tooltips.TooltipTr.radioButtonUseInterfacePath : Tooltips.TooltipEn.radioButtonUseInterfacePath);
            this.toolTipMain.SetToolTip(radioButtonUseCCPath, langTr ? Tooltips.TooltipTr.radioButtonUseCCPath : Tooltips.TooltipEn.radioButtonUseCCPath);

            this.toolTipMain.SetToolTip(textBoxInterfaceSubPath1, langTr ? Tooltips.TooltipTr.textBoxInterfaceSubPath1 : Tooltips.TooltipEn.textBoxInterfaceSubPath1);
            this.toolTipMain.SetToolTip(textBoxCcSubPath1, langTr ? Tooltips.TooltipTr.textBoxCcSubPath1 : Tooltips.TooltipEn.textBoxCcSubPath1);
            this.toolTipMain.SetToolTip(textBoxTypeSubPath1, langTr ? Tooltips.TooltipTr.textBoxTypeSubPath1 : Tooltips.TooltipEn.textBoxTypeSubPath1);

            this.toolTipMain.SetToolTip(textBoxInterfaceSubPath2, langTr ? Tooltips.TooltipTr.textBoxInterfaceSubPath2 : Tooltips.TooltipEn.textBoxInterfaceSubPath2);
            this.toolTipMain.SetToolTip(textBoxCcSubPath2, langTr ? Tooltips.TooltipTr.textBoxCcSubPath2 : Tooltips.TooltipEn.textBoxCcSubPath2);
            this.toolTipMain.SetToolTip(textBoxTypeSubPath2, langTr ? Tooltips.TooltipTr.textBoxTypeSubPath2 : Tooltips.TooltipEn.textBoxTypeSubPath2);

            this.toolTipMain.SetToolTip(textBoxConnectionStringName, langTr ? Tooltips.TooltipTr.textBoxConnectionStringName : Tooltips.TooltipEn.textBoxConnectionStringName);
        }
    }
}
