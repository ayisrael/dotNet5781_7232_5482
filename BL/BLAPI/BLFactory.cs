﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;

namespace BLAPI
{
    public static class BLFactory
    {
        public static IBL GetBL(string type)
        {
            switch (type)
            {
                case "BLImp":
                    return new BLImp();
                default:
                    return new BLImp();
            }
        }
    }
    public  class a
    {
        IBL d = new BLAPI.BLFactory.GetBL("BLImp");
    }
}