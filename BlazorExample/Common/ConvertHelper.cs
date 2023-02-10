using System.Data;
using System.Reflection;

namespace BlazorExample.Common
{
    public class ConvertHelper
    {
        public static List<T> ConvertToList<T>(DataTable dt)
        {
            List<T> result = new();
            List<string> columNames = dt.Columns.Cast<DataColumn>().Select(col => col.ColumnName.Replace("_", "").ToLower()).ToList();
            PropertyInfo[] properties = typeof(T).GetProperties();
            result = dt.AsEnumerable().Select(row =>
            {
                var objT = Activator.CreateInstance<T>();
                foreach (var pro in properties)
                {
                    if (columNames.Contains(pro.Name.ToLower()))
                    {
                        try
                        {
                            string? findName = dt.Columns.Cast<DataColumn>().FirstOrDefault(x => x.ColumnName.Replace("_", "").ToLower() == pro.Name.ToLower())?.ColumnName;
                            pro.SetValue(objT, row[findName]);
                        }
                        catch (Exception ex) { }
                    }
                }
                return objT;
            }).ToList();

            return result;
        }

    }
}
