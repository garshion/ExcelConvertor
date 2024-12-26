using Bass.Tools.Config;
using Bass.Tools.ExcelConvertor.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Bass.Tools.Core.Programming
{
    public class ProgrammingController : AWorkController
    {
        private const string CPP_EXPORT_FOLDER = "CPP";
        private const string CS_EXPORT_FOLDER = "CSharp";

        private const string SINGLE_FILE_NAME = "ConvertDatas";

        private int mDepth = 0;     // Depth for Tab

        public override bool Process(List<WorkData> datas)
        {
            if (datas.Count == 0)
                return false;   // no data.

            if (ConfigManager.Setting.ExportCPPSourceCode)
            {
                CheckExportFolder(CPP_EXPORT_FOLDER);
                if (!_ExportCPPSourceCode(datas))
                {
                    return false;
                }
            }

            if (ConfigManager.Setting.ExportCSSourceCode)
            {
                CheckExportFolder(CS_EXPORT_FOLDER);
                if (!_ExportCSSourceCode(datas))
                {
                    return false;
                }
            }

            return true;
        }

        private string _GetDepth()
        {
            string ret = string.Empty;
            for (int i = 0; i < mDepth; i++)
                ret += "\t";
            return ret;
        }


        #region C# Source Code Generate

        private bool _ExportCSSourceCode(List<WorkData> datas)
        {
            if (!ConfigManager.Setting.ExportCSSourceCode)
                return false;   // skip C# Source Code Export

            if (!RemoveFiles(CS_EXPORT_FOLDER))
                return false;   // Clean Export Folder Error

            mDepth = 0;

            StringBuilder sb = new StringBuilder();
            if (ConfigManager.Setting.SourceCodeFileOption == EExportFileOption.SingleFile)
            {
                _CSClassHeader(sb);
            }

            foreach (var data in datas)
            {
                if (ConfigManager.Setting.SourceCodeFileOption == EExportFileOption.EachFile)
                {
                    _CSClassHeader(sb);
                }

                _CSClassData(sb, data);

                if (ConfigManager.Setting.SourceCodeFileOption == EExportFileOption.EachFile)
                {
                    _CSClassFooter(sb);
                    string filePath = Path.Combine(ConfigManager.Setting.ExportFolder, CS_EXPORT_FOLDER, $"{data.SheetName}.cs");
                    File.WriteAllText(filePath, sb.ToString());
                    sb.Clear();
                }
            }

            if (ConfigManager.Setting.SourceCodeFileOption == EExportFileOption.SingleFile)
            {
                _CSClassFooter(sb);
                string filePath = Path.Combine(ConfigManager.Setting.ExportFolder, CS_EXPORT_FOLDER, $"{SINGLE_FILE_NAME}.cs");
                File.WriteAllText(filePath, sb.ToString());
            }

            return true;
        }


        private void _CSClassData(StringBuilder sb, WorkData data)
        {
            string structType = "class";

            if (ConfigManager.Setting.SourceCodeDataOption == ESourceCodeDataOption.Struct)
                structType = "struct";


            sb.AppendLine();
            sb.AppendLine($"{_GetDepth()}public {structType} {data.SheetName}");
            sb.AppendLine($"{_GetDepth()}{{");

            mDepth++;

            foreach (var header in data.HeaderInfo)
            {
                sb.AppendLine($"{_GetDepth()}public {header.DataType.GetTypeString(ETargetType.CSharp)} {header.ColumnName} {{ get; set; }} = {header.DataType.Type.GetProgrammingDefaultValue(ETargetType.CSharp)};");
            }

            mDepth--;
            sb.AppendLine($"{_GetDepth()}}}");
        }

        private void _CSClassHeader(StringBuilder sb)
        {
            sb.AppendLine("using System;");
            sb.AppendLine();
            if (ConfigManager.Setting.UseNamespace)
            {
                sb.AppendLine($"namespace {ConfigManager.Setting.NamespaceString}");
                sb.AppendLine("{");
                mDepth++;
            }
        }

        private void _CSClassFooter(StringBuilder sb)
        {
            if (ConfigManager.Setting.UseNamespace)
            {
                mDepth--;
                sb.AppendLine($"{_GetDepth()}}}");
            }
        }

        #endregion


        #region C++ Source Code Generate


        private bool _ExportCPPSourceCode(List<WorkData> datas)
        {
            if (!ConfigManager.Setting.ExportCPPSourceCode)
                return false;   // skip C++ Source Code Export

            if (!RemoveFiles(CPP_EXPORT_FOLDER))
                return false;   // Clean Export Folder Error

            mDepth = 0;

            StringBuilder sb = new StringBuilder();
            if (ConfigManager.Setting.SourceCodeFileOption == EExportFileOption.SingleFile)
            {
                _CPPClassHeader(sb);
            }

            foreach (var data in datas)
            {
                if (ConfigManager.Setting.SourceCodeFileOption == EExportFileOption.EachFile)
                {
                    _CPPClassHeader(sb);
                }

                _CPPClassData(sb, data);

                if (ConfigManager.Setting.SourceCodeFileOption == EExportFileOption.EachFile)
                {
                    _CPPClassFooter(sb);
                    string filePath = Path.Combine(ConfigManager.Setting.ExportFolder, CPP_EXPORT_FOLDER, $"{data.SheetName}.h");
                    File.WriteAllText(filePath, sb.ToString());
                    sb.Clear();
                }
            }

            if (ConfigManager.Setting.SourceCodeFileOption == EExportFileOption.SingleFile)
            {
                _CPPClassFooter(sb);
                string filePath = Path.Combine(ConfigManager.Setting.ExportFolder, CPP_EXPORT_FOLDER, $"{SINGLE_FILE_NAME}.h");
                File.WriteAllText(filePath, sb.ToString());
            }

            return true;
        }

        private void _CPPClassData(StringBuilder sb, WorkData data)
        {
            string structType = "class";

            if (ConfigManager.Setting.SourceCodeDataOption == ESourceCodeDataOption.Struct)
                structType = "struct";

            sb.AppendLine();
            sb.AppendLine($"{_GetDepth()}{structType} {data.SheetName}");
            sb.AppendLine($"{_GetDepth()}{{");

            if (ConfigManager.Setting.SourceCodeDataOption == ESourceCodeDataOption.Class)
                sb.AppendLine($"{_GetDepth()}public:");

            mDepth++;

            foreach (var header in data.HeaderInfo)
            {
                sb.AppendLine($"{_GetDepth()}{header.DataType.GetTypeString(ETargetType.CPlusPlus)} {header.ColumnName} = {header.DataType.Type.GetProgrammingDefaultValue(ETargetType.CPlusPlus)};");
            }

            mDepth--;
            sb.AppendLine($"{_GetDepth()}}};");

        }

        private void _CPPClassHeader(StringBuilder sb)
        {
            sb.AppendLine("#include <string>");
            sb.AppendLine("#include <cstdint>");
            sb.AppendLine();

            if (ConfigManager.Setting.UseNamespace)
            {
                string[] seps = { "." };
                string[] namespaces = ConfigManager.Setting.NamespaceString.Split(seps, StringSplitOptions.RemoveEmptyEntries);

                foreach (var ns in namespaces)
                {
                    sb.AppendLine($"{_GetDepth()}namespace {ns}");
                    sb.AppendLine($"{_GetDepth()}{{");
                    mDepth++;
                }
            }
        }

        private void _CPPClassFooter(StringBuilder sb)
        {
            if (ConfigManager.Setting.UseNamespace)
            {
                string[] seps = { "." };
                string[] namespaces = ConfigManager.Setting.NamespaceString.Split(seps, StringSplitOptions.RemoveEmptyEntries);
                foreach (var ns in namespaces)
                {
                    mDepth--;
                    sb.AppendLine($"{_GetDepth()}}};");
                }
            }
        }

        #endregion


    }
}
