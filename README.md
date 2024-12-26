# ExcelConvertor

엑셀 파일을 게임에서 사용하기 위한 리소스로 변환해주는 툴 입니다.<br/>

## 사용한 nuget 라이브러리
이 프로젝트는 다음 라이브러리들의 nuget package 를 사용하였습니다. <br/>
각 라이브러리들의 라이센스는 각 프로젝트의 라이센스를 참고하시기 바랍니다.<br/>

- ClosedXML (MIT License, https://github.com/ClosedXML/ClosedXML)
- Newtonsoft.Json (MIT License, https://www.newtonsoft.com/json)
- System.Data.SQLite.Core (Public Domain, https://system.data.sqlite.org/index.html/doc/trunk/www/index.wiki)

## 사용 방법

### 변환 가능한 타입
- SQLite .db
- 데이터베이스 스크립트 (스키마 생성, 데이터 Insert)
  - MySQL
  - MSSQL
- 프로그래밍 언어 데이터 구조 소스코드.
  - C#
  - C++
### 엑셀 파일 지원 데이터타입 및 변환표
<table>
  <tr>
    <th>엑셀파일 타입</th>
    <th>SQLite</th>
    <th>MySQL</th>
    <th>MSSQL</th>
    <th>C#</th>
    <th>C++</th>
  </tr>
  
  <tr>
    <td>int8</td>
    <td rowspan=3>INTEGER</td>
    <td rowspan=3>tinyint</td>
    <td rowspan=3>tinyint</td>
    <td rowspan=3>sbyte</td>
    <td rowspan=3>char</td>
  </tr>
  <tr>
    <td>tinyint</td>
  </tr>
  <tr>
    <td>byte</td>
  </tr>
  
  <tr>
    <td>int16</td>
    <td rowspan=3>INTEGER</td>
    <td rowspan=3>smallint</td>
    <td rowspan=3>smallint</td>
    <td rowspan=3>short</td>
    <td rowspan=3>short</td>
  </tr>
  <tr>
    <td>short</td>
  </tr>
  <tr>
    <td>smallint</td>
  </tr>
  
  <tr>
    <td>int32</td>
    <td rowspan=2>INTEGER</td>
    <td rowspan=2>int</td>
    <td rowspan=2>int</td>
    <td rowspan=2>int</td>
    <td rowspan=2>int</td>
  </tr>
  <tr>
    <td>int</td>
  </tr>
  
  <tr>
    <td>int64</td>
    <td rowspan=3>INTEGER</td>
    <td rowspan=3>bigint</td>
    <td rowspan=3>bigint</td>
    <td rowspan=3>long</td>
    <td rowspan=3>long long</td>
  </tr>
  <tr>
    <td>long</td>
  </tr>
  <tr>
    <td>bigint</td>
  </tr>

  <tr>
    <td>float</td>
    <td rowspan=3>REAL</td>
    <td rowspan=3>float</td>
    <td rowspan=3>float</td>
    <td rowspan=3>float</td>
    <td rowspan=3>float</td>
  </tr>
  <tr>
    <td>single</td>
  </tr>
  <tr>
    <td>float32</td>
  </tr>

  <tr>
    <td>double</td>
    <td rowspan=3>REAL</td>
    <td rowspan=3>double</td>
    <td rowspan=3>double</td>
    <td rowspan=3>double</td>
    <td rowspan=3>double</td>
  </tr>
  <tr>
    <td>float64</td>
  </tr>
  <tr>
    <td>real</td>
  </tr>

  <tr>
    <td>string</td>
    <td rowspan=4>TEXT</td>
    <td rowspan=4>varchar</td>
    <td rowspan=4>nvarchar</td>
    <td rowspan=4>string</td>
    <td rowspan=4>std::string</td>
  </tr>
  <tr>
    <td>text</td>
  </tr>
  <tr>
    <td>varchar(x)</td>
  </tr>
  <tr>
    <td>nvarchar(x)</td>
  </tr>

  <tr>
    <td>date</td>
    <td rowspan=2>TEXT</td>
    <td rowspan=2>datetime</td>
    <td rowspan=2>datetime</td>
    <td rowspan=2>DateTime</td>
    <td rowspan=2>std::string</td>
  </tr>
  <tr>
    <td>datetime</td>
  </tr>


  <tr>
    <td>bool</td>
    <td rowspan=3>INTEGER</td>
    <td rowspan=3>bit</td>
    <td rowspan=3>bit</td>
    <td rowspan=3>bool</td>
    <td rowspan=3>bool</td>
  </tr>
  <tr>
    <td>boolean</td>
  </tr>
  <tr>
    <td>bit</td>
  </tr>
 
</table>


