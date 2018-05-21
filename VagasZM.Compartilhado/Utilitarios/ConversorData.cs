using System;

namespace VagasZM.Compartilhado.Utilitarios
{
    public static class ConversorData
    {
        public static long ConverterParaUnixEpochDate(DateTime date)
          => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);
    }
}
