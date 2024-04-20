namespace Communal.Application.Constants;

public static class RedisKeys
{
    public static string ProductPrefix => "product";
    public static string UserPrefix => "user";
    public static string OrderPrefix => "order";
    public static string UserKey(int userId) => $"{UserPrefix}:{userId}";
    public static string ProductKey(int productId) => $"{ProductPrefix}:{productId}";
    public static string OrderKey(int orderId) => $"{OrderPrefix}:{orderId}";
}