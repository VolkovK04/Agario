namespace Agario_v2
{
    class IdGenerator
    {
        private int IdCount = 0;
        public int SetId()
        {
            IdCount++;
            return IdCount;
        }
    }
}
