using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDR_Viewer.models
{
    public class field
    {
        public string Name{get;set;}
        public string DataType{get;set;}
        public string FieldType{get;set;}

        public bool IsPrimaryKey
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Name)) return false;

                if (Name.IndexOf("_pk_") > 0)
                {
                    return true;
                }

                return false;
            }
        }

        public string IsPrimaryKeyString
        {
            get
            {
                return IsPrimaryKey ? " PRIMARY KEY": " ";
            }
        }


        public string NameForSql
        {
            get
            {
                string result = Name;
                result = string.Format("\"{0}\"",Name);
                return result;
            }
        }
        public string TypeForSqlServer
        {
            get
            {
                switch (DataType)
                {
                    case "Number":
                        return "Decimal";
                    case "Text":
                        return "NVarchar";
                    case "Date":
                        return "Date";
                    case "Time":
                        return "Time";
                    case "TimeStamp":
                        return "Datetime";
                    case "Binary":
                        return "Binary";
                    default:
                        throw new FormatException("DataTypeをSql Server対応型に変換出来ません {0}");
                }
            }
        }
    }
}
