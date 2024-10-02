using Problem_Sloving.Problems;

namespace Problem_Sloving
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //#PALINDROME
            //Palindrome palindrome = new Palindrome();
            //palindrome.Palindrom_In_ForLoop();
            //palindrome.Palindrom_In_ForEach();
            //palindrome.Palindrom_In_While();
            //palindrome.Palindrom_In_DoWhile();

            //#STAR PATTEN
            //StarPatten starPatten = new StarPatten();
            //starPatten.PrintSqure();
            //starPatten.PrintTriange();

            //#REGEX
            //RegexValidation regexValidation = new RegexValidation();
            //regexValidation.EMail_Validation();

            FileOperations fileOperations = new FileOperations();
            //fileOperations.CreateTextFile_With_Async();
            //fileOperations.CreateTextFile_By_Lines_With_Parallel_ForEach();
            //fileOperations.CreateTextFile_By_Lines_With_MemoryStream();
            //fileOperations.CreateTextFile_By_Bytes_With_Parallel_ForEach();
            fileOperations.CreateTextFile_By_Lines_With_MemoryStream_Chunks();

        }
    }
}
//59087075339

