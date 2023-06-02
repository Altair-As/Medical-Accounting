namespace WebApplicationAuth.Data.Classes
{
    public class DocxFileCopier
    {
        public void CopyDocxFile(string sourceFilePath, string destinationFilePath)
        {
            File.Copy(sourceFilePath, destinationFilePath, true);
        }
    }
}
