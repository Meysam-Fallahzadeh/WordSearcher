using WordSearcher;
using WordSearcherTools;

var s = new WordsManager();
var config = new WordSearcherConfig()
{
    FileExtentions = new List<string>() { ".cs" },
    IgnoreFolderPath = "C:\\Users\\m.falahzadeh\\source\\repos\\WordSearcher\\Ignore",
    SourceFolderPath = "D:\\Git-Project\\CompanyProject\\CoreV2",


};
var ss = s.Manager(config);

Console.ReadKey();

