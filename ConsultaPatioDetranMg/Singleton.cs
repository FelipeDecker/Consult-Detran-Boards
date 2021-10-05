namespace ConsultaPatioDetranMg
{
    public sealed class Singleton<T> where T : class, new()
    {
        private static T Instancia;

        public static T Instanciar()
        {
            lock (typeof(T))
                if (Instancia == null) Instancia = new T();

            return Instancia;
        }
    }
}
