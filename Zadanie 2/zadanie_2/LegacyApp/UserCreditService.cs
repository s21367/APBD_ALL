﻿using System;

namespace LegacyApp
{
    public class UserCreditService : IDisposable
    {
        public void Dispose()
        {
           
        }

        internal int GetCreditLimit(string firstName, string lastName, DateTime dateOfBirth)
        {
           
            return 10000;
        }
    }
}