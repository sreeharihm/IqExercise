namespace Application.Extensions
{
    public static class ObjectExtensions
    {
        public static bool IsNull(this object model)
        {
            return model == null;
        }
    }
}
