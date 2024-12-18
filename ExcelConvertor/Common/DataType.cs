using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bass.Tools.Common
{
    /// <summary>
    /// 프로그램에서 사용하는 데이터 타입과 크기 정보
    /// </summary>
    public class DataType
    {
        public EDataType Type { get; set; } = EDataType.None;
        public int Size { get; set; } = 0;

        public DataType(EDataType type = EDataType.None, int size = 0)
        {
            Type = type;
            Size = size;
        }

        



    }
}
