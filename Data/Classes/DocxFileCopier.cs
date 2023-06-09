namespace WebApplicationAuth.Data.Classes
{
    public class DocxFileCopier
    {
        // Копирование файла
        public void CopyDocxFile(string sourceFilePath, string destinationFilePath)
        {
            File.Copy(sourceFilePath, destinationFilePath, true);
        }
    }
}
