using Bass.Tools.ExcelConvertor.Common;

namespace Bass.Tools.Core.Database
{
    public static class DBControllerUtil
    {
        public static string DBNaming(this string name, ETargetType target)
        {
            switch (target)
            {
                case ETargetType.MSSQL:
                    return $"[{name}]";
                case ETargetType.MySQL:
                    return $"`{name}`";
                case ETargetType.SQLite:
                    return $"\"{name}\"";
                default:
                    return name;
            }
        }
    }
}
