namespace stickers;

public class ImageExtensionsException : Exception
{
    public ImageExtensionsException() { }
    public ImageExtensionsException(string message) : base(message) { }
    public ImageExtensionsException(string message, Exception inner) : base(message, inner) { }
    protected ImageExtensionsException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}
