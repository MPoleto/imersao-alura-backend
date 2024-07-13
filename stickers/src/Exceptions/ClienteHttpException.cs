namespace stickers;

public class ClienteHttpException : Exception
{
    public ClienteHttpException() {}
    public ClienteHttpException(string message) : base(message) 
    {
        Console.WriteLine("Vixi! Ocorreu um erro durante a consulta a API. Este URI tá certo?");
    }
    public ClienteHttpException(string message, Exception inner) : base(message, inner) {}
    public ClienteHttpException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) {}

}
