# X12ResourceTool

A command line program that generates visual studio resource files (.restext or .resx) from pyx12 transaction specification "maps".  In other words, it reads maps.xml, and generates 2 resource files for each referenced transaction .xml file: a `.Name` and a `.Usage` file.

For example, generated .restext files for 999.5010.xml contain mappings like these:

### 999.5010.xml.Name.restext

Contains the names of segments and elements.

```text
IK4=Implementation Data Element Note
IK4_2=Data Element Reference Number
IK4_3=Implementation Data Element Syntax Error Code
...
```

### 999.5010.xml.Usage.restext

Contains the usage of segments and elements (whether or not it is required).

```text
IK4=S
IK4_2=S
IK4_3=R
IK4_4=S
...
```

# Usage

```text
Usage: X12ResourceTool path\to\maps.xml

When there are several values for a key, these environment variables are used to make a choice.
Each may set to one selector.
set Name_choice=First|OnlyOrEmpty|OnlyOrUncertain|Commas
set Usage_choice=First|OnlyOrEmpty|OnlyOrUncertain|Commas

Supported output formats:
set Resource_Extension=.resx|.restext|.txt

Output directory:
set Output_Directory=.resx|.restext|.txt
```
