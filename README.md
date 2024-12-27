# ExcelConvertor

엑셀 파일을 게임에서 사용하기 위한 리소스로 변환해주는 툴 입니다.<br/>

## 사용한 nuget 라이브러리
이 프로젝트는 다음 라이브러리들의 nuget package 를 사용하였습니다. <br/>
각 라이브러리들의 라이센스는 각 프로젝트의 라이센스를 참고하시기 바랍니다.<br/>

- ClosedXML (MIT License, https://github.com/ClosedXML/ClosedXML)
- Newtonsoft.Json (MIT License, https://www.newtonsoft.com/json)
- System.Data.SQLite.Core (Public Domain, https://system.data.sqlite.org/index.html/doc/trunk/www/index.wiki)

## 사용 방법
<img src="https://github.com/garshion/ExcelConvertor/blob/main/res/usage.png?raw=true"/>

1. 변환할 엑셀 파일이 있는 폴더를 지정합니다.
2. 폴더에 있는 엑셀 파일들 중, 변환할 엑셀파일을 선택합니다.
3. 출력 폴더를 지정합니다.
4. 사용할 옵션들을 선택합니다.
5. Convert 버튼을 눌러 변환합니다.

<img src="https://github.com/garshion/ExcelConvertor/blob/main/res/export.png?raw=true"/>

변환이 완료되면, Export Folder 아래 Open Folder 버튼을 눌러 결과 파일을 확인할 수 있습니다.

### 엑셀 파일 형태

<img src="https://github.com/garshion/ExcelConvertor/blob/main/res/excel1.png?raw=true"/>

- 첫 번째 컬럼이 비어있거나 #으로 시작하면, 해당 열은 무시됩니다.
- 처음에 오는 열은 컬럼명, 두 번째 오는 열은 데이터 타입으로 구성되고, 그 이후의 열들은 모두 데이터로 인식합니다.
- 컬럼명이 비어있거나, #으로 시작하면 해당 행은 무시됩니다.
- 컬럼명에 'pk ' 가 붙어있으면 해당 컬럼은 데이터베이스에서 Primary Key 가 됩니다.
- date/datetime 타입의 경우, 비어있다면 '0001-01-01 00:00:00' 으로 입력됩니다.
- bool 타입의 경우 true/false 이외에 정수로도 표현 가능합니다. (value <= 0) 이면 false, (value > 0) 이면 true 로 입력됩니다.

<img src="https://github.com/garshion/ExcelConvertor/blob/main/res/excel2.png?raw=true"/>
  
- 하나의 파일에 여러 개의 시트가 존재 가능합니다.
  - 시트명이 #로 시작하면, 해당 시트는 무시됩니다.
  - 시트명은 C#, C++ 클래스명으로 사용 가능한 형태만 허용됩니다.
- 여러 파일에 같은 이름의 시트가 있는 경우, 구조가 같은 경우 데이터가 합쳐져서 변환됩니다.
  - 컬럼명과 순서, 타입이 일치해야 같은 구조로 판단합니다.  


### 변환 가능한 타입
- SQLite .db
- 데이터베이스 스크립트 (스키마 생성, 데이터 Insert)
  - MySQL
  - MSSQL
- 프로그래밍 언어 데이터 구조 소스코드.
  - C#
  - C++

### 엑셀 파일 지원 데이터타입 및 변환표
<details>
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
</details>


