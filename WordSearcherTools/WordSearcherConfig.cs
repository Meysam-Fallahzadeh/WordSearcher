namespace WordSearcherTools;

public class WordSearcherConfig
{
    public string SourceFolderPath { get; set; } = "";  
    public string IgnoreFolderPath { get; set; } = "";
    public List<string> FileExtentions { get; set; } = new List<string>();
    public List<string> IgnoreString {  get; set; }= new List<string>();

}
