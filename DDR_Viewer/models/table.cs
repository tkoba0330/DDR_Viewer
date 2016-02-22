using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDR_Viewer.models
{
    public class table
    {
        public table()
        {
            Fields = new List<field>();
        }

        public string Name { get; set; }
        public List<models.field> Fields{ get; set; }
        public string CreateTable 
        {
            get
            {
                return GetSchemaByCreateTable();
            }
        }


        public string GetSchemaByCreateTable()
        {
            string sql = "";

            sql += string.Format("Create Table {0} ( ", Name);
            foreach(var item in Fields)
            {
                sql += string.Format("\n{0} {1} ,", item.NameForSql, item.TypeForSqlServer );
            }
            sql = sql.Substring(0, sql.Length - 1);

            sql += "\n)";

            return sql;
        }
    }
}
