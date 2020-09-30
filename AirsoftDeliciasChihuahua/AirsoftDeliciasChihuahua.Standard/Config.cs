using System;
using System.Collections.Generic;
using System.Text;
using OKHOSTING.ORM;
using OKHOSTING.ORM.Model;
using OKHOSTING.ORM.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using OKHOSTING.Core;

namespace AirsoftDeliciasChihuahua.Standard
{
    public class Config
    {
        public void Start()
        {
            BaitAndSwitch.PlatformSpecificConstructors.Add(typeof(DataBase), DataBase_Setup);
            BaitAndSwitch.PlatformSpecificConstructors.Add(typeof(OKHOSTING.SQL.Client), Client_Setup_Local);
            MapTypes();
            Create();
        }

        public static DataBase DataBase_Setup()
        {
            var db = new DataBase(BaitAndSwitch.Create<OKHOSTING.SQL.Client>(), new OKHOSTING.SQL.DbProviders.MySql.SQLGenerator());
            db.BeforeOperation += Db_BeforeOperation;

            return db;
        }

        public static OKHOSTING.SQL.Client Client_Setup_Local()
        {
            OKHOSTING.Core.AppConfig config = new OKHOSTING.Core.AppConfig();

            return new OKHOSTING.SQL.DbProviders.MySql.Client() { ConnectionString = config.GetAppSetting("connectionString") };
        }

        private static void Db_BeforeOperation(DataBase sender, OperationEventArgs eventArgs)
        {
            if (eventArgs.Operation is Insert && eventArgs.Operation.DataType.PrimaryKey.Count() == 1 && eventArgs.Operation.DataType.PrimaryKey.Single().Expression.ReturnType.Equals(typeof(Guid)))
            {
                var pk = eventArgs.Operation.DataType.PrimaryKey.Single();
                object instance = ((Insert)eventArgs.Operation).Instance;
                Guid pkValue = (Guid)pk.Expression.GetValue(instance);

                //create new Guid before insert, if current value is empty
                if (pkValue.Equals(Guid.Empty))
                {
                    pk.SetValueFromColumn(instance, Guid.NewGuid());
                }
            }
        }
    }
}
