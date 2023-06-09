namespace WebApplicationAuth.Exceptions
{
    public class MyValidationException : Exception
    {
        // Объявление класса пользовательской ошибки
        public MyValidationException(string message) : base(message) 
        {
            
        }
    }
}
