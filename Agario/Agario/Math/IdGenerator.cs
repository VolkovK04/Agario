﻿namespace Agario
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
