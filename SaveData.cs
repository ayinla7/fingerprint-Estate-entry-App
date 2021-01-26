using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfredGardens
{
    class SaveData
    {
       protected int q;
        public void Savedata(int k)
        {
            int q = k;
        }
        public  void setdata(int k)
        {
            int q = k;
        }
        public int getdata()
        {
           
            return q;
        }
        public void cleardata()
        {
            int q = 0;
        }

    }
}
